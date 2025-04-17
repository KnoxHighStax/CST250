using MineSweeperClasses;

namespace MineSweeperGUI
{
    public partial class Form1 : Form
    {
        // Instance of teh Board class used to manage the game data
        Board board;
        // 2D Array of buttons used to represent the game baord in the GUI
        Button[,] buttons;
        DateTime startTime;
        private int totalScore;

        // graphical assests
        private Image bombImage;
        private Image flagImage;
        private Image coveredImage;
        private Image safeImage;
        private Image rewardImage;
        private Dictionary<string, Image> numberImages = new Dictionary<string, Image>();

        // Getting teh size and dfificulty from Form2 and setting up the game baord
        public Form1(int size, float difficulty)
        {
            InitializeComponent();
            LoadGameAssets();
            totalScore = 0;
            board = new Board(size, difficulty);
            UpdateScoreDisplay();
            InitializeGameBoard();
            startTime = DateTime.Now;
        }

        private void LoadGameAssets()
        {
            try
            {
                // Load all image files from Assets folder
                bombImage = Image.FromFile("Assets/bomb.png");
                flagImage = Image.FromFile("Assets/flag.png");
                coveredImage = Image.FromFile("Assets/covered.png");
                safeImage = Image.FromFile("Assets/safe.png");
                rewardImage = Image.FromFile("Assets/reward.png");

                // Load number images (1-8) for bomb proximty indicators
                for (int i = 1; i <= 8; i++)
                {
                    numberImages[i.ToString()] = Image.FromFile($"Assets/{i}.png");
                }
                // Standardize image sizes
                int targetSize = 40;
                bombImage = new Bitmap(bombImage, new Size(targetSize, targetSize));
                flagImage = new Bitmap(flagImage, new Size(targetSize, targetSize));
                coveredImage = new Bitmap(coveredImage, new Size(targetSize, targetSize));
                safeImage = new Bitmap(safeImage, new Size(targetSize, targetSize));
                rewardImage = new Bitmap(rewardImage, new Size(targetSize, targetSize));

                // Resize number images
                foreach (var key in numberImages.Keys.ToList())
                {
                    numberImages[key] = new Bitmap(numberImages[key], new Size(targetSize, targetSize));
                }
            }
            catch (Exception ex) 
            {
                MessageBox.Show($"Failed to load images: {ex.Message}");
            }
        }

        private void UpdateScoreDisplay()
        {
            lblTotalScore.Text = $"Score: {totalScore}";
        }

        // This method will help with cerating the game baord in our panel with interactive playablility
        private void InitializeGameBoard()
        {
            // Reset game area
            panel1.Controls.Clear();
            if (board == null) return;

            int size = board.Size;
            // Create button array matching board size
            buttons = new Button[size, size];

            // Calculate button size based on form size and board size
            int buttonSize = Math.Min(panel1.Width / size, panel1.Height / size);

            // Building an interactive grid
            for (int row = 0; row < size; row++) 
            {
                for (int col = 0; col < size; col++)
                {
                    var btn = new Button
                    {
                        Width = buttonSize,
                        Height = buttonSize,
                        Top = row * buttonSize,
                        Left = col * buttonSize,
                        // Store grid position
                        Tag = new Point(row, col),
                        Font = new Font("Arial", 12, FontStyle.Bold),
                        Margin = Padding.Empty,
                        FlatStyle = FlatStyle.Flat,
                        BackgroundImageLayout = ImageLayout.Stretch
                    };
                    // Assign click handler
                    btn.MouseUp += Button_MouseUp;
                    buttons[row, col] = btn;
                    // Add to display
                    panel1.Controls.Add(btn);
                }
            }
            // Set initial vlaues
            UpdateButtonFaces();
        }
        
