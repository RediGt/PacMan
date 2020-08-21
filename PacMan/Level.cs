using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace PacMan
{
    class Level : PictureBox
    {
        public Level()
        {
            InitializeLevel();
        }

        private void InitializeLevel()
        {
            this.BackColor = Color.DarkSlateBlue;
            this.Size = new Size(400, 400);
            this.Location = new Point(20, 20);
            this.Name = "Level";
        }
    }
}
