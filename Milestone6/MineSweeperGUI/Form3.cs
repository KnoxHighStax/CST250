using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace MineSweeperGUI
{
    public partial class Form3 : Form
    {
        // Property to store the player's name
        public string PlayerName { get; private set;}

        // Constructor for the player name input form
        public Form3()
        {
            InitializeComponent();
        }

        // Method that handles when the OK button is clicked to submit the players name
        private void btnOK_Click(object sender, EventArgs e)
        {
            // To validate that name to not empty
            if (!string.IsNullOrWhiteSpace(txtName.Text))
            {
                PlayerName = txtName.Text.Trim();
                this.DialogResult = DialogResult.OK;
                this.Close();
            }
        }
    }
}
