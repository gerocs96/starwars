// <copyright file="GameControlViewModel.cs" company="PlaceholderCompany">
// Copyright (c) PlaceholderCompany. All rights reserved.
// </copyright>

namespace RogueOne.ViewModels
{
    using GalaSoft.MvvmLight;
    using GameModel;
    using GameRepository;

    /// <summary>
    /// The viewmodel for the GameControl window.
    /// </summary>
    public class GameControlViewModel : ViewModelBase
    {
        private string ship;
        private string map;

        /// <summary>
        /// Gets or sets the type of the chosen ship.
        /// </summary>
        public string Ship
        {
            get { return this.ship; }
            set { this.Set(ref this.ship, value); }
        }

        /// <summary>
        /// Gets or sets the chosen map.
        /// </summary>
        public string Map
        {
            get { return this.map; }
            set { this.Set(ref this.map, value); }
        }

        /// <summary>
        /// Gets or sets the repository.
        /// </summary>
        public IGameRepository Repo { get; set; }

        /// <summary>
        /// Gets or sets the model.
        /// </summary>
        public IGameModel Model { get; set; }

        /// <summary>
        /// Gets or sets a value indicating whether the game is a new one.
        /// </summary>
        public bool Load { get; set; }
    }
}
