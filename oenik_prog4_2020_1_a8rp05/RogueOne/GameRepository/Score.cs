// <copyright file="Score.cs" company="PlaceholderCompany">
// Copyright (c) PlaceholderCompany. All rights reserved.
// </copyright>

namespace GameRepository
{
    using System;

    /// <summary>
    /// The parameters of the player's score.
    /// </summary>
    public class Score : IComparable<Score>
    {
        /// <summary>
        /// Gets or sets the name of the player.
        /// </summary>
        public string Name { get; set; }

        /// <summary>
        /// Gets or sets the score amount.
        /// </summary>
        public int HighScore { get; set; }

        /// <summary>
        /// Compares two different Score objects.
        /// </summary>
        /// <param name="other">The Score which we compare to.</param>
        /// <returns>Returns -1, 0, 1 if the other Score is greater, equals or less respectively.</returns>
        public int CompareTo(Score other)
        {
            if (this.HighScore > other.HighScore)
            {
                return 1;
            }
            else if (this.HighScore < other.HighScore)
            {
                return -1;
            }
            else
            {
                return 0;
            }
        }
    }
}
