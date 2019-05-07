using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace CalendarProject
{
    public partial class frmAddCalendar : Form
    {
        public frmAddCalendar()
        {
            InitializeComponent();
        }
        public int? CalendarNameID;
        private void btnAddnew_Click(object sender, EventArgs e)
        {
            CalendarGroup cal = new CalendarGroup();
          
            if (CalendarNameID == null)
            {
                cal.Text = txtCalendarName.Text.Trim();
                cal.AddCalendar();
            }
            else
            {
                cal.ID = CalendarNameID;
                cal.Text = txtCalendarName.Text.Trim();
                cal.UpdateCalendar();
            }
            this.Close();
        }

        private void btnCancel_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void frmAddCalendar_Load(object sender, EventArgs e)
        {
            if(CalendarNameID!=null)
            {
                btnAddnew.Text = "Update";
            }
        }
    }
}
