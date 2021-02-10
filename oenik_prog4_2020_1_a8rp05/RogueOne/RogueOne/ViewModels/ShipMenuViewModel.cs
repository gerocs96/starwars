// <copyright file="ShipMenuViewModel.cs" company="PlaceholderCompany">
// Copyright (c) PlaceholderCompany. All rights reserved.
// </copyright>

namespace RogueOne.ViewModels
{
    using GalaSoft.MvvmLight;
    using GameRepository;

    /// <summary>
    /// The view model for the ship selection menu.
    /// </summary>
    public class ShipMenuViewModel : ViewModelBase
    {
        /// <summary>
        /// Gets or sets the repository.
        /// </summary>
        public IGameRepository Repo { get; set; }
    }
}
