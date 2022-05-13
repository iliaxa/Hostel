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
namespace WpfApplicationEntity.Forms.Add
{
    /// <summary>
    /// Логика взаимодействия для AddWeekendOutWindow.xaml
    /// </summary>
    public partial class AddWeekendOutWindow : Window
    {
        public AddWeekendOutWindow()
        {
            InitializeComponent();
        }
        public AddWeekendOutWindow(WeekendOut weekendOut)
        {
            InitializeComponent();
            this.weekendOut = weekendOut;
        }
        private readonly WeekendOut weekendOut;
        private void AddButton_Click(object sender, RoutedEventArgs e)
        {
            if (!String.IsNullOrWhiteSpace(NoteBox.Text) &&
            studentsgrid.SelectedItem != null &&
            DepDateBox.SelectedDate.Value < ArrDateBox.SelectedDate.Value &&
            DepDateBox.SelectedDate.Value < DateTime.Now &&
            ArrDateBox.SelectedDate.Value < DateTime.Now &&
            DepDateBox.SelectedDate.HasValue &&
            ArrDateBox.SelectedDate.HasValue &&
            DepTimeBox.Value.HasValue &&
            ArrTimeBox.Value.HasValue)
            {
                StudentsView student = (StudentsView)studentsgrid.SelectedItem;
            if (weekendOut != null)
            {
                DataService.WeekendOutEdit(new WeekendOut
                {
                    ID_Weekend_Out = weekendOut.ID_Weekend_Out,
                    Departure_Date = DepDateBox.SelectedDate.Value,
                    Departure_Time = DepTimeBox.Value.Value.TimeOfDay,
                    Arrival_Date = ArrDateBox.SelectedDate.Value,
                    Arrival_Time = ArrTimeBox.Value.Value.TimeOfDay,
                    Adress = AdressBox.Text,
                    Note = NoteBox.Text,
                    cn_S = student.cn_S,
                    IsDepartured = null
                });
            }
            else
            {
                DataService.WeekendOutAdd(new WeekendOut
                {
                    Departure_Date = DepDateBox.SelectedDate.Value,
                    Departure_Time = DepTimeBox.Value.Value.TimeOfDay,
                    Arrival_Date = ArrDateBox.SelectedDate.Value,
                    Arrival_Time = ArrTimeBox.Value.Value.TimeOfDay,
                    Adress = AdressBox.Text,
                    Note = NoteBox.Text,
                    cn_S = student.cn_S,
                    IsDepartured = null
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
            if (weekendOut != null)
            {
                AddButton.Content = "Сохранить";
                DepDateBox.SelectedDate = weekendOut.Departure_Date;
                DepTimeBox.Value = DateTime.MinValue + weekendOut.Departure_Time;
                ArrDateBox.SelectedDate = weekendOut.Arrival_Date;
                ArrTimeBox.Value = DateTime.MinValue + weekendOut.Arrival_Time;
                AdressBox.Text = weekendOut.Adress;
                NoteBox.Text = weekendOut.Note;
                studentsgrid.SelectedItem = studentsgrid.Items.Cast<StudentsView>().Select(c => c).Where(c => c.cn_S == weekendOut.cn_S).First();
                studentsgrid.IsReadOnly = true;
            }
        }

        private void StudSearch_TextChanged(object sender, TextChangedEventArgs e)
        {
            studentsgrid.ItemsSource = Filters.InSurnameSearch(StudSearch.Text);
        }
    }
}
