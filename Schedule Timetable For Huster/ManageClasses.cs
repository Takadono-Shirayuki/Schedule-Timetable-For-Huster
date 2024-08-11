using System.Data;

namespace Schedule_Timetable_For_Huster
{
    public partial class ManageClasses : Form
    {
        TimetableSetting2 Parent;
        public ManageClasses(TimetableSetting2 Parent)
        {
            InitializeComponent();
            this.Parent = Parent;
        }

        private void ManageClasses_Load(object sender, EventArgs e)
        {
            foreach (var item in TimetableSetting2.GroupInfo)
            {
                comboBox1.Items.Add(item.Key);
                listBox1.Items.Add(item.Key);
            }
        }

        private void button1_Click(object sender, EventArgs e)
        {
            GroupDialog groupDialog = new GroupDialog("Add Group");
            if (groupDialog.ShowDialog() == DialogResult.OK)
            {
                if (TimetableSetting2.GroupInfo.ContainsKey(groupDialog.GroupName))
                {
                    MessageBox.Show("Group already exists");
                    return;
                }
                TimetableSetting2.GroupInfo.Add(groupDialog.GroupName, new TimetableSetting2.Group(groupDialog.CourseName));
                Parent.AddGroup(groupDialog.GroupName, groupDialog.CourseName);
                comboBox1.Items.Add(groupDialog.GroupName);
                listBox1.Items.Add(groupDialog.GroupName);
            }
        }

        private void button3_Click(object sender, EventArgs e)
        {
            if (listBox1.SelectedIndex > 0)
            {
                MessageBox.Show("Please select a group");
                return;
            }
            GroupDialog groupDialog = new GroupDialog("Edit Group", listBox1.SelectedItem.ToString(), TimetableSetting2.GroupInfo[listBox1.SelectedItem.ToString()].CourseName);
            if (groupDialog.ShowDialog() == DialogResult.OK)
            {
                if (TimetableSetting2.GroupInfo.ContainsKey(groupDialog.GroupName))
                {
                    MessageBox.Show("Group already exists");
                    return;
                }
                TimetableSetting2.GroupInfo.Add(groupDialog.GroupName, new TimetableSetting2.Group(groupDialog.CourseName));
                TimetableSetting2.GroupInfo.Remove(listBox1.SelectedItem.ToString());
                DataRow[] dataRows = TimetableSetting2.ClassSource.Select("Group='" + listBox1.SelectedItem.ToString() + "'");
                foreach (DataRow dataRow in dataRows)
                {
                    dataRow["Group"] = groupDialog.GroupName;
                }
                Parent.UpdateGroup(listBox1.SelectedItem.ToString(), groupDialog.GroupName);
                comboBox1.Items[comboBox1.Items.IndexOf(listBox1.SelectedItem.ToString())] = groupDialog.GroupName;
                listBox1.Items[listBox1.Items.IndexOf(listBox1.SelectedItem.ToString())] = groupDialog.GroupName;
            }
        }

        private void listBox1_SelectedIndexChanged(object sender, EventArgs e)
        {
            try
            {
                if (listBox1.SelectedIndex == 0)
                {
                    dataGridView1.DataSource = TimetableSetting2.ClassSource;
                }
                else
                {
                    dataGridView1.DataSource = TimetableSetting2.ClassSource.Select("Group='" + listBox1.SelectedItem.ToString() + "'").CopyToDataTable();
                }
                ShowClass(0);
            }
            catch { }
        }

        private void ShowClass(int rowIndex)
        {
            if (dataGridView1.SelectedRows.Count == 1)
            {
                textBox1.Text = dataGridView1.Rows[rowIndex].Cells[0].Value.ToString();
                textBox2.Text = dataGridView1.Rows[rowIndex].Cells[1].Value.ToString();
                textBox3.Text = dataGridView1.Rows[rowIndex].Cells[2].Value.ToString();
                textBox4.Text = dataGridView1.Rows[rowIndex].Cells[3].Value.ToString();
                textBox5.Text = dataGridView1.Rows[rowIndex].Cells[4].Value.ToString();
                textBox7.Text = dataGridView1.Rows[rowIndex].Cells[5].Value.ToString();
                textBox6.Text = dataGridView1.Rows[rowIndex].Cells[6].Value.ToString();
                textBox8.Text = dataGridView1.Rows[rowIndex].Cells[7].Value.ToString();
                textBox9.Text = dataGridView1.Rows[rowIndex].Cells[8].Value.ToString();
                textBox10.Text = dataGridView1.Rows[rowIndex].Cells[9].Value.ToString();
                textBox11.Text = dataGridView1.Rows[rowIndex].Cells[10].Value.ToString();
                textBox12.Text = dataGridView1.Rows[rowIndex].Cells[11].Value.ToString();
                comboBox2.Text = dataGridView1.Rows[rowIndex].Cells[12].Value.ToString();
            }
            else
            {
                textBox1.Text = "";
                textBox2.Text = "";
                textBox3.Text = "";
                textBox4.Text = "";
                textBox5.Text = "";
                textBox7.Text = "";
                textBox6.Text = "";
                textBox8.Text = "";
                textBox9.Text = "";
                textBox10.Text = "";
                textBox11.Text = "";
                textBox12.Text = "";
                comboBox2.Text = "";
            }
        }
        private void dataGridView1_CellClick(object sender, DataGridViewCellEventArgs e)
        {

        }

