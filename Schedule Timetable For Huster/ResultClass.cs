using System.Data;

namespace Schedule_Timetable_For_Huster
{
    public partial class ResultClass : UserControl
    {
        public ResultClass(DataRow Data)
        {
            InitializeComponent();
            int T1, T2;
            T1 = Convert.ToInt32(Data[7].ToString());
            T2 = Convert.ToInt32(Data[8].ToString());
            label1.Text = Data[1].ToString() + "\n" + (T1 / 60).ToString("00") + ":" + (T1 % 60).ToString("00") + "-" + (T2 / 60).ToString("00") + ":" + (T2 % 60).ToString("00") + "\n" + Data[4].ToString();
            this.Location = new Point(0, T1 - 390);
            this.Height = T2 - T1;
        }
    }
}
