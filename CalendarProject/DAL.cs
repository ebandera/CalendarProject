using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.OleDb;

namespace CalendarProject
{
    class DAL
    {
        OleDbConnection conn;
        public void GetConnection()
        {
           // string currentDirectory = Environment.CurrentDirectory;
            string currentDirectory = Environment.GetFolderPath(Environment.SpecialFolder.ApplicationData);
            OleDbConnection con = new OleDbConnection("Provider=Microsoft.ACE.OLEDB.12.0;Data Source=" + currentDirectory + "\\Calendar\\BirthdayData.accdb;Persist Security Info=False;");
            conn = con;
        }
        public Birthday GetFirstBirthday()
        {
            GetConnection();
            conn.Open();
            OleDbCommand cmd = new OleDbCommand("Select * from BirthdayEvent", conn);
           // int result = cmd.ExecuteNonQuery();
            using (OleDbDataReader reader = cmd.ExecuteReader())
            {
                while (reader.Read())
                {
                    string strFirstName = reader["FirstName"].ToString();
                  
                }
            }
            return new Birthday(); 
            

        }
        public List<Birthday> GetBirthdaysForCalendarID(int id,string sort)
        {
            string strSortSql = "Month(DateOfBirth),Day(DateOfBirth)";
            switch (sort)
            {
                case "default asc":
                    strSortSql = "Month(DateOfBirth),Day(DateOfBirth)";
                    break;
                case "default desc":
                    strSortSql = "Month(DateOfBirth) Desc,Day(DateOfBirth) Desc";
                    break;
                case "fName asc":
                    strSortSql = "FirstName";
                    break;
                case "fName desc":
                    strSortSql = "FirstName Desc";
                    break;
                case "lName asc":
                    strSortSql = "LastName";
                    break;
                case "lName desc":
                    strSortSql = "LastName Desc";
                    break;
                default:
                    break;
            }
            try
            {
                GetConnection();
                conn.Open();
                OleDbCommand cmd = new OleDbCommand("Select * from BirthdayEvent Where CalendarNameID = @CalendarNameID And IsDeleted = @IsDeleted Order by " + strSortSql, conn);
                cmd.Parameters.AddWithValue("CalendarNameID", id);
                cmd.Parameters.AddWithValue("IsDeleted", false);
               // int result = cmd.ExecuteNonQuery();
                List<Birthday> lstBD = new List<Birthday>();
                using (OleDbDataReader reader = cmd.ExecuteReader())
                {
                    while (reader.Read())
                    {
                        Birthday bday = new Birthday();
                        if (reader["ID"] != DBNull.Value)
                        {
                            bday.ID = Convert.ToInt32(reader["ID"]);
                        }
                        if (reader["FirstName"] != DBNull.Value)
                        {
                            bday.FirstName = reader["FirstName"].ToString();
                        }
                        if (reader["LastName"] != DBNull.Value)
                        {
                            bday.LastName = reader["LastName"].ToString();
                        }
                        if (reader["Notes"] != DBNull.Value)
                        {
                            bday.Notes = reader["Notes"].ToString();
                        }
                        if (reader["IsDeceased"] != DBNull.Value)
                        {
                            bday.IsDeceased = Convert.ToBoolean(reader["IsDeceased"]);
                        }
                        if (reader["DateOfBirth"] != DBNull.Value)
                        {
                            bday.Birthdate = Convert.ToDateTime(reader["DateOfBirth"]);
                        }
                        if (reader["DateOfDeath"] != DBNull.Value)
                        {
                            bday.Deathdate = Convert.ToDateTime(reader["DateOfDeath"]);
                        }
                       
                        lstBD.Add(bday);
                    }
                }
              
                return lstBD;
            }
            catch
            {
                throw;
            }
            finally
            {
                conn.Close();
            }
           
        }

