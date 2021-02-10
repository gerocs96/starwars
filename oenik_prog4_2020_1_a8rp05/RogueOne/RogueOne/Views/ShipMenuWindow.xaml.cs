// <copyright file="ShipMenuWindow.xaml.cs" company="PlaceholderCompany">
// Copyright (c) PlaceholderCompany. All rights reserved.
// </copyright>

namespace RogueOne.Views
{
    using System.Windows;
    using GameRepository;
    using RogueOne.ViewModels;

    /// <summary>
    /// Interaction logic for ShipMenuWindow.xaml.
    /// </summary>
    public partial class ShipMenuWindow : Window
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="ShipMenuWindow"/> class.
        /// </summary>
        /// <param name="repo">The repository of the game.</param>
        public ShipMenuWindow(IGameRepository repo)
        {
            this.InitializeComponent();
            (this.FindResource("SMVM")
                as ShipMenuViewModel).Repo = repo;
        }

        private void BackButton(object sender, RoutedEventArgs e)
        {
            MenuWindow mw = new MenuWindow();
            mw.Top = this.Top;
            mw.Left = this.Left;
            mw.Show();
            this.Close();
        }

        private void GoToPlanet(string ship)
        {
            PlanetMenuWindow pmw = new PlanetMenuWindow(ship, (this.FindResource("SMVM") as ShipMenuViewModel).Repo);
            pmw.Top = this.Top;
            pmw.Left = this.Left;
            pmw.Show();
            this.Close();
        }

        private void NabooClick(object sender, System.Windows.Input.MouseButtonEventArgs e)
        {
            this.GoToPlanet("NabooFighter");
        }

        private void XWingClick(object sender, System.Windows.Input.MouseButtonEventArgs e)
        {
            this.GoToPlanet("XWing");
        }

        private void T47Click(object sender, System.Windows.Input.MouseButtonEventArgs e)
        {
            this.GoToPlanet("T47");
        }

        private void FalconClick(object sender, System.Windows.Input.MouseButtonEventArgs e)
        {
            this.GoToPlanet("MilleniumFalcon");
        }

        private void JediClick(object sender, System.Windows.Input.MouseButtonEventArgs e)
        {
            this.GoToPlanet("JediFighter");
        }
    }
}