        private void textBox12_TextChanged(object sender, EventArgs e)
        {
            if (checkBox1.Checked)
            {
                if (textBox12.Text == "inf")
                    textBox12.Text = int.MaxValue.ToString();
                if (textBox12.Text == "")
                    textBox12.Text = "0";
                if (int.TryParse(textBox12.Text, out int a))
                {
                    foreach (DataGridViewRow row in dataGridView1.SelectedRows)
                    {
                        row.Cells[11].Value = a;
                        DataRow[] dataRows = TimetableSetting2.ClassSource.Select("[Class code] = '" + row.Cells[1].ToString() + "'");
                        foreach (DataRow dataRow in dataRows)
                        {
                            dataRow["Coefficient"] = a;
                        }
                    }
                }
            }
        }

        private void comboBox2_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (checkBox1.Checked)
            {
                foreach (DataGridViewRow row in dataGridView1.SelectedRows)
                {
                    row.Cells[12].Value = comboBox2.Text;
                    DataRow[] dataRows = TimetableSetting2.ClassSource.Select("[Class code] = '" + row.Cells[1].Value.ToString() + "'");
                    foreach (DataRow dataRow in dataRows)
                    {
                        dataRow["Status"] = comboBox2.Text;
                    }
                    dataRows = TimetableSetting2.ClassSource.Select("Group = '" + row.Cells[0].Value.ToString() + "' AND Status <> 'Not Added'");
                    if (dataRows.Count() == 0)
                    {
                        Parent.ChangeStatus(row.Cells[0].Value.ToString(), "Not Added");
                    }
                    else
                    {
                        Parent.ChangeStatus(row.Cells[0].Value.ToString(), "Added");
                    }
                }
            }
        }

        private void button4_Click(object sender, EventArgs e)
        {
            if (textBox12.Text == "inf")
                textBox12.Text = int.MaxValue.ToString();
            if (textBox12.Text == "")
                textBox12.Text = "0";
            if (int.TryParse(textBox12.Text, out int a))
            {
                foreach (DataGridViewRow row in dataGridView1.SelectedRows)
                {
                    row.Cells[11].Value = a;
                    row.Cells[12].Value = comboBox2.Text;
                    DataRow[] dataRows = TimetableSetting2.ClassSource.Select("[Class code] = '" + row.Cells[1].Value.ToString() + "'");
                    foreach (DataRow dataRow in dataRows)
                    {
                        dataRow["Coefficient"] = a;
                        dataRow["Status"] = comboBox2.Text;
                    }
                    dataRows = TimetableSetting2.ClassSource.Select("Group = '" + row.Cells[0].Value.ToString() + "' AND Status <> 'Not Added'");
                    if (dataRows.Count() == 0)
                    {
                        Parent.ChangeStatus(row.Cells[0].Value.ToString(), "Not Added");
                    }
                    else
                    {
                        Parent.ChangeStatus(row.Cells[0].Value.ToString(), "Added");
                    }
                }
                MessageBox.Show("Updated");
            }
            else
            {
                MessageBox.Show("Invalid coefficient");
            }
        }

        private void dataGridView1_SelectionChanged(object sender, EventArgs e)
        {
            int rowIndex = dataGridView1.CurrentCell.RowIndex;
            if (rowIndex > -1)
            {
                ShowClass(rowIndex);
            }
        }

        private void checkBox1_CheckedChanged(object sender, EventArgs e)
        {
            if (!checkBox1.Checked)
            {
                return;
            }
            if (textBox12.Text == "inf")
                textBox12.Text = int.MaxValue.ToString();
            if (textBox12.Text == "")
                textBox12.Text = "0";
            if (int.TryParse(textBox12.Text, out int a))
            {
                foreach (DataGridViewRow row in dataGridView1.SelectedRows)
                {
                    row.Cells[11].Value = a;
                    row.Cells[12].Value = comboBox2.Text;
                    DataRow[] dataRows = TimetableSetting2.ClassSource.Select("[Class code] = '" + row.Cells[1].Value.ToString() + "'");
                    foreach (DataRow dataRow in dataRows)
                    {
                        dataRow["Coefficient"] = a;
                        dataRow["Status"] = comboBox2.Text;
                    }
                    dataRows = TimetableSetting2.ClassSource.Select("Group = '" + row.Cells[0].Value.ToString() + "' AND Status <> 'Not Added'");
                    if (dataRows.Count() == 0)
                    {
                        Parent.ChangeStatus(row.Cells[0].Value.ToString(), "Not Added");
                    }
                    else
                    {
                        Parent.ChangeStatus(row.Cells[0].Value.ToString(), "Added");
                    }
                }
            }
        }

        private void button2_Click(object sender, EventArgs e)
        {
            foreach (DataGridViewRow row in dataGridView1.SelectedRows)
            {
                DataRow[] dataRows = TimetableSetting2.ClassSource.Select("[Class code] = '" + row.Cells[1].Value.ToString() + "'");
                foreach (DataRow dataRow in dataRows)
                {
                    dataRow["Group"] = comboBox1.Text;
                }
                dataRows = TimetableSetting2.ClassSource.Select("Group = '" + row.Cells[0].Value.ToString() + "' AND Status <> 'Not Added'");
                if (dataRows.Count() == 0)
                {
                    Parent.ChangeStatus(row.Cells[0].Value.ToString(), "Not Added");
                }
                else
                {
                    Parent.ChangeStatus(row.Cells[0].Value.ToString(), "Added");
                }
                row.Cells[0].Value = comboBox1.Text;
            }
        }
    }
}
