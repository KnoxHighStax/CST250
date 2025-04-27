namespace MineSweeperGUI
{
    public partial class FrmStartMenu : Form
    {
        // Properties to store game configuration
        // Determine grid dimensions and bomb probability
        public int BoardSize { get; set;}
        public float Difficulty { get; set;}

        public FrmStartMenu()
        {
            InitializeComponent();
        }

        private void btnPlay_Click(object sender, EventArgs e)
        {
            // Setting the game parameters based on selected difficulty
            if (radiobtnEasy.Checked)
            {
                // 10% bombs 5x5
                Difficulty = 0.1f;
                BoardSize = 5;
            }
            else if (radiobtnMedium.Checked)
            {
                // 15% bombs 8x8
                Difficulty = 0.15f;
                BoardSize = 8;
            }
            else if (radiobtnDifficult.Checked) 
            {
                // 20% bombs 10x10
                Difficulty = 0.20f;
                BoardSize = 10;
            }
            else
            {
                MessageBox.Show("Please select a difficulty level.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }
            // Close menu and signal ready to start game
            this.DialogResult = DialogResult.OK;
            this.Close();
        }
    }
}
