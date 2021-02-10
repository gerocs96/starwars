// <copyright file="AddScoreWindow.xaml.cs" company="PlaceholderCompany">
// Copyright (c) PlaceholderCompany. All rights reserved.
// </copyright>

namespace RogueOne.Views
{
    using System.Windows;
    using GameRepository;
    using RogueOne.ViewModels;

    /// <summary>
    /// Interaction logic for AddScoreWindow.xaml.
    /// </summary>
    public partial class AddScoreWindow : Window
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="AddScoreWindow"/> class.
        /// </summary>
        /// <param name="score">The score of the player.</param>
        public AddScoreWindow(Score score)
        {
            this.InitializeComponent();
            (this.FindResource("ASVM")
                as AddScoreWindowViewModel).Score = score;
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            this.Close();
        }
    }
}