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
            menuStripGame = new MenuStrip();
            gameToolStripMenuItem = new ToolStripMenuItem();
            loadToolStripMenuItem = new ToolStripMenuItem();
            saveToolStripMenuItem = new ToolStripMenuItem();
            menuStripGame.SuspendLayout();
            SuspendLayout();
            // 
            // panel1
            // 
            panel1.Location = new Point(12, 62);
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
            // menuStripGame
            // 
            menuStripGame.ImageScalingSize = new Size(20, 20);
            menuStripGame.Items.AddRange(new ToolStripItem[] { gameToolStripMenuItem });
            menuStripGame.Location = new Point(0, 0);
            menuStripGame.Name = "menuStripGame";
            menuStripGame.Size = new Size(1004, 28);
            menuStripGame.TabIndex = 6;
            menuStripGame.Text = "menuStrip1";
            // 
            // gameToolStripMenuItem
            // 
            gameToolStripMenuItem.DropDownItems.AddRange(new ToolStripItem[] { loadToolStripMenuItem, saveToolStripMenuItem });
            gameToolStripMenuItem.Name = "gameToolStripMenuItem";
            gameToolStripMenuItem.Size = new Size(62, 24);
            gameToolStripMenuItem.Text = "Game";
            // 
            // loadToolStripMenuItem
            // 
            loadToolStripMenuItem.Name = "loadToolStripMenuItem";
            loadToolStripMenuItem.Size = new Size(224, 26);
            loadToolStripMenuItem.Text = "Load";
            loadToolStripMenuItem.Click += loadToolStripMenuItem_Click;
            // 
            // saveToolStripMenuItem
            // 
            saveToolStripMenuItem.Name = "saveToolStripMenuItem";
            saveToolStripMenuItem.Size = new Size(224, 26);
            saveToolStripMenuItem.Text = "Save";
            saveToolStripMenuItem.Click += saveToolStripMenuItem_Click;
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
            Controls.Add(menuStripGame);
            MainMenuStrip = menuStripGame;
            Name = "Form1";
            Text = "Form1";
            menuStripGame.ResumeLayout(false);
            menuStripGame.PerformLayout();
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
        private MenuStrip menuStripGame;
        private ToolStripMenuItem gameToolStripMenuItem;
        private ToolStripMenuItem loadToolStripMenuItem;
        private ToolStripMenuItem saveToolStripMenuItem;
    }
}
