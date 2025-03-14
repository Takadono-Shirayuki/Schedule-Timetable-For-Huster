using System.Data;

namespace Schedule_Timetable_For_Huster
{
    public partial class Class : UserControl
    {
        public int H;
        public int M;
        int coefficient = 0;
        string status = "Available";
        DataRow data;
        public DataRow Data
        {
            get { return data; }
            set
            {
                data = value;
                label1.Text = data[3].ToString();
            }
        }
        public Class()
        {
            InitializeComponent();
        }

        public int Coefficient
        {
            get { return coefficient; }
        }
        public string Status
        {
            get { return this.status; }
        }

        private void button1_Click(object sender, EventArgs e)
        {
            ClassInfo classInfo = new ClassInfo(data, coefficient, Status);
            classInfo.ShowDialog();
            coefficient = classInfo.Coefficient;
            status = classInfo.Status;
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
            string time = data[6].ToString();
            H = 0;
            M = 0;
            label1.Text = data[0].ToString() + " - " + data[3].ToString();
            for (int i = 0; i < Form1.Time_Frame_Format.Length; i++)
            {
                char c = Form1.Time_Frame_Format[i];
                if (c == 'H')
                    H = H * 10 + time[i] - '0';
                else if (c == 'M')
                    M = M * 10 + time[i] - '0';
            }
            this.Location = new Point(0, (60 * (H / 100 - 6) + M / 100 - 30) * 5 / 4);
            this.Height = (60 * (H % 100 - H / 100) + M % 100 - M / 100) * 5 / 4;
            this.BringToFront();
        }
    }
}
