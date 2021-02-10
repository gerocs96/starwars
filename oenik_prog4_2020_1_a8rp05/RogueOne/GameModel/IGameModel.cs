// <copyright file="IGameModel.cs" company="PlaceholderCompany">
// Copyright (c) PlaceholderCompany. All rights reserved.
// </copyright>

namespace GameModel
{
    using System.Collections.Generic;

    /// <summary>
    /// The elements required for the GameModel.
    /// </summary>
    public interface IGameModel
    {
        /// <summary>
        /// Gets or sets the list of the currently active enemies of the game.
        /// </summary>
        List<Enemy> Enemies { get; set; }

        /// <summary>
        /// Gets or sets the list of the currently active bullets of the game.
        /// </summary>
        List<Bullet> Bullets { get; set; }

        /// <summary>
        /// Gets or sets the score of the player.
        /// </summary>
        int Score { get; set; }

        /// <summary>
        /// Gets or sets the player of the game.
        /// </summary>
        Ship Player { get; set; }

        /// <summary>
        /// Gets or sets the game map's path.
        /// </summary>
        string Map { get; set; }

        /// <summary>
        /// Gets or sets the spawncounters actual state.
        /// </summary>
        int SpawnCounter { get; set; }

        /// <summary>
        /// Gets or sets the necessary value for a basic spawn.
        /// </summary>
        int BasicSpawn { get; set; }

        /// <summary>
        /// Gets or sets the necessary value for a boss spawn.
        /// </summary>
        int BossSpawn { get; set; }

        /// <summary>
        /// Gets or sets the value of the next speed increase.
        /// </summary>
        double SpeedIncrease { get; set; }
    }
}