        public Birthday GetBirthdayByID(int id)
        {
            try
            {
                GetConnection();
                conn.Open();
                OleDbCommand cmd = new OleDbCommand("Select * from BirthdayEvent Where ID = @ID And IsDeleted = @IsDeleted", conn);
                cmd.Parameters.AddWithValue("ID", id);
                cmd.Parameters.AddWithValue("IsDeleted", false);
                // int result = cmd.ExecuteNonQuery();
                List<Birthday> lstBD = new List<Birthday>();
                using (OleDbDataReader reader = cmd.ExecuteReader())
                {
                    while (reader.Read())
                    {
                        Birthday bday = new Birthday();
                        if (reader["ID"] != DBNull.Value)
                        {
                            bday.ID = Convert.ToInt32(reader["ID"]);
                        }
                        if (reader["FirstName"] != DBNull.Value)
                        {
                            bday.FirstName = reader["FirstName"].ToString();
                        }
                        if (reader["LastName"] != DBNull.Value)
                        {
                            bday.LastName = reader["LastName"].ToString();
                        }
                        if (reader["Notes"] != DBNull.Value)
                        {
                            bday.Notes = reader["Notes"].ToString();
                        }
                        if (reader["IsDeceased"] != DBNull.Value)
                        {
                            bday.IsDeceased = Convert.ToBoolean(reader["IsDeceased"]);
                        }
                        if (reader["DateOfBirth"] != DBNull.Value)
                        {
                            bday.Birthdate = Convert.ToDateTime(reader["DateOfBirth"]);
                        }
                        if (reader["DateOfDeath"] != DBNull.Value)
                        {
                            bday.Deathdate = Convert.ToDateTime(reader["DateOfDeath"]);
                        }
                       
                        lstBD.Add(bday);
                    }
                }
                if (lstBD.Count == 1)
                {
                    return lstBD[0];
                }
                else
                {
                    Exception ex = new Exception("Wrong number of Birthday Results.  Should be 1.");
                    throw ex;
                }
            }
            catch
            {
                throw;
            }
            finally
            {
                conn.Close();
            }
        }

        public CalendarGroup GetCalendarGroupByID(int id)
        {
            try
            {
                GetConnection();
                conn.Open();
                OleDbCommand cmd = new OleDbCommand("Select * from CalendarName Where IsDeleted=@IsDeleted and ID=@ID", conn);
                cmd.Parameters.AddWithValue("IsDeleted", false);
                cmd.Parameters.AddWithValue("ID", false);
                //  int result = cmd.ExecuteNonQuery();
                // List<CalendarGroup> lstCal = new List<CalendarGroup>();

                CalendarGroup cg = new CalendarGroup();
                using (OleDbDataReader reader = cmd.ExecuteReader())
                {

                    while (reader.Read())
                    {
                        if (reader["CalendarName"] != DBNull.Value)
                        {
                            cg.Text = reader["CalendarName"].ToString();
                            cg.ID = Convert.ToInt32(reader["ID"]);
                        }
                       // lstCal.Add(cg);
                    }
                }

                return cg;
            }
            catch
            {
                throw;
            }
            finally
            {
                conn.Close();
            }
        }
        public List<CalendarGroup> GetAllCalendars()
        {
            try
            {
                GetConnection();
                conn.Open();
                OleDbCommand cmd = new OleDbCommand("Select * from CalendarName Where IsDeleted=@IsDeleted", conn);
                cmd.Parameters.AddWithValue("IsDeleted", false);
              //  int result = cmd.ExecuteNonQuery();
                List<CalendarGroup> lstCal = new List<CalendarGroup>();
                using (OleDbDataReader reader = cmd.ExecuteReader())
                {
                    
                    while (reader.Read())
                    {
                        CalendarGroup cg = new CalendarGroup();
                        if (reader["CalendarName"] != DBNull.Value)
                        {
                            cg.Text = reader["CalendarName"].ToString();
                            cg.ID = Convert.ToInt32(reader["ID"]);
                        }
                        lstCal.Add(cg);
                    }
                }

                return lstCal;
            }
            catch
            {
                throw;
            }
            finally
            {
                conn.Close();
            }
        }

