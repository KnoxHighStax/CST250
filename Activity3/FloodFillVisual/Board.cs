using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FloodFillVisual
{
    class Board
    {
        public int Size;
        public Cell[,] Grid;

        Random random = new Random();

        public Board(int Size) 
        {
            this.Grid = new Cell[Size, Size];
            this.Size = Size;

            // Initializing all cells first empty state
            for (int i = 0; i < Size; i++)
            {
                for (int j = 0; j < Size; j++)
                {
                    Grid[i, j] = new Cell(i, j, "E");
                }
            }
            // Call to create random shapes
            CreateShapes();
        }

        // Random pattern, rectangles
        private void CreateShapes()
        {
            // Create 3-5 rectangles
            int rectangles = random.Next(3, 6);

            for (int i = 0; i < rectangles; i++) 
            {
                // Random dimensions of rectangle
                int width = random.Next(4, 8);
                int height = random.Next(4, 8);
                // Random starting position ensuring it fits in board boaunds
                int startCol = random.Next(1, Size - width - 1);
                int startRow = random.Next(1, Size - height - 1);

                // Draw top and bottom points
                for (int col = startCol; col < startCol + width; col++)
                {
                    Grid[startRow, col].Contents = "W";
                    Grid[startRow + height - 1, col].Contents = "W";
                }

                // Draw the left and right points
                for (int row = startRow + 1; row < startRow + height - 1; row++)
                {
                    Grid[row, startCol].Contents = "W";
                    Grid[row, startCol + width - 1].Contents = "W";
                }
            }
        }

        // Recursive floodfill algorithm
        public void FloodFill(int row, int col, string directions = "N, NE, E, SE, S, SW, W, NW", string comingFrom = "")
        {
            Console.ForegroundColor = ConsoleColor.White;
            Console.Write($"Checking at {row}, {col} ");
            Thread.Sleep(300);

            // Check to see if position is in bounds
            if (row < 0 || row >= Size || col < 0 || col >= Size)
            {
                Console.WriteLine("Out of bounds. Stop. ");
                return;
            }

            // Checks to see if already filled
            if (Grid[row, col].Contents == "F")
            {
                Console.WriteLine("Already filled, SKIP!");
                Thread.Sleep(300);
                return;
            }

            // Checks to see if its a wall
            if (Grid[row, col].Contents == "W")
            {
                Console.WriteLine("Its a wall! (JUMP)");
                Thread.Sleep(300);

                // Determin teh jump direction based on the oreientation method
                int jumpRow = row;
                int jumpCol = col;

                switch (comingFrom)
                {
                    case "N": jumpRow++; break;
                    case "S": jumpRow--; break;
                    case "E": jumpCol--; break;
                    case "W": jumpCol++; break;
                    case "NE":
                        jumpRow++;
                        jumpCol--;
                        break;
                    case "NW":
                        jumpRow++;
                        jumpCol++;
                        break;
                    case "SE":
                        jumpRow--;
                        jumpCol--;
                        break;
                    case "SW":
                        jumpRow--;
                        jumpCol++;
                        break;
                    default:
                        jumpRow++;
                        break;
                }
                // Recursively call flood fill on jumped positions
                FloodFill(jumpRow, jumpCol, directions, comingFrom);
                return;
            }
            // Fill current cell
            Grid[row, col].Contents = "F";
            Console.WriteLine("(Filled!)");
            Thread.Sleep(300);
            Program.PrintBoard(this);
           

            // process eacch dirction in the directions string
            foreach (string direction in directions.Split(',').Select(d => d.Trim()))
            {
                Console.ForegroundColor = GetDirectionColor(direction);
                Console.Write($"{direction}");

                // Recurively call flood fill in each specified direction
                switch (direction)
                {
                    case "N":
                        Console.Write("North ");
                        // North
                        FloodFill(row - 1, col, directions, "S");
                        break;
                    case "E":
                        Console.Write("East ");
                        // East
                        FloodFill(row, col + 1, directions, "W");
                        break;
                    case "S":
                        Console.Write("South ");
                        // South
                        FloodFill(row + 1, col, directions, "N");
                        break;
                    case "W":
                        Console.Write("West ");
                        // West
                        FloodFill(row, col - 1, directions, "E");
                        break;
                    case "NE":
                        Console.Write("North East ");
                        // North East
                        FloodFill(row - 1, col + 1, directions, "SW");
                        break;
                    case "SE":
                        Console.Write("South East ");
                        // South East
                        FloodFill(row + 1, col + 1, directions, "NW");
                        break;
                    case "SW":
                        Console.Write("South West ");
                        // South West
                        FloodFill(row + 1, col - 1, directions, "NE");
                        break;
                    case "NW":
                        Console.Write(" North West ");
                        // North West
                        FloodFill(row - 1, col - 1, directions, "SE");
                        break;
                }
            }
        }

        // returns a different console color for each direction
        private ConsoleColor GetDirectionColor(string direction)
        {
            return direction switch
            {
                "N" => ConsoleColor.Red,
                "NE" => ConsoleColor.Green,
                "E" => ConsoleColor.Blue,
                "SE" => ConsoleColor.Magenta,
                "S" => ConsoleColor.DarkBlue,
                "SW" => ConsoleColor.DarkGreen,
                "W" => ConsoleColor.Cyan,
                "NW" => ConsoleColor.DarkYellow,
                _ => ConsoleColor.White
            };
        }
    }
}
