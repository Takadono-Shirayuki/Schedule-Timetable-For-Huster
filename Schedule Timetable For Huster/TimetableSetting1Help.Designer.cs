namespace Schedule_Timetable_For_Huster
{
    partial class TimetableSetting1Help
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(TimetableSetting1Help));
            label3 = new Label();
            button1 = new Button();
            SuspendLayout();
            // 
            // label3
            // 
            label3.Dock = DockStyle.Top;
            label3.Location = new Point(0, 0);
            label3.Margin = new Padding(9, 0, 9, 0);
            label3.Name = "label3";
            label3.Size = new Size(582, 211);
            label3.TabIndex = 2;
            label3.Text = resources.GetString("label3.Text");
            // 
            // button1
            // 
            button1.Location = new Point(240, 214);
            button1.Name = "button1";
            button1.Size = new Size(100, 36);
            button1.TabIndex = 3;
            button1.Text = "Close";
            button1.UseVisualStyleBackColor = true;
            // 
            // TimetableSetting1Help
            // 
            AutoScaleDimensions = new SizeF(14F, 29F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(582, 260);
            Controls.Add(button1);
            Controls.Add(label3);
            Font = new Font("Times New Roman", 15F, FontStyle.Regular, GraphicsUnit.Point, 0);
            Margin = new Padding(5, 4, 5, 4);
            Name = "TimetableSetting1Help";
            Text = "TimetableSetting1Help";
            Load += TimetableSetting1Help_Load;
            ResumeLayout(false);
        }

        #endregion

        private Label label3;
        private Button button1;
    }
}