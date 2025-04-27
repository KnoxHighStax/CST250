using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WinFormsApp1
{
    public class GameScore
    {
        // Properties
        public int Id {  get; set; }
        public int Score { get; set; }
        public int Level { get; set; }
        public DateTime Date { get; set; }
        public string PlayerName { get; set; }

        /// <summary>
        /// Constructor to indicate a GameScore with player data
        /// </summary>
        public GameScore(string playerName, int id, int score, int level)
        {
            PlayerName = playerName; 
            Id = id;
            Score = score;
            Level = level;
            Date = DateTime.Now;
        }

        public GameScore() { }
        
        public override string ToString()
        {
            return $"{PlayerName}: {Score} pts (Level {Level}, Id: {Id}) - {Date.ToShortDateString()}";
        }
    }
}
