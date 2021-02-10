// <copyright file="IGameRepository.cs" company="PlaceholderCompany">
// Copyright (c) PlaceholderCompany. All rights reserved.
// </copyright>

namespace GameRepository
{
    using System.Collections.Generic;
    using GameModel;

    /// <summary>
    /// The necessary methods of the GameRepositroy.
    /// </summary>
    public interface IGameRepository
    {
        /// <summary>
        /// Gets or sets the list of the highscores.
        /// </summary>
        List<Score> HighScores { get; set; }

        /// <summary>
        /// Adds a highscore to the highscore list.
        /// </summary>
        /// <param name="score">The name and score of the player.</param>
        void ScoreAdd(Score score);

        /// <summary>
        /// Save the model of the game.
        /// </summary>
        /// <param name="model">The model which needs to be saved.</param>
        void SaveGame(IGameModel model);

        /// <summary>
        /// Loads a model.
        /// </summary>
        /// <returns>The game model.</returns>
        IGameModel LoadGame();
    }
}
