using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace PacMan
{
    class Score : PictureBox
    {
        private int frameCounter = 0;
        private Timer animationTimer = null;

        public Score(int score)
        {
            this.ScoreType = "score_" + score.ToString();
            InitializeScore();
            InitializeAnimationTimer();
        }

        public string ScoreType { get; private set; } = null;

        private void InitializeScore()
        {
            this.BackColor = Color.Transparent;
            this.Size = new Size(30, 15);
            this.SizeMode = PictureBoxSizeMode.StretchImage;
            this.Image = (Image)Properties.Resources.ResourceManager.GetObject(this.ScoreType);
            this.Name = "Score";
        }

        private void InitializeAnimationTimer()
        {
            animationTimer = new Timer();
            animationTimer.Interval = 50;
            animationTimer.Tick += new EventHandler(AnimationTimer_Tick);
            animationTimer.Start();
        }

        private void AnimationTimer_Tick(object sender, EventArgs e)
        {
            Animate();
        }

        private void Animate()
        {
            this.Top -= 2;
            frameCounter++;
            if (frameCounter > 30)
            {
                animationTimer.Stop();
                this.Dispose();
            }
        }
    }
}
