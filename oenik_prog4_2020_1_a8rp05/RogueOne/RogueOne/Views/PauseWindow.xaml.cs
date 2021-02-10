// <copyright file="PauseWindow.xaml.cs" company="PlaceholderCompany">
// Copyright (c) PlaceholderCompany. All rights reserved.
// </copyright>

namespace RogueOne.Views
{
    using System.Windows;
    using GameModel;
    using GameRepository;
    using RogueOne.ViewModels;

    /// <summary>
    /// Interaction logic for PauseWindow.xaml.
    /// </summary>
    public partial class PauseWindow : Window
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="PauseWindow"/> class.
        /// </summary>
        /// <param name="model">The model of the game.</param>
        /// <param name="repo">The repository of the game.</param>
        public PauseWindow(IGameModel model, IGameRepository repo)
        {
            this.InitializeComponent();
            this.InitializeComponent();
            (this.FindResource("PVM") as PauseViewModel).Model = model;
            (this.FindResource("PVM") as PauseViewModel).Repo = repo;
        }

        private void ContinueButton(object sender, RoutedEventArgs e)
        {
            this.DialogResult = false;
        }

        private void SaveButton(object sender, RoutedEventArgs e)
        {
            (this.FindResource("PVM") as PauseViewModel).Repo.
                SaveGame((this.FindResource("PVM") as PauseViewModel).Model);
            MessageBox.Show("Game saved");
            this.DialogResult = false;
        }

        private void ExitButton(object sender, RoutedEventArgs e)
        {
            this.DialogResult = true;
        }
    }
}
