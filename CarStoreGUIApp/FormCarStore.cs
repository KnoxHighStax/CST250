using CarClassLibrary;
using System;
using System.Windows.Forms;

namespace CarStoreGUIApp
{
    public partial class frmCarStore : Form
    {
        // Create a store object to hold the car inventory
        Store Store = new Store();

        // Create teo BindingSources to bind the car inventory and shopping list to the listboxes
        BindingSource bindingSourceInventory = new BindingSource();
        BindingSource bindingSourceShoppingList = new BindingSource();

        public frmCarStore()
        {
            InitializeComponent();
            // Set the DataSource of the BindingSources to the CarList and ShoppingList properties of the store
            bindingSourceInventory.DataSource = Store.CarList;
            bindingSourceShoppingList.DataSource = Store.ShoppingList;

            // Set the DataSource of the listboxes to the BindingSources
            listInventory.DataSource = bindingSourceInventory;
            listShoppingCart.DataSource = bindingSourceShoppingList;
        }

        private void label1_Click(object sender, EventArgs e)
        {

        }

        // Create a car instance from the textboxes and ad it to the inventory list
        private void BtnCreate_Click(object sender, EventArgs e)
        {
            // Get the Properties of the car from the textboxes
            string Make = txtMake.Text;
            string Model = txtModel.Text;
            int Year = int.Parse(txtYear.Text);
            decimal Price = decimal.Parse(txtPrice.Text);

            // Create a car and add it to the store's inventory
            Car car = new Car(Make, Model, Year, Price);

            Store.CarList.Add(car);

            MessageBox.Show(car.ToString() + " added to inventory which now has " + Store.CarList.Count() + " items.");

            txtMake.Clear();
            txtModel.Clear();
            txtYear.Clear();
            txtPrice.Clear();

            // Refresh the inventory listbox
            bindingSourceInventory.ResetBindings(false);
        }

        // Copy the selected car from the inventory list to the shopping cart
        private void BtnAddToCart_Click(object sender, EventArgs e)
        {
            // Get the car from the selected item in the inventory listbox and add it to the shopping list
            Store.ShoppingList.Add((Car)listInventory.SelectedItem);
            // Refresh teh shopping listbox
            bindingSourceShoppingList.ResetBindings(false);
        }

        // Add the value of items in the shopping list. Display the total in the correspoding label
        private void BtnCheckout_Click(object sender, EventArgs e)
        {
            // Calculate the total price of the cars in teh shopping lsit
            decimal total = Store.Checkout();
            // Use label6 to display then total
            lblTotal.Text = total.ToString("C");
        }

        // Search for a specific item out of the inventory list
        private void btnSearch_Click(object sender, EventArgs e)
        {
            // Get the search term entered by the user in the txtSearch TextBox
            string searchTerm = txtSearch.Text.Trim().ToLower();

            // Check if the search term is empty
            if (string.IsNullOrEmpty(searchTerm))
            {
                // If no search term is entered, reset the inventory list to show all cars
                bindingSourceInventory.DataSource = Store.CarList;
            }
            else
            {
                // Filter the CarList by the search term (e.g., make, model, or year)
                var filteredCars = Store.CarList
                    .Where(car => car.Make.ToLower().Contains(searchTerm) ||
                                  car.Model.ToLower().Contains(searchTerm) ||
                                  car.Year.ToString().Contains(searchTerm))
                    .ToList();

                // Update the BindingSource with the filtered list of cars
                bindingSourceInventory.DataSource = filteredCars;
            }

            // Refresh the inventory listbox
            bindingSourceInventory.ResetBindings(false);
        }

        // Removing selected item from the Shopping Cart
        private void btnRemove_Click(object sender, EventArgs e)
        {
            // Check if an item is selected in the shopping cart listbox
            if (listShoppingCart.SelectedItem != null)
            { 
                // Get slected car from the shopping cart list
                Car selectedCar = (Car)listShoppingCart.SelectedItem;

                // Remove the selected car from the shopping list
                Store.ShoppingList.Remove(selectedCar);

                // Refresh the shopping listbox
                bindingSourceShoppingList.ResetBindings(false);

                MessageBox.Show(selectedCar.ToString() + " has been removed from your shopping cart.");
            }
            else
            {
                // Show an error message if no item is selected
                MessageBox.Show("Please select a car to remove from the shopping cart.");
            }
        }
    }p
}
