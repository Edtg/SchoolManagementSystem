namespace TeacherClient
{
    partial class frmMain
    {
        /// <summary>
        ///  Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        ///  Clean up any resources being used.
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
        ///  Required method for Designer support - do not modify
        ///  the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.btn_ViewClassesMenu = new System.Windows.Forms.Button();
            this.btn_BroadcastsMenu = new System.Windows.Forms.Button();
            this.btn_MessagesMenu = new System.Windows.Forms.Button();
            this.panel_ClassList = new System.Windows.Forms.Panel();
            this.btn_NewClass = new System.Windows.Forms.Button();
            this.label4 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.cbo_SortBy = new System.Windows.Forms.ComboBox();
            this.panel_ClassTable = new System.Windows.Forms.TableLayoutPanel();
            this.date_SimulationDate = new System.Windows.Forms.DateTimePicker();
            this.btn_SetDate = new System.Windows.Forms.Button();
            this.panel_Broadcasts = new System.Windows.Forms.Panel();
            this.btn_SendBroadcast = new System.Windows.Forms.Button();
            this.text_Broadcast = new System.Windows.Forms.TextBox();
            this.cbo_BroadcastReceiver = new System.Windows.Forms.ComboBox();
            this.panel_EditClass = new System.Windows.Forms.Panel();
            this.btn_DeleteEditingClass = new System.Windows.Forms.Button();
            this.btn_SaveClassEdit = new System.Windows.Forms.Button();
            this.label10 = new System.Windows.Forms.Label();
            this.label9 = new System.Windows.Forms.Label();
            this.date_EditEndDate = new System.Windows.Forms.DateTimePicker();
            this.date_EditStartDate = new System.Windows.Forms.DateTimePicker();
            this.text_EditJoinCode = new System.Windows.Forms.TextBox();
            this.text_EditClassName = new System.Windows.Forms.TextBox();
            this.label8 = new System.Windows.Forms.Label();
            this.label7 = new System.Windows.Forms.Label();
            this.label6 = new System.Windows.Forms.Label();
            this.label5 = new System.Windows.Forms.Label();
            this.panel_EditingClassMarks = new System.Windows.Forms.TableLayoutPanel();
            this.panel_ClassList.SuspendLayout();
            this.panel_Broadcasts.SuspendLayout();
            this.panel_EditClass.SuspendLayout();
            this.SuspendLayout();
            // 
            // btn_ViewClassesMenu
            // 
            this.btn_ViewClassesMenu.Location = new System.Drawing.Point(12, 12);
            this.btn_ViewClassesMenu.Name = "btn_ViewClassesMenu";
            this.btn_ViewClassesMenu.Size = new System.Drawing.Size(93, 23);
            this.btn_ViewClassesMenu.TabIndex = 0;
            this.btn_ViewClassesMenu.Text = "View Classes";
            this.btn_ViewClassesMenu.UseVisualStyleBackColor = true;
            this.btn_ViewClassesMenu.Click += new System.EventHandler(this.btn_ViewClassesMenu_Click);
            // 
            // btn_BroadcastsMenu
            // 
            this.btn_BroadcastsMenu.Location = new System.Drawing.Point(111, 12);
            this.btn_BroadcastsMenu.Name = "btn_BroadcastsMenu";
            this.btn_BroadcastsMenu.Size = new System.Drawing.Size(125, 23);
            this.btn_BroadcastsMenu.TabIndex = 1;
            this.btn_BroadcastsMenu.Text = "Broadcast Message";
            this.btn_BroadcastsMenu.UseVisualStyleBackColor = true;
            this.btn_BroadcastsMenu.Click += new System.EventHandler(this.btn_BroadcastsMenu_Click);
            // 
            // btn_MessagesMenu
            // 
            this.btn_MessagesMenu.Location = new System.Drawing.Point(242, 12);
            this.btn_MessagesMenu.Name = "btn_MessagesMenu";
            this.btn_MessagesMenu.Size = new System.Drawing.Size(101, 23);
            this.btn_MessagesMenu.TabIndex = 2;
            this.btn_MessagesMenu.Text = "View Messages";
            this.btn_MessagesMenu.UseVisualStyleBackColor = true;
            this.btn_MessagesMenu.Click += new System.EventHandler(this.btn_MessagesMenu_Click);
            // 
            // panel_ClassList
            // 
            this.panel_ClassList.Controls.Add(this.btn_NewClass);
            this.panel_ClassList.Controls.Add(this.label4);
            this.panel_ClassList.Controls.Add(this.label3);
            this.panel_ClassList.Controls.Add(this.label2);
            this.panel_ClassList.Controls.Add(this.label1);
            this.panel_ClassList.Controls.Add(this.cbo_SortBy);
            this.panel_ClassList.Controls.Add(this.panel_ClassTable);
            this.panel_ClassList.Location = new System.Drawing.Point(12, 41);
            this.panel_ClassList.Name = "panel_ClassList";
            this.panel_ClassList.Size = new System.Drawing.Size(776, 397);
            this.panel_ClassList.TabIndex = 3;
            // 
            // btn_NewClass
            // 
            this.btn_NewClass.Location = new System.Drawing.Point(3, 3);
            this.btn_NewClass.Name = "btn_NewClass";
            this.btn_NewClass.Size = new System.Drawing.Size(90, 23);
            this.btn_NewClass.TabIndex = 6;
            this.btn_NewClass.Text = "New Class";
            this.btn_NewClass.UseVisualStyleBackColor = true;
            this.btn_NewClass.Click += new System.EventHandler(this.btn_NewClass_Click);
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(652, 38);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(47, 15);
            this.label4.TabIndex = 5;
            this.label4.Text = "Actions";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(467, 38);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(113, 15);
            this.label3.TabIndex = 4;
            this.label3.Text = "Number of students";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(239, 38);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(31, 15);
            this.label2.TabIndex = 3;
            this.label2.Text = "Date";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(3, 38);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(39, 15);
            this.label1.TabIndex = 2;
            this.label1.Text = "Name";
            // 
            // cbo_SortBy
            // 
            this.cbo_SortBy.FormattingEnabled = true;
            this.cbo_SortBy.Items.AddRange(new object[] {
            "Name",
            "Date",
            "Student Count"});
            this.cbo_SortBy.Location = new System.Drawing.Point(652, 3);
            this.cbo_SortBy.Name = "cbo_SortBy";
            this.cbo_SortBy.Size = new System.Drawing.Size(121, 23);
            this.cbo_SortBy.TabIndex = 1;
            this.cbo_SortBy.SelectedIndexChanged += new System.EventHandler(this.cbo_SortBy_SelectedIndexChanged);
            // 
            // panel_ClassTable
            // 
            this.panel_ClassTable.CellBorderStyle = System.Windows.Forms.TableLayoutPanelCellBorderStyle.Single;
            this.panel_ClassTable.ColumnCount = 4;
            this.panel_ClassTable.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 50F));
            this.panel_ClassTable.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 50F));
            this.panel_ClassTable.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 181F));
            this.panel_ClassTable.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 129F));
            this.panel_ClassTable.Location = new System.Drawing.Point(3, 56);
            this.panel_ClassTable.Name = "panel_ClassTable";
            this.panel_ClassTable.RowCount = 2;
            this.panel_ClassTable.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 50.14326F));
            this.panel_ClassTable.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 49.85674F));
            this.panel_ClassTable.Size = new System.Drawing.Size(770, 338);
            this.panel_ClassTable.TabIndex = 0;
            // 
            // date_SimulationDate
            // 
            this.date_SimulationDate.Location = new System.Drawing.Point(446, 12);
            this.date_SimulationDate.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.date_SimulationDate.Name = "date_SimulationDate";
            this.date_SimulationDate.Size = new System.Drawing.Size(219, 23);
            this.date_SimulationDate.TabIndex = 4;
            // 
            // btn_SetDate
            // 
            this.btn_SetDate.Location = new System.Drawing.Point(678, 12);
            this.btn_SetDate.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.btn_SetDate.Name = "btn_SetDate";
            this.btn_SetDate.Size = new System.Drawing.Size(107, 22);
            this.btn_SetDate.TabIndex = 5;
            this.btn_SetDate.Text = "Set Date";
            this.btn_SetDate.UseVisualStyleBackColor = true;
            this.btn_SetDate.Click += new System.EventHandler(this.btn_SetDate_Click);
            // 
            // panel_Broadcasts
            // 
            this.panel_Broadcasts.Controls.Add(this.btn_SendBroadcast);
            this.panel_Broadcasts.Controls.Add(this.text_Broadcast);
            this.panel_Broadcasts.Controls.Add(this.cbo_BroadcastReceiver);
            this.panel_Broadcasts.Location = new System.Drawing.Point(12, 39);
            this.panel_Broadcasts.Name = "panel_Broadcasts";
            this.panel_Broadcasts.Size = new System.Drawing.Size(776, 399);
            this.panel_Broadcasts.TabIndex = 6;
            // 
            // btn_SendBroadcast
            // 
            this.btn_SendBroadcast.Location = new System.Drawing.Point(3, 72);
            this.btn_SendBroadcast.Name = "btn_SendBroadcast";
            this.btn_SendBroadcast.Size = new System.Drawing.Size(375, 23);
            this.btn_SendBroadcast.TabIndex = 2;
            this.btn_SendBroadcast.Text = "Send Broadcast";
            this.btn_SendBroadcast.UseVisualStyleBackColor = true;
            this.btn_SendBroadcast.Click += new System.EventHandler(this.btn_SendBroadcast_Click);
            // 
            // text_Broadcast
            // 
            this.text_Broadcast.Location = new System.Drawing.Point(3, 43);
            this.text_Broadcast.Name = "text_Broadcast";
            this.text_Broadcast.Size = new System.Drawing.Size(375, 23);
            this.text_Broadcast.TabIndex = 1;
            // 
            // cbo_BroadcastReceiver
            // 
            this.cbo_BroadcastReceiver.FormattingEnabled = true;
            this.cbo_BroadcastReceiver.Location = new System.Drawing.Point(3, 14);
            this.cbo_BroadcastReceiver.Name = "cbo_BroadcastReceiver";
            this.cbo_BroadcastReceiver.Size = new System.Drawing.Size(375, 23);
            this.cbo_BroadcastReceiver.TabIndex = 0;
            // 
            // panel_EditClass
            // 
            this.panel_EditClass.Controls.Add(this.btn_DeleteEditingClass);
            this.panel_EditClass.Controls.Add(this.btn_SaveClassEdit);
            this.panel_EditClass.Controls.Add(this.label10);
            this.panel_EditClass.Controls.Add(this.label9);
            this.panel_EditClass.Controls.Add(this.date_EditEndDate);
            this.panel_EditClass.Controls.Add(this.date_EditStartDate);
            this.panel_EditClass.Controls.Add(this.text_EditJoinCode);
            this.panel_EditClass.Controls.Add(this.text_EditClassName);
            this.panel_EditClass.Controls.Add(this.label8);
            this.panel_EditClass.Controls.Add(this.label7);
            this.panel_EditClass.Controls.Add(this.label6);
            this.panel_EditClass.Controls.Add(this.label5);
            this.panel_EditClass.Controls.Add(this.panel_EditingClassMarks);
            this.panel_EditClass.Location = new System.Drawing.Point(12, 39);
            this.panel_EditClass.Name = "panel_EditClass";
            this.panel_EditClass.Size = new System.Drawing.Size(776, 399);
            this.panel_EditClass.TabIndex = 7;
            // 
            // btn_DeleteEditingClass
            // 
            this.btn_DeleteEditingClass.Location = new System.Drawing.Point(132, 373);
            this.btn_DeleteEditingClass.Name = "btn_DeleteEditingClass";
            this.btn_DeleteEditingClass.Size = new System.Drawing.Size(122, 23);
            this.btn_DeleteEditingClass.TabIndex = 12;
            this.btn_DeleteEditingClass.Text = "Delete";
            this.btn_DeleteEditingClass.UseVisualStyleBackColor = true;
            this.btn_DeleteEditingClass.Click += new System.EventHandler(this.btn_DeleteEditingClass_Click);
            // 
            // btn_SaveClassEdit
            // 
            this.btn_SaveClassEdit.Location = new System.Drawing.Point(4, 373);
            this.btn_SaveClassEdit.Name = "btn_SaveClassEdit";
            this.btn_SaveClassEdit.Size = new System.Drawing.Size(122, 23);
            this.btn_SaveClassEdit.TabIndex = 11;
            this.btn_SaveClassEdit.Text = "Save";
            this.btn_SaveClassEdit.UseVisualStyleBackColor = true;
            this.btn_SaveClassEdit.Click += new System.EventHandler(this.btn_SaveClassEdit_Click);
            // 
            // label10
            // 
            this.label10.AutoSize = true;
            this.label10.Location = new System.Drawing.Point(387, 126);
            this.label10.Name = "label10";
            this.label10.Size = new System.Drawing.Size(39, 15);
            this.label10.TabIndex = 10;
            this.label10.Text = "Marks";
            // 
            // label9
            // 
            this.label9.AutoSize = true;
            this.label9.Location = new System.Drawing.Point(4, 126);
            this.label9.Name = "label9";
            this.label9.Size = new System.Drawing.Size(53, 15);
            this.label9.TabIndex = 9;
            this.label9.Text = "Students";
            // 
            // date_EditEndDate
            // 
            this.date_EditEndDate.Location = new System.Drawing.Point(99, 64);
            this.date_EditEndDate.Name = "date_EditEndDate";
            this.date_EditEndDate.Size = new System.Drawing.Size(200, 23);
            this.date_EditEndDate.TabIndex = 8;
            // 
            // date_EditStartDate
            // 
            this.date_EditStartDate.Location = new System.Drawing.Point(99, 35);
            this.date_EditStartDate.Name = "date_EditStartDate";
            this.date_EditStartDate.Size = new System.Drawing.Size(200, 23);
            this.date_EditStartDate.TabIndex = 7;
            // 
            // text_EditJoinCode
            // 
            this.text_EditJoinCode.Location = new System.Drawing.Point(99, 93);
            this.text_EditJoinCode.Name = "text_EditJoinCode";
            this.text_EditJoinCode.Size = new System.Drawing.Size(260, 23);
            this.text_EditJoinCode.TabIndex = 6;
            // 
            // text_EditClassName
            // 
            this.text_EditClassName.Location = new System.Drawing.Point(99, 6);
            this.text_EditClassName.Name = "text_EditClassName";
            this.text_EditClassName.Size = new System.Drawing.Size(260, 23);
            this.text_EditClassName.TabIndex = 5;
            // 
            // label8
            // 
            this.label8.AutoSize = true;
            this.label8.Location = new System.Drawing.Point(4, 96);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(62, 15);
            this.label8.TabIndex = 4;
            this.label8.Text = "Join Code:";
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Location = new System.Drawing.Point(4, 69);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(57, 15);
            this.label7.TabIndex = 3;
            this.label7.Text = "End Date:";
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Location = new System.Drawing.Point(3, 41);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(61, 15);
            this.label6.TabIndex = 2;
            this.label6.Text = "Start Date:";
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(4, 9);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(70, 15);
            this.label5.TabIndex = 1;
            this.label5.Text = "Class name:";
            // 
            // panel_EditingClassMarks
            // 
            this.panel_EditingClassMarks.CellBorderStyle = System.Windows.Forms.TableLayoutPanelCellBorderStyle.Single;
            this.panel_EditingClassMarks.ColumnCount = 2;
            this.panel_EditingClassMarks.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 50F));
            this.panel_EditingClassMarks.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 50F));
            this.panel_EditingClassMarks.Location = new System.Drawing.Point(3, 153);
            this.panel_EditingClassMarks.Name = "panel_EditingClassMarks";
            this.panel_EditingClassMarks.RowCount = 1;
            this.panel_EditingClassMarks.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 50F));
            this.panel_EditingClassMarks.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 50F));
            this.panel_EditingClassMarks.Size = new System.Drawing.Size(770, 214);
            this.panel_EditingClassMarks.TabIndex = 0;
            // 
            // frmMain
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 15F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(800, 450);
            this.Controls.Add(this.panel_EditClass);
            this.Controls.Add(this.panel_Broadcasts);
            this.Controls.Add(this.btn_SetDate);
            this.Controls.Add(this.date_SimulationDate);
            this.Controls.Add(this.panel_ClassList);
            this.Controls.Add(this.btn_MessagesMenu);
            this.Controls.Add(this.btn_BroadcastsMenu);
            this.Controls.Add(this.btn_ViewClassesMenu);
            this.Name = "frmMain";
            this.Text = "Teacher Client";
            this.panel_ClassList.ResumeLayout(false);
            this.panel_ClassList.PerformLayout();
            this.panel_Broadcasts.ResumeLayout(false);
            this.panel_Broadcasts.PerformLayout();
            this.panel_EditClass.ResumeLayout(false);
            this.panel_EditClass.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private Button btn_ViewClassesMenu;
        private Button btn_BroadcastsMenu;
        private Button btn_MessagesMenu;
        private Panel panel_ClassList;
        private TableLayoutPanel panel_ClassTable;
        private ComboBox cbo_SortBy;
        private Label label1;
        private Label label2;
        private Label label3;
        private Label label4;
        private Button btn_NewClass;
        private DateTimePicker date_SimulationDate;
        private Button btn_SetDate;
        private Panel panel_Broadcasts;
        private Button btn_SendBroadcast;
        private TextBox text_Broadcast;
        private ComboBox cbo_BroadcastReceiver;
        private Panel panel_EditClass;
        private Label label7;
        private Label label6;
        private Label label5;
        private TableLayoutPanel panel_EditingClassMarks;
        private Label label8;
        private TextBox text_EditJoinCode;
        private TextBox text_EditClassName;
        private DateTimePicker date_EditEndDate;
        private DateTimePicker date_EditStartDate;
        private Label label10;
        private Label label9;
        private Button btn_SaveClassEdit;
        private Button btn_DeleteEditingClass;
    }
}