        public bool DeleteBirthday(int id)
        {
            try
            {
                GetConnection();
                conn.Open();
                OleDbCommand cmd = new OleDbCommand("Update BirthdayEvent SET IsDeleted = @IsDeleted Where ID = @ID", conn);
                cmd.Parameters.AddWithValue("IsDeleted", true);
                cmd.Parameters.AddWithValue("ID", id);
                int result = cmd.ExecuteNonQuery();
              
                return true;
            }
            catch
            {
                return false;
            }
            finally
            {
                conn.Close();
            }
        }
        public bool DeleteBirthdaysForCalendar(int id)
        {
            try
            {
                GetConnection();
                conn.Open();
                OleDbCommand cmd = new OleDbCommand("Update BirthdayEvent SET IsDeleted = @IsDeleted Where CalendarNameId = @ID", conn);
                cmd.Parameters.AddWithValue("IsDeleted", true);
                cmd.Parameters.AddWithValue("ID", id);
                int result = cmd.ExecuteNonQuery();

                return true;
            }
            catch
            {
                return false;
            }
            finally
            {
                conn.Close();
            }
        }
        public bool DeleteCalendar(int id)
        {
            try
            {
                GetConnection();
                conn.Open();
                OleDbCommand cmd = new OleDbCommand("Update CalendarName SET IsDeleted = @IsDeleted Where ID = @ID", conn);
                cmd.Parameters.AddWithValue("IsDeleted", true);
                cmd.Parameters.AddWithValue("ID", id);
                int result = cmd.ExecuteNonQuery();
                List<string> lstCal = new List<string>();


                return true;
            }
            catch
            {
                return false;
            }
            finally
            {
                conn.Close();
            }
        }
        public bool CleanCalendars()
        {
            try
            {
                GetConnection();
                conn.Open();
                OleDbCommand cmd = new OleDbCommand("Delete From CalendarName where IsDeleted = @IsDeleted", conn);
                cmd.Parameters.AddWithValue("IsDeleted", true);
                int result = cmd.ExecuteNonQuery();
                List<string> lstCal = new List<string>();


                return true;
            }
            catch
            {
                return false;
            }
            finally
            {
                conn.Close();
            }
        }
        public bool CleanBirthdays()
        {
            try
            {
                GetConnection();
                conn.Open();
                OleDbCommand cmd = new OleDbCommand("Delete From BirthdayEvent Where IsDeleted = @IsDeleted", conn);
                cmd.Parameters.AddWithValue("IsDeleted", true);
              
                int result = cmd.ExecuteNonQuery();

                return true;
            }
            catch
            {
                return false;
            }
            finally
            {
                conn.Close();
            }
        }

        public int AddBirthday(int calID,string fName,string lName,DateTime dtBirth,bool blnDeceased,DateTime dtDeath,string strNote)
        {
            try
            {
                GetConnection();
                conn.Open();
                OleDbCommand cmd = new OleDbCommand("Insert Into BirthdayEvent(CalendarNameId,FirstName,LastName,DateOfBirth,IsDeceased,DateOfDeath,Notes,IsDeleted) Values(@CalendarNameID,@FirstName,@LastName,@DtOfBirth,@IsDeceased,@DtOfDeath,@Notes,@IsDeleted)", conn);
                cmd.Parameters.AddWithValue("CalendarNameID", calID);
                cmd.Parameters.AddWithValue("FirstName", fName);
                cmd.Parameters.AddWithValue("LastName", lName);
                cmd.Parameters.AddWithValue("DtOfBirth", dtBirth);
                cmd.Parameters.AddWithValue("IsDeceased", blnDeceased);
                cmd.Parameters.AddWithValue("DtOfDeath", dtDeath);
                cmd.Parameters.AddWithValue("Notes", strNote);
                cmd.Parameters.AddWithValue("IsDeleted", false);
               
                int result = cmd.ExecuteNonQuery();
                cmd.CommandText = "Select @@Identity";
                int newID = (int)cmd.ExecuteScalar();
                if (result==1)
                {
                    return newID;
                }
                else
                {
                    return 0;
                }
               
            }
            catch
            {
                return 0;
            }
            finally
            {
                conn.Close();
            }
        }
        public int AddCalendar(string calName)
        {
            try
            {
                GetConnection();
                conn.Open();
                OleDbCommand cmd = new OleDbCommand("Insert Into CalendarName(CalendarName,IsDeleted) Values(@CalendarName,@IsDeleted)", conn);
                cmd.Parameters.AddWithValue("CalendarName", calName);
                cmd.Parameters.AddWithValue("IsDeleted", false);

                int result = cmd.ExecuteNonQuery();
                cmd.CommandText = "Select @@Identity";
                int newID = (int)cmd.ExecuteScalar();
                if (result == 1)
                {
                    return newID;
                }
                else
                {
                    return 0;
                }

            }
            catch
            {
                return 0;
            }
            finally
            {
                conn.Close();
            }
        }

