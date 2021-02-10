// <copyright file="PauseViewModel.cs" company="PlaceholderCompany">
// Copyright (c) PlaceholderCompany. All rights reserved.
// </copyright>

namespace RogueOne.ViewModels
{
    using GalaSoft.MvvmLight;
    using GameModel;
    using GameRepository;

    /// <summary>
    /// The viewmodel for the pause window.
    /// </summary>
    public class PauseViewModel : ViewModelBase
    {
        /// <summary>
        /// Gets or sets the model.
        /// </summary>
        public IGameModel Model { get; set; }

        /// <summary>
        /// Gets or sets the repository.
        /// </summary>
        public IGameRepository Repo { get; set; }
    }
}
