namespace FrmInventory
{
    partial class FrmInventory
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
            groupEntryForm = new GroupBox();
            btnAdd = new Button();
            txtValue = new TextBox();
            txtName = new TextBox();
            label2 = new Label();
            Name = new Label();
            groupBox1 = new GroupBox();
            rdoShowMostValuable = new RadioButton();
            RdoShoowLeastValuable = new RadioButton();
            rdoShowAll = new RadioButton();
            gridInventory = new DataGridView();
            btnSearch = new Button();
            txtSearch = new TextBox();
            menuStrip1 = new MenuStrip();
            fileToolStripMenuItem = new ToolStripMenuItem();
            saveToolStripMenuItem = new ToolStripMenuItem();
            loadToolStripMenuItem = new ToolStripMenuItem();
            exitToolStripMenuItem = new ToolStripMenuItem();
            statusStrip1 = new StatusStrip();
            lblStatistics = new ToolStripStatusLabel();
            groupEntryForm.SuspendLayout();
            groupBox1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)gridInventory).BeginInit();
            menuStrip1.SuspendLayout();
            statusStrip1.SuspendLayout();
            SuspendLayout();
            // 
            // groupEntryForm
            // 
            groupEntryForm.Controls.Add(btnAdd);
            groupEntryForm.Controls.Add(txtValue);
            groupEntryForm.Controls.Add(txtName);
            groupEntryForm.Controls.Add(label2);
            groupEntryForm.Controls.Add(Name);
            groupEntryForm.Location = new Point(12, 33);
            groupEntryForm.Name = "groupEntryForm";
            groupEntryForm.Size = new Size(261, 131);
            groupEntryForm.TabIndex = 0;
            groupEntryForm.TabStop = false;
            groupEntryForm.Text = "Things in my Pocket";
            // 
            // btnAdd
            // 
            btnAdd.Location = new Point(76, 90);
            btnAdd.Name = "btnAdd";
            btnAdd.Size = new Size(94, 29);
            btnAdd.TabIndex = 4;
            btnAdd.Text = "Add";
            btnAdd.UseVisualStyleBackColor = true;
            btnAdd.Click += btnAdd_Click;
            // 
            // txtValue
            // 
            txtValue.Location = new Point(65, 57);
            txtValue.Name = "txtValue";
            txtValue.Size = new Size(174, 27);
            txtValue.TabIndex = 3;
            txtValue.Leave += txtValue_Leave;
            // 
            // txtName
            // 
            txtName.Location = new Point(65, 23);
            txtName.Name = "txtName";
            txtName.Size = new Size(174, 27);
            txtName.TabIndex = 2;
            // 
            // label2
            // 
            label2.AutoSize = true;
            label2.Location = new Point(10, 57);
            label2.Name = "label2";
            label2.Size = new Size(45, 20);
            label2.TabIndex = 1;
            label2.Text = "Value";
            // 
            // Name
            // 
            Name.AutoSize = true;
            Name.Location = new Point(10, 23);
            Name.Name = "Name";
            Name.Size = new Size(49, 20);
            Name.TabIndex = 0;
            Name.Text = "Name";
            // 
            // groupBox1
            // 
            groupBox1.Controls.Add(rdoShowMostValuable);
            groupBox1.Controls.Add(RdoShoowLeastValuable);
            groupBox1.Controls.Add(rdoShowAll);
            groupBox1.Location = new Point(22, 170);
            groupBox1.Name = "groupBox1";
            groupBox1.Size = new Size(160, 125);
            groupBox1.TabIndex = 1;
            groupBox1.TabStop = false;
            groupBox1.Text = "Filter and Sort";
            // 
            // rdoShowMostValuable
            // 
            rdoShowMostValuable.AutoSize = true;
            rdoShowMostValuable.Location = new Point(10, 86);
            rdoShowMostValuable.Name = "rdoShowMostValuable";
            rdoShowMostValuable.Size = new Size(135, 24);
            rdoShowMostValuable.TabIndex = 2;
            rdoShowMostValuable.Text = "3 most valuable";
            rdoShowMostValuable.UseVisualStyleBackColor = true;
            rdoShowMostValuable.CheckedChanged += rdoShowMostValuable_CheckedChanged;
            // 
            // RdoShoowLeastValuable
            // 
            RdoShoowLeastValuable.AutoSize = true;
            RdoShoowLeastValuable.Location = new Point(10, 56);
            RdoShoowLeastValuable.Name = "RdoShoowLeastValuable";
            RdoShoowLeastValuable.Size = new Size(133, 24);
            RdoShoowLeastValuable.TabIndex = 1;
            RdoShoowLeastValuable.Text = "3 least valuable";
            RdoShoowLeastValuable.UseVisualStyleBackColor = true;
            RdoShoowLeastValuable.CheckedChanged += RdoShoowLeastValuable_CheckedChanged;
            // 
            // rdoShowAll
            // 
            rdoShowAll.AutoSize = true;
            rdoShowAll.Location = new Point(10, 26);
            rdoShowAll.Name = "rdoShowAll";
            rdoShowAll.Size = new Size(88, 24);
            rdoShowAll.TabIndex = 0;
            rdoShowAll.Text = "Show All";
            rdoShowAll.UseVisualStyleBackColor = true;
            rdoShowAll.CheckedChanged += rdoShowAll_CheckedChanged;
            // 
            // gridInventory
            // 
            gridInventory.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            gridInventory.Location = new Point(299, 42);
            gridInventory.Name = "gridInventory";
            gridInventory.RowHeadersWidth = 51;
            gridInventory.Size = new Size(489, 298);
            gridInventory.TabIndex = 2;
            gridInventory.CellValidating += gridInventory_CellValidating;
            gridInventory.DataError += gridInventory_DataError;
            // 
            // btnSearch
            // 
            btnSearch.Location = new Point(682, 346);
            btnSearch.Name = "btnSearch";
            btnSearch.Size = new Size(94, 29);
            btnSearch.TabIndex = 3;
            btnSearch.Text = "Search";
            btnSearch.UseVisualStyleBackColor = true;
            btnSearch.Click += btnSearch_Click;
            // 
            // txtSearch
            // 
            txtSearch.Location = new Point(478, 347);
            txtSearch.Name = "txtSearch";
            txtSearch.Size = new Size(198, 27);
            txtSearch.TabIndex = 4;
            txtSearch.TextChanged += txtSearch_TextChanged;
            // 
            // menuStrip1
            // 
            menuStrip1.ImageScalingSize = new Size(20, 20);
            menuStrip1.Items.AddRange(new ToolStripItem[] { fileToolStripMenuItem });
            menuStrip1.Location = new Point(0, 0);
            menuStrip1.Name = "menuStrip1";
            menuStrip1.Size = new Size(800, 28);
            menuStrip1.TabIndex = 5;
            menuStrip1.Text = "menuStrip1";
            // 
            // fileToolStripMenuItem
            // 
            fileToolStripMenuItem.DropDownItems.AddRange(new ToolStripItem[] { saveToolStripMenuItem, loadToolStripMenuItem, exitToolStripMenuItem });
            fileToolStripMenuItem.Name = "fileToolStripMenuItem";
            fileToolStripMenuItem.Size = new Size(46, 24);
            fileToolStripMenuItem.Text = "File";
            // 
            // saveToolStripMenuItem
            // 
            saveToolStripMenuItem.Name = "saveToolStripMenuItem";
            saveToolStripMenuItem.Size = new Size(125, 26);
            saveToolStripMenuItem.Text = "Save";
            saveToolStripMenuItem.Click += saveToolStripMenuItem_Click;
            // 
            // loadToolStripMenuItem
            // 
            loadToolStripMenuItem.Name = "loadToolStripMenuItem";
            loadToolStripMenuItem.Size = new Size(125, 26);
            loadToolStripMenuItem.Text = "Load";
            loadToolStripMenuItem.Click += loadToolStripMenuItem_Click;
            // 
            // exitToolStripMenuItem
            // 
            exitToolStripMenuItem.Name = "exitToolStripMenuItem";
            exitToolStripMenuItem.Size = new Size(125, 26);
            exitToolStripMenuItem.Text = "Exit";
            // 
            // statusStrip1
            // 
            statusStrip1.ImageScalingSize = new Size(20, 20);
            statusStrip1.Items.AddRange(new ToolStripItem[] { lblStatistics });
            statusStrip1.Location = new Point(0, 424);
            statusStrip1.Name = "statusStrip1";
            statusStrip1.Size = new Size(800, 26);
            statusStrip1.TabIndex = 6;
            statusStrip1.Text = "statusStrip1";
            // 
            // lblStatistics
            // 
            lblStatistics.Name = "lblStatistics";
            lblStatistics.Size = new Size(151, 20);
            lblStatistics.Text = "toolStripStatusLabel1";
            // 
            // FrmInventory
            // 
            AutoScaleDimensions = new SizeF(8F, 20F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(800, 450);
            Controls.Add(statusStrip1);
            Controls.Add(txtSearch);
            Controls.Add(btnSearch);
            Controls.Add(gridInventory);
            Controls.Add(groupBox1);
            Controls.Add(groupEntryForm);
            Controls.Add(menuStrip1);
            MainMenuStrip = menuStrip1;
            Text = "Form1";
            Load += FrmInventory_Load;
            groupEntryForm.ResumeLayout(false);
            groupEntryForm.PerformLayout();
            groupBox1.ResumeLayout(false);
            groupBox1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)gridInventory).EndInit();
            menuStrip1.ResumeLayout(false);
            menuStrip1.PerformLayout();
            statusStrip1.ResumeLayout(false);
            statusStrip1.PerformLayout();
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private GroupBox groupEntryForm;
        private Button btnAdd;
        private TextBox txtValue;
        private TextBox txtName;
        private Label label2;
        private Label Name;
        private GroupBox groupBox1;
        private RadioButton rdoShowMostValuable;
        private RadioButton RdoShoowLeastValuable;
        private RadioButton rdoShowAll;
        private DataGridView gridInventory;
        private Button btnSearch;
        private TextBox txtSearch;
        private MenuStrip menuStrip1;
        private ToolStripMenuItem fileToolStripMenuItem;
        private ToolStripMenuItem saveToolStripMenuItem;
        private ToolStripMenuItem loadToolStripMenuItem;
        private ToolStripMenuItem exitToolStripMenuItem;
        private FileIO.RangeTrackBar rangeMinMax;
        private StatusStrip statusStrip1;
        private ToolStripStatusLabel lblStatistics;
    }
}
