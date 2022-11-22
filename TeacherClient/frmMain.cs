namespace TeacherClient
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
        }

        private void btn_ViewClassesMenu_Click(object sender, EventArgs e)
        {
            HidePanels();

            UpdateClassTable();
            cbo_SortBy.SelectedIndex = 0;

            panel_ClassList.Visible = true;
        }

        private void btn_BroadcastsMenu_Click(object sender, EventArgs e)
        {

        }

        private void btn_MessagesMenu_Click(object sender, EventArgs e)
        {
            frmMessages frm = new frmMessages();
            frm.Show();
        }

        private void cbo_SortBy_SelectedIndexChanged(object sender, EventArgs e)
        {
            switch (cbo_SortBy.SelectedIndex)
            {
                case 0:
                    UpdateClassTable("name");
                    break;
                case 1:
                    UpdateClassTable("date");
                    break;
                case 2:
                    UpdateClassTable("students");
                    break;
                default:
                    UpdateClassTable();
                    break;
            }
        }

        private void UpdateClassTable(string SortType = "name")
        {
            foreach (Label ClassTableControl in panel_ClassTable.Controls.OfType<Label>().ToList())
            {
                panel_ClassTable.Controls.Remove(ClassTableControl);
                ClassTableControl.Dispose();
            }
            foreach (Button ClassTableControl in panel_ClassTable.Controls.OfType<Button>().ToList())
            {
                panel_ClassTable.Controls.Remove(ClassTableControl);
                ClassTableControl.Dispose();
            }
            panel_ClassTable.RowStyles.Clear();

            panel_ClassTable.RowCount = 0;
            List<string> Classes = Client.Instance.SendData("instruction=teacherclasses|sort=" + SortType + "|teacher=" + Session.Instance.TeacherName);

            panel_ClassTable.RowCount = Classes.Count - 1;
            for (int i = 1; i < Classes.Count; i++)
            {
                string ClassName = Classes[i].Split("|")[0];
                string ClassDate = Classes[i].Split("|")[1];
                string StudentCount = Classes[i].Split("|")[2];

                Label ClassNameLabel = new Label();
                ClassNameLabel.Text = ClassName;
                panel_ClassTable.Controls.Add(ClassNameLabel, 0, i - 1);

                Label ClassDateLabel = new Label();
                ClassDateLabel.Text = ClassDate;
                panel_ClassTable.Controls.Add(ClassDateLabel, 1, i - 1);

                Label ClassStudentCountLabel = new Label();
                ClassStudentCountLabel.Text = StudentCount;
                panel_ClassTable.Controls.Add(ClassStudentCountLabel, 2, i - 1);

                Button ClassEditButton = new Button();
                ClassEditButton.Text = "Edit";
                panel_ClassTable.Controls.Add(ClassEditButton, 3, i - 1);

                panel_ClassTable.RowStyles.Add(new RowStyle(SizeType.Absolute, 30));
            }
        }

        private void btn_NewClass_Click(object sender, EventArgs e)
        {
            frmNewClass frm = new frmNewClass();

            frm.ShowDialog();

            UpdateClassTable();
        }
    }
}