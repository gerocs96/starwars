// <copyright file="GameLogic.cs" company="PlaceholderCompany">
// Copyright (c) PlaceholderCompany. All rights reserved.
// </copyright>

namespace GameLogic
{
    using System;
    using System.IO;

    // using System.Media;
    using System.Windows;
    using System.Windows.Media;
    using GameModel;
    using GameRepository;

    /// <summary>
    /// Holds the necessary methods and parameters to manipulate the GameModel.
    /// </summary>
    public class GameLogic : IGameLogic
    {
        // public enum Direction { Left, Right, Up, Down };
        private static Random rnd = new Random();
        private IGameModel model;
        private IGameRepository repo;

        // private SoundPlayer enemyplayer;
        // private SoundPlayer friendlyplayer;

        /// <summary>
        /// Initializes a new instance of the <see cref="GameLogic"/> class.
        /// </summary>
        /// <param name="model">The model of the game.</param>
        /// <param name="repo">The repository of the game.</param>
        /// <param name="load">Dertermines whether the is a new one or not.</param>
        public GameLogic(IGameModel model, IGameRepository repo, bool load)
        {
            this.model = model;
            this.repo = repo;
            if (load == false)
            {
                this.model.SpawnCounter = 0;
                this.model.BasicSpawn = 20;
                this.model.BossSpawn = 80;
                this.model.SpeedIncrease = 2000;
            }

            // this.enemyplayer = new SoundPlayer("enemyshoot.wav");
            // this.friendlyplayer = new SoundPlayer("playershoot.wav");
        }

        /// <summary>
        /// Gets a value indicating whether the game can continue.
        /// </summary>
        public bool GameOver { get; private set; }

        /// <summary>
        /// Adds the name and the score to the repository.
        /// </summary>
        /// <param name="score">The name and score of the player.</param>
        public void AddScore(Score score)
        {
            this.repo.ScoreAdd(score);
        }

        /// <summary>
        /// Gets the actual score of the player.
        /// </summary>
        /// <returns>Returns the actual score of the playr.</returns>
        public int GetActualScore()
        {
            return this.model.Score;
        }

        /// <summary>
        /// Gives the current snapshot of the model to the repository for saving.
        /// </summary>
        public void Save()
        {
            this.repo.SaveGame(this.model);
        }

        /// <summary>
        /// Moves the player to the point's direction based on it's speed value.
        /// </summary>
        /// <param name="p">The point that needs to be reached.</param>
        public void MovePlayer(Point p)
        {
            if (p.X + 20 < this.model.Player.CenterX || p.X - 20 > this.model.Player.CenterX || p.Y + 20 < this.model.Player.CenterY || p.Y - 20 > this.model.Player.CenterY)
            {
                if (this.model.Player.CenterX > (this.model.Player.Width / 2) + 40 && this.model.Player.CenterY > (this.model.Player.Height / 2) + 40 && p.X + 20 < this.model.Player.CenterX && p.Y + 20 < this.model.Player.CenterY)
                {
                    this.model.Player.CenterX -= this.model.Player.Speed;
                    this.model.Player.CenterY -= this.model.Player.Speed;
                }
                else if (this.model.Player.CenterX > (this.model.Player.Width / 2) + 40 && this.model.Player.CenterY < Config.Height - ((this.model.Player.Height / 2) + 40) && p.X + 20 < this.model.Player.CenterX && p.Y - 20 > this.model.Player.CenterY)
                {
                    this.model.Player.CenterX -= this.model.Player.Speed;
                    this.model.Player.CenterY += this.model.Player.Speed;
                }
                else if (this.model.Player.CenterX < Config.Width - ((this.model.Player.Width / 2) + 40) && this.model.Player.CenterY > (this.model.Player.Height / 2) + 40 && p.X - 20 > this.model.Player.CenterX && p.Y + 20 < this.model.Player.CenterY)
                {
                    this.model.Player.CenterX += this.model.Player.Speed;
                    this.model.Player.CenterY -= this.model.Player.Speed;
                }
                else if (this.model.Player.CenterX < Config.Width - ((this.model.Player.Width / 2) + 40) && this.model.Player.CenterY < Config.Height - ((this.model.Player.Height / 2) + 40) && p.X - 20 > this.model.Player.CenterX && p.Y - 20 > this.model.Player.CenterY)
                {
                    this.model.Player.CenterX += this.model.Player.Speed;
                    this.model.Player.CenterY += this.model.Player.Speed;
                }
                else if (this.model.Player.CenterX > (this.model.Player.Width / 2) + 40 && p.X + 20 < this.model.Player.CenterX)
                {
                    this.model.Player.CenterX -= this.model.Player.Speed;
                }
                else if (this.model.Player.CenterX < Config.Width - ((this.model.Player.Width / 2) + 40) && p.X - 20 > this.model.Player.CenterX)
                {
                    this.model.Player.CenterX += this.model.Player.Speed;
                }
                else if (this.model.Player.CenterY > (this.model.Player.Height / 2) + 40 && p.Y + 20 < this.model.Player.CenterY)
                {
                    this.model.Player.CenterY -= this.model.Player.Speed;
                }
                else if (this.model.Player.CenterY < Config.Height - ((this.model.Player.Height / 2) + 40) && p.Y - 20 > this.model.Player.CenterY)
                {
                    this.model.Player.CenterY += this.model.Player.Speed;
                }
            }
        }

