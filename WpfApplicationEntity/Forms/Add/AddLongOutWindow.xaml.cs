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
using System.Windows.Shapes;
using WpfApplicationEntity.API;
namespace WpfApplicationEntity.Forms.Add
{
    /// <summary>
    /// Логика взаимодействия для AddLongOutWindow.xaml
    /// </summary>
    public partial class AddLongOutWindow : Window
    {
        private readonly LongOut longOut;
        public AddLongOutWindow()
        {
            InitializeComponent();
        }
        public AddLongOutWindow(LongOut longOut)
        {
            InitializeComponent();
            this.longOut = longOut;
        }
        private void AddButton_Click(object sender, RoutedEventArgs e)
        {
            if (studentsgrid.SelectedItem != null &&
            DepDateBox.SelectedDate.Value < ArrDateBox.SelectedDate.Value &&
            DepDateBox.SelectedDate.Value < DateTime.Now &&
            ArrDateBox.SelectedDate.Value < DateTime.Now &&
            DepDateBox.SelectedDate.HasValue &&
            ArrDateBox.SelectedDate.HasValue &&
            DepTimeBox.Value.HasValue &&
            ArrTimeBox.Value.HasValue &&
            ReasonCombo.SelectedItem != null)
            {
                StudentsView student = (StudentsView)studentsgrid.SelectedItem;
                if (longOut != null)
                {
                    DataService.LongOutEdit(new LongOut
                    {
                        Departure_Date = DepDateBox.SelectedDate.Value,
                        Departure_Time = DepTimeBox.Value.Value.TimeOfDay,
                        Arrival_Date = ArrDateBox.SelectedDate.Value,
                        Arrival_Time = ArrTimeBox.Value.Value.TimeOfDay,
                        Absence_Reason = ReasonCombo.Text,
                        cn_S = student.cn_S
                    });
                }
                else
                {
                    DataService.LongOutAdd(new LongOut
                    {
                        Departure_Date = DepDateBox.SelectedDate.Value,
                        Departure_Time = DepTimeBox.Value.Value.TimeOfDay,
                        Arrival_Date = ArrDateBox.SelectedDate.Value,
                        Arrival_Time = ArrTimeBox.Value.Value.TimeOfDay,
                        Absence_Reason = ReasonCombo.Text,
                        cn_S = student.cn_S
                    });
                }
                this.Close();
            }
            else MessageBox.Show("Заполнены не все поля");
        }

        private void CancelButon_Click(object sender, RoutedEventArgs e)
        {
            this.Close();
        }

        private void Window_Loaded(object sender, RoutedEventArgs e)
        {
            studentsgrid.ItemsSource = DataService.GetInhabitedStudents();
            ReasonCombo.ItemsSource = DataService.GetReasons();
            if (longOut != null)
            {
                AddButton.Content = "Сохранить";
                DepDateBox.SelectedDate = longOut.Departure_Date;
                DepTimeBox.Value = DateTime.MinValue + longOut.Departure_Time;
                ArrDateBox.SelectedDate = longOut.Arrival_Date;
                ArrTimeBox.Value = DateTime.MinValue + longOut.Arrival_Time;
                ReasonCombo.Text = longOut.Absence_Reason;
                studentsgrid.SelectedItem = studentsgrid.Items.Cast<StudentsView>().Select(c => c).Where(c => c.cn_S == longOut.cn_S).First();
                studentsgrid.IsReadOnly = true;
            }
        }

        private void StudSearch_TextChanged(object sender, TextChangedEventArgs e)
        {
            studentsgrid.ItemsSource = Filters.InSurnameSearch(StudSearch.Text);
        }
    }
}
