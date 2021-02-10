// <copyright file="MenuWindow.xaml.cs" company="PlaceholderCompany">
// Copyright (c) PlaceholderCompany. All rights reserved.
// </copyright>

namespace RogueOne
{
    using System.IO;
    using System.Media;
    using System.Windows;
    using GameModel;
    using GameRepository;
    using RogueOne.Views;

    /// <summary>
    /// Interaction logic for MenuWindow.xaml.
    /// </summary>
    public partial class MenuWindow : Window
    {
        private IGameRepository repo;
        private SoundPlayer player;

        /// <summary>
        /// Initializes a new instance of the <see cref="MenuWindow"/> class.
        /// </summary>
        public MenuWindow()
        {
            this.InitializeComponent();
            this.player = new SoundPlayer("menumusic.wav");
            this.repo = new GameRepository();
            this.Top = 50;
            this.Left = 50;
        }

        private void PlayButton(object sender, RoutedEventArgs e)
        {
            this.Button_Play.IsEnabled = false;
            this.Button_HighScores.IsEnabled = false;
            this.Button_Controls.IsEnabled = false;
            this.Button_Exit.IsEnabled = false;
            this.Button_NewGame.IsEnabled = true;
            this.Button_LoadGame.IsEnabled = true;
            this.Button_Back.IsEnabled = true;

            this.Button_Play.Visibility = Visibility.Hidden;
            this.Button_HighScores.Visibility = Visibility.Hidden;
            this.Button_Controls.Visibility = Visibility.Hidden;
            this.Button_Exit.Visibility = Visibility.Hidden;
            this.Button_NewGame.Visibility = Visibility.Visible;
            this.Button_LoadGame.Visibility = Visibility.Visible;
            this.Button_Back.Visibility = Visibility.Visible;
        }

        private void HighscoreButton(object sender, RoutedEventArgs e)
        {
            HighScoreWindow hsw = new HighScoreWindow(this.repo);
            hsw.Top = this.Top;
            hsw.Left = this.Left;
            hsw.Show();
            this.Close();
        }

        private void ControlsButton(object sender, RoutedEventArgs e)
        {
            ControlsWindow cw = new ControlsWindow();
            cw.Top = this.Top;
            cw.Left = this.Left;
            cw.Show();
            this.Close();
        }

        private void ExitButton(object sender, RoutedEventArgs e)
        {
            this.Close();
        }

        private void NewGameButton(object sender, RoutedEventArgs e)
        {
            ShipMenuWindow smw = new ShipMenuWindow(this.repo);
            smw.Top = this.Top;
            smw.Left = this.Left;
            smw.Show();
            this.Close();
        }

        private void LoadGameButton(object sender, RoutedEventArgs e)
        {
            try
            {
                IGameModel model = this.repo.LoadGame();
                MainWindow mw = new MainWindow(model, this.repo, true);
                mw.Top = this.Top;
                mw.Left = this.Left;
                mw.Show();
                this.Close();
            }
            catch (FileNotFoundException)
            {
                MessageBox.Show("Cannot file saved game.");
            }
        }

        private void BackButton(object sender, RoutedEventArgs e)
        {
            this.Button_Play.IsEnabled = true;
            this.Button_HighScores.IsEnabled = true;
            this.Button_Controls.IsEnabled = true;
            this.Button_Exit.IsEnabled = true;
            this.Button_NewGame.IsEnabled = false;
            this.Button_LoadGame.IsEnabled = false;
            this.Button_Back.IsEnabled = true;

            this.Button_Play.Visibility = Visibility.Visible;
            this.Button_HighScores.Visibility = Visibility.Visible;
            this.Button_Controls.Visibility = Visibility.Visible;
            this.Button_Exit.Visibility = Visibility.Visible;
            this.Button_NewGame.Visibility = Visibility.Hidden;
            this.Button_LoadGame.Visibility = Visibility.Hidden;
            this.Button_Back.Visibility = Visibility.Hidden;
        }

        private void SoundButton(object sender, RoutedEventArgs e)
        {
            this.player.PlayLooping();
        }

        private void SoundButtoff(object sender, RoutedEventArgs e)
        {
            this.player.Stop();
        }
    }
}
