using System.Configuration;
using System.Data;
using System.Text;

namespace Schedule_Timetable_For_Huster
{
    public partial class Result : Form
    {
        List<HashSet<string>> Results = new List<HashSet<string>>();
        List<int> Points = new List<int>();
        List<int> Order = new List<int>();

        int Number = 0;
        // ClassInfo stores the information of the classes which have the same course code. 
        Dictionary<string, DataRow[]> ClassInfo = new Dictionary<string, DataRow[]>();

        // InfCourse stores the information of the courses which have the bonus coefficient of inf. 
        Dictionary<string, TimetableSetting2.Course> InfCourse = new Dictionary<string, TimetableSetting2.Course>();
        // Course stores the information of the courses which have the bonus coefficient of not inf.
        Dictionary<string, TimetableSetting2.Course> FinityCourse = new Dictionary<string, TimetableSetting2.Course>();

        // StopFlag is used to control the access of the task.
        Boolean StopFlag = false;

        // CancelFlag is used to control the cancel of the task.
        Boolean CancelFlag = false;

        public Result()
        {
            InitializeComponent();
        }

        private void Result_Load(object sender, EventArgs e)
        {
            foreach (DataRow row in TimetableSetting2.ClassSource.Rows)
            {
                if (!ClassInfo.ContainsKey(row[2].ToString()))
                {
                    ClassInfo.Add(row[2].ToString(), TimetableSetting2.ClassSource.Select("[Course code] = '" + row[2].ToString() + "'"));
                }
                if (Convert.ToInt32(row[8]) == int.MaxValue)
                {
                    foreach (DataRow row2 in ClassInfo[row[2].ToString()])
                    {
                        if (Convert.ToInt32(row2[8]) != int.MaxValue)
                        {
                            row2[9] = "Eliminated";
                        }
                    }
                }
            }
            for (int i = 0; i < TimetableSetting2.Courseinfo.Count; i++)
            {
                string Key = TimetableSetting2.Courseinfo.ElementAt(i).Key;
                TimetableSetting2.Course course = TimetableSetting2.Courseinfo.ElementAt(i).Value;
                if (course.Coefficient == int.MaxValue)
                {
                    InfCourse.Add(Key, course);
                }
                else
                {
                    FinityCourse.Add(Key, course);
                }
            }
            
            Task.Run(() => ScheduleTimetable());
            Task.Run(() => ScheduleTimetable());
            Task.Run(() => ScheduleTimetable());
            Task.Run(() => ScheduleTimetable());
            Task.Run(() => ScheduleTimetable());
            Task.Run(() => ScheduleTimetable());
            Task.Run(() => ScheduleTimetable());
            Task.Run(() => ScheduleTimetable());
            Task.Run(() => ScheduleTimetable());
            Task.Run(() => ScheduleTimetable());
            Task.Run(() => ScheduleTimetable());
            Task.Run(() => ScheduleTimetable());
            Task.Run(() => ScheduleTimetable());
            Task.Run(() => ScheduleTimetable());
            Task.Run(() => ScheduleTimetable());
            Task.Run(() => ScheduleTimetable());
            Task.Run(() => ScheduleTimetable());
            Task.Run(() => ScheduleTimetable());
            Task.Run(() => ScheduleTimetable());
            Task.Run(() => ScheduleTimetable());
        }

