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
namespace WpfApplicationEntity.Forms.Main
{
    /// <summary>
    /// Логика взаимодействия для DeleteGroup.xaml
    /// </summary>
    public partial class DeleteGroup : Window
    {
        private void Window_Loaded(object sender, RoutedEventArgs e)
        {
            var list = DataService.GetGroups();
            for (int i = 0; i < list.Count; i++)
            {
                list[i] = GridsInfo.GetGroupRus(list[i]);
            }
            GroupCombo.ItemsSource = list;
        }

        private void bGruppa_Click(object sender, RoutedEventArgs e)
        {
            DataService.GroupStudentDel(DataService.GetGroups()[GroupCombo.SelectedIndex]);
            this.Close();
        }
        public DeleteGroup()
        {
            InitializeComponent();
        }
        //private void bGruppa_Click(object sender, RoutedEventArgs e)
        //{
        //    db.Students.Select(c => c).Where(c => c.Group == GroupCombo.SelectedItem.ToString()).ToList().ForEach(c => c.Room = db.Rooms.First());
        //    db.SaveChanges();
        //    this.Close();
        //}

        //private void Window_Loaded(object sender, RoutedEventArgs e)
        //{
        //    var types = db.Students.GroupBy(c => c.Group).Select(c => c.Key).ToList();
        //    List<string> typeList = new List<string>();
        //    foreach (var item in types)
        //        typeList.Add(item.ToString());
        //    GroupCombo.ItemsSource = typeList;
        //}
    }
}
