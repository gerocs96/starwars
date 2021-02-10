// <copyright file="ControlsWindow.xaml.cs" company="PlaceholderCompany">
// Copyright (c) PlaceholderCompany. All rights reserved.
// </copyright>

namespace RogueOne.Views
{
    using System.Windows;

    /// <summary>
    /// Interaction logic for ControlsWindow.xaml.
    /// </summary>
    public partial class ControlsWindow : Window
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="ControlsWindow"/> class.
        /// </summary>
        public ControlsWindow()
        {
            this.InitializeComponent();
        }

        private void Button_Back(object sender, RoutedEventArgs e)
        {
            MenuWindow mw = new MenuWindow();
            mw.Top = this.Top;
            mw.Left = this.Left;
            mw.Show();
            this.Close();
        }
    }
}
