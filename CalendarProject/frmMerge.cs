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
    public partial class frmMerge : Form
    {
        public frmMerge()
        {
            InitializeComponent();
        }

        private void frmMerge_Load(object sender, EventArgs e)
        {
            RefreshCalendars();
        }

        private void btnCancel_Click(object sender, EventArgs e)
        {
            this.Close();
        }
        private void RefreshCalendars()
        {
            CalendarGroup CG = new CalendarProject.CalendarGroup();
            List<CalendarGroup> lstCG = CG.GetAllCalendarGroups();
            cboCalFrom.Items.Clear();
            cboCalInto.Items.Clear();
            foreach (CalendarGroup cal in lstCG)
            {
                cboCalFrom.Items.Add(cal);
                cboCalInto.Items.Add(cal);
            }
            cboCalFrom.SelectedIndex = 0;
            cboCalInto.SelectedIndex = 0;

        }

        private void btnMerge_Click(object sender, EventArgs e)
        {
            if((int)((CalendarGroup)cboCalFrom.SelectedItem).ID!= (int)((CalendarGroup)cboCalInto.SelectedItem).ID)
            {
                DialogResult dr = MessageBox.Show("Are You sure you want to merge " + ((CalendarGroup)cboCalFrom.SelectedItem).Text + " into " + ((CalendarGroup)cboCalInto.SelectedItem).Text + "? ", "Merge Calendars", MessageBoxButtons.YesNo);
                if (dr == DialogResult.Yes)
                {

                    CalendarGroup CG = new CalendarProject.CalendarGroup();

                    CG.Load((int)((CalendarGroup)cboCalInto.SelectedItem).ID); //
                    CG.MergeOtherCalendarIntoThis((int)((CalendarGroup)cboCalFrom.SelectedItem).ID);
                    CG.RemoveDuplicates();
                    CG.DeleteCalendar((int)((CalendarGroup)cboCalFrom.SelectedItem).ID);
                    this.Close();
                }
            }
            else
            {
                MessageBox.Show("Cannot merge into the same calendar");
            }
          

           


        }
    }
}
