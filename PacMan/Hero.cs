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
        public Hero()
        {
            InitializeHero();
        }

        public int Step { get; set; } = 2;
        public int VerticalVelocity { get; set; } = 0;
        public int HorisontalVelocity { get; set; } = 0;

        private void InitializeHero()
        {
            this.BackColor = Color.Yellow;
            this.Size = new Size(30, 30);
            this.Location = new Point(200, 200);
            this.Name = "Pacman";
        }
    }
}
