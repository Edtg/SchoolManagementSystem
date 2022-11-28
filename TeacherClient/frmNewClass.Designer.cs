namespace TeacherClient
{
    partial class frmNewClass
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
            this.date_ClassStartDate = new System.Windows.Forms.DateTimePicker();
            this.text_ClassName = new System.Windows.Forms.TextBox();
            this.text_JoinCode = new System.Windows.Forms.TextBox();
            this.btn_Create = new System.Windows.Forms.Button();
            this.date_ClassEndDate = new System.Windows.Forms.DateTimePicker();
            this.label4 = new System.Windows.Forms.Label();
            this.SuspendLayout();
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(12, 9);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(39, 15);
            this.label1.TabIndex = 0;
            this.label1.Text = "Name";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(12, 53);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(58, 15);
            this.label2.TabIndex = 1;
            this.label2.Text = "Start Date";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(12, 141);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(59, 15);
            this.label3.TabIndex = 2;
            this.label3.Text = "Join Code";
            // 
            // date_ClassStartDate
            // 
            this.date_ClassStartDate.Location = new System.Drawing.Point(12, 71);
            this.date_ClassStartDate.Name = "date_ClassStartDate";
            this.date_ClassStartDate.Size = new System.Drawing.Size(219, 23);
            this.date_ClassStartDate.TabIndex = 3;
            // 
            // text_ClassName
            // 
            this.text_ClassName.Location = new System.Drawing.Point(12, 27);
            this.text_ClassName.Name = "text_ClassName";
            this.text_ClassName.Size = new System.Drawing.Size(219, 23);
            this.text_ClassName.TabIndex = 4;
            // 
            // text_JoinCode
            // 
            this.text_JoinCode.Location = new System.Drawing.Point(13, 159);
            this.text_JoinCode.Name = "text_JoinCode";
            this.text_JoinCode.Size = new System.Drawing.Size(219, 23);
            this.text_JoinCode.TabIndex = 5;
            // 
            // btn_Create
            // 
            this.btn_Create.Location = new System.Drawing.Point(12, 188);
            this.btn_Create.Name = "btn_Create";
            this.btn_Create.Size = new System.Drawing.Size(219, 23);
            this.btn_Create.TabIndex = 6;
            this.btn_Create.Text = "Create";
            this.btn_Create.UseVisualStyleBackColor = true;
            this.btn_Create.Click += new System.EventHandler(this.btn_Create_Click);
            // 
            // date_ClassEndDate
            // 
            this.date_ClassEndDate.Location = new System.Drawing.Point(13, 115);
            this.date_ClassEndDate.Name = "date_ClassEndDate";
            this.date_ClassEndDate.Size = new System.Drawing.Size(218, 23);
            this.date_ClassEndDate.TabIndex = 7;
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(13, 97);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(51, 15);
            this.label4.TabIndex = 8;
            this.label4.Text = "EndDate";
            // 
            // frmNewClass
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 15F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(243, 222);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.date_ClassEndDate);
            this.Controls.Add(this.btn_Create);
            this.Controls.Add(this.text_JoinCode);
            this.Controls.Add(this.text_ClassName);
            this.Controls.Add(this.date_ClassStartDate);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.Name = "frmNewClass";
            this.Text = "frmNewClass";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private Label label1;
        private Label label2;
        private Label label3;
        private DateTimePicker date_ClassStartDate;
        private TextBox text_ClassName;
        private TextBox text_JoinCode;
        private Button btn_Create;
        private DateTimePicker date_ClassEndDate;
        private Label label4;
    }
}