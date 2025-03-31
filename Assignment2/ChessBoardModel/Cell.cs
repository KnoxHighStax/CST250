using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ChessBoardModel
{
    public class Cell
    {
        public int Row { get; set; }
        public int Column { get; set; }
        public String IsCurrentlyOccupied { get; set; }
        public bool IsLegalNextMove { get; set; }

        // Constructor
        public Cell(int r, int c)
        {
            // Each cell has a row and column number
            Row = r;
            Column = c;

            // By default the cell is not occupied by a piece nor is it a legal next move
            IsCurrentlyOccupied = "";
            IsLegalNextMove = false;
        }
    }
}
