// <copyright file="Ship.cs" company="PlaceholderCompany">
// Copyright (c) PlaceholderCompany. All rights reserved.
// </copyright>

namespace GameModel
{
    using System;
    using System.Windows;
    using System.Windows.Media;

    /// <summary>
    /// The player of the game.
    /// </summary>
    public class Ship : GameItem
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="Ship"/> class with texture.
        /// </summary>
        /// <param name="centerx">The center point of the Ship on the X-axis.</param>
        /// <param name="centery">The center point of the Ship on the Y-axis.</param>
        /// <param name="area">The Geometry of the Ship.</param>
        /// <param name="textpath">The path to the texture of the Ship.</param>
        /// <param name="health">The health of the Ship.</param>
        /// <param name="maxhealth">The max health of the Ship.</param>
        /// <param name="damage">The damage of the Ship.</param>
        /// <param name="armor">The armor of the Ship.</param>
        /// <param name="speed">The speed of the Ship.</param>
        /// <param name="width">The width of the Ship.</param>
        /// <param name="height">The height of the Ship.</param>
        public Ship(double centerx, double centery, Geometry area, string textpath, int health, int maxhealth, int damage, int armor, int speed, double width, double height)
        {
            this.TexturePath = textpath;
            this.CenterX = centerx;
            this.CenterY = centery;
            this.Area = area;
            this.Health = health;
            this.MaxHealth = maxhealth;
            this.Damage = damage;
            this.Armor = armor;
            this.Speed = speed;
            this.Width = width;
            this.Height = height;
            this.TextureLoad(textpath);
        }

        /// <summary>
        /// Initializes a new instance of the <see cref="Ship"/> class without texture.
        /// </summary>
        /// <param name="centerx">The center point of the Ship on the X-axis.</param>
        /// <param name="centery">The center point of the Ship on the Y-axis.</param>
        /// <param name="area">The Geometry of the Ship.</param>
        /// <param name="health">The health of the Ship.</param>
        /// <param name="maxhealth">The current health of the Ship.</param>
        /// <param name="damage">The damage of the Ship.</param>
        /// <param name="armor">The armor of the Ship.</param>
        /// <param name="speed">The speed of the Ship.</param>
        /// <param name="width">The width of the Ship.</param>
        /// <param name="height">The height of the Ship.</param>
        public Ship(double centerx, double centery, Geometry area, int health, int maxhealth, int damage, int armor, int speed, double width, double height)
        {
            this.CenterX = centerx;
            this.CenterY = centery;
            this.Area = area;
            this.Health = health;
            this.MaxHealth = maxhealth;
            this.Damage = damage;
            this.Armor = armor;
            this.Speed = speed;
            this.Width = width;
            this.Height = height;
        }

        /// <summary>
        /// Gets or sets the health of the player.
        /// </summary>
        public int Health { get; set; }

        /// <summary>
        /// Gets or sets the current health of the player.
        /// </summary>
        public int MaxHealth { get; set; }

        /// <summary>
        /// Gets or sets the damage of the player.
        /// </summary>
        public int Damage { get; set; }

        /// <summary>
        /// Gets or sets the armor of the player.
        /// </summary>
        public int Armor { get; set; }

        /// <summary>
        /// Gets or sets the speed of the player.
        /// </summary>
        public int Speed { get; set; }

        /// <summary>
        /// Gets or sets the width of the player.
        /// </summary>
        public double Width { get; set; }

        /// <summary>
        /// Gets or sets the height of the player.
        /// </summary>
        public double Height { get; set; }

        /// <summary>
        /// Initializes a new Ship with the values of an XWing.
        /// </summary>
        /// <returns>A new Ship with XWing values.</returns>
        public static Ship XWing()
        {
            double width = (int)Math.Round(Config.Width / 14);
            double height = (int)Math.Round(Config.Width / 14 * 0.86);
            return new Ship(
                20 + (int)(width / 2),
                (int)(Config.Height / 2),
                new RectangleGeometry(new Rect(0, 0, width, height)),
                Config.XWingTexturePath,
                Config.XWingHealth,
                Config.XWingHealth,
                Config.XWingDamage,
                Config.XWingArmor,
                Config.XWingSpeed,
                width,
                height);
        }

        /// <summary>
        /// Initializes a new Ship with the values of an MilleniumFalcon.
        /// </summary>
        /// <returns>A new Ship with MilleniumFalcon values.</returns>
        public static Ship Falcon()
        {
            double width = (int)Math.Round(Config.Width / 10);
            double height = (int)Math.Round(Config.Width / 10 * 0.73);
            return new Ship(
                20 + (int)(width / 2),
                (int)(Config.Height / 2),
                new RectangleGeometry(new Rect(0, 0, width, height)),
                Config.FalconTexturePath,
                Config.FalconHealth,
                Config.FalconHealth,
                Config.FalconDamage,
                Config.FalconArmor,
                Config.FalconSpeed,
                width,
                height);
        }

        /// <summary>
        /// Initializes a new Ship with the values of an JediFighter.
        /// </summary>
        /// <returns>A new Ship with JediFighter values.</returns>
        public static Ship JediFighter()
        {
            double width = (int)Math.Round(Config.Width / 11);
            double height = (int)Math.Round(Config.Width / 11 * 0.55);
            return new Ship(
                20 + (int)(width / 2),
                (int)(Config.Height / 2),
                new RectangleGeometry(new Rect(0, 0, width, height)),
                Config.JediFighterTexturePath,
                Config.JediFighterHealth,
                Config.JediFighterHealth,
                Config.JediFighterDamage,
                Config.JediFighterArmor,
                Config.JediFighterSpeed,
                width,
                height);
        }

        /// <summary>
        /// Initializes a new Ship with the values of an NabooFighter.
        /// </summary>
        /// <returns>A new Ship with NabooFighter values.</returns>
        public static Ship NabooFighter()
        {
            double width = (int)Math.Round(Config.Width / 12);
            double height = (int)Math.Round(Config.Width / 12 * 0.63);
            return new Ship(
                20 + (int)(width / 2),
                (int)(Config.Height / 2),
                new RectangleGeometry(new Rect(0, 0, width, height)),
                Config.NabooFighterTexturePath,
                Config.NabooFighterHealth,
                Config.NabooFighterHealth,
                Config.NabooFighterDamage,
                Config.NabooFighterArmor,
                Config.NabooFighterSpeed,
                width,
                height);
        }

        /// <summary>
        /// Initializes a new Ship with the values of an T47.
        /// </summary>
        /// <returns>A new Ship with T47 values.</returns>
        public static Ship T47()
        {
            double width = (int)Math.Round(Config.Width / 15);
            double height = (int)Math.Round(Config.Width / 15);
            return new Ship(
                20 + (int)(width / 2),
                (int)(Config.Height / 2),
                new RectangleGeometry(new Rect(0, 0, width, height)),
                Config.T47TexturePath,
                Config.T47Health,
                Config.T47Health,
                Config.T47Damage,
                Config.T47Armor,
                Config.T47Speed,
                width,
                height);
        }
    }
}
