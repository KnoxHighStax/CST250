using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace PizzaOrder
{
    public partial class FrmPizzaOrders : Form
    {
        // Data binding source for pizza list
        BindingSource bindingSourcePizzaList = new BindingSource();

        // List to store pizza orders
        List<PizzaOrder> pizzaList = new List<PizzaOrder>();

        public FrmPizzaOrders(List<PizzaOrder> pizzaOrders)
        {
            InitializeComponent();
            pizzaList = pizzaOrders;
            bindingSourcePizzaList.DataSource = pizzaList;
            listPizzas.DataSource = bindingSourcePizzaList;
            listPizzas.DisplayMember = "Name";
        }

        // Diaplays details when a pizza is selected form the list
        private void listPizzas_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (listPizzas.SelectedItem is PizzaOrder newOrder) 
            {
                // Build topping list from boolen array
                List<string> toppings = new List<string>();
                if (newOrder.Toppings[0]) toppings.Add("Cheese");
                if (newOrder.Toppings[0]) toppings.Add("Bacon");
                if (newOrder.Toppings[0]) toppings.Add("Sausage");
                if (newOrder.Toppings[0]) toppings.Add("Tomatoes");
                if (newOrder.Toppings[0]) toppings.Add("Perppers");
                if (newOrder.Toppings[0]) toppings.Add("Bell Peppers");
                if (newOrder.Toppings[0]) toppings.Add("Pepperoni");
                if (newOrder.Toppings[0]) toppings.Add("Ham");

                string toppingsText = toppings.Count > 0 ? string.Join(", ", toppings) : "None";

                string strangeAddOns = newOrder.StrangeAddOns.Count > 0 ? string.Join(", ", newOrder.StrangeAddOns) : "None";

                // Build and display order details
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
                    $" Toppins: {toppingsText}\n\n" +
                    $" Strange Add Ons: {strangeAddOns}";

                txtPizzaOrders.Text = status_message;
            }
        }

        // Deletes the currently selected pizza order
        private void btnDelete_Click(object sender, EventArgs e)
        {
            if (listPizzas.SelectedItem is PizzaOrder selectedOrder)
            {
                pizzaList.Remove((PizzaOrder)listPizzas.SelectedItem);
                bindingSourcePizzaList.ResetBindings(false);
            }
        }

        // Sorts pizza orders by name Z to A
        private void btnZtoA_Click(object sender, EventArgs e)
        {
            pizzaList = pizzaList.OrderByDescending(p => p.Name).ToList();
            bindingSourcePizzaList.DataSource = pizzaList;
            bindingSourcePizzaList.ResetBindings(false);
        }

        // Sorts pizza orders by name A to Z
        private void btnAtoZ_Click(object sender, EventArgs e)
        {
            pizzaList = pizzaList.OrderBy(p => p.Name).ToList();
            bindingSourcePizzaList.DataSource = pizzaList;
            bindingSourcePizzaList.ResetBindings(false);
        }
    }
}
