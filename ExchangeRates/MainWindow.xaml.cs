using System;
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
using ExchangeRates.Forms;

namespace ExchangeRates
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public  MainWindow()
        {
            InitializeComponent();
            APIhelper.InitializeClient();
            TodayRatesView.Visibility = Visibility.Visible;
            TodayRatesView.todayRatesDataGrid.ItemsSource = null;
            RatesForSpecificDayView.Visibility = Visibility.Hidden;
            CurrencyConverterView.Visibility = Visibility.Hidden;
            GoldRatesView.Visibility = Visibility.Hidden;
            CurrencyDetailsView.Visibility = Visibility.Hidden;
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            TodayRatesView.Visibility = Visibility.Visible;
            TodayRatesView.todayRatesDataGrid.ItemsSource = null;
            RatesForSpecificDayView.Visibility = Visibility.Hidden;
            CurrencyConverterView.Visibility = Visibility.Hidden;
            GoldRatesView.Visibility = Visibility.Hidden;
            CurrencyDetailsView.Visibility = Visibility.Hidden;
        }

        private void Button_Click_1(object sender, RoutedEventArgs e)
        {
            TodayRatesView.Visibility = Visibility.Hidden;
            CurrencyConverterView.Visibility = Visibility.Hidden;
            RatesForSpecificDayView.Visibility = Visibility.Visible;
            RatesForSpecificDayView.SpecificDayPicker.SelectedDate = null;
            RatesForSpecificDayView.SpecificDayRadioB.IsChecked = false;
            RatesForSpecificDayView.DateRangeRadioB.IsChecked = false;
            RatesForSpecificDayView.DateStartPicker.SelectedDate = null;
            RatesForSpecificDayView.DateEndPicker.SelectedDate = null;
            RatesForSpecificDayView.SpecificDaysDataGrid.ItemsSource = null;
            GoldRatesView.Visibility = Visibility.Hidden;
            CurrencyDetailsView.Visibility = Visibility.Hidden;
        }

        private void Button_Click_2(object sender, RoutedEventArgs e)
        {
            TodayRatesView.Visibility = Visibility.Hidden;
            CurrencyConverterView.Visibility = Visibility.Visible;
            CurrencyConverterView.amountTextbox.Text = string.Empty;
            CurrencyConverterView.fromCombobox.SelectedItem = null;
            CurrencyConverterView.toCombobox.SelectedItem = null;
            CurrencyConverterView.resultLabel.Content = string.Empty;
            RatesForSpecificDayView.Visibility = Visibility.Hidden;
            GoldRatesView.Visibility = Visibility.Hidden;
            CurrencyDetailsView.Visibility = Visibility.Hidden;

        }

        private void Button_Click_3(object sender, RoutedEventArgs e)
        {
            TodayRatesView.Visibility = Visibility.Hidden;
            CurrencyConverterView.Visibility = Visibility.Hidden;
            RatesForSpecificDayView.Visibility = Visibility.Hidden;
            GoldRatesView.Visibility = Visibility.Visible;
            GoldRatesView.goldRatesGrid.ItemsSource = null;
            CurrencyDetailsView.Visibility = Visibility.Hidden;
        }

        private void Button_Click_4(object sender, RoutedEventArgs e)
        {
            CurrencyDetailsView.Visibility = Visibility.Visible;
            TodayRatesView.Visibility = Visibility.Hidden;
            CurrencyConverterView.Visibility = Visibility.Hidden;
            RatesForSpecificDayView.Visibility = Visibility.Hidden;
            GoldRatesView.Visibility = Visibility.Hidden;
            CurrencyDetailsView.currenciesCombobox.SelectedItem = null;
            CurrencyDetailsView.currencyDetailsGrid.ItemsSource = null;


        }
    }

    
}
