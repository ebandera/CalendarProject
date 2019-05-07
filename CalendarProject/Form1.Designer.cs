namespace CalendarProject
{
    partial class Form1
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
            this.calBirth = new System.Windows.Forms.MonthCalendar();
            this.calDeath = new System.Windows.Forms.MonthCalendar();
            this.btnAddEditBd = new System.Windows.Forms.Button();
            this.btnRemoveBd = new System.Windows.Forms.Button();
            this.cboCalendar = new System.Windows.Forms.ComboBox();
            this.btnCreateList = new System.Windows.Forms.Button();
            this.btnRemoveList = new System.Windows.Forms.Button();
            this.btnPrintNextYear = new System.Windows.Forms.Button();
            this.listView1 = new System.Windows.Forms.ListView();
            this.columnHeader0 = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.columnHeader1 = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.columnHeader2 = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.columnHeader3 = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.btnPrintThisYear = new System.Windows.Forms.Button();
            this.menuStrip1 = new System.Windows.Forms.MenuStrip();
            this.fileToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.importToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.exportToDesktopToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.mergeToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.backupCurrentStateToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.recoverPreviousStateToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.helpToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.aboutToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.releaseNotesToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.openFileDialog1 = new System.Windows.Forms.OpenFileDialog();
            this.btnEditList = new System.Windows.Forms.Button();
            this.cleanDatabaseToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.menuStrip1.SuspendLayout();
            this.SuspendLayout();
            // 
            // calBirth
            // 
            this.calBirth.Enabled = false;
            this.calBirth.Location = new System.Drawing.Point(321, 252);
            this.calBirth.Name = "calBirth";
            this.calBirth.ShowToday = false;
            this.calBirth.ShowTodayCircle = false;
            this.calBirth.TabIndex = 0;
            // 
            // calDeath
            // 
            this.calDeath.Enabled = false;
            this.calDeath.Location = new System.Drawing.Point(321, 433);
            this.calDeath.Name = "calDeath";
            this.calDeath.ShowToday = false;
            this.calDeath.ShowTodayCircle = false;
            this.calDeath.TabIndex = 3;
            this.calDeath.Visible = false;
            // 
            // btnAddEditBd
            // 
            this.btnAddEditBd.BackColor = System.Drawing.Color.Navy;
            this.btnAddEditBd.ForeColor = System.Drawing.Color.White;
            this.btnAddEditBd.Location = new System.Drawing.Point(321, 31);
            this.btnAddEditBd.Name = "btnAddEditBd";
            this.btnAddEditBd.Size = new System.Drawing.Size(199, 31);
            this.btnAddEditBd.TabIndex = 4;
            this.btnAddEditBd.Text = "Add Birthday";
            this.btnAddEditBd.UseVisualStyleBackColor = false;
            this.btnAddEditBd.Click += new System.EventHandler(this.btnAddEditBd_Click);
            this.btnAddEditBd.MouseLeave += new System.EventHandler(this.btnAddEditBd_MouseLeave);
            this.btnAddEditBd.MouseHover += new System.EventHandler(this.btnAddEditBd_MouseHover);
            // 
            // btnRemoveBd
            // 
            this.btnRemoveBd.BackColor = System.Drawing.Color.Navy;
            this.btnRemoveBd.ForeColor = System.Drawing.Color.White;
            this.btnRemoveBd.Location = new System.Drawing.Point(321, 66);
            this.btnRemoveBd.Name = "btnRemoveBd";
            this.btnRemoveBd.Size = new System.Drawing.Size(199, 31);
            this.btnRemoveBd.TabIndex = 5;
            this.btnRemoveBd.Text = "Delete Birthday";
            this.btnRemoveBd.UseVisualStyleBackColor = false;
            this.btnRemoveBd.Click += new System.EventHandler(this.btnRemoveBd_Click);
            this.btnRemoveBd.MouseLeave += new System.EventHandler(this.btnAddEditBd_MouseLeave);
            this.btnRemoveBd.MouseHover += new System.EventHandler(this.btnAddEditBd_MouseHover);
            // 
            // cboCalendar
            // 
            this.cboCalendar.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.cboCalendar.FormattingEnabled = true;
            this.cboCalendar.Location = new System.Drawing.Point(13, 31);
            this.cboCalendar.Name = "cboCalendar";
            this.cboCalendar.Size = new System.Drawing.Size(297, 28);
            this.cboCalendar.TabIndex = 6;
            this.cboCalendar.SelectedIndexChanged += new System.EventHandler(this.cboCalendar_SelectedIndexChanged);
            // 
            // btnCreateList
            // 
            this.btnCreateList.BackColor = System.Drawing.Color.Navy;
            this.btnCreateList.ForeColor = System.Drawing.Color.White;
            this.btnCreateList.Location = new System.Drawing.Point(321, 101);
            this.btnCreateList.Name = "btnCreateList";
            this.btnCreateList.Size = new System.Drawing.Size(199, 31);
            this.btnCreateList.TabIndex = 7;
            this.btnCreateList.Text = "Create New Calendar";
            this.btnCreateList.UseVisualStyleBackColor = false;
            this.btnCreateList.Click += new System.EventHandler(this.btnCreateList_Click);
            this.btnCreateList.MouseLeave += new System.EventHandler(this.btnAddEditBd_MouseLeave);
            this.btnCreateList.MouseHover += new System.EventHandler(this.btnAddEditBd_MouseHover);
            // 
            // btnRemoveList
            // 
            this.btnRemoveList.BackColor = System.Drawing.Color.Navy;
            this.btnRemoveList.ForeColor = System.Drawing.Color.White;
            this.btnRemoveList.Location = new System.Drawing.Point(321, 171);
            this.btnRemoveList.Name = "btnRemoveList";
            this.btnRemoveList.Size = new System.Drawing.Size(199, 31);
            this.btnRemoveList.TabIndex = 8;
            this.btnRemoveList.Text = "Delete Selected Calendar";
            this.btnRemoveList.UseVisualStyleBackColor = false;
            this.btnRemoveList.Click += new System.EventHandler(this.btnRemoveList_Click);
            this.btnRemoveList.MouseLeave += new System.EventHandler(this.btnAddEditBd_MouseLeave);
            this.btnRemoveList.MouseHover += new System.EventHandler(this.btnAddEditBd_MouseHover);
            // 
            // btnPrintNextYear
            // 
            this.btnPrintNextYear.BackColor = System.Drawing.Color.DarkBlue;
            this.btnPrintNextYear.ForeColor = System.Drawing.Color.White;
            this.btnPrintNextYear.Location = new System.Drawing.Point(421, 206);
            this.btnPrintNextYear.Name = "btnPrintNextYear";
            this.btnPrintNextYear.Size = new System.Drawing.Size(99, 31);
            this.btnPrintNextYear.TabIndex = 9;
            this.btnPrintNextYear.Text = "Print Next Year";
            this.btnPrintNextYear.UseVisualStyleBackColor = false;
            this.btnPrintNextYear.Click += new System.EventHandler(this.btnPrint_Click);
            this.btnPrintNextYear.MouseLeave += new System.EventHandler(this.btnAddEditBd_MouseLeave);
            this.btnPrintNextYear.MouseHover += new System.EventHandler(this.btnAddEditBd_MouseHover);
            // 
            // listView1
            // 
            this.listView1.Columns.AddRange(new System.Windows.Forms.ColumnHeader[] {
            this.columnHeader0,
            this.columnHeader1,
            this.columnHeader2,
            this.columnHeader3});
            this.listView1.FullRowSelect = true;
            this.listView1.GridLines = true;
            this.listView1.Location = new System.Drawing.Point(12, 89);
            this.listView1.Name = "listView1";
            this.listView1.Size = new System.Drawing.Size(298, 507);
            this.listView1.TabIndex = 10;
            this.listView1.UseCompatibleStateImageBehavior = false;
            this.listView1.View = System.Windows.Forms.View.Details;
            this.listView1.ColumnClick += new System.Windows.Forms.ColumnClickEventHandler(this.listView1_ColumnClick);
            this.listView1.SelectedIndexChanged += new System.EventHandler(this.listView1_SelectedIndexChanged);
            this.listView1.DoubleClick += new System.EventHandler(this.listView1_DoubleClick);
            // 
            // columnHeader0
            // 
            this.columnHeader0.Width = 0;
            // 
            // columnHeader1
            // 
            this.columnHeader1.Text = "First Name";
            this.columnHeader1.Width = 73;
            // 
            // columnHeader2
            // 
            this.columnHeader2.Text = "Last Name";
            this.columnHeader2.Width = 117;
            // 
            // columnHeader3
            // 
            this.columnHeader3.Text = "Birthdate";
            this.columnHeader3.Width = 104;
            // 
            // btnPrintThisYear
            // 
            this.btnPrintThisYear.BackColor = System.Drawing.Color.DarkBlue;
            this.btnPrintThisYear.ForeColor = System.Drawing.Color.White;
            this.btnPrintThisYear.Location = new System.Drawing.Point(321, 206);
            this.btnPrintThisYear.Name = "btnPrintThisYear";
            this.btnPrintThisYear.Size = new System.Drawing.Size(94, 31);
            this.btnPrintThisYear.TabIndex = 11;
            this.btnPrintThisYear.Text = "Print This Year";
            this.btnPrintThisYear.UseVisualStyleBackColor = false;
            this.btnPrintThisYear.Click += new System.EventHandler(this.btnPrintThisYear_Click);
            // 
            // menuStrip1
            // 
            this.menuStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.fileToolStripMenuItem,
            this.helpToolStripMenuItem,
            this.aboutToolStripMenuItem});
            this.menuStrip1.Location = new System.Drawing.Point(0, 0);
            this.menuStrip1.Name = "menuStrip1";
            this.menuStrip1.Size = new System.Drawing.Size(538, 24);
            this.menuStrip1.TabIndex = 13;
            this.menuStrip1.Text = "menuStrip2";
            // 
            // fileToolStripMenuItem
            // 
            this.fileToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.importToolStripMenuItem,
            this.exportToDesktopToolStripMenuItem,
            this.mergeToolStripMenuItem,
            this.backupCurrentStateToolStripMenuItem,
            this.recoverPreviousStateToolStripMenuItem,
            this.cleanDatabaseToolStripMenuItem});
            this.fileToolStripMenuItem.Name = "fileToolStripMenuItem";
            this.fileToolStripMenuItem.Size = new System.Drawing.Size(35, 20);
            this.fileToolStripMenuItem.Text = "File";
            // 
            // importToolStripMenuItem
            // 
            this.importToolStripMenuItem.Name = "importToolStripMenuItem";
            this.importToolStripMenuItem.Size = new System.Drawing.Size(177, 22);
            this.importToolStripMenuItem.Text = "Import";
            this.importToolStripMenuItem.Click += new System.EventHandler(this.importToolStripMenuItem_Click);
            // 
            // exportToDesktopToolStripMenuItem
            // 
            this.exportToDesktopToolStripMenuItem.Name = "exportToDesktopToolStripMenuItem";
            this.exportToDesktopToolStripMenuItem.Size = new System.Drawing.Size(177, 22);
            this.exportToDesktopToolStripMenuItem.Text = "Export";
            this.exportToDesktopToolStripMenuItem.Click += new System.EventHandler(this.exportToDesktopToolStripMenuItem_Click);
            // 
            // mergeToolStripMenuItem
            // 
            this.mergeToolStripMenuItem.Name = "mergeToolStripMenuItem";
            this.mergeToolStripMenuItem.Size = new System.Drawing.Size(177, 22);
            this.mergeToolStripMenuItem.Text = "Merge 2 Calendars";
            this.mergeToolStripMenuItem.Click += new System.EventHandler(this.mergeToolStripMenuItem_Click);
            // 
            // backupCurrentStateToolStripMenuItem
            // 
            this.backupCurrentStateToolStripMenuItem.Name = "backupCurrentStateToolStripMenuItem";
            this.backupCurrentStateToolStripMenuItem.Size = new System.Drawing.Size(177, 22);
            this.backupCurrentStateToolStripMenuItem.Text = "Backup Current State";
            this.backupCurrentStateToolStripMenuItem.Click += new System.EventHandler(this.backupCurrentStateToolStripMenuItem_Click);
            // 
            // recoverPreviousStateToolStripMenuItem
            // 
            this.recoverPreviousStateToolStripMenuItem.Name = "recoverPreviousStateToolStripMenuItem";
            this.recoverPreviousStateToolStripMenuItem.Size = new System.Drawing.Size(177, 22);
            this.recoverPreviousStateToolStripMenuItem.Text = "Recover Backup";
            this.recoverPreviousStateToolStripMenuItem.Click += new System.EventHandler(this.recoverPreviousStateToolStripMenuItem_Click);
            // 
            // helpToolStripMenuItem
            // 
            this.helpToolStripMenuItem.Name = "helpToolStripMenuItem";
            this.helpToolStripMenuItem.Size = new System.Drawing.Size(40, 20);
            this.helpToolStripMenuItem.Text = "Help";
            this.helpToolStripMenuItem.Click += new System.EventHandler(this.helpToolStripMenuItem_Click);
            // 
            // aboutToolStripMenuItem
            // 
            this.aboutToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.releaseNotesToolStripMenuItem});
            this.aboutToolStripMenuItem.Name = "aboutToolStripMenuItem";
            this.aboutToolStripMenuItem.Size = new System.Drawing.Size(48, 20);
            this.aboutToolStripMenuItem.Text = "About";
            // 
            // releaseNotesToolStripMenuItem
            // 
            this.releaseNotesToolStripMenuItem.Name = "releaseNotesToolStripMenuItem";
            this.releaseNotesToolStripMenuItem.Size = new System.Drawing.Size(143, 22);
            this.releaseNotesToolStripMenuItem.Text = "Release Notes";
            this.releaseNotesToolStripMenuItem.Click += new System.EventHandler(this.releaseNotesToolStripMenuItem_Click);
            // 
            // openFileDialog1
            // 
            this.openFileDialog1.FileName = "openFileDialog1";
            // 
            // btnEditList
            // 
            this.btnEditList.BackColor = System.Drawing.Color.Navy;
            this.btnEditList.ForeColor = System.Drawing.Color.White;
            this.btnEditList.Location = new System.Drawing.Point(321, 136);
            this.btnEditList.Name = "btnEditList";
            this.btnEditList.Size = new System.Drawing.Size(199, 31);
            this.btnEditList.TabIndex = 14;
            this.btnEditList.Text = "Rename Calendar";
            this.btnEditList.UseVisualStyleBackColor = false;
            this.btnEditList.Click += new System.EventHandler(this.btnEditList_Click);
            this.btnEditList.MouseLeave += new System.EventHandler(this.btnAddEditBd_MouseLeave);
            this.btnEditList.MouseHover += new System.EventHandler(this.btnAddEditBd_MouseHover);
            // 
            // cleanDatabaseToolStripMenuItem
            // 
            this.cleanDatabaseToolStripMenuItem.Name = "cleanDatabaseToolStripMenuItem";
            this.cleanDatabaseToolStripMenuItem.Size = new System.Drawing.Size(177, 22);
            this.cleanDatabaseToolStripMenuItem.Text = "Clean Database";
            this.cleanDatabaseToolStripMenuItem.Click += new System.EventHandler(this.cleanDatabaseToolStripMenuItem_Click);
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.Gainsboro;
            this.ClientSize = new System.Drawing.Size(538, 620);
            this.Controls.Add(this.btnEditList);
            this.Controls.Add(this.btnPrintThisYear);
            this.Controls.Add(this.listView1);
            this.Controls.Add(this.btnPrintNextYear);
            this.Controls.Add(this.btnRemoveList);
            this.Controls.Add(this.btnCreateList);
            this.Controls.Add(this.cboCalendar);
            this.Controls.Add(this.btnRemoveBd);
            this.Controls.Add(this.btnAddEditBd);
            this.Controls.Add(this.calDeath);
            this.Controls.Add(this.calBirth);
            this.Controls.Add(this.menuStrip1);
            this.Name = "Form1";
            this.Text = "Birthday Calendar";
            this.Load += new System.EventHandler(this.Form1_Load);
            this.menuStrip1.ResumeLayout(false);
            this.menuStrip1.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.MonthCalendar calBirth;
        private System.Windows.Forms.MonthCalendar calDeath;
        private System.Windows.Forms.Button btnAddEditBd;
        private System.Windows.Forms.Button btnRemoveBd;
        private System.Windows.Forms.ComboBox cboCalendar;
        private System.Windows.Forms.Button btnCreateList;
        private System.Windows.Forms.Button btnRemoveList;
        private System.Windows.Forms.Button btnPrintNextYear;
        private System.Windows.Forms.ListView listView1;
        private System.Windows.Forms.ColumnHeader columnHeader1;
        private System.Windows.Forms.ColumnHeader columnHeader2;
        private System.Windows.Forms.ColumnHeader columnHeader3;
        private System.Windows.Forms.ColumnHeader columnHeader0;
        private System.Windows.Forms.Button btnPrintThisYear;
        private System.Windows.Forms.MenuStrip menuStrip1;
        private System.Windows.Forms.ToolStripMenuItem aboutToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem releaseNotesToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem helpToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem fileToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem importToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem exportToDesktopToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem mergeToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem backupCurrentStateToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem recoverPreviousStateToolStripMenuItem;
        private System.Windows.Forms.OpenFileDialog openFileDialog1;
        private System.Windows.Forms.Button btnEditList;
        private System.Windows.Forms.ToolStripMenuItem cleanDatabaseToolStripMenuItem;
    }
}

