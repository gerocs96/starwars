// <copyright file="Enemy.cs" company="PlaceholderCompany">
// Copyright (c) PlaceholderCompany. All rights reserved.
// </copyright>

namespace GameModel
{
    using System.Windows.Media;

    /// <summary>
    /// Defines an enemy.
    /// </summary>
    public class Enemy : GameItem
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="Enemy"/> class with texture.
        /// </summary>
        /// <param name="centerx">The center point of the Enemy on the X-axis.</param>
        /// <param name="centery">The center point of the Enemy on the Y-axis.</param>
        /// <param name="area">The Geometry of the Enemy.</param>
        /// <param name="textpath">The path to the texture of the Enemy.</param>
        /// <param name="dx">The speed of the Enemy on the X-axis in pixels.</param>
        /// <param name="dy">The speed of the Enemy on the Y-axis in pixels.</param>
        /// <param name="health">The current health of the Enemy.</param>
        /// <param name="damage">The damage the Enemy deals with one bullet.</param>
        /// <param name="worth">How much score the Enemy worths.</param>
        /// <param name="target">Determines wheter the Enemy uses targeting fire.</param>
        /// <param name="width">The width of the Enemy in pixels.</param>
        /// <param name="height">The height of the Enemy in pixels.</param>
        /// <param name="maxcharge">The amount of charge required for the Enemy to fire.</param>
        public Enemy(double centerx, double centery, Geometry area, string textpath, int dx, int dy, int health, int damage, int worth, bool target, double width, double height, int maxcharge)
        {
            this.TexturePath = textpath;
            this.CenterX = centerx;
            this.CenterY = centery;
            this.Area = area;
            this.DX = dx;
            this.DY = dy;
            this.Health = health;
            this.Damage = damage;
            this.Worth = worth;
            this.Targeting = target;
            this.Width = width;
            this.Height = height;
            this.TextureLoad(textpath);
            this.RequiredCharge = maxcharge;
            this.CurrentChagre = 0;
        }

        /// <summary>
        /// Initializes a new instance of the <see cref="Enemy"/> class without texture.
        /// </summary>
        /// <param name="centerx">The center point of the Enemy on the X-axis.</param>
        /// <param name="centery">The center point of the Enemy on the Y-axis.</param>
        /// <param name="area">The Geometry of the Enemy.</param>
        /// <param name="dx">The speed of the Enemy on the X-axis in pixels.</param>
        /// <param name="dy">The speed of the Enemy on the Y-axis in pixels.</param>
        /// <param name="health">The current health of the Enemy.</param>
        /// <param name="damage">The damage the Enemy deals with one bullet.</param>
        /// <param name="worth">How much score the Enemy worths.</param>
        /// <param name="target">Determines wheter the Enemy uses targeting fire.</param>
        /// <param name="width">The width of the Enemy in pixels.</param>
        /// <param name="height">The height of the Enemy in pixels.</param>
        /// <param name="maxcharge">The amount of charge required for the Enemy to fire.</param>
        public Enemy(double centerx, double centery, Geometry area, int dx, int dy, int health, int damage, int worth, bool target, double width, double height, int maxcharge)
        {
            this.CenterX = centerx;
            this.CenterY = centery;
            this.Area = area;
            this.DX = dx;
            this.DY = dy;
            this.Health = health;
            this.Damage = damage;
            this.Worth = worth;
            this.Targeting = target;
            this.Width = width;
            this.Height = height;
            this.RequiredCharge = maxcharge;
            this.CurrentChagre = 0;
        }

        /// <summary>
        /// Gets or sets the speed of the Enemy on the X-axis.
        /// </summary>
        public int DX { get; set; }

        /// <summary>
        /// Gets or sets the speed of the Enemy on the Y-Axis.
        /// </summary>
        public int DY { get; set; }

        /// <summary>
        /// Gets or sets the health of the Enemy.
        /// </summary>
        public int Health { get; set; }

        /// <summary>
        /// Gets or sets the damage of the Enemy.
        /// </summary>
        public int Damage { get; set; }

        /// <summary>
        /// Gets or sets the amount of given when the Enemy dies.
        /// </summary>
        public int Worth { get; set; }

        /// <summary>
        /// Gets or sets a value indicating whether the Enemy's fire is targeting.
        /// </summary>
        public bool Targeting { get; set; }

        /// <summary>
        /// Gets or sets the width of the Enemy.
        /// </summary>
        public double Width { get; set; }

        /// <summary>
        /// Gets or sets the height of the Enemy.
        /// </summary>
        public double Height { get; set; }

        /// <summary>
        /// Gets or sets the current charge of the Enemy.
        /// </summary>
        public int CurrentChagre { get; set; }

        /// <summary>
        /// Gets or sets the required amount of charge needed for the Enemy to fire.
        /// </summary>
        public int RequiredCharge { get; set; }
    }
}
