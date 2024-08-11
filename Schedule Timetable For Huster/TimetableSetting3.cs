namespace Schedule_Timetable_For_Huster
{
    public partial class TimetableSetting3 : Form
    {
        public static Dictionary<int, List<TimeCoefficient>> TimeCoefficientControlPoiter = new Dictionary<int, List<TimeCoefficient>>();
        public static Dictionary<int, Time> TimeControlPoiter = new Dictionary<int, Time>();

        public TimetableSetting3(ListBox.ObjectCollection List)
        {
            InitializeComponent();
            listBox1.Items.AddRange(List);
            listBox1.Items.RemoveAt(0);
        }

        private void listBox1_SelectedIndexChanged(object sender, EventArgs e)
        {
            // Show the course code and course name of the selected course
            try
            {
                label1.Text = "Course code: " + listBox1.SelectedItem.ToString();
                label2.Text = "Course name: " + TimetableSetting2.GroupInfo[listBox1.SelectedItem.ToString()].CourseName;
                if (TimetableSetting2.GroupInfo[listBox1.SelectedItem.ToString()].Coefficient == int.MaxValue)
                {
                    comboBox1.Text = "inf";
                }
                else
                {
                    comboBox1.Text = TimetableSetting2.GroupInfo[listBox1.SelectedItem.ToString()].Coefficient.ToString();
                }
                if (TimetableSetting2.GroupInfo[listBox1.SelectedItem.ToString()].Coefficient == int.MaxValue)
                {
                    comboBox1.Text = "inf";
                }
                else
                {
                    comboBox1.Text = TimetableSetting2.GroupInfo[listBox1.SelectedItem.ToString()].Coefficient.ToString();
                }
                comboBox1.Focus();
                comboBox1.SelectAll();
            }
            catch
            {
                label1.Text = "Course code:";
                label2.Text = "Course name:";
                comboBox1.Text = "";
            }
        }

        private void button2_Click(object sender, EventArgs e)
        {
            // Show the help form
            TimetableSetting3Help timetableSetting3Help = new TimetableSetting3Help();
            timetableSetting3Help.ShowDialog();
        }

        /// <summary>
        /// Add a "Time" control to the timetable.
        /// </summary>
        /// <param name="T">The time of the "Time" control.</param>
        public void AddTime(int T)
        {
            // Add a "Time" control to the timetable
            Time time = new Time();
            time.Location = new Point(0, T - 400);
            TimeControlPoiter.Add(T, time);
            time.TimeText = (T / 60).ToString("00") + ":" + (T % 60).ToString("00");
            splitContainer2.Panel1.Controls.Add(time);
        }

        /// <summary>
        /// Add a "TimeCoefficient" control to the timetable.
        /// </summary>
        /// <param name="DoW">The day of week of the "TimeCoefficient" control.</param>
        /// <param name="info">The struct of info of the "TimeCoefficient" control include "Time start", "Time end" and "Coeffictient".</param>
        public void AddTimeCoefficient(int DoW, TimeCoefficient.TimeCoefficientInfo info)
        {
            // Add a "TimeCoefficient" control to the timetable
            TimeCoefficient timeCoefficient = new TimeCoefficient(DoW, info);
            TimeCoefficientControlPoiter[DoW].Add(timeCoefficient);
            switch (DoW)
            {
                case 2:
                    splitContainer3.Panel1.Controls.Add(timeCoefficient);
                    break;
                case 3:
                    splitContainer4.Panel1.Controls.Add(timeCoefficient);
                    break;
                case 4:
                    splitContainer5.Panel1.Controls.Add(timeCoefficient);
                    break;
                case 5:
                    splitContainer6.Panel1.Controls.Add(timeCoefficient);
                    break;
                case 6:
                    splitContainer7.Panel1.Controls.Add(timeCoefficient);
                    break;
                case 7:
                    splitContainer7.Panel2.Controls.Add(timeCoefficient);
                    break;
                default:
                    break;
            }
        }
        private void label8_Click(object sender, EventArgs e)
        {
            // Add a "TimeCoefficient" control of Monday to the timetable
            TimeCoefficient timeCoefficient = new TimeCoefficient(2);
            splitContainer3.Panel1.Controls.Add(timeCoefficient);
            timeCoefficient.SetTime();
        }

        private void label4_Click(object sender, EventArgs e)
        {
            // Add a "TimeCoefficient" control of Tuesday to the timetable
            TimeCoefficient timeCoefficient = new TimeCoefficient(3);
            splitContainer4.Panel1.Controls.Add(timeCoefficient);
            timeCoefficient.SetTime();
        }

        private void label6_Click(object sender, EventArgs e)
        {
            // Add a "TimeCoefficient" control of Wednesday to the timetable
            TimeCoefficient timeCoefficient = new TimeCoefficient(4);
            splitContainer5.Panel1.Controls.Add(timeCoefficient);
            timeCoefficient.SetTime();
        }

        private void label7_Click(object sender, EventArgs e)
        {
            // Add a "TimeCoefficient" control of Thursday to the timetable
            TimeCoefficient timeCoefficient = new TimeCoefficient(5);
            splitContainer6.Panel1.Controls.Add(timeCoefficient);
            timeCoefficient.SetTime();
        }

        private void label9_Click(object sender, EventArgs e)
        {
            // Add a "TimeCoefficient" control of Friday to the timetable
            TimeCoefficient timeCoefficient = new TimeCoefficient(6);
            splitContainer7.Panel1.Controls.Add(timeCoefficient);
            timeCoefficient.SetTime();
        }

        private void label10_Click(object sender, EventArgs e)
        {
            // Add a "TimeCoefficient" control of Saturday to the timetable
            TimeCoefficient timeCoefficient = new TimeCoefficient(7);
            splitContainer7.Panel2.Controls.Add(timeCoefficient);
            timeCoefficient.SetTime();
        }

        private void TimetableSetting3_Load(object sender, EventArgs e)
        {
            try
            {
                // Reset the static dictionaries
                TimeCoefficientControlPoiter = new Dictionary<int, List<TimeCoefficient>>();
                TimeControlPoiter = new Dictionary<int, Time>();

                TimeCoefficientControlPoiter.Add(2, new List<TimeCoefficient>());
                TimeCoefficientControlPoiter.Add(3, new List<TimeCoefficient>());
                TimeCoefficientControlPoiter.Add(4, new List<TimeCoefficient>());
                TimeCoefficientControlPoiter.Add(5, new List<TimeCoefficient>());
                TimeCoefficientControlPoiter.Add(6, new List<TimeCoefficient>());
                TimeCoefficientControlPoiter.Add(7, new List<TimeCoefficient>());
            }
            catch { }
        }

        private void button3_Click(object sender, EventArgs e)
        {
            Result result = new Result();
            Hide();
            result.ShowDialog();
            Show();
        }

        private void comboBox1_TextChanged(object sender, EventArgs e)
        {
            // Save the coefficient of the selected course
            try
            {
                int c1;
                if (comboBox1.Text == "inf")
                {
                    c1 = int.MaxValue;
                }
                else if (int.TryParse(comboBox1.Text, out int a))
                {
                    if (a < 0)
                        c1 = 0;
                    else
                        c1 = a;
                }
                else
                {
                    c1 = 0;
                }
                TimetableSetting2.GroupInfo[label1.Text.Split(": ")[1]].Coefficient = c1;
            }
            catch { }
        }
    }
}
