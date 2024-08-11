namespace Schedule_Timetable_For_Huster
{
    partial class SetCoefficient
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(SetCoefficient));
            label1 = new Label();
            groupBox1 = new GroupBox();
            label3 = new Label();
            comboBox1 = new ComboBox();
            button1 = new Button();
            button2 = new Button();
            groupBox1.SuspendLayout();
            SuspendLayout();
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.Location = new Point(14, 15);
            label1.Margin = new Padding(5, 0, 5, 0);
            label1.Name = "label1";
            label1.Size = new Size(130, 29);
            label1.TabIndex = 0;
            label1.Text = "Coefficient:";
            // 
            // groupBox1
            // 
            groupBox1.Controls.Add(label3);
            groupBox1.Location = new Point(14, 97);
            groupBox1.Name = "groupBox1";
            groupBox1.Size = new Size(660, 328);
            groupBox1.TabIndex = 4;
            groupBox1.TabStop = false;
            groupBox1.Text = "Help";
            // 
            // label3
            // 
            label3.Dock = DockStyle.Fill;
            label3.Location = new Point(3, 32);
            label3.Name = "label3";
            label3.Size = new Size(654, 293);
            label3.TabIndex = 0;
            label3.Text = resources.GetString("label3.Text");
            // 
            // comboBox1
            // 
            comboBox1.FormattingEnabled = true;
            comboBox1.Items.AddRange(new object[] { "inf" });
            comboBox1.Location = new Point(152, 12);
            comboBox1.Name = "comboBox1";
            comboBox1.Size = new Size(125, 37);
            comboBox1.TabIndex = 0;
            comboBox1.Text = "0";
            // 
            // button1
            // 
            button1.Location = new Point(21, 55);
            button1.Name = "button1";
            button1.Size = new Size(125, 36);
            button1.TabIndex = 6;
            button1.Text = "Complete";
            button1.UseVisualStyleBackColor = true;
            button1.Click += button1_Click;
            // 
            // button2
            // 
            button2.Location = new Point(152, 55);
            button2.Name = "button2";
            button2.Size = new Size(125, 36);
            button2.TabIndex = 7;
            button2.Text = "Cancel";
            button2.UseVisualStyleBackColor = true;
            button2.Click += button2_Click;
            // 
            // SetCoefficient
            // 
            AutoScaleDimensions = new SizeF(14F, 29F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(682, 433);
            Controls.Add(button2);
            Controls.Add(button1);
            Controls.Add(comboBox1);
            Controls.Add(groupBox1);
            Controls.Add(label1);
            Font = new Font("Times New Roman", 15F, FontStyle.Regular, GraphicsUnit.Point, 0);
            Margin = new Padding(5, 4, 5, 4);
            Name = "SetCoefficient";
            Text = "Set Coefficient";
            groupBox1.ResumeLayout(false);
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private Label label1;
        private GroupBox groupBox1;
        private Label label3;
        private ComboBox comboBox1;
        private Button button1;
        private Button button2;
    }
}