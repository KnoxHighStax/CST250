namespace WhackAMole
{
    public partial class FrmGame : Form
    {
        // Variables for game stat
        private int elapsed = 0;
        private int score = 0;
        private Random random = new Random();
        private Rectangle targetRectangle; // Rectangle representing the target (mole)
        private bool targetVisible = false; // Flag indicating if target is currently visible
        private const int TargetSize = 50; // Constant size of the target

        public FrmGame()
        {
            InitializeComponent();

            // Initialize timer properties
            timeMoveTarget.Interval = 1000;
            timeMoveTarget.Enabled = false;

            // Initialize target rectangle
            targetRectangle = new Rectangle(0, 0, TargetSize, TargetSize);

            // Subscribe to the Piant event
            this.Paint += FrmGame_Paint;
            this.MouseClick += FrmGame_MouseClick;
        }

        // Method to handle when the Start button is clicked
        private void btnStart_Click(object sender, EventArgs e)
        {
            // Start Timer
            timeMoveTarget.Start();
        }
        // Method to handle when the Stop button is clicked
        private void btnStop_Click(object sender, EventArgs e)
        {
            // Stop Timer
            timeMoveTarget.Stop();
        }
        // Method to handle when the Reset button is clicked
        private void btnReset_Click(object sender, EventArgs e)
        {
            // reset timer
            timeMoveTarget.Stop();
            elapsed = 0;
            lblTime.Text = "00:00:00";
            score = 0;
            targetVisible = false;
            UpdateLabels();
            this.Invalidate();
        }

        // Timer tick handler that runs every second
        private void TimeMoveTarget_Tick(object sender, EventArgs e)
        {
            // Increment elapsed time counter
            elapsed++;
            // Every 3 seconds, show the target at a new random position
            if (elapsed % 3 == 0)
            {
                targetVisible = true;
                // Setting a rnadom position with the form bounds
                targetRectangle.X = random.Next(0, this.Width - TargetSize);
                targetRectangle.Y = random.Next(0, this.Height - TargetSize);
                this.Invalidate();
            }
            UpdateLabels();
        }

        // Method to update the labels to display the time length of game play
        private void UpdateLabels()
        {
            // Time tracking
            TimeSpan time = TimeSpan.FromSeconds(elapsed);
            lblTime.Text = time.ToString(@"hh\:mm\:ss");
        }

        // Method to paint rectangle, to draw game elemnts
        private void FrmGame_Paint(object sender, PaintEventArgs e)
        {
            // If target is visible, draw it
            if (targetVisible)
            {
                e.Graphics.FillRectangle(Brushes.Red, targetRectangle);
                e.Graphics.DrawRectangle(Pens.Black, targetRectangle);
            }
        }

        // Method for the event of a Mouse click on the target (rectangle) 
        private void FrmGame_MouseClick(object sender, MouseEventArgs e)
        {
            // Checks if click hit is a visible target 
            if (targetVisible && targetRectangle.Contains(e.Location))
            {
                score++; // Increment the score
                targetVisible = false; // Hide target
                UpdateLabels();
                this.Invalidate(); // Remove hit target
            }
        }
    }
}
