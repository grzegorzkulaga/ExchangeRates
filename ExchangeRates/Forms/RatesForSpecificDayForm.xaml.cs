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

namespace ExchangeRates.Forms
{
    /// <summary>
    /// Interaction logic for RatesForSpecificDayFormxaml.xaml
    /// </summary>
    public partial class RatesForSpecificDayFormxaml : UserControl
    {
        public List<List<RateModel>> SpecificDaysRatesList = new List<List<RateModel>>();
        public List<RateModel> childSpecificDaysRatesList;
        public List<Rates> endList;
        public enum SpecificDayOrDateRange
        {
            SpecificDay,
            DateRange 

        }
        public SpecificDayOrDateRange specificDayOrDateRange;
        public RatesForSpecificDayFormxaml()
        {
            InitializeComponent();
            ShowRatesButton.IsEnabled = false;
            SpecificDayPicker.IsEnabled = false;
            DateStartPicker.IsEnabled = false;
            DateEndPicker.IsEnabled = false;
            
        }

        private void SpecificDayRadioB_Checked(object sender, RoutedEventArgs e)
        {
            specificDayOrDateRange = SpecificDayOrDateRange.SpecificDay;
            ShowRatesButton.IsEnabled = false;
            if (SpecificDayRadioB.IsChecked!=null)
            {
                if ((bool)SpecificDayRadioB.IsChecked)
                {
                    SpecificDayPicker.IsEnabled = true;
                    DateStartPicker.IsEnabled = false;
                    DateEndPicker.IsEnabled = false;
                    DateStartPicker.SelectedDate = null;
                    DateEndPicker.SelectedDate = null;
                }
            }
        }

        private void DateRangeRadioB_Checked(object sender, RoutedEventArgs e)
        {
            specificDayOrDateRange = SpecificDayOrDateRange.DateRange;
            ShowRatesButton.IsEnabled = false;
            if (DateRangeRadioB.IsChecked != null)
            {
                if ((bool)DateRangeRadioB.IsChecked)
                {
                    SpecificDayPicker.IsEnabled = false;
                    DateStartPicker.IsEnabled = true;
                    DateEndPicker.IsEnabled = true;
                    SpecificDayPicker.SelectedDate = null;
                }
            }
        }

        private void SpecificDayPicker_SelectedDateChanged(object sender, SelectionChangedEventArgs e)
        {
            DateValidator();
        }
        /// <summary>
        /// validating if dates are correct
        /// </summary>
        private void DateValidator()
        {
            if (specificDayOrDateRange == SpecificDayOrDateRange.SpecificDay)
            {
                if (SpecificDayPicker.SelectedDate!=null)
                {
                    if (SpecificDayPicker.SelectedDate <= System.DateTime.Today)
                    {
                        ShowRatesButton.IsEnabled = true;
                    }
                  
                }
                else
                {
                    ShowRatesButton.IsEnabled = false;
                }
            }
            else if(specificDayOrDateRange == SpecificDayOrDateRange.DateRange)
            {
                if ((bool)DateRangeRadioB.IsChecked)
                {
                    if (DateStartPicker.SelectedDate != null && DateEndPicker.SelectedDate != null)
                    {
                        if (DateEndPicker.SelectedDate > DateStartPicker.SelectedDate)
                        {
                            ShowRatesButton.IsEnabled = true;
                        }
                        else
                        {
                            ShowRatesButton.IsEnabled = false;
                            MessageBox.Show("End Date can't be before Start Date. Please Correct it and try again");
                        }
                    }
                    else
                    {
                        ShowRatesButton.IsEnabled = false;
                    }
                }
            }
           
        }

        private void DateStartPicker_SelectedDateChanged(object sender, SelectionChangedEventArgs e)
        {
            DateValidator();
        }

        private void DateEndPicker_SelectedDateChanged(object sender, SelectionChangedEventArgs e)
        {
            DateValidator();
        }
        /// <summary>
        ///  event after clik submit button
        /// </summary>
        private async void ShowRatesButton_Click(object sender, RoutedEventArgs e)
        {
            SpecificDaysOperations specificDaysOperations = new SpecificDaysOperations();
            SpecificDaysRatesList.Clear();
            List<string> tablenames = new List<string>(new string[] { "A", "B", "C" });
            if (specificDayOrDateRange == SpecificDayOrDateRange.SpecificDay)
            {
                string specificDay = ((DateTime)SpecificDayPicker.SelectedDate).ToString("yyyy-MM-dd");
                
              
                foreach (var tableName in tablenames)
                {
                    try
                    {
                        SpecificDaysRatesList.Add(await specificDaysOperations.GetSpecificDayRates(tableName, specificDay));
                    }
                    catch (Exception ex)
                    {
                        MessageBox.Show(ex.Message + " dla tabeli" + " " + tableName);
                    }
                }
                
              
            }
            else
            {
                string startDate = ((DateTime)DateStartPicker.SelectedDate).ToString("yyyy-MM-dd");
                string endDate = ((DateTime)DateEndPicker.SelectedDate).ToString("yyyy-MM-dd");
                foreach (var tablename in tablenames)
                {
                    try
                    {
                        SpecificDaysRatesList.Add(await specificDaysOperations.GetSpecificDayRates(tablename, startDate, endDate));
                    }
                    catch (Exception ex)
                    {
                        MessageBox.Show(ex.Message + " dla tabeli" + " " + tablename);
                    }
                }
            }


            childSpecificDaysRatesList = SpecificDaysRatesList.SelectMany(x => x).ToList();
            endList = childSpecificDaysRatesList.SelectMany(x => x.Rates).Where(y=>y.Mid!=0).ToList();
            endList = endList.OrderBy(x => x.Code).ToList();
            fillDataGrid();

        }
        private void fillDataGrid()
        {
            SpecificDaysDataGrid.ItemsSource = endList;
            foreach (var item in SpecificDaysDataGrid.Columns.ToList())
            {
                item.Width = new DataGridLength(33, DataGridLengthUnitType.Star);
            }
        }
    }
}
