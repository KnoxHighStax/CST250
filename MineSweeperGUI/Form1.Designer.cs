namespace MineSweeperGUI
{
    partial class Form1
    {
        /// <summary>
        ///  Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        ///  Clean up any resources being used.
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
        ///  Required method for Designer support - do not modify
        ///  the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            panel1 = new Panel();
            lblStartTime = new Label();
            lblTime = new Label();
            lblScore = new Label();
            lblTotalScore = new Label();
            btnRestart = new Button();
            SuspendLayout();
            // 
            // panel1
            // 
            panel1.Location = new Point(4, 5);
            panel1.Name = "panel1";
            panel1.Size = new Size(773, 644);
            panel1.TabIndex = 0;
            // 
            // lblStartTime
            // 
            lblStartTime.AutoSize = true;
            lblStartTime.Location = new Point(777, 58);
            lblStartTime.Name = "lblStartTime";
            lblStartTime.Size = new Size(74, 20);
            lblStartTime.TabIndex = 1;
            lblStartTime.Text = "Start time";
            // 
            // lblTime
            // 
            lblTime.AutoSize = true;
            lblTime.Location = new Point(783, 84);
            lblTime.Name = "lblTime";
            lblTime.Size = new Size(50, 20);
            lblTime.TabIndex = 2;
            lblTime.Text = "label1";
            // 
            // lblScore
            // 
            lblScore.AutoSize = true;
            lblScore.Location = new Point(777, 171);
            lblScore.Name = "lblScore";
            lblScore.Size = new Size(46, 20);
            lblScore.TabIndex = 3;
            lblScore.Text = "Score";
            // 
            // lblTotalScore
            // 
            lblTotalScore.AutoSize = true;
            lblTotalScore.Location = new Point(777, 206);
            lblTotalScore.Name = "lblTotalScore";
            lblTotalScore.Size = new Size(50, 20);
            lblTotalScore.TabIndex = 4;
            lblTotalScore.Text = "label3";
            // 
            // btnRestart
            // 
            btnRestart.Location = new Point(817, 249);
            btnRestart.Name = "btnRestart";
            btnRestart.Size = new Size(94, 29);
            btnRestart.TabIndex = 5;
            btnRestart.Text = "Restart";
            btnRestart.UseVisualStyleBackColor = true;
            btnRestart.Click += btnRestart_Click;
            // 
            // Form1
            // 
            AutoScaleDimensions = new SizeF(8F, 20F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(1004, 718);
            Controls.Add(btnRestart);
            Controls.Add(lblTotalScore);
            Controls.Add(lblScore);
            Controls.Add(lblTime);
            Controls.Add(lblStartTime);
            Controls.Add(panel1);
            Name = "Form1";
            Text = "Form1";
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private Panel panel1;
        private Label lblStartTime;
        private Label lblTime;
        private Label lblScore;
        private Label lblTotalScore;
        private Button btnRestart;
    }
}
