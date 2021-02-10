// <copyright file="Bullet.cs" company="PlaceholderCompany">
// Copyright (c) PlaceholderCompany. All rights reserved.
// </copyright>

namespace GameModel
{
    using System.Windows.Media;

    /// <summary>
    /// Defines a bullet.
    /// </summary>
    public class Bullet : GameItem
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="Bullet"/> class with color.
        /// </summary>
        /// <param name="centerx">The center point of the Bullet on the X-axis.</param>
        /// <param name="centery">The center point of the Bullet on the Y-axis.</param>
        /// <param name="color">The color of the Bullet.</param>
        /// <param name="area">The Geometry of the Bullet.</param>
        /// <param name="rotdegree">The degree in in which the bullet is rotated.</param>
        /// <param name="dx">The bullet speed on the X-axis.</param>
        /// <param name="dy">The bullet speed on the Y-axis.</param>
        /// <param name="friendly">Indicating whether the bullet was shot by the enemy or the player.</param>
        /// <param name="damage">The damage of the bullet.</param>
        /// <param name="width">The width of the bullet.</param>
        /// <param name="height">The height of the bullet.</param>
        public Bullet(double centerx, double centery, Brush color, Geometry area, double rotdegree, int dx, int dy, bool friendly, int damage, double width, double height)
        {
            this.CenterX = centerx;
            this.CenterY = centery;
            this.Color = color;
            this.Area = area;
            this.RotDegree = rotdegree;
            this.DX = dx;
            this.DY = dy;
            this.Friendly = friendly;
            this.Damage = damage;
            this.Width = width;
            this.Height = height;
        }

        /// <summary>
        /// Initializes a new instance of the <see cref="Bullet"/> class without color.
        /// </summary>
        /// <param name="centerx">The center point of the Bullet on the X-axis.</param>
        /// <param name="centery">The center point of the Bullet on the Y-axis.</param>
        /// <param name="area">The Geometry of the Bullet.</param>
        /// <param name="rotdegree">The degree in in which the bullet is rotated.</param>
        /// <param name="dx">The bullet speed on the X-axis.</param>
        /// <param name="dy">The bullet speed on the Y-axis.</param>
        /// <param name="friendly">Indicating whether the bullet was shot by the enemy or the player.</param>
        /// <param name="damage">The damage of the bullet.</param>
        /// <param name="width">The width of the bullet.</param>
        /// <param name="height">The height of the bullet.</param>
        public Bullet(double centerx, double centery, Geometry area, double rotdegree, int dx, int dy, bool friendly, int damage, double width, double height)
        {
            this.CenterX = centerx;
            this.CenterY = centery;
            this.Area = area;
            this.RotDegree = rotdegree;
            this.DX = dx;
            this.DY = dy;
            this.Friendly = friendly;
            this.Damage = damage;
            this.Width = width;
            this.Height = height;
        }

        /// <summary>
        /// Gets or sets the bullet speed on the X-axis.
        /// </summary>
        public int DX { get; set; }

        /// <summary>
        /// Gets or sets the bullet speed on the Y-axis.
        /// </summary>
        public int DY { get; set; }

        /// <summary>
        /// Gets or sets a value indicating whether the bullet was shot by the enemy or the player.
        /// </summary>
        public bool Friendly { get; set; }

        /// <summary>
        /// Gets or sets the damage of the bullet.
        /// </summary>
        public int Damage { get; set; }

        /// <summary>
        /// Gets or sets the width of the bullet.
        /// </summary>
        public double Width { get; set; }

        /// <summary>
        /// Gets or sets the height of the bullet.
        /// </summary>
        public double Height { get; set; }
    }
}
