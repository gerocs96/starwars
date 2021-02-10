// <copyright file="GameControl.cs" company="PlaceholderCompany">
// Copyright (c) PlaceholderCompany. All rights reserved.
// </copyright>

namespace RogueOne
{
    using System;
    using System.Collections.Generic;
    using System.Windows;
    using System.Windows.Input;
    using System.Windows.Media;
    using System.Windows.Threading;
    using GameLogic;
    using GameModel;
    using GameRepository;
    using RogueOne.ViewModels;
    using RogueOne.Views;

    /// <summary>
    /// The necessary elements to control the game' flow.
    /// </summary>
    public class GameControl : FrameworkElement
    {
        /// <summary>
        /// Contains the necessary ship to a ship name.
        /// </summary>
        private static Dictionary<string, Ship> ships = new Dictionary<string, Ship>()
        {
            {
                "XWing", Ship.XWing()
            },
            {
                "NabooFighter", Ship.NabooFighter()
            },
            {
                "T47", Ship.T47()
            },
            {
                "MilleniumFalcon", Ship.Falcon()
            },
            {
                "JediFighter", Ship.JediFighter()
            },
        };

        /// <summary>
        /// Contains the path to the given map.
        /// </summary>
        private static Dictionary<string, string> maps = new Dictionary<string, string>()
        {
            {
                "Tatooine", Config.TatooineBackgroundPath
            },
            {
                "Hoth", Config.HothBackgroundPath
            },
            {
                "Scarif", Config.ScarifBackgroundPath
            },
            {
                "Mustafar", Config.MustafarBackgroundPath
            },
            {
                "Coruscant", Config.CoruscantBackgroundPath
            },
            {
                "Space", Config.SpaceBackgroundPath
            },
        };

        private IGameModel model;
        private IGameLogic logic;
        private IGameRepository repo;
        private GameRenderer.GameRenderer renderer;
        private DispatcherTimer mainTimer;
        private DispatcherTimer spawnTimer;

        /// <summary>
        /// Initializes a new instance of the <see cref="GameControl"/> class.
        /// </summary>
        public GameControl()
        {
            this.Loaded += this.GameControl_Loaded;
        }

        /// <summary>
        /// Determines what to do on render.
        /// </summary>
        /// <param name="drawingContext">The drawingcontext that needs to be rendered.</param>
        protected override void OnRender(DrawingContext drawingContext)
        {
            if (this.renderer != null)
            {
                this.renderer.BuildDisplay(drawingContext);
            }
        }

        private void GameControl_Loaded(object sender, RoutedEventArgs e)
        {
            Window win = Window.GetWindow(this);
            GameControlViewModel vm = new GameControlViewModel() { Ship = "XWing", Map = "Space" };
            if (win.FindResource("GCVM") is GameControlViewModel)
            {
                vm = win.FindResource("GCVM") as GameControlViewModel;
            }
            else
            {
                vm = new GameControlViewModel() { Ship = "XWing", Map = "Space", Repo = new GameRepository(), Load = false };
            }

            if (vm.Model is null)
            {
                this.model = new GameModel(ships[vm.Ship], maps[vm.Map]);
            }
            else
            {
                this.model = new GameModel(vm.Model.Player, vm.Model.Map, vm.Model.Enemies, vm.Model.Bullets, vm.Model.Score, vm.Model.SpawnCounter, vm.Model.BasicSpawn, vm.Model.BossSpawn, vm.Model.SpeedIncrease);
            }

            this.repo = vm.Repo;
            this.logic = new GameLogic(this.model, this.repo, vm.Load);
            this.renderer = new GameRenderer.GameRenderer(this.model);

            if (win != null)
            {
                win.KeyDown += this.Win_KeyDown;
                win.MouseLeave += this.Win_MouseLeave;
                win.MouseEnter += this.Win_MouseEnter;
                this.MouseLeftButtonDown += this.GameControl_MouseLeftButtonDown;
                this.mainTimer = new DispatcherTimer();
                this.spawnTimer = new DispatcherTimer();
                this.mainTimer.Interval = TimeSpan.FromMilliseconds(40);
                this.spawnTimer.Interval = TimeSpan.FromMilliseconds(250);
                this.mainTimer.Tick += this.MainTimer_Tick;
                this.spawnTimer.Tick += this.SpawnTimer_Tick;
                this.mainTimer.Start();
                this.spawnTimer.Start();
            }

            this.InvalidateVisual();
        }

        private void Win_MouseEnter(object sender, MouseEventArgs e)
        {
            this.Resume();
        }

        private void Win_MouseLeave(object sender, MouseEventArgs e)
        {
            this.Pause();
        }

        private void SpawnTimer_Tick(object sender, EventArgs e)
        {
            this.logic.SpawnerTick();
        }

        private void GameControl_MouseLeftButtonDown(object sender, MouseButtonEventArgs e)
        {
            this.logic.Fire();
        }

        private void MainTimer_Tick(object sender, EventArgs e)
        {
            if (this.logic.GameOver == true)
            {
                this.Pause();
                Score score = new Score()
                {
                    HighScore = this.logic.GetActualScore(),
                    Name = "Player",
                };
                AddScoreWindow asw = new AddScoreWindow(score);
                Window win = Window.GetWindow(this);
                asw.Top = win.Top + (win.Height / 2) - (asw.Width / 2);
                asw.Left = win.Left + (win.Width / 2) - (asw.Height / 2);
                asw.ShowDialog();
                this.logic.AddScore(score);
                this.StopGame();
            }
            else
            {
                this.logic.MovePlayer(Mouse.GetPosition(this));
                this.logic.OneTick();
                this.InvalidateVisual();
            }
        }

        private void Win_KeyDown(object sender, KeyEventArgs e)
        {
            switch (e.Key)
            {
                case Key.Space: this.PauseMenu(); break;

                // case Key.D: this.logic.FireAll(); break;
            }

            this.InvalidateVisual();
        }

        private void PauseMenu()
        {
            this.Pause();
            Window win = Window.GetWindow(this);
            PauseWindow pw = new PauseWindow(this.model, this.repo);
            pw.Top = win.Top + (win.Height / 2) - 65;
            pw.Left = win.Left + (win.Width / 2) - 200;
            if ((bool)pw.ShowDialog() == true)
            {
                this.StopGame();
            }
            else
            {
                this.Resume();
            }
        }

        private void Pause()
        {
            this.mainTimer.IsEnabled = false;
            this.spawnTimer.IsEnabled = false;
        }

        private void Resume()
        {
            this.mainTimer.IsEnabled = true;
            this.spawnTimer.IsEnabled = true;
        }

        private void StopGame()
        {
            MenuWindow menu = new MenuWindow();
            Window win = Window.GetWindow(this);
            menu.Top = win.Top;
            menu.Left = win.Left;
            menu.Show();
            win.Close();
        }
    }
}