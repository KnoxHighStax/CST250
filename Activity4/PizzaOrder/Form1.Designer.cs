namespace PizzaOrder
{
    partial class FrmPizzaList
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
            label1 = new Label();
            txtName = new TextBox();
            Ingredients = new GroupBox();
            chk_ham = new CheckBox();
            chk_pepperroni = new CheckBox();
            chk_bellpeppers = new CheckBox();
            chk_peppers = new CheckBox();
            chk_tomatoes = new CheckBox();
            chk_sausage = new CheckBox();
            chk_bacon = new CheckBox();
            chk_cheese = new CheckBox();
            label2 = new Label();
            list_StrangeThings = new ListBox();
            groupBox1 = new GroupBox();
            radio_BtnStuffedCrust = new RadioButton();
            radio_BtnDeepDish = new RadioButton();
            radio_BtnHandTossed = new RadioButton();
            radio_BtnThinCrust = new RadioButton();
            groupBox2 = new GroupBox();
            lblParmesanCheese = new Label();
            lblGarlic = new Label();
            lblSauce = new Label();
            label8 = new Label();
            label7 = new Label();
            label6 = new Label();
            label5 = new Label();
            label4 = new Label();
            label3 = new Label();
            hScrollBarParmesanCheese = new HScrollBar();
            hScrollBarGarlic = new HScrollBar();
            hScrollBarSauce = new HScrollBar();
            trkCookedLevel = new TrackBar();
            label10 = new Label();
            label11 = new Label();
            listColor = new ListView();
            groupBox3 = new GroupBox();
            timeOrderReady = new DateTimePicker();
            numericUpDownHunger = new NumericUpDown();
            groupBox4 = new GroupBox();
            pictureBoxPizza = new PictureBox();
            button2 = new Button();
            btnReset_Click = new Button();
            lblLightlyCooked = new Label();
            lblNormal = new Label();
            lblWellDone = new Label();
            Ingredients.SuspendLayout();
            groupBox1.SuspendLayout();
            groupBox2.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)trkCookedLevel).BeginInit();
            groupBox3.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)numericUpDownHunger).BeginInit();
            groupBox4.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)pictureBoxPizza).BeginInit();
            SuspendLayout();
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.Location = new Point(11, 7);
            label1.Name = "label1";
            label1.Size = new Size(146, 20);
            label1.TabIndex = 0;
            label1.Text = "Name for the Order?";
            // 
            // txtName
            // 
            txtName.BackColor = SystemColors.Info;
            txtName.Location = new Point(165, 5);
            txtName.Name = "txtName";
            txtName.Size = new Size(228, 27);
            txtName.TabIndex = 1;
            // 
            // Ingredients
            // 
            Ingredients.Controls.Add(chk_ham);
            Ingredients.Controls.Add(chk_pepperroni);
            Ingredients.Controls.Add(chk_bellpeppers);
            Ingredients.Controls.Add(chk_peppers);
            Ingredients.Controls.Add(chk_tomatoes);
            Ingredients.Controls.Add(chk_sausage);
            Ingredients.Controls.Add(chk_bacon);
            Ingredients.Controls.Add(chk_cheese);
            Ingredients.Location = new Point(16, 34);
            Ingredients.Name = "Ingredients";
            Ingredients.Size = new Size(377, 211);
            Ingredients.TabIndex = 2;
            Ingredients.TabStop = false;
            Ingredients.Text = "Ingredients";
            // 
            // chk_ham
            // 
            chk_ham.AutoSize = true;
            chk_ham.Location = new Point(149, 164);
            chk_ham.Name = "chk_ham";
            chk_ham.Size = new Size(63, 24);
            chk_ham.TabIndex = 7;
            chk_ham.Text = "Ham";
            chk_ham.UseVisualStyleBackColor = true;
            // 
            // chk_pepperroni
            // 
            chk_pepperroni.AutoSize = true;
            chk_pepperroni.Location = new Point(149, 123);
            chk_pepperroni.Name = "chk_pepperroni";
            chk_pepperroni.Size = new Size(103, 24);
            chk_pepperroni.TabIndex = 6;
            chk_pepperroni.Text = "Pepperroni";
            chk_pepperroni.UseVisualStyleBackColor = true;
            // 
            // chk_bellpeppers
            // 
            chk_bellpeppers.AutoSize = true;
            chk_bellpeppers.Location = new Point(149, 81);
            chk_bellpeppers.Name = "chk_bellpeppers";
            chk_bellpeppers.Size = new Size(112, 24);
            chk_bellpeppers.TabIndex = 5;
            chk_bellpeppers.Text = "Bell Peppers";
            chk_bellpeppers.UseVisualStyleBackColor = true;
            // 
            // chk_peppers
            // 
            chk_peppers.AutoSize = true;
            chk_peppers.Location = new Point(149, 39);
            chk_peppers.Name = "chk_peppers";
            chk_peppers.Size = new Size(83, 24);
            chk_peppers.TabIndex = 4;
            chk_peppers.Text = "Peppers";
            chk_peppers.UseVisualStyleBackColor = true;
            // 
            // chk_tomatoes
            // 
            chk_tomatoes.AutoSize = true;
            chk_tomatoes.Location = new Point(17, 164);
            chk_tomatoes.Name = "chk_tomatoes";
            chk_tomatoes.Size = new Size(96, 24);
            chk_tomatoes.TabIndex = 3;
            chk_tomatoes.Text = "Tomatoes";
            chk_tomatoes.UseVisualStyleBackColor = true;
            // 
            // chk_sausage
            // 
            chk_sausage.AutoSize = true;
            chk_sausage.Location = new Point(17, 123);
            chk_sausage.Name = "chk_sausage";
            chk_sausage.Size = new Size(86, 24);
            chk_sausage.TabIndex = 2;
            chk_sausage.Text = "Sausage";
            chk_sausage.UseVisualStyleBackColor = true;
            // 
            // chk_bacon
            // 
            chk_bacon.AutoSize = true;
            chk_bacon.Location = new Point(17, 81);
            chk_bacon.Name = "chk_bacon";
            chk_bacon.Size = new Size(72, 24);
            chk_bacon.TabIndex = 1;
            chk_bacon.Text = "Bacon";
            chk_bacon.UseVisualStyleBackColor = true;
            // 
            // chk_cheese
            // 
            chk_cheese.AutoSize = true;
            chk_cheese.Location = new Point(17, 39);
            chk_cheese.Name = "chk_cheese";
            chk_cheese.Size = new Size(78, 24);
            chk_cheese.TabIndex = 0;
            chk_cheese.Text = "Cheese";
            chk_cheese.UseVisualStyleBackColor = true;
            // 
            // label2
            // 
            label2.AutoSize = true;
            label2.Location = new Point(16, 254);
            label2.Name = "label2";
            label2.Size = new Size(121, 20);
            label2.TabIndex = 3;
            label2.Text = "Strange Add Ons";
            // 
            // list_StrangeThings
            // 
            list_StrangeThings.BackColor = SystemColors.Info;
            list_StrangeThings.FormattingEnabled = true;
            list_StrangeThings.Items.AddRange(new object[] { "Anchovies", "Pine Nuts", "Pineapple", "Pickles", "Marshmellow", "Choclate Chips", "Steak", "Olives", "Mushrooms", "Yellow Bell Peppers", "Red Bell Peppers", "Peanut Butter", "Jelly" });
            list_StrangeThings.Location = new Point(21, 281);
            list_StrangeThings.Name = "list_StrangeThings";
            list_StrangeThings.Size = new Size(182, 164);
            list_StrangeThings.TabIndex = 4;
            // 
            // groupBox1
            // 
            groupBox1.Controls.Add(radio_BtnStuffedCrust);
            groupBox1.Controls.Add(radio_BtnDeepDish);
            groupBox1.Controls.Add(radio_BtnHandTossed);
            groupBox1.Controls.Add(radio_BtnThinCrust);
            groupBox1.Location = new Point(209, 264);
            groupBox1.Name = "groupBox1";
            groupBox1.Size = new Size(184, 181);
            groupBox1.TabIndex = 5;
            groupBox1.TabStop = false;
            groupBox1.Text = "Crust";
            // 
            // radio_BtnStuffedCrust
            // 
            radio_BtnStuffedCrust.AutoSize = true;
            radio_BtnStuffedCrust.Location = new Point(15, 136);
            radio_BtnStuffedCrust.Name = "radio_BtnStuffedCrust";
            radio_BtnStuffedCrust.Size = new Size(161, 24);
            radio_BtnStuffedCrust.TabIndex = 3;
            radio_BtnStuffedCrust.Text = "Stuffed with Cheese";
            radio_BtnStuffedCrust.UseVisualStyleBackColor = true;
            // 
            // radio_BtnDeepDish
            // 
            radio_BtnDeepDish.AutoSize = true;
            radio_BtnDeepDish.Location = new Point(15, 102);
            radio_BtnDeepDish.Name = "radio_BtnDeepDish";
            radio_BtnDeepDish.Size = new Size(99, 24);
            radio_BtnDeepDish.TabIndex = 2;
            radio_BtnDeepDish.Text = "Deep Dish";
            radio_BtnDeepDish.UseVisualStyleBackColor = true;
            // 
            // radio_BtnHandTossed
            // 
            radio_BtnHandTossed.AutoSize = true;
            radio_BtnHandTossed.Location = new Point(15, 66);
            radio_BtnHandTossed.Name = "radio_BtnHandTossed";
            radio_BtnHandTossed.Size = new Size(115, 24);
            radio_BtnHandTossed.TabIndex = 1;
            radio_BtnHandTossed.Text = "Hand Tossed";
            radio_BtnHandTossed.UseVisualStyleBackColor = true;
            // 
            // radio_BtnThinCrust
            // 
            radio_BtnThinCrust.AutoSize = true;
            radio_BtnThinCrust.Checked = true;
            radio_BtnThinCrust.Location = new Point(15, 31);
            radio_BtnThinCrust.Name = "radio_BtnThinCrust";
            radio_BtnThinCrust.Size = new Size(95, 24);
            radio_BtnThinCrust.TabIndex = 0;
            radio_BtnThinCrust.TabStop = true;
            radio_BtnThinCrust.Text = "Thin Crust";
            radio_BtnThinCrust.UseVisualStyleBackColor = true;
            // 
            // groupBox2
            // 
            groupBox2.Controls.Add(lblParmesanCheese);
            groupBox2.Controls.Add(lblGarlic);
            groupBox2.Controls.Add(lblSauce);
            groupBox2.Controls.Add(label8);
            groupBox2.Controls.Add(label7);
            groupBox2.Controls.Add(label6);
            groupBox2.Controls.Add(label5);
            groupBox2.Controls.Add(label4);
            groupBox2.Controls.Add(label3);
            groupBox2.Controls.Add(hScrollBarParmesanCheese);
            groupBox2.Controls.Add(hScrollBarGarlic);
            groupBox2.Controls.Add(hScrollBarSauce);
            groupBox2.Location = new Point(21, 451);
            groupBox2.Name = "groupBox2";
            groupBox2.Size = new Size(363, 203);
            groupBox2.TabIndex = 6;
            groupBox2.TabStop = false;
            groupBox2.Text = "Extra Goodies";
            // 
            // lblParmesanCheese
            // 
            lblParmesanCheese.AutoSize = true;
            lblParmesanCheese.Location = new Point(137, 139);
            lblParmesanCheese.Name = "lblParmesanCheese";
            lblParmesanCheese.Size = new Size(17, 20);
            lblParmesanCheese.TabIndex = 11;
            lblParmesanCheese.Text = "0";
            // 
            // lblGarlic
            // 
            lblGarlic.AutoSize = true;
            lblGarlic.Location = new Point(139, 80);
            lblGarlic.Name = "lblGarlic";
            lblGarlic.Size = new Size(17, 20);
            lblGarlic.TabIndex = 10;
            lblGarlic.Text = "0";
            // 
            // lblSauce
            // 
            lblSauce.AutoSize = true;
            lblSauce.Location = new Point(140, 26);
            lblSauce.Name = "lblSauce";
            lblSauce.Size = new Size(17, 20);
            lblSauce.TabIndex = 9;
            lblSauce.Text = "0";
            // 
            // label8
            // 
            label8.AutoSize = true;
            label8.Location = new Point(135, 140);
            label8.Name = "label8";
            label8.Size = new Size(0, 20);
            label8.TabIndex = 8;
            // 
            // label7
            // 
            label7.AutoSize = true;
            label7.Location = new Point(10, 140);
            label7.Name = "label7";
            label7.Size = new Size(123, 20);
            label7.TabIndex = 7;
            label7.Text = "Parmesan Cheese";
            // 
            // label6
            // 
            label6.AutoSize = true;
            label6.Location = new Point(140, 82);
            label6.Name = "label6";
            label6.Size = new Size(0, 20);
            label6.TabIndex = 6;
            // 
            // label5
            // 
            label5.AutoSize = true;
            label5.Location = new Point(7, 81);
            label5.Name = "label5";
            label5.Size = new Size(47, 20);
            label5.TabIndex = 5;
            label5.Text = "Garlic";
            // 
            // label4
            // 
            label4.AutoSize = true;
            label4.Location = new Point(140, 28);
            label4.Name = "label4";
            label4.Size = new Size(0, 20);
            label4.TabIndex = 4;
            // 
            // label3
            // 
            label3.AutoSize = true;
            label3.Location = new Point(7, 26);
            label3.Name = "label3";
            label3.Size = new Size(123, 20);
            label3.TabIndex = 3;
            label3.Text = "Amount of Sauce";
            // 
            // hScrollBarParmesanCheese
            // 
            hScrollBarParmesanCheese.Location = new Point(7, 164);
            hScrollBarParmesanCheese.Name = "hScrollBarParmesanCheese";
            hScrollBarParmesanCheese.Size = new Size(353, 26);
            hScrollBarParmesanCheese.TabIndex = 2;
            hScrollBarParmesanCheese.Scroll += hScroll_ParmesanCheese;
            // 
            // hScrollBarGarlic
            // 
            hScrollBarGarlic.Location = new Point(3, 108);
            hScrollBarGarlic.Name = "hScrollBarGarlic";
            hScrollBarGarlic.Size = new Size(353, 26);
            hScrollBarGarlic.TabIndex = 1;
            hScrollBarGarlic.Scroll += hScroll_Garlic;
            // 
            // hScrollBarSauce
            // 
            hScrollBarSauce.Location = new Point(7, 52);
            hScrollBarSauce.Name = "hScrollBarSauce";
            hScrollBarSauce.Size = new Size(353, 26);
            hScrollBarSauce.TabIndex = 0;
            hScrollBarSauce.Scroll += hScroll_Sauce;
            // 
            // trkCookedLevel
            // 
            trkCookedLevel.Location = new Point(421, 254);
            trkCookedLevel.Name = "trkCookedLevel";
            trkCookedLevel.Size = new Size(343, 56);
            trkCookedLevel.TabIndex = 7;
            trkCookedLevel.Scroll += trkCookedLevel_Scroll;
            // 
            // label10
            // 
            label10.AutoSize = true;
            label10.Location = new Point(404, 173);
            label10.Name = "label10";
            label10.Size = new Size(91, 20);
            label10.TabIndex = 9;
            label10.Text = "Sauce Color:";
            // 
            // label11
            // 
            label11.AutoSize = true;
            label11.Location = new Point(426, 94);
            label11.Name = "label11";
            label11.Size = new Size(96, 20);
            label11.TabIndex = 10;
            label11.Text = "Hunger Level";
            // 
            // listColor
            // 
            listColor.BackColor = Color.Red;
            listColor.ForeColor = Color.Red;
            listColor.Location = new Point(501, 133);
            listColor.Name = "listColor";
            listColor.Size = new Size(263, 60);
            listColor.TabIndex = 11;
            listColor.UseCompatibleStateImageBehavior = false;
            listColor.Click += listColor_Click;
            // 
            // groupBox3
            // 
            groupBox3.Controls.Add(timeOrderReady);
            groupBox3.Location = new Point(426, 14);
            groupBox3.Name = "groupBox3";
            groupBox3.Size = new Size(344, 66);
            groupBox3.TabIndex = 12;
            groupBox3.TabStop = false;
            groupBox3.Text = "Delivery Time";
            // 
            // timeOrderReady
            // 
            timeOrderReady.CalendarForeColor = SystemColors.Info;
            timeOrderReady.CalendarMonthBackground = SystemColors.Info;
            timeOrderReady.Location = new Point(16, 26);
            timeOrderReady.Name = "timeOrderReady";
            timeOrderReady.Size = new Size(322, 27);
            timeOrderReady.TabIndex = 0;
            // 
            // numericUpDownHunger
            // 
            numericUpDownHunger.BackColor = SystemColors.Info;
            numericUpDownHunger.Location = new Point(529, 100);
            numericUpDownHunger.Name = "numericUpDownHunger";
            numericUpDownHunger.Size = new Size(219, 27);
            numericUpDownHunger.TabIndex = 13;
            // 
            // groupBox4
            // 
            groupBox4.Controls.Add(pictureBoxPizza);
            groupBox4.Location = new Point(421, 317);
            groupBox4.Name = "groupBox4";
            groupBox4.Size = new Size(349, 294);
            groupBox4.TabIndex = 14;
            groupBox4.TabStop = false;
            groupBox4.Text = "Visual of Your Creation";
            // 
            // pictureBoxPizza
            // 
            pictureBoxPizza.Location = new Point(6, 26);
            pictureBoxPizza.Name = "pictureBoxPizza";
            pictureBoxPizza.Size = new Size(343, 268);
            pictureBoxPizza.TabIndex = 0;
            pictureBoxPizza.TabStop = false;
            // 
            // button2
            // 
            button2.BackColor = Color.FromArgb(192, 255, 192);
            button2.Location = new Point(606, 626);
            button2.Name = "button2";
            button2.Size = new Size(118, 29);
            button2.TabIndex = 16;
            button2.Text = "Create Pizza!";
            button2.UseVisualStyleBackColor = false;
            button2.Click += click_CreatePizza;
            // 
            // btnReset_Click
            // 
            btnReset_Click.BackColor = Color.FromArgb(255, 192, 192);
            btnReset_Click.Location = new Point(442, 626);
            btnReset_Click.Name = "btnReset_Click";
            btnReset_Click.Size = new Size(100, 29);
            btnReset_Click.TabIndex = 17;
            btnReset_Click.Text = "Reset Form";
            btnReset_Click.UseVisualStyleBackColor = false;
            btnReset_Click.Click += btnReset_Click_Click;
            // 
            // lblLightlyCooked
            // 
            lblLightlyCooked.AutoSize = true;
            lblLightlyCooked.Location = new Point(399, 225);
            lblLightlyCooked.Name = "lblLightlyCooked";
            lblLightlyCooked.Size = new Size(112, 20);
            lblLightlyCooked.TabIndex = 18;
            lblLightlyCooked.Text = "Lightly  Cooked";
            // 
            // lblNormal
            // 
            lblNormal.AutoSize = true;
            lblNormal.Location = new Point(570, 225);
            lblNormal.Name = "lblNormal";
            lblNormal.Size = new Size(59, 20);
            lblNormal.TabIndex = 19;
            lblNormal.Text = "Normal";
            // 
            // lblWellDone
            // 
            lblWellDone.AutoSize = true;
            lblWellDone.Location = new Point(699, 225);
            lblWellDone.Name = "lblWellDone";
            lblWellDone.Size = new Size(78, 20);
            lblWellDone.TabIndex = 20;
            lblWellDone.Text = "Well Done";
            // 
            // FrmPizzaList
            // 
            AutoScaleDimensions = new SizeF(8F, 20F);
            AutoScaleMode = AutoScaleMode.Font;
            BackColor = Color.FromArgb(192, 255, 255);
            ClientSize = new Size(789, 671);
            Controls.Add(lblWellDone);
            Controls.Add(lblNormal);
            Controls.Add(lblLightlyCooked);
            Controls.Add(btnReset_Click);
            Controls.Add(button2);
            Controls.Add(groupBox4);
            Controls.Add(numericUpDownHunger);
            Controls.Add(groupBox3);
            Controls.Add(listColor);
            Controls.Add(label11);
            Controls.Add(label10);
            Controls.Add(trkCookedLevel);
            Controls.Add(groupBox2);
            Controls.Add(groupBox1);
            Controls.Add(list_StrangeThings);
            Controls.Add(label2);
            Controls.Add(Ingredients);
            Controls.Add(txtName);
            Controls.Add(label1);
            Name = "FrmPizzaList";
            Text = "Pizza Order";
            Ingredients.ResumeLayout(false);
            Ingredients.PerformLayout();
            groupBox1.ResumeLayout(false);
            groupBox1.PerformLayout();
            groupBox2.ResumeLayout(false);
            groupBox2.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)trkCookedLevel).EndInit();
            groupBox3.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)numericUpDownHunger).EndInit();
            groupBox4.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)pictureBoxPizza).EndInit();
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private Label label1;
        private TextBox txtName;
        private GroupBox Ingredients;
        private CheckBox chk_ham;
        private CheckBox chk_pepperroni;
        private CheckBox chk_bellpeppers;
        private CheckBox chk_peppers;
        private CheckBox chk_tomatoes;
        private CheckBox chk_sausage;
        private CheckBox chk_bacon;
        private CheckBox chk_cheese;
        private Label label2;
        private ListBox list_StrangeThings;
        private GroupBox groupBox1;
        private RadioButton radio_BtnStuffedCrust;
        private RadioButton radio_BtnDeepDish;
        private RadioButton radio_BtnHandTossed;
        private RadioButton radio_BtnThinCrust;
        private GroupBox groupBox2;
        private Label label8;
        private Label label7;
        private Label label6;
        private Label label5;
        private Label label4;
        private Label label3;
        private HScrollBar hScrollBarParmesanCheese;
        private HScrollBar hScrollBarGarlic;
        private HScrollBar hScrollBarSauce;
        private TrackBar trkCookedLevel;
        private Label label10;
        private Label label11;
        private ListView listColor;
        private GroupBox groupBox3;
        private DateTimePicker timeOrderReady;
        private NumericUpDown numericUpDownHunger;
        private GroupBox groupBox4;
        private Button button2;
        private Button btnReset_Click;
        private Label lblLightlyCooked;
        private Label lblNormal;
        private Label lblWellDone;
        private Label lblParmesanCheese;
        private Label lblGarlic;
        private Label lblSauce;
        private PictureBox pictureBoxPizza;
    }
}
