namespace MineSweeperGUI
{
    static class Program
    {
        [STAThread]
        static void Main()
        {
            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);

            // Show start menu first 
            using (var startForm = new FrmStartMenu())
            {
                if (startForm.ShowDialog() == DialogResult.OK)
                {
                    // Start main game with selected settings 
                    Application.Run(new Form1(startForm.BoardSize, startForm.Difficulty));
                }
            }
        }
    }
}