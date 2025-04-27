using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace WinFormsApp1
{
    /// <summary>
    /// Form for entering the players name at game end
    /// </summary>
    public partial class FrmNameEntry : Form
    {
        // To store the entered name
        public string inputText = "";
        /// <summary>
        /// Initialize the name entry form with custom title and prompt
        /// </summary>
        public FrmNameEntry(string title, string prompt)
        {
            InitializeComponent();
            this.Text = title;
            lblName.Text = prompt;
        }

        // Method for teh click event of the OK button
        private void btnOK_Click(object sender, EventArgs e)
        {
            // Store entered text
            inputText = txtName.Text;
            // Close form with OK result
            this.DialogResult = DialogResult.OK;
        }

        /// <summary>
        /// Returns the entered player name
        /// </summary>
        /// <returns></returns>
        public string InputText()
        {
            return inputText;
        }
    }
}
