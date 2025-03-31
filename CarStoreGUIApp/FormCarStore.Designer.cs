namespace CarStoreGUIApp
{
    partial class frmCarStore
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
            groupBox1 = new GroupBox();
            txtPrice = new TextBox();
            txtYear = new TextBox();
            txtModel = new TextBox();
            txtMake = new TextBox();
            btnCreate = new Button();
            label4 = new Label();
            label3 = new Label();
            label2 = new Label();
            label1 = new Label();
            groupBox2 = new GroupBox();
            btnSortValue = new Button();
            btnSortYear = new Button();
            btnSortAtoZ = new Button();
            label7 = new Label();
            listInventory = new ListBox();
            groupBox3 = new GroupBox();
            listShoppingCart = new ListBox();
            btnAddtoCart = new Button();
            btnCheckout = new Button();
            label5 = new Label();
            lblTotal = new Label();
            btnSearch = new Button();
            txtSearch = new TextBox();
            btnRemove = new Button();
            groupBox1.SuspendLayout();
            groupBox2.SuspendLayout();
            groupBox3.SuspendLayout();
            SuspendLayout();
            // 
            // groupBox1
            // 
            groupBox1.Controls.Add(txtPrice);
            groupBox1.Controls.Add(txtYear);
            groupBox1.Controls.Add(txtModel);
            groupBox1.Controls.Add(txtMake);
            groupBox1.Controls.Add(btnCreate);
            groupBox1.Controls.Add(label4);
            groupBox1.Controls.Add(label3);
            groupBox1.Controls.Add(label2);
            groupBox1.Controls.Add(label1);
            groupBox1.Location = new Point(10, 18);
            groupBox1.Name = "groupBox1";
            groupBox1.Size = new Size(254, 257);
            groupBox1.TabIndex = 0;
            groupBox1.TabStop = false;
            groupBox1.Text = "Create a Car";
            // 
            // txtPrice
            // 
            txtPrice.Location = new Point(71, 126);
            txtPrice.Name = "txtPrice";
            txtPrice.Size = new Size(177, 27);
            txtPrice.TabIndex = 8;
            // 
            // txtYear
            // 
            txtYear.Location = new Point(71, 93);
            txtYear.Name = "txtYear";
            txtYear.Size = new Size(177, 27);
            txtYear.TabIndex = 7;
            // 
            // txtModel
            // 
            txtModel.Location = new Point(71, 61);
            txtModel.Name = "txtModel";
            txtModel.Size = new Size(177, 27);
            txtModel.TabIndex = 6;
            // 
            // txtMake
            // 
            txtMake.Location = new Point(71, 30);
            txtMake.Name = "txtMake";
            txtMake.Size = new Size(177, 27);
            txtMake.TabIndex = 5;
            // 
            // btnCreate
            // 
            btnCreate.Location = new Point(70, 177);
            btnCreate.Name = "btnCreate";
            btnCreate.Size = new Size(94, 29);
            btnCreate.TabIndex = 4;
            btnCreate.Text = "Create";
            btnCreate.UseVisualStyleBackColor = true;
            btnCreate.Click += BtnCreate_Click;
            // 
            // label4
            // 
            label4.AutoSize = true;
            label4.Location = new Point(17, 129);
            label4.Name = "label4";
            label4.Size = new Size(41, 20);
            label4.TabIndex = 3;
            label4.Text = "Price";
            // 
            // label3
            // 
            label3.AutoSize = true;
            label3.Location = new Point(17, 97);
            label3.Name = "label3";
            label3.Size = new Size(37, 20);
            label3.TabIndex = 2;
            label3.Text = "Year";
            // 
            // label2
            // 
            label2.AutoSize = true;
            label2.Location = new Point(18, 65);
            label2.Name = "label2";
            label2.Size = new Size(52, 20);
            label2.TabIndex = 1;
            label2.Text = "Model";
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.Location = new Point(18, 35);
            label1.Name = "label1";
            label1.Size = new Size(45, 20);
            label1.TabIndex = 0;
            label1.Text = "Make";
            label1.Click += label1_Click;
            // 
            // groupBox2
            // 
            groupBox2.Controls.Add(btnSortValue);
            groupBox2.Controls.Add(btnSortYear);
            groupBox2.Controls.Add(btnSortAtoZ);
            groupBox2.Controls.Add(label7);
            groupBox2.Controls.Add(listInventory);
            groupBox2.Location = new Point(267, 28);
            groupBox2.Name = "groupBox2";
            groupBox2.Size = new Size(226, 398);
            groupBox2.TabIndex = 1;
            groupBox2.TabStop = false;
            groupBox2.Text = "Store Inventory";
            // 
            // btnSortValue
            // 
            btnSortValue.Location = new Point(177, 36);
            btnSortValue.Name = "btnSortValue";
            btnSortValue.Size = new Size(43, 29);
            btnSortValue.TabIndex = 11;
            btnSortValue.Text = "$";
            btnSortValue.UseVisualStyleBackColor = true;
            // 
            // btnSortYear
            // 
            btnSortYear.Location = new Point(111, 36);
            btnSortYear.Name = "btnSortYear";
            btnSortYear.Size = new Size(60, 29);
            btnSortYear.TabIndex = 10;
            btnSortYear.Text = "Year";
            btnSortYear.UseVisualStyleBackColor = true;
            // 
            // btnSortAtoZ
            // 
            btnSortAtoZ.Location = new Point(45, 36);
            btnSortAtoZ.Name = "btnSortAtoZ";
            btnSortAtoZ.Size = new Size(60, 29);
            btnSortAtoZ.TabIndex = 9;
            btnSortAtoZ.Text = "A->Z";
            btnSortAtoZ.UseVisualStyleBackColor = true;
            // 
            // label7
            // 
            label7.AutoSize = true;
            label7.Location = new Point(3, 40);
            label7.Name = "label7";
            label7.Size = new Size(36, 20);
            label7.TabIndex = 9;
            label7.Text = "Sort";
            // 
            // listInventory
            // 
            listInventory.FormattingEnabled = true;
            listInventory.Location = new Point(6, 68);
            listInventory.Name = "listInventory";
            listInventory.Size = new Size(214, 324);
            listInventory.TabIndex = 0;
            // 
            // groupBox3
            // 
            groupBox3.Controls.Add(listShoppingCart);
            groupBox3.Location = new Point(594, 28);
            groupBox3.Name = "groupBox3";
            groupBox3.Size = new Size(194, 321);
            groupBox3.TabIndex = 2;
            groupBox3.TabStop = false;
            groupBox3.Text = "Shopping Cart";
            // 
            // listShoppingCart
            // 
            listShoppingCart.FormattingEnabled = true;
            listShoppingCart.Location = new Point(6, 24);
            listShoppingCart.Name = "listShoppingCart";
            listShoppingCart.Size = new Size(179, 284);
            listShoppingCart.TabIndex = 1;
            // 
            // btnAddtoCart
            // 
            btnAddtoCart.Location = new Point(496, 156);
            btnAddtoCart.Name = "btnAddtoCart";
            btnAddtoCart.Size = new Size(94, 56);
            btnAddtoCart.TabIndex = 3;
            btnAddtoCart.Text = "Add to Cart ->";
            btnAddtoCart.UseVisualStyleBackColor = true;
            btnAddtoCart.Click += BtnAddToCart_Click;
            // 
            // btnCheckout
            // 
            btnCheckout.Location = new Point(655, 365);
            btnCheckout.Name = "btnCheckout";
            btnCheckout.Size = new Size(94, 29);
            btnCheckout.TabIndex = 4;
            btnCheckout.Text = "Checkout";
            btnCheckout.UseVisualStyleBackColor = true;
            btnCheckout.Click += BtnCheckout_Click;
            // 
            // label5
            // 
            label5.AutoSize = true;
            label5.Location = new Point(619, 406);
            label5.Name = "label5";
            label5.Size = new Size(70, 20);
            label5.TabIndex = 9;
            label5.Text = "Car Store";
            // 
            // lblTotal
            // 
            lblTotal.AutoSize = true;
            lblTotal.Location = new Point(729, 406);
            lblTotal.Name = "lblTotal";
            lblTotal.Size = new Size(50, 20);
            lblTotal.TabIndex = 10;
            lblTotal.Text = "label6";
            // 
            // btnSearch
            // 
            btnSearch.Location = new Point(414, 432);
            btnSearch.Name = "btnSearch";
            btnSearch.Size = new Size(94, 29);
            btnSearch.TabIndex = 9;
            btnSearch.Text = "Search";
            btnSearch.UseVisualStyleBackColor = true;
            btnSearch.Click += btnSearch_Click;
            // 
            // txtSearch
            // 
            txtSearch.Location = new Point(231, 434);
            txtSearch.Name = "txtSearch";
            txtSearch.Size = new Size(177, 27);
            txtSearch.TabIndex = 9;
            // 
            // btnRemove
            // 
            btnRemove.Location = new Point(666, 444);
            btnRemove.Name = "btnRemove";
            btnRemove.Size = new Size(94, 29);
            btnRemove.TabIndex = 11;
            btnRemove.Text = "Remove";
            btnRemove.UseVisualStyleBackColor = true;
            btnRemove.Click += btnRemove_Click;
            // 
            // frmCarStore
            // 
            AutoScaleDimensions = new SizeF(8F, 20F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(800, 492);
            Controls.Add(btnRemove);
            Controls.Add(txtSearch);
            Controls.Add(btnSearch);
            Controls.Add(lblTotal);
            Controls.Add(label5);
            Controls.Add(btnCheckout);
            Controls.Add(btnAddtoCart);
            Controls.Add(groupBox3);
            Controls.Add(groupBox2);
            Controls.Add(groupBox1);
            Name = "frmCarStore";
            Text = "Car Store";
            groupBox1.ResumeLayout(false);
            groupBox1.PerformLayout();
            groupBox2.ResumeLayout(false);
            groupBox2.PerformLayout();
            groupBox3.ResumeLayout(false);
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private GroupBox groupBox1;
        private TextBox txtPrice;
        private TextBox txtYear;
        private TextBox txtModel;
        private TextBox txtMake;
        private Button btnCreate;
        private Label label4;
        private Label label3;
        private Label label2;
        private Label label1;
        private GroupBox groupBox2;
        private ListBox listInventory;
        private GroupBox groupBox3;
        private ListBox listShoppingCart;
        private Button btnAddtoCart;
        private Button btnCheckout;
        private Label label5;
        private Label lblTotal;
        private Button btnSortValue;
        private Button btnSortYear;
        private Button btnSortAtoZ;
        private Label label7;
        private Button btnSearch;
        private TextBox txtSearch;
        private Button btnRemove;
    }
}
