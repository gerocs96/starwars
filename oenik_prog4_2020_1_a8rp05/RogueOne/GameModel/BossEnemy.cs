// <copyright file="BossEnemy.cs" company="PlaceholderCompany">
// Copyright (c) PlaceholderCompany. All rights reserved.
// </copyright>

namespace GameModel
{
    using System.Windows.Media;

    /// <summary>
    /// Defines a boss enemy, a unique version of the Enemy class.
    /// </summary>
    public class BossEnemy : Enemy
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="BossEnemy"/> class with textures.
        /// </summary>
        /// <param name="centerx">The center point of the BossEnemy on the X-axis.</param>
        /// <param name="centery">The center point of the BossEnemy on the Y-axis.</param>
        /// <param name="area">The Geometry of the BossEnemy.</param>
        /// <param name="textpath">The path to the texture of the BossEnemy.</param>
        /// <param name="dx">The speed of the BossEnemy on the X-axis in pixels.</param>
        /// <param name="dy">The speed of the BossEnemy on the Y-axis in pixels.</param>
        /// <param name="health">The current health of the BossEnemy.</param>
        /// <param name="damage">The damage the BossEnemy deals with one bullet.</param>
        /// <param name="worth">How much score the BossEnemy worths.</param>
        /// <param name="target">Determines wheter the BossEnemy uses targeting fire.</param>
        /// <param name="width">The width of the BossEnemy in pixels.</param>
        /// <param name="height">The height of the BossEnemy in pixels.</param>
        /// <param name="maxcharge">The amount of charge required for the BossEnemy to fire.</param>
        public BossEnemy(double centerx, double centery, Geometry area, string textpath, int dx, int dy, int health, int damage, int worth, bool target, double width, double height, int maxcharge)
            : base(centerx, centery, area, textpath, dx, dy, health, damage, worth, target, width, height, maxcharge)
        {
        }

        /// <summary>
        /// Initializes a new instance of the <see cref="BossEnemy"/> class without textures.
        /// </summary>
        /// <param name="centerx">The center point of the BossEnemy on the X-axis.</param>
        /// <param name="centery">The center point of the BossEnemy on the Y-axis.</param>
        /// <param name="area">The Geometry of the BossEnemy.</param>
        /// <param name="dx">The speed of the BossEnemy on the X-axis in pixels.</param>
        /// <param name="dy">The speed of the BossEnemy on the Y-axis in pixels.</param>
        /// <param name="health">The current health of the BossEnemy.</param>
        /// <param name="damage">The damage the BossEnemy deals with one bullet.</param>
        /// <param name="worth">How much score the BossEnemy worths.</param>
        /// <param name="target">Determines wheter the BossEnemy uses targeting fire.</param>
        /// <param name="width">The width of the BossEnemy in pixels.</param>
        /// <param name="height">The height of the BossEnemy in pixels.</param>
        /// <param name="maxcharge">The amount of charge required for the BossEnemy to fire.</param>
        public BossEnemy(double centerx, double centery, Geometry area, int dx, int dy, int health, int damage, int worth, bool target, double width, double height, int maxcharge)
            : base(centerx, centery, area, dx, dy, health, damage, worth, target, width, height, maxcharge)
        {
        }
    }
}