        private async Task ScheduleTimetable()
        {
            // Schedule the timetable.
            // The result is stored in the result list.
            // The count is the number of the scheduled timetable.

            int[] RadomInfCourse = new int[InfCourse.Count];
            int[] RandomFinityCourse = new int[FinityCourse.Count];
            for (int i = 0; i < InfCourse.Count; i++)
            {
                RadomInfCourse[i] = i;
            }
            for (int i = 0; i < FinityCourse.Count; i++)
            {
                RandomFinityCourse[i] = i;
            }

            while (!CancelFlag)
            {
                string result = "";
                int Point = 0;

                List<int>[] TimeStart = new List<int>[8];
                List<int>[] TimeEnd = new List<int>[8];
                for (int i = 2; i < 8; i++)
                {
                    TimeStart[i] = new List<int>();
                    TimeEnd[i] = new List<int>();
                }

                // Intialize the random order of the courses.
                RadomInfCourse = RadomInfCourse.OrderBy(a => Guid.NewGuid()).ToArray();
                RandomFinityCourse = RandomFinityCourse.OrderBy(a => Guid.NewGuid()).ToArray();
                Dictionary<string, TimetableSetting2.Course> Course = new Dictionary<string, TimetableSetting2.Course>();
                foreach (int i in RadomInfCourse)
                {
                    Course.Add(InfCourse.ElementAt(i).Key, InfCourse.ElementAt(i).Value);
                }
                foreach (int i in RandomFinityCourse)
                {
                    Course.Add(FinityCourse.ElementAt(i).Key, FinityCourse.ElementAt(i).Value);
                }

                for (int i = 0; i < Course.Count; i++)
                {
                    // Intialize the random order of the classes
                    TimetableSetting2.Course course = Course.ElementAt(i).Value;
                    string Key = Course.ElementAt(i).Key;
                    int[] RandomClass = new int[ClassInfo[Key].Length];
                    for (int j = 0; j < RandomClass.Length; j++)
                    {
                        RandomClass[j] = j;
                    }
                    RandomClass = RandomClass.OrderBy(a => Guid.NewGuid()).ToArray();

                    for (int j = 0; j < RandomClass.Length; j++)
                    {
                        // Get the class information. Skip the class if the class is not available. 
                        DataRow Class = ClassInfo[Key][RandomClass[j]];
                        if (Class[1].ToString() == "NULL")
                            continue;
                        if (Class[9].ToString() == "Eliminated")
                            continue;
                        // Get the lessons of the class.
                        List<DataRow> Lesson = new List<DataRow>();
                        for (int k = 0; k < RandomClass.Length; k++)
                        {
                            if ((ClassInfo[Key][k][0].ToString() == Class[0].ToString()) || (ClassInfo[Key][k][0].ToString() == Class[1].ToString()))
                            {
                                if (ClassInfo[Key][k][9].ToString() == "Eliminated")
                                {
                                    goto NextClass;
                                }
                                Lesson.Add(ClassInfo[Key][k]);
                            }
                        }

                        // Check if the class's time frame is available.
                        int PointTemp = 0;
                        foreach (DataRow row in Lesson)
                        {
                            int DoW = Convert.ToInt32(row[4]);
                            int T1, T2;
                            T1 = Convert.ToInt32(row[5]);
                            T2 = Convert.ToInt32(row[6]);
                            for (int k = 0; k < TimeStart[DoW].Count; k++)
                            {
                                // if time conflict, skip the class.
                                if ((TimeStart[DoW][k] <= T1 && TimeEnd[DoW][k] >= T1) || (TimeStart[DoW][k] <= T2 && TimeEnd[DoW][k] >= T2) || (TimeStart[DoW][k] >= T1 && TimeEnd[DoW][k] <= T2))
                                {
                                    goto NextClass;
                                }
                            }
                            for (int k = 0; k < TimetableSetting3.TimeCoefficientControlPoiter[DoW].Count; k++)
                            {
                                TimeCoefficient.TimeCoefficientInfo Info = TimetableSetting3.TimeCoefficientControlPoiter[DoW][k].Info;
                                if ((Info.TimeStart < T1 && Info.TimeEnd > T1) || (Info.TimeStart < T2 && Info.TimeEnd > T2) || (Info.TimeStart >= T1 && Info.TimeEnd <= T2))
                                {
                                    if (Info.Coefficient == int.MaxValue)
                                    {
                                        goto NextClass;
                                    }
                                    else
                                    {
                                        PointTemp += Info.Coefficient;
                                    }
                                }
                            }
                        }

                        // Add the class to the result.
                        foreach (DataRow row in Lesson)
                        {
                            int DoW = Convert.ToInt32(row[4]);
                            int T1, T2;
                            T1 = Convert.ToInt32(row[5]);
                            T2 = Convert.ToInt32(row[6]);
                            TimeStart[DoW].Add(T1);
                            TimeEnd[DoW].Add(T2);
                            if (Convert.ToInt32(row[8]) != int.MaxValue)
                                Point += Convert.ToInt32(row[8]);
                        }
                        result += "|" + Class[0].ToString() + "|" + Class[1].ToString();
                        if (i >= InfCourse.Count)
                            Point += course.Coefficient;
                        Point -= PointTemp;
                        goto NextCourse;
                    NextClass:;
                    }
                    // If there're no available classes of the course has inf coefficient, skip the course.
                    if (i < InfCourse.Count)
                        goto NextResult;
                    NextCourse:;
                }

                // Check if the result is already in the list.
                HashSet<string> HS = new HashSet<string>(result.Substring(1).Split('|'));
                foreach (HashSet<string> hs in Results)
                {
                    // If the result is already in the list, skip the result.
                    if (HS.SetEquals(hs))
                    {
                        goto NextResult;
                    }
                }
                Results.Add(HS);
                Order.Add(Results.Count);
                Points.Add(Point);
                label2.BeginInvoke(new Action(() => label2.Text = "Number: " + Number.ToString() + "/" + Results.Count.ToString()));
            NextResult:
                while (StopFlag)
                {
                    await Task.Delay(100);
                }
            }
        }

