using System.Data;

namespace Schedule_Timetable_For_Huster
{
    public partial class ClassInfo : Form
    {
        public int Coefficient
        {
            get
            {
                if (label10.Text.Split(' ')[1] == "inf")
                {
                    return int.MaxValue;
                }
                else
                {
                    return int.Parse(label10.Text.Split(' ')[1]);
                }
            }
        }
        public string Status
        {
            get
            {
                return label11.Text.Split(' ')[1];
            }
        }

        public ClassInfo(DataRow data)
        {
            InitializeComponent();
            int TimeStart = Convert.ToInt32(data[7].ToString());
            int TimeEnd = Convert.ToInt32(data[8].ToString());
            label1.Text = "Class code: " + data[1].ToString();
            label2.Text = "Attached class code: " + data[2].ToString();
            label3.Text = "Course code: " + data[3].ToString();
            label4.Text = "Course name: " + data[4].ToString();
            label5.Text = "Note: " + data[5].ToString();
            label6.Text = "Day of week: " + data[6].ToString();
            label7.Text = "Time frame: " + (TimeStart / 60).ToString() + ":" + (TimeStart % 60).ToString() + " - " + (TimeEnd / 60).ToString() + ":" + (TimeEnd % 60).ToString();
            label8.Text = "Week: " + data[9].ToString();
            label9.Text = "Management code: " + data[10].ToString();

            int coeffictent = Convert.ToInt32(data[11].ToString());
            string Status = data[12].ToString();
            if (coeffictent != int.MaxValue)
            {
                label10.Text = "Coefficient: " + coeffictent.ToString();
            }
            else
            {
                label10.Text = "Coefficient: inf";
            }
            if (Status == "Eliminated")
            {
                label11.Text = "Status: Eliminated";
                button3.Text = "Recover this class";
            }
            else
            {
                label11.Text = "Status: Available";
                button3.Text = "Eliminate this class";
            }
        }

        private void button1_Click(object sender, EventArgs e)
        {
            SetCoefficient setCoefficient = new SetCoefficient();
            setCoefficient.Coefficient = Coefficient;
            setCoefficient.ShowDialog();
            if (setCoefficient.DialogResult == DialogResult.OK)
            {
                if (setCoefficient.Coefficient == int.MaxValue)
                {
                    label10.Text = "Coefficient: inf";
                }
                else
                {
                    label10.Text = "Coefficient: " + setCoefficient.Coefficient.ToString();
                }
            }
        }

        private void button2_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void button3_Click(object sender, EventArgs e)
        {
            if (button3.Text == "Eliminate this class")
            {
                button3.Text = "Recover this class";
                label11.Text = "Status: Eliminated";
            }
            else
            {
                button3.Text = "Eliminate this class";
                label11.Text = "Status: Available";
            }
        }

        private void ClassInfo_Load(object sender, EventArgs e)
        {

        }
    }
}
