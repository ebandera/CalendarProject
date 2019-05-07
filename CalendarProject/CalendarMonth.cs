using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CalendarProject
{
    class CalendarMonth
    {
        public List<CalendarDay> lstDay;
        public string monthName;
        public int monthNumber;
        public int daysInMonth;
        public int year;
        public int firstDayIndex;  //from 0-6 0 being sunday, 6 being Saturday
        public CalendarMonth(int monthNum,string name,int yearNumber)
        {
            lstDay = new List<CalendarDay>();
            year = yearNumber;
            monthName = name;
            monthNumber = monthNum;
            daysInMonth = DateTime.DaysInMonth(year, monthNumber);
            DateTime firstDayOfMonth = new DateTime(year, monthNumber, 1);
            DayOfWeek theDay= firstDayOfMonth.DayOfWeek;
            switch(theDay)
            {
                case (DayOfWeek.Sunday):
                    firstDayIndex = 0;
                    break;
                case (DayOfWeek.Monday):
                    firstDayIndex = 1;
                    break;
                case (DayOfWeek.Tuesday):
                    firstDayIndex = 2;
                    break;
                case (DayOfWeek.Wednesday):
                    firstDayIndex = 3;
                    break;
                case (DayOfWeek.Thursday):
                    firstDayIndex = 4;
                    break;
                case (DayOfWeek.Friday):
                    firstDayIndex = 5;
                    break;
                case (DayOfWeek.Saturday):
                    firstDayIndex = 6;
                    break;
                default:
                    firstDayIndex = 0;
                    break;

            }
        }
        public void PopulateDays()
        {
            for(int i=0;i<daysInMonth;i++)
            {
                lstDay.Add(new CalendarProject.CalendarDay(i + 1));
            }
        }
    }
}
