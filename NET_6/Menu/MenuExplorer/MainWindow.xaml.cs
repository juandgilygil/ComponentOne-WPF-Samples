﻿using System.Windows;

namespace MenuExplorer
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();
            this.Title = MenuExplorer.Properties.Resources.Title;
        }
    }
}
