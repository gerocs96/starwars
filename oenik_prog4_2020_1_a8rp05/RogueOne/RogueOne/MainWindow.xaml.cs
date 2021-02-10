// <copyright file="MainWindow.xaml.cs" company="PlaceholderCompany">
// Copyright (c) PlaceholderCompany. All rights reserved.
// </copyright>

namespace RogueOne
{
    using System.Windows;
    using GameModel;
    using GameRepository;
    using RogueOne.ViewModels;

    /// <summary>
    /// Interaction logic for MainWindow.xaml.
    /// </summary>
    public partial class MainWindow : Window
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="MainWindow"/> class as a new game.
        /// </summary>
        /// <param name="ship">The chosen ship's name.</param>
        /// <param name="map">The chosen map's name.</param>
        /// <param name="repo">The repository of the game.</param>
        public MainWindow(string ship, string map, IGameRepository repo)
        {
            this.InitializeComponent();
            (this.FindResource("GCVM")
                as GameControlViewModel).Map = map;
            (this.FindResource("GCVM")
                as GameControlViewModel).Ship = ship;
            (this.FindResource("GCVM")
                as GameControlViewModel).Repo = repo;
            (this.FindResource("GCVM")
                as GameControlViewModel).Load = false;
        }

        /// <summary>
        /// Initializes a new instance of the <see cref="MainWindow"/> class as a loaded game.
        /// </summary>
        /// <param name="model">The model of the loaded game.</param>
        /// <param name="repo">The repository of the game.</param>
        /// <param name="load">Indicates that the game is a loaded game.</param>
        public MainWindow(IGameModel model, IGameRepository repo, bool load)
        {
            this.InitializeComponent();
            (this.FindResource("GCVM")
                as GameControlViewModel).Model = model;
            (this.FindResource("GCVM")
                as GameControlViewModel).Repo = repo;
            (this.FindResource("GCVM")
                as GameControlViewModel).Load = load;
        }
    }
}
