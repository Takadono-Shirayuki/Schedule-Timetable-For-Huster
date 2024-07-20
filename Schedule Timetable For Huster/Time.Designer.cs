namespace Schedule_Timetable_For_Huster
{
    partial class Time
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

        #region Component Designer generated code

        /// <summary> 
        /// Required method for Designer support - do not modify 
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            TTime = new Label();
            SuspendLayout();
            // 
            // TTime
            // 
            TTime.BackColor = Color.Transparent;
            TTime.Font = new Font("Times New Roman", 12F, FontStyle.Regular, GraphicsUnit.Point, 0);
            TTime.Location = new Point(3, 0);
            TTime.Name = "TTime";
            TTime.Size = new Size(94, 20);
            TTime.TabIndex = 3;
            TTime.Text = "06:45";
            TTime.TextAlign = ContentAlignment.MiddleCenter;
            TTime.Click += TTime_Click;
            // 
            // Time
            // 
            AutoScaleDimensions = new SizeF(8F, 20F);
            AutoScaleMode = AutoScaleMode.Font;
            BackColor = Color.Transparent;
            Controls.Add(TTime);
            Name = "Time";
            Size = new Size(100, 20);
            ResumeLayout(false);
        }

        #endregion

        private Label TTime;
    }
}
