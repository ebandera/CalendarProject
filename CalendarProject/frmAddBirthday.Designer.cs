namespace CalendarProject
{
    partial class frmAddBirthday
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.txtFName = new System.Windows.Forms.TextBox();
            this.txtLName = new System.Windows.Forms.TextBox();
            this.txtNotes = new System.Windows.Forms.TextBox();
            this.calBirth = new System.Windows.Forms.MonthCalendar();
            this.chkDeceased = new System.Windows.Forms.CheckBox();
            this.calDeath = new System.Windows.Forms.MonthCalendar();
            this.btnAdd = new System.Windows.Forms.Button();
            this.btnCancel = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(14, 21);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(57, 13);
            this.label1.TabIndex = 0;
            this.label1.Text = "First Name";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(14, 49);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(58, 13);
            this.label2.TabIndex = 1;
            this.label2.Text = "Last Name";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(14, 77);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(35, 13);
            this.label3.TabIndex = 2;
            this.label3.Text = "Notes";
            // 
            // txtFName
            // 
            this.txtFName.Location = new System.Drawing.Point(83, 18);
            this.txtFName.Name = "txtFName";
            this.txtFName.Size = new System.Drawing.Size(163, 20);
            this.txtFName.TabIndex = 3;
            // 
            // txtLName
            // 
            this.txtLName.Location = new System.Drawing.Point(83, 46);
            this.txtLName.Name = "txtLName";
            this.txtLName.Size = new System.Drawing.Size(163, 20);
            this.txtLName.TabIndex = 4;
            // 
            // txtNotes
            // 
            this.txtNotes.Location = new System.Drawing.Point(83, 74);
            this.txtNotes.Name = "txtNotes";
            this.txtNotes.Size = new System.Drawing.Size(253, 20);
            this.txtNotes.TabIndex = 5;
            // 
            // calBirth
            // 
            this.calBirth.Location = new System.Drawing.Point(19, 103);
            this.calBirth.MaxSelectionCount = 1;
            this.calBirth.Name = "calBirth";
            this.calBirth.ShowToday = false;
            this.calBirth.ShowTodayCircle = false;
            this.calBirth.TabIndex = 6;
            // 
            // chkDeceased
            // 
            this.chkDeceased.AutoSize = true;
            this.chkDeceased.Location = new System.Drawing.Point(344, 80);
            this.chkDeceased.Name = "chkDeceased";
            this.chkDeceased.Size = new System.Drawing.Size(86, 17);
            this.chkDeceased.TabIndex = 7;
            this.chkDeceased.Text = "Is Deceased";
            this.chkDeceased.UseVisualStyleBackColor = true;
            this.chkDeceased.CheckedChanged += new System.EventHandler(this.chkDeceased_CheckedChanged);
            // 
            // calDeath
            // 
            this.calDeath.Location = new System.Drawing.Point(231, 103);
            this.calDeath.MaxSelectionCount = 1;
            this.calDeath.Name = "calDeath";
            this.calDeath.ShowToday = false;
            this.calDeath.ShowTodayCircle = false;
            this.calDeath.TabIndex = 8;
            this.calDeath.Visible = false;
            // 
            // btnAdd
            // 
            this.btnAdd.BackColor = System.Drawing.Color.Navy;
            this.btnAdd.ForeColor = System.Drawing.Color.White;
            this.btnAdd.Location = new System.Drawing.Point(261, 18);
            this.btnAdd.Name = "btnAdd";
            this.btnAdd.Size = new System.Drawing.Size(75, 23);
            this.btnAdd.TabIndex = 9;
            this.btnAdd.Text = "Add Record";
            this.btnAdd.UseVisualStyleBackColor = false;
            this.btnAdd.Click += new System.EventHandler(this.btnAdd_Click);
            // 
            // btnCancel
            // 
            this.btnCancel.BackColor = System.Drawing.Color.Navy;
            this.btnCancel.ForeColor = System.Drawing.Color.White;
            this.btnCancel.Location = new System.Drawing.Point(355, 18);
            this.btnCancel.Name = "btnCancel";
            this.btnCancel.Size = new System.Drawing.Size(75, 23);
            this.btnCancel.TabIndex = 10;
            this.btnCancel.Text = "Cancel";
            this.btnCancel.UseVisualStyleBackColor = false;
            this.btnCancel.Click += new System.EventHandler(this.btnCancel_Click);
            // 
            // frmAddBirthday
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.Gainsboro;
            this.ClientSize = new System.Drawing.Size(447, 273);
            this.Controls.Add(this.btnCancel);
            this.Controls.Add(this.btnAdd);
            this.Controls.Add(this.calDeath);
            this.Controls.Add(this.chkDeceased);
            this.Controls.Add(this.calBirth);
            this.Controls.Add(this.txtNotes);
            this.Controls.Add(this.txtLName);
            this.Controls.Add(this.txtFName);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.Name = "frmAddBirthday";
            this.Text = "Add / Edit Birthday";
            this.Load += new System.EventHandler(this.AddBirthday_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.TextBox txtFName;
        private System.Windows.Forms.TextBox txtLName;
        private System.Windows.Forms.TextBox txtNotes;
        private System.Windows.Forms.MonthCalendar calBirth;
        private System.Windows.Forms.CheckBox chkDeceased;
        private System.Windows.Forms.MonthCalendar calDeath;
        private System.Windows.Forms.Button btnAdd;
        private System.Windows.Forms.Button btnCancel;
    }
}