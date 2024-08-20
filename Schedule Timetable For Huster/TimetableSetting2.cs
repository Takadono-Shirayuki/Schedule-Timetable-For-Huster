using System.Data;
using System.Diagnostics;

namespace Schedule_Timetable_For_Huster
{
    public partial class TimetableSetting2 : Form
    {
        public class Group
        {
            public string CourseName;
            public int Coefficient;
            public string Status;

            public Group(string CourseName)
            {
                this.CourseName = CourseName;
                Coefficient = int.MaxValue;
                Status = "Not Added";
            }
        }

        public static DataTable ClassSource = new DataTable();
        public static Dictionary<string, Group> GroupInfo = new Dictionary<string, Group>();

        public void UpdateGroup(string OldGroup, string NewGroup)
        {
            foreach (var item in listBox1.Items)
            {
                if (item.ToString() == OldGroup)
                {
                    listBox1.Items.Remove(item);
                    listBox1.Items.Add(NewGroup);
                    break;
                }
            }
            foreach (var item in listBox2.Items)
            {
                if (item.ToString() == OldGroup)
                {
                    listBox2.Items.Remove(item);
                    listBox2.Items.Add(NewGroup);
                    break;
                }
            }
        }

        public void AddGroup(string GroupName, string CourseName)
        {
            listBox1.Items.Add(GroupName);
        }

        public void ChangeStatus(string GroupName, string Status)
        {
            if (Status == GroupInfo[GroupName].Status)
                return;
            if (Status == "Not Added")
            {
                listBox2.Items.Remove(GroupName);
                listBox1.Items.Add(GroupName);
            }    
            else
            {
                listBox1.Items.Remove(GroupName);
                listBox2.Items.Add(GroupName);
            }
            GroupInfo[GroupName].Status = Status;
        }
        public TimetableSetting2()
        {
            InitializeComponent();
        }

        private void TimetableSetting2_Load(object sender, EventArgs e)
        {
            // Set the auto-complete source of the textboxes
            AutoCompleteStringCollection collection = new AutoCompleteStringCollection();
            foreach (DataRow dr in Form1.Data.Rows)
            {
                collection.Add(dr[2].ToString());
            }
            textBox1.AutoCompleteCustomSource = collection;
            textBox1.AutoCompleteMode = AutoCompleteMode.SuggestAppend;
            textBox1.AutoCompleteSource = AutoCompleteSource.CustomSource;

            collection = new AutoCompleteStringCollection();
            foreach (DataRow dr in Form1.Data.Rows)
            {
                collection.Add(dr[3].ToString());
            }
            textBox2.AutoCompleteCustomSource = collection;
            textBox2.AutoCompleteMode = AutoCompleteMode.SuggestAppend;
            textBox2.AutoCompleteSource = AutoCompleteSource.CustomSource;

            try
            {
                // Reset the static dictionaries and datatable
                GroupInfo = new Dictionary<string, Group>();

                ClassSource.Columns.Add("Group");
                ClassSource.Columns.Add("Class code");
                ClassSource.Columns.Add("Attached class code");
                ClassSource.Columns.Add("Course code");
                ClassSource.Columns.Add("Course name");
                ClassSource.Columns.Add("Note");
                ClassSource.Columns.Add("Day of week");
                ClassSource.Columns.Add("Time start");
                ClassSource.Columns.Add("Time end");
                ClassSource.Columns.Add("Week");
                ClassSource.Columns.Add("Management code");
                ClassSource.Columns.Add("Coefficient");
                ClassSource.Columns.Add("Status");
            }
            catch { }
        }

        private void AddClassesOfTheCourse()
        {
            string CourseCode = "";
            // Remove the classes of the course(s) that have been added to the list of courses to show in the timetable
            string ManagementCode = "|";
            foreach (Control control in groupBox2.Controls)
            {
                if (((CheckBox)control).Checked)
                {
                    ManagementCode += ((CheckBox)control).Text + "|";
                }
            }
            foreach (DataRow row in DataRows)
            {
                if (row[2].ToString() != CourseCode)
                {
                    CourseCode = row[2].ToString();
                    for (int i = 0; i < ClassSource.Rows.Count; i++)
                    {
                        if (ClassSource.Rows[i][3].ToString() == CourseCode)
                        {
                            ClassSource.Rows.RemoveAt(i);
                            i--;
                        }
                    }
                    if (!listBox1.Items.Contains(CourseCode) && !listBox2.Items.Contains(CourseCode))
                    {
                        listBox1.Items.Add(CourseCode);
                        GroupInfo.Add(CourseCode, new Group(row[3].ToString()));
                    }
                }
            }

            // Add the classes of the course(s) that have been added to the list of courses to show in the timetable
            foreach (DataRow row in DataRows)
            {
                if (ManagementCode.IndexOf("|" + row[8].ToString() + "|") != -1)
                {
                    string time = row[6].ToString();
                    int H = 0;
                    int M = 0;
                    for (int i = 0; i < Form1.Time_Frame_Format.Length; i++)
                    {
                        char c = Form1.Time_Frame_Format[i];
                        if (c == 'H')
                            H = H * 10 + time[i] - '0';
                        else if (c == 'M')
                            M = M * 10 + time[i] - '0';
                    }
                    ClassSource.Rows.Add(row[2], row[0], row[1], row[2], row[3], row[4], row[5], H / 100 * 60 + M / 100, H % 100 * 60 + M % 100, row[7], row[8], 0, "Not Added");
                }
            }
        }


