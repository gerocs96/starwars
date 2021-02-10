// <copyright file="IGameLogic.cs" company="PlaceholderCompany">
// Copyright (c) PlaceholderCompany. All rights reserved.
// </copyright>

namespace GameLogic
{
    using System.Windows;
    using GameRepository;

    /// <summary>
    /// The necessary elements of a GameLogic class.
    /// </summary>
    public interface IGameLogic
    {
        /// <summary>
        /// Gets a value indicating whether the game can continue.
        /// </summary>
        bool GameOver { get; }

        /// <summary>
        /// Adds a friendly bullet to the model.
        /// </summary>
        void Fire();

        /// <summary>
        /// Moves the game forward with one iteration.
        /// </summary>
        void OneTick();

        /// <summary>
        /// Fires all enemies in the model all at once, for testing purposes.
        /// </summary>
        void FireAll();

        /// <summary>
        /// Adds the name and the score to the repository.
        /// </summary>
        /// <param name="score">The name and score of the player.</param>
        void AddScore(Score score);

        /// <summary>
        /// Gets the actual score of the player.
        /// </summary>
        /// <returns>Returns the actual score of the player.</returns>
        int GetActualScore();

        /// <summary>
        /// Gives the current snapshot of the model to the repository for saving.
        /// </summary>
        void Save();

        /// <summary>
        /// Moves the player to the point's direction based on it's speed value.
        /// </summary>
        /// <param name="p">The point that needs to be reached.</param>
        void MovePlayer(Point p);

        /// <summary>
        /// Moves the spawn sequence forward with one iteration.
        /// </summary>
        void SpawnerTick();
    }
}
