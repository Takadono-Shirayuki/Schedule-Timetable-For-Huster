namespace Schedule_Timetable_For_Huster
{
    public partial class GroupDialog : Form
    {
        public string GroupName
        {
            get { return textBox1.Text; }
        }
        public string CourseName
        {
            get { return textBox2.Text; }
        }
        public GroupDialog(string Name, string Group = "", string Course = "")
        {
            InitializeComponent();
            Text = Name;
            textBox1.Text = Group;
            textBox2.Text = Course;
        }

        private void button1_Click(object sender, EventArgs e)
        {
            DialogResult = DialogResult.OK;
        }

        private void button2_Click(object sender, EventArgs e)
        {
            DialogResult = DialogResult.Cancel;
        }
    }
}