        // Find course info by inputting course code or course name
        DataRow[] DataRows;
        private void GetManagementCode()
        {
            // Get the management code of the course
            int d = 0;
            int p = 7;
            string[] ManagementCode = new string[DataRows.Length];

            groupBox2.Controls.Clear();
            foreach (DataRow dr in DataRows)
            {
                if (ManagementCode.Contains(dr[8].ToString()))
                    continue;
                ManagementCode[d++] = dr[8].ToString();
                CheckBox checkBox = new CheckBox();

                checkBox.AutoSize = true;
                checkBox.Checked = true;
                checkBox.Text = dr[8].ToString();
                int width = TextRenderer.MeasureText(checkBox.Text, this.Font).Width;
                checkBox.Location = new Point(p, 35);
                groupBox2.Controls.Add(checkBox);
                p += width + 30;
            }
        }
        private void textBox1_TextChanged(object sender, EventArgs e)
        {
            // If the textbox is not focused, return. This's used to avoid the error caused by the program itself.
            if (!textBox1.Focused)
                return;

            // Find the course info by course code
            try
            {
                DataRows = Form1.Data.Select("[Course code] = '" + textBox1.Text + "'");
                textBox1.Text = DataRows[0][2].ToString();
                textBox2.Text = DataRows[0][3].ToString();
                GetManagementCode();
            }
            catch { }
        }

        private void textBox2_TextChanged(object sender, EventArgs e)
        {
            // If the textbox is not focused, return. This's used to avoid the error caused by the program itself.
            if (!textBox2.Focused)
                return;

            // Find the course info by course name
            try
            {
                DataRows = Form1.Data.Select("[Course name] = '" + textBox2.Text + "'");
                if (DataRows.Length == 1)
                    textBox1.Text = DataRows[0][2].ToString();
                else
                    textBox1.Text = "";
                textBox2.Text = DataRows[0][3].ToString();
                GetManagementCode();
            }
            catch { }
        }

        private void button1_Click(object sender, EventArgs e)
        {
            // Add the course(s) to the list of courses to show in the timetable
            try
            {
                while (listBox1.SelectedItems.Count > 0)
                {
                    ChangeStatus(listBox1.SelectedItems[0].ToString(), "Added");
                    DataRow[] rows = ClassSource.Select("Group = '" + listBox2.Items[listBox2.Items.Count - 1].ToString() + "'");
                    foreach (DataRow row in rows)
                    {
                        row[12] = "Available";
                    }
                }
            }
            catch { }
        }

        private void button2_Click(object sender, EventArgs e)
        {
            // Remove the course(s) from the list of courses to show in the timetable
            try
            {
                listBox2.SetSelected(0, false);
                while (listBox2.SelectedItems.Count > 0)
                {
                    ChangeStatus(listBox2.SelectedItems[0].ToString(), "Not Added");
                    DataRow[] rows = ClassSource.Select("Group = '" + listBox1.Items[listBox1.Items.Count - 1].ToString() + "'");
                    foreach (DataRow row in rows)
                    {
                        row[12] = "Not Added";
                    }
                }
            }
            catch { }
        }

        private void button3_Click(object sender, EventArgs e)
        {
            // Add all the courses to the list of courses to show in the timetable
            for (int i = 0; i < listBox1.Items.Count; i++)
            {
                listBox1.SetSelected(i, true);
            }
            button1_Click(sender, e);
        }

        private void button4_Click(object sender, EventArgs e)
        {
            // Remove all the courses from the list of courses to show in the timetable
            for (int i = 0; i < listBox2.Items.Count; i++)
            {
                listBox2.SetSelected(i, true);
            }
            button2_Click(sender, e);
        }

        private void button8_Click(object sender, EventArgs e)
        {
            // Remove the course(s) that the program doesn't use to shedule the timetable
            string CourseCode = "|";
            while (listBox1.SelectedItems.Count > 0)
            {
                CourseCode += listBox1.SelectedItems[0].ToString() + "|";
                GroupInfo.Remove(listBox1.SelectedItems[0].ToString());
                listBox1.Items.Remove(listBox1.SelectedItems[0]);
            }
            for (int i = 0; i < ClassSource.Rows.Count; i++)
            {
                if (CourseCode.IndexOf("|" + ClassSource.Rows[i][3].ToString() + "|") != -1)
                {
                    ClassSource.Rows.RemoveAt(i);
                    i--;
                }
            }
        }

