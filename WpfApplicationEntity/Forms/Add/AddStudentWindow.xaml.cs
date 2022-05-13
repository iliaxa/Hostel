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
    /// Логика взаимодействия для AddWorkerWindow.xaml
    /// </summary>
    public partial class AddStudentWindow : Window
    {
        StudentsView newStudent;
        public AddStudentWindow(StudentsView student)
        {
            InitializeComponent();
            newStudent = student;
        }
        //public AddStudentWindow(int ID)
        //{
        //    InitializeComponent();
        //    this.EditID = ID;
        //}
        //private readonly int EditID = -1;
        private void Window_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.Key == Key.Enter)
                TryAdd();
        }
        private void TryAdd()
        {
            try
            {
                var room = (Room)roomGrid.SelectedItem;
                DataService.StudentAdd(new Hostel { cn_S = newStudent.cn_S, id_Room = room.id_Room });
                //MessageBox.Show("Студент успешно заселён!");
                this.Close();

            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message,"Внимание",MessageBoxButton.OK, MessageBoxImage.Warning);
            }
        }
        private void AddButton_Click(object sender, RoutedEventArgs e)
        {
            TryAdd();
            //using (DataService db = new DataService())
            //{
            //    if (!String.IsNullOrWhiteSpace(RoomBox.Text) &&
            //        RoomBox.Text.All(c => Char.IsDigit(c)) &&
            //        RoomBox.Text.Length == 3)
            //    //NumberBox.Text.Length < 12 &&
            //    //NumberBox.Text.Length >= 7 &&
            //    //RoomCombo.SelectedIndex != -1 &&
            //    //BirthBox.SelectedDate != null &&
            //    //BirthBox.SelectedDate.Value.Year < DateTime.Now.Year - 14)
            //    {
            //        if (GetRoom(db.Rooms.ToList()) != null)
            //        {
            //            if (GetRoom(db.Rooms.ToList()).Residing_Count > GetRoom(db.Rooms.ToList()).Students.Count)
            //            {
            //                GetStudent(db.Students.ToList()).Room = GetRoom(db.Rooms.ToList());
            //            }
            //            else MessageBox.Show("Комната заполнена!");
            //            //bool gender;
            //            //if (MaleRadio.IsChecked.Value == true)
            //            //    gender = true;
            //            //else gender = false;
            //            //Student student = new Student
            //            //{
            //            //    ID = db.Students.Count() + 1,
            //            //    SurName = SurNameBox.Text,
            //            //    Name = NameBox.Text,
            //            //    LastName = LastNameBox.Text,
            //            //    Phone_Number = NumberBox.Text,
            //            //    Group = GroupBox.Text,
            //            //    BirthDay = BirthBox.SelectedDate.Value,
            //            //    Gender = gender,
            //            //    Room = GetRoom(db.Rooms.ToList())
            //            //};
            //            //if (EditID == -1)
            //            //{
            //            //    db.Students.Add(student);
            //            //}
            //            //else
            //            //{
            //            //    var result = db.Students.Find(EditID);
            //            //    result.SurName = SurNameBox.Text;
            //            //    result.Name = NameBox.Text;
            //            //    result.LastName = LastNameBox.Text;
            //            //    result.Phone_Number = NumberBox.Text;
            //            //    result.BirthDay = BirthBox.SelectedDate.Value;
            //            //    result.Group = GroupBox.Text;
            //            //    result.Gender = gender;
            //            //    result.Room = GetRoom(db.Rooms.ToList());
            //            //}
            //            db.SaveChanges();
            //            this.Close();
            //        }
            //        else MessageBox.Show("Комната не найдена");
            //    }
            //    else MessageBox.Show("Полe ввода заполненo некорректно");

            //    db.SaveChanges();
            //}
        }
        //private Room GetRoom(List<Room> rooms)
        //{
        //    foreach (var item in rooms)
        //    {
        //        if (item.Number.ToString() == this.RoomBox.Text.ToString())
        //            return item;
        //    }
        //    return null;
        //}
        //private StudentsView GetStudent(List<StudentsView> students)
        //{
        //    //foreach (var item in students)
        //    //{
        //    //    if (item.ID == this.newStudent.ID)
        //    //        return item;
        //    //}
        //    //return null;
        //}
        private void CancelButon_Click(object sender, RoutedEventArgs e)
        {
            this.Close();
        }

        private void Window_Loaded(object sender, RoutedEventArgs e)
        {
            FIO.Content = newStudent.SurName + " " + newStudent.Name + " " + newStudent.FatherName;
            roomGrid.ItemsSource = DataService.GetFreeRooms().Select(c => c).Where(c => c.FreeSeats != c.People_amount);
        }

        private void roomGrid_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {

        }
        //private bool IsRoomCorrect(Room room)
        //{
        //    if (this.RoomCombo.SelectedIndex == -1)
        //    {
        //        return true;
        //    }
        //    return room.Students.Count() < room.Residing_Count;
        //}
        //private void Window_Loaded(object sender, RoutedEventArgs e)
        //{
        //    using (MyDBContext db = new MyDBContext())
        //    {
        //        Student result = db.Students.Find(this.EditID);
        //        var types = db.Rooms.ToList();
        //        List<string> typeList = new List<string>();
        //        foreach (var item in types)
        //            typeList.Add(item.Number.ToString());
        //        typeList.Remove(typeList.First());
        //        RoomCombo.ItemsSource = typeList;
        //        if (EditID != -1)
        //        {
        //            AddButton.Content = "Сохранить";
        //            SurNameBox.Text = result.SurName;
        //            NameBox.Text= result.Name;
        //            LastNameBox.Text= result.LastName;
        //            NumberBox.Text= result.Phone_Number;
        //            BirthBox.SelectedDate= result.BirthDay;
        //            if (result.Gender)
        //                MaleRadio.IsChecked = true;
        //            else
        //                WomanRadio.IsChecked = true;
        //            RoomCombo.SelectedItem = result.Room.Number;
        //        }
        //    }
    }
}
