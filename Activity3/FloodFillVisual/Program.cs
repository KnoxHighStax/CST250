namespace FloodFillVisual
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Hello, World!");
            Console.OutputEncoding = System.Text.Encoding.UTF8;
            ShowBoard();
        }

        private static void ShowBoard()
        {
            Board board = new Board(20);
            PrintBoard(board);

            // let user choose flood fill type
            Console.WriteLine("\nChoose fill type:");
            Console.WriteLine("1) 4-way N,S,E,W");
            Console.WriteLine("2) 8-way with diagonals");
            Console.Write("Your choive: ");

            // Set directions base don user choice
            string directions = Console.ReadLine() == "1"
                ? "N,E,S,W"
                : "N,NE,E,SE,S,SW,W,NW";

            // Get staring position from user
            Console.WriteLine("\nWhat row would you like to start with?");
            int startRow = int.Parse(Console.ReadLine());

            Console.WriteLine("What column would you like to start with?");
            int startCol = int.Parse(Console.ReadLine());
            //Begin flood fill
            board.FloodFill(startRow, startCol, directions);
            // Show final results
            Console.WriteLine("\nAfter the Flood Fill");
            PrintBoard(board);
            Console.ReadLine();
        }

        // Method to print teh current state of teh baord
        public static void PrintBoard(Board board)
        {
            Console.Clear();
            // Print column numbers with color
            Console.ForegroundColor = ConsoleColor.Magenta;
            Console.Write("   ");
            for (int i = 0; i < board.Size; i++)
            {
                Console.ForegroundColor = ConsoleColor.DarkGray;
                Console.Write($"{i % 10} ");
            }
            Console.WriteLine();

            for (int i = 0; i < board.Size; i++) 
            {
                // row number
                Console.ForegroundColor = ConsoleColor.DarkGray;
                Console.Write($"{i % 100,2} ");

                for (int j = 0; j < board.Size; j++)
                {
                    Console.BackgroundColor = ConsoleColor.Black;

                    if (board.Grid[i, j].Contents == "W")
                    {
                        Console.BackgroundColor = ConsoleColor.DarkRed;
                        Console.ForegroundColor = ConsoleColor.White;
                        Console.Write("W");
                    }
                    else if (board.Grid[i, j].Contents == "E")
                    {
                        Console.ForegroundColor = ConsoleColor.DarkGray;
                        Console.Write(".");
                    }
                    else if (board.Grid[i,j].Contents == "F")
                    {
                        Console.BackgroundColor = ConsoleColor.DarkGreen;
                        Console.ForegroundColor = ConsoleColor.Black;
                        Console.Write("F");
                    }
                    Console.Write(" ");
                    Console.ResetColor();
                }

                Console.WriteLine();

            }
            // Print legend
            Console.WriteLine("\nKey:");
            Console.Write(" ");
            Console.ForegroundColor = ConsoleColor.White;
            Console.Write(".");
            Console.ForegroundColor = ConsoleColor.White;
            Console.WriteLine(" = Empty");

            Console.ForegroundColor = ConsoleColor.White;
            Console.Write("W");
            Console.ForegroundColor = ConsoleColor.White;
            Console.WriteLine(" = Wall");

            Console.ForegroundColor = ConsoleColor.White;
            Console.Write("F");
            Console.ForegroundColor = ConsoleColor.White;
            Console.WriteLine(" = Filled");

            Console.ResetColor();

        }
    }
}
