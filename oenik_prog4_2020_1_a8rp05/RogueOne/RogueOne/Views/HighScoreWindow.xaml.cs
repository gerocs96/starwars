// <copyright file="HighScoreWindow.xaml.cs" company="PlaceholderCompany">
// Copyright (c) PlaceholderCompany. All rights reserved.
// </copyright>

namespace RogueOne.Views
{
    using System.Collections.Generic;
    using System.Windows;
    using GameRepository;
    using RogueOne.ViewModels;

    /// <summary>
    /// Interaction logic for HighScoreWindow.xaml.
    /// </summary>
    public partial class HighScoreWindow : Window
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="HighScoreWindow"/> class.
        /// </summary>
        /// <param name="repo">The reposiotry where the highscores are.</param>
        public HighScoreWindow(IGameRepository repo)
        {
            this.InitializeComponent();
            (this.FindResource("HSMVM")
                as HighScoreMenuViewModel).Repo = repo;

            this.Scores = new List<Score>();
            foreach (var item in (this.FindResource("HSMVM")
                as HighScoreMenuViewModel).Repo.HighScores)
            {
                this.Scores.Add(item);
            }

            this.Scores.Sort((x, y) =>
            {
                return y.CompareTo(x);
            });
            this.Lista.ItemsSource = this.Scores;
        }

        /// <summary>
        /// Gets or sets the list of the highscores.
        /// </summary>
        public List<Score> Scores { get; set; }

        private void BackButton(object sender, RoutedEventArgs e)
        {
            MenuWindow mw = new MenuWindow();
            mw.Top = this.Top;
            mw.Left = this.Left;
            mw.Show();
            this.Close();
        }
    }
}
