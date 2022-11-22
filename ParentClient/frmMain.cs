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
        }

        private void HidePanels()
        {
            panel_ClassList.Visible = false;
            panel_JoinClass.Visible = false;
        }

        private void btn_Submit_Click(object sender, EventArgs e)
        {
            Client.Instance.SendData(text_Input.Text);
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
            
            panel_ClassTable.RowCount = Classes.Count - 1;
            for (int i = 1; i < Classes.Count; i++)
            {
                string ClassName = Classes[i].Split("|")[0];
                string ClassDate = Classes[i].Split("|")[1];

                Label ClassNameLabel = new Label();
                ClassNameLabel.Text = ClassName;
                panel_ClassTable.Controls.Add(ClassNameLabel, 0, i - 1);

                Label ClassDateLabel = new Label();
                ClassDateLabel.Text = ClassDate;
                panel_ClassTable.Controls.Add(ClassDateLabel, 1, i - 1);

                panel_ClassTable.RowStyles.Add(new RowStyle(SizeType.Absolute, 20));
            }
        }

        private void btn_JoinClassMenu_Click(object sender, EventArgs e)
        {
            HidePanels();
            panel_JoinClass.Visible = true;
        }

        private void btn_JoinClass_Click(object sender, EventArgs e)
        {
            Client.Instance.SendData("instruction=joinclass|code=" + text_JoinCode.Text + "|parent=" + Session.Instance.ParentName);
        }

        private void btn_ViewBroadcastsMenu_Click(object sender, EventArgs e)
        {

        }

        private void btn_MessagesMenu_Click(object sender, EventArgs e)
        {
            frmMessages frm = new frmMessages();

            frm.Show();
        }
    }
}