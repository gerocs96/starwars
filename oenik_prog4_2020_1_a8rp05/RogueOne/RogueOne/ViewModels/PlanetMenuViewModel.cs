// <copyright file="PlanetMenuViewModel.cs" company="PlaceholderCompany">
// Copyright (c) PlaceholderCompany. All rights reserved.
// </copyright>

namespace RogueOne.ViewModels
{
    using GalaSoft.MvvmLight;
    using GameRepository;

    /// <summary>
    /// The window on which the player choses the map.
    /// </summary>
    public class PlanetMenuViewModel : ViewModelBase
    {
        /// <summary>
        /// Gets or sets the ship's name.
        /// </summary>
        public string Ship { get; set; }

        /// <summary>
        /// Gets or sets the repository.
        /// </summary>
        public IGameRepository Repo { get; set; }
    }
}
