using System.Windows.Forms;

namespace VerseIndenting
{
    public partial class FormVerses : Form
    {
        List<Verse> verses = new List<Verse>();

        // Defining colors for each level of recursion
        private Color[] levelColors = new Color[]
        {
            Color.Red,
            Color.Blue,
            Color.Green,
            Color.Yellow,
            Color.Orange,
            Color.Purple,
            Color.Teal,
            Color.Magenta
        };

        public FormVerses()
        {
            InitializeComponent();

            // Hardcoded verse data
            verses = new List<Verse> {
            new Verse("A", "God said, 'This is the sign of the covenant which I am making between Me and you and every living creature that is with you, for all future generations (v.12)'"),
            new Verse("B", "I have set My rainbow in the cloud, and it shall serve as a sign of a covenant between Me and the earth (v.13)"),
            new Verse("C", "It shall come about, when I make a cloud appear over the earth, that the rainbow will be seen in the cloud (v.14)"),
            new Verse("D", "And I will remember My covenant, which is between Me and you and every living creature of all flesh, and never again shall the water become a flood to destroy all flesh (v.15)"),
            new Verse("C", "When the rainbow is in teh cloud, then I will look at it (v.16)"),
            new Verse("B", "to remember the everlasting covenant between God and every living creature of all flesh that is on the earth"),
            new Verse("A", "God said to Noah, 'This is the sign of the covenant which i have established between Me and all flesh that is on earth'")
        };
            DisplayVersesRecursively(0, verses.Count - 1, 0);
        }

        // Recursive function to display verses in a chain
        private void DisplayVersesRecursively(int start, int end, int level)
        {
            // Start is teh index of the first verse in the chiasm, end is the index of the least verse in the chiasm.
            // The level is the current level of recursion used to calculate padding
            // Base case: If the start index is greater tahn the end index, return or "break" our of the recursion
            if (start > end) return;

            // Calculate padding based on recursion level
            int padding = level * 20;

            // Display the first part of the chiasm
            AddVerseToPanel(verses[start], padding, level);

            // Recurse into the next level if not at the middle yet
            if (start != end)
            {
                // Call the next "step" of the recursion
                DisplayVersesRecursively(start + 1, end - 1, level + 1);

                // Unwind the recursion by displaying teh second part of the chiasm
                AddVerseToPanel(verses[end], padding, level);
            }
        }

        // Create a label for each verse and add it to teh panel with the appropriate padding
        private void AddVerseToPanel(Verse verse, int padding, int level)
        {
            Label label = new Label
            {
                Text = $"{verse.Label}: {verse.Text}",
                Padding = new Padding(padding, 0, 0, 0),
                ForeColor = Color.Red,
                AutoSize = true
            };
            // Set color based on recursion level
            int colorIndex = level % levelColors.Length;
            label.ForeColor = levelColors[colorIndex];

            // Padding is used to indent the labels based on the recursion level.
            // The flowLayout panle automatically arranges the labels in a flow layout.
            // Be sure to change teh panel's AutoScroll property to tru if you have many verses.
            // Change the orientation of the flow layout panel to vertical so that the verses are display from top to bottom.
            flowLayoutPanel1.Controls.Add(label);
        }

        private void openToolStripMenuItem_Click(object sender, EventArgs e)
        {
            OpenFileDialog openFileDialog = new OpenFileDialog
            {
                Filter = "Text Files (*.txt)|*.txt",
                Title = "Open Verses File"
            };

            if (openFileDialog.ShowDialog() == DialogResult.OK)
            {
                try
                {
                    string[] lines = File.ReadAllLines(openFileDialog.FileName);
                    ParseVersesFromFile(lines);
                    flowLayoutPanel1.Controls.Clear();
                    DisplayVersesRecursively(0, verses.Count - 1, 0);
                }
                catch (Exception ex)
                {
                    MessageBox.Show($"Error readin file: {ex.Message}", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
        }

        private void ParseVersesFromFile(string[] lines)
        {
            // Clear existing verses
            verses.Clear();

            foreach (string line in lines)
            {
                if (string.IsNullOrWhiteSpace(line))
                    continue;
                string[] parts = line.Split('|');
                if (parts.Length != 2)
                {
                    MessageBox.Show($"Invalid line format: '{line}'. Expected 'Label|Text' .", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    continue;
                }
                verses.Add(new Verse(parts[0].Trim(), parts[1].Trim()));
            }
        }
    }

}

