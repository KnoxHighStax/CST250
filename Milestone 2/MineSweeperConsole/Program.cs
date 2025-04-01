using MineSweeperClasses;
using System.ComponentModel;

namespace MineSweeperConsole
{
    internal class Program
    {
        // Our main Constructor for Minesweeper application
        static void Main(string[] args)
        {
            Console.WriteLine("Hello, Welcome to Minesweeper");
            // Size 10 and difficulty .01
            // Create and display first board
            Board board = new Board(10, 0.1f);

            // Randomly place bombs, sprcial rewards and and bomb live neighbors
            board.SetupBombs();
            board.SetupRewards();
            board.CalculateNumberOfBombNeighbors();

            // Show answer key first
            Console.WriteLine("\nHere is the answer key:");
            PrintAnswers(board);
            Console.WriteLine("\nPress and key to start playing...");
            Console.ReadKey();

            // Clear any key before starting game
            Console.Clear();

            // Tracking for when the GameState
            bool gameOver = false;
            bool victory = false;

            // Main game loop
            while (!gameOver) 
            {
                Console.Clear();
                PrintBoard(board);

                // Get user input with validation for cells
                int row = -1, col = -1;
                bool validInput = false;
                while (!validInput)
                {
                    try
                    {
                        Console.WriteLine("Enter row and column numbers:");
                        string[] input = Console.ReadLine().Split();
                        row = int.Parse(input[0]) - 1;
                        col = int.Parse(input[1]) - 1;

                        // Validate coordinates within bounds
                        if (row < 0 || row >= board.Size || col < 0 || col >= board.Size)
                        {
                            throw new Exception("Coordinates out of range");
                        }
                        validInput = true;
                    }
                    catch
                    {
                        Console.WriteLine("Invalid input! Use format: row column (x,x)");
                    }
                }

                // Get game action
                Console.WriteLine("Choose action: (F)lag, (V)isit, (U)se Reawrd");
                string action = Console.ReadLine().ToUpper() ?? "";

                Cell selectedCell = board.Cells[row, col];

                // Processing for players action
                switch (action)
                {
                    // For flag
                    case "F":
                        selectedCell.IsFlagged = !selectedCell.IsFlagged;
                        break;
                    // Visit/Reveal
                    case "V":
                        if (selectedCell.IsFlagged)
                        {
                            Console.WriteLine("Cell is flagged! Unflag if first.");
                            Console.ReadKey();
                            continue;
                        }
                        // If cell has a reward
                        selectedCell.IsVisited = true;
                        if (selectedCell.HasSpecialReward)
                        {
                            Console.WriteLine("You found a reward! You can now peek at one of the cells.");
                            selectedCell.HasSpecialReward = false;
                            board.RewardRemaining++;
                            Console.ReadKey();
                        }
                        break;
                    // Use reward to peek at cell
                    case "U":
                        if (board.RewardRemaining > 0)
                        {
                            bool validPeek = false;
                            int peekRow = -1, peekCol = -1;

                            // Get coordinates to peek
                            while (!validPeek)
                            {
                                try
                                {
                                    Console.WriteLine("Enter cell to peek at the row and column:");
                                    string[] peekInput = Console.ReadLine().Split();
                                    peekRow = int.Parse(peekInput[0]) - 1;
                                    peekCol = int.Parse(peekInput[1]) - 1;

                                    // Validate coordinates
                                    if (peekRow < 0 || peekRow >= board.Size || peekCol < 0 || peekCol >= board.Size)
                                    {
                                        throw new Exception("Invalid coordinates");
                                    }
                                    if (board.Cells[peekRow, peekCol].IsVisited)
                                    {
                                        Console.WriteLine("Cell already revealed! Choose another.");
                                        continue;
                                    }

                                    validPeek = true;
                                }
                                catch
                                {
                                    Console.WriteLine("Invalid input! Use format: row colum (x,x)");
                                }
                            }
                            
                            // Reveal peeked cell's status
                            Console.WriteLine($"Cell at {peekRow + 1}, {peekCol+1} is " + $"{(board.Cells[peekRow, peekCol].IsBomb ? "a BOMB!" : "safe.")}");
                            board.RewardRemaining--;
                            Console.WriteLine("Press any key to continue...");
                            Console.ReadKey();
                        }
                        else
                        {
                            Console.WriteLine("No rewards available!");
                            Console.WriteLine("Press any key to continue...");
                            Console.ReadKey();
                        }
                        break;
                    default:
                        Console.WriteLine("Invalid action!");
                        Console.ReadKey();
                        continue;
                }
                // Check game state
                var gameState = board.DetermineGameState();
                if (gameState == Board.GameStatus.Won)
                {
                    gameOver = true;
                    victory = true;
                }
                else if (gameState == Board.GameStatus.Lost)
                {
                    gameOver = true;
                    victory = false;
                }
            }
            Console.Clear();
            // Show complete board at the end
            PrintAnswers(board);
            Console.WriteLine(victory ? "You Won!" : "Game Over! You hit a bomb!");
            Console.ReadKey();
        }