        private void button5_Click(object sender, EventArgs e)
        {
            AddClassesOfTheCourse();
            textBox1.Focus();
            textBox1.SelectAll();
        }

        private void button6_Click(object sender, EventArgs e)
        {
            ManageClasses manageClasses = new ManageClasses(this);
            manageClasses.Show();
        }

        private void button9_Click(object sender, EventArgs e)
        {
<<<<<<< Updated upstream
=======
            string NotSatisfiedGroup = "";
            foreach (var item in GroupInfo)
            {
                if (item.Value.Status == "Added")
                {
                    HashSet<String> ClassCode = new HashSet<string>();
                    HashSet<string> AttachedClassCode = new HashSet<string>();
                    DataRow[] rows = ClassSource.Select("Group = '" + item.Key + "' AND Status = 'Available'");
                    foreach (DataRow row in rows)
                    {
                        ClassCode.Add(row[1].ToString());
                        if (row[2].ToString() != "NULL")
                            AttachedClassCode.Add(row[2].ToString());
                    }
                    if (AttachedClassCode.IsSubsetOf(ClassCode))
                        continue;
                    ChangeStatus(item.Key, "Not Added");
                    rows = ClassSource.Select("Group = '" + item.Key + "'");
                    foreach (DataRow row in rows)
                    {
                        row[12] = "Not Added";
                    }
                    NotSatisfiedGroup += item.Key + "\n";
                }
            }
            if (NotSatisfiedGroup != "")
                if (MessageBox.Show("The following groups are not satisfied:\n" + NotSatisfiedGroup + "Continue? The program will skip the \"Not satisfied\" groups.", "Warning", MessageBoxButtons.YesNo, MessageBoxIcon.Warning) == DialogResult.No)
                    return;
>>>>>>> Stashed changes
            TimetableSetting3 timetableSetting3 = new TimetableSetting3(listBox2.Items);
            this.Hide();
            timetableSetting3.ShowDialog();
            this.Show();
        }

        private void AddClass(DataRow row)
        {
            Class @class = new Class();
            @class.Data = row;
            int DoW = Convert.ToInt32(row[6].ToString());
            switch (DoW)
            {
                case 2:
                    splitContainer3.Panel1.Controls.Add(@class);
                    break;
                case 3:
                    splitContainer4.Panel1.Controls.Add(@class);
                    break;
                case 4:
                    splitContainer5.Panel1.Controls.Add(@class);
                    break;
                case 5:
                    splitContainer6.Panel1.Controls.Add(@class);
                    break;
                case 6:
                    splitContainer7.Panel1.Controls.Add(@class);
                    break;
                case 7:
                    splitContainer7.Panel2.Controls.Add(@class);
                    break;
                default:
                    break;
            }
            if (splitContainer2.Panel1.Controls.ContainsKey("T" + row[7].ToString()) == false)
            {
                Time time = new Time();
                time.Location = new Point(0, (Convert.ToInt32(row[7].ToString()) - 390) * 5 / 4 - 10);
                time.TimeText = (Convert.ToInt32(row[7].ToString()) / 60).ToString("00") + ":" + (Convert.ToInt32(row[7].ToString()) % 60).ToString("00");
                time.Name = "T" + row[7].ToString();
                splitContainer2.Panel1.Controls.Add(time);
            }
            if (splitContainer2.Panel1.Controls.ContainsKey("T" + row[8].ToString()) == false)
            {
                Time time = new Time();
                time.Location = new Point(0, (Convert.ToInt32(row[8].ToString()) - 390) * 5 / 4 - 10);
                time.TimeText = (Convert.ToInt32(row[8].ToString()) / 60).ToString("00") + ":" + (Convert.ToInt32(row[8].ToString()) % 60).ToString("00");
                time.Name = "T" + row[8].ToString();
                splitContainer2.Panel1.Controls.Add(time);
            }
        }
        private void listBox2_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (listBox2.SelectedIndex == -1)
                return;
            splitContainer2.Panel1.Controls.Clear();
            splitContainer3.Panel1.Controls.Clear();
            splitContainer4.Panel1.Controls.Clear();
            splitContainer5.Panel1.Controls.Clear();
            splitContainer6.Panel1.Controls.Clear();
            splitContainer7.Panel1.Controls.Clear();
            splitContainer7.Panel2.Controls.Clear();
            
            if (listBox2.SelectedIndex == 0)
            {
                foreach (DataRow row in ClassSource.Rows)
                    if (row[12].ToString() != "Not Added")
                        AddClass(row);
                return;
            }
            foreach (DataRow row in ClassSource.Rows)
                if (row[0].ToString() == listBox2.SelectedItem.ToString() && row[12].ToString() != "Not Added")
                    AddClass(row);
        }
    }
}
