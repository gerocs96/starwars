// <copyright file="GameRepository.cs" company="PlaceholderCompany">
// Copyright (c) PlaceholderCompany. All rights reserved.
// </copyright>

namespace GameRepository
{
    using System.Collections.Generic;
    using System.Globalization;
    using System.IO;
    using System.Linq;
    using System.Windows;
    using System.Windows.Media;
    using System.Xml.Linq;
    using GameModel;

    /// <summary>
    /// Contains the necessary elemnts to manage the highsocre and the save/load of the game.
    /// </summary>
    public class GameRepository : IGameRepository
    {
        private BrushConverter conv;

        /// <summary>
        /// Initializes a new instance of the <see cref="GameRepository"/> class.
        /// </summary>
        public GameRepository()
        {
            this.LoadHighScore();
            this.conv = new BrushConverter();
        }

        /// <summary>
        /// Gets or sets the list of the highscore.
        /// </summary>
        public List<Score> HighScores { get; set; }

        /// <summary>
        /// Checks whether the score should be added to the highscore list and inserts it if it should.
        /// </summary>
        /// <param name="score">The name and score of the player.</param>
        public void ScoreAdd(Score score)
        {
            if (this.HighScores.Count < 10)
            {
                this.HighScores.Add(score);
                this.HighScores.Sort((x, y) =>
                {
                    return x.CompareTo(y);
                });
            }
            else
            {
                if (score.HighScore > this.HighScores[0].HighScore)
                {
                    this.HighScores[0] = score;
                    this.HighScores.Sort((x, y) =>
                    {
                        return x.CompareTo(y);
                    });
                }
            }

            this.SaveHighScore();
        }

        /// <summary>
        /// Saves the current snapshot of the game to the savedgame.xml file.
        /// </summary>
        /// <param name="model">The model that needs to be saved.</param>
        public void SaveGame(IGameModel model)
        {
            XDocument x = new XDocument();
            string fullpath = Path.GetFullPath(@"savedgame.xml");
            var root = new XElement("model");
            x.Add(root);
            var enemies = new XElement("enemies");
            x.Root.Add(enemies);
            for (int i = 0; i < model.Enemies.Count; i++)
            {
                XElement sub;
                if (model.Enemies[i] is BossEnemy)
                {
                    sub = new XElement("bossenemy");
                }
                else
                {
                    sub = new XElement("enemy");
                }

                sub.Add(new XAttribute("centerx", model.Enemies[i].CenterX));
                sub.Add(new XAttribute("centery", model.Enemies[i].CenterY));
                sub.Add(new XAttribute("rotdegree", model.Enemies[i].RotDegree));
                if (model.Enemies[i].Area is RectangleGeometry)
                {
                    sub.Add(new XAttribute("areatype", "rectangle"));
                }
                else
                {
                    sub.Add(new XAttribute("areatype", "ellipse"));
                }

                sub.Add(new XAttribute("textpath", model.Enemies[i].TexturePath));
                sub.Add(new XAttribute("dx", model.Enemies[i].DX));
                sub.Add(new XAttribute("dy", model.Enemies[i].DY));
                sub.Add(new XAttribute("health", model.Enemies[i].Health));
                sub.Add(new XAttribute("damage", model.Enemies[i].Damage));
                sub.Add(new XAttribute("worth", model.Enemies[i].Worth));
                sub.Add(new XAttribute("targeting", model.Enemies[i].Targeting));
                sub.Add(new XAttribute("width", model.Enemies[i].Width));
                sub.Add(new XAttribute("height", model.Enemies[i].Height));
                sub.Add(new XAttribute("currentcharge", model.Enemies[i].CurrentChagre));
                sub.Add(new XAttribute("requiredcharge", model.Enemies[i].RequiredCharge));
                enemies.Add(sub);
            }

            var bullets = new XElement("bullets");
            x.Root.Add(bullets);
            for (int i = 0; i < model.Bullets.Count; i++)
            {
                XElement sub = new XElement("bullet");
                sub.Add(new XAttribute("centerx", model.Bullets[i].CenterX));
                sub.Add(new XAttribute("centery", model.Bullets[i].CenterY));
                sub.Add(new XAttribute("rotdegree", model.Bullets[i].RotDegree));
                sub.Add(new XAttribute("color", model.Bullets[i].Color));
                if (model.Bullets[i].Area is RectangleGeometry)
                {
                    sub.Add(new XAttribute("areatype", "rectangle"));
                }
                else
                {
                    sub.Add(new XAttribute("areatype", "ellipse"));
                }

                sub.Add(new XAttribute("dx", model.Bullets[i].DX));
                sub.Add(new XAttribute("dy", model.Bullets[i].DY));
                sub.Add(new XAttribute("friendly", model.Bullets[i].Friendly));
                sub.Add(new XAttribute("damage", model.Bullets[i].Damage));
                sub.Add(new XAttribute("width", model.Bullets[i].Width));
                sub.Add(new XAttribute("height", model.Bullets[i].Height));
                bullets.Add(sub);
            }

            var score = new XElement("score");
            score.Add(new XAttribute("actual", model.Score));
            x.Root.Add(score);

            var map = new XElement("map");
            map.Add(new XAttribute("path", model.Map));
            x.Root.Add(map);

            var spawncounter = new XElement("spawncounter");
            spawncounter.Add(new XAttribute("actual", model.SpawnCounter));
            x.Root.Add(spawncounter);

            var basicspawn = new XElement("basicspawn");
            basicspawn.Add(new XAttribute("actual", model.BasicSpawn));
            x.Root.Add(basicspawn);

            var bossspawn = new XElement("bossspawn");
            bossspawn.Add(new XAttribute("actual", model.BossSpawn));
            x.Root.Add(bossspawn);

            var speedincrease = new XElement("speedincrease");
            speedincrease.Add(new XAttribute("actual", model.SpeedIncrease));
            x.Root.Add(speedincrease);

            var player = new XElement("player");
            player.Add(new XAttribute("centerx", model.Player.CenterX));
            player.Add(new XAttribute("centery", model.Player.CenterY));
            player.Add(new XAttribute("rotdegree", model.Player.RotDegree));
            if (model.Player.Area is RectangleGeometry)
            {
                player.Add(new XAttribute("areatype", "rectangle"));
            }
            else
            {
                player.Add(new XAttribute("areatype", "ellipse"));
            }

            player.Add(new XAttribute("textpath", model.Player.TexturePath));
            player.Add(new XAttribute("health", model.Player.Health));
            player.Add(new XAttribute("maxhealth", model.Player.MaxHealth));
            player.Add(new XAttribute("damage", model.Player.Damage));
            player.Add(new XAttribute("armor", model.Player.Armor));
            player.Add(new XAttribute("speed", model.Player.Speed));
            player.Add(new XAttribute("width", model.Player.Width));
            player.Add(new XAttribute("height", model.Player.Height));
            x.Root.Add(player);

            x.Save(fullpath);
        }

