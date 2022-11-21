namespace ParentClient
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
            this.text_Input = new System.Windows.Forms.TextBox();
            this.btn_Submit = new System.Windows.Forms.Button();
            this.panel_ClassList = new System.Windows.Forms.Panel();
            this.label2 = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.panel_ClassTable = new System.Windows.Forms.TableLayoutPanel();
            this.btn_ClassListMenu = new System.Windows.Forms.Button();
            this.btn_JoinClassMenu = new System.Windows.Forms.Button();
            this.btn_ViewBroadcastsMenu = new System.Windows.Forms.Button();
            this.btn_MessagesMenu = new System.Windows.Forms.Button();
            this.panel_JoinClass = new System.Windows.Forms.Panel();
            this.label3 = new System.Windows.Forms.Label();
            this.btn_JoinClass = new System.Windows.Forms.Button();
            this.text_JoinCode = new System.Windows.Forms.TextBox();
            this.panel_ClassList.SuspendLayout();
            this.panel_JoinClass.SuspendLayout();
            this.SuspendLayout();
            // 
            // text_Input
            // 
            this.text_Input.Location = new System.Drawing.Point(533, 12);
            this.text_Input.Name = "text_Input";
            this.text_Input.Size = new System.Drawing.Size(100, 23);
            this.text_Input.TabIndex = 0;
            // 
            // btn_Submit
            // 
            this.btn_Submit.Location = new System.Drawing.Point(664, 12);
            this.btn_Submit.Name = "btn_Submit";
            this.btn_Submit.Size = new System.Drawing.Size(100, 23);
            this.btn_Submit.TabIndex = 1;
            this.btn_Submit.Text = "Send";
            this.btn_Submit.UseVisualStyleBackColor = true;
            this.btn_Submit.Click += new System.EventHandler(this.btn_Submit_Click);
            // 
            // panel_ClassList
            // 
            this.panel_ClassList.Controls.Add(this.label2);
            this.panel_ClassList.Controls.Add(this.label1);
            this.panel_ClassList.Controls.Add(this.panel_ClassTable);
            this.panel_ClassList.Location = new System.Drawing.Point(12, 41);
            this.panel_ClassList.Name = "panel_ClassList";
            this.panel_ClassList.Size = new System.Drawing.Size(776, 397);
            this.panel_ClassList.TabIndex = 2;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(485, 11);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(31, 15);
            this.label2.TabIndex = 2;
            this.label2.Text = "Date";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(3, 11);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(34, 15);
            this.label1.TabIndex = 1;
            this.label1.Text = "Class";
            // 
            // panel_ClassTable
            // 
            this.panel_ClassTable.AutoScroll = true;
            this.panel_ClassTable.CellBorderStyle = System.Windows.Forms.TableLayoutPanelCellBorderStyle.Single;
            this.panel_ClassTable.ColumnCount = 2;
            this.panel_ClassTable.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 61.03896F));
            this.panel_ClassTable.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 38.96104F));
            this.panel_ClassTable.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 259F));
            this.panel_ClassTable.Location = new System.Drawing.Point(3, 40);
            this.panel_ClassTable.Name = "panel_ClassTable";
            this.panel_ClassTable.RowCount = 1;
            this.panel_ClassTable.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 50F));
            this.panel_ClassTable.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 50F));
            this.panel_ClassTable.Size = new System.Drawing.Size(770, 354);
            this.panel_ClassTable.TabIndex = 0;
            // 
            // btn_ClassListMenu
            // 
            this.btn_ClassListMenu.Location = new System.Drawing.Point(15, 11);
            this.btn_ClassListMenu.Name = "btn_ClassListMenu";
            this.btn_ClassListMenu.Size = new System.Drawing.Size(92, 23);
            this.btn_ClassListMenu.TabIndex = 3;
            this.btn_ClassListMenu.Text = "View Classes";
            this.btn_ClassListMenu.UseVisualStyleBackColor = true;
            this.btn_ClassListMenu.Click += new System.EventHandler(this.btn_ClassListMenu_Click);
            // 
            // btn_JoinClassMenu
            // 
            this.btn_JoinClassMenu.Location = new System.Drawing.Point(113, 11);
            this.btn_JoinClassMenu.Name = "btn_JoinClassMenu";
            this.btn_JoinClassMenu.Size = new System.Drawing.Size(75, 23);
            this.btn_JoinClassMenu.TabIndex = 4;
            this.btn_JoinClassMenu.Text = "Join Class";
            this.btn_JoinClassMenu.UseVisualStyleBackColor = true;
            this.btn_JoinClassMenu.Click += new System.EventHandler(this.btn_JoinClassMenu_Click);
            // 
            // btn_ViewBroadcastsMenu
            // 
            this.btn_ViewBroadcastsMenu.Location = new System.Drawing.Point(194, 11);
            this.btn_ViewBroadcastsMenu.Name = "btn_ViewBroadcastsMenu";
            this.btn_ViewBroadcastsMenu.Size = new System.Drawing.Size(105, 23);
            this.btn_ViewBroadcastsMenu.TabIndex = 5;
            this.btn_ViewBroadcastsMenu.Text = "View Broadcasts";
            this.btn_ViewBroadcastsMenu.UseVisualStyleBackColor = true;
            this.btn_ViewBroadcastsMenu.Click += new System.EventHandler(this.btn_ViewBroadcastsMenu_Click);
            // 
            // btn_MessagesMenu
            // 
            this.btn_MessagesMenu.Location = new System.Drawing.Point(305, 12);
            this.btn_MessagesMenu.Name = "btn_MessagesMenu";
            this.btn_MessagesMenu.Size = new System.Drawing.Size(117, 23);
            this.btn_MessagesMenu.TabIndex = 6;
            this.btn_MessagesMenu.Text = "Message Teacher";
            this.btn_MessagesMenu.UseVisualStyleBackColor = true;
            this.btn_MessagesMenu.Click += new System.EventHandler(this.btn_MessagesMenu_Click);
            // 
            // panel_JoinClass
            // 
            this.panel_JoinClass.Controls.Add(this.label3);
            this.panel_JoinClass.Controls.Add(this.btn_JoinClass);
            this.panel_JoinClass.Controls.Add(this.text_JoinCode);
            this.panel_JoinClass.Location = new System.Drawing.Point(12, 41);
            this.panel_JoinClass.Name = "panel_JoinClass";
            this.panel_JoinClass.Size = new System.Drawing.Size(776, 397);
            this.panel_JoinClass.TabIndex = 7;
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(3, 11);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(98, 15);
            this.label3.TabIndex = 2;
            this.label3.Text = "Enter Class Code:";
            // 
            // btn_JoinClass
            // 
            this.btn_JoinClass.Location = new System.Drawing.Point(0, 58);
            this.btn_JoinClass.Name = "btn_JoinClass";
            this.btn_JoinClass.Size = new System.Drawing.Size(121, 23);
            this.btn_JoinClass.TabIndex = 1;
            this.btn_JoinClass.Text = "Join";
            this.btn_JoinClass.UseVisualStyleBackColor = true;
            this.btn_JoinClass.Click += new System.EventHandler(this.btn_JoinClass_Click);
            // 
            // text_JoinCode
            // 
            this.text_JoinCode.Location = new System.Drawing.Point(3, 29);
            this.text_JoinCode.Name = "text_JoinCode";
            this.text_JoinCode.Size = new System.Drawing.Size(118, 23);
            this.text_JoinCode.TabIndex = 0;
            // 
            // frmMain
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 15F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(800, 450);
            this.Controls.Add(this.panel_JoinClass);
            this.Controls.Add(this.btn_MessagesMenu);
            this.Controls.Add(this.btn_ViewBroadcastsMenu);
            this.Controls.Add(this.btn_JoinClassMenu);
            this.Controls.Add(this.btn_ClassListMenu);
            this.Controls.Add(this.panel_ClassList);
            this.Controls.Add(this.btn_Submit);
            this.Controls.Add(this.text_Input);
            this.Name = "frmMain";
            this.Text = "Form1";
            this.panel_ClassList.ResumeLayout(false);
            this.panel_ClassList.PerformLayout();
            this.panel_JoinClass.ResumeLayout(false);
            this.panel_JoinClass.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private TextBox text_Input;
        private Button btn_Submit;
        private Panel panel_ClassList;
        private TableLayoutPanel panel_ClassTable;
        private Label label2;
        private Label label1;
        private Button btn_ClassListMenu;
        private Button btn_JoinClassMenu;
        private Button btn_ViewBroadcastsMenu;
        private Button btn_MessagesMenu;
        private Panel panel_JoinClass;
        private Label label3;
        private Button btn_JoinClass;
        private TextBox text_JoinCode;
    }
}