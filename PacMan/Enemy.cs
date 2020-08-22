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
            SetRandomDirection();
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

        public void SetRandomDirection()
        {
            int directionCode = rand.Next(1, 5);
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
