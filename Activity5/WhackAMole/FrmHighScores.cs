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
    /// Displays high scores in a list
    /// </summary>
    public partial class FrmHighScores : Form
    {
        /// <summary>
        /// Initialize high scores form with sorted scores
        /// </summary>
        public FrmHighScores(List<GameScore> highScores)
        {
            InitializeComponent();

            // Sort scores by score descending
            highScores = highScores.OrderByDescending(score => score.Score).ToList();

            // Display in listbox
            listHighScores.DataSource = highScores;
        }

    }
}
