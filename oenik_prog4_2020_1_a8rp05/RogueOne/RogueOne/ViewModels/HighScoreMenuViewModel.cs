// <copyright file="HighScoreMenuViewModel.cs" company="PlaceholderCompany">
// Copyright (c) PlaceholderCompany. All rights reserved.
// </copyright>

namespace RogueOne.ViewModels
{
    using GalaSoft.MvvmLight;
    using GameRepository;

    /// <summary>
    /// The viewmodel for the highscore menu.
    /// </summary>
    public class HighScoreMenuViewModel : ViewModelBase
    {
        /// <summary>
        /// Gets or sets the repository.
        /// </summary>
        public IGameRepository Repo { get; set; }
    }
}
