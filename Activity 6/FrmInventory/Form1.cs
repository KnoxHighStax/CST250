using FileIO;
using System.Globalization;
using ServiceStack;
using OfficeOpenXml;
using System.Diagnostics;

namespace FrmInventory
{
    public partial class FrmInventory : Form
    {
        // List to store inventory list
        private List<Thing> thingsInMyPocket = new List<Thing>();
        // BidngSource to bind the list to the grid
        BindingSource thingsBindingSource = new BindingSource();

        public FrmInventory()
        {
            InitializeComponent();

            // Initializing the list and binding source
            thingsInMyPocket = new List<Thing>();

            thingsBindingSource = new BindingSource();
            thingsBindingSource.DataSource = thingsInMyPocket;

            // Event handlers for search functionality
            txtSearch.TextChanged += txtSearch_TextChanged;
            btnSearch.Click += btnSearch_Click;
        }

        private void FrmInventory_Load(object sender, EventArgs e)
        {
            // Initializing the value textbox with currency format
            txtValue.Text = string.Format(CultureInfo.CurrentCulture, "{0:C2}", 0);
            // Format on leaving the TextBox
            txtValue.Leave += txtValue_Leave;

            // Set up the data binding for the grid
            thingsBindingSource.DataSource = thingsInMyPocket;
            gridInventory.DataSource = thingsBindingSource;

            // Enabling cell validation for the grid
            gridInventory.CellValidating += gridInventory_CellValidating;
            gridInventory.DataError += gridInventory_DataError;
        }

        // Method to format the vlaue textbox when it gets out of range
        private void txtValue_Leave(object sender, EventArgs e)
        {
            decimal value;
            if (Decimal.TryParse(txtValue.Text, NumberStyles.Currency, CultureInfo.CurrentCulture, out value))
            {
                if (value < 0)
                {
                    MessageBox.Show("Value cannot be negative", "Validation Error",
                        MessageBoxButtons.OK, MessageBoxIcon.Error);
                    txtValue.Text = string.Format(CultureInfo.CurrentCulture, "{0:C2}", 0);
                    txtValue.Focus();
                }
                else
                {
                    txtValue.Text = string.Format(CultureInfo.CurrentCulture, "{0:C2}", value);
                }
            }
        }