        /// <summary>
        /// Loads the saved snapshot of the model.
        /// </summary>
        /// <returns>Returns the saved model.</returns>
        public IGameModel LoadGame()
        {
            XDocument xdoc;
            try
            {
                string fullpath = Path.GetFullPath(@"savedgame.xml");
                xdoc = XDocument.Load(fullpath);
            }
            catch (FileNotFoundException)
            {
                throw new FileNotFoundException();
            }

            List<Enemy> enemies = new List<Enemy>();
            List<Bullet> bullets = new List<Bullet>();
            Ship player;
            string map;
            int score;
            int spawncounter;
            int basicspawn;
            int bossspawn;
            double speedincrease;
            IGameModel model;

            double width;
            double height;
            Geometry geo;

            foreach (var item in xdoc.Descendants("bossenemy"))
            {
                width = double.Parse(item.Attribute("width").Value, new NumberFormatInfo() { NumberDecimalSeparator = "." });
                height = double.Parse(item.Attribute("height").Value, new NumberFormatInfo() { NumberDecimalSeparator = "." });
                if (item.Attribute("areatype").Value == "rectangle")
                {
                    geo = new RectangleGeometry(new Rect(0, 0, width, height));
                }
                else
                {
                    geo = new EllipseGeometry(new Point(0, 0), width / 2, height / 2);
                }

                enemies.Add(new BossEnemy(
                    double.Parse(item.Attribute("centerx").Value, new NumberFormatInfo() { NumberDecimalSeparator = "." }),
                    double.Parse(item.Attribute("centery").Value, new NumberFormatInfo() { NumberDecimalSeparator = "." }),
                    geo,
                    item.Attribute("textpath").Value,
                    int.Parse(item.Attribute("dx").Value),
                    int.Parse(item.Attribute("dy").Value),
                    int.Parse(item.Attribute("health").Value),
                    int.Parse(item.Attribute("damage").Value),
                    int.Parse(item.Attribute("worth").Value),
                    bool.Parse(item.Attribute("targeting").Value),
                    width,
                    height,
                    int.Parse(item.Attribute("requiredcharge").Value)));
            }

            foreach (var item in xdoc.Descendants("enemy"))
            {
                width = double.Parse(item.Attribute("width").Value, new NumberFormatInfo() { NumberDecimalSeparator = "." });
                height = double.Parse(item.Attribute("height").Value, new NumberFormatInfo() { NumberDecimalSeparator = "." });
                if (item.Attribute("areatype").Value == "rectangle")
                {
                    geo = new RectangleGeometry(new Rect(0, 0, width, height));
                }
                else
                {
                    geo = new EllipseGeometry(new Point(0, 0), width / 2, height / 2);
                }

                enemies.Add(new Enemy(
                    double.Parse(item.Attribute("centerx").Value, new NumberFormatInfo() { NumberDecimalSeparator = "." }),
                    double.Parse(item.Attribute("centery").Value, new NumberFormatInfo() { NumberDecimalSeparator = "." }),
                    geo,
                    item.Attribute("textpath").Value,
                    int.Parse(item.Attribute("dx").Value),
                    int.Parse(item.Attribute("dy").Value),
                    int.Parse(item.Attribute("health").Value),
                    int.Parse(item.Attribute("damage").Value),
                    int.Parse(item.Attribute("worth").Value),
                    bool.Parse(item.Attribute("targeting").Value),
                    width,
                    height,
                    int.Parse(item.Attribute("requiredcharge").Value)));
            }

            foreach (var item in xdoc.Descendants("bullet"))
            {
                width = double.Parse(item.Attribute("width").Value, new NumberFormatInfo() { NumberDecimalSeparator = "." });
                height = double.Parse(item.Attribute("height").Value, new NumberFormatInfo() { NumberDecimalSeparator = "." });
                if (item.Attribute("areatype").Value == "rectangle")
                {
                    geo = new RectangleGeometry(new Rect(0, 0, width, height));
                }
                else
                {
                    geo = new EllipseGeometry(new Point(0, 0), width / 2, height / 2);
                }

                bullets.Add(new Bullet(
                    double.Parse(item.Attribute("centerx").Value, new NumberFormatInfo() { NumberDecimalSeparator = "." }),
                    double.Parse(item.Attribute("centery").Value, new NumberFormatInfo() { NumberDecimalSeparator = "." }),
                    (Brush)this.conv.ConvertFrom(item.Attribute("color").Value),
                    geo,
                    double.Parse(item.Attribute("rotdegree").Value, new NumberFormatInfo() { NumberDecimalSeparator = "." }),
                    int.Parse(item.Attribute("dx").Value),
                    int.Parse(item.Attribute("dy").Value),
                    bool.Parse(item.Attribute("friendly").Value),
                    int.Parse(item.Attribute("damage").Value),
                    width,
                    height));
            }

            score = int.Parse(xdoc.Root.Element("score").Attribute("actual").Value);
            map = xdoc.Root.Element("map").Attribute("path").Value;
            spawncounter = int.Parse(xdoc.Root.Element("spawncounter").Attribute("actual").Value);
            basicspawn = int.Parse(xdoc.Root.Element("basicspawn").Attribute("actual").Value);
            bossspawn = int.Parse(xdoc.Root.Element("bossspawn").Attribute("actual").Value);
            speedincrease = double.Parse(xdoc.Root.Element("speedincrease").Attribute("actual").Value, new NumberFormatInfo() { NumberDecimalSeparator = "." });

            width = double.Parse(xdoc.Root.Element("player").Attribute("width").Value, new NumberFormatInfo() { NumberDecimalSeparator = "." });
            height = double.Parse(xdoc.Root.Element("player").Attribute("height").Value, new NumberFormatInfo() { NumberDecimalSeparator = "." });
            if (xdoc.Root.Element("player").Attribute("areatype").Value == "rectangle")
            {
                geo = new RectangleGeometry(new Rect(0, 0, width, height));
            }
            else
            {
                geo = new EllipseGeometry(new Point(0, 0), width / 2, height / 2);
            }

            player = new Ship(
                double.Parse(xdoc.Root.Element("player").Attribute("centerx").Value, new NumberFormatInfo() { NumberDecimalSeparator = "." }),
                double.Parse(xdoc.Root.Element("player").Attribute("centery").Value, new NumberFormatInfo() { NumberDecimalSeparator = "." }),
                geo,
                xdoc.Root.Element("player").Attribute("textpath").Value,
                int.Parse(xdoc.Root.Element("player").Attribute("health").Value),
                int.Parse(xdoc.Root.Element("player").Attribute("maxhealth").Value),
                int.Parse(xdoc.Root.Element("player").Attribute("damage").Value),
                int.Parse(xdoc.Root.Element("player").Attribute("armor").Value),
                int.Parse(xdoc.Root.Element("player").Attribute("speed").Value),
                width,
                height);

            model = new GameModel(player, map, enemies, bullets, score, spawncounter, basicspawn, bossspawn, speedincrease);
            return model;
        }

        private void LoadHighScore()
        {
            string fullpath = Path.GetFullPath(@"highscore.xml");
            XDocument xdoc = XDocument.Load(fullpath);
            this.HighScores = xdoc.Descendants("highscore").Select(
                node => new Score()
                {
                    Name = node.Element("name")?.Value,
                    HighScore = int.Parse(node.Element("score")?.Value),
                }).ToList();
        }

        private void SaveHighScore()
        {
            XDocument x = new XDocument();
            string fullpath = Path.GetFullPath(@"highscore.xml");
            var root = new XElement("highscores");
            x.Add(root);
            for (int i = 0; i < this.HighScores.Count; i++)
            {
                var sub = new XElement("highscore");
                sub.Add(new XElement("name", this.HighScores[i].Name));
                sub.Add(new XElement("score", this.HighScores[i].HighScore));
                root.Add(sub);
            }

            x.Save(fullpath);
        }
    }
}
