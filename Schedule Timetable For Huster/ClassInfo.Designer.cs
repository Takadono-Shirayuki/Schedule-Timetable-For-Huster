namespace Schedule_Timetable_For_Huster
{
    partial class ClassInfo
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
            label1 = new Label();
            label2 = new Label();
            label3 = new Label();
            label4 = new Label();
            label5 = new Label();
            label6 = new Label();
            label7 = new Label();
            label8 = new Label();
            label9 = new Label();
            label10 = new Label();
            label11 = new Label();
            button1 = new Button();
            button2 = new Button();
            button3 = new Button();
            SuspendLayout();
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.Location = new Point(12, 18);
            label1.Name = "label1";
            label1.Size = new Size(127, 29);
            label1.TabIndex = 0;
            label1.Text = "Class code:";
            // 
            // label2
            // 
            label2.AutoSize = true;
            label2.Location = new Point(12, 60);
            label2.Name = "label2";
            label2.Size = new Size(218, 29);
            label2.TabIndex = 1;
            label2.Text = "Attached class code:";
            // 
            // label3
            // 
            label3.AutoSize = true;
            label3.Location = new Point(12, 102);
            label3.Name = "label3";
            label3.Size = new Size(145, 29);
            label3.TabIndex = 2;
            label3.Text = "Course code:";
            // 
            // label4
            // 
            label4.AutoSize = true;
            label4.Location = new Point(12, 144);
            label4.Name = "label4";
            label4.Size = new Size(152, 29);
            label4.TabIndex = 3;
            label4.Text = "Course name:";
            // 
            // label5
            // 
            label5.AutoSize = true;
            label5.Location = new Point(432, 18);
            label5.Name = "label5";
            label5.Size = new Size(146, 29);
            label5.TabIndex = 4;
            label5.Text = "Day of week:";
            // 
            // label6
            // 
            label6.AutoSize = true;
            label6.Location = new Point(432, 60);
            label6.Name = "label6";
            label6.Size = new Size(126, 29);
            label6.TabIndex = 5;
            label6.Text = "Time frane:";
            // 
            // label7
            // 
            label7.AutoSize = true;
            label7.Location = new Point(432, 102);
            label7.Name = "label7";
            label7.Size = new Size(75, 29);
            label7.TabIndex = 6;
            label7.Text = "Week:";
            // 
            // label8
            // 
            label8.AutoSize = true;
            label8.Location = new Point(12, 186);
            label8.Name = "label8";
            label8.Size = new Size(62, 29);
            label8.TabIndex = 7;
            label8.Text = "Note";
            // 
            // label9
            // 
            label9.AutoSize = true;
            label9.Location = new Point(432, 186);
            label9.Name = "label9";
            label9.Size = new Size(204, 29);
            label9.TabIndex = 8;
            label9.Text = "Management code:";
            // 
            // label10
            // 
            label10.AutoSize = true;
            label10.Location = new Point(12, 228);
            label10.Name = "label10";
            label10.Size = new Size(130, 29);
            label10.TabIndex = 9;
            label10.Text = "Coefficient:";
            // 
            // label11
            // 
            label11.AutoSize = true;
            label11.Location = new Point(432, 228);
            label11.Name = "label11";
            label11.Size = new Size(81, 29);
            label11.TabIndex = 10;
            label11.Text = "Status:";
            // 
            // button1
            // 
            button1.Location = new Point(261, 277);
            button1.Name = "button1";
            button1.Size = new Size(204, 37);
            button1.TabIndex = 11;
            button1.Text = "Change coeficient";
            button1.UseVisualStyleBackColor = true;
            button1.Click += button1_Click;
            // 
            // button2
            // 
            button2.Location = new Point(695, 276);
            button2.Name = "button2";
            button2.Size = new Size(126, 37);
            button2.TabIndex = 14;
            button2.Text = "Close";
            button2.UseVisualStyleBackColor = true;
            button2.Click += button2_Click;
            // 
            // button3
            // 
            button3.Location = new Point(471, 276);
            button3.Name = "button3";
            button3.Size = new Size(218, 37);
            button3.TabIndex = 13;
            button3.Text = "Eliminate this class";
            button3.UseVisualStyleBackColor = true;
            button3.Click += button3_Click;
            // 
            // ClassInfo
            // 
            AutoScaleDimensions = new SizeF(14F, 29F);
            AutoScaleMode = AutoScaleMode.Font;
            BackColor = Color.White;
            ClientSize = new Size(833, 325);
            Controls.Add(button3);
            Controls.Add(button2);
            Controls.Add(button1);
            Controls.Add(label11);
            Controls.Add(label10);
            Controls.Add(label9);
            Controls.Add(label8);
            Controls.Add(label7);
            Controls.Add(label6);
            Controls.Add(label5);
            Controls.Add(label4);
            Controls.Add(label3);
            Controls.Add(label2);
            Controls.Add(label1);
            Font = new Font("Times New Roman", 15F, FontStyle.Regular, GraphicsUnit.Point, 0);
            Margin = new Padding(5, 4, 5, 4);
            Name = "ClassInfo";
            Text = "Class info";
            Load += ClassInfo_Load;
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private Label label1;
        private Label label2;
        private Label label3;
        private Label label4;
        private Label label5;
        private Label label6;
        private Label label7;
        private Label label8;
        private Label label9;
        private Label label10;
        private Label label11;
        private Button button1;
        private Button button2;
        private Button button3;
    }
}