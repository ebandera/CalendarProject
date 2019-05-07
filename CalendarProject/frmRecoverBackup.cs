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
    public partial class frmRecoverBackup : Form
    {
        public frmRecoverBackup()
        {
            InitializeComponent();
        }

        private void btnCancel_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void btnRestore_Click(object sender, EventArgs e)
        {
            if(listBox1.SelectedIndex !=-1)
            {
                string fn = listBox1.SelectedItem.ToString();
                FileProcessor fp = new FileProcessor();
                //first make a backup
                fp.MakeBackupFile();
                //then delete the old database
                fp.DeleteFile("BirthdayData.accdb");
                //then copy the recover to that filename
                fp.RecoverBackupFile(fn);
                this.Close();
            }
          else
            {
                MessageBox.Show("Please Select an item to restore");

            }

        }

        private void btnDelete_Click(object sender, EventArgs e)
        {
            if (listBox1.SelectedItems.Count == 0)
            {
             
                return;
            }
            DialogResult dr = MessageBox.Show("Are You sure you want to delete the backup for " + listBox1.SelectedItem.ToString() + "?", "Remove Backup", MessageBoxButtons.YesNo);
            if (dr == DialogResult.Yes)
            {
                FileProcessor fp = new FileProcessor();
                fp.DeleteFile(listBox1.SelectedItem.ToString());
                ReloadListBox();

            }
        }

        private void frmRecoverBackup_Load(object sender, EventArgs e)
        {
            ReloadListBox();
          
        }
        private void ReloadListBox()
        {
            listBox1.Items.Clear();
            FileProcessor fp = new FileProcessor();
            List<string> lstFiles = fp.GetAllBackupFilenames();
            foreach (string file in lstFiles)
            {
                listBox1.Items.Add(file);
            }
        }
    }
}
