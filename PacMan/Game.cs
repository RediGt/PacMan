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
        private int initialEnemyCount = 1;

        private Random rand = new Random();
        private readonly Level level = new Level();
        private Hero hero = new Hero();
        private Food food = new Food();
        private Timer mainTimer = null;
        private Timer enemySpawnTimer = null;
        private List<Enemy> enemies = new List<Enemy>();

        public Game()
        {
            InitializeComponent();
            InitializeGame();
            InitializeMainTimer();
            lblGameOver.Visible = false;
            InitializeEnemySpawnTimer();
        }

        private void InitializeGame()
        {
            this.Size = new Size(500, 500);
            this.KeyDown += new KeyEventHandler(Game_KeyDown);
            AddLevel();
            AddHero();
            AddEnemy(initialEnemyCount);
            AddFood();
        }

        private void AddLevel()
        {
            this.Controls.Add(level);
        }

        private void AddHero()
        {           
            this.Controls.Add(hero);
            hero.Parent = level;
            hero.BringToFront();
        }

        private void AddFood()
        {
            this.Controls.Add(food);
            food.Parent = level;
            food.BringToFront();
            food.Location = new Point(rand.Next(100, 400), rand.Next(100, 400));
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
            EnemyBorderCollision();
            HeroEnemyCollision();
            HeroFoodCollision();
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
                    hero.Direction = "right";
                    break;
                case Keys.Down:
                    hero.HorisontalVelocity = 0;
                    hero.VerticalVelocity = hero.Step;
                    hero.Direction = "down";
                    break;
                case Keys.Left:
                    hero.HorisontalVelocity = -hero.Step;
                    hero.VerticalVelocity = 0;
                    hero.Direction = "left";
                    break;
                case Keys.Up:
                    hero.HorisontalVelocity = 0;
                    hero.VerticalVelocity = -hero.Step;
                    hero.Direction = "up";
                    break;
            }
            SetRandomEnemyDirection();
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

        private void AddEnemy(int enemyCount)
        {
            Enemy enemy;

            for (int i = 0; i < enemyCount; i++)
            {
                enemy = new Enemy();
                enemy.Location = new Point(rand.Next(100, 500), rand.Next(100, 500));
                enemy.SetDirection(rand.Next(1, 5));
                enemies.Add(enemy);
                this.Controls.Add(enemy);
                enemy.Parent = level;
                enemy.BringToFront();
            }
        }

        private void EnemyBorderCollision()
        {
            foreach (var enemy in enemies)
            {
                if (enemy.Left > level.Width - enemy.Width)
                {
                    enemy.SetDirection(2);                  
                }
                if (enemy.Left < level.Left)
                {
                    enemy.SetDirection(3);                    
                }
                if (enemy.Top > level.Height - enemy.Height)
                {
                    enemy.SetDirection(4);
                }
                if (enemy.Top < level.Top)
                {
                    enemy.SetDirection(1);
                }
            }
        }

        private void HeroFoodCollision()
        {          
            if (hero.Bounds.IntersectsWith(food.Bounds))
            {
                RespawnFood();
            }
        }

        private void RespawnFood()
        {
            food.Location = new Point(rand.Next(100, 400), rand.Next(100, 400));
        }


        private void SetRandomEnemyDirection()
        {
            foreach (var enemy in enemies)
            {
                enemy.SetDirection(rand.Next(1, 5));
            }
        }

        private void GameOver()
        {
            mainTimer.Stop();
            lblGameOver.Parent = level;
            lblGameOver.BackColor = Color.Transparent;
            lblGameOver.Visible = true;
        }

        private void HeroEnemyCollision()
        {
            foreach (var enemy in enemies)
            {
                if (enemy.Bounds.IntersectsWith(hero.Bounds))
                    GameOver();
            }
        }

        private void InitializeEnemySpawnTimer()
        {
            enemySpawnTimer = new Timer();
            enemySpawnTimer.Tick += new EventHandler(EnemySpawnTimer_Tick);
            enemySpawnTimer.Interval = 3000;
            enemySpawnTimer.Start();
        }

        private void EnemySpawnTimer_Tick(object sender, EventArgs e)
        {
            AddEnemy(1);
        }
    }
}
