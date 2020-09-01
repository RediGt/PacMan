﻿using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace PacMan
{
    class Food : PictureBox
    {
        private int Type { get; set; } = 1;
        public Food()
        {
            InitializeFood();
        }

        private void InitializeFood()
        {
            this.BackColor = Color.Transparent;
            this.Size = new Size(20, 20);
            this.Name = "Food";
        }
    }
}
