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
    /// Логика взаимодействия для AddOrderTypeWindow.xaml
    /// </summary>
    public partial class AddRoomWindow : Window
    {
        public AddRoomWindow()
        {
            InitializeComponent();
        }
        public AddRoomWindow(int ID)
        {
            InitializeComponent();
            this.EditID = ID;
        }
        private readonly int EditID = -1;
        private void AddButton_Click(object sender, RoutedEventArgs e)
        {
            //using (DataService db = new DataService())
            //{
            //    if (!String.IsNullOrWhiteSpace(NameBox.Text) &&
            //        !String.IsNullOrWhiteSpace(ManufBox.Text) &&
            //        NameBox.Text.All(c => Char.IsDigit(c)) &&
            //        ManufBox.Text.All(c => Char.IsDigit(c)))
            //    {
            //        Room room = new Room
            //        {
            //            ID = db.Rooms.Count() + 1,
            //            Number = Convert.ToInt32(NameBox.Text),
            //            Residing_Count = Convert.ToInt32(ManufBox.Text)
            //        };
            //        if (EditID == -1)
            //        {
            //            db.Rooms.Add(room);
            //        }
            //        else
            //        {
            //            var result = db.Rooms.Find(EditID);
            //            result.Number = Convert.ToInt32(NameBox.Text);
            //            result.Residing_Count = Convert.ToInt32(ManufBox.Text);
            //        }
            //    }
            //    else MessageBox.Show("Заполнены не все поля");
            //    db.SaveChanges();
            //    this.Close();
            //}
        }
        private void CancelButton_Click(object sender, RoutedEventArgs e)
        {
            this.Close();
        }

        private void Window_Loaded(object sender, RoutedEventArgs e)
        {
            //using (DataService db = new DataService())
            //{
            //    Room EditPesticide = db.Rooms.Find(EditID);
            //    if (EditID != -1)
            //    {
            //        AddButton.Content = "Сохранить";
            //        NameBox.Text = EditPesticide.Number.ToString();
            //        ManufBox.Text = EditPesticide.Residing_Count.ToString();
            //    }
            //}
        }
    }
}