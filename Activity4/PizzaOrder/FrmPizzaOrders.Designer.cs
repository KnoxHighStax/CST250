namespace PizzaOrder
{
    partial class FrmPizzaOrders
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
            txtPizzaOrders = new TextBox();
            listPizzas = new ListBox();
            btnAtoZ = new Button();
            btnZtoA = new Button();
            btnDelete = new Button();
            SuspendLayout();
            // 
            // txtPizzaOrders
            // 
            txtPizzaOrders.BackColor = SystemColors.ControlLightLight;
            txtPizzaOrders.Location = new Point(250, 82);
            txtPizzaOrders.Multiline = true;
            txtPizzaOrders.Name = "txtPizzaOrders";
            txtPizzaOrders.ReadOnly = true;
            txtPizzaOrders.ScrollBars = ScrollBars.Horizontal;
            txtPizzaOrders.Size = new Size(440, 356);
            txtPizzaOrders.TabIndex = 0;
            // 
            // listPizzas
            // 
            listPizzas.FormattingEnabled = true;
            listPizzas.Location = new Point(12, 12);
            listPizzas.Name = "listPizzas";
            listPizzas.Size = new Size(232, 424);
            listPizzas.TabIndex = 1;
            listPizzas.SelectedIndexChanged += listPizzas_SelectedIndexChanged;
            // 
            // btnAtoZ
            // 
            btnAtoZ.Location = new Point(277, 34);
            btnAtoZ.Name = "btnAtoZ";
            btnAtoZ.Size = new Size(94, 29);
            btnAtoZ.TabIndex = 2;
            btnAtoZ.Text = "A->Z";
            btnAtoZ.UseVisualStyleBackColor = true;
            btnAtoZ.Click += btnAtoZ_Click;
            // 
            // btnZtoA
            // 
            btnZtoA.Location = new Point(414, 34);
            btnZtoA.Name = "btnZtoA";
            btnZtoA.Size = new Size(94, 29);
            btnZtoA.TabIndex = 3;
            btnZtoA.Text = "Z->A";
            btnZtoA.UseVisualStyleBackColor = true;
            btnZtoA.Click += btnZtoA_Click;
            // 
            // btnDelete
            // 
            btnDelete.Location = new Point(551, 34);
            btnDelete.Name = "btnDelete";
            btnDelete.Size = new Size(94, 29);
            btnDelete.TabIndex = 4;
            btnDelete.Text = "Delete";
            btnDelete.UseVisualStyleBackColor = true;
            btnDelete.Click += btnDelete_Click;
            // 
            // FrmPizzaOrders
            // 
            AutoScaleDimensions = new SizeF(8F, 20F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(693, 450);
            Controls.Add(btnDelete);
            Controls.Add(btnZtoA);
            Controls.Add(btnAtoZ);
            Controls.Add(listPizzas);
            Controls.Add(txtPizzaOrders);
            Name = "FrmPizzaOrders";
            Text = "FrmPizzaOrders";
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private TextBox txtPizzaOrders;
        private ListBox listPizzas;
        private Button btnAtoZ;
        private Button btnZtoA;
        private Button btnDelete;
    }
}