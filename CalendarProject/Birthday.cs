using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CalendarProject
{
    public class Birthday
    {
        public string FirstName="";
        public string LastName="";
        public DateTime Birthdate;
        public Boolean IsDeceased=false;
        public DateTime Deathdate;
        public int CalendarNameID;
        public int ID;
        public string Notes;
        DAL da = new DAL();

        //public string Text { get; set; }
        //public int Value { get; set; }

        //public override string ToString()
        //{
        //    return Text;

        //}
        public bool AddBirthday()
        {
            if (da.AddBirthday(CalendarNameID,FirstName,LastName,Birthdate,IsDeceased,Deathdate,Notes)>0)
            {
                return true;
            }
            else
            {
                return false;
            }
        }
        public bool UpdateBirthday(int id)
        {
            if (da.UpdateBirthday(id,CalendarNameID, FirstName, LastName, Birthdate, IsDeceased, Deathdate, Notes) > 0)
            {
                return true;
            }
            else
            {
                return false;
            }
        }
        public void LoadBirthday(int id)
        {
            Birthday temp = da.GetBirthdayByID(id);
            FirstName = temp.FirstName;
            LastName = temp.LastName;
            Notes = temp.Notes;
            Birthdate = temp.Birthdate;
            IsDeceased = temp.IsDeceased;
            Deathdate = temp.Deathdate;
            CalendarNameID = temp.CalendarNameID;
            ID = temp.ID;
        }
        public bool DeleteBirthday()
        {
            return da.DeleteBirthday(ID);
        }
        public bool CleanAllBirthdays()
        {
           return  da.CleanBirthdays();
        }


    

        public List<Birthday> GetBirthdaysForCalendar(int calID,string sortType="default asc")
        {
            return da.GetBirthdaysForCalendarID(calID,sortType);
          
        }

        public string GetSuffixForAge(int age)
        {
            int endingNumber = age % 10;
            if (age < 21 && age > 10) { return "th"; }
            switch (endingNumber)
            {
                case 1:
                    return "st";
                case 2:
                    return "nd";
                case 3:
                    return "rd";
                default:
                    return "th";
                              

            }
        }
    }
    
}