        // Method to print the current game board with hidden and revealed cells
        private static void PrintBoard(Board board)
        {
            // Print column numbers header (centered)
            Console.Write("  ");
            for (int col = 0; col < board.Size; col++)
            {
                Console.Write($" {col + 1}  ");
            }
            Console.WriteLine();

            // Print top border
            Console.Write("  +");
            for (int col = 0; col < board.Size; col++)
            {
                Console.Write("---+");
            }
            Console.WriteLine();

            // Print each row with cell contents
            for (int row = 0; row < board.Size; row++)
            {
                // Row number and left border
                Console.Write($"{row + 1} |");

                // Cell contents with dividers
                for (int col = 0; col < board.Size; col++)
                {
                    Cell cell = board.Cells[row, col];
                    Console.Write(" ");

                    // Displaying cells based on GameState
                    if (cell.IsFlagged)
                    {
                        Console.ForegroundColor = ConsoleColor.Yellow;
                        Console.Write("F");
                    }
                    else if (!cell.IsVisited)
                    {
                        Console.ForegroundColor = ConsoleColor.White;
                        Console.Write("?");
                    }
                    else if (cell.IsVisited && cell.HasSpecialReward)
                    {
                        Console.ForegroundColor = ConsoleColor.Magenta;
                        Console.Write("r");
                    }
                    else if (cell.IsBomb)
                    {
                        Console.ForegroundColor = ConsoleColor.Red;
                        Console.Write("B");
                    }
                    else if (cell.NumberOfBombNeighbors > 0)
                    {
                        Console.ForegroundColor = GetNumberColor(cell.NumberOfBombNeighbors);
                        Console.Write(cell.NumberOfBombNeighbors);
                    }
                    else
                    {
                        Console.ForegroundColor = ConsoleColor.Gray;
                        Console.Write(".");
                    }
                    Console.ForegroundColor = ConsoleColor.Gray;
                    Console.Write(" |");
                }
                Console.WriteLine();

                //Print row divider
                Console.Write(" +");
                for (int col = 0; col < board.Size; col++)
                {
                    Console.Write("---+");
                }
                Console.WriteLine();
            }
        }

        // Prints out the complete board withing the proper foramtting cnd colors
        static void PrintAnswers(Board board)
        {
            // Print column numbers header (centered)
            Console.Write("   ");
            for (int col = 0; col < board.Size; col++)
            {
                Console.Write($" {col + 1}  ");
            }
            Console.WriteLine();

            // Print top border
            Console.Write("  +");
            for (int col = 0; col < board.Size; col++)
            {
                Console.Write("---+"); // Each cell is exactly 3 chars wide
            }
            Console.WriteLine();

            // Print each row with cell contents
            for (int row = 0; row < board.Size; row++)
            {
                // Row number and left border
                Console.Write($"{row + 1} |");

                // Cell contents with dividers
                for (int col = 0; col < board.Size; col++)
                {
                    Cell cell = board.Cells[row, col];
                    Console.Write(" ");

                    if (cell.IsBomb)
                    {
                        Console.ForegroundColor = ConsoleColor.Red;
                        Console.Write("B");
                    }
                    else if (cell.HasSpecialReward)
                    {
                        Console.ForegroundColor = ConsoleColor.Magenta;
                        Console.Write("r");
                    }
                    else if (cell.NumberOfBombNeighbors > 0)
                    {
                        Console.ForegroundColor = GetNumberColor(cell.NumberOfBombNeighbors);
                        Console.Write(cell.NumberOfBombNeighbors);
                    }
                    else
                    {
                        Console.ForegroundColor = ConsoleColor.Gray;
                        Console.Write(".");
                    }

                    Console.ForegroundColor = ConsoleColor.Gray;
                    Console.Write(" |");
                }
                Console.WriteLine();

                // Print row divider
                Console.Write("  +");
                for (int col = 0; col < board.Size; col++)
                {
                    Console.Write("---+");
                }
                Console.WriteLine();
            }
        }

        // Returns the color based on neighbor of bomb count
        static ConsoleColor GetNumberColor(int number)
        {
            return number switch
            {
                1 => ConsoleColor.Blue,
                2 => ConsoleColor.Green,
                3 => ConsoleColor.Red,
                4 => ConsoleColor.DarkBlue,
                5 => ConsoleColor.DarkRed,
                6 => ConsoleColor.DarkCyan,
                7 => ConsoleColor.Black,
                8 => ConsoleColor.Gray,
                _ => ConsoleColor.Yellow

            };
        }
    }
}
