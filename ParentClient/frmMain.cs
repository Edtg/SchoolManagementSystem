using System.Globalization;

namespace ParentClient
{
    public partial class frmMain : Form
    {
        public frmMain()
        {
            InitializeComponent();

            HidePanels();

            frmLogin frmLogin = new frmLogin();
            if (frmLogin.ShowDialog() == DialogResult.Cancel)
            {
                Close();
            }

            label_LoggedInValue.Text = Session.Instance.ParentName;

            panel_Dashboard.Visible = true;
        }

        private void HidePanels()
        {
            panel_Dashboard.Visible = false;
            panel_ClassList.Visible = false;
            panel_JoinClass.Visible = false;
            panel_Broadcasts.Visible = false;
        }

        private void btn_ClassListMenu_Click(object sender, EventArgs e)
        {
            HidePanels();
            UpdateClassTable();
            panel_ClassList.Visible = true;
        }

        private void UpdateClassTable()
        {
            foreach (Label ClassTableControl in panel_ClassTable.Controls.OfType<Label>().ToList())
            {
                panel_ClassTable.Controls.Remove(ClassTableControl);
                ClassTableControl.Dispose();
            }
            panel_ClassTable.RowStyles.Clear();

            panel_ClassTable.RowCount = 0;
            List<string> Classes = Client.Instance.SendData("instruction=parentclasses|sort=date|parent=" + Session.Instance.ParentName);

            if (Classes[0] != "empty")
            {
                panel_ClassTable.RowCount = Classes.Count - 1;
                for (int i = 0; i < Classes.Count; i++)
                {
                    string ClassName = Classes[i].Split("|")[0];
                    DateTime ClassStartDate = DateTime.ParseExact(Classes[i].Split("|")[1], "yyyyMMdd:HH:mm:ss", CultureInfo.InvariantCulture);
                    DateTime ClassEndDate = DateTime.ParseExact(Classes[i].Split("|")[2], "yyyyMMdd:HH:mm:ss", CultureInfo.InvariantCulture);
                    int Marks = -1;
                    Int32.TryParse(Classes[i].Split("|")[4], out Marks);

                    Label ClassNameLabel = new Label();
                    ClassNameLabel.Text = ClassName;
                    panel_ClassTable.Controls.Add(ClassNameLabel, 0, i);

                    Label ClassStartDateLabel = new Label();
                    ClassStartDateLabel.Text = ClassStartDate.ToString("dd/MM/yyyy");
                    panel_ClassTable.Controls.Add(ClassStartDateLabel, 1, i);

                    Label ClassEndDateLabel = new Label();
                    ClassEndDateLabel.Text = ClassEndDate.ToString("dd/MM/yyyy");
                    panel_ClassTable.Controls.Add(ClassEndDateLabel, 2, i);

                    Label MarksLabel = new Label();
                    if (Marks < 0)
                    {
                        MarksLabel.Text = "Unmarked";
                    }
                    else
                    {
                        MarksLabel.Text = Marks.ToString();
                    }
                    panel_ClassTable.Controls.Add(MarksLabel, 3, i);

                    panel_ClassTable.RowStyles.Add(new RowStyle(SizeType.Absolute, 20));
                }
            }
        }

        private void btn_JoinClassMenu_Click(object sender, EventArgs e)
        {
            HidePanels();
            panel_JoinClass.Visible = true;
        }

        private void btn_JoinClass_Click(object sender, EventArgs e)
        {
            string Result = Client.Instance.SendData("instruction=joinclass|code=" + text_JoinCode.Text + "|parent=" + Session.Instance.ParentName)[0];

            if (Result.Equals("success"))
            {
                text_JoinCode.Text = "";
                MessageBox.Show("Class joined");
            }
            else
            {
                MessageBox.Show("Error joining class");
            }
        }

        private void btn_ViewBroadcastsMenu_Click(object sender, EventArgs e)
        {
            HidePanels();

            LoadBroadcasts();

            panel_Broadcasts.Visible = true;
        }

        private void LoadBroadcasts()
        {
            foreach (Label ClassTableControl in panel_Broadcasts.Controls.OfType<Label>().ToList())
            {
                panel_Broadcasts.Controls.Remove(ClassTableControl);
                ClassTableControl.Dispose();
            }

            List<string> Broadcasts = Client.Instance.SendData("instruction=getbroadcasts|parent=" + Session.Instance.ParentName);

            if (Broadcasts[0] == "empty")
            {
                Label EmptyLabel = new Label();
                EmptyLabel.Text = "No broadcasts";
                EmptyLabel.Width = panel_Broadcasts.Width;
                panel_Broadcasts.Controls.Add(EmptyLabel);
            }
            else
            {
                foreach (string Broadcast in Broadcasts)
                {
                    Label BroadcastLabel = new Label();
                    BroadcastLabel.Text = Broadcast.Split(",")[0] + ": " + Broadcast.Split(",")[1];
                    BroadcastLabel.Width = panel_Broadcasts.Width;
                    panel_Broadcasts.Controls.Add(BroadcastLabel);
                }
            }
        }

        private void btn_MessagesMenu_Click(object sender, EventArgs e)
        {
            frmMessages frm = new frmMessages();

            frm.Show();
        }
    }
}