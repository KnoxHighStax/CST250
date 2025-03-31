using MineSweeperClasses;

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
            board.SetupBombs();
            board.CalculateNumberOfBombNeighbors();
            Console.WriteLine("Here is the answer key for the first board");
            PrintAnswers(board);

            // Size 15 and difficulty 0.15
            //Create and display second board
            board = new Board(15, 0.15f);
            board.SetupBombs();
            board.CalculateNumberOfBombNeighbors();
            Console.WriteLine("Here is the answer key for the second board");
            PrintAnswers(board);

        }

        // Prints our the complete board withing the proper foramtting cnd colors
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
