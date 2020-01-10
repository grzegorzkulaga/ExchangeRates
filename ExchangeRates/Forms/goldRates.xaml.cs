﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace ExchangeRates.Forms
{
    /// <summary>
    /// Interaction logic for goldRates.xaml
    /// </summary>
    public partial class goldRates : UserControl
    {  public List<List<GoldRateModel>> goldRatesList = new List<List<GoldRateModel>>();
       public  List<GoldRateModel> childGoldRatesList = new List<GoldRateModel>();
        public goldRates()
        {
            InitializeComponent();
        }

        private async void Button_Click_1(object sender, RoutedEventArgs e)
        {
            GoldRatesOperations goldRatesProcessor = new GoldRatesOperations();
            goldRatesList.Clear();
            goldRatesList.Add(await goldRatesProcessor.GetGoldRates());
            childGoldRatesList = goldRatesList.SelectMany(x => x).ToList();
            fillDataGrid();

        }
        private void fillDataGrid()
        {
            goldRatesGrid.ItemsSource = childGoldRatesList;
            foreach (var item in goldRatesGrid.Columns.ToList())
            {
                item.Width = new DataGridLength(33, DataGridLengthUnitType.Star);
            }
        }
    }
}
