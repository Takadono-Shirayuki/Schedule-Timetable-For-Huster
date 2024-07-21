using Aspose.Cells;
using System.Data;
using System.Security.Cryptography;
using System.Text.RegularExpressions;

namespace Schedule_Timetable_For_Huster
{
    public partial class Form1 : Form
    {
        public static DataTable Data = new DataTable();
        public static string Time_Frame_Format = "";
        public Form1()
        {
            InitializeComponent();
        }

        OpenFileDialog openFileDialog = new OpenFileDialog();
        private void button1_Click(object sender, EventArgs e)
        {
            // Select the file
            openFileDialog.Title = "Select the file";
            openFileDialog.FileName = "";
            openFileDialog.Filter = "Excel files(*.xlsx)|*.xlsx|All files(*.*)|*.*";
            openFileDialog.FilterIndex = 0; 
            openFileDialog.RestoreDirectory = true;
            if (openFileDialog.ShowDialog() == DialogResult.OK)
            {
                textBox1.Text = openFileDialog.FileName;
            }
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            // Initialize the data table
            Data.Columns.Add("Class code");
            Data.Columns.Add("Attached class code");
            Data.Columns.Add("Course code");
            Data.Columns.Add("Course name");
            Data.Columns.Add("Note");
            Data.Columns.Add("Day of week");
            Data.Columns.Add("Time frame");
            Data.Columns.Add("Week");
            Data.Columns.Add("Management code");

            // Set default values for the comboboxes
            comboBox1.SelectedIndex = 0;
            comboBox2.SelectedIndex = 0;
            comboBox3.SelectedIndex = 0;
            comboBox4.SelectedIndex = 0;
            comboBox5.SelectedIndex = 0;
            comboBox6.SelectedIndex = 0;
            comboBox7.SelectedIndex = 0;
            comboBox8.SelectedIndex = 0;
            comboBox9.SelectedIndex = 0;
        }

        private void button4_Click(object sender, EventArgs e)
        {
            // Show the help form
            TimetableSetting1Help timetableSetting1Help = new TimetableSetting1Help();
            timetableSetting1Help.ShowDialog();
        }

        private int AutoRow1(string Column, int Sheet)
        {
            // Calculate the first row which have many same characters
            Workbook workbook = new Workbook(textBox1.Text);
            Worksheet worksheet = workbook.Worksheets[Sheet];
            Cells cells = worksheet.Cells;
            int row = cells.MaxDataRow;
            Dictionary<char, int> H1 = new Dictionary<char, int>();
            Dictionary<char, int> H2 = new Dictionary<char, int>();
            Dictionary<char, int> H3 = new Dictionary<char, int>();
            int H1Count = 0;
            int H2Count = 0;
            int H3Count = 0;
            int i;
            for (i = 0; i < 100; i++)
            {
                int rrow = RandomNumberGenerator.GetInt32(1, row);
                string value = cells[Column + rrow.ToString()].StringValue;
                foreach (char c in value)
                {
                    if (H1.ContainsKey(c))
                    {
                        H1[c] += value.Length;
                    }
                    else
                    {
                        H1.Add(c, value.Length);
                    }
                }
                H1Count += value.Length;
            }
            for (i = 0; i < 100; i++)
            {
                int rrow = RandomNumberGenerator.GetInt32(1, row);
                string value = cells[Column + rrow.ToString()].StringValue;
                foreach (char c in value)
                {
                    if (H2.ContainsKey(c))
                    {
                        H2[c] += value.Length;
                    }
                    else
                    {
                        H2.Add(c, value.Length);
                    }
                }
                H2Count += value.Length;
            }
            for (i = 0; i < 100; i++)
            {
                int rrow = RandomNumberGenerator.GetInt32(1, row);
                string value = cells[Column + rrow.ToString()].StringValue;
                foreach (char c in value)
                {
                    if (H3.ContainsKey(c))
                    {
                        H3[c] += value.Length;
                    }
                    else
                    {
                        H3.Add(c, value.Length);
                    }
                }
                H3Count += value.Length;
            }
            int d = 0;
            i = 1;
            while (d < 10)
            {
                string value = cells[Column + i.ToString()].StringValue;
                if (value == "")
                {
                    i++;
                    continue;
                }
                int[] P = new int[3];
                foreach (char c in value)
                {
                    P[0] += H1.ContainsKey(c) ? H1[c] : 0;
                    P[1] += H2.ContainsKey(c) ? H2[c] : 0;
                    P[2] += H3.ContainsKey(c) ? H3[c] : 0;
                }
                double[] p = new double[3];
                p[0] = (double)P[0] / H1Count / value.Length;
                p[1] = (double)P[1] / H2Count / value.Length;
                p[2] = (double)P[2] / H3Count / value.Length;
                if ((p[0] > 0.5 && p[1] > 0.5) || (p[0] > 0.5 && p[2] > 0.5) || (p[1] > 0.5 && p[2] > 0.5))
                {
                    d++;
                }
                else
                    d = 0;
                i++;
            }
            return i - 10;
        }
        private int AutoRow2(string Column, int Sheet, int Threshold)
        {
            // Calculate the first row which have few values
            Workbook workbook = new Workbook(textBox1.Text);
            Worksheet worksheet = workbook.Worksheets[Sheet];
            Cells cells = worksheet.Cells;
            int row = cells.MaxDataRow;
            Dictionary<string, int> H1 = new Dictionary<string, int>();
            Dictionary<string, int> H2 = new Dictionary<string, int>();
            Dictionary<string, int> H3 = new Dictionary<string, int>();
            int i;
            for (i = 0; i < 100; i++)
            {
                int rrow = RandomNumberGenerator.GetInt32(0, row);
                string value = cells[Column + rrow.ToString()].StringValue;
                if (H1.ContainsKey(value))
                {
                    H1[value]++;
                }
                else
                {
                    H1.Add(value, 1);
                }
            }
            for (i = 0; i < 100; i++)
            {
                int rrow = RandomNumberGenerator.GetInt32(0, row);
                string value = cells[Column + rrow.ToString()].StringValue;
                if (H2.ContainsKey(value))
                {
                    H2[value]++;
                }
                else
                {
                    H2.Add(value, 1);
                }
            }
            for (i = 0; i < 100; i++)
            {
                int rrow = RandomNumberGenerator.GetInt32(0, row);
                string value = cells[Column + rrow.ToString()].StringValue;
                if (H3.ContainsKey(value))
                {
                    H3[value]++;
                }
                else
                {
                    H3.Add(value, 1);
                }
            }
            int d = 0;
            i = 1;
            while (d < 10)
            {
                string value = cells[Column + i.ToString()].StringValue;
                if ((H1.ContainsKey(value) && H1[value] > Threshold) || (H2.ContainsKey(value) && H2[value] > Threshold) || (H3.ContainsKey(value) && H3[value] > Threshold))
                {
                    d++;
                }
                else
                    d = 0;
            }
            return i - 10;
        }
        private Boolean CheckColumn(string Column)
        {
            // Check the column
            return !(Regex.IsMatch(Column, @"^\d[A-Z]{1,2}$") || Regex.IsMatch(Column, @"^[A-Z]{1,2}$"));
        }

