using System.Drawing;

namespace Flappy_Monster2
{
    public class GameModel
    {
        public int MonsterX { get; set; } = 46;
        public int MonsterY { get; set; } = 205;
        public int MonsterWidth { get; set; } = 100;
        public int MonsterHeight { get; set; } = 82;

        public int PipeBottomX { get; set; } = 327;
        public int PipeBottomY { get; set; } = 413;
        public int PipeBottomWidth { get; set; } = 97;
        public int PipeBottomHeight { get; set; } = 199;

        public int PipeTopX { get; set; } = 526;
        public int PipeTopY { get; set; } = -4;
        public int PipeTopWidth { get; set; } = 92;
        public int PipeTopHeight { get; set; } = 206;

        public int GroundY { get; set; } = 609;
        public int GroundHeight { get; set; } = 91;

        public int Score { get; set; } = 0;
        public int PipeSpeed { get; set; } = 8;
        public int Gravity { get; set; } = 15;
        public bool GameOver { get; set; } = false;
        public bool IsGameStarted { get; set; } = false;

        public void Update()
        {
            if (!IsGameStarted || GameOver) 
                return;

            MonsterY += Gravity;
            PipeBottomX -= PipeSpeed;
            PipeTopX -= PipeSpeed;

            if (PipeBottomX < -150)
            {
                PipeBottomX = 800;
                Score++;
            }
            if (PipeTopX < -180)
            {
                PipeTopX = 950;
                Score++;
            }

            if (Score > 5) 
                PipeSpeed = 10;

            if (CheckCollision()) 
                GameOver = true;
        }

        public void Jump()
        {
            Gravity = -15;
        }

        public void ReleaseJump()
        {
            Gravity = 15;
        }

        public void StartGame()
        {
            IsGameStarted = true;
        }

        private bool CheckCollision()
        {
            Rectangle monsterRect = new Rectangle(MonsterX, MonsterY, MonsterWidth, MonsterHeight);
            Rectangle pipeBottomRect = new Rectangle(PipeBottomX, PipeBottomY, PipeBottomWidth, PipeBottomHeight);
            Rectangle pipeTopRect = new Rectangle(PipeTopX, PipeTopY, PipeTopWidth, PipeTopHeight);
            Rectangle groundRect = new Rectangle(0, GroundY, 677, GroundHeight);

            return monsterRect.IntersectsWith(pipeBottomRect) || monsterRect.IntersectsWith(pipeTopRect) ||
                   monsterRect.IntersectsWith(groundRect) || MonsterY < -25;
        }
    }
}