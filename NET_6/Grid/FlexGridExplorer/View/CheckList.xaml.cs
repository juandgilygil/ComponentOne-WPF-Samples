﻿using FlexGridExplorer.Resources;
using System.Windows;
using System.Windows.Controls;

namespace FlexGridExplorer
{
    public partial class CheckList : UserControl
    {
        public CheckList()
        {
            InitializeComponent();
            Tag = AppResources.CheckListDescription;
            grid.ItemsSource = Customer.GetCities();
        }

        private void OnAutoGeneratingColumn(object sender, C1.WPF.Grid.GridAutoGeneratingColumnEventArgs e)
        {
            e.Column.Width = new GridLength(1, GridUnitType.Star);
        }
    }
}
