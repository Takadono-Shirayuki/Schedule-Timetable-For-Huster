namespace Schedule_Timetable_For_Huster
{
    public partial class Time : UserControl
    {
        public Time()
        {
            InitializeComponent();
        }

        public string TimeText
        {
            get
            {
                return TTime.Text;
            }
            set
            {
                TTime.Text = value;
            }
        }

        private void TTime_Click(object sender, EventArgs e)
        {

        }
    }
}
