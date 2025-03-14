using System.Data;

namespace Schedule_Timetable_For_Huster
{
    public partial class TimetableSetting2 : Form
    {
        public class Course
        {
            public string CourseName;
            public int Coefficient;
            
            public Course(string CourseName)
            {
                this.CourseName = CourseName;
                Coefficient = int.MaxValue;
            }
        }

        DataTable Classes = new DataTable();
        public static DataTable ClassSource = new DataTable();
        public static Dictionary<string, List<Class>> ClassControlPoiter = new Dictionary<string, List<Class>>();   
        public static Dictionary<string, Time> TimeControlPoiter = new Dictionary<string, Time>();
        public static Dictionary<string, Course> Courseinfo = new Dictionary<string, Course>(); 

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

            // Initialize the datatable
            Classes.Columns.Add("Class code");
            Classes.Columns.Add("Attached class code");
            Classes.Columns.Add("Course code");
            Classes.Columns.Add("Course name");
            Classes.Columns.Add("Note");
            Classes.Columns.Add("Day of week");
            Classes.Columns.Add("Time frame");
            Classes.Columns.Add("Week");
            Classes.Columns.Add("Management code");

            try
            {
                // Reset the static dictionaries and datatable
                ClassControlPoiter = new Dictionary<string, List<Class>>();
                TimeControlPoiter = new Dictionary<string, Time>();
                Courseinfo = new Dictionary<string, Course>();
                
                ClassSource.Clear();
                ClassSource.Columns.Add("Class code");
                ClassSource.Columns.Add("Attached class code");
                ClassSource.Columns.Add("Course code");
                ClassSource.Columns.Add("Course name");
                ClassSource.Columns.Add("Day of week");
                ClassSource.Columns.Add("Time start");
                ClassSource.Columns.Add("Time end");
                ClassSource.Columns.Add("Week");
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
                    for (int i = 0; i < Classes.Rows.Count; i++)
                    {
                        if (Classes.Rows[i][2].ToString() == CourseCode)
                        {
                            Classes.Rows.RemoveAt(i);
                            i--;
                        }
                    }
                    if (!listBox1.Items.Contains(CourseCode) && !listBox2.Items.Contains(CourseCode))
                    {
                        listBox1.Items.Add(CourseCode);
                        Courseinfo.Add(CourseCode, new Course(row[3].ToString()));
                    }
                }
            }

