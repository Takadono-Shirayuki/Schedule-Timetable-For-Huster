namespace Schedule_Timetable_For_Huster
{
    public partial class SetCoefficient : Form
    {
        public int Coefficient
        {
            get
            {
                if (comboBox1.Text == "inf")
                {
                    return int.MaxValue;
                }
                else if (int.TryParse(comboBox1.Text, out int a))
                {
                    if (a < 0) 
                        return 0;
                    else 
                        return a;
                }
                else
                {
                    return 0;
                }
            }
            set 
            {
                if (value == int.MaxValue)
                {
                    comboBox1.Text = "inf";
                }
                else
                {
                    comboBox1.Text = value.ToString();
                }
            }
        } 
        public SetCoefficient()
        {
            InitializeComponent();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            this.DialogResult = DialogResult.Cancel;
            this.Close();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            this.DialogResult = DialogResult.OK;
            this.Close();
        }
    }
}
