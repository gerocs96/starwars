// <copyright file="GameModel.cs" company="PlaceholderCompany">
// Copyright (c) PlaceholderCompany. All rights reserved.
// </copyright>

namespace GameModel
{
    using System.Collections.Generic;

    /// <summary>
    /// The model of the game.
    /// </summary>
    public class GameModel : IGameModel
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="GameModel"/> class for a new game.
        /// </summary>
        /// <param name="player">The player's chosen ship.</param>
        /// <param name="map">The chosen map's path.</param>
        public GameModel(Ship player, string map)
        {
            this.Enemies = new List<Enemy>();
            this.Bullets = new List<Bullet>();
            this.Score = 0;
            this.Player = player;
            this.Map = map;
        }

        /// <summary>
        /// Initializes a new instance of the <see cref="GameModel"/> class for a loaded game.
        /// </summary>
        /// <param name="player">The player's chosen ship.</param>
        /// <param name="map">The chosen map's path.</param>
        /// <param name="enemies">The list of the enemies.</param>
        /// <param name="bullets">The list of the bullets.</param>
        /// <param name="score">The actual score.</param>
        /// <param name="spawncounter">The actual spawncounter.</param>
        /// <param name="basicspawn">The actual basicspawn.</param>
        /// <param name="bossspawn">The actual bossspawn.</param>
        /// <param name="speedincrease">The actual speedincrease.</param>
        public GameModel(Ship player, string map, List<Enemy> enemies, List<Bullet> bullets, int score, int spawncounter, int basicspawn, int bossspawn, double speedincrease)
        {
            this.Enemies = enemies;
            this.Bullets = bullets;
            this.Score = score;
            this.Player = player;
            this.Map = map;
            this.SpawnCounter = spawncounter;
            this.BasicSpawn = basicspawn;
            this.BossSpawn = bossspawn;
            this.SpeedIncrease = speedincrease;
        }

        /// <summary>
        /// Gets or sets the list of the currently active enemies of the game.
        /// </summary>
        public List<Enemy> Enemies { get; set; }

        /// <summary>
        /// Gets or sets the list of the currently active bullets of the game.
        /// </summary>
        public List<Bullet> Bullets { get; set; }

        /// <summary>
        /// Gets or sets the score of the player.
        /// </summary>
        public int Score { get; set; }

        /// <summary>
        /// Gets or sets the player of the game.
        /// </summary>
        public Ship Player { get; set; }

        /// <summary>
        /// Gets or sets the map's path.
        /// </summary>
        public string Map { get; set; }

        /// <summary>
        /// Gets or sets the spawncounters actual state.
        /// </summary>
        public int SpawnCounter { get; set; }

        /// <summary>
        /// Gets or sets the necessary value for a basic spawn.
        /// </summary>
        public int BasicSpawn { get; set; }

        /// <summary>
        /// Gets or sets the necessary value for a boss spawn.
        /// </summary>
        public int BossSpawn { get; set; }

        /// <summary>
        /// Gets or sets the value of the next speed increase.
        /// </summary>
        public double SpeedIncrease { get; set; }
    }
}