        private Boolean CheckRow(string Row)
        {
            // Check the row
            return !(Row == "Auto" || Row == "Same as Class code" || Row == "Same as Course code" || int.TryParse(Row, out int result));
        }
        private void button3_Click(object sender, EventArgs e)
        {
            // Check the input
            if (textBox1.Text == "")
            {
                MessageBox.Show("Please select a file first.", "File Selection", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }
            if (!File.Exists(textBox1.Text))
            {
                MessageBox.Show("The file does not exist.", "File Selection", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }
            if (textBox2.Text == "" || CheckColumn(textBox2.Text))
            {
                MessageBox.Show("Please select a suitable column for the class code data", "Column Selection", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }
            if (textBox3.Text == "" || CheckColumn(textBox3.Text))
            {
                MessageBox.Show("Please select a suitable column for the attached class code data", "Column Selection", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }
            if (textBox4.Text == "" || CheckColumn(textBox5.Text))
            {
                MessageBox.Show("Please select a suitable column for the course code data", "Column Selection", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }
            if (textBox5.Text == "" || CheckColumn(textBox5.Text))
            {
                MessageBox.Show("Please select a suitable column for the course name data", "Column Selection", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }
            if (textBox6.Text == "" || CheckColumn(textBox6.Text))
            {
                MessageBox.Show("Please select a suitable column for the note data", "Column Selection", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }
            if (textBox7.Text == "" || CheckColumn(textBox7.Text))
            {
                MessageBox.Show("Please select a suitable column for the day of week data", "Column Selection", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }
            if (textBox8.Text == "" || CheckColumn(textBox8.Text))
            {
                MessageBox.Show("Please select a suitable column for the time frame data", "Column Selection", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }
            if (textBox10.Text == "" || CheckColumn(textBox10.Text))
            {
                MessageBox.Show("Please select a suitable column for the week data", "Column Selection", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }
            if (textBox11.Text == "" || CheckColumn(textBox11.Text))
            {
                MessageBox.Show("Please select a suitable column for the management code data", "Column Selection", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            if (CheckRow(comboBox1.Text))
            {
                MessageBox.Show("Please select a suitable row for the class code data", "Row Selection", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }
            if (CheckRow(comboBox2.Text))
            {
                MessageBox.Show("Please select a suitable row for the attached class code data", "Row Selection", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }
            if (CheckRow(comboBox3.Text))
            {
                MessageBox.Show("Please select a suitable row for the course code data", "Row Selection", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }
            if (CheckRow(comboBox4.Text))
            {
                MessageBox.Show("Please select a suitable row for the course name data", "Row Selection", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }
            if (CheckRow(comboBox5.Text))
            {
                MessageBox.Show("Please select a suitable row for the note data", "Row Selection", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }
            if (CheckRow(comboBox6.Text))
            {
                MessageBox.Show("Please select a suitable row for the day of week data", "Row Selection", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }
            if (CheckRow(comboBox7.Text))
            {
                MessageBox.Show("Please select a suitable row for the time frame data", "Row Selection", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }
            if (CheckRow(comboBox8.Text))
            {
                MessageBox.Show("Please select a suitable row for the week data", "Row Selection", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }
            if (CheckRow(comboBox9.Text))
            {
                MessageBox.Show("Please select a suitable row for the management code data", "Row Selection", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            // Calculate the first row
            int[] worksheet = new int[9];
            string[] Columns = new string[9];
            Columns[0] = textBox2.Text;
            Columns[1] = textBox3.Text;
            Columns[2] = textBox4.Text;
            Columns[3] = textBox5.Text;
            Columns[4] = textBox6.Text;
            Columns[5] = textBox7.Text;
            Columns[6] = textBox8.Text;
            Columns[7] = textBox10.Text;
            Columns[8] = textBox11.Text;
            for (int i = 0; i < 9; i++)
            {
                worksheet[i] = 0;
                while ("0123456789".IndexOf(Columns[i][0]) != -1)
                {
                    worksheet[i] = worksheet[i] * 10 + Columns[i][0] - '0';
                    Columns[i] = Columns[i].Substring(1);
                }
            }

            int[] FirstRow = new int[9];
            if (comboBox1.Text == "Auto")
            {
                FirstRow[0] = AutoRow1(Columns[0], worksheet[0]);
            }
            else
            {
                FirstRow[0] = int.Parse(comboBox1.Text);
            }
            if (comboBox2.Text == "Auto")
            {
                FirstRow[1] = AutoRow1(Columns[1], worksheet[1]);
            }
            else if (comboBox2.Text == "Same as Class code")
            {
                FirstRow[1] = FirstRow[0];
            }
            else
            {
                FirstRow[1] = int.Parse(comboBox2.Text);
            }
            if (comboBox3.Text == "Auto")
            {
                FirstRow[2] = AutoRow1(Columns[2], worksheet[2]);
            }
            else if (comboBox3.Text == "Same as Class code")
            {
                FirstRow[2] = FirstRow[0];
            }
            else
            {
                FirstRow[2] = int.Parse(comboBox3.Text);
            }
            if (comboBox4.Text == "Same as Class code")
            {
                FirstRow[3] = FirstRow[0];
            }
            else if (comboBox4.Text == "Same as Course code")
            {
                FirstRow[3] = FirstRow[2];
            }
            else
            {
                FirstRow[3] = int.Parse(comboBox4.Text);
            }
            if (comboBox5.Text == "Same as Class code")
            {
                FirstRow[4] = FirstRow[0];
            }
            else if (comboBox5.Text == "Same as Course code")
            {
                FirstRow[4] = FirstRow[2];
            }
            else
            {
                FirstRow[4] = int.Parse(comboBox5.Text);
            }
            if (comboBox6.Text == "Same as Class code")
            {
                FirstRow[5] = FirstRow[0];
            }
            else if (comboBox6.Text == "Same as Course code")
            {
                FirstRow[5] = FirstRow[2];
            }
            else
            {
                FirstRow[5] = int.Parse(comboBox6.Text);
            }
            if (comboBox7.Text == "Same as Class code")
            {
                FirstRow[6] = FirstRow[0];
            }
            else if (comboBox7.Text == "Same as Course code")
            {
                FirstRow[6] = FirstRow[2];
            }
            else
            {
                FirstRow[6] = int.Parse(comboBox7.Text);
            }
            if (comboBox8.Text == "Same as Class code")
            {
                FirstRow[7] = FirstRow[0];
            }
            else if (comboBox8.Text == "Same as Course code")
            {
                FirstRow[7] = FirstRow[2];
            }
            else
            {
                FirstRow[7] = int.Parse(comboBox8.Text);
            }
            if (comboBox9.Text == "Auto")
            {
                FirstRow[8] = AutoRow2(Columns[9], worksheet[9], 1);
            }
            else if (comboBox9.Text == "Same as Class code")
            {
                FirstRow[8] = FirstRow[0];
            }
            else if (comboBox9.Text == "Same as Course code")
            {
                FirstRow[8] = FirstRow[2];
            }
            else
            {
                FirstRow[8] = int.Parse(comboBox9.Text);
            }

            // Read the data from the excel file use aspose.cells
            Data.Rows.Clear();
            Workbook workbook = new Workbook(textBox1.Text);
            for (; FirstRow[0] < workbook.Worksheets[worksheet[0]].Cells.MaxDataRow;)
            {
                DataRow row = Data.NewRow();
                for (int i = 0; i < 9; i++)
                {
                    row[i] = workbook.Worksheets[worksheet[i]].Cells[Columns[i] + FirstRow[i]++.ToString()].StringValue;
                }
                Data.Rows.Add(row);
            }
            this.Hide();
            Time_Frame_Format = textBox9.Text;
            TimetableSetting2 timetableSetting2 = new TimetableSetting2();
            timetableSetting2.ShowDialog();
            this.Show();
        }
    }
}
