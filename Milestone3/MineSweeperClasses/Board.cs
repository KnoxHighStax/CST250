using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MineSweeperClasses
{
    public class Board
    {
        //Properties
        // The Size of the square board
        public int Size { get; set; }

        // The Percentage chance of bombs(0-1)
        public float Difficulty { get; set; }

        //2D array of Cell objects
        public Cell[,] Cells { get; set; }

        // Will count what power-ups are available
        public int RewardRemaining { get; set; }

        // When the game first starts
        public DateTime StartTime { get; set; }

        // When the game comes to an end
        public DateTime EndTime { get; set; }

        // The Different possible game states
        public enum GameStatus { StillPlaying, Won, Lost }

        // This is our random number generatetor
        Random random = new Random();

        // Contructor that intializes teh board and cells
        public Board(int size, float difficulty)
        {
            Size = size;
            Difficulty = difficulty;
            Cells = new Cell[size, size];

            // Initialize each cell in the grid
            for (int row = 0; row < size; row++)
            {
                for (int col = 0; col < size; col++)
                {
                    Cells[row, col] = new Cell(row, col);
                }
            }

            RewardRemaining = 0;
            InitializeBoard();
        }

        // Initializes the game board with bombs, rewards and calculates neighbors
        private void InitializeBoard()
        {
            SetupBombs();
            SetupRewards();
            CalculateNumberOfBombNeighbors();
            StartTime = DateTime.Now;
        }

        // Used when a player selects a cell and choose to play the reawrd
        public void UseSpecialBonus() { }

        // Used after game is over to calculate final score
        public int DetermineFinalScore() { return 0; }

        // A helper method to determine if a cell is out of bounds
        private bool IsCellOnBoard(int row, int col) { return false; }

        // Used during a setup to calculate the number of bomb neighbors for each cell
        public void CalculateNumberOfBombNeighbors()
        {
            for (int row = 0; row < Size; row++)
            {
                for (int col = 0; col < Size; col++)
                {
                    if (Cells[row, col].IsBomb)
                    {
                        // Special value indicating it's a bomb
                        Cells[row, col].NumberOfBombNeighbors = 9;
                        continue;
                    }

                    int bombCount = 0;

                    // Check all 8 possible neighbors
                    for (int i = -1; i <= 1; i++)
                    {
                        for (int j = -1; j <= 1; j++)
                        {
                            // Skip current cell
                            if (i == 0 && j == 0) continue;

                            int newRow = row + i;
                            int newCol = col + j;

                            // Check if the neighbor is within bounds
                            if (newRow >= 0 && newRow < Size && newCol >= 0 && newCol < Size)
                            {
                                if (Cells[newRow, newCol].IsBomb)
                                {
                                    bombCount++;
                                }
                            }
                        }
                    }

                    Cells[row, col].NumberOfBombNeighbors = bombCount;
                }
            }
        }

        // Used during setup to place bombs on the board, will randomly place bomvs based on the difficulty
        public void SetupBombs()
        {
            Random random = new Random();

            for (int row = 0; row < Size; row++)
            {
                for (int col = 0; col < Size; col++)
                {
                    // Set bomb based on probability
                    Cells[row, col].IsBomb = random.NextDouble() < Difficulty;
                }
            }
        }

        // Used during setup to place rewards on the board randomly (will be place on cells already not containing a bomb)
        public void SetupRewards()
        {
            // Number of rewards based on board size
            RewardRemaining = 0;
            int rewardCount = Size;

            while (rewardCount > 0)
            {
                int row = random.Next(Size);
                int col = random.Next(Size);

                // Place reward only on safe cells
                if (!Cells[row, col].IsBomb && !Cells[row, col].HasSpecialReward)
                {
                    Cells[row, col].HasSpecialReward = true;
                    RewardRemaining++;
                    rewardCount--;
                }
            }
        }

        // Determines if the game has been won, lost or is still being played
        public GameStatus DetermineGameState()
        {
            bool allNonBombsVisited = true;

            for (int row = 0; row < Size; row++)
            {
                for (int col = 0; col < Size; col++)
                {
                    Cell cell = Cells[row, col];

                    // Check if any bomb has been visited (game lost and is over)
                    if (cell.IsBomb && cell.IsVisited)
                    {
                        EndTime = DateTime.Now;
                        return GameStatus.Lost;
                    }

                    // Check if all non-bomb cells are either visited or correctly flagged
                    if (!cell.IsBomb && !cell.IsVisited && !cell.IsFlagged)
                    {
                        allNonBombsVisited = false;
                    }
                }
            }
            // Check if the player revealed all safe cells
            if (allNonBombsVisited)
            {
                EndTime = DateTime.Now;
                return GameStatus.Won;
            }
            return GameStatus.StillPlaying;
        }

        // Method to help automatically fill all no live neighbor cells
        public void FloodFill(int row, int col)
        {
            // Check to prevent out of bounds error
            if (row < 0 || row >= Size || col < 0 || col >= Size)
                return;

            // Get the target cell from the baord
            Cell cell = Cells[row, col];

            // Will skip if conditions met
            if (cell.IsVisited || cell.IsBomb || cell.IsFlagged)
                return;

            // Mark the current cell as visited
            cell.IsVisited = true;

            // Stop teh recusion if cells has adjacent bombs
            // only bombs with 0 neighbors trigger it to expamd
            if (cell.NumberOfBombNeighbors > 0)
                return;

            // Recursive call all 8 directions
            FloodFill(row - 1, col - 1); //top left
            FloodFill(row - 1, col);     // top
            FloodFill(row - 1, col + 1); // top right
            FloodFill(row, col - 1);     // left
            FloodFill(row, col + 1);     // right
            FloodFill(row + 1, col - 1); // bottom left
            FloodFill(row + 1, col);     // bottom
            FloodFill(row + 1, col + 1); // bottom right
        }
    }
}