using ChessBoardModel;

namespace ChessBoardGUIApp
{
    public partial class frmChessBoard : Form
    {
        public Board myBoard = new Board(8);
        public Button[,] buttons = new Button[8, 8];

        // Color sets for button themes
        Color[] ColorSet1 = { Color.FromArgb(240, 240, 250), Color.FromArgb(220, 220, 220), Color.FromArgb(180, 233, 180), Color.LightBlue };
        Color[] ColorSet2 = { Color.FromArgb(220, 200, 200), Color.FromArgb(180, 160, 160), Color.LightCoral, Color.MistyRose };
        Color[] ColorSet3 = { Color.FromArgb(180, 180, 180), Color.FromArgb(160, 160, 160), Color.Aqua, Color.MediumAquamarine };

        public frmChessBoard()
        {
            InitializeComponent();
            SetupButtons();
        }

        // Populate the panel with buttons in a grid. 8x8 for chess
        private void SetupButtons()
        {
            // Calculate the buttons size. panel width / 8 = size of one button
            int buttonSize = panelChessBoard.Width / myBoard.Size;
            // Force the panel to be square
            panelChessBoard.Height = panelChessBoard.Width;
            // Create the buttons
            for (int row = 0; row < myBoard.Size; row++)
            {
                for (int col = 0; col < myBoard.Size; col++)
                {
                    // Dynamically create a button and place it on the panel
                    buttons[row, col] = new Button();
                    // Button is square
                    buttons[row, col].Width = buttonSize;
                    buttons[row, col].Height = buttonSize;
                    // Left = Left side of buttons. Each button is buttonSize wide
                    buttons[row, col].Left = col * buttonSize;
                    buttons[row, col].Top = row * buttonSize;
                    // Attach an event to the button
                    // Manually add this event handler to the buttons
                    buttons[row, col].Click += GridButtons_Click;
                    // The tag property can store an object. we will use it to store the row and column of the button
                    buttons[row, col].Tag = new Point(row, col);

                    // Set the face of teh buttons to be the coordinates
                    buttons[row, col].Text = row + "," + col;
                    // Add the button to the panel
                    panelChessBoard.Controls.Add(buttons[row, col]);
                }
            }
        }

        private void GridButtons_Click(object sender, EventArgs e)
        {
            Button b = (Button)sender;
            Point p = (Point)b.Tag;
            int row = p.X;
            int col = p.Y;
            MessageBox.Show("You clicked on row " + row + " and column " + col);

            string piece = comboPieceNames.Text;
            myBoard.MarkNextLegalMoves(myBoard.TheGrid[row, col], piece);
            UpdateButtonFaces(myBoard);
        }

        private void UpdateButtonFaces(Board myBoard)
        {
            // Map N to Knight, K to King, Q to Queen, B to Bishop, R to Rook, P to Pawn
            var pieceMap = new Dictionary<string, string>
            {
                {"N", "Knight"},
                {"K", "King"},
                {"Q", "Queen"},
                {"B", "Bishop"},
                {"R", "Rook"},
                {"P", "Pawn"}
            };

            for (int i = 0; i < myBoard.Size; i++) 
            {
                for (int j = 0; j < myBoard.Size; j++) 
                {
                    buttons[i, j].Text = "";
                    if (myBoard.TheGrid[i, j].IsLegalNextMove)
                        buttons[i, j].Text = "Legal move";
                    if (myBoard.TheGrid[i, j].IsCurrentlyOccupied != "")
                        // Map the occupied by letter to the name
                        // Example. If the cell is pccupied by "N", change it to "Knight"
                        buttons[i, j].Text = pieceMap[myBoard.TheGrid[i, j].IsCurrentlyOccupied];

                    Color color1 = ColorSet1[0];
                    Color color2 = ColorSet1[1];
                    Color color3 = ColorSet1[2];
                    Color color4 = ColorSet1[3];

                    if (radioButton2.Checked)
                    {
                        color1 = ColorSet2[0];
                        color2 = ColorSet2[1];
                        color3 = ColorSet2[2];
                        color4 = ColorSet2[3];
                    }

                    if (radioButton3.Checked)
                    {
                        color1 = ColorSet3[0];
                        color2 = ColorSet3[1];
                        color3 = ColorSet3[2];
                        color4 = ColorSet3[3];
                    }

                    // Checkerboard pattern the mod operation % return the remainder of a division. 5%2
                    if ((i + j) % 2 == 0)
                        buttons[i, j].BackColor = color1;
                    else
                        buttons[i, j].BackColor = color2;

                    // Highlight the legal moves
                    if (myBoard.TheGrid[i, j].IsLegalNextMove)
                        buttons[i, j].BackColor = color3;
                    if (myBoard.TheGrid[i, j].IsCurrentlyOccupied != "")
                        buttons[i, j].BackColor = color4;
                }
            }
        }
    }
}