        private void ShowTimetable()
        {
            List<int> TimeList = new List<int>();
            splitContainer2.Panel1.Controls.Clear();
            splitContainer3.Panel1.Controls.Clear();
            splitContainer4.Panel1.Controls.Clear();
            splitContainer5.Panel1.Controls.Clear();
            splitContainer6.Panel1.Controls.Clear();
            splitContainer7.Panel1.Controls.Clear();
            splitContainer7.Panel2.Controls.Clear();

            StringBuilder ClassCodesSB = new StringBuilder("|");
            foreach (string ClassCode in Results[Order[Number - 1] - 1])
            {
                ClassCodesSB.Append(ClassCode + "|");
            }
            string ClassCodes = ClassCodesSB.ToString();
            foreach (DataRow row in TimetableSetting2.ClassSource.Rows)
            {
                if (ClassCodes.Contains("|" + row[0].ToString() + "|"))
                {
                    int DoW = Convert.ToInt32(row[4]);
                    if (!TimeList.Contains(Convert.ToInt32(row[5])))
                    {
                        TimeList.Add(Convert.ToInt32(row[5]));
                        Time time = new Time();
                        time.Location = new Point(0, Convert.ToInt32(row[5]) - 400);
                        time.TimeText = (Convert.ToInt32(row[5]) / 60).ToString("00") + ":" + (Convert.ToInt32(row[5]) % 60).ToString("00");
                        splitContainer2.Panel1.Controls.Add(time);
                    }
                    if (!TimeList.Contains(Convert.ToInt32(row[6])))
                    {
                        TimeList.Add(Convert.ToInt32(row[6]));
                        Time time = new Time();
                        time.Location = new Point(0, Convert.ToInt32(row[6]) - 400);
                        time.TimeText = (Convert.ToInt32(row[6]) / 60).ToString("00") + ":" + (Convert.ToInt32(row[6]) % 60).ToString("00");
                        splitContainer2.Panel1.Controls.Add(time);
                    }
                    switch (DoW)
                    {
                        case 2:
                            splitContainer3.Panel1.Controls.Add(new ResultClass(row));
                            break;
                        case 3:
                            splitContainer4.Panel1.Controls.Add(new ResultClass(row));
                            break;
                        case 4:
                            splitContainer5.Panel1.Controls.Add(new ResultClass(row));
                            break;
                        case 5:
                            splitContainer6.Panel1.Controls.Add(new ResultClass(row));
                            break;
                        case 6:
                            splitContainer7.Panel1.Controls.Add(new ResultClass(row));
                            break;
                        case 7:
                            splitContainer7.Panel2.Controls.Add(new ResultClass(row));
                            break;
                        default:
                            break;
                    }
                }
            }
        }
        private void button1_Click(object sender, EventArgs e)
        {
            if (Number > 1)
                Number--;
            else
                return;
            label2.Text = "Number: " + Number.ToString() + "/" + Results.Count.ToString();
            label1.Text = "Point: " + Points[Order[Number - 1] - 1].ToString();
            ShowTimetable();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            if (Number < Results.Count)
                Number++;
            else
                return;
            label2.Text = "Number: " + Number.ToString() + "/" + Results.Count.ToString();
            label1.Text = "Point: " + Points[Order[Number - 1] - 1].ToString();
            ShowTimetable();
        }

        private void button3_Click(object sender, EventArgs e)
        {
            SaveFileDialog saveFileDialog = new SaveFileDialog();
            saveFileDialog.FileName = "";
            saveFileDialog.Title = "Save the result";
            saveFileDialog.Filter = "Text files (*.txt)|*.txt";
            saveFileDialog.FilterIndex = 1;
            saveFileDialog.RestoreDirectory = true;
            if (saveFileDialog.ShowDialog() == DialogResult.OK)
            {
                using (StreamWriter sw = new StreamWriter(saveFileDialog.FileName))
                {
                    sw.WriteLine("Number: " + Number.ToString() + "/" + Results.Count.ToString());
                    sw.WriteLine("Point: " + Points[Order[Number - 1] - 1].ToString());
                    sw.WriteLine("Result: ");
                    foreach (string ClassCode in Results[Order[Number - 1] - 1])
                    {
                        sw.WriteLine(ClassCode);
                    }
                }
            }
        }

        private void button4_Click(object sender, EventArgs e)
        {
            if (button4.Text == "Pause")
            {
                StopFlag = true;
                button4.Text = "Continue";
                button5.Enabled = true;
            }
            else
            {
                StopFlag = false;
                button4.Text = "Pause";
                button5.Enabled = false;
            }
        }

        private void button5_Click(object sender, EventArgs e)
        {
            int Quality = Points.Count;
            for (int i = 0; i < Quality - 1; i++)
                for (int j = i + 1; j < Quality; j++)
                    if (Points[Order[i] - 1] < Points[Order[j] - 1])
                    {
                        int Temp = Order[i];
                        Order[i] = Order[j];
                        Order[j] = Temp;
                    }
            Number = 1;
            label2.Text = "Number: " + Number.ToString() + "/" + Results.Count.ToString();
            label1.Text = "Point: " + Points[Order[Number - 1] - 1].ToString();
            ShowTimetable();
        }

        private void button6_Click(object sender, EventArgs e)
        {
            ResultHelp resultHelp = new ResultHelp();
            resultHelp.ShowDialog();
        }

        private void button7_Click(object sender, EventArgs e)
        {
            if (int.TryParse(textBox1.Text, out int a))
            {
                if (a < 1)
                    a = 1;
                else if (a > Results.Count)
                    a = Results.Count;
                Number = a;
                label2.Text = "Number: " + Number.ToString() + "/" + Results.Count.ToString();
                label1.Text = "Point: " + Points[Order[Number - 1] - 1].ToString();
                ShowTimetable();
            }    
        }
    }
}