        // Updates all buttons to reflect current game state
        private void UpdateButtonFaces()
        {
            if (board == null || buttons == null) return;

            for (int row = 0; row < board.Size; row++) 
            {
                for (int col = 0; col < board.Size; col++)
                {
                    Button btn = buttons[row, col];
                    Cell cell = board.Cells[row, col];

                    // Reset button properties
                    btn.Text = "";
                    btn.BackColor = SystemColors.Control;
                    btn.Image = null;
                    btn.ForeColor = Color.Black;

                    // Applying appropriate visuals based on the cells state
                    if (cell.IsFlagged)
                    {
                        btn.BackgroundImage = flagImage;
                        btn.BackColor = Color.LightGray;
                    }
                    else if (!cell.IsVisited)
                    {
                        btn.BackgroundImage = coveredImage;
                        btn.BackColor = Color.LightGray;
                    }
                    else if (cell.IsBomb)
                    {
                        btn.BackgroundImage = bombImage;
                        btn.BackColor = Color.White;
                    }
                    else if (cell.HasSpecialReward)
                    {
                        btn.BackgroundImage = rewardImage;
                        btn.BackColor = Color.Gold;
                    }
                    else if (cell.NumberOfBombNeighbors > 0)
                    {
                        if (numberImages.TryGetValue(cell.NumberOfBombNeighbors.ToString(), out Image? numberImage))
                        {
                            btn.BackgroundImage = numberImage;
                        }
                        else
                        {
                            btn.Text = cell.NumberOfBombNeighbors.ToString();
                            btn.BackgroundImage = null;
                        }
                        btn.BackColor = Color.White;
                    }
                    else
                    {
                        btn.BackgroundImage = safeImage;
                        btn.BackColor = Color.White;
                    }
                }
            }
        }

        // Method to handle all player interactions
        private void Button_MouseUp(object? sender, MouseEventArgs e)
        {
            if (sender == null || board == null || buttons == null) return;
            if (sender is not Button button || button.Tag is not Point location) return;
            
            int row = location.X;
            int col = location.Y;
            Cell cell = board.Cells[row, col];

            if (e.Button == MouseButtons.Right)
            {
                // Right Click to toggle flag
                cell.IsFlagged = !cell.IsFlagged;

                // Add score if correclty flagged a bomb
                if (cell.IsFlagged && cell.IsBomb)
                {
                    totalScore += 20;
                    UpdateScoreDisplay();
                }
                // remove score if incorrectly flagged a safe cell
                else if (cell.IsFlagged && !cell.IsBomb)
                {
                    totalScore = Math.Max(0, totalScore - 10);
                    UpdateScoreDisplay();
                }
                UpdateButtonFaces();
            }
            // Left-click revealing cell
            else if (e.Button == MouseButtons.Left && !cell.IsFlagged)
            {
                if (cell.IsBomb)
                {
                    // Game Over - Reveal all bombs
                    RevealAllBombs();
                    totalScore = Math.Max(0, totalScore - 50);
                    MessageBox.Show("Game Over! You hit a bomb!", "Game Over",
                        MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                    return;
                }

                // Only score if this cell wasn't already visited
                if (!cell.IsVisited)
                {
                    // Award points absed on what was revealed
                    if (cell.NumberOfBombNeighbors > 0)
                    {
                        totalScore += cell.NumberOfBombNeighbors * 10;
                    }
                    // Empty cell bonus
                    else
                    {
                        totalScore += 5;
                    }
                    UpdateScoreDisplay();
                }
                // Auto reveal empty areas
                if (cell.NumberOfBombNeighbors == 0)
                {
                    board.FloodFill(row, col);
                }
                cell.IsVisited = true;
            }
            UpdateButtonFaces();
            UpdateTimeDisplay();

            // if victory
            if (board.DetermineGameState() == Board.GameStatus.Won)
            {
                // Winnign bonus
                totalScore += 1000;
                UpdateScoreDisplay();
                MessageBox.Show($"You Won! Time: {lblTime.Text}\nFinal Score: {totalScore}");
            }
        }

        // Method to update the time the game took to play
        private void UpdateTimeDisplay()
        {
            TimeSpan elapsed = DateTime.Now - startTime;
            lblTime.Text = $"{elapsed.Minutes}:{elapsed.Seconds:00}";
        }
        // Method to reveal all bombs when game is lost
        private void RevealAllBombs()
        {
            if (board == null) return;

            for (int row = 0; row < board.Size; row++)
            {
                for (int col = 0; col < board.Size; col++)
                {
                    if (board.Cells[row, col].IsBomb)
                    {
                        board.Cells[row, col].IsVisited = true;
                    }
                }
            }
            UpdateButtonFaces();
        }

        // method to help restart the whole game over
        private void btnRestart_Click(object sender, EventArgs e)
        {
            // Show the start menu again
            using (var startForm = new FrmStartMenu())
            {
                if (startForm.ShowDialog() == DialogResult.OK)
                {
                    // Reset game with new parameters
                    totalScore = 0;
                    board = new Board(startForm.BoardSize, startForm.Difficulty);
                    startTime = DateTime.Now;
                    InitializeGameBoard();
                    UpdateTimeDisplay();
                }
            }
        }
    }
}
