using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CalendarProject
{
    class CalendarDay
    {
        public int dayNumber;
        public List<Birthday> lstBirthday;
        public CalendarDay(int day)
        {
            dayNumber = day;
            lstBirthday = new List<Birthday>();
        }
    }
}
