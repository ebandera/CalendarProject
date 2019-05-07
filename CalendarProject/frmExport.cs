using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.IO;

namespace CalendarProject
{
    public partial class frmExport : Form
    {
        public frmExport()
        {
            InitializeComponent();
        }

        private void Export_Load(object sender, EventArgs e)
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

        private void btnAddToExport_Click(object sender, EventArgs e)
        {
          
            if (listBox1.Items.IndexOf(cboCalendar.SelectedItem) == -1)
            {
                listBox1.Items.Add(cboCalendar.SelectedItem);
            }
        }

        private void btnRemove_Click(object sender, EventArgs e)
        {
            listBox1.Items.Remove(listBox1.SelectedItem);
        }

        private void btnCancel_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void btnCreateFile_Click(object sender, EventArgs e)
        {

            List<CalendarGroup > lstCal = new List<CalendarGroup>();
            foreach(Object o in listBox1.Items)
            {
                lstCal.Add((CalendarGroup)o);
            }
            foreach(CalendarGroup cal in lstCal)
            {
                Birthday bd = new CalendarProject.Birthday();
                List<Birthday>lstBd = bd.GetBirthdaysForCalendar((int)cal.ID);
                cal.lstBD = lstBd;
            }
            XMLProcessor xProc = new XMLProcessor();
            string contents = xProc.GetExportFileContents(lstCal);
           
            if(lstCal.Count>0)
            {
                saveFileDialog1.FileName = lstCal[0].Text + DateTime.Now.Year + DateTime.Now.Month + DateTime.Now.Day + DateTime.Now.Hour + DateTime.Now.Minute + ".cal";
                saveFileDialog1.Filter = "Calendar File (*.cal)|*.cal";
                if(saveFileDialog1.ShowDialog() ==DialogResult.OK)
                {
                    using (StreamWriter sw = new StreamWriter(saveFileDialog1.FileName))
                    {
                        sw.Write(contents);
                    }

                        
                }
            }
            this.Close();
           
            
        }
    }
}
