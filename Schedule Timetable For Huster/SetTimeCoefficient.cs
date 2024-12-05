namespace Schedule_Timetable_For_Huster
{
    public partial class SetTimeCoefficient : Form
    {
        public TimeCoefficient.TimeCoefficientInfo TimeCoefficientInfo
        {
            get
            {
                TimeCoefficient.TimeCoefficientInfo result = new TimeCoefficient.TimeCoefficientInfo();
                int H1, H2, M1, M2;
                string T1, T2;
                T1 = dateTimePicker1.Value.ToString("HH:mm");
                T2 = dateTimePicker2.Value.ToString("HH:mm");
                H1 = int.Parse(T1.Split(':')[0]);
                M1 = int.Parse(T1.Split(':')[1]);
                H2 = int.Parse(T2.Split(':')[0]);
                M2 = int.Parse(T2.Split(':')[1]);
                result.TimeStart = H1 * 60 + M1;
                result.TimeEnd = H2 * 60 + M2;
                if (comboBox1.Text == "inf")
                {
                    result.Coefficient = int.MaxValue;
                }
                else if (comboBox1.Text == "-inf")
                {
                    result.Coefficient = int.MinValue;
                }
                else if (int.TryParse(comboBox1.Text, out int a))
                {
                    result.Coefficient = a;
                }
                else
                {
                    result.Coefficient = 0;
                }
                return result;
            }
        }

        public SetTimeCoefficient(TimeCoefficient.TimeCoefficientInfo info)
        {
            InitializeComponent();
            int H1, H2, M1, M2;
            H1 = info.TimeStart / 60;
            M1 = info.TimeStart % 60;
            H2 = info.TimeEnd / 60;
            M2 = info.TimeEnd % 60;
            dateTimePicker1.Value = new DateTime(2000, 1, 1, H1, M1, 0);
            dateTimePicker2.Value = new DateTime(2000, 1, 1, H2, M2, 0);
            if (info.Coefficient == int.MaxValue)
            {
                comboBox1.Text = "inf";
            }
            else if (info.Coefficient == int.MinValue)
            {
                comboBox1.Text = "-inf";
            }
            else
            {
                comboBox1.Text = info.Coefficient.ToString();
            }
        }

        private void button1_Click(object sender, EventArgs e)
        {
            this.DialogResult = DialogResult.OK;
            this.Close();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            this.DialogResult = DialogResult.Cancel;
            this.Close();
        }

        private void SetTimeCoefficient_Load(object sender, EventArgs e)
        {

        }
    }
}
