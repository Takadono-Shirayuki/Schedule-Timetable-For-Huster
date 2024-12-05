namespace Schedule_Timetable_For_Huster
{
    partial class TimetableSetting3Help
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(TimetableSetting3Help));
            label3 = new Label();
            button1 = new Button();
            SuspendLayout();
            // 
            // label3
            // 
            label3.Dock = DockStyle.Top;
            label3.Location = new Point(0, 0);
            label3.Margin = new Padding(5, 0, 5, 0);
            label3.Name = "label3";
            label3.Size = new Size(753, 324);
            label3.TabIndex = 1;
            label3.Text = resources.GetString("label3.Text");
            // 
            // button1
            // 
            button1.Location = new Point(325, 327);
            button1.Name = "button1";
            button1.Size = new Size(100, 35);
            button1.TabIndex = 2;
            button1.Text = "Close";
            button1.UseVisualStyleBackColor = true;
            button1.Click += button1_Click;
            // 
            // TimetableSettingHelp
            // 
            AutoScaleDimensions = new SizeF(14F, 29F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(753, 372);
            Controls.Add(button1);
            Controls.Add(label3);
            Font = new Font("Times New Roman", 15F, FontStyle.Regular, GraphicsUnit.Point, 0);
            Margin = new Padding(5, 4, 5, 4);
            Name = "TimetableSettingHelp";
            Text = "Timetable Setting Help";
            ResumeLayout(false);
        }

        #endregion

        private Label label3;
        private Button button1;
    }
}