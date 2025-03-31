using ChessBoardModel;

namespace ChessBoardConsoleApp
{
    internal class Program
    {
        // Show the empty chessboard
        // Get the location of the chess piece
        // Calculate and mark the cells where legal moves are possible
        // Show the chessboard. Use  . for an empty square,
        // // X for the piece location and + for a possible legal move
        static void Main(string[] args)
        {
            Console.WriteLine("Hello, Chess players!");

            // Create new board
            Board myBoard = new Board(8);

            // Get the user input for the piece type and position
            string piece = GetChessPiece();
            (int row, int col) = GetValidPosition(myBoard.Size);

            // Use the board class to set the piece and mark the last legal moves
            myBoard.MarkNextLegalMoves(myBoard.TheGrid[row, col], piece);

            // Print the board
            PrintBoard(myBoard);
        }

        // Method that helps to get a valid board position from user
        private static (int, int) GetValidPosition(int boardSize)
        {
            int row = GetValidCoordinate("row", boardSize);
            int col = GetValidCoordinate("column", boardSize);
            return (row, col);
        }

        // This is a helper method to get a single valid coordinate, row or column
        private static int GetValidCoordinate(string coordinateName, int boardSize)
        {
            while (true)
            {
                Console.WriteLine($"Enter the {coordinateName} number (0-{boardSize-1}):");
                string input = Console.ReadLine();

                // Validate input is a number and within the bounds
                if (int.TryParse(input, out int value) && value >= 0 && value < boardSize)
                {
                    return value;
                }

                Console.WriteLine($"Invalid {coordinateName}. Please enter a number between 0 and {boardSize - 1}.");
            }
        }

        // Method to get all valid chess pieces that the user may input
        private static string GetChessPiece()
        {
            string[] validPieces = { "knight", "rook", "bishop", "queen", "king", "pawn" };

            while (true)
            {
                Console.WriteLine("What type of piece do you want to place? (Knight, Rook, Bishop, Queen, King, Pawn)");
                string input = Console.ReadLine().ToLower();

                if (validPieces.Contains(input))
                {
                    return input;
                }
                Console.WriteLine("Invalid piece. Please try again!");
            }
        }

        // Method that helps to print the chess board with the borders and labels
          private static void PrintBoard(Board myBoard)
        {
            // Print Column headers
            Console.Write("  ");
            for (int j = 0; j < myBoard.Size; j++)
            {
                Console.Write($" {j}  "); // Column Numbers
            }
            Console.WriteLine();

            // Print each row of the board
            for (int i = 0; i < myBoard.Size; i++)
            {
                // Print top border of the row
                Console.Write(" +");
                for (int j = 0; j < myBoard.Size; j++)
                {
                    Console.Write("---+"); // Cell top border
                }
                Console.WriteLine();

                // Print row number and cell contents
                Console.Write($"{i} |");

                // Cell content
                for (int j = 0; j < myBoard.Size; j++)
                {
                    Cell cell = myBoard.TheGrid[i, j];
                    string content = " ";

                    // If the cell has a piece, show its symbol (K, Q, R, B, N)
                    if (!string.IsNullOrEmpty(cell.IsCurrentlyOccupied))
                    {
                        content = cell.IsCurrentlyOccupied;
                    }
                    // If it's a legal move and not occupied,will show "+"
                    else if (cell.IsLegalNextMove)
                    {
                        content = "+";
                    }

                    Console.Write($" {content} |");
                }
                Console.WriteLine();
            }

            // Print bottom border of the board
            Console.Write(" +");
            for (int j = 0; j < myBoard.Size; j++)
            {
                Console.Write("---+");
            }
            Console.WriteLine();
        }
    }
}