        // "Add" button. Create a new Thing object and add it to the list.
        private void btnAdd_Click(object sender, EventArgs e)
        {
            try
            {
                // Validating Name
                if (string.IsNullOrWhiteSpace(txtName.Text))
                {
                    MessageBox.Show("Please enter a name for the line", "Validation Error",
                        MessageBoxButtons.OK, MessageBoxIcon.Error);
                    txtName.Focus();
                    return;
                }

                // Validate Value
                decimal value;
                if (!Decimal.TryParse(txtValue.Text, NumberStyles.Currency, CultureInfo.CurrentCulture, out value))
                {
                    MessageBox.Show("Please enter a valid currency value", "Validation Error",
                        MessageBoxButtons.OK, MessageBoxIcon.Error);
                    txtValue.Focus();
                    return;
                }
                else if (value < 0)
                {
                    MessageBox.Show("Value cannot be negative", "Validation Error",
                        MessageBoxButtons.OK, MessageBoxIcon.Error);
                    txtValue.Text = string.Format(CultureInfo.CurrentCulture, "{0:C2}", 0);
                    txtValue.Focus();
                    return;
                }
                // Create new thing and add to list
                Thing thing = new Thing
                {
                    Id = thingsInMyPocket.Count + 1,
                    Name = txtName.Text,
                    Value = Decimal.Parse(txtValue.Text, NumberStyles.Currency, CultureInfo.CurrentCulture)
                };
                thingsInMyPocket.Add(thing);

                // Update the binding source and reset bindings
                thingsBindingSource.DataSource = thingsInMyPocket.ToList();
                thingsBindingSource.ResetBindings(false);

                // Upfdate UI elements
                SetMaxValue();
                UpdateStatistics();

                // Clear input fields
                txtName.Clear();
                txtValue.Text = string.Format(CultureInfo.CurrentCulture, "{0:C2}", 0);
                txtValue.Clear();
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error adding item: " + ex.Message, "Error",
                    MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        // Method to set the maximum value for the range control
        private void SetMaxValue()
        {
            try
            {
                if (thingsInMyPocket == null || !thingsInMyPocket.Any())
                {
                    if (rangeMinMax != null)
                        rangeMinMax.MaxValue = 100;
                    return;
                }

                // Find the maximum value in the list
                decimal maxValuedItem = thingsInMyPocket.Max(thing => thing.Value);
                if (rangeMinMax != null)
                {
                    rangeMinMax.MaxValue = (int)Math.Ceiling(maxValuedItem);
                }
            }
            catch (Exception ex)
            {
                Debug.WriteLine($"SetMaxValue error: {ex.Message}");

                if (rangeMinMax != null)
                    rangeMinMax.MaxValue = 100;
            }
        }

        // Method to save menu item when clicked - save the list to a file
        private void saveToolStripMenuItem_Click(object sender, EventArgs e)
        {
            using (SaveFileDialog saveFileDialog = new SaveFileDialog())
            {
                saveFileDialog.Title = "Save File";
                // Setting filter to show different file types
                saveFileDialog.Filter = "Text Files (*.txt)|*.txt|CSV Files (*.csv)|*.csv|JSON Files (*.json)|*.json|XML Files (*.xml)|*.xml|Excel Files (*.xlsx)|*.xlsx|All Files (*.*)|*.*";
                // Start teh dialog showing Text Files
                saveFileDialog.FilterIndex = 1;

                if (saveFileDialog.ShowDialog() == DialogResult.OK)
                {
                    string fileName = saveFileDialog.FileName;
                    try
                    {
                        // Depending on teh file extension, save the appropriate format
                        if (fileName.EndsWith(".json"))
                        {
                            string json = ServiceStack.Text.JsonSerializer.SerializeToString(thingsInMyPocket);
                            File.WriteAllText(fileName, json);
                        }
                        else if (fileName.EndsWith(".csv"))
                        {
                            string csv = ServiceStack.Text.CsvSerializer.SerializeToCsv(thingsInMyPocket);
                            File.WriteAllText(fileName, csv);
                        }
                        else if (fileName.EndsWith(".txt"))
                        {
                            foreach (Thing thing in thingsInMyPocket)
                            {
                                File.AppendAllText(fileName, thing.ToString() + Environment.NewLine);
                            }
                        }
                        else if (fileName.EndsWith(".xml"))
                        {
                            var serializer = new System.Xml.Serialization.XmlSerializer(typeof(List<Thing>));

                            using (var writer = new System.IO.StreamWriter(fileName))
                            {
                                serializer.Serialize(writer, thingsInMyPocket);
                            }
                        }
                        else if (fileName.EndsWith(".xlsx"))
                        {
                            using (var package = new ExcelPackage())
                            {
                                var worksheet = package.Workbook.Worksheets.Add("Inventory");
                                worksheet.Cells[1, 1].Value = "Id";
                                worksheet.Cells[1, 2].Value = "Name";
                                worksheet.Cells[1, 3].Value = "Value";

                                for (int i = 0; i < thingsInMyPocket.Count; i++)
                                {
                                    worksheet.Cells[i + 2, 1].Value = thingsInMyPocket[i].Id;
                                    worksheet.Cells[i + 2, 2].Value = thingsInMyPocket[i].Name;
                                    worksheet.Cells[i + 2, 3].Value = thingsInMyPocket[i].Value;
                                }
                                package.SaveAs(new FileInfo(fileName));
                            }
                        }
                    }
                    catch (Exception ex)
                    {
                        MessageBox.Show($"Error: {ex.Message}\n{ex.StackTrace}", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    }
                }
            }
        }

        // Method to load menu item when clicked - load the list from a file
        private void loadToolStripMenuItem_Click(object sender, EventArgs e)
        {
            using (OpenFileDialog openFileDialog = new OpenFileDialog())
            {
                if (openFileDialog.ShowDialog() == DialogResult.OK)
                {
                    if (thingsInMyPocket == null)
                        thingsInMyPocket = new List<Thing>();

                    string fileName = openFileDialog.FileName;

                    try
                    {
                        // Load from JSON if extension is json
                        if (fileName.EndsWith(".json"))
                        {
                            // Read the JSON if extension is JSON
                            string json = File.ReadAllText(fileName);

                            // Deserialize the JSON to a list using serive stack
                            thingsInMyPocket = ServiceStack.Text.JsonSerializer.DeserializeFromString<List<Thing>>(json);
                            thingsBindingSource.ResetBindings(false);
                        }
                        else if (fileName.EndsWith(".csv"))
                        {
                            // Read teh csv from teh file
                            string csv = File.ReadAllText(fileName);

                            // Deserialize the CSV to a list using Service Stack
                            thingsInMyPocket = ServiceStack.Text.CsvSerializer.DeserializeFromString<List<Thing>>(csv);
                            thingsBindingSource.ResetBindings(false);
                        }
                        else if (fileName.EndsWith(".txt"))
                        {
                            // Read each line
                            string[] lines = File.ReadAllLines(fileName);
                            thingsInMyPocket.Clear();
                            foreach (string line in lines)
                            {
                                // Much more complicated to parse the file that has a bunch of 'junk' in it
                                /*
                                 * Id = 1, Name = Keys, Value = 80.00
                                 * Id = 2, Name = Phone, Value = 899.99
                                 * Id = 3, Name = Quarter, Value = .25
                                 */
                                string[] parts = line.Split(',');

                                for (int i = 0; i < parts.Length; i++)
                                {
                                    MessageBox.Show(parts[i]);
                                }
                                /*parts look like this
                                 *      ["Id = 1", "Name = Keys", "Value = 80.00"
                                 */

                                Thing thing = new Thing();
                                // To get id, split this "Id = 1" on the = symbol and take the second part

                                String idString = parts[0].Split("=")[1].Trim();
                                MessageBox.Show("IdString = '" + idString + "'");
                                thing.Id = int.Parse(idString);
                                thing.Name = parts[1].Split("=")[1].Trim();
                                string valueString = parts[2].Split("=")[1].Trim();
                                MessageBox.Show("ValueString = '" + valueString + "'");
                                thing.Value = decimal.Parse(valueString);

                                thingsInMyPocket.Add(thing);
                            }
                        }
                        // For XML files
                        else if (fileName.EndsWith(".xml"))
                        {
                            var serializer = new System.Xml.Serialization.XmlSerializer(typeof(List<Thing>));

                            using (var reader = new System.IO.StreamReader(fileName))
                            {
                                thingsInMyPocket = (List<Thing>)serializer.Deserialize(reader);
                            }
                        }
                        else if (fileName.EndsWith(".xlsx"))
                        {
                            FileInfo excelFile = new FileInfo(fileName);
                            using (ExcelPackage package = new ExcelPackage(excelFile))
                            {
                                ExcelWorksheet worksheet = package.Workbook.Worksheets[0];
                                thingsInMyPocket.Clear();

                                // Read data from the Excel worksheet
                                int rowCount = worksheet.Dimension.Rows;
                                for (int row = 2; row <= rowCount; row++)
                                {
                                    Thing thing = new Thing
                                    {
                                        Id = int.Parse(worksheet.Cells[row, 1].Text),
                                        Name = worksheet.Cells[row, 2].Text,
                                        Value = decimal.Parse(worksheet.Cells[row, 3].Text)
                                    };
                                    thingsInMyPocket.Add(thing);
                                }
                            }
                        }
                        // Update the binding source and reset bindings
                        thingsBindingSource.DataSource = typeof(List<Thing>);
                        thingsBindingSource.DataSource = thingsInMyPocket;
                        thingsBindingSource.ResetBindings(false);

                        // Update UI elements
                        SetMaxValue();
                        UpdateStatistics();

                        MessageBox.Show("File loaded successfully.", "Success",
                            MessageBoxButtons.OK, MessageBoxIcon.Information);
                    }
                    catch (Exception ex)
                    {
                        MessageBox.Show($"Error: {ex.Message}\n{ex.StackTrace}", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    }
                }
            }
        }

        // Method that selects the 3 most valuable items
        private void rdoShowMostValuable_CheckedChanged(object sender, EventArgs e)
        {
            var currentList = thingsBindingSource.DataSource as List<Thing> ?? thingsInMyPocket;
            // Use method syntax to order teh items by their Value property in descending order and take the first 3
            var mostValuable = thingsInMyPocket.OrderByDescending(thing => thing.Value).Take(3).ToList();

            thingsBindingSource.DataSource = mostValuable;
            thingsBindingSource.ResetBindings(false);
            UpdateStatistics();
        }

        // Methos to show the 3 least valuable items
        private void RdoShoowLeastValuable_CheckedChanged(object sender, EventArgs e)
        {
            var currentList = thingsBindingSource.DataSource as List<Thing> ?? thingsInMyPocket;
            // Order the items by their Value property in ascending order and take the first 3
            var leastValuable = (from thing in thingsInMyPocket
                                 orderby thing.Value
                                 select thing).Take(3).ToList();

            thingsBindingSource.DataSource = leastValuable;
            thingsBindingSource.ResetBindings(false);
            UpdateStatistics();
        }

        // Show all items in the grid
        private void rdoShowAll_CheckedChanged(object sender, EventArgs e)
        {
            var currentList = thingsBindingSource.DataSource as List<Thing> ?? thingsInMyPocket;
            // Use LINQ to order the items by their Id
            var sortedItems = thingsInMyPocket.OrderBy(thing => thing.Id).ToList();
            thingsBindingSource.DataSource = sortedItems;
            thingsBindingSource.ResetBindings(false);
            UpdateStatistics();
        }
        // Filter the grid to show all items between the two values of this control
        private void rangeMinMax_Click(object sender, EventArgs e)
        {
            var currentList = thingsBindingSource.DataSource as List<Thing> ?? thingsInMyPocket;
            // Use Query syntax to show all items between two values of this control
            var rangeList = thingsInMyPocket.FindAll(thing => thing.Value >= rangeMinMax.LowerValue && thing.Value <=
                rangeMinMax.UpperValue);

            thingsBindingSource.DataSource = rangeList;
            thingsBindingSource.ResetBindings(false);
            UpdateStatistics();
        }

        // Method to help validate the grid cell value
        private void gridInventory_CellValidating(object sender, DataGridViewCellValidatingEventArgs e)
        {
            if (gridInventory.Rows[e.RowIndex].IsNewRow) return;
            string headerText = gridInventory.Columns[e.ColumnIndex].HeaderText;
            try
            {
                // Validate Name column
                if (headerText.Equals("Name", StringComparison.OrdinalIgnoreCase))
                {
                    if (string.IsNullOrWhiteSpace(e.FormattedValue.ToString()))
                    {
                        MessageBox.Show("Name cannot be empty", "Validation Error",
                            MessageBoxButtons.OK, MessageBoxIcon.Error);
                        e.Cancel = true;
                    }
                }
                // Validate Value column
                else if (headerText.Equals("Value", StringComparison.OrdinalIgnoreCase))
                {
                    decimal value;
                    if (!decimal.TryParse(e.FormattedValue.ToString(), NumberStyles.Currency,
                        CultureInfo.CurrentCulture, out value))
                    {
                        MessageBox.Show("Please enter a valid currency value", "Validation Error",
                            MessageBoxButtons.OK, MessageBoxIcon.Error);
                        e.Cancel = true;
                    }
                    else if (value < 0)
                    {
                        MessageBox.Show("Value cannot be negative", "Validation Error",
                            MessageBoxButtons.OK, MessageBoxIcon.Error);
                        e.Cancel = true;
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Validation error: {ex.Message}", "Error",
                    MessageBoxButtons.OK, MessageBoxIcon.Error);
                e.Cancel = true;
            }
        }

        // Method to handle any data error in the grid
        private void gridInventory_DataError(object sender, DataGridViewDataErrorEventArgs e)
        {
            MessageBox.Show($"Invalid data entered: {e.Exception.Message}", "Data Error",
                MessageBoxButtons.OK, MessageBoxIcon.Error);
            e.ThrowException = false;
        }

        // Method to search when buttons is clicked
        private void btnSearch_Click(object sender, EventArgs e)
        {
            ApplySearchFilter(txtSearch.Text);
        }

        // Method to search text when changed 
        private void txtSearch_TextChanged(object sender, EventArgs e)
        {
            ApplySearchFilter(txtSearch.Text);
        }

        // method to apply the search filter to the inventory list
        private void ApplySearchFilter(string searchText)
        {
            try
            {
                if (string.IsNullOrWhiteSpace(searchText))
                {
                    // Show all items in search is empty
                    thingsBindingSource.DataSource = thingsInMyPocket;
                    thingsBindingSource.ResetBindings(false);
                    UpdateStatistics();
                    return;
                }
                // Trying to parse as decimal for value search
                bool isValueSearch = decimal.TryParse(searchText, NumberStyles.Currency, CultureInfo.CurrentCulture, out decimal searchValue);

                // Search both name and Value fields
                var filterList = thingsInMyPocket.Where(thing =>
                    thing.Name.IndexOf(searchText, StringComparison.OrdinalIgnoreCase) >= 0 ||
                    (isValueSearch && thing.Value == searchValue)).ToList();

                thingsBindingSource.DataSource = filterList;
                thingsBindingSource.ResetBindings(false);
                UpdateStatistics();
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Search error: {ex.Message}", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        // Method to update the statistics display
        private void UpdateStatistics()
        {
            try
            {
                var currentList = thingsBindingSource.DataSource as List<Thing> ?? thingsInMyPocket;

                // Calculate Statistics
                int itemCount = currentList.Count;
                decimal totalValue = currentList.Sum(thing => thing.Value);
                decimal averageValue = itemCount > 0 ? totalValue / itemCount : 0;
                decimal minValue = itemCount > 0 ? currentList.Min(thing => thing.Value) : 0;
                decimal maxValue = itemCount > 0 ? currentList.Max(thing => thing.Value) : 0;

                // Update Status level
                lblStatistics.Text = $"Items: {itemCount} | " +
                            $"Total Value: {totalValue:C2} | " +
                            $"Avg Value: {averageValue:C2} | " +
                            $"Max: {maxValue:C2} | " +
                            $"Min: {minValue:C2}";
            }
            catch (Exception ex)
            {
                lblStatistics.Text = "Error calculating statistics: ";
                Console.WriteLine("Error in UpdateStatistics: (ex.Message)");
            }
        }
    }
}