            // Add the classes of the course(s) that have been added to the list of courses to show in the timetable
            foreach (DataRow row in DataRows)
            {
                if (ManagementCode.IndexOf("|" + row[8].ToString() + "|") != -1)
                    Classes.Rows.Add(row.ItemArray);
            }
        }

        private void DeleteClassesOfTheCourse()
        {
            // Remove the classes of the course(s) that have been removed from the list of courses to show in the timetable
            string CourseCode = "|";
            while (listBox1.SelectedItems.Count > 0)
            {
                CourseCode += listBox1.SelectedItems[0].ToString() + "|";
                Courseinfo.Remove(listBox1.SelectedItems[0].ToString());
                listBox1.Items.Remove(listBox1.SelectedItems[0]);
            }
            for (int i = 0; i < Classes.Rows.Count; i++)
            {
                if (CourseCode.IndexOf("|" + Classes.Rows[i][2].ToString() + "|") != -1)
                {
                    Classes.Rows.RemoveAt(i);
                    i--;
                }
            }
        }

        private void LoadClassesOfTheCourse()
        {
            // Display the classes of the course(s) that have been added to the list of courses to show in the timetable
            while (listBox1.SelectedItems.Count > 0)
            {
                ClassControlPoiter.Add(listBox1.SelectedItems[0].ToString(), new List<Class>());
                foreach (DataRow row in Classes.Rows)
                {
                    if (row[2].ToString() == listBox1.SelectedItems[0].ToString())
                    {
                        Class @class = new Class();
                        @class.Data = row;
                        int dow = int.Parse(row[5].ToString());
                        ClassControlPoiter[listBox1.SelectedItems[0].ToString()].Add(@class);   
                        switch (dow)
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
                        }
                        if (!TimeControlPoiter.ContainsKey((@class.H / 100).ToString() + (@class.M / 100).ToString()))
                        {
                            Time time = new Time();
                            time.Location = new Point(0, (60 * (@class.H / 100 - 6) + @class.M / 100 - 30) * 5 / 4 - 10);
                            TimeControlPoiter.Add((@class.H / 100).ToString() + (@class.M / 100).ToString(), time);
                            time.TimeText = (@class.H / 100).ToString("00") + ":" + (@class.M / 100).ToString("00");
                            splitContainer2.Panel1.Controls.Add(time);
                        }
                        if (!TimeControlPoiter.ContainsKey((@class.H % 100).ToString() + (@class.M % 100).ToString()))
                        {
                            Time time = new Time();
                            time.Location = new Point(0, (60 * (@class.H % 100 - 6) + @class.M % 100 - 30) * 5 / 4 - 10);
                            TimeControlPoiter.Add((@class.H % 100).ToString() + (@class.M % 100).ToString(), time);
                            time.TimeText = (@class.H % 100).ToString("00") + ":" + (@class.M % 100).ToString("00");
                            splitContainer2.Panel1.Controls.Add(time);
                        }
                    }
                }
                listBox2.Items.Add(listBox1.SelectedItems[0]);
                listBox1.Items.Remove(listBox1.SelectedItems[0]);
            }
        }

        private void ReloadClassesOfTheCourse()
        {
            // Reload the classes of the selected course(s)
            foreach (object item in listBox2.SelectedItems)
            {
                for (int i = 0; i < ClassControlPoiter[item.ToString()].Count; i++)
                {
                    ClassControlPoiter[item.ToString()][i].Dispose();
                }
                ClassControlPoiter.Remove(item.ToString());
                
                ClassControlPoiter.Add(item.ToString(), new List<Class>()); 
                foreach (DataRow row in Classes.Rows)
                {
                    if (row[2].ToString() == item.ToString())
                    {
                        Class @class = new Class();
                        @class.Data = row;
                        ClassControlPoiter[row[2].ToString()].Add(@class);
                        int dow = int.Parse(row[5].ToString());
                        switch (dow)
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
                        }
                    }
                }
            }
        }

        private void UnloadClassesOfTheCourse()
        {
            // Unload the classes of the course(s) that have been removed from the list of courses to show in the timetable
            while (listBox2.SelectedItems.Count > 0)
            {
                for (int i = 0; i < ClassControlPoiter[listBox2.SelectedItems[0].ToString()].Count; i++)
                {
                    ClassControlPoiter[listBox2.SelectedItems[0].ToString()][i].Dispose();
                }
                ClassControlPoiter.Remove(listBox2.SelectedItems[0].ToString());
                listBox1.Items.Add(listBox2.SelectedItems[0]);
                listBox2.Items.Remove(listBox2.SelectedItems[0]);
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
                LoadClassesOfTheCourse();
            }
            catch { }
        }

        private void button2_Click(object sender, EventArgs e)
        {
            // Remove the course(s) from the list of courses to show in the timetable
            try
            {
                UnloadClassesOfTheCourse();
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
            DeleteClassesOfTheCourse();
        }

        private void button7_Click(object sender, EventArgs e)
        {
            // Reload the classes of the course
            try
            {
                ReloadClassesOfTheCourse();
            }
            catch { }
        }

        private void button5_Click(object sender, EventArgs e)
        {
            AddClassesOfTheCourse();
            textBox1.Focus();
            textBox1.SelectAll();
        }

        private void button6_Click(object sender, EventArgs e)
        {
            ClassSource.Rows.Clear();
            foreach (var item in ClassControlPoiter)
            {
                foreach (Class @class in item.Value)
                {
                    DataRow row = @class.Data;
                    ClassSource.Rows.Add(row[0], row[1], row[2], row[3], row[5], @class.H / 100 * 60 + @class.M / 100, @class.H % 100 * 60 + @class.M % 100, row[7], @class.Coefficient, @class.Status);
                }
            }
            TimetableSetting3 timetableSetting3 = new TimetableSetting3(listBox2.Items);
            this.Hide();
            timetableSetting3.ShowDialog();
            this.Show();
        }
    }
}
