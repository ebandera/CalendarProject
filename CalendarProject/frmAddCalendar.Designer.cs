namespace CalendarProject
{
    partial class frmAddCalendar
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
            this.btnAddnew = new System.Windows.Forms.Button();
            this.btnCancel = new System.Windows.Forms.Button();
            this.txtCalendarName = new System.Windows.Forms.TextBox();
            this.SuspendLayout();
            // 
            // btnAddnew
            // 
            this.btnAddnew.BackColor = System.Drawing.Color.Navy;
            this.btnAddnew.ForeColor = System.Drawing.Color.White;
            this.btnAddnew.Location = new System.Drawing.Point(12, 45);
            this.btnAddnew.Name = "btnAddnew";
            this.btnAddnew.Size = new System.Drawing.Size(111, 23);
            this.btnAddnew.TabIndex = 0;
            this.btnAddnew.Text = "Add Calendar";
            this.btnAddnew.UseVisualStyleBackColor = false;
            this.btnAddnew.Click += new System.EventHandler(this.btnAddnew_Click);
            // 
            // btnCancel
            // 
            this.btnCancel.BackColor = System.Drawing.Color.Navy;
            this.btnCancel.ForeColor = System.Drawing.Color.White;
            this.btnCancel.Location = new System.Drawing.Point(164, 45);
            this.btnCancel.Name = "btnCancel";
            this.btnCancel.Size = new System.Drawing.Size(116, 23);
            this.btnCancel.TabIndex = 1;
            this.btnCancel.Text = "Cancel";
            this.btnCancel.UseVisualStyleBackColor = false;
            this.btnCancel.Click += new System.EventHandler(this.btnCancel_Click);
            // 
            // txtCalendarName
            // 
            this.txtCalendarName.Location = new System.Drawing.Point(12, 12);
            this.txtCalendarName.Name = "txtCalendarName";
            this.txtCalendarName.Size = new System.Drawing.Size(267, 20);
            this.txtCalendarName.TabIndex = 2;
            // 
            // frmAddCalendar
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.Gainsboro;
            this.ClientSize = new System.Drawing.Size(292, 84);
            this.Controls.Add(this.txtCalendarName);
            this.Controls.Add(this.btnCancel);
            this.Controls.Add(this.btnAddnew);
            this.Name = "frmAddCalendar";
            this.Text = "AddCalendar";
            this.Load += new System.EventHandler(this.frmAddCalendar_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button btnAddnew;
        private System.Windows.Forms.Button btnCancel;
        private System.Windows.Forms.TextBox txtCalendarName;
    }
}