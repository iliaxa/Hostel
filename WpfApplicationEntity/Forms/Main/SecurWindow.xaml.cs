using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Shapes;
using WpfApplicationEntity.API;
namespace WpfApplicationEntity.Forms.Main
{
    /// <summary>
    /// Логика взаимодействия для SecurWindow.xaml
    /// </summary>
    public partial class SecurWindow : Window
    {
        public SecurWindow()
        {
            InitializeComponent();
        }
        private void Window_Loaded(object sender, RoutedEventArgs e)
        {
            tabControl.SelectedIndex = 2;
            try
            {
                this.ShowAll();
            }
            catch
            {
                MessageBox.Show("База данных была изменена", "Ошибка");
            }
        }
        private void ShowAll()
        {
            try
            {
                var outs = DataService.GetWeekendOut();
                for (int i = 0; i < outs.Count; i++)
                {
                    outs[i].StringIsDepartured = GridsInfo.IsDepartured(outs[i].IsDepartured);
                }
                OutGrid.ItemsSource = outs;
                LongGrid.ItemsSource = DataService.GetLongOuts();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "ОШИБКА", MessageBoxButton.OK, MessageBoxImage.Error);
            }
        }
        private void SurNameSearch_TextChanged(object sender, TextChangedEventArgs e)
        {
            OutGrid.ItemsSource = Filters.OutSurnameSearch(SurNameSearch.Text);

        }

        private void reportoOutsButton_Click(object sender, RoutedEventArgs e)
        {
            if (calendar1.SelectedDates.Count >= 2)
                Reports.ReportWeekendOuts(calendar1.SelectedDates.First(), calendar1.SelectedDates.Last());
            else MessageBox.Show("Не выбраны даты");
        }

        private void reason4Radio_Checked(object sender, RoutedEventArgs e)
        {

        }

        private void Reason3Radio_Checked(object sender, RoutedEventArgs e)
        {

        }

        private void Reason2Radio_Checked(object sender, RoutedEventArgs e)
        {

        }

        private void Reason1Radio_Checked(object sender, RoutedEventArgs e)
        {

        }

        private void NullRadio_Checked(object sender, RoutedEventArgs e)
        {
            OutGrid.ItemsSource = Filters.OutNullDepSearch();
        }

        private void MenuItem_Click_1(object sender, RoutedEventArgs e)
        {
            var item = (WeekendOut)OutGrid.SelectedItem;
            item.IsDepartured = false;
            DataService.WeekendOutEdit(item);
            this.ShowAll();
        }

        private void MenuItem_Click(object sender, RoutedEventArgs e)
        {
            var item = (WeekendOut)OutGrid.SelectedItem;
            item.IsDepartured = true;
            DataService.WeekendOutEdit(item);
            this.ShowAll();
        }

        private void LSurNameSearch_TextChanged(object sender, TextChangedEventArgs e)
        {
            LongGrid.ItemsSource = Filters.LongSurnameSearch(LSurNameSearch.Text);
        }

        private void DepRadio_Checked(object sender, RoutedEventArgs e)
        {
            OutGrid.ItemsSource = Filters.OutDepSearch();
        }

        private void calendar_SelectedDatesChanged(object sender, SelectionChangedEventArgs e)
        {
            LongGrid.ItemsSource = DataService.GetLongOuts().Select(c => c).Where(o => Convert.ToDateTime(o.Departure_Date) == calendar.SelectedDate || (Convert.ToDateTime(o.Departure_Date) < calendar.SelectedDate.Value.AddSeconds(1) && Convert.ToDateTime(o.Arrival_Date) > calendar.SelectedDate.Value.AddSeconds(-1)));
        }

        private void calendar1_SelectedDatesChanged(object sender, SelectionChangedEventArgs e)
        {
            OutGrid.ItemsSource = DataService.GetWeekendOut().Select(c => c).Where(o =>  calendar1.SelectedDates.Any(c=>c == o.Departure_Date) || calendar1.SelectedDates.Any(c=>c.AddSeconds(1) > o.Departure_Date) && calendar1.SelectedDates.Any(c=>c.AddSeconds(-1) < o.Arrival_Date));
        }

        private void Button_Click_1(object sender, RoutedEventArgs e)
        {
            //Reason4Radio.IsChecked = false;
            //Reason3Radio.IsChecked = false;
            //Reason2Radio.IsChecked = false;
            //Reason1Radio.IsChecked = false;
            LSurNameSearch.Text = string.Empty;
            this.ShowAll();
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            DepRadio.IsChecked = false;
            ArrRadio.IsChecked = false;
            NullRadio.IsChecked = false;
            //RoomSearch.Text = string.Empty;
            SurNameSearch.Text = string.Empty;
            this.ShowAll();
        }

        private void ArrRadio_Checked(object sender, RoutedEventArgs e)
        {
            OutGrid.ItemsSource = Filters.OutArrSearch();
        }
    }
}
