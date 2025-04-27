namespace WhackAMole
{
    partial class FrmGame
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
            components = new System.ComponentModel.Container();
            lblTime = new Label();
            btnStart = new Button();
            btnStop = new Button();
            btnReset = new Button();
            timeMoveTarget = new System.Windows.Forms.Timer(components);
            SuspendLayout();
            // 
            // lblTime
            // 
            lblTime.AutoSize = true;
            lblTime.Location = new Point(175, 9);
            lblTime.Name = "lblTime";
            lblTime.Size = new Size(50, 20);
            lblTime.TabIndex = 0;
            lblTime.Text = "label1";
            // 
            // btnStart
            // 
            btnStart.Location = new Point(158, 278);
            btnStart.Name = "btnStart";
            btnStart.Size = new Size(94, 29);
            btnStart.TabIndex = 1;
            btnStart.Text = "Start";
            btnStart.UseVisualStyleBackColor = true;
            btnStart.Click += btnStart_Click;
            // 
            // btnStop
            // 
            btnStop.Location = new Point(158, 313);
            btnStop.Name = "btnStop";
            btnStop.Size = new Size(94, 29);
            btnStop.TabIndex = 2;
            btnStop.Text = "Stop";
            btnStop.UseVisualStyleBackColor = true;
            btnStop.Click += btnStop_Click;
            // 
            // btnReset
            // 
            btnReset.Location = new Point(158, 348);
            btnReset.Name = "btnReset";
            btnReset.Size = new Size(94, 29);
            btnReset.TabIndex = 3;
            btnReset.Text = "Reset";
            btnReset.UseVisualStyleBackColor = true;
            btnReset.Click += btnReset_Click;
            // 
            // timeMoveTarget
            // 
            timeMoveTarget.Enabled = true;
            timeMoveTarget.Interval = 1000;
            timeMoveTarget.Tick += TimeMoveTarget_Tick;
            // 
            // FrmGame
            // 
            AutoScaleDimensions = new SizeF(8F, 20F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(466, 413);
            Controls.Add(btnReset);
            Controls.Add(btnStop);
            Controls.Add(btnStart);
            Controls.Add(lblTime);
            Name = "FrmGame";
            Text = "Form1";
            Paint += FrmGame_Paint;
            MouseClick += FrmGame_MouseClick;
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private Label lblTime;
        private Button btnStart;
        private Button btnStop;
        private Button btnReset;
        private System.Windows.Forms.Timer timeMoveTarget;
    }
}
