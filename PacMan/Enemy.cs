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
        public Enemy()
        {
            InitializeEnemy();
        }

        private void InitializeEnemy()
        {
            this.BackColor = Color.Red;
            this.Size = new Size(40, 40);

        }
    }
}