        public int UpdateBirthday(int id,int calID, string fName, string lName, DateTime dtBirth, bool blnDeceased, DateTime dtDeath, string strNote)
        {
            try
            {
                GetConnection();
                conn.Open();
                string sql = "Update BirthdayEvent Set CalendarNameId=@CalendarNameID," +
                    "FirstName = @FirstName," +
                    "LastName = @LastName," +
                    "DateOfBirth = @DtOfBirth," +
                    "IsDeceased = @IsDeceased," +
                    "DateOfDeath = @DtOfDeath," +
                    "Notes = @Notes," +
                    "IsDeleted = @IsDeleted " +
                    "Where ID = @ID";
                OleDbCommand cmd = new OleDbCommand(sql,conn);
              
                cmd.Parameters.AddWithValue("CalendarNameID", calID);
                cmd.Parameters.AddWithValue("FirstName", fName);
                cmd.Parameters.AddWithValue("LastName", lName);
                cmd.Parameters.AddWithValue("DtOfBirth", dtBirth);
                cmd.Parameters.AddWithValue("IsDeceased", blnDeceased);
                cmd.Parameters.AddWithValue("DtOfDeath", dtDeath);
                cmd.Parameters.AddWithValue("Notes", strNote);
                cmd.Parameters.AddWithValue("IsDeleted", false);
                cmd.Parameters.AddWithValue("ID", id);
                int result = cmd.ExecuteNonQuery();
                return result;
            }
            catch
            {
                return 0;
            }
            finally
            {
                conn.Close();
            }
        }

        public int UpdateCalendar(int id, string calName)
        {
            try
            {
                GetConnection();
                conn.Open();
                string sql = "Update CalendarName Set CalendarName=@CalendarName " +
                   "Where ID = @ID";
                OleDbCommand cmd = new OleDbCommand(sql, conn);
               
                cmd.Parameters.AddWithValue("CalendarName", calName);
                cmd.Parameters.AddWithValue("ID", id);
                int result = cmd.ExecuteNonQuery();
                return result;
            }
            catch
            {
                return 0;
            }
            finally
            {
                conn.Close();
            }
        }

        public int MergeFirstCalIntoSecond(int idFrom, int idTo)
        {
            try
            {
                GetConnection();
                conn.Open();
                string sql = "Update BirthdayEvent Set CalendarNameId=@CalendarNameIdTo Where CalendarNameID = @CalendarNameIdFrom";
                OleDbCommand cmd = new OleDbCommand(sql, conn);

                cmd.Parameters.AddWithValue("CalendarNameIdTo", idTo);
                cmd.Parameters.AddWithValue("CalendarNameIdFrom", idFrom);

                int result = cmd.ExecuteNonQuery();
                return result;
            }
            catch
            {
                return 0;
            }
            finally
            {
                conn.Close();
            }

        }

        public int RemoveDuplicatesFromCalendar(int calID)
        {
            try
            {
                GetConnection();
                conn.Open();
                string sql = "Update BirthdayEvent b1 Set IsDeleted=@IsDeleted " +
                      "Where CalendarNameID = @ID and ID > (SELECT MIN(ID) from BirthdayEvent b2 where b2.FirstName=b1.FirstName and b2.LastName=b1.LastName)";
              
                OleDbCommand cmd = new OleDbCommand(sql, conn);

                cmd.Parameters.AddWithValue("IsDeleted", true);
                cmd.Parameters.AddWithValue("CalendarNameID", calID);
               
               
              
                int result = cmd.ExecuteNonQuery();
                return result;
            }
            catch
            {
                return 0;
            }
            finally
            {
                conn.Close();
            }
        }




    }
}
