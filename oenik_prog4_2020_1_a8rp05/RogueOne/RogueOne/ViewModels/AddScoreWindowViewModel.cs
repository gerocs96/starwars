// <copyright file="AddScoreWindowViewModel.cs" company="PlaceholderCompany">
// Copyright (c) PlaceholderCompany. All rights reserved.
// </copyright>

namespace RogueOne.ViewModels
{
    using GalaSoft.MvvmLight;
    using GameRepository;

    /// <summary>
    /// The window on which the player can type in his name for the highscore.
    /// </summary>
    public class AddScoreWindowViewModel : ViewModelBase
    {
        private Score score;

        /// <summary>
        /// Gets or sets the Score's properties.
        /// </summary>
        public Score Score
        {
            get { return this.score; }
            set { this.Set(ref this.score, value); }
        }
    }
}