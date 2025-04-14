using System.Text;

namespace PizzaOrder
{
    public partial class FrmPizzaList : Form
    {
        // List to store all pizza orders
        private List<PizzaOrder> orders = new List<PizzaOrder>();
        public FrmPizzaList()
        {
            InitializeComponent();
            // Intialize list color click event handler
            listColor.Click += listColor_Click;
            // Setting intial form state
            InitializeForm();
        }

        // Intialize form contorls with default values
        private void InitializeForm()
        {
            // Setting defalut values
            timeOrderReady.Value = DateTime.Now.AddHours(1);
            lblSauce.Text = $"{hScrollBarSauce.Value}%";
            lblGarlic.Text = $"{hScrollBarGarlic.Value}%";
            lblParmesanCheese.Text = $"{hScrollBarParmesanCheese.Value}%";

            // Configuring Hunger level/ NumericUpDown
            numericUpDownHunger.Minimum = 0;
            numericUpDownHunger.Maximum = 10;
            numericUpDownHunger.Value = 0;

            // Configuring Track Bar for cooked level for pizza
            trkCookedLevel.Minimum = 0;
            trkCookedLevel.Maximum = 10;
            trkCookedLevel.TickFrequency = 5;
            trkCookedLevel.Value = 5;
            lblNormal.Text = "Normal";

            // Setup color selection
            listColor.View = View.List;
            listColor.Items.Add("Click here to choose sauce color");
            pictureBoxPizza.BackColor = Color.Transparent;

        }

        // Cretae a new pizza order based form inputs
        private void click_CreatePizza(object sender, EventArgs e)
        {
            PizzaOrder newOrder = new PizzaOrder();

            // Set customer name if provided
            if (!string.IsNullOrWhiteSpace(txtName.Text))
                newOrder.Name = txtName.Text;

            // Record selected toppings
            bool[] toppings = { false, false, false, false, false, false, false, false };

            toppings[0] = chk_cheese.Checked;
            toppings[1] = chk_bacon.Checked;
            toppings[2] = chk_sausage.Checked;
            toppings[3] = chk_tomatoes.Checked;
            toppings[4] = chk_peppers.Checked;
            toppings[5] = chk_bellpeppers.Checked;
            toppings[6] = chk_pepperroni.Checked;
            toppings[7] = chk_ham.Checked;
            newOrder.Toppings = toppings;

            // Record strange add ons
            foreach (string item in list_StrangeThings.SelectedItems)
            {
                newOrder.StrangeAddOns.Add(item);
            }

            // Set cooked level based on trackbar position
            switch (trkCookedLevel.Value)
            {
                case 0:
                    newOrder.CookedLevel = "Lightly Cooked";
                    newOrder.CookedLevelValue = 0;
                    break;
                case 5:
                    newOrder.CookedLevel = "Normal";
                    newOrder.CookedLevelValue = 5;
                    break;
                case 10:
                    newOrder.CookedLevel = "Well Done";
                    newOrder.CookedLevelValue = 10;
                    break;
            }

            // Set ingredient quantities
            newOrder.SauceQty = hScrollBarSauce.Value;
            newOrder.GarlicQty = hScrollBarGarlic.Value;
            newOrder.ParmesanQty = hScrollBarParmesanCheese.Value;

            // Set delivery time and hunger time
            newOrder.Delivery = timeOrderReady.Value;
            newOrder.HungerLevel = numericUpDownHunger.Value;

            // Set sauce color
            newOrder.SauceColor = listColor.BackColor.Name;

            // Set crust tpe based on radio button selection
            if (radio_BtnThinCrust.Checked)
                newOrder.CrustType = "Thin Crust";
            else if (radio_BtnHandTossed.Checked)
                newOrder.CrustType = "Hand Tossed";
            else if (radio_BtnDeepDish.Checked)
                newOrder.CrustType = "Deep Dish";
            else if (radio_BtnStuffedCrust.Checked)
                newOrder.CrustType = "Stuffed with Cheese";

            // Build toppings list to be displayed
            List<string> selectedToppings = new List<string>();
            if (chk_cheese.Checked) selectedToppings.Add("Cheese");
            if (chk_bacon.Checked) selectedToppings.Add("Bacon");
            if (chk_sausage.Checked) selectedToppings.Add("Sausage");
            if (chk_tomatoes.Checked) selectedToppings.Add("Tomatoes");
            if (chk_peppers.Checked) selectedToppings.Add("Peppers");
            if (chk_bellpeppers.Checked) selectedToppings.Add("Bell Peppers");
            if (chk_pepperroni.Checked) selectedToppings.Add("Pepperoni");
            if (chk_ham.Checked) selectedToppings.Add("Ham");

            string toppingsText = selectedToppings.Count > 0 ? string.Join(", ", selectedToppings) : "None";

            string strangeAddOns = newOrder.StrangeAddOns.Count > 0 ? string.Join(", ", newOrder.StrangeAddOns) : "None";

            // Add order to list and show confirmation
            orders.Add(newOrder);
            string status_message = "Pizza order created successfully!\n\n" +
                    $" Customer's Name: {newOrder.Name}\n\n" +
                    $" Pizza crust: {newOrder.CrustType}\n\n" +
                    $" Delivery time: {newOrder.Delivery}\n\n" +
                    $" Hunger level: {newOrder.HungerLevel}\n\n" +
                    $" Sauce color: {newOrder.SauceColor}\n\n" +
                    $" Cooked level: {newOrder.CookedLevel}\n\n" +
                    $" Sauce Quantity: {newOrder.SauceQty}%\n\n" +
                    $" Garlic amount: {newOrder.GarlicQty}%\n\n" +
                    $" Parmesan Cheese amount: {newOrder.ParmesanQty}%\n\n" +
                    $" Toppings: {toppingsText}\n\n" +
                    $" Strange Add Ons: {strangeAddOns}";

            MessageBox.Show(status_message);
            MessageBox.Show("You have made " + orders.Count() + " different pizzas");

            // Show the orders form
            FrmPizzaOrders listForm = new FrmPizzaOrders(orders);
            listForm.ShowDialog();
        }

