﻿namespace WinFormsApp1
{
    partial class FrmAchievements
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
            listAchievements = new ListBox();
            label1 = new Label();
            SuspendLayout();
            // 
            // listAchievements
            // 
            listAchievements.FormattingEnabled = true;
            listAchievements.Location = new Point(12, 36);
            listAchievements.Name = "listAchievements";
            listAchievements.Size = new Size(281, 404);
            listAchievements.TabIndex = 0;
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.Location = new Point(12, 9);
            label1.Name = "label1";
            label1.Size = new Size(101, 20);
            label1.TabIndex = 1;
            label1.Text = "Achievements";
            // 
            // FrmAchievements
            // 
            AutoScaleDimensions = new SizeF(8F, 20F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(308, 444);
            Controls.Add(label1);
            Controls.Add(listAchievements);
            Name = "FrmAchievements";
            Text = "FrmAchievements";
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private ListBox listAchievements;
        private Label label1;
    }
}