        /// <summary>
        /// Adds a friendly bullet to the model.
        /// </summary>
        public void Fire()
        {
            this.model.Bullets.Add(new Bullet(
                this.model.Player.CenterX + (this.model.Player.Width / 2) + (Config.ShipBulletWidth / 2),
                this.model.Player.CenterY,
                Brushes.Red,
                new RectangleGeometry(new Rect(0, 0, Config.ShipBulletWidth, Config.ShipBulletHeight)),
                0,
                Config.ShipBulletDX,
                Config.ShipBulletDY,
                true,
                this.model.Player.Damage,
                Config.ShipBulletWidth,
                Config.ShipBulletHeight));

            // this.friendlyplayer.Play();
        }

        /// <summary>
        /// Fires all enemies in the model all at once, for testing purposes.
        /// </summary>
        public void FireAll()
        {
            foreach (Enemy enemy in this.model.Enemies)
            {
                this.EnemyFire(enemy);
            }
        }

        /// <summary>
        /// Moves the game forward with one iteration.
        /// </summary>
        public void OneTick()
        {
            for (int i = 0; i < this.model.Bullets.Count; i++)
            {
                if (this.MoveBullet(this.model.Bullets[i]) == false)
                {
                    this.model.Bullets.RemoveAt(i);
                }
            }

            for (int i = 0; i < this.model.Enemies.Count; i++)
            {
                if (this.MoveEnemy(this.model.Enemies[i]) == false)
                {
                    this.model.Enemies.RemoveAt(i);
                }
            }

            this.FireEnemies();
        }

        /// <summary>
        /// Moves the spawn sequence forward with one iteration.
        /// </summary>
        public void SpawnerTick()
        {
            int rand;
            if (this.model.SpawnCounter % this.model.BasicSpawn == 0)
            {
                rand = rnd.Next(1, 11);
                if (rand < 7)
                {
                    this.AddBasicEnemy();
                }
                else
                {
                    this.AddTargetingEnemy();
                }
            }

            if (this.model.SpawnCounter % this.model.BossSpawn == 0)
            {
                rand = rnd.Next(1, 11);
                if (rand < 3)
                {
                    this.AddDeathStarEnemy();
                }
                else if (rand < 6)
                {
                    this.AddStarDestroyerEnemy();
                }
                else
                {
                    this.AddSlaveOneEnemy();
                }
            }

            if (this.model.Score > this.model.SpeedIncrease)
            {
                if (this.model.BasicSpawn > 4)
                {
                    this.model.BasicSpawn--;
                }

                if (this.model.BossSpawn > 20)
                {
                    this.model.BossSpawn -= 2;
                }

                this.model.SpeedIncrease *= 1.5;
            }

            this.model.SpawnCounter++;
        }

        private void AddBasicEnemy()
        {
            double width = Math.Round(Config.Width / 16);
            double height = Math.Round((Config.Width / 16) * 0.91);
            int y = rnd.Next((int)height / 2, (int)(Config.Height - (height / 2)));
            this.model.Enemies.Add(new Enemy(
                Config.Width + (width / 2) + 10,
                y,
                new RectangleGeometry(new Rect(0, 0, width, height)),
                Config.TieFighterPath,
                Config.TieFighterDX,
                Config.TieFighterDY,
                Config.TieFighterHealth,
                Config.TieFighterDamage,
                Config.TieFighterWorth,
                Config.TieFighterTarget,
                width,
                height,
                Config.TieFighterCharge));
        }

        private void AddTargetingEnemy()
        {
            double width = Math.Round(Config.Width / 12);
            double height = Math.Round((Config.Width / 12) * 0.79);
            int y = rnd.Next((int)height / 2, (int)(Config.Height - (height / 2)));
            this.model.Enemies.Add(new Enemy(
                Config.Width + (width / 2) + 10,
                y,
                new RectangleGeometry(new Rect(0, 0, width, height)),
                Config.FieTighterPath,
                Config.FieTighterDX,
                Config.FieTighterDY,
                Config.FieTighterHealth,
                Config.FieTighterDamage,
                Config.FieTighterWorth,
                Config.FieTighterTarget,
                width,
                height,
                Config.FieTighterCharge));
        }

        private void AddStarDestroyerEnemy()
        {
            double width = Math.Round(Config.Width / 2);
            double height = Math.Round((Config.Width / 2) * 0.38);
            int y = rnd.Next((int)height / 2, (int)(Config.Height - (height / 2)));
            this.model.Enemies.Add(new BossEnemy(
                Config.Width + (width / 2) + 10,
                y,
                new RectangleGeometry(new Rect(0, 0, width, height)),
                Config.StarDestroyerPath,
                Config.StarDestroyerDX,
                Config.StarDestroyerDY,
                Config.StarDestroyerHealth,
                Config.StarDestroyerDamage,
                Config.StarDestroyerWorth,
                Config.StarDestroyerTarget,
                width,
                height,
                Config.StarDestroyerCharge));
        }

        private void AddDeathStarEnemy()
        {
            double r = Math.Round(Config.Height / 6);
            this.model.Enemies.Add(new BossEnemy(
                Config.Width + r,
                Config.Height / 2,
                new EllipseGeometry(new Point(0, 0), r, r),
                Config.DeathStarPath,
                Config.DeathStarDX,
                Config.DeathStarDY,
                Config.DeathStarHealth,
                Config.DeathStarDamage,
                Config.DeathStarWorth,
                Config.DeathStarTarget,
                r * 2,
                r * 2,
                Config.DeathStarCharge));
        }

        private void AddSlaveOneEnemy()
        {
            double width = Math.Round(Config.Width / 10);
            double height = Math.Round((Config.Width / 10) * 0.85);
            this.model.Enemies.Add(new BossEnemy(
                Config.Width + (width / 2) + 10,
                Config.Height / 2,
                new RectangleGeometry(new Rect(0, 0, width, height)),
                Config.SlaveOnePath,
                Config.SlaveOneDX,
                Config.SlaveOneDY,
                Config.SlaveOneHealth,
                Config.SlaveOneDamage,
                Config.SlaveOneWorth,
                Config.SlaveOneTarget,
                width,
                height,
                Config.SlaveOneCharge));
        }

        private bool MoveEnemy(Enemy enemy)
        {
            if (enemy is BossEnemy)
            {
                this.MoveBoss(enemy);
                return true;
            }

            if (enemy.CenterX < 0)
            {
                return false;
            }

            if (enemy.IsCollision(this.model.Player, enemy.Width / 2, enemy.Height / 2, this.model.Player.Width / 2, this.model.Player.Height / 2) == true)
            {
                this.model.Player.Health -= enemy.Health;
                this.model.Score += enemy.Worth;
                this.HealthCheck();
                return false;
            }

            enemy.CenterX += enemy.DX;
            enemy.CenterY += enemy.DY;
            return true;
        }

        private void MoveBoss(Enemy enemy)
        {
            if (enemy.IsCollision(this.model.Player, enemy.Width / 2, enemy.Height / 2, this.model.Player.Width / 2, this.model.Player.Height / 2) == true)
            {
                this.model.Player.Health = 0;
                this.HealthCheck();
            }

            if (enemy.TexturePath == Config.StarDestroyerPath)
            {
                if (enemy.CenterX < Config.Width / 2 || enemy.CenterX > Config.Width + (enemy.Width / 2) + 10)
                {
                    enemy.DX *= -1;
                    enemy.CenterX += enemy.DX * 2;
                }
                else
                {
                    enemy.CenterX += enemy.DX;
                }
            }
            else if (enemy.TexturePath == Config.DeathStarPath)
            {
                if (enemy.CenterX > Config.Width - (enemy.Width / 2))
                {
                    enemy.CenterX += enemy.DX;
                }
            }
            else if (enemy.TexturePath == Config.SlaveOnePath)
            {
                if (enemy.CenterY > enemy.Height / 2 && enemy.CenterY < Config.Height - (enemy.Height / 2) && enemy.CenterX < Config.Width - (enemy.Width / 2) - 60)
                {
                    enemy.CenterY += enemy.DY;
                }
                else if (enemy.CenterX > Config.Width - (enemy.Width / 2) - 60)
                {
                    enemy.CenterX += enemy.DX;
                }
                else
                {
                    if (enemy.DX > (Config.SlaveOneDX * 5) && enemy.DX < 0)
                    {
                        enemy.DX *= 5;
                        enemy.Targeting = !enemy.Targeting;
                    }

                    enemy.CenterX += enemy.DX;
                }

                if (enemy.CenterX < (enemy.Width / 2) + 20)
                {
                    enemy.CenterX -= enemy.DX * 2;
                    enemy.DX = Config.SlaveOneDX * -1;
                    enemy.DY *= -1;
                }

                if (enemy.CenterX > Config.Width - (enemy.Width / 2) - 60 && enemy.DX > 0)
                {
                    enemy.CenterY += enemy.DY * 2;
                    enemy.DX *= -1;
                    enemy.Targeting = !enemy.Targeting;
                }
            }
        }

        private void EnemyFire(Enemy enemy)
        {
            if (enemy.Targeting == false)
            {
                this.model.Bullets.Add(new Bullet(
                    enemy.CenterX - (enemy.Width / 2) - (Config.EnemyBulletWidth / 2),
                    enemy.CenterY,
                    Brushes.Green,
                    new RectangleGeometry(new Rect(0, 0, Config.EnemyBulletWidth, Config.EnemyBulletHeight)),
                    0,
                    Config.EnemyBulletDX,
                    Config.EnemyBulletDY,
                    false,
                    enemy.Damage,
                    Config.EnemyBulletWidth,
                    Config.EnemyBulletHeight));
            }
            else
            {
                double xdiff = (enemy.CenterX - (enemy.Width / 2) - (Config.EnemyBulletWidth / 2)) - this.model.Player.CenterX;
                double ydiff = enemy.CenterY - this.model.Player.CenterY;
                double rotdegree = (Math.Atan2(ydiff, xdiff) * 180) / Math.PI;

                double reqx = Math.Abs(((Math.Abs(xdiff) + Math.Abs(ydiff)) / 1.4) / Config.EnemyBulletDX);
                double tempdx = -1 * (xdiff / reqx);
                double tempdy = -1 * (ydiff / reqx);

                this.model.Bullets.Add(new Bullet(
                    enemy.CenterX - (enemy.Width / 2) - (Config.EnemyBulletWidth / 2),
                    enemy.CenterY,
                    Brushes.Green,
                    new RectangleGeometry(new Rect(0, 0, Config.EnemyBulletWidth, Config.EnemyBulletHeight)),
                    rotdegree,
                    (int)Math.Ceiling(tempdx),
                    (int)Math.Ceiling(tempdy),
                    false,
                    enemy.Damage,
                    Config.EnemyBulletWidth,
                    Config.EnemyBulletHeight));
            }
        }

        private void FireEnemies()
        {
            foreach (Enemy current in this.model.Enemies)
            {
                current.CurrentChagre += rnd.Next(1, 8);
                if (current.CurrentChagre >= current.RequiredCharge)
                {
                    this.EnemyFire(current);

                    // this.enemyplayer.Play();
                    current.CurrentChagre = 0;
                }
            }
        }

        private bool MoveBullet(Bullet bullet)
        {
            if (bullet.CenterX > Config.Width || bullet.CenterX < 0 ||
                bullet.CenterY > Config.Height || bullet.CenterY < 0)
            {
                return false;
            }

            if (bullet.Friendly == false && bullet.IsCollision(this.model.Player, bullet.Width / 2, bullet.Height / 2, this.model.Player.Width / 2, this.model.Player.Height / 2) == true)
            {
                this.model.Player.Health -= bullet.Damage;
                this.HealthCheck();
                return false;
            }
            else if (bullet.Friendly == true)
            {
                int i = 0;
                while (i < this.model.Enemies.Count && bullet.IsCollision(this.model.Enemies[i], bullet.Width / 2, bullet.Height / 2, this.model.Enemies[i].Width / 2, this.model.Enemies[i].Height / 2) == false)
                {
                    i++;
                }

                if (i < this.model.Enemies.Count)
                {
                    this.model.Enemies[i].Health -= this.model.Player.Damage;
                    if (this.model.Enemies[i].Health <= 0)
                    {
                        this.model.Score += this.model.Enemies[i].Worth;
                        this.model.Enemies.RemoveAt(i);
                    }

                    return false;
                }
            }

            bullet.CenterX += bullet.DX;
            bullet.CenterY += bullet.DY;
            return true;
        }

        private void HealthCheck()
        {
            if (this.model.Player.Health <= 0)
            {
                this.model.Player.Armor -= 1;
                this.model.Player.CenterX = (this.model.Player.Width / 2) + 10;
                this.model.Player.CenterY = Config.Height / 2;
                if (this.model.Player.Armor < 0)
                {
                    this.GameOver = true;
                }

                this.model.Player.Health = this.model.Player.MaxHealth;
            }
        }
    }
}
