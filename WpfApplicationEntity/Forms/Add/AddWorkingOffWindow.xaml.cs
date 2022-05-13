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
    /// Логика взаимодействия для AddWorkingOutWindow.xaml
    /// </summary>
    public partial class AddWorkingOffWindow : Window
    {
        private readonly WorkingOff workingOff;
        public AddWorkingOffWindow()
        {
            InitializeComponent();
        }
        public AddWorkingOffWindow(WorkingOff workingOff)
        {
            InitializeComponent();
            this.workingOff = workingOff;
        }
        private void AddButton_Click(object sender, RoutedEventArgs e)
        {
            if (String.IsNullOrWhiteSpace(HoursBox.Text))
            {
                MessageBox.Show("Заполнены не все поля","Внимание",MessageBoxButton.OK,MessageBoxImage.Warning);
                return;
            }    
            if (HoursBox.Text.Any(c => Char.IsLetter(c)) || HoursBox.Text.Any(c => c == '-'))
            {
                MessageBox.Show("Некорректно введено время", "Внимание", MessageBoxButton.OK, MessageBoxImage.Warning);
                return;
            }
            if (studentsgrid.SelectedItem == null)
            {
                MessageBox.Show("Не выбран студент", "Внимание", MessageBoxButton.OK, MessageBoxImage.Warning);
                return;
            }
            if (!(DateBox.SelectedDate.HasValue) || (DateBox.SelectedDate > DateTime.Now))
            {
                MessageBox.Show("Некорректно введена дата", "Внимание", MessageBoxButton.OK, MessageBoxImage.Warning);
                return;
            }
            if (Convert.ToInt32(HoursBox.Text) > 15)
            {
                MessageBox.Show("Некорректно введено количество часов", "Внимание", MessageBoxButton.OK, MessageBoxImage.Warning);
                return;
            }
            StudentsView student = (StudentsView)studentsgrid.SelectedItem;
                if (workingOff != null)
                {
                    DataService.PracticeEdit(new WorkingOff
                    {
                        ID_Practice_Working_Off = workingOff.ID_Practice_Working_Off,
                        Date = DateBox.SelectedDate.Value,
                        Count_Working_Off_Hours = Convert.ToInt32(HoursBox.Text),
                        Note = NoteBox.Text,
                        cn_S = student.cn_S
                    });
                }
                else
                {
                    DataService.PracticeAdd(new WorkingOff
                    {
                        Date = DateBox.SelectedDate.Value,
                        Count_Working_Off_Hours = Convert.ToInt32(HoursBox.Text),
                        Note = NoteBox.Text,
                        cn_S = student.cn_S
                    });
                }
                this.Close();
        }
        private void CancelButon_Click(object sender, RoutedEventArgs e)
        {
            this.Close();
        }
        private void Window_Loaded(object sender, RoutedEventArgs e)
        {
            studentsgrid.ItemsSource = DataService.GetInhabitedStudents();
            if (workingOff != null)
            {
                DateBox.SelectedDate = workingOff.Date;
                HoursBox.Text = workingOff.Count_Working_Off_Hours.ToString();
                NoteBox.Text = workingOff.Note;
                studentsgrid.SelectedItem = studentsgrid.Items.Cast<StudentsView>().Select(c=>c).Where(c=> c.cn_S == workingOff.cn_S).First();
                studentsgrid.IsReadOnly = true;
                AddButton.Content = "Изменить";
            }
        }

        private void StudSearch_TextChanged(object sender, TextChangedEventArgs e)
        {
            studentsgrid.ItemsSource = Filters.InSurnameSearch(StudSearch.Text);
        }
    }
}