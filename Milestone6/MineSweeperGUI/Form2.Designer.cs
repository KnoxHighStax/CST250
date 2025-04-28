namespace MineSweeperGUI
{
    partial class FrmStartMenu
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
            groupBoxLevel = new GroupBox();
            radiobtnDifficult = new RadioButton();
            radiobtnMedium = new RadioButton();
            radiobtnEasy = new RadioButton();
            btnPlay = new Button();
            groupBoxLevel.SuspendLayout();
            SuspendLayout();
            // 
            // groupBoxLevel
            // 
            groupBoxLevel.Controls.Add(radiobtnDifficult);
            groupBoxLevel.Controls.Add(radiobtnMedium);
            groupBoxLevel.Controls.Add(radiobtnEasy);
            groupBoxLevel.Location = new Point(29, 12);
            groupBoxLevel.Name = "groupBoxLevel";
            groupBoxLevel.Size = new Size(225, 177);
            groupBoxLevel.TabIndex = 0;
            groupBoxLevel.TabStop = false;
            groupBoxLevel.Text = "Choose a Level";
            // 
            // radiobtnDifficult
            // 
            radiobtnDifficult.AutoSize = true;
            radiobtnDifficult.Location = new Point(74, 129);
            radiobtnDifficult.Name = "radiobtnDifficult";
            radiobtnDifficult.Size = new Size(83, 24);
            radiobtnDifficult.TabIndex = 2;
            radiobtnDifficult.TabStop = true;
            radiobtnDifficult.Text = "Difficult";
            radiobtnDifficult.UseVisualStyleBackColor = true;
            // 
            // radiobtnMedium
            // 
            radiobtnMedium.AutoSize = true;
            radiobtnMedium.Location = new Point(74, 84);
            radiobtnMedium.Name = "radiobtnMedium";
            radiobtnMedium.Size = new Size(85, 24);
            radiobtnMedium.TabIndex = 1;
            radiobtnMedium.TabStop = true;
            radiobtnMedium.Text = "Medium";
            radiobtnMedium.UseVisualStyleBackColor = true;
            // 
            // radiobtnEasy
            // 
            radiobtnEasy.AutoSize = true;
            radiobtnEasy.Location = new Point(74, 39);
            radiobtnEasy.Name = "radiobtnEasy";
            radiobtnEasy.Size = new Size(59, 24);
            radiobtnEasy.TabIndex = 0;
            radiobtnEasy.TabStop = true;
            radiobtnEasy.Text = "Easy";
            radiobtnEasy.UseVisualStyleBackColor = true;
            // 
            // btnPlay
            // 
            btnPlay.BackColor = Color.Red;
            btnPlay.Cursor = Cursors.Hand;
            btnPlay.Location = new Point(94, 195);
            btnPlay.Name = "btnPlay";
            btnPlay.Size = new Size(94, 29);
            btnPlay.TabIndex = 1;
            btnPlay.Text = "Play!";
            btnPlay.UseVisualStyleBackColor = false;
            btnPlay.Click += btnPlay_Click;
            // 
            // FrmStartMenu
            // 
            AutoScaleDimensions = new SizeF(8F, 20F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(294, 233);
            Controls.Add(btnPlay);
            Controls.Add(groupBoxLevel);
            Name = "FrmStartMenu";
            Text = "Start a New Game";
            groupBoxLevel.ResumeLayout(false);
            groupBoxLevel.PerformLayout();
            ResumeLayout(false);
        }

        #endregion

        private GroupBox groupBoxLevel;
        private RadioButton radiobtnEasy;
        private Button btnPlay;
        private RadioButton radiobtnMedium;
        private RadioButton radiobtnDifficult;
    }
}