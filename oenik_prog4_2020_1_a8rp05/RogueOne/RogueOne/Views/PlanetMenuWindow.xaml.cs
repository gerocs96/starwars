// <copyright file="PlanetMenuWindow.xaml.cs" company="PlaceholderCompany">
// Copyright (c) PlaceholderCompany. All rights reserved.
// </copyright>

namespace RogueOne.Views
{
    using System.Windows;
    using GameRepository;
    using RogueOne.ViewModels;

    /// <summary>
    /// Interaction logic for PlanetMenuWindow.xaml.
    /// </summary>
    public partial class PlanetMenuWindow : Window
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="PlanetMenuWindow"/> class.
        /// </summary>
        /// <param name="ship">The chosen ship's name.</param>
        /// <param name="repo">The repository of the game.</param>
        public PlanetMenuWindow(string ship, IGameRepository repo)
        {
            this.InitializeComponent();
            (this.FindResource("PMVM")
                as PlanetMenuViewModel).Ship = ship;
            (this.FindResource("PMVM")
                as PlanetMenuViewModel).Repo = repo;
        }

        private void StartGame(string map)
        {
            MainWindow mw = new MainWindow((this.FindResource("PMVM") as PlanetMenuViewModel).Ship, map, (this.FindResource("PMVM") as PlanetMenuViewModel).Repo);
            mw.Top = this.Top;
            mw.Left = this.Left;
            mw.Show();
            this.Close();
        }

        private void BackButton(object sender, RoutedEventArgs e)
        {
            ShipMenuWindow smw = new ShipMenuWindow((this.FindResource("PMVM") as PlanetMenuViewModel).Repo);
            smw.Top = this.Top;
            smw.Left = this.Left;
            smw.Show();
            this.Close();
        }

        private void TatooineClick(object sender, System.Windows.Input.MouseButtonEventArgs e)
        {
            this.StartGame("Tatooine");
        }

        private void HothClick(object sender, System.Windows.Input.MouseButtonEventArgs e)
        {
            this.StartGame("Hoth");
        }

        private void ScarifClick(object sender, System.Windows.Input.MouseButtonEventArgs e)
        {
            this.StartGame("Scarif");
        }

        private void MustafarClick(object sender, System.Windows.Input.MouseButtonEventArgs e)
        {
            this.StartGame("Mustafar");
        }

        private void CoruscantClick(object sender, System.Windows.Input.MouseButtonEventArgs e)
        {
            this.StartGame("Coruscant");
        }

        private void SpaceClick(object sender, System.Windows.Input.MouseButtonEventArgs e)
        {
            this.StartGame("Space");
        }
    }
}
