using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CalendarProject
{
    class CalendarGroup
    {
        public string Text { get; set; }
       
        public int? ID = null;
        public List<Birthday> lstBD = new List<Birthday>();

        public override string ToString()
        {
            return Text;

        }
        public List<CalendarGroup> GetAllCalendarGroups()
        {
            DAL da = new CalendarProject.DAL();
            List<CalendarGroup> lstCG = da.GetAllCalendars();
            return lstCG;
        }
        public int UpdateCalendar()
        {
            DAL bd = new CalendarProject.DAL();
            if (this.ID != null)
            {
                return bd.UpdateCalendar((int)this.ID, this.Text);
            }
            else
            {
                return 0;
            }
        }
        public bool DeleteCalendar()
        {
            DAL bd = new CalendarProject.DAL();

            if (this.ID != null)
            {
                return (bd.DeleteCalendar((int)this.ID) && bd.DeleteBirthdaysForCalendar((int)this.ID));
              
            }
            else
            {
                return false;
            }
        }
        public bool DeleteCalendar(int id)
        {
            DAL bd = new CalendarProject.DAL();
            if (this.ID != null)
            {
                return (bd.DeleteCalendar(id) && bd.DeleteBirthdaysForCalendar(id));
            }
            else
            {
                return false;
            }
        }
        public bool CleanCalendars()
        {
            DAL bd = new CalendarProject.DAL();
        
            return bd.CleanCalendars();
        
        }
        public int AddCalendar()
        {
            DAL bd = new CalendarProject.DAL();
            return bd.AddCalendar(this.Text);
        }
        public void Load(int id)
        {
            ID = id;
            DAL bd = new CalendarProject.DAL();
            CalendarGroup temp = bd.GetCalendarGroupByID((int)this.ID);
            this.Text = temp.Text;
          
        }

        public int RemoveDuplicates()
        {
            DAL bd = new CalendarProject.DAL();
            if (this.ID != null)
            {
                return bd.RemoveDuplicatesFromCalendar((int)this.ID);
            }
            else
            {
                return 0;
            }
        }
        public int MergeOtherCalendarIntoThis(int otherCalendarId)
        {
            DAL bd = new CalendarProject.DAL();
            if (this.ID != null)
            {
                return bd.MergeFirstCalIntoSecond(otherCalendarId, ((int)this.ID));
            }
            else
            {
                return 0;
            }
        }
    }
  
}
