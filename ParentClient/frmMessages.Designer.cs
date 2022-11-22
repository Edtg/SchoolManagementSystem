namespace ParentClient
{
    partial class frmMessages
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
            this.cbo_Contacts = new System.Windows.Forms.ComboBox();
            this.text_Message = new System.Windows.Forms.TextBox();
            this.btn_Send = new System.Windows.Forms.Button();
            this.panel_Messages = new System.Windows.Forms.FlowLayoutPanel();
            this.SuspendLayout();
            // 
            // cbo_Contacts
            // 
            this.cbo_Contacts.FormattingEnabled = true;
            this.cbo_Contacts.Location = new System.Drawing.Point(12, 12);
            this.cbo_Contacts.Name = "cbo_Contacts";
            this.cbo_Contacts.Size = new System.Drawing.Size(252, 23);
            this.cbo_Contacts.TabIndex = 0;
            this.cbo_Contacts.SelectedIndexChanged += new System.EventHandler(this.cbo_Contacts_SelectedIndexChanged);
            // 
            // text_Message
            // 
            this.text_Message.Location = new System.Drawing.Point(12, 316);
            this.text_Message.Name = "text_Message";
            this.text_Message.Size = new System.Drawing.Size(252, 23);
            this.text_Message.TabIndex = 1;
            // 
            // btn_Send
            // 
            this.btn_Send.Location = new System.Drawing.Point(12, 345);
            this.btn_Send.Name = "btn_Send";
            this.btn_Send.Size = new System.Drawing.Size(252, 23);
            this.btn_Send.TabIndex = 2;
            this.btn_Send.Text = "Send";
            this.btn_Send.UseVisualStyleBackColor = true;
            this.btn_Send.Click += new System.EventHandler(this.btn_Send_Click);
            // 
            // panel_Messages
            // 
            this.panel_Messages.AutoScroll = true;
            this.panel_Messages.Location = new System.Drawing.Point(12, 41);
            this.panel_Messages.Name = "panel_Messages";
            this.panel_Messages.Size = new System.Drawing.Size(252, 269);
            this.panel_Messages.TabIndex = 3;
            // 
            // frmMessages
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 15F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(276, 381);
            this.Controls.Add(this.panel_Messages);
            this.Controls.Add(this.btn_Send);
            this.Controls.Add(this.text_Message);
            this.Controls.Add(this.cbo_Contacts);
            this.Name = "frmMessages";
            this.Text = "frmMessages";
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.frmMessages_FormClosing);
            this.FormClosed += new System.Windows.Forms.FormClosedEventHandler(this.frmMessages_FormClosed);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private ComboBox cbo_Contacts;
        private TextBox text_Message;
        private Button btn_Send;
        private FlowLayoutPanel panel_Messages;
    }
}