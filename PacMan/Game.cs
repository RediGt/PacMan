using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace PacMan
{
    public partial class Game : Form
    {
        private int initialEnemyCount = 4;

        private Random rand = new Random();
        private readonly Level level = new Level();
        private Hero hero = new Hero();
        private Timer mainTimer = null;
        private List<Enemy> enemies = new List<Enemy>();

        public Game()
        {
            InitializeComponent();
            InitializeGame();
            InitializeMainTimer();
        }

        private void InitializeGame()
        {
            this.Size = new Size(500, 500);
            this.KeyDown += new KeyEventHandler(Game_KeyDown);
            AddLevel();
            AddHero();
            AddEnemy();
        }

        private void AddLevel()
        {
            this.Controls.Add(level);
        }

        private void AddHero()
        {
            this.Controls.Add(hero);
            hero.BringToFront();
        }

        private void InitializeMainTimer()
        {
            mainTimer = new Timer();
            mainTimer.Tick += new EventHandler(MainTimer_Tick);
            mainTimer.Interval = 20;           
            mainTimer.Start();
        }

        private void MainTimer_Tick(object sender, EventArgs e)
        {
            MoveHero();
            HeroBorderCollision();
            MoveEnemies();
        }

        private void MoveHero()
        {
            hero.Left += hero.HorisontalVelocity;
            hero.Top += hero.VerticalVelocity;
        }

        private void MoveEnemies()
        {
            foreach (var enemy in enemies)
            {
                enemy.Left += enemy.HorisontalVelocity;
                enemy.Top += enemy.VerticalVelocity;
            }
        }

        private void Game_KeyDown(object sender, KeyEventArgs e)
        {
            switch (e.KeyCode)
            {
                case Keys.Right:
                    hero.HorisontalVelocity = hero.Step;
                    hero.VerticalVelocity = 0;
                    break;
                case Keys.Down:
                    hero.HorisontalVelocity = 0;
                    hero.VerticalVelocity = hero.Step;
                    break;
                case Keys.Left:
                    hero.HorisontalVelocity = -hero.Step;
                    hero.VerticalVelocity = 0;
                    break;
                case Keys.Up:
                    hero.HorisontalVelocity = 0;
                    hero.VerticalVelocity = -hero.Step;
                    break;
            }
        }

        private void HeroBorderCollision()
        {
            if (hero.Left > level.Left + level.Width)
            {
                hero.Left = level.Left - hero.Width;
            }
            if (hero.Left < level.Left - hero.Width)
            {
                hero.Left = level.Left + level.Width;
            }
            if (hero.Top > level.Top + level.Height)
            {
                hero.Top = level.Top - hero.Height;
            }
            if (hero.Top < level.Top - hero.Height)
            {
                hero.Top = level.Top + level.Height;
            }
        }

        private void AddEnemy()
        {
            Enemy enemy;

            for (int i = 0; i < initialEnemyCount; i++)
            {
                enemy = new Enemy();
                enemy.Location = new Point(rand.Next(100, 500), rand.Next(100, 500));
                enemy.SetDirection(rand.Next(1, 5));
                enemies.Add(enemy);
                this.Controls.Add(enemy);
                enemy.BringToFront();
            }
        }
    }
}
