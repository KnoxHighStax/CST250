using MineSweeperClasses;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace MineSweeperGUI
{
    public partial class Form4 : Form
    {
        // Stores current game stats
        GameStat gameStat;
        // Used for data binding with the DataGridView
        BindingSource bindingSource = new BindingSource();
        // List to store all game stats
        public List<GameStat> statList = new List<GameStat>();

        // Constructor taht intializes the high scores form with player name and score
        public Form4(string name, int score)
        {
            InitializeComponent();
            // Creating new game stat entry
            gameStat = new GameStat();
            gameStat.Name = name;
            gameStat.Score = score;
            gameStat.Date = DateTime.Now;
            gameStat.Id = statList.Count + 1;
            statList.Add(gameStat);

            // Setup DataGridView
            bindingSource.DataSource = typeof(GameStat);
            bindingSource.DataSource = statList;
            dataGridViewHighScores.DataSource = bindingSource;

            // Confirm menu
            ConfigureMenu();
        }

        // Method to set up the event handlers for the menu items
        private void ConfigureMenu()
        {
            saveToolStripMenuItem.Click += saveToolStripMenuItem_Click;
            loadToolStripMenuItem.Click += loadToolStripMenuItem_Click;
            exitToolStripMenuItem.Click += exitToolStripMenuItem_Click;
            byScoreToolStripMenuItem.Click += byScoreToolStripMenuItem_Click;
            byDateToolStripMenuItem.Click += byDateToolStripMenuItem_Click;
        }

        // Method to close the high scores form when OK button is clicked
        private void btnHSOK_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        // Method that handles saving the high score to a file
        private void saveToolStripMenuItem_Click(object? sender, EventArgs e)
        {
            SaveFileDialog saveFileDialog = new SaveFileDialog();
            saveFileDialog.Filter = "Text Files (*.txt)|*.txt|All Files (*.*)|*.*";
            if (saveFileDialog.ShowDialog() == DialogResult.OK)
            {
                try
                {
                    // Creating a temporary file for safe saving
                    string tempFile = Path.GetTempFileName();

                    // To preserve existing file if is available
                    if (File.Exists(saveFileDialog.FileName))
                    {
                        File.Copy(saveFileDialog.FileName, tempFile, true);
                    }

                    // Write all stats to the file
                    using (StreamWriter writer = File.AppendText(tempFile))
                    {
                        foreach (var stat in statList)
                        {
                            writer.WriteLine($"{stat.Id},{stat.Name},{stat.Score},{stat.Date}");
                        }
                    }
                    // To replace the original file with the temporary file
                    File.Replace(tempFile, saveFileDialog.FileName, null);

                    MessageBox.Show($"High scores appended successfully!", "Success",
                        MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
                catch (Exception ex)
                {
                    MessageBox.Show($"Error saving file: {ex.Message}", "Error",
                        MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
        }

        // Method that handles loading the high scores from a file
        private void loadToolStripMenuItem_Click(object? sender, EventArgs e)
        {
            OpenFileDialog openFileDialog = new OpenFileDialog();
            openFileDialog.Filter = "Text Files (*.txt)|*.txt|All Files (*.*)|*.*";
            if (openFileDialog.ShowDialog() == DialogResult.OK)
            {
                try
                {
                    // Clear the existing stats
                    statList.Clear();
                    // Read file line by line
                    using (StreamReader reader = new StreamReader(openFileDialog.FileName))
                    {
                        string line;
                        while ((line = reader.ReadLine()) != null)
                        {
                            string[] parts = line.Split(',');
                            if (parts.Length == 4)
                            {
                                // Create new GameStat from file data
                                GameStat stat = new GameStat
                                {
                                    Id = int.Parse(parts[0]),
                                    Name = parts[1],
                                    Score = int.Parse(parts[2]),
                                    Date = DateTime.Parse(parts[3]),
                                };
                                statList.Add(stat);
                            }
                        }
                    }
                    // Refresh the data binding
                    bindingSource.ResetBindings(false);
                }
                catch (Exception ex)
                {
                    MessageBox.Show($"Error loading file: {ex.Message}", "Error",
                        MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
        }

        // Method that will close the high scores form
        private void exitToolStripMenuItem_Click(object? sender, EventArgs e)
        {
            this.Close();
        }

        // Method to sort score by name
        private void byNameToolStripMenuItem_Click(object? sender, EventArgs e)
        {
            statList = statList.OrderBy(s => s.Name).ToList();
            bindingSource.DataSource = null;
            bindingSource.DataSource = statList;
            dataGridViewHighScores.Refresh();
        }

        // Method that sorts scores by score
        private void byScoreToolStripMenuItem_Click(object? sender, EventArgs e)
        {
            statList = statList.OrderByDescending(s => s.Score).ToList();
            bindingSource.DataSource = null;
            bindingSource.DataSource = statList;
            dataGridViewHighScores.Refresh();
        }

        // Method that sorts scores by date
        private void byDateToolStripMenuItem_Click(object? sender, EventArgs e)
        {
            statList = statList.OrderByDescending(s => s.Date).ToList();
            bindingSource.DataSource = null;
            bindingSource.DataSource = statList;
            dataGridViewHighScores.Refresh();
        }
    }
}
