using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Schedule_Timetable_For_Huster
{
    public partial class ResultClass : UserControl
    {
        public ResultClass(DataRow Data)
        {
            InitializeComponent();
            int T1, T2;
            T1 = Convert.ToInt32(Data[5].ToString());
            T2 = Convert.ToInt32(Data[6].ToString());
            label1.Text = Data[0].ToString() + "\n" + (T1 / 60).ToString("00") + ":" + (T1 % 60).ToString("00") + "-" + (T2 / 60).ToString("00") + ":" + (T2 % 60).ToString("00") + "\n" + Data[3].ToString();
            this.Location = new Point(0, T1 - 390);
            this.Height = T2 - T1;
        }

        private void ResultClass_Load(object sender, EventArgs e)
        {

        }
    }
}
