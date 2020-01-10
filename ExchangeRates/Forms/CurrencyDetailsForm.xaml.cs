using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
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
using ExchangeRates;

namespace ExchangeRates.Forms
{
    /// <summary>
    /// Interaction logic for CurrencyDetailsFormxaml.xaml
    /// </summary>
    public partial class CurrencyDetailsFormxaml : UserControl
    {
        public List<List<RateModel>> RatesList = new List<List<RateModel>>();
        public List<RateModel> childRatesList;
        public List<Rates> endList;
        public List<Rate> currencyDetailsList = new List<Rate>();
        public CurrencyDetailsFormxaml()
        {
            InitializeComponent();
        }

        private void ComboBox_GotMouseCapture(object sender, MouseEventArgs e)
        {
            loadList();
        }
        public async void loadList()
        {
            if (currenciesCombobox.ItemsSource == null)
            {
                RatesProcessor ratesProcessor = new RatesProcessor();
                RatesList.Clear();
                RatesList.Add(await ratesProcessor.GetTodaysRates("A"));
                RatesList.Add(await ratesProcessor.GetTodaysRates("B"));
                RatesList.Add(await ratesProcessor.GetTodaysRates("C"));
                childRatesList = RatesList.SelectMany(x => x).ToList();
                endList = childRatesList.SelectMany(x => x.Rates).ToList();
                currenciesCombobox.ItemsSource = endList.Select(x => x.Code + " - " + x.Currency).ToList();
            }

        }

        private async void Button_Click(object sender, RoutedEventArgs e)
        {
            string currencyCode = currenciesCombobox.SelectedItem.ToString();
          
            int index1 = currencyCode.IndexOf(" ");
            if (index1 > 0)
                currencyCode = currencyCode.Substring(0, index1);
           
            foreach (var item in childRatesList)
            {
                if (item.Rates.Find(x => x.Code == currencyCode) != null) ;
                {
                    string tableOfCurrency = item.table;
                    CurrencyDetalisOperations currencyDetalis = new CurrencyDetalisOperations();
                    var result =await currencyDetalis.getCurrencyDetails(tableOfCurrency, currencyCode);
                    currencyDetailsList = result.rates.OrderBy(x=>x.effectiveDate).ToList();    
                    filldataGrid();
                    return;
                }
            }
        }

        private void filldataGrid()
        {
            currencyDetailsGrid.ItemsSource = currencyDetailsList;
            foreach (var item in currencyDetailsGrid.Columns.ToList())
            {
                item.Width = new DataGridLength(33, DataGridLengthUnitType.Star);
            }
        }
    }
}
