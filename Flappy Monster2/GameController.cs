using System;
using System.Windows.Forms;

namespace Flappy_Monster2
{
    public class GameController
    {
        private GameModel model;
        private GameView view;

        public GameController(GameModel model, GameView view)
        {
            this.model = model;
            this.view = view;

            view.KeyDownEvent += View_KeyDown;
            view.KeyUpEvent += View_KeyUp;

            view.UpdateView(model);
        }

        private void View_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Space)
            {
                if (!model.IsGameStarted)
                {
                    model.StartGame();
                    view.StartTimer();
                }
                if (!model.GameOver)
                    model.Jump();
            }
        }

        private void View_KeyUp(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Space && model.IsGameStarted && !model.GameOver)
                model.ReleaseJump();
        }

        public void GameLoop(object sender, EventArgs e)
        {
            if (!model.GameOver)
            {
                model.Update();
                view.UpdateView(model);
            }
        }
    }
}