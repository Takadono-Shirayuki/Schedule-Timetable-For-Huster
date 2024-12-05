namespace Schedule_Timetable_For_Huster
{
    public partial class TimeCoefficient : UserControl
    {
        public struct TimeCoefficientInfo
        {
            public int TimeStart;
            public int TimeEnd;
            public int Coefficient;

            public TimeCoefficientInfo(int TimeStart, int TimeEnd, int Coefficient)
            {
                this.TimeStart = TimeStart;
                this.TimeEnd = TimeEnd;
                this.Coefficient = Coefficient;
            }
        }

        TimeCoefficientInfo timeCoefficientInfo;
        public TimeCoefficientInfo Info
        {
            get { return timeCoefficientInfo; }
        }
        public void SetTime(int TimeStart, int TimeEnd)
        {
            timeCoefficientInfo.TimeStart = TimeStart;
            timeCoefficientInfo.TimeEnd = TimeEnd;
            this.Location = new Point(0, TimeStart - 390);
            this.Height = TimeEnd - TimeStart;
            label1.Text = (TimeStart / 60).ToString("00") + ":" + (TimeStart % 60).ToString("00") + " - " + (TimeEnd / 60).ToString("00") + ":" + (TimeEnd % 60).ToString("00") + "\nCoefficient: ";
            if (timeCoefficientInfo.Coefficient == int.MaxValue)
            {
                label1.Text += "inf";
            }
            else if (timeCoefficientInfo.Coefficient == int.MinValue)
            {
                label1.Text += "-inf";
            }
            else
            {
                label1.Text += timeCoefficientInfo.Coefficient.ToString();
            }
            if (!TimetableSetting3.TimeControlPoiter.ContainsKey(timeCoefficientInfo.TimeStart))
            {
                ((TimetableSetting3)this.FindForm()).AddTime(timeCoefficientInfo.TimeStart);
            }
            if (!TimetableSetting3.TimeControlPoiter.ContainsKey(timeCoefficientInfo.TimeEnd))
            {
                ((TimetableSetting3)this.FindForm()).AddTime(timeCoefficientInfo.TimeEnd);
            }
        }

        int DoW;
        public TimeCoefficient(int DoW)
        {
            InitializeComponent();
            this.DoW = DoW;
        }
        
        public TimeCoefficient(int DoW, TimeCoefficientInfo timeCoefficientInfo)
        {
            InitializeComponent();
            this.DoW = DoW;
            this.timeCoefficientInfo = timeCoefficientInfo;
            SetTime(timeCoefficientInfo.TimeStart, timeCoefficientInfo.TimeEnd);
        }

        private void label1_Click(object sender, EventArgs e)
        {
            SetTime();
        }

        public void SetTime()
        {
            SetTimeCoefficient setTimeCoefficient = new SetTimeCoefficient(timeCoefficientInfo);
            setTimeCoefficient.ShowDialog();
            if (setTimeCoefficient.DialogResult == DialogResult.OK)
            {
                timeCoefficientInfo = setTimeCoefficient.TimeCoefficientInfo;
                if (timeCoefficientInfo.Coefficient == 0)
                {
                    TimetableSetting3.TimeCoefficientControlPoiter[DoW].Remove(this);  
                    Dispose();
                    return;
                }
                SetTime(timeCoefficientInfo.TimeStart, timeCoefficientInfo.TimeEnd);
                bool k1, k2;
                for (int i = 0; i < TimetableSetting3.TimeCoefficientControlPoiter[DoW].Count; i++)
                {
                    if (TimetableSetting3.TimeCoefficientControlPoiter[DoW][i] == this)
                    {
                        continue;
                    }
                    TimeCoefficient timeCoefficient = TimetableSetting3.TimeCoefficientControlPoiter[DoW][i];
                    k1 = timeCoefficient.timeCoefficientInfo.TimeStart >= timeCoefficientInfo.TimeStart && timeCoefficient.timeCoefficientInfo.TimeStart < timeCoefficientInfo.TimeEnd;
                    k2 = timeCoefficient.timeCoefficientInfo.TimeEnd > timeCoefficientInfo.TimeStart && timeCoefficient.timeCoefficientInfo.TimeEnd <= timeCoefficientInfo.TimeEnd;
                    if (k1 && k2)
                    {
                        TimetableSetting3.TimeCoefficientControlPoiter[DoW].Remove(timeCoefficient);
                        i--;
                        timeCoefficient.Dispose();
                        continue;
                    }
                    if (k1)
                    {
                        timeCoefficient.SetTime(timeCoefficient.timeCoefficientInfo.TimeEnd, timeCoefficient.timeCoefficientInfo.TimeEnd);
                    }
                    if (k2)
                    {
                        timeCoefficient.SetTime(timeCoefficient.timeCoefficientInfo.TimeStart, timeCoefficient.timeCoefficientInfo.TimeStart);
                    }
                    if (timeCoefficient.timeCoefficientInfo.TimeStart < timeCoefficientInfo.TimeStart && timeCoefficient.timeCoefficientInfo.TimeEnd > timeCoefficientInfo.TimeEnd)
                    {
                        TimeCoefficientInfo info = new TimeCoefficientInfo(timeCoefficientInfo.TimeEnd, timeCoefficient.timeCoefficientInfo.TimeEnd, timeCoefficient.timeCoefficientInfo.Coefficient);
                        ((TimetableSetting3)this.FindForm()).AddTimeCoefficient(DoW, info);
                        timeCoefficient.SetTime(timeCoefficient.timeCoefficientInfo.TimeStart, timeCoefficientInfo.TimeStart);
                    }
                }
                if (!TimetableSetting3.TimeCoefficientControlPoiter[DoW].Contains(this))
                {
                    TimetableSetting3.TimeCoefficientControlPoiter[DoW].Add(this);
                }
            }
        }
    }
}
