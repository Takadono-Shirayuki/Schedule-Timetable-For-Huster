using System.Data;

namespace Schedule_Timetable_For_Huster
{
    public partial class Class : UserControl
    {
        DataRow data;
        public DataRow Data
        {
            get { return data; }
            set
            {
                data = value;
                label1.Text = data[4].ToString();
            }
        }

        public Class()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            ClassInfo classInfo = new ClassInfo(data);
            classInfo.ShowDialog();
            data["Coefficient"] = classInfo.Coefficient;
            data["Status"] = classInfo.Status;
        }

        private void button2_Click(object sender, EventArgs e)
        {
            this.SendToBack();
        }

        private void label1_Click(object sender, EventArgs e)
        {
              this.BringToFront();
        }

        private void Class_Load(object sender, EventArgs e)
        {
            int TimeStart = Convert.ToInt32(data[7].ToString());
            int TimeEnd = Convert.ToInt32(data[8].ToString());
            this.Location = new Point(0, (TimeStart - 390) * 5 / 4);
            this.Height = (TimeEnd - TimeStart) * 5 / 4;
            this.BringToFront();
        }
    }
}
