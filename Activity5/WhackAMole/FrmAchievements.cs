using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace WinFormsApp1
{
    /// <summary>
    /// Displays player achievements and their status
    /// </summary>
    public partial class FrmAchievements : Form
    {
        /// <summary>
        /// Initialize achievements form with current achievement status
        /// </summary>
        public FrmAchievements(GameAchievements achievements)
        {
            InitializeComponent();
            listAchievements.Items.Add($"10 Clicks: {(achievements.Clicked10Times ? "Recieved" : "Nothing Yet")}");
            listAchievements.Items.Add($"Levle 5 Reached: {(achievements.ReachedLevel5 ? "Recieved" : "Nothing Yet")}");
            listAchievements.Items.Add($"Bombs Avoided: {(achievements.AvoidedBombs ? "Recieved" : "Nothing Yet")}");
        }
    }
}
