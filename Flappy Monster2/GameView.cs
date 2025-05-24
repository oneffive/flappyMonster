using System;
using System.Windows.Forms;

namespace Flappy_Monster2
{
    public partial class GameView : Form
    {
        private PictureBox flappyMonster;
        private PictureBox pipeTop;
        private PictureBox pipeBottom;
        private PictureBox ground;
        private Label scoreText;
        private Label startPrompt;
        public Timer gameTimer;
        private System.ComponentModel.IContainer components = null;
        public event EventHandler<KeyEventArgs> KeyDownEvent;
        public event EventHandler<KeyEventArgs> KeyUpEvent;

        public GameView()
        {
            InitializeComponent();
        }

        private void InitializeComponent()
        {
            this.components = new System.ComponentModel.Container();
            this.scoreText = new System.Windows.Forms.Label();
            this.startPrompt = new System.Windows.Forms.Label();
            this.ground = new System.Windows.Forms.PictureBox();
            this.pipeBottom = new System.Windows.Forms.PictureBox();
            this.pipeTop = new System.Windows.Forms.PictureBox();
            this.flappyMonster = new System.Windows.Forms.PictureBox();
            this.gameTimer = new System.Windows.Forms.Timer(this.components);
            ((System.ComponentModel.ISupportInitialize)(this.ground)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pipeBottom)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pipeTop)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.flappyMonster)).BeginInit();
            this.SuspendLayout();

            this.scoreText.AutoSize = true;
            this.scoreText.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(255)))), ((int)(((byte)(192)))));
            this.scoreText.Font = new System.Drawing.Font("Arial Narrow", 24F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.scoreText.Location = new System.Drawing.Point(11, 9);
            this.scoreText.Name = "scoreText";
            this.scoreText.Size = new System.Drawing.Size(149, 46);
            this.scoreText.Text = "Score: 0";

            this.startPrompt.AutoSize = true;
            this.startPrompt.Font = new System.Drawing.Font("Arial Narrow", 24F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.startPrompt.ForeColor = System.Drawing.Color.White;
            this.startPrompt.Location = new System.Drawing.Point(150, 300);
            this.startPrompt.Name = "startPrompt";
            this.startPrompt.Size = new System.Drawing.Size(350, 46);
            this.startPrompt.Text = "Нажмите Пробел для старта";
            this.startPrompt.BackColor = System.Drawing.Color.Transparent;

            this.ground.Image = global::Flappy_Monster2.Properties.Resources.ground;
            this.ground.Location = new System.Drawing.Point(-3, 609);
            this.ground.Name = "ground";
            this.ground.Size = new System.Drawing.Size(677, 91);
            this.ground.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.ground.TabIndex = 3;
            this.ground.TabStop = false;

            this.pipeBottom.Image = global::Flappy_Monster2.Properties.Resources.pipe;
            this.pipeBottom.Location = new System.Drawing.Point(327, 413);
            this.pipeBottom.Name = "pipeBottom";
            this.pipeBottom.Size = new System.Drawing.Size(97, 199);
            this.pipeBottom.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.pipeBottom.TabIndex = 2;
            this.pipeBottom.TabStop = false;

            this.pipeTop.Image = global::Flappy_Monster2.Properties.Resources.pipedown;
            this.pipeTop.Location = new System.Drawing.Point(526, -4);
            this.pipeTop.Name = "pipeTop";
            this.pipeTop.Size = new System.Drawing.Size(92, 206);
            this.pipeTop.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.pipeTop.TabIndex = 1;
            this.pipeTop.TabStop = false;

            this.flappyMonster.Image = global::Flappy_Monster2.Properties.Resources.flappyMonster;
            this.flappyMonster.Location = new System.Drawing.Point(46, 205);
            this.flappyMonster.Name = "flappyMonster";
            this.flappyMonster.Size = new System.Drawing.Size(100, 82);
            this.flappyMonster.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.flappyMonster.TabIndex = 0;
            this.flappyMonster.TabStop = false;

            this.gameTimer.Interval = 20;
            this.gameTimer.Tick += new System.EventHandler(this.GameTimer_Tick);

            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.Aqua;
            this.ClientSize = new System.Drawing.Size(650, 699);
            this.Controls.Add(this.startPrompt);
            this.Controls.Add(this.scoreText);
            this.Controls.Add(this.flappyMonster);
            this.Controls.Add(this.ground);
            this.Controls.Add(this.pipeBottom);
            this.Controls.Add(this.pipeTop);
            this.Font = new System.Drawing.Font("Arial Narrow", 7.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.Name = "GameView";
            this.Text = "Flappy Monster Game - Moo ICT";
            this.KeyDown += new System.Windows.Forms.KeyEventHandler(this.GameView_KeyDown);
            this.KeyUp += new System.Windows.Forms.KeyEventHandler(this.GameView_KeyUp);
            ((System.ComponentModel.ISupportInitialize)(this.ground)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pipeBottom)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pipeTop)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.flappyMonster)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();
        }

        private void GameView_KeyDown(object sender, KeyEventArgs e)
        {
            KeyDownEvent?.Invoke(this, e);
        }

        private void GameView_KeyUp(object sender, KeyEventArgs e)
        {
            KeyUpEvent?.Invoke(this, e);
        }

        private void GameTimer_Tick(object sender, EventArgs e)
        {

        }

        public void UpdateView(GameModel model)
        {
            flappyMonster.Location = new System.Drawing.Point(model.MonsterX, model.MonsterY);
            pipeBottom.Location = new System.Drawing.Point(model.PipeBottomX, model.PipeBottomY);
            pipeTop.Location = new System.Drawing.Point(model.PipeTopX, model.PipeTopY);
            scoreText.Text = $"Score: {model.Score}";
            startPrompt.Visible = !model.IsGameStarted;
            if (model.GameOver)
            {
                gameTimer.Stop();
                scoreText.Text += "   Game over!";
            }
        }

        public void StartTimer()
        {
            gameTimer.Start();
        }

        public void StopTimer()
        {
            gameTimer.Stop();
        }
    }
}