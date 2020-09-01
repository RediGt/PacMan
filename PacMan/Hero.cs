using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace PacMan
{
    class Hero : PictureBox
    {
        private Timer animationTimer = null;
        private Timer meltTimer = null;
        private Timer predatorModeTimer = null;
        private int frameCounter = 1;

        public Hero()
        {
            InitializeHero();
            InitializeAnimationTimer();
        }

        public int Step { get; set; } = 2;
        public int VerticalVelocity { get; set; } = 0;
        public int HorisontalVelocity { get; set; } = 0;
        public string Direction { get; set; } = "right";
        public bool PredatorMode { get; set; } = false;

        private void InitializeHero()
        {
            this.BackColor = Color.Transparent;
            this.Size = new Size(30, 30);
            this.Location = new Point(200, 200);
            this.Name = "Pacman";           
        }

        private void InitializeAnimationTimer()
        {
            animationTimer = new Timer();
            animationTimer.Interval = 200;
            animationTimer.Tick += new EventHandler(AnimationTimer_Tick);
            animationTimer.Start();
        }

        private void AnimationTimer_Tick(object sender, EventArgs e)
        {
            MoveAnimate();
        }

        private void MoveAnimate()
        {
            string imageName = "pacman_" + this.Direction + "_" + frameCounter.ToString();
            this.Image = (Image)Properties.Resources.ResourceManager.GetObject(imageName);
            this.SizeMode = PictureBoxSizeMode.StretchImage;
            frameCounter++;
            if (frameCounter > 4)
                frameCounter = 1;
        }

        public void StopMove()
        {
            animationTimer.Stop();
            frameCounter = 0;
            InitializeMeltTimer();
        }


        private void InitializeMeltTimer()
        {
            meltTimer = new Timer();
            meltTimer.Interval = 100;
            meltTimer.Tick += new EventHandler(MeltTimer_Tick);
            meltTimer.Start();
        }

        private void MeltTimer_Tick(object sender, EventArgs e)
        {
            MeltAnimate();
        }

        private void MeltAnimate()
        {
            string imageName = "pacman_melt_" + frameCounter.ToString();
            this.Image = (Image)Properties.Resources.ResourceManager.GetObject(imageName);
            this.SizeMode = PictureBoxSizeMode.StretchImage;
            frameCounter++;
            if (frameCounter > 14)
            {
                meltTimer.Stop();
            }
        }
    }
}
