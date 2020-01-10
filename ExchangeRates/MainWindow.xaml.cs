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
            RatesForSpecificDayView.Visibility = Visibility.Hidden;
            CurrencyConverterView.Visibility = Visibility.Hidden;
            GoldRatesView.Visibility = Visibility.Hidden;
            CurrencyDetailsView.Visibility = Visibility.Hidden;
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            TodayRatesView.Visibility = Visibility.Visible;
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
            GoldRatesView.Visibility = Visibility.Hidden;
            CurrencyDetailsView.Visibility = Visibility.Hidden;
        }

        private void Button_Click_2(object sender, RoutedEventArgs e)
        {
            TodayRatesView.Visibility = Visibility.Hidden;
            CurrencyConverterView.Visibility = Visibility.Visible;
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
            CurrencyDetailsView.Visibility = Visibility.Hidden;
        }

        private void Button_Click_4(object sender, RoutedEventArgs e)
        {
            CurrencyDetailsView.Visibility = Visibility.Visible;
            TodayRatesView.Visibility = Visibility.Hidden;
            CurrencyConverterView.Visibility = Visibility.Hidden;
            RatesForSpecificDayView.Visibility = Visibility.Hidden;
            GoldRatesView.Visibility = Visibility.Hidden;
        }
    }

    
}
