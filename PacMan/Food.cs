using System;
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
            this.SizeMode = PictureBoxSizeMode.StretchImage;
            this.Name = "Food";
            this.SetFoodType(1);
        }

        public void SetFoodType(int type)
        {
            this.Type = type;
            this.Image = (Image)Properties.Resources.ResourceManager.GetObject("food_" + type.ToString());
        }
        public int GetFoodType()
        {
            return this.Type;
        }
    }
}
