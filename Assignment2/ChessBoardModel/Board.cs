using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ChessBoardModel
{
    public class Board
    {
        // The board is always a square: Usually 8x8
        public int Size { get; set; }

        // Create a 2d array of cells
        public Cell[,] TheGrid { get; set; }

        // Constructor - Create the board and fill it with cells
        public Board(int s)
        {
            Size = s;
            TheGrid = new Cell[Size, Size];

            // Initailizing each cell in the grid
            for (int i = 0; i < Size; i++)
            {
                for (int j = 0; j < Size; j++)
                {
                    TheGrid[i, j] = new Cell(i, j);
                }
            }
        }

        // Method to clear all marks from the board, occupied pieces and legal moves
        public void ClearBoard()
        {
            // Reset all cells to empty
            foreach (Cell Cell in TheGrid)
            {
                Cell.IsCurrentlyOccupied = "";
                Cell.IsLegalNextMove = false;
            }    
        }

        // Method to mark legal moves for teh specified chess piece at the target cell
        public void MarkNextLegalMoves(Cell targetCell, string chessPiece)
        {
            ClearBoard();

            // Setting the piece on the grid
            TheGrid[targetCell.Row, targetCell.Column].IsCurrentlyOccupied = GetPieceSymbol(chessPiece);
            switch (chessPiece.ToLower())
            {
                case "knight":
                    // All 8 possible knight moves
                    // Knights move in an L shape: 2 squares in one direction, then 1 square perpendicular
                    int[] rowOffsets = { 2, 2, -2, -2, 1, 1, -1, -1 };
                    int[] colOffsets = { 1, -1, 1, -1, 2, -2, 2, -2 };

                    for (int i = 0; i < 8; i++)
                    {
                        int newRow = targetCell.Row + rowOffsets[i];
                        int newCol = targetCell.Column + colOffsets[i];

                        // Only mark if the move is within teh board bounds
                        if (IsOnTheBoard(newRow, newCol))
                        {
                            TheGrid[newRow, newCol].IsLegalNextMove = true;
                        }
                    }
                    break;
                case "rook":
                    // Horizontal and vertically any number of squares
                    for (int i = 0; i < Size; i++)
                    {
                        // Vertical moves
                        if (i != targetCell.Row)
                        {
                            TheGrid[i, targetCell.Column].IsLegalNextMove = true;
                        }

                        // The Horizontal moves
                        if (i != targetCell.Column)
                        {
                            TheGrid[targetCell.Row, i].IsLegalNextMove = true;
                        }
                    }
                    break;
                case "bishop":
                    // Diagonal moves any number of squares
                    for (int i = 1; i < Size; i++)
                    {
                        // Top Right Diagonal
                        if (IsOnTheBoard(targetCell.Row + i, targetCell.Column + i))
                            TheGrid[targetCell.Row + i, targetCell.Column + i].IsLegalNextMove = true;

                        // Top Left Diagonal
                        if (IsOnTheBoard(targetCell.Row + i, targetCell.Column - i))
                            TheGrid[targetCell.Row + i, targetCell.Column - i].IsLegalNextMove = true;

                        // Bottom Right Diagonal
                        if (IsOnTheBoard(targetCell.Row - i, targetCell.Column + i))
                            TheGrid[targetCell.Row - i, targetCell.Column + i].IsLegalNextMove = true;

                        // Bottom Left Diagonal
                        if (IsOnTheBoard(targetCell.Row - i, targetCell.Column - i))
                            TheGrid[targetCell.Row - i, targetCell.Column - i].IsLegalNextMove = true;
                    }
                    break;
                case "queen":
                    // Going to be a Combination of the movements of teh Rook and teh Bishop
                    // Rook like movements, straight
                    for (int i = 0; i < Size; i++)
                    {
                        if (i != targetCell.Row)
                            TheGrid[i, targetCell.Column].IsLegalNextMove = true;

                        if (i != targetCell.Column)
                            TheGrid[targetCell.Row, i].IsLegalNextMove = true;
                    }

                    // Bishop like movements, diagonal
                    for (int i = 1; i < Size; i++)
                    {
                        if (IsOnTheBoard(targetCell.Row + i, targetCell.Column + i))
                            TheGrid[targetCell.Row + i, targetCell.Column + i].IsLegalNextMove = true;

                        if (IsOnTheBoard(targetCell.Row + i, targetCell.Column - i))
                            TheGrid[targetCell.Row + i, targetCell.Column - i].IsLegalNextMove = true;

                        if (IsOnTheBoard(targetCell.Row - i, targetCell.Column + i))
                            TheGrid[targetCell.Row - i, targetCell.Column + i].IsLegalNextMove = true;

                        if (IsOnTheBoard(targetCell.Row - i, targetCell.Column - i))
                            TheGrid[targetCell.Row - i, targetCell.Column - i].IsLegalNextMove = true;
                    }
                    break;
                case "king":
                    // All adjacent squares, so one square in any direction
                    for (int rowOffSet = -1; rowOffSet <= 1; rowOffSet++)
                    {
                        for (int colOffSet = -1; colOffSet <= 1; colOffSet++)
                        {
                            // Here we will skip the king's current position as an option
                            if (rowOffSet == 0 && colOffSet ==0) continue;

                            int newRow = targetCell.Row + rowOffSet;
                            int newCol = targetCell.Column + colOffSet;

                            if (IsOnTheBoard(newRow, newCol))
                            {
                                TheGrid[newRow, newCol].IsLegalNextMove = true;
                            }
                        }
                    }
                    break;
                case "pawn":
                    // Move forward one square
                    if (IsOnTheBoard(targetCell.Row - 1, targetCell.Column))
                    {
                        TheGrid[targetCell.Row - 1, targetCell.Column].IsLegalNextMove = true;
                    }

                    // The first move can have the option to move forward one or two spaces
                    if (targetCell.Row == 6 && IsOnTheBoard(targetCell.Row - 2, targetCell.Column))
                    {
                        TheGrid[targetCell.Row - 2, targetCell.Column].IsLegalNextMove = true;
                    }

                    // Taking a piece, moving in a diagonal direction
                    if (IsOnTheBoard(targetCell.Row - 1, targetCell.Column - 1))
                    {
                        TheGrid[targetCell.Row - 1, targetCell.Column - 1].IsLegalNextMove = true;
                    }
                    if (IsOnTheBoard(targetCell.Row - 1, targetCell.Column + 1))
                    {
                        TheGrid[targetCell.Row - 1, targetCell.Column + 1].IsLegalNextMove = true;    
                    }
                    break;
            }
        }

        // This method checks if a given position is within the bounds of the board
        public bool IsOnTheBoard(int row, int col)
        {
            return row >= 0 && row < Size && col >= 0 && col < Size;
        }

        private string GetPieceSymbol(string pieceName)
        {
            switch (pieceName.ToLower())
            {
                case "knight": return "N";
                case "rook": return "R";
                case "bishop": return "B";
                case "queen": return "Q";
                case "king": return "K";
                case "pawn": return "P";
                default: return "?";
            }
        }
    }
}
