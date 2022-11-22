﻿using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace ParentClient
{
    public partial class frmMessages : Form
    {
        private struct Message
        {
            public string Content { get; set; }
            public DateTime Timestamp { get; set; }
            public string Sender { get; set; }

        }

        private System.Windows.Forms.Timer UpdateTimer;

        private List<Message> SavedMessages;

        public frmMessages()
        {
            InitializeComponent();

            List<string> Classes = Client.Instance.SendData("instruction=parentclasses|sort=date|parent=" + Session.Instance.ParentName);

            for (int i = 1; i < Classes.Count; i++)
            {
                string Teacher = Classes[i].Split("|")[2];
                cbo_Contacts.Items.Add(Teacher);
            }

            if (cbo_Contacts.Items.Count > 0)
            {
                SavedMessages = new List<Message>();

                cbo_Contacts.SelectedIndex = 0;

                LoadMessages();

                UpdateTimer = new System.Windows.Forms.Timer();
                UpdateTimer.Interval = 2000;
                UpdateTimer.Tick += new EventHandler(LoadTick);
                UpdateTimer.Start();
            }
        }

        private void cbo_Contacts_SelectedIndexChanged(object sender, EventArgs e)
        {
            LoadMessages();
        }

        private void LoadTick(object sender, EventArgs e)
        {
            UpdateMessages();
        }

        private void LoadMessages()
        {
            foreach (Label ClassTableControl in panel_Messages.Controls.OfType<Label>().ToList())
            {
                panel_Messages.Controls.Remove(ClassTableControl);
                ClassTableControl.Dispose();
            }

            List<string> Messages = Client.Instance.SendData("instruction=getmessages|usertype=parent|username=" + Session.Instance.ParentName + "|contact=" + cbo_Contacts.SelectedItem);

            if (Messages[0] == "empty" || Messages[0] == "fail")
                return;

            foreach(string Message in Messages)
            {
                string SenderName = Message.Split("|")[0];
                string MessageContent = Message.Split("|")[1];
                DateTime MessageTime = DateTime.ParseExact(Message.Split("|")[2], "yyyyMMdd:HH:mm:ss", CultureInfo.InvariantCulture);

                SavedMessages.Add(new frmMessages.Message { Content = MessageContent, Timestamp = MessageTime, Sender = SenderName });

                Label MessageLabel = new Label();
                MessageLabel.Text = SenderName + ": " + MessageContent;
                MessageLabel.Width = panel_Messages.Width;
                panel_Messages.Controls.Add(MessageLabel);

                panel_Messages.ScrollControlIntoView(MessageLabel);
            }
        }

        private void UpdateMessages()
        {
            List<string> Messages = Client.Instance.SendData("instruction=getmessages|usertype=parent|username=" + Session.Instance.ParentName + "|contact=" + cbo_Contacts.SelectedItem);

            if (Messages[0] == "empty" || Messages[0] == "fail")
                return;

            foreach (string Message in Messages)
            {
                DateTime MessageTime = DateTime.ParseExact(Message.Split("|")[2], "yyyyMMdd:HH:mm:ss", CultureInfo.InvariantCulture);
                if (MessageTime > SavedMessages[SavedMessages.Count - 1].Timestamp)
                {
                    string SenderName = Message.Split("|")[0];
                    string MessageContent = Message.Split("|")[1];

                    SavedMessages.Add(new frmMessages.Message { Content = MessageContent, Timestamp = MessageTime, Sender = SenderName });

                    Label MessageLabel = new Label();
                    MessageLabel.Text = SenderName + ": " + MessageContent;
                    MessageLabel.Width = panel_Messages.Width;
                    panel_Messages.Controls.Add(MessageLabel);

                    panel_Messages.ScrollControlIntoView(MessageLabel);
                }
            }

        }

        private void btn_Send_Click(object sender, EventArgs e)
        {
            Client.Instance.SendData("instruction=sendmessage|sendertype=parent|sender=" + Session.Instance.ParentName + "|receivers=" + cbo_Contacts.SelectedItem + "|content=" + text_Message.Text);

            Label MessageLabel = new Label();
            MessageLabel.Text = Session.Instance.ParentName + ": " + text_Message.Text;
            MessageLabel.Width = panel_Messages.Width;
            panel_Messages.Controls.Add(MessageLabel);

            panel_Messages.ScrollControlIntoView(MessageLabel);

            SavedMessages.Add(new frmMessages.Message { Content = text_Message.Text, Timestamp = DateTime.Now, Sender = Session.Instance.ParentName });

            text_Message.Text = "";
        }

        private void frmMessages_FormClosing(object sender, FormClosingEventArgs e)
        {
            if (UpdateTimer != null)
            {
                UpdateTimer.Stop();
                UpdateTimer.Tick -= new EventHandler(LoadTick);
            }
        }

        private void frmMessages_FormClosed(object sender, FormClosedEventArgs e)
        {
            if (UpdateTimer != null)
            {
                UpdateTimer.Dispose();
                UpdateTimer = null;
            }
        }
    }
}
