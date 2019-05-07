using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CalendarProject
{
    class CalendarYear
    {
        public List<CalendarMonth> lstMonth;
        //Boolean isLeapYear = false;
        int yearNumber;
        public CalendarYear(int year)
        {
            yearNumber = year;
            lstMonth = new List<CalendarMonth>();
        } 
        private void PopulateMonths()
        {
            lstMonth.Add(new CalendarProject.CalendarMonth(1,"January",yearNumber));
            lstMonth.Add(new CalendarProject.CalendarMonth(2,"February",yearNumber));
            lstMonth.Add(new CalendarProject.CalendarMonth(3,"March", yearNumber));
            lstMonth.Add(new CalendarProject.CalendarMonth(4,"April", yearNumber));
            lstMonth.Add(new CalendarProject.CalendarMonth(5,"May", yearNumber));
            lstMonth.Add(new CalendarProject.CalendarMonth(6, "June",yearNumber));
            lstMonth.Add(new CalendarProject.CalendarMonth(7,"July", yearNumber));
            lstMonth.Add(new CalendarProject.CalendarMonth(8,"August", yearNumber));
            lstMonth.Add(new CalendarProject.CalendarMonth(9,"September", yearNumber));
            lstMonth.Add(new CalendarProject.CalendarMonth(10,"October", yearNumber));
            lstMonth.Add(new CalendarProject.CalendarMonth(11,"November", yearNumber));
            lstMonth.Add(new CalendarProject.CalendarMonth(12,"December", yearNumber));
        }
        public void PrepopulateCalendar() 
        {
            PopulateMonths();
            foreach(CalendarMonth mon in lstMonth)
            {
                mon.PopulateDays();
            }
        }
        public void AddBirthdaysToCalendar(List<Birthday>lstBd)
        {
            foreach(Birthday bd in lstBd)
            {
                DateTime dt = bd.Birthdate;
                int month = dt.Month;  //from 1 to 12
                int day = dt.Day; //from 1 to 31
                lstMonth[month - 1].lstDay[day - 1].lstBirthday.Add(bd);
            }
        }
           
    }
}
