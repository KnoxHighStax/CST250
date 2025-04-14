using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MineSweeperClasses
{
    public class Cell
    {
        //Properties
        // The row position of the cell
        public int Row { get; set; }

        // The column position of the cell
        public int Column { get; set; }

        // When the cell has been revealed/clcked
        public bool IsVisited { get; set; }

        // True when the cell contains a bomb
        public bool IsBomb { get; set; }

        // True when the player has flagged the cell
        public bool IsFlagged { get; set; }

        // Count of adjacent bombs
        public int NumberOfBombNeighbors { get; set; }

        // True when the cell contains a power-up
        public bool HasSpecialReward { get; set; }

        // Constructor that initializes the cell default values
        public Cell(int row, int column)
        {
            Row = row;
            Column = column;
            IsVisited = false;
            IsBomb = false;
            IsFlagged = false;
            NumberOfBombNeighbors = 0;
            HasSpecialReward = false;

        }
    }
}
