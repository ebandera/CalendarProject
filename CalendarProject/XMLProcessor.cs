using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml;

namespace CalendarProject
{
    class XMLProcessor
    {
        private XmlDocument xmlDoc;
        public XMLProcessor(string content)  //used for reading
        {
            xmlDoc = new XmlDocument();
            xmlDoc.LoadXml(content);
        }
        public XMLProcessor()  //used for writing
        {

        }

        public List<Birthday> LoadBirthdaysForCalendars(List<CalendarGroup> lstCal)
        {
            List<Birthday> lstBirthday = new List<Birthday>();
            foreach (CalendarGroup cal in lstCal)
            {

            
                //get the xml for one calendar
                // cal.Text = cal.Text.Replace("'", "&quot;");
                string expression = XpathExpression(cal.Text);
                XmlNodeList bdNodes = xmlDoc.SelectNodes(@"/xml/Calendar[@Name=" + expression + "]/Birthday");
               
                foreach (XmlNode node in bdNodes)
                {
                    Birthday bd = new CalendarProject.Birthday();
                    bd.FirstName = GetValueFromNode(node.SelectSingleNode("FirstName")).ToString();
                    bd.LastName = GetValueFromNode(node.SelectSingleNode("LastName")).ToString();
                    bd.Birthdate = (DateTime)GetValueFromNode(node.SelectSingleNode("Birthdate"), "date");
                    if(GetValueFromNode(node.SelectSingleNode("Deathdate"), "date")!=null)
                    {
                        bd.Deathdate = (DateTime)GetValueFromNode(node.SelectSingleNode("Deathdate"), "date");
                    }
                    bd.IsDeceased = (Boolean)GetValueFromNode(node.SelectSingleNode("IsDeceased"), "bool");
                    if(GetValueFromNode(node.SelectSingleNode("Notes"))!=null)
                    { bd.Notes = GetValueFromNode(node.SelectSingleNode("Notes")).ToString(); }
                 
                    bd.CalendarNameID = (int)cal.ID;
                    lstBirthday.Add(bd);
                }
            }
            return lstBirthday;
        }
        public List<CalendarGroup> GetCalendarsFromFile()
        {
            XmlNodeList calNodes = xmlDoc.SelectNodes("/xml/Calendar");
            List<CalendarGroup> lstCal = new List<CalendarGroup>();
            foreach(XmlNode node in calNodes)
            {
                string calName=(string)GetValueFromNode(node, "string","Name");
                CalendarGroup temp = new CalendarGroup();
                temp.Text = calName;
                lstCal.Add(temp);
            }
            return lstCal;
        }
        private object GetValueFromNode(XmlNode node, string datatype = "string", string attributename = null)
        {
            if (node == null)
            {
                if (datatype == "bool")
                {
                    return false;
                }
                else
                {
                    return null;
                }

            }
            bool blnFail = false;
            string strValue = "";
            object objOutput = null;

            if (attributename == null)//we're looking for the inner text of the node
            {
                strValue = node.InnerText;
            }
            else //find specified attribute value
            {
                if (node.Attributes[attributename] != null)
                {
                    strValue = node.Attributes[attributename].Value;
                }
                else
                {
                    blnFail = true;
                }
            }

            //next try to convert this to the correct data type
            switch (datatype)
            {
                case "string":
                    objOutput = strValue.Trim();
                    break;
                case "int":
                    int tempint = 0;
                    blnFail = !Int32.TryParse(strValue.Trim(), out tempint);
                    objOutput = tempint;
                    break;
                case "decimal":
                    decimal tempdec = 0;
                    blnFail = !Decimal.TryParse(strValue.Trim(), out tempdec);
                    objOutput = tempdec;
                    break;
                case "float":
                    float tempfloat = 0.0F;
                    blnFail = !float.TryParse(strValue.Trim(), out tempfloat);
                    objOutput = tempfloat;
                    break;
                case "bool":
                    bool tempbln = false;
                    if (strValue.Trim().ToUpper() == "TRUE") { tempbln = true; }
                    else { tempbln = false; }
                    objOutput = tempbln;
                    break;
                case "date":
                    DateTime tempdt;
                    blnFail = !DateTime.TryParse(strValue.Trim(), out tempdt);
                    if (blnFail) { tempdt = DateTime.Now; }
                    objOutput = tempdt;
                    break;
                default:
                    blnFail = true;
                    break;
            }


            if (blnFail == true)
            {
                return null;
            }
            else
            {
                return objOutput;
            }
        }
        private string XpathExpression(string value)
        {
            if(!value.Contains("'"))
            {
                return '\'' + value + '\'';

            }
            else if (!value.Contains("\""))
            {
                return '"' + value + '"';
            }
            else
            {
                return "concat('" + value.Replace("'", "',\"'\",'") + "')";
            }
             
        }

        public string GetExportFileContents(List<CalendarGroup>lstCal)
        {
            XmlDocument doc = new XmlDocument();
            XmlDeclaration xmlDeclaration = doc.CreateXmlDeclaration("1.0", "UTF-8", null);
            XmlElement root = doc.DocumentElement;
            doc.InsertBefore(xmlDeclaration, root);
            XmlElement xml = doc.CreateElement(string.Empty,"xml",string.Empty);
            doc.AppendChild(xml);

            foreach(CalendarGroup cal in lstCal)
            {
                XmlElement calendar = doc.CreateElement(string.Empty, "Calendar", string.Empty);
                calendar.SetAttribute("Name",cal.Text);
                xml.AppendChild(calendar);
                foreach (Birthday bd in cal.lstBD)
                {
                    XmlElement birthday = doc.CreateElement(string.Empty, "Birthday", string.Empty);
                    calendar.AppendChild(birthday);

                    XmlElement firstName = doc.CreateElement(string.Empty, "FirstName", string.Empty);
                    XmlText fName = doc.CreateTextNode(bd.FirstName);
                    firstName.AppendChild(fName);
                    birthday.AppendChild(firstName);
         
                    XmlElement lastName = doc.CreateElement(string.Empty, "LastName", string.Empty);
                    XmlText lName = doc.CreateTextNode(bd.LastName);
                    lastName.AppendChild(lName);
                    birthday.AppendChild(lastName);
                  
                    XmlElement birthDate = doc.CreateElement(string.Empty, "Birthdate", string.Empty);
                    XmlText bDate = doc.CreateTextNode(bd.Birthdate.ToShortDateString());
                    birthDate.AppendChild(bDate);
                    birthday.AppendChild(birthDate);
                   

                    XmlElement isDeceased = doc.CreateElement(string.Empty, "IsDeceased", string.Empty);
                    XmlText isDec = doc.CreateTextNode(bd.IsDeceased.ToString());
                    isDeceased.AppendChild(isDec);
                    birthday.AppendChild(isDeceased);
                   
                    if(bd.Deathdate!=null)
                    {
                        XmlElement deathDate = doc.CreateElement(string.Empty, "Deathdate", string.Empty);
                        XmlText dDate = doc.CreateTextNode(bd.Deathdate.ToShortDateString());
                        deathDate.AppendChild(dDate);
                        birthday.AppendChild(deathDate);
                    }
                    if(bd.Notes!="")
                    {
                        XmlElement notes = doc.CreateElement(string.Empty, "Notes", string.Empty);
                        XmlText not = doc.CreateTextNode(bd.Notes);
                        notes.AppendChild(not);
                        birthday.AppendChild(notes);
                    }
                                   
                }//end Birthday loop
           }//end calendar loop

            return doc.OuterXml;


        }

    }
}
