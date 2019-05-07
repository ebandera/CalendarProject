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
    public partial class frmAddBirthday : Form
    {
        public frmAddBirthday()
        {
            InitializeComponent();
        }

        public int CalendarID;
        public int? BirthdayID;
        public Birthday bd = new Birthday();
        private void btnCancel_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void btnAdd_Click(object sender, EventArgs e)
        {
           
            bd.CalendarNameID = CalendarID;
            bd.FirstName = txtFName.Text.Trim();
            bd.LastName = txtLName.Text.Trim();
            bd.Notes = txtNotes.Text.Trim();
            bd.Birthdate = calBirth.SelectionRange.Start;
            bd.IsDeceased = chkDeceased.Checked;
            bd.Deathdate = calDeath.SelectionRange.Start;
            //determine Whether add or edit
            bool success;
            if(BirthdayID!=null)
            {
                success = bd.UpdateBirthday((int)BirthdayID);
            }
            else
            {
                success = bd.AddBirthday();
            }
          
            if(success==false)
            {
                MessageBox.Show("There was a problem saving");
            }
            else
            {
                this.Close();
            }

        }

        private void chkDeceased_CheckedChanged(object sender, EventArgs e)
        {
            if (chkDeceased.Checked==true)
            {
                calDeath.Visible = true;
            }
            else
            {
                calDeath.Visible = false;

            }
        }

        private void AddBirthday_Load(object sender, EventArgs e)
        {
            if (BirthdayID !=null)
            {
                btnAdd.Text = "Update";
                txtFName.Text = bd.FirstName;
                txtLName.Text = bd.LastName;
                txtNotes.Text = bd.Notes;
                chkDeceased.Checked =bd.IsDeceased;
                calBirth.SetDate(bd.Birthdate);
                calDeath.SetDate(bd.Deathdate);
            }
          
        }
    }
}
