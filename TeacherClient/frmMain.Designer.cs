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
            this.label4 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.cbo_SortBy = new System.Windows.Forms.ComboBox();
            this.panel_ClassTable = new System.Windows.Forms.TableLayoutPanel();
            this.btn_NewClass = new System.Windows.Forms.Button();
            this.panel_ClassList.SuspendLayout();
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
            this.panel_ClassTable.ColumnCount = 4;
            this.panel_ClassTable.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 50F));
            this.panel_ClassTable.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 50F));
            this.panel_ClassTable.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 181F));
            this.panel_ClassTable.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 126F));
            this.panel_ClassTable.Location = new System.Drawing.Point(3, 56);
            this.panel_ClassTable.Name = "panel_ClassTable";
            this.panel_ClassTable.RowCount = 2;
            this.panel_ClassTable.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 50.14326F));
            this.panel_ClassTable.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 49.85674F));
            this.panel_ClassTable.Size = new System.Drawing.Size(770, 338);
            this.panel_ClassTable.TabIndex = 0;
            // 
            // btn_NewClass
            // 
            this.btn_NewClass.Location = new System.Drawing.Point(3, 3);
            this.btn_NewClass.Name = "btn_NewClass";
            this.btn_NewClass.Size = new System.Drawing.Size(90, 23);
            this.btn_NewClass.TabIndex = 6;
            this.btn_NewClass.Text = "New Class";
            this.btn_NewClass.UseVisualStyleBackColor = true;
            // 
            // frmMain
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 15F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(800, 450);
            this.Controls.Add(this.panel_ClassList);
            this.Controls.Add(this.btn_MessagesMenu);
            this.Controls.Add(this.btn_BroadcastsMenu);
            this.Controls.Add(this.btn_ViewClassesMenu);
            this.Name = "frmMain";
            this.Text = "Form1";
            this.panel_ClassList.ResumeLayout(false);
            this.panel_ClassList.PerformLayout();
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
    }
}