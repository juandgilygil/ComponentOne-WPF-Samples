﻿using C1.DataCollection;
using C1.WPF.DataFilter;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Windows;
using System.Windows.Controls;

namespace DataFilterExplorer
{
    /// <summary>
    /// Interaction logic for CarsListControl.xaml
    /// </summary>
    public partial class CarsListControl : UserControl
    {
        private readonly string _fileName = "Expressions.xml";
        private DataTable _carsTable;
        public CarsListControl()
        {
            InitializeComponent();
            Tag = "This sample demonstrates how to use C1DataFilter control to filter the C1FlexGrid control. Also demonstrates how to modify automatically generated filters, save and restore filter expressions.";
            //Get Cars list
            _carsTable = DataProvider.GetCarTable();
            var data = new C1DataCollection<Car>(DataProvider.GetCarDataCollection(_carsTable));
            c1DataFilter.ItemsSource = data;
            flexGrid.ItemsSource = data;
            c1DataFilter.SaveFilterExpression(_fileName);
        }

        private void C1DataFilter_FilterAutoGenerating(object sender, FilterAutoGeneratingEventArgs e)
        {
            switch (e.Property.Name)
            {
                case "Model":
                    var modelFilter = (ChecklistFilter)e.Filter;
                    modelFilter.SelectAll();
                    break;
                case "Brand":
                    var brandFilter = (ChecklistFilter)e.Filter;
                    brandFilter.SelectAll();
                    break;
                case "Liter":
                    var literFilter = (RangeFilter)e.Filter;
                    literFilter.Maximum = _carsTable.AsEnumerable().Max(x => x.Field<double>("Liter"));
                    literFilter.Minimum = _carsTable.AsEnumerable().Min(x => x.Field<double>("Liter"));
                    literFilter.Increment = 0.01;
                    break;
                case "TransmissSpeedCount":
                    var transmissFilter = (ChecklistFilter)e.Filter;
                    transmissFilter.HeaderText = "Transmiss Speed Count";
                    transmissFilter.ShowSelectAll = false;
                    transmissFilter.SelectAll();
                    break;
                case "Category":
                    var categoryFilter = (ChecklistFilter)e.Filter;
                    categoryFilter.ShowSelectAll = false;
                    categoryFilter.SelectAll();
                    break;
                case "TransmissAutomatic":
                    var taFilter = (ChecklistFilter)e.Filter;
                    taFilter.HeaderText = "Transmiss Automatic";
                    taFilter.ItemsSource = new List<TransmissAutomatic>()
                    {
                        new TransmissAutomatic() { DisplayValue = "Yes", Value = "Yes" },
                        new TransmissAutomatic() { DisplayValue = "No", Value = "No" },
                        new TransmissAutomatic() { DisplayValue = "Empty", Value = string.Empty }
                    };
                    taFilter.DisplayMemberPath = "DisplayValue";
                    taFilter.ValueMemberPath = "Value";
                    taFilter.ShowSelectAll = false;
                    taFilter.SelectAll();
                    break;
                case "Price":
                    var priceFilter = (RangeFilter)e.Filter;
                    priceFilter.Maximum = _carsTable.AsEnumerable().Max(x => x.Field<double>("Price"));
                    priceFilter.Minimum = _carsTable.AsEnumerable().Min(x => x.Field<double>("Price"));
                    priceFilter.Increment = 1000;
                    priceFilter.Digits = 0;
                    break;
                default:
                    e.Cancel = true;
                    break;
            }
        }

        private class TransmissAutomatic
        {
            public string DisplayValue { get; set; }
            public object Value { get; set; }
        }

        private void CbAutoApply_CheckChanged(object sender, RoutedEventArgs e)
        {
            if (c1DataFilter != null)
            {
                c1DataFilter.AutoApply = cbAutoApply.IsChecked == true;
            }
        }

        private void BtnSaveFilter_Click(object sender, RoutedEventArgs e)
        {
            c1DataFilter.SaveFilterExpression(_fileName);
        }

        private async void BtnResetFilter_Click(object sender, RoutedEventArgs e)
        {
            c1DataFilter.LoadFilterExpression(_fileName);
            await c1DataFilter.ApplyFilterAsync();
        }

        private async void BtnApplyFilter_Click(object sender, RoutedEventArgs e)
        {
            await c1DataFilter.ApplyFilterAsync();
        }
    }
}
