using MineSweeperClasses;
using System.Text.Json;
using System.Threading.Tasks;

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

        // graphical assests made to be nullable
        private Image? bombImage;
        private Image? flagImage;
        private Image? coveredImage;
        private Image? safeImage;
        private Image? rewardImage;
        private Dictionary<string, Image> numberImages = new Dictionary<string, Image>();

        // Getting teh size and difficulty from Form2 and setting up the game baord
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

        // Method to load all game assets from the Assets folder
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
                    var image = Image.FromFile($"Assets/{i}.png");
                    numberImages[i.ToString()] = image;
                }
                // Standardize image sizes
                int targetSize = 40;
                bombImage = new Bitmap(bombImage!, new Size(targetSize, targetSize));
                flagImage = new Bitmap(flagImage!, new Size(targetSize, targetSize));
                coveredImage = new Bitmap(coveredImage!, new Size(targetSize, targetSize));
                safeImage = new Bitmap(safeImage!, new Size(targetSize, targetSize));
                rewardImage = new Bitmap(rewardImage!, new Size(targetSize, targetSize));

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
                    if (cell.IsFlagged && flagImage != null)
                    {
                        btn.BackgroundImage = flagImage;
                        btn.BackColor = Color.LightGray;
                    }
                    else if (!cell.IsVisited && coveredImage != null)
                    {
                        btn.BackgroundImage = coveredImage;
                        btn.BackColor = Color.LightGray;
                    }
                    else if (cell.IsBomb && bombImage != null)
                    {
                        btn.BackgroundImage = bombImage;
                        btn.BackColor = Color.White;
                    }
                    else if (cell.HasSpecialReward && rewardImage != null)
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
        private void SaveGame()
        {
            SaveFileDialog saveFileDialog = new SaveFileDialog
            {
                Filter = "Minesweeper Save Files (*.mssave)|*.mssave|All Files (*.*)|*.*",
                DefaultExt = "mssave"
            };

            if (saveFileDialog.ShowDialog() == DialogResult.OK)
            {
                try
                {
                    // Create a save object with all necessary game state
                    var saveData = new
                    {
                        BoardSize = board.Size,
                        Difficulty = board.Difficulty,
                        Cells = board.GetCellsFlatArray(),
                        RewardRemaining = board.RewardRemaining,
                        StartTime = board.StartTime,
                        EndTime = board.EndTime,
                        Score = board.Score,
                        TotalScore = totalScore,
                        CurrentTime = DateTime.Now
                    };

                    var options = new JsonSerializerOptions
                    {
                        WriteIndented = true,
                    };

                    // Serialize to JSON
                    string jsonString = JsonSerializer.Serialize(saveData, options);

                    // Write to file
                    File.WriteAllText(saveFileDialog.FileName, jsonString);

                    MessageBox.Show("Game saved successfully!", "Save Game",
                        MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
                catch (Exception ex)
                {
                    MessageBox.Show($"Error saving game: {ex.Message}", "Error",
                        MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
        }

        private void LoadGame()
        {
            OpenFileDialog openFileDialog = new OpenFileDialog
            {
                Filter = "Minesweeper Save Files (*.mssave)|*.mssave|All Files (*.*)|*.*"
            };

            if (openFileDialog.ShowDialog() == DialogResult.OK)
            {
                try
                {
                    // Read JSON from file
                    string jsonString = File.ReadAllText(openFileDialog.FileName);
                    // Deserialize JSON
                    var saveData = JsonSerializer.Deserialize<dynamic>(jsonString);

                    // Create new board with saved parameters
                    int size = saveData.GetProperty("BoardSize").GetInt32();
                    float difficulty = (float)saveData.GetProperty("Difficulty").GetDouble();
                    board = new Board(size, difficulty);

                    // Restore board state
                    var cellsJson = saveData.GetProperty("Cells").GetRawText();
                    var cells = JsonSerializer.Deserialize<Cell[]>(cellsJson);
                    board.SetCellsFlatArray(cells);

                    board.RewardRemaining = saveData.GetProperty("RewardRemaining").GetInt32();
                    board.StartTime = saveData.GetProperty("StartTime").GetDateTime();
                    board.EndTime = saveData.GetProperty("EndTime").GetDateTime();
                    board.Score = saveData.GetProperty("Score").GetInt32();
                    totalScore = saveData.GetProperty("TotalScore").GetInt32();

                    // Adjust for time paused
                    var currentTime = saveData.GetProperty("CurrentTime").GetDateTime();
                    var pausedTime = DateTime.Now - currentTime;
                    board.StartTime += pausedTime;

                    // Reinitialize the game board
                    InitializeGameBoard();
                    UpdateScoreDisplay();
                    UpdateTimeDisplay();

                    MessageBox.Show("Game loaded successfully!", "Load Game",
                        MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
                catch (Exception ex)
                {
                    MessageBox.Show($"Error loading game: {ex.Message}", "Error",
                        MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
        }

        private void loadToolStripMenuItem_Click(object sender, EventArgs e)
        {
            LoadGame();
        }

        private void saveToolStripMenuItem_Click(object sender, EventArgs e)
        {
            SaveGame();
        }



        // Method to handle all player interactions 

        private async void Button_MouseUp(object? sender, MouseEventArgs e)
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
                // Check if this is a reward cell that hasent been visited yet 
                if (cell.HasSpecialReward && !cell.IsVisited)
                {
                    // Activate the reward power 
                    await ActivateRewardPower();
                    // Reward is consumed after use 
                    cell.HasSpecialReward = false;
                    board.RewardRemaining--;
                }

                // Only score if this cell wasn't already visited 
                if (!cell.IsVisited)
                {
                    // Award points based on what was revealed 
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

                // Show Form3 to capture player name 
                using (Form3 nameForm = new Form3())
                {
                    if (nameForm.ShowDialog() == DialogResult.OK)
                    {
                        // Show Form4 with the high scores with player name 
                        Form4 highScoresForm = new Form4(nameForm.PlayerName, totalScore);
                        highScoresForm.ShowDialog();
                    }
                }
                MessageBox.Show($"You Won! Time: {lblTime.Text}\nFinal Score: {totalScore}");
            }
        }

        private async Task ActivateRewardPower()
        {
            MessageBox.Show("Reward activated! Click any cell to peek at its contents for 5 seconds.",
                "Reward Power", MessageBoxButtons.OK, MessageBoxIcon.Information);

            // Enable peek mode 
            bool peekMode = true;
            MouseEventHandler peekHandler = null;

            peekHandler = async (sender, e) =>
            {
                if (!peekMode || sender is not Button button || button.Tag is not Point location)
                    return;

                int row = location.X;
                int col = location.Y;
                Cell cell = board.Cells[row, col];

                // Skip if already revealed or flagged 
                if (cell.IsVisited || cell.IsFlagged) return;

                Button btn = buttons[row, col];
                Image originalImage = btn.BackgroundImage;
                Color originalColor = btn.BackColor;

                // Temporarily reveal the cell 
                if (cell.IsBomb && bombImage != null)
                {
                    btn.BackgroundImage = bombImage;
                    btn.BackColor = Color.White;
                }
                else if (cell.HasSpecialReward && rewardImage != null)
                {
                    btn.BackgroundImage = rewardImage;
                    btn.BackColor = Color.Gold;
                }
                else if (cell.NumberOfBombNeighbors > 0)
                {
                    if (numberImages.TryGetValue(cell.NumberOfBombNeighbors.ToString(), out Image numberImage))
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

                // Wait for 5 seconds 
                await Task.Delay(5000);

                // Only revert if we're still in peek mode (user hasn't clicked another cell) 
                if (peekMode)
                {
                    btn.BackgroundImage = originalImage;
                    btn.BackColor = originalColor;
                    btn.Text = "";
                }
            };

            // Add the peek handler to all buttons 
            foreach (Button btn in panel1.Controls.OfType<Button>())
            {
                btn.MouseUp += peekHandler;
            }

            // Wait for the next click (which will trigger the peek) 
            var tcs = new TaskCompletionSource<bool>();
            MouseEventHandler clickHandler = null;
            clickHandler = (sender, e) =>
            {
                if (e.Button == MouseButtons.Left)
                {
                    tcs.TrySetResult(true);
                }
            };

            panel1.MouseUp += clickHandler;
            await tcs.Task;
            // Clean up 
            peekMode = false;
            panel1.MouseUp -= clickHandler;
            foreach (Button btn in panel1.Controls.OfType<Button>())
            {
                btn.MouseUp -= peekHandler;
            }
        }
    }
}
