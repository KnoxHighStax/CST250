﻿using System;
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
        public enum GameStatus { InProgress, Won, Lost}

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
                    Cells[row, col] = new Cell(row,col);
                }
            }
            
            RewardRemaining = 0;
            InitializeBoard();
        }

        // Initializes the game board with bombs, rewards and calculates neighbors
        private void InitializeBoard()
        {
            SetupBombs();
            CalculateNumberOfBombNeighbors();
            StartTime = DateTime.Now;
        }

        // Used when a player selects a cell and choose to play the reawrd
        public void UseSpecialBonus() { }

        // Used after game is over to calculate final score
        public int DetermineFinalScore() { return 0; }

        // A helper method to determine if a cell is out of bounds
        private bool IsCellOnBoard(int row, int col) {  return false; }

        // Used during a setup to claculate the number of bomb neighbors for each cell
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

        // Helper method to determine the number of bomb neighbors for a cell
        // private int GetNumberOfBombsNeighbors(int row, int col) { }

        // Used during setup to place bombs on the board, will randomly place bomvs based on the difficulty
        public void SetupBombs() 
        {
            Random random = new Random();

            for (int row = 0; row < Size; row++)
            {
                for (int col= 0; col < Size; col++)
                {
                    // Set bomb based on probability
                    Cells[row, col].IsBomb = random.NextDouble() < Difficulty;
                }
            }
        }

        // Used during setup to place rewards on the board randomly (will be place on cells already not containing a bomb)
        private void SetupRewards() { }


    }
}
