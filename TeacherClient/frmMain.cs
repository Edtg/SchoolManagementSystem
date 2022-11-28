using System.Globalization;

namespace TeacherClient
{
    public partial class frmMain : Form
    {
        private string EditingClassName = "";

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
            panel_Broadcasts.Visible = false;
            panel_EditClass.Visible = false;
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
            HidePanels();

            UpdateBroadcastsPanel();

            panel_Broadcasts.Visible = true;
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

            panel_ClassTable.RowCount = Classes.Count;
            for (int i = 0; i < Classes.Count; i++)
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
                ClassEditButton.Click += (sender, EventArgs) => { ShowClassEdit(sender, EventArgs, ClassName); };
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

        private void ShowClassEdit(object sender, EventArgs e, string ClassName)
        {
            EditingClassName = ClassName;
            text_EditClassName.Text = ClassName;

            string EditingClass = Client.Instance.SendData("instruction=getclass|classname=" + ClassName)[0];
            if (EditingClass.Equals(""))
            {
                return;
            }
            date_EditStartDate.Value = DateTime.ParseExact(EditingClass.Split("|")[1], "yyyyMMdd:HH:mm:ss", CultureInfo.InvariantCulture);
            date_EditEndDate.Value = DateTime.ParseExact(EditingClass.Split("|")[2], "yyyyMMdd:HH:mm:ss", CultureInfo.InvariantCulture);
            text_EditJoinCode.Text = EditingClass.Split("|")[3];

            HidePanels();

            panel_EditClass.Visible = true;
        }

        private void btn_SaveClassEdit_Click(object sender, EventArgs e)
        {
            string UpdateClassRequest = "instruction=updateclass";
            UpdateClassRequest += "|classname=" + EditingClassName;
            UpdateClassRequest += "|name=" + text_EditClassName.Text;
            DateTime ClassStartDate = date_EditStartDate.Value;
            UpdateClassRequest += "|year=" + ClassStartDate.Year.ToString() + "|month=" + ClassStartDate.Month.ToString() + "|day=" + ClassStartDate.Day.ToString();
            DateTime ClassEndDate = date_EditEndDate.Value;
            UpdateClassRequest += "|endyear=" + ClassEndDate.Year.ToString() + "|endmonth=" + ClassEndDate.Month.ToString() + "|endday=" + ClassEndDate.Day.ToString();
            UpdateClassRequest += "|code=" + text_EditJoinCode.Text;

            Client.Instance.SendData(UpdateClassRequest);
        }

        private void btn_SetDate_Click(object sender, EventArgs e)
        {
            Client.Instance.SendData("instruction=setsimulateddate|date=" + date_SimulationDate.Value.ToString("yyyyMMdd:HH:mm:ss"));
        }

        private void UpdateBroadcastsPanel()
        {
            List<string> Classes = Client.Instance.SendData("instruction=teacherclasses|sort=name|teacher=" + Session.Instance.TeacherName);

            if (Classes.Count > 0)
            {
                foreach (string Class in Classes)
                {
                    cbo_BroadcastReceiver.Items.Add(Class.Split("|")[0]);
                }
                cbo_BroadcastReceiver.SelectedIndex = 0;
            }
        }

        private void btn_SendBroadcast_Click(object sender, EventArgs e)
        {
            Client.Instance.SendData("instruction=sendbroadcast|sender=" + Session.Instance.TeacherName + "|classname=" + cbo_BroadcastReceiver.SelectedItem.ToString() + "|content=" + text_Broadcast.Text);
        }
    }
}