using System;
using System.Windows.Forms;

namespace Flappy_Monster2
{
    static class Program
    {
        [STAThread]
        static void Main()
        {
            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);

            GameModel model = new GameModel();
            GameView view = new GameView();
            GameController controller = new GameController(model, view);

            view.gameTimer.Tick += controller.GameLoop;

            Application.Run(view);
        }
    }
}