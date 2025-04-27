using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WinFormsApp1
{
    /// <summary>
    /// Tracks player achievements in the game
    /// </summary>
    public class GameAchievements
    {
        // Achievement Flags
        public bool Clicked10Times { get; set; }
        public bool ReachedLevel5 {  get; set; }
        public bool AvoidedBombs { get; set; }
    }
}
