namespace WinFormsApp1
{
    partial class FrmNameEntry
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
            lblName = new Label();
            txtName = new TextBox();
            btnOK = new Button();
            SuspendLayout();
            // 
            // lblName
            // 
            lblName.AutoSize = true;
            lblName.Location = new Point(12, 9);
            lblName.Name = "lblName";
            lblName.Size = new Size(117, 20);
            lblName.TabIndex = 0;
            lblName.Text = "Enter your name";
            // 
            // txtName
            // 
            txtName.Location = new Point(12, 32);
            txtName.Name = "txtName";
            txtName.Size = new Size(284, 27);
            txtName.TabIndex = 1;
            // 
            // btnOK
            // 
            btnOK.Location = new Point(99, 76);
            btnOK.Name = "btnOK";
            btnOK.Size = new Size(94, 29);
            btnOK.TabIndex = 2;
            btnOK.Text = "Ok";
            btnOK.UseVisualStyleBackColor = true;
            btnOK.Click += btnOK_Click;
            // 
            // FrmNameEntry
            // 
            AutoScaleDimensions = new SizeF(8F, 20F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(309, 117);
            Controls.Add(btnOK);
            Controls.Add(txtName);
            Controls.Add(lblName);
            Name = "FrmNameEntry";
            Text = "FrmNameEntry";
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private Label lblName;
        private TextBox txtName;
        private Button btnOK;
    }
}