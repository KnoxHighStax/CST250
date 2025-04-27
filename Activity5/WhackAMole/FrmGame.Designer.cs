namespace WinFormsApp1
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(FrmGame));
            lblTime = new Label();
            btnStart = new Button();
            btnStop = new Button();
            btnReset = new Button();
            btnTarget = new Button();
            timeMoveTarget = new System.Windows.Forms.Timer(components);
            lblScore = new Label();
            btnBomb = new Button();
            btnAchievements = new Button();
            SuspendLayout();
            // 
            // lblTime
            // 
            lblTime.AutoSize = true;
            lblTime.BackColor = SystemColors.ActiveCaptionText;
            lblTime.ForeColor = SystemColors.ControlLightLight;
            lblTime.Location = new Point(12, 9);
            lblTime.Name = "lblTime";
            lblTime.Size = new Size(63, 20);
            lblTime.TabIndex = 0;
            lblTime.Text = "00:00:00";
            // 
            // btnStart
            // 
            btnStart.Anchor = AnchorStyles.Bottom | AnchorStyles.Left;
            btnStart.AutoSize = true;
            btnStart.BackColor = Color.DarkSlateBlue;
            btnStart.ForeColor = SystemColors.ControlLightLight;
            btnStart.Location = new Point(89, 416);
            btnStart.Name = "btnStart";
            btnStart.Size = new Size(94, 30);
            btnStart.TabIndex = 1;
            btnStart.Text = "Start";
            btnStart.UseVisualStyleBackColor = false;
            // 
            // btnStop
            // 
            btnStop.Anchor = AnchorStyles.Bottom;
            btnStop.AutoSize = true;
            btnStop.BackColor = Color.DarkSlateBlue;
            btnStop.ForeColor = SystemColors.ControlLightLight;
            btnStop.Location = new Point(189, 415);
            btnStop.Name = "btnStop";
            btnStop.Size = new Size(94, 30);
            btnStop.TabIndex = 2;
            btnStop.Text = "Stop";
            btnStop.UseVisualStyleBackColor = false;
            // 
            // btnReset
            // 
            btnReset.Anchor = AnchorStyles.Bottom | AnchorStyles.Right;
            btnReset.AutoSize = true;
            btnReset.BackColor = Color.DarkSlateBlue;
            btnReset.ForeColor = SystemColors.ControlLightLight;
            btnReset.Location = new Point(291, 415);
            btnReset.Name = "btnReset";
            btnReset.Size = new Size(94, 30);
            btnReset.TabIndex = 3;
            btnReset.Text = "Reset";
            btnReset.UseVisualStyleBackColor = false;
            // 
            // btnTarget
            // 
            btnTarget.Location = new Point(150, 163);
            btnTarget.Name = "btnTarget";
            btnTarget.Size = new Size(68, 65);
            btnTarget.TabIndex = 4;
            btnTarget.Text = "Target";
            btnTarget.UseVisualStyleBackColor = true;
            btnTarget.Click += btnTarget_Click;
            // 
            // timeMoveTarget
            // 
            timeMoveTarget.Enabled = true;
            timeMoveTarget.Interval = 1000;
            timeMoveTarget.Tick += timeMoveTarget_Tick_1;
            // 
            // lblScore
            // 
            lblScore.Anchor = AnchorStyles.Top | AnchorStyles.Right;
            lblScore.AutoSize = true;
            lblScore.BackColor = SystemColors.ControlLightLight;
            lblScore.Location = new Point(693, 9);
            lblScore.Name = "lblScore";
            lblScore.Size = new Size(49, 20);
            lblScore.TabIndex = 5;
            lblScore.Text = "Score:";
            // 
            // btnBomb
            // 
            btnBomb.BackColor = Color.IndianRed;
            btnBomb.Location = new Point(341, 252);
            btnBomb.Name = "btnBomb";
            btnBomb.Size = new Size(62, 63);
            btnBomb.TabIndex = 6;
            btnBomb.Text = "Decoy";
            btnBomb.UseVisualStyleBackColor = false;
            btnBomb.Click += btnBomb_Click;
            // 
            // btnAchievements
            // 
            btnAchievements.BackColor = Color.SlateBlue;
            btnAchievements.Location = new Point(671, 417);
            btnAchievements.Name = "btnAchievements";
            btnAchievements.Size = new Size(117, 29);
            btnAchievements.TabIndex = 7;
            btnAchievements.Text = "Achievements";
            btnAchievements.UseCompatibleTextRendering = true;
            btnAchievements.UseVisualStyleBackColor = false;
            btnAchievements.Click += btnAchievements_Click;
            // 
            // FrmGame
            // 
            AutoScaleDimensions = new SizeF(8F, 20F);
            AutoScaleMode = AutoScaleMode.Font;
            BackgroundImage = (Image)resources.GetObject("$this.BackgroundImage");
            BackgroundImageLayout = ImageLayout.Stretch;
            ClientSize = new Size(800, 450);
            Controls.Add(btnAchievements);
            Controls.Add(btnBomb);
            Controls.Add(lblScore);
            Controls.Add(btnTarget);
            Controls.Add(btnReset);
            Controls.Add(btnStop);
            Controls.Add(btnStart);
            Controls.Add(lblTime);
            Name = "FrmGame";
            Text = "Form1";
            Click += FrmGame_Click;
            Paint += FrmGame_Paint;
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private Label lblTime;
        private Button btnStart;
        private Button btnStop;
        private Button btnReset;
        private Button btnTarget;
        private System.Windows.Forms.Timer timeMoveTarget;
        private Label lblScore;
        private Button btnBomb;
        private Button btnAchievements;
    }
}