        // Resets all form conrols to default values
        private void btnReset_Click_Click(object sender, EventArgs e)
        {
            // reset name textboxes
            txtName.Text = "";

            // Reset checkboxes
            chk_cheese.Checked = false;
            chk_bacon.Checked = false;
            chk_sausage.Checked = false;
            chk_tomatoes.Checked = false;
            chk_peppers.Checked = false;
            chk_bellpeppers.Checked = false;
            chk_pepperroni.Checked = false;
            chk_ham.Checked = false;

            // Reset listbox
            list_StrangeThings.ClearSelected();

            // Reset the scrollbars
            hScrollBarSauce.Value = 0;
            hScrollBarGarlic.Value = 0;
            hScrollBarParmesanCheese.Value = 0;
            lblSauce.Text = "0%";
            lblGarlic.Text = "0%";
            lblParmesanCheese.Text = "0%";

            // Reset other controls
            timeOrderReady.Value = DateTime.Now.AddHours(1);
            numericUpDownHunger.Value = 0;
            trkCookedLevel.Value = 5;
            lblNormal.Text = "Normal";
            radio_BtnHandTossed.Checked = true;
        }

        // Hnadles cooked level trachbar changes with snapping behavior
        private void trkCookedLevel_Scroll(object sender, EventArgs e)
        {
            // Keeping value into specific ranges
            if (trkCookedLevel.Value < 3)
                trkCookedLevel.Value = 0;
            else if (trkCookedLevel.Value > 7)
                trkCookedLevel.Value = 10;
            else
                trkCookedLevel.Value = 5;

            // Making sure labels are updated correctly
            switch (trkCookedLevel.Value)
            {
                case 0:
                    lblLightlyCooked.Text = "Lightly Cooked";
                    break;
                case 5:
                    lblNormal.Text = "Normal";
                    break;
                case 10:
                    lblWellDone.Text = "Well Done";
                    break;
            }
        }

        // Handles the sauce quantity scroll changes with validation
        private void hScroll_Sauce(object sender, ScrollEventArgs e)
        {
            if (!ValidateSliderTotal(hScrollBarSauce, e.NewValue))
            {
                hScrollBarSauce.Value = 0;
                return;
            }
            lblSauce.Text = $"{e.NewValue}%";
        }

        // Handles the garlic quantity scroll changes with validation
        private void hScroll_Garlic(object sender, ScrollEventArgs e)
        {
            if (!ValidateSliderTotal(hScrollBarGarlic, e.NewValue))
            {
                hScrollBarGarlic.Value = 0;
                return;
            }
            lblGarlic.Text = $"{e.NewValue}%";
        }

        // Handles the parmesan cheese quantity scroll changes with validation
        private void hScroll_ParmesanCheese(object sender, ScrollEventArgs e)
        {
            if (!ValidateSliderTotal(hScrollBarParmesanCheese, e.NewValue))
            {
                hScrollBarParmesanCheese.Value = 0;
                return;
            }
            lblParmesanCheese.Text = $"{e.NewValue}%";
        }

        // Validates that the total of all ingredient sliders do not exceed 100%
        private bool ValidateSliderTotal(HScrollBar changedSlider, int newValue)
        {
            int total = (changedSlider == hScrollBarSauce ? newValue : hScrollBarSauce.Value) +
                (changedSlider == hScrollBarGarlic ? newValue : hScrollBarGarlic.Value) +
                (changedSlider == hScrollBarParmesanCheese ? newValue : hScrollBarParmesanCheese.Value);

            if (total > 100)
            {
                MessageBox.Show("Total cannot exceed 100%! Adjust other sliders first.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return false;
            }
            return true;
        }

        // Handles sauce color selection via color dialog
        private void listColor_Click(object sender, EventArgs e)
        {
            // Only open dialog if clicking on an actual item
            using (ColorDialog colorDialog = new ColorDialog())
            {
                // Perserve current color if set
                if (pictureBoxPizza.BackColor != Color.Transparent)
                {
                    colorDialog.Color = pictureBoxPizza.BackColor;
                }

                if (colorDialog.ShowDialog() == DialogResult.OK)
                {
                    // Update the pizza color
                    pictureBoxPizza.BackColor = colorDialog.Color;

                    // Save to current order
                    if (orders.Count > 0)
                    {
                        orders.Last().SauceColor = colorDialog.Color.Name;
                    }
                }
                listColor.SelectedItems.Clear();
            }
        }
    }
}
