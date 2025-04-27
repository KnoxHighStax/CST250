namespace WinFormsApp1
{
    /// <summary>
    /// Main game form containing the game logic and UI
    /// </summary>
    public partial class FrmGame : Form
    {
        // Game stat variables
        int elapsed = 0;
        int score = 0;
        int level = 1;
        int fontSize = 200;
        DateTime gameStartTime;
        Random Random = new Random();
        Color levelColor = Color.FromArgb(10, Color.Black);
        Color backgroundColor = SystemColors.Control;

        // High score collection
        public List<GameScore> highScores = new List<GameScore>();

        // Initial values for difficulty scaling
        private int initialTimerInterval;
        private int initialTargetWidth;
        private int initialTargetHeight;

        // Achievement tracking
        private GameAchievements achievements = new GameAchievements();
        private int totalClicks = 0;
        private int bombsAvoided = 0;

        /// <summary>
        /// Initialize game form
        /// </summary>
        public FrmGame()
        {
            InitializeComponent();
            // Add paint event
            this.Paint += FrmGame_Paint;
            UpdateScoreDisplay();
            lblTime.Text = "0.00s";
            // Record start time
            gameStartTime = DateTime.Now;
            this.BackColor = backgroundColor;

            // For storing the initial timer interval
            initialTimerInterval = timeMoveTarget.Interval;
            initialTargetWidth = btnTarget.Width;
            initialTargetHeight = btnTarget.Height;
        }
        /// <summary>
        /// Method to update the score display level
        /// </summary>
        private void UpdateScoreDisplay()
        {
            lblScore.Text = $"Score: {score}";
        }

        /// <summary>
        /// Method for the timer tick event to move target and bomb periodically 
        /// </summary>
        private void timeMoveTarget_Tick_1(object sender, EventArgs e)
        {
            elapsed++;
            // Ticks every 3 seconds moving both target/bomb
            if (elapsed % 3 == 0)
            {
                btnTarget.Visible = true;
                btnBomb.Visible = true;

                int margin = 10;
                // Ensuring the button stays within the form
                int width = this.ClientSize.Width - btnTarget.Width - margin * 2;
                int height = this.ClientSize.Height - btnTarget.Height - margin * 2;

                // Ensuring non-negative values
                width = Math.Max(0, width);
                height = Math.Max(0, height);

                // Move target to random position
                btnTarget.Top = margin + (height > 0 ? Random.Next(0, height) : 0);
                btnTarget.Left = margin + (width > 0 ? Random.Next(0, width) : 0);
                btnTarget.BackColor = Color.FromArgb(Random.Next(0, 256), Random.Next(0, 256), Random.Next(0, 256));

                // Making the bomb move random positions
                Point bombPosition;
                do
                {
                    bombPosition = new Point(
                        margin + (width > 0 ? Random.Next(0, width) : 0),
                        margin + (height > 0 ? Random.Next(0, height) : 0)
                    );
                }
                while (Math.Abs(bombPosition.X - btnTarget.Left) < btnTarget.Width &&
                        Math.Abs(bombPosition.Y - btnTarget.Top) < btnTarget.Height);

                btnBomb.Top = bombPosition.Y;
                btnBomb.Left = bombPosition.X;

                // Make bomb visibility distinct with a random red shade
                btnBomb.BackColor = Color.FromArgb(255, Random.Next(150, 256), Random.Next(0, 100), Random.Next(0, 100));
            }
            else
            {
                // Tracks when the bomb disappears without being clicked
                if (btnBomb.Visible)
                {
                    bombsAvoided++;
                    if (bombsAvoided >= 5 && !achievements.AvoidedBombs)
                    {
                        achievements.AvoidedBombs = true;
                    }
                }
            }
        }

        /// <summary>
        /// Method to handle the target button being clicked
        /// </summary>
        private void btnTarget_Click(object sender, EventArgs e)
        {
            // Increament score by 1 for each click
            score++;
            totalClicks++;

            // Unlock 10 clicks achievement
            if (totalClicks >= 10 && !achievements.Clicked10Times)
            {
                achievements.Clicked10Times = true;
            }

            UpdateScoreDisplay();
            btnTarget.Visible = false;

            // Level up evey 3 clicks
            if (score % 3 == 0)
            {
                level++;

                // Check for level 5 achievement
                if (level >= 5 && !achievements.ReachedLevel5)
                {
                    achievements.ReachedLevel5 = true;
                }

                // For increasing the difficulty
                timeMoveTarget.Interval = Math.Max(200, initialTimerInterval - (level * 50));

                // Reducing target size
                int newWidth = Math.Max(20, initialTargetWidth - (level * 2));
                int newHeight = Math.Max(20, initialTargetHeight - (level * 2));
                btnTarget.Size = new Size(newWidth, newHeight);

                // Generate random color for new level
                Color baseColor = Color.FromArgb(10, Color.FromArgb(Random.Next(50, 256),
                    Random.Next(50, 256), Random.Next(50, 256)));

                // Set level color
                levelColor = Color.FromArgb(10, baseColor);

                // Set background color
                backgroundColor = ControlPaint.Dark(baseColor, 0.7f);
                this.BackColor = backgroundColor;

                // Force the form to redraw
                this.Invalidate();
            }

            // Showing the time display
            TimeSpan currentTime = DateTime.Now - gameStartTime;
            lblTime.Text = $"Playtime: {currentTime.TotalSeconds:F2}s";
        }

        /// <summary>
        /// To end the game and prompts for player name
        /// </summary>
        private void GameOver()
        {
            timeMoveTarget.Stop();
            TimeSpan totalPlayTime = DateTime.Now - gameStartTime;
            //Show name entry dialog
            using (FrmNameEntry form2 = new FrmNameEntry("Enter Your Name", "Enter your name:"))
            {
                if (form2.ShowDialog() == DialogResult.OK)
                {
                    // Add socre to high scores
                    string playerName = form2.InputText();
                    GameScore gameScore = new GameScore
                    {
                        Score = score,
                        Level = level,
                        Date = DateTime.Now,
                        PlayerName = playerName,
                        Id = highScores.Count + 1
                    };
                    highScores.Add(gameScore);
                    MessageBox.Show("game Over! Your name is: " + playerName);
                }
            }
            // Show the high scores
            FrmHighScores formHighScores = new FrmHighScores(highScores);
            formHighScores.ShowDialog();
        }
        private void FrmGame_Click(object sender, EventArgs e)
        {
            GameOver();
        }

        /// <summary>
        /// Method that draws the current level in teh shape of a large number on the form
        /// </summary>
        private void DrawLargeNumber(Graphics graphics)
        {
            // The numebr to print
            string number = level.ToString();

            // Set font size to match the form height
            Font font = new Font("Arial", fontSize, FontStyle.Bold, GraphicsUnit.Pixel);

            // Create a brush with the current level color
            Brush brush = new SolidBrush(levelColor);

            // Find the center of the form
            SizeF textSize = graphics.MeasureString(number, font);
            float x = (this.ClientSize.Width - textSize.Width) / 2;
            float y = (this.ClientSize.Height - textSize.Height) / 2;

            // Draw the number
            graphics.DrawString(number, font, brush, x, y);
        }

        /// <summary>
        /// Will be called upon when form generates to display level number on form
        /// </summary>
        private void FrmGame_Paint(object? sender, PaintEventArgs e)
        {
            DrawLargeNumber(e.Graphics);
        }

        /// <summary>
        /// Method to handle when the bomb is clicked (penalty given)
        /// </summary>
        private void btnBomb_Click(object sender, EventArgs e)
        {
            // Penalize player for clicking the bomb
            score = Math.Max(0, score - 2);
            level = Math.Max(1, level - 1);

            bombsAvoided = 0;

            UpdateScoreDisplay();
            Refresh();
        }

        /// <summary>
        /// Method to show the achievements dialog
        /// </summary>
        private void btnAchievements_Click(object sender, EventArgs e)
        {
            new FrmAchievements(achievements).ShowDialog();
        }
    }
}
