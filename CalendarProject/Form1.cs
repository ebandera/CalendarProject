using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using LabelPrintInterface;
using System.IO;

namespace CalendarProject
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }
        int CalendarID = 0;
        int BirthdayID = -1;
        string listViewSortType = "default";
        bool listViewSortDirection = true;
        private void button1_Click(object sender, EventArgs e)
        {
            DAL dbBirthdays = new DAL();
            // dbBirthdays.GetBirthdaysForCalendarID(2);
            //  dbBirthdays.GetAllCalendars();
            //dbBirthdays.DeleteBirthday(1);
            // int newID = dbBirthdays.AddBirthday(2, "Katie", "Bandera", new DateTime(1983, 2, 9), true, new DateTime(2012, 6, 6), "Beloved");
            // int newID =dbBirthdays.AddCalendar("Family3");
            //int newID = dbBirthdays.UpdateBirthday(3, 2, "Katie", "Bandera", new DateTime(1983, 2, 9), true, new DateTime(2012, 6, 7), "Beloved Sis");
            int newID = dbBirthdays.UpdateCalendar(1, "original");
           // int stophere = 0;
        }

        private void btnAddEditBd_Click(object sender, EventArgs e)
        {
            AddEditBirthday();//this is for adding

        }
        private void AddEditBirthday(int? editID=null)
        {
            frmAddBirthday addBday = new frmAddBirthday();
            CalendarID = (int)(cboCalendar.SelectedItem as CalendarGroup).ID;
            addBday.CalendarID = CalendarID;
            if(editID!=null)  //if the form has a selected Birthday ID
            {
                addBday.BirthdayID = (int)editID;
                addBday.bd.LoadBirthday((int)editID);
               
            }
                      
            addBday.ShowDialog();
           
            RefreshBirthdays();

        }


        private void btnCreateList_Click(object sender, EventArgs e)
        {
            frmAddCalendar addCal = new frmAddCalendar();
            addCal.ShowDialog();
           
            RefreshCalendars();
            
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            RefreshCalendars();
           
        }
        private void RefreshCalendars()
        {
            CalendarGroup CG = new CalendarProject.CalendarGroup();
            List<CalendarGroup> lstCG = CG.GetAllCalendarGroups();
            cboCalendar.Items.Clear();
            foreach (CalendarGroup cal in lstCG)
            {
                cboCalendar.Items.Add(cal);
            }
            cboCalendar.SelectedIndex = 0;
           
        }

        private void cboCalendar_SelectedIndexChanged(object sender, EventArgs e)
        {
            listViewSortType = "default";
            listViewSortDirection = true;
          
            RefreshBirthdays();

            
          //  listEvent.SelectedIndex = 0;
        }
        private void RefreshBirthdays()
        {
            calBirth.Visible = false;
            calDeath.Visible = false;
            Birthday BE = new Birthday();

            CalendarID = (int)(cboCalendar.SelectedItem as CalendarGroup).ID;
            string strDir = "asc";
            if (listViewSortDirection == false) { strDir = "desc"; }
            List<Birthday> lstBE = BE.GetBirthdaysForCalendar(CalendarID,listViewSortType + " " + strDir);
            listView1.Items.Clear();
            foreach (Birthday bday in lstBE)
            {
                ListViewItem lvi = new ListViewItem(bday.ID.ToString());

                lvi.SubItems.Add(bday.FirstName);
                lvi.SubItems.Add(bday.LastName);
                lvi.SubItems.Add(bday.Birthdate.Month + "/" + bday.Birthdate.Day + "/" + bday.Birthdate.Year);
                listView1.Items.Add(lvi);
            }
        }

        private void listView1_SelectedIndexChanged(object sender, EventArgs e)
        {
            if(listView1.SelectedItems.Count == 0)
            {
                BirthdayID = -1;
                return;
            }
            BirthdayID = Convert.ToInt32(listView1.SelectedItems[0].Text);
            Birthday temp = new Birthday();
            temp.LoadBirthday(BirthdayID);
            calBirth.Visible = true;
            calBirth.SetDate(temp.Birthdate);
            if(temp.IsDeceased)
            {
                calDeath.Visible = true;
                calDeath.SetDate(temp.Deathdate);

            }
            else
            {
                calDeath.Visible = false;
            }
       
          
        }

        private void listView1_DoubleClick(object sender, EventArgs e)
        {
            if (listView1.SelectedItems.Count == 0)
            {
                BirthdayID = -1;
                return;
            }
            BirthdayID = Convert.ToInt32(listView1.SelectedItems[0].Text);
            AddEditBirthday(BirthdayID);
        }

        private void btnRemoveBd_Click(object sender, EventArgs e)
        {
            if (listView1.SelectedItems.Count == 0)
            {
                BirthdayID = -1;
                return;
            }
            DialogResult dr= MessageBox.Show("Are You sure you want to remove the Bithday for " + listView1.SelectedItems[0].SubItems[1].Text + "?", "Remove Birthday", MessageBoxButtons.YesNo);
            if(dr == DialogResult.Yes)
            {
               
                BirthdayID = Convert.ToInt32(listView1.SelectedItems[0].Text);
                Birthday bd = new Birthday();
                bd.ID = BirthdayID;
                bd.DeleteBirthday();

                RefreshBirthdays();
            }
           
        }

        private void btnRemoveList_Click(object sender, EventArgs e)
        {
            DialogResult dr = MessageBox.Show("Are You sure you want to remove the Entire Calendar?", "Remove Birthday", MessageBoxButtons.YesNo);
            if (dr == DialogResult.Yes)
            {
                CalendarID = (int)(cboCalendar.SelectedItem as CalendarGroup).ID;
               
                if (CalendarID != -1)
                {
                    CalendarGroup cal = new CalendarGroup();
                    cal.ID=CalendarID;
                    cal.DeleteCalendar();
                }
                RefreshCalendars();
            }
           
        }

        private void listView1_ColumnClick(object sender, ColumnClickEventArgs e)
        {
            int intColIndex = e.Column;
            switch (intColIndex)
            {
                case 1:  //this is First Name
                    if (listViewSortType == "fName"){ listViewSortDirection = !listViewSortDirection; } else { listViewSortDirection = true; }
                    listViewSortType = "fName";
                    break;
                case 2:  //this is Second Name
                    if (listViewSortType == "lName") { listViewSortDirection = !listViewSortDirection; } else { listViewSortDirection = true; }
                    listViewSortType = "lName";
                    break;
                case 3:  //this is Birthdate (defaut)
                    if (listViewSortType == "default") { listViewSortDirection = !listViewSortDirection; } else { listViewSortDirection = true; }
                    listViewSortType = "default";
                    break;
            }
         
            RefreshBirthdays();
        }

        private void btnAddEditBd_MouseHover(object sender, EventArgs e)
        {
            Button btn = (Button)sender;
            btn.BackColor = Color.MediumBlue;
        }

        private void btnAddEditBd_MouseLeave(object sender, EventArgs e)
        {
            Button btn = (Button)sender;
            btn.BackColor = Color.Navy;
        }

        private void btnPrint_Click(object sender, EventArgs e)
        {
            int nextYear = DateTime.Now.Year + 1;
            CalendarYear cy = new CalendarProject.CalendarYear(nextYear);
            cy.PrepopulateCalendar();

            Birthday bd = new Birthday();
            int id = (int)(cboCalendar.SelectedItem as CalendarGroup).ID;
            List<Birthday> lstBd = bd.GetBirthdaysForCalendar(id, "default");
            cy.AddBirthdaysToCalendar(lstBd);
            PrintMonth(cy);

          

            
        }

        private void PrintMonth(CalendarYear cy)
        {
            LabelPrint lp = new LabelPrint(8.5, 11, 850, 1100);
            foreach(CalendarMonth cm in cy.lstMonth)
            {
                lp.NewPage();
                lp.NewLabel(0,850, 170);
                PageDefinition pd = lp.DefineCustomPage(50);
                pd.SetIndexPosition(0, 0, 0);
               
                lp.AddText("monthlabel", cm.monthName + " " + cm.year, "Arial Black", 36, "regular", 0, 50, 850, 100, "center", "top", false, false);
                lp.NewLabel(1, 114, 30);
                lp.AddText("sunday", "Sunday", "Times New Roman", 12, "regular", 0, 0, 110, 25, "center", "top", true, true);
                lp.NewLabel(2, 114, 30);
                lp.AddText("monday", "Monday", "Times New Roman", 12, "regular", 0, 0, 110, 25, "center", "top", true, true);
                lp.NewLabel(3, 114, 30);
                lp.AddText("tuesday", "Tuesday", "Times New Roman", 12, "regular", 0, 0, 110, 25, "center", "top", true, true);
                lp.NewLabel(4, 114, 30);
                lp.AddText("wednesday", "Wednesday", "Times New Roman", 12, "regular", 0, 0, 110, 25, "center", "top", true, true);
                lp.NewLabel(5, 114, 30);
                lp.AddText("thursday", "Thursday", "Times New Roman", 12, "regular", 0, 0, 110, 25, "center", "top", true, true);
                lp.NewLabel(6, 114, 30);
                lp.AddText("friday", "Friday", "Times New Roman", 12, "regular", 0, 0, 110, 25, "center", "top", true, true);
                lp.NewLabel(7, 114, 30);
                lp.AddText("saturday", "Saturday", "Times New Roman", 12, "regular", 0, 0, 110, 25, "center", "top", true, true);
                int previousMonthNumber = cm.monthNumber - 1;
                int previousMonthYearNumber = cm.year;
                if (previousMonthNumber == 0) { previousMonthNumber = 12;previousMonthYearNumber--; }
                DateTime previousMonth = new DateTime(previousMonthYearNumber, previousMonthNumber, 1);
                int DaysInPreviousMonth = DateTime.DaysInMonth(previousMonthYearNumber, previousMonthNumber);
                int startingPreviousMonthDay = DaysInPreviousMonth - (cm.firstDayIndex - 1);
                int index = 8;
                int counter = 0;
                for (int i=0;i<cm.firstDayIndex;i++)
                {
                    lp.NewLabel(index, 110, 150);
                    lp.AddText("day", startingPreviousMonthDay.ToString(), "Arial", 12, "regular", 0, 0, 110, 150, "left", "top", true, true);
                    index++;
                    counter++;
                    startingPreviousMonthDay++;
                }
                pd.GridOutPosition(new GridLayout(25, 140, 110, 30, 0, 0, 7, 1), 1, 7);
                pd.GridOutPosition(new GridLayout(25, 165, 110, 150, 0, 0, 7, 6), 8, index, 0);
                pd.GridOutPosition(new GridLayout(25, 165, 110, 150, 0, 0, 7, 6),index, 50, cm.firstDayIndex);

                foreach (CalendarDay cd in cm.lstDay)
                {
                    lp.NewLabel(index,110, 150);
                    lp.AddText("day", cd.dayNumber.ToString(), "Arial", 12, "bold", 0, 0, 114, 150, "left", "top", true, false);
                    int spacer = 15;
                    foreach (Birthday bd in cd.lstBirthday)
                    {

                        TextItem ti = lp.AddText("birthday", bd.FirstName + " " + bd.LastName, "Cambria", 11, "bold", 0, spacer);
                        if(ti.stringWidth>110)
                        {
                            ti.text = bd.FirstName;
                            spacer += 15;
                            lp.AddText("birthday", bd.LastName, "Cambria", 11, "bold", 0, spacer);
                        }
                        spacer += 15;
                        int age = cm.year - bd.Birthdate.Year;
                        if (bd.IsDeceased == true)
                        {
                           lp.AddText("birthday", "(" + bd.Birthdate.Year.ToString() + "-" + bd.Deathdate.Year.ToString() + ")", "Cambria", 10, "italic", 0, spacer);
                           
                        }
                        else
                        {
                            lp.AddText("birthday", age + bd.GetSuffixForAge(age) + " (b. " + bd.Birthdate.Year.ToString() + ")", "Cambria", 11, "italic", 0, spacer);
                        }
                        spacer += 15;
                        if(bd.Notes.Trim() !="")
                        {
                            TextItem ti2 = lp.AddText("birthday", bd.Notes, "Times New Roman", 11, "regular", 0, spacer);
                           
                            int pixelWidth = ti2.stringWidth;
                            if (pixelWidth > 110)
                            {
                                ti2.text = "";
                                string temp = bd.Notes;
                                string splitString = SplitStringToMultiline(temp,Convert.ToInt32(Math.Ceiling((decimal)pixelWidth/114)));
                                string[] splits = splitString.Split('\n');
                               
                                for(int i=0;i<splits.Length;i++)
                                {
                                    lp.AddText("birthday", splits[i], "Cambria", 11, "regular", 0, spacer);
                                    spacer += 15;
                                }
                            }
                            else
                            {
                                spacer += 15;
                            }
                           
                        }

                    }
                    
                    index++;
                }
            }
            SheetDefinition sh = lp.DefineCustomSheet(50);
           // sh.SetIndexPosition(0, 0, 0);
            //sh.GridOutPosition(new GridLayout(50, 300, 100, 100, 0, 0, 7, 6), 1, 31, 2);
            sh.ResetSheets(lp,false);
            lp.Print(true);
        }

        private string SplitStringToMultiline(string input,int howManyLines)  //this will return with a \n char
        {
            int stringLength = input.Length;
            //get the indexes of all the spaces
            List<int> indexes = new List<int>();
            int startingPoint = 0;
            while(input.IndexOf(' ',startingPoint)!=-1)
            {
                int temp = input.IndexOf(' ', startingPoint);
                indexes.Add(temp);
                startingPoint = temp+1;
            }
            int optimalSplit = input.Length / howManyLines;
            List<int> lstOptimalSplit = new List<int>(); ;
            for(int i=1;i<howManyLines;i++)
            {
                lstOptimalSplit.Add(i * (input.Length / howManyLines));
            }
            //List<int> finalIndex = new List<int>();
            //foreach (int opt in lstOptimalSplit)
            //{
            //    int lastWinner = input.Length;
            //    int leastDistance = input.Length;
            //    foreach (int ind in indexes)
            //    {
            //        if (Math.Abs(ind - opt) < leastDistance)
            //        {
            //            lastWinner = ind;
            //            leastDistance = Math.Abs(ind - optimalSplit);
            //        }
            //    }
            //    finalIndex.Add(lastWinner);
            //}

            StringBuilder sb = new StringBuilder(input);
           foreach(int index in lstOptimalSplit)
            {
                sb.Insert(index, '\n');
            }
            return sb.ToString();
        }

        private void btnPrintThisYear_Click(object sender, EventArgs e)
        {
            int currentYear = DateTime.Now.Year;
            CalendarYear cy = new CalendarProject.CalendarYear(currentYear);
            cy.PrepopulateCalendar();

            Birthday bd = new Birthday();
            int id = (int)(cboCalendar.SelectedItem as CalendarGroup).ID;
            List<Birthday> lstBd = bd.GetBirthdaysForCalendar(id, "default");
            cy.AddBirthdaysToCalendar(lstBd);
            PrintMonth(cy);
        }

        private void releaseNotesToolStripMenuItem_Click(object sender, EventArgs e)
        {
            string strInstructionsPath = "Release Notes.docx";
            string strInstructionsFullPath = Path.GetFullPath(strInstructionsPath);
            System.Diagnostics.Process.Start(strInstructionsFullPath);
        }

        private void helpToolStripMenuItem_Click(object sender, EventArgs e)
        {
            string strInstructionsPath = "Help.docx";
            string strInstructionsFullPath = Path.GetFullPath(strInstructionsPath);
            System.Diagnostics.Process.Start(strInstructionsFullPath);
        }

        private void importToolStripMenuItem_Click(object sender, EventArgs e)
        {

            string importFileName;
            string contents;
            openFileDialog1.InitialDirectory = Environment.GetFolderPath(Environment.SpecialFolder.Desktop);
            openFileDialog1.Filter = "Calendar Xml(*.cal)| *.cal";
            openFileDialog1.RestoreDirectory = true;

            if (openFileDialog1.ShowDialog() == DialogResult.OK)
            {
                try
                {
                    importFileName = openFileDialog1.FileName;
                    //read file
                    contents = File.ReadAllText(importFileName);
                    XMLProcessor xProc = new XMLProcessor(contents);
                    List<CalendarGroup>lstCal=xProc.GetCalendarsFromFile();
                    foreach(CalendarGroup cal in lstCal)
                    {
                        int id = cal.AddCalendar();
                        cal.ID = id;
                    }
                    List<Birthday> lstBD = xProc.LoadBirthdaysForCalendars(lstCal);
                    foreach(Birthday bd in lstBD)
                    {
                        bd.AddBirthday();
                    }
                    RefreshCalendars();
                   // RefreshBirthdays();
                }
                catch(Exception ex)
                {
                    MessageBox.Show(ex.Message, ex.ToString());
                }
            }

          


        }

        private void exportToDesktopToolStripMenuItem_Click(object sender, EventArgs e)
        {
            frmExport addCal = new frmExport();
            addCal.ShowDialog();

        }

        private void mergeToolStripMenuItem_Click(object sender, EventArgs e)
        {
            frmMerge merge = new frmMerge();
            merge.ShowDialog();
            RefreshCalendars();
        }

        private void backupCurrentStateToolStripMenuItem_Click(object sender, EventArgs e)
        {
            FileProcessor fp = new CalendarProject.FileProcessor();
            fp.MakeBackupFile();
            MessageBox.Show("Backup is Created.  Look in Recover Backups for a full list of backup records.", "Backup Complete");
        }

        private void recoverPreviousStateToolStripMenuItem_Click(object sender, EventArgs e)
        {
            frmRecoverBackup recover = new frmRecoverBackup();
            recover.ShowDialog();
            RefreshCalendars();

        }

        private void btnEditList_Click(object sender, EventArgs e)
        {
            frmAddCalendar addCal = new frmAddCalendar();
            addCal.CalendarNameID = ((CalendarGroup)cboCalendar.SelectedItem).ID;
            addCal.ShowDialog();

            RefreshCalendars();
        }

        private void cleanDatabaseToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Birthday bd = new CalendarProject.Birthday();
            CalendarGroup cal = new CalendarProject.CalendarGroup();
            bd.CleanAllBirthdays();
            cal.CleanCalendars();
        }
    }
}
