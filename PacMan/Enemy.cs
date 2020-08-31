using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace PacMan
{
    class Enemy : PictureBox
    {
        private Random rand = new Random();

        public Enemy()
        {
            InitializeEnemy();
            SetDirection(rand.Next(1, 5));
        }

        public int Step { get; set; } = 1;
        public int VerticalVelocity { get; set; } = 0;
        public int HorisontalVelocity { get; set; } = 0;

        private void InitializeEnemy()
        {
            this.BackColor = Color.Red;
            this.Size = new Size(40, 40);
            this.Tag = "Ghost";
        }

        /// <summary>
        /// Sets movement direction of the enemy
        /// </summary>
        /// <param name="directionCode">1-East, 2-South, 3-West, 4-North</param>
        public void SetDirection(int directionCode)
        {
            switch (directionCode)
            {
                case 1:
                    HorisontalVelocity = Step;
                    VerticalVelocity = 0;
                    break;
                case 2:
                    HorisontalVelocity = 0;
                    VerticalVelocity = Step;
                    break;
                case 3:
                    HorisontalVelocity = -Step;
                    VerticalVelocity = 0;
                    break;
                case 4:
                    HorisontalVelocity = 0;
                    VerticalVelocity = -Step;
                    break;
            }
        }
    }
}
