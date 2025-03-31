namespace ChessBoardGUIApp
{
    partial class frmChessBoard
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
            panelChessBoard = new Panel();
            lblPieceName = new Label();
            comboPieceNames = new ComboBox();
            groupBox1 = new GroupBox();
            radioButton1 = new RadioButton();
            radioButton2 = new RadioButton();
            radioButton3 = new RadioButton();
            groupBox1.SuspendLayout();
            SuspendLayout();
            // 
            // panelChessBoard
            // 
            panelChessBoard.Location = new Point(12, 21);
            panelChessBoard.Name = "panelChessBoard";
            panelChessBoard.Size = new Size(500, 500);
            panelChessBoard.TabIndex = 0;
            // 
            // lblPieceName
            // 
            lblPieceName.AutoSize = true;
            lblPieceName.Location = new Point(537, 21);
            lblPieceName.Name = "lblPieceName";
            lblPieceName.Size = new Size(50, 20);
            lblPieceName.TabIndex = 1;
            lblPieceName.Text = "label1";
            // 
            // comboPieceNames
            // 
            comboPieceNames.DropDownStyle = ComboBoxStyle.DropDownList;
            comboPieceNames.FormattingEnabled = true;
            comboPieceNames.Items.AddRange(new object[] { "Bishop", "King", "Knight", "Queen", "Rook", "Pawn" });
            comboPieceNames.Location = new Point(593, 21);
            comboPieceNames.Name = "comboPieceNames";
            comboPieceNames.Size = new Size(151, 28);
            comboPieceNames.TabIndex = 2;
            // 
            // groupBox1
            // 
            groupBox1.Controls.Add(radioButton3);
            groupBox1.Controls.Add(radioButton2);
            groupBox1.Controls.Add(radioButton1);
            groupBox1.Location = new Point(537, 112);
            groupBox1.Name = "groupBox1";
            groupBox1.Size = new Size(250, 125);
            groupBox1.TabIndex = 3;
            groupBox1.TabStop = false;
            groupBox1.Text = "Color Theme";
            // 
            // radioButton1
            // 
            radioButton1.AutoSize = true;
            radioButton1.Location = new Point(6, 26);
            radioButton1.Name = "radioButton1";
            radioButton1.Size = new Size(107, 24);
            radioButton1.TabIndex = 0;
            radioButton1.TabStop = true;
            radioButton1.Text = "Cool Colors";
            radioButton1.UseVisualStyleBackColor = true;
            // 
            // radioButton2
            // 
            radioButton2.AutoSize = true;
            radioButton2.Location = new Point(6, 56);
            radioButton2.Name = "radioButton2";
            radioButton2.Size = new Size(115, 24);
            radioButton2.TabIndex = 1;
            radioButton2.TabStop = true;
            radioButton2.Text = "Warm Colors";
            radioButton2.UseVisualStyleBackColor = true;
            // 
            // radioButton3
            // 
            radioButton3.AutoSize = true;
            radioButton3.Location = new Point(6, 86);
            radioButton3.Name = "radioButton3";
            radioButton3.Size = new Size(107, 24);
            radioButton3.TabIndex = 2;
            radioButton3.TabStop = true;
            radioButton3.Text = "Wild Colors";
            radioButton3.UseVisualStyleBackColor = true;
            // 
            // frmChessBoard
            // 
            AutoScaleDimensions = new SizeF(8F, 20F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(800, 651);
            Controls.Add(groupBox1);
            Controls.Add(comboPieceNames);
            Controls.Add(lblPieceName);
            Controls.Add(panelChessBoard);
            Name = "frmChessBoard";
            Text = "Form1";
            groupBox1.ResumeLayout(false);
            groupBox1.PerformLayout();
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private Panel panelChessBoard;
        private Label lblPieceName;
        private ComboBox comboPieceNames;
        private GroupBox groupBox1;
        private RadioButton radioButton3;
        private RadioButton radioButton2;
        private RadioButton radioButton1;
    }
}
