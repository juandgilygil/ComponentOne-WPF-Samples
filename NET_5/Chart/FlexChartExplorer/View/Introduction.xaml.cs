﻿using System;
using System.Linq;
using System.Collections.Generic;
using System.Windows.Controls;
using C1.Chart;
using System.Windows.Data;
using System.Globalization;
using System.Windows;

namespace FlexChartExplorer
{
    /// <summary>
    /// An empty page that can be used on its own or navigated to within a Frame.
    /// </summary>
    public sealed partial class Introduction : UserControl
    {
        List<string> _chartTypes;
        List<FruitDataItem> _fruits;
        List<string> _palettes;
        List<string> _stackings;

        public Introduction()
        {
            this.InitializeComponent();
            EnumConverter enumConverter = new EnumConverter();
            cbChartType.SetBinding(ComboBox.SelectedValueProperty, new System.Windows.Data.Binding() { ElementName = "flexChart", Path = new PropertyPath("ChartType"), 
                Mode = BindingMode.TwoWay, Converter = enumConverter });
            cbPalette.SetBinding(ComboBox.SelectedValueProperty, new System.Windows.Data.Binding() { ElementName = "flexChart", Path = new PropertyPath("Palette"), 
                Mode = BindingMode.TwoWay, Converter = enumConverter });
            cbStacked.SetBinding(ComboBox.SelectedValueProperty, new System.Windows.Data.Binding() { ElementName = "flexChart", Path = new PropertyPath("Stacking"), 
                Mode = BindingMode.TwoWay, Converter = enumConverter });
            cbRotate.SetBinding(CheckBox.IsCheckedProperty, new System.Windows.Data.Binding() { ElementName = "flexChart", Path = new PropertyPath("Rotated"), 
                Mode = BindingMode.TwoWay });

            Tag = "This view shows the FlexChart's basic features. It binds the chart to a data source and allows you to select the chart type, series stacking, and rotation.\r" +
                "If you move the mouse over a chart element, a tooltip will appear showing details about the data point.\r" + Environment.NewLine +
                "The simplest way to use the FlexChart is to:\r" + Environment.NewLine +
                "1.Set the chart's DataSource property to an array of data objects.\r" +
                "2.Set the chart's bindingX property to the name of the property that contains the X values (in this example fruit names).\r" +
                "3.Add one or more Series objects to the chart's series array and set their binding property to the name of the property that contains the Y values (in this example the months of March, April, and May).";
        }

        public List<string> ChartTypes
        {
            get
            {
                if (_chartTypes == null)
                {
                    _chartTypes = DataCreator.CreateSimpleChartTypes();
                }

                return _chartTypes;
            }
        }

        public List<string> Palettes
        {
            get
            {
                if (_palettes == null)
                {
                    _palettes = Enum.GetNames(typeof(Palette)).ToList();    
                }

                return _palettes;
            }
        }

        public List<string> Stackings
        {
            get
            {
                if (_stackings == null)
                {
                    _stackings = Enum.GetNames(typeof(Stacking)).ToList();
                }

                return _stackings;
            }
        }

        public List<FruitDataItem> Data
        {
            get
            {
                if (_fruits == null)
                {
                    _fruits = DataCreator.CreateFruit();
                }

                return _fruits;
            }
        }

        private void cbGroup_CheckedChanged(object sender, System.Windows.RoutedEventArgs e)
        {
            if (cbGroup.IsChecked != null && cbGroup.IsChecked.Value)
            {
                flexChart.Series[0].StackingGroup = 0;
                flexChart.Series[1].StackingGroup = 0;
                flexChart.Series[2].StackingGroup = 1;
            }
            else
                foreach (var series in flexChart.Series)
                {
                    series.StackingGroup = -1;
                }
            }
        }

    public class GroupCheckBoxVisibilityConverter : IMultiValueConverter
    {
        public object Convert(object[] values, Type targetType, object parameter, System.Globalization.CultureInfo culture)
        {
            if ((string.Equals(values[0], "Column") || string.Equals(values[0], "Bar")) && (string.Equals(values[1], "Stacked") || string.Equals(values[1], "Stacked100pc")))
            {
                return System.Windows.Visibility.Visible;
            }
            return System.Windows.Visibility.Collapsed;

        }
        public object[] ConvertBack(object values, Type[] targetType, object parameter, System.Globalization.CultureInfo culture)
        {
            return null;
        }
    }

}
