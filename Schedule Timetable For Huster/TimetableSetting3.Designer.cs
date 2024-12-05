namespace Schedule_Timetable_For_Huster
{
    partial class TimetableSetting3
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            groupBox1 = new GroupBox();
            button2 = new Button();
            comboBox1 = new ComboBox();
            label3 = new Label();
            label2 = new Label();
            label1 = new Label();
            panel1 = new Panel();
            dow7 = new Label();
            dow6 = new Label();
            dow5 = new Label();
            dow4 = new Label();
            label5 = new Label();
            dow3 = new Label();
            dow2 = new Label();
            splitContainer2 = new SplitContainer();
            splitContainer3 = new SplitContainer();
            splitContainer4 = new SplitContainer();
            splitContainer5 = new SplitContainer();
            splitContainer6 = new SplitContainer();
            splitContainer7 = new SplitContainer();
            listBox1 = new ListBox();
            button3 = new Button();
            panel2 = new Panel();
            groupBox1.SuspendLayout();
            panel1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)splitContainer2).BeginInit();
            splitContainer2.Panel2.SuspendLayout();
            splitContainer2.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)splitContainer3).BeginInit();
            splitContainer3.Panel2.SuspendLayout();
            splitContainer3.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)splitContainer4).BeginInit();
            splitContainer4.Panel2.SuspendLayout();
            splitContainer4.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)splitContainer5).BeginInit();
            splitContainer5.Panel2.SuspendLayout();
            splitContainer5.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)splitContainer6).BeginInit();
            splitContainer6.Panel2.SuspendLayout();
            splitContainer6.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)splitContainer7).BeginInit();
            splitContainer7.SuspendLayout();
            panel2.SuspendLayout();
            SuspendLayout();
            // 
            // groupBox1
            // 
            groupBox1.Controls.Add(button2);
            groupBox1.Controls.Add(comboBox1);
            groupBox1.Controls.Add(label3);
            groupBox1.Controls.Add(label2);
            groupBox1.Controls.Add(label1);
            groupBox1.Dock = DockStyle.Top;
            groupBox1.Location = new Point(150, 0);
            groupBox1.Margin = new Padding(5, 4, 5, 4);
            groupBox1.Name = "groupBox1";
            groupBox1.Padding = new Padding(5, 4, 5, 4);
            groupBox1.Size = new Size(1073, 115);
            groupBox1.TabIndex = 1;
            groupBox1.TabStop = false;
            groupBox1.Text = "Set the course coefficient";
            // 
            // button2
            // 
            button2.Location = new Point(259, 68);
            button2.Name = "button2";
            button2.Size = new Size(125, 37);
            button2.TabIndex = 11;
            button2.Text = "Help";
            button2.UseVisualStyleBackColor = true;
            button2.Click += button2_Click;
            // 
            // comboBox1
            // 
            comboBox1.FormattingEnabled = true;
            comboBox1.Items.AddRange(new object[] { "inf" });
            comboBox1.Location = new Point(144, 68);
            comboBox1.Name = "comboBox1";
            comboBox1.Size = new Size(108, 37);
            comboBox1.TabIndex = 8;
            comboBox1.TextChanged += comboBox1_TextChanged;
            // 
            // label3
            // 
            label3.AutoSize = true;
            label3.Location = new Point(8, 71);
            label3.Name = "label3";
            label3.Size = new Size(130, 29);
            label3.TabIndex = 6;
            label3.Text = "Coefficient:";
            // 
            // label2
            // 
            label2.AutoSize = true;
            label2.Location = new Point(259, 33);
            label2.Name = "label2";
            label2.Size = new Size(152, 29);
            label2.TabIndex = 1;
            label2.Text = "Course name:";
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.Location = new Point(8, 33);
            label1.Name = "label1";
            label1.Size = new Size(145, 29);
            label1.TabIndex = 0;
            label1.Text = "Course code:";
            // 
            // panel1
            // 
            panel1.Controls.Add(dow7);
            panel1.Controls.Add(dow6);
            panel1.Controls.Add(dow5);
            panel1.Controls.Add(dow4);
            panel1.Controls.Add(label5);
            panel1.Controls.Add(dow3);
            panel1.Controls.Add(dow2);
            panel1.Dock = DockStyle.Top;
            panel1.Location = new Point(150, 115);
            panel1.Name = "panel1";
            panel1.Size = new Size(1073, 44);
            panel1.TabIndex = 2;
            // 
            // dow7
            // 
            dow7.Location = new Point(873, 3);
            dow7.Name = "dow7";
            dow7.Size = new Size(144, 41);
            dow7.TabIndex = 5;
            dow7.Text = "Saturday";
            dow7.TextAlign = ContentAlignment.MiddleCenter;
            dow7.Click += label10_Click;
            // 
            // dow6
            // 
            dow6.Location = new Point(720, 3);
            dow6.Name = "dow6";
            dow6.Size = new Size(147, 41);
            dow6.TabIndex = 4;
            dow6.Text = "Friday";
            dow6.TextAlign = ContentAlignment.MiddleCenter;
            dow6.Click += label9_Click;
            // 
            // dow5
            // 
            dow5.Location = new Point(566, 3);
            dow5.Name = "dow5";
            dow5.Size = new Size(148, 41);
            dow5.TabIndex = 3;
            dow5.Text = "Thursday";
            dow5.TextAlign = ContentAlignment.MiddleCenter;
            dow5.Click += label7_Click;
            // 
            // dow4
            // 
            dow4.Location = new Point(412, 3);
            dow4.Name = "dow4";
            dow4.Size = new Size(148, 41);
            dow4.TabIndex = 3;
            dow4.Text = "Wednesday";
            dow4.TextAlign = ContentAlignment.MiddleCenter;
            dow4.Click += label6_Click;
            // 
            // label5
            // 
            label5.Location = new Point(416, 3);
            label5.Name = "label5";
            label5.Size = new Size(144, 30);
            label5.TabIndex = 2;
            label5.Text = "Tuesday";
            label5.TextAlign = ContentAlignment.MiddleCenter;
            // 
            // dow3
            // 
            dow3.Location = new Point(258, 3);
            dow3.Name = "dow3";
            dow3.Size = new Size(152, 41);
            dow3.TabIndex = 1;
            dow3.Text = "Tuesday";
            dow3.TextAlign = ContentAlignment.MiddleCenter;
            dow3.Click += label4_Click;
            // 
            // dow2
            // 
            dow2.Location = new Point(104, 3);
            dow2.Name = "dow2";
            dow2.Size = new Size(148, 41);
            dow2.TabIndex = 0;
            dow2.Text = "Monday";
            dow2.TextAlign = ContentAlignment.MiddleCenter;
            dow2.Click += label8_Click;
            // 
            // splitContainer2
            // 
            splitContainer2.BorderStyle = BorderStyle.FixedSingle;
            splitContainer2.Dock = DockStyle.Fill;
            splitContainer2.FixedPanel = FixedPanel.Panel1;
            splitContainer2.IsSplitterFixed = true;
            splitContainer2.Location = new Point(150, 159);
            splitContainer2.Name = "splitContainer2";
            // 
            // splitContainer2.Panel2
            // 
            splitContainer2.Panel2.Controls.Add(splitContainer3);
            splitContainer2.Size = new Size(1073, 457);
            splitContainer2.SplitterDistance = 100;
            splitContainer2.TabIndex = 3;
            // 
            // splitContainer3
            // 
            splitContainer3.BorderStyle = BorderStyle.FixedSingle;
            splitContainer3.Dock = DockStyle.Fill;
            splitContainer3.FixedPanel = FixedPanel.Panel1;
            splitContainer3.IsSplitterFixed = true;
            splitContainer3.Location = new Point(0, 0);
            splitContainer3.Name = "splitContainer3";
            // 
            // splitContainer3.Panel2
            // 
            splitContainer3.Panel2.Controls.Add(splitContainer4);
            splitContainer3.Size = new Size(969, 457);
            splitContainer3.SplitterDistance = 150;
            splitContainer3.TabIndex = 0;
            // 
            // splitContainer4
            // 
            splitContainer4.Dock = DockStyle.Fill;
            splitContainer4.FixedPanel = FixedPanel.Panel1;
            splitContainer4.IsSplitterFixed = true;
            splitContainer4.Location = new Point(0, 0);
            splitContainer4.Name = "splitContainer4";
            // 
            // splitContainer4.Panel2
            // 
            splitContainer4.Panel2.Controls.Add(splitContainer5);
            splitContainer4.Size = new Size(813, 455);
            splitContainer4.SplitterDistance = 150;
            splitContainer4.TabIndex = 0;
            // 
            // splitContainer5
            // 
            splitContainer5.BorderStyle = BorderStyle.FixedSingle;
            splitContainer5.Dock = DockStyle.Fill;
            splitContainer5.FixedPanel = FixedPanel.Panel1;
            splitContainer5.IsSplitterFixed = true;
            splitContainer5.Location = new Point(0, 0);
            splitContainer5.Name = "splitContainer5";
            // 
            // splitContainer5.Panel2
            // 
            splitContainer5.Panel2.Controls.Add(splitContainer6);
            splitContainer5.Size = new Size(659, 455);
            splitContainer5.SplitterDistance = 150;
            splitContainer5.TabIndex = 0;
            // 
            // splitContainer6
            // 
            splitContainer6.BorderStyle = BorderStyle.FixedSingle;
            splitContainer6.Dock = DockStyle.Fill;
            splitContainer6.FixedPanel = FixedPanel.Panel1;
            splitContainer6.IsSplitterFixed = true;
            splitContainer6.Location = new Point(0, 0);
            splitContainer6.Name = "splitContainer6";
            // 
            // splitContainer6.Panel2
            // 
            splitContainer6.Panel2.Controls.Add(splitContainer7);
            splitContainer6.Size = new Size(505, 455);
            splitContainer6.SplitterDistance = 150;
            splitContainer6.TabIndex = 0;
            // 
            // splitContainer7
            // 
            splitContainer7.BorderStyle = BorderStyle.FixedSingle;
            splitContainer7.Dock = DockStyle.Fill;
            splitContainer7.FixedPanel = FixedPanel.Panel1;
            splitContainer7.IsSplitterFixed = true;
            splitContainer7.Location = new Point(0, 0);
            splitContainer7.Name = "splitContainer7";
            splitContainer7.Size = new Size(351, 455);
            splitContainer7.SplitterDistance = 150;
            splitContainer7.TabIndex = 0;
            // 
            // listBox1
            // 
            listBox1.Dock = DockStyle.Left;
            listBox1.FormattingEnabled = true;
            listBox1.ItemHeight = 29;
            listBox1.Location = new Point(0, 0);
            listBox1.Name = "listBox1";
            listBox1.Size = new Size(150, 574);
            listBox1.TabIndex = 0;
            listBox1.SelectedIndexChanged += listBox1_SelectedIndexChanged;
            // 
            // button3
            // 
            button3.Dock = DockStyle.Bottom;
            button3.FlatStyle = FlatStyle.Popup;
            button3.Location = new Point(0, 574);
            button3.Name = "button3";
            button3.Size = new Size(150, 42);
            button3.TabIndex = 4;
            button3.Text = "Continue";
            button3.UseVisualStyleBackColor = true;
            button3.Click += button3_Click;
            // 
            // panel2
            // 
            panel2.Controls.Add(listBox1);
            panel2.Controls.Add(button3);
            panel2.Dock = DockStyle.Left;
            panel2.Location = new Point(0, 0);
            panel2.Name = "panel2";
            panel2.Size = new Size(150, 616);
            panel2.TabIndex = 0;
            // 
            // TimetableSetting3
            // 
            AutoScaleDimensions = new SizeF(14F, 29F);
            AutoScaleMode = AutoScaleMode.Font;
            BackColor = Color.White;
            ClientSize = new Size(1223, 616);
            Controls.Add(splitContainer2);
            Controls.Add(panel1);
            Controls.Add(groupBox1);
            Controls.Add(panel2);
            Font = new Font("Times New Roman", 15F, FontStyle.Regular, GraphicsUnit.Point, 0);
            Margin = new Padding(5, 4, 5, 4);
            Name = "TimetableSetting3";
            Text = "Timetable Setting";
            Load += TimetableSetting3_Load;
            groupBox1.ResumeLayout(false);
            groupBox1.PerformLayout();
            panel1.ResumeLayout(false);
            splitContainer2.Panel2.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)splitContainer2).EndInit();
            splitContainer2.ResumeLayout(false);
            splitContainer3.Panel2.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)splitContainer3).EndInit();
            splitContainer3.ResumeLayout(false);
            splitContainer4.Panel2.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)splitContainer4).EndInit();
            splitContainer4.ResumeLayout(false);
            splitContainer5.Panel2.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)splitContainer5).EndInit();
            splitContainer5.ResumeLayout(false);
            splitContainer6.Panel2.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)splitContainer6).EndInit();
            splitContainer6.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)splitContainer7).EndInit();
            splitContainer7.ResumeLayout(false);
            panel2.ResumeLayout(false);
            ResumeLayout(false);
        }

        #endregion
        private GroupBox groupBox1;
        private Label label2;
        private Label label1;
        private Panel panel1;
        private Label dow7;
        private Label dow6;
        private Label dow5;
        private Label dow4;
        private Label label5;
        private Label dow3;
        private Label dow2;
        private SplitContainer splitContainer2;
        private SplitContainer splitContainer3;
        private SplitContainer splitContainer4;
        private SplitContainer splitContainer5;
        private SplitContainer splitContainer6;
        private SplitContainer splitContainer7;
        private Button button2;
        private ComboBox comboBox1;
        private Label label3;
        private ListBox listBox1;
        private Button button3;
        private Panel panel2;
    }
}