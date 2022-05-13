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
using WpfApplicationEntity.Forms.Add;
using WpfApplicationEntity.API;
using System.Windows.Controls.Primitives;

namespace WpfApplicationEntity.Forms.Main
{
    /// <summary>
    /// Логика взаимодействия для AdminWindow.xaml
    /// </summary>
    public partial class AdminWindow : Window
    {
        public AdminWindow()
        {
            InitializeComponent();
            try
            {
                this.ShowAll();
            }
            catch
            {
                MessageBox.Show("База данных была изменена", "Ошибка");
            }           
        }
        //readonly DataService DBContext = new DataService();

        private void ShowAll()
        {
            try
            {
                hostelstudentsgrid.ItemsSource = DataService.GetInhabitedStudents();
                studentsgrid.ItemsSource = DataService.GetUninhabitedStudents();
                roomGrid.ItemsSource = DataService.GetRooms();
                hostelstudentsgrid1.ItemsSource = DataService.GetInhabitedStudents();
                relativeGrid.ItemsSource = DataService.GetRelatives();
                working1Grid.ItemsSource = DataService.GetWorkingOff();
                OutGrid.ItemsSource = DataService.GetWeekendOut();
                LongGrid.ItemsSource = DataService.GetLongOuts();
                //using (MyDBContext objectMyDBContext = new MyDBContext())
                //{
                //    roomGrid.ItemsSource = GridsInfo.GetNewRooms(objectMyDBContext);
                //    //studentGrid.ItemsSource = GridsInfo.GetNewHostelStudents(objectMyDBContext);
                //    hostelstudentsgrid.ItemsSource = GridsInfo.GetNewHostelStudents(objectMyDBContext);
                //    studentsgrid.ItemsSource = GridsInfo.GetNewStudents(objectMyDBContext);
                //    relativeGrid.ItemsSource = GridsInfo.GetNewRelatives(objectMyDBContext);
                //    workingGrid.ItemsSource = GridsInfo.GetNewWorkingOffs(objectMyDBContext);
                //    working1Grid.ItemsSource = GridsInfo.GetNewWorkingOffs(objectMyDBContext);
                //    OutGrid.ItemsSource = GridsInfo.GetNewOuts(objectMyDBContext);
                //    LongGrid.ItemsSource = GridsInfo.GetNewLongOuts(objectMyDBContext);
                //}
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "ОШИБКА", MessageBoxButton.OK, MessageBoxImage.Error);
            }
        }
        //private void addWorkerButton_Click(object sender, RoutedEventArgs e)
        //{
        //    AddStudentWindow form = new AddStudentWindow();
        //    form.ShowDialog();
        //    this.ShowAll();
        //}

        //private void editWorkerButton_Click(object sender, RoutedEventArgs e)
        //{
        //    if (studentGrid.SelectedItem != null)
        //    {
        //        var edit = (GridsInfo.newStudent)studentGrid.SelectedItem;
        //        AddStudentWindow form = new AddStudentWindow(DBContext.Students.Find(edit.ID).ID);
        //        form.ShowDialog();
        //    }
        //    else MessageBox.Show("Не выбрано поле для редактирования", "Ошибка");
        //    this.ShowAll();
        //}

        private void deleteWorkerButton_Click(object sender, RoutedEventArgs e)
        {
            if (hostelstudentsgrid.SelectedItem != null)
            {
                var deleted = (StudentsView)hostelstudentsgrid.SelectedItem;
                DataService.StudentDel(new Hostel { cn_S = deleted.cn_S, id_Room = Convert.ToInt32(deleted.Room) });
                //AddStudentWindow form = new AddStudentWindow((StudentsView)studentsgrid.SelectedItem);
                //form.ShowDialog();
                this.ShowAll();
                //var deleted = (GridsInfo.newStudent)hostelstudentsgrid.SelectedItem;
                //var student = DBContext.Students.Find(deleted.ID);
                //student.Room = null;
                //DBContext.SaveChanges();
                //this.ShowAll();
            }
            else MessageBox.Show("Не выбран студент для выселения", "Ошибка");
            //if (hostelstudentsgrid.SelectedItem != null)
            //{
            //    var deleted = (GridsInfo.newStudent)hostelstudentsgrid.SelectedItem;
            //    var student = DBContext.Students.Find(deleted.ID);
            //    student.Room = null;
            //    DBContext.SaveChanges();
            //    this.ShowAll();
            //}
            //else MessageBox.Show("Не выбран студент для выселения", "Ошибка");
        }

        private void editOrderButton_Click(object sender, RoutedEventArgs e)
        {
            //if (roomGrid.SelectedItem != null)
            //{
            //    var edit = (GridsInfo.newRoom)roomGrid.SelectedItem;
            //    AddRoomWindow form = new AddRoomWindow(DBContext.Rooms.Find(edit.ID).ID);
            //    form.ShowDialog();
            //}
            //else MessageBox.Show("Не выбрано поле для редактирования", "Ошибка");
            //this.ShowAll();
        }

        private void addProductButton_Click(object sender, RoutedEventArgs e)
        {
            //AddPesticide_processing_planWindow form = new AddPesticide_processing_planWindow();
            //form.ShowDialog();
            //this.ShowAll();
        }

        private void editProductButton_Click(object sender, RoutedEventArgs e)
        {
            //    if (relativeGrid.SelectedItem != null)
            //    {
            //        var edit = (Relative)relativeGrid.SelectedItem;
            //        AddPesticide_processing_planWindow form = new AddPesticide_processing_planWindow(DBContext.Relatives.Find(edit.ID).ID);
            //        form.ShowDialog();
            //    }
            //    else MessageBox.Show("Не выбрано поле для редактирования", "Ошибка");
            //    this.ShowAll();
        }

        private void deleteProductButton_Click(object sender, RoutedEventArgs e)
        {
            //if (relativeGrid.SelectedItem != null)
            //{
            //    var deleted = (Relative)relativeGrid.SelectedItem;
            //    var list = (from item in DBContext.Relatives.ToList()
            //                where item.ID.CompareTo(deleted.ID) == 0
            //                select item).ToList();
            //    DBContext.Relatives.Remove(list[0]);
            //    DBContext.SaveChanges();
            //    this.ShowAll();
            //}
            //else MessageBox.Show("Не выбрано поле для удаления", "Ошибка");
        }
        private void Window_Loaded(object sender, RoutedEventArgs e)
        {
            tabControl.SelectedIndex = 2;
        }
        private void reportRelativesButton_Click(object sender, RoutedEventArgs e)
        {
            //Reports.ReportRelatives();
        }
       
        private void OldRadio_Checked(object sender, RoutedEventArgs e)
        {
            hostelstudentsgrid1.ItemsSource = Filters.OldFilter(true);            
        }

        private void YoungRadio_Checked(object sender, RoutedEventArgs e)
        {
            hostelstudentsgrid1.ItemsSource = Filters.OldFilter(false);            
        }

        private void RoomSearch_TextChanged(object sender, TextChangedEventArgs e)
        {
            if (RoomSearch.Text.Any(c => Char.IsLetter(c)))
            {
                MessageBox.Show("Ошибка", "В номере комнаты не может быть букв");
            }
            else
            {
                hostelstudentsgrid.ItemsSource = Filters.RoomSearch(RoomSearch.Text);
            }
        }

        private void GroupSearch_TextChanged(object sender, TextChangedEventArgs e)
        {
            hostelstudentsgrid.ItemsSource = Filters.InGroupSearch(GroupSearch.Text);
            studentsgrid.ItemsSource = Filters.UnGroupSearch(GroupSearch.Text);
        }

        private void SurNameSearch_TextChanged(object sender, TextChangedEventArgs e)
        {
            hostelstudentsgrid.ItemsSource = Filters.InSurnameSearch(SurNameSearch.Text);
            studentsgrid.ItemsSource = Filters.UnSurnameSearch(SurNameSearch.Text);
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            InhabCancel();
        }
        private void InhabCancel()
        {
            OldRadio.IsChecked = false;
            YoungRadio.IsChecked = false;
            WYoungRadio.IsChecked = false;
            GroupSearch2.Text = string.Empty;
            RoomSearch2.Text = string.Empty;
            SurNameSearch2.Text = string.Empty;
            ShowAll();
        }
        private void RelCancel()
        {
            StudentSurNameSearch.Text = string.Empty;
            FIPSearch.Text = string.Empty;
            ShowAll();
        }

        private void deleteGroupWorkerButton_Click(object sender, RoutedEventArgs e)
        {
            //DeleteGroup form = new DeleteGroup();
            //form.ShowDialog();
            //this.ShowAll();
        }

        private void roomGrid_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            if (roomGrid.SelectedItem != null)
            {
                var item = (Room)roomGrid.SelectedItem;
                student_roomGrid.ItemsSource = DataService.GetStudFromRooms().Select(c => c).Where(s => s.id_Room == item.id_Room).ToList();
                //var room = DataService.GetRooms().Find(item);
                //List < StudentsView > test= DataService.GetStudFromRooms();
                //List<StudentsView> test2 = DataService.GetStudFromRooms().Select(c => c).Where(s => s.Room == item.Room_number.ToString()).ToList();
            }
        }

        private void addWorkingButton_Click(object sender, RoutedEventArgs e)
        {
            AddWorkingOffWindow form = new AddWorkingOffWindow();
            form.ShowDialog();
            this.ShowAll();
        }

        private void editWorkingButton_Click(object sender, RoutedEventArgs e)
        {
            if (working1Grid.SelectedItem != null)
            {
                AddWorkingOffWindow form = new AddWorkingOffWindow((WorkingOff)working1Grid.SelectedItem);
                form.ShowDialog();
                this.ShowAll();
            }
            else
                MessageBox.Show("Не выбрано поле для редактирования");
            //if (workingGrid.SelectedItem != null)
            //{
            //    var edit = (GridsInfo.newWorkingOff)workingGrid.SelectedItem;
            //    AddWorkingOffWindow form = new AddWorkingOffWindow(DBContext.Working_Offs.Find(edit.ID).ID);
            //    form.ShowDialog();
            //}
            //else MessageBox.Show("Не выбрано поле для редактирования", "Ошибка");
            //this.ShowAll();
        }

        private void deleteWorkingButton_Click(object sender, RoutedEventArgs e)
        {
            if (working1Grid.SelectedItem != null)
                DataService.PracticeDel((WorkingOff)working1Grid.SelectedItem);
            else
                MessageBox.Show("Не выбрано поле для удаления");
            ShowAll();
            //if (workingGrid.SelectedItem != null)
            //{
            //    var deleted = (GridsInfo.newWorkingOff)workingGrid.SelectedItem;
            //    var list = (from item in DBContext.Working_Offs.ToList()
            //                where item.ID.CompareTo(deleted.ID) == 0
            //                select item).ToList();
            //    DBContext.Working_Offs.Remove(list[0]);
            //    DBContext.SaveChanges();
            //    this.ShowAll();
            //}
            //else MessageBox.Show("Не выбрано поле для удаления", "Ошибка");
        }

        private void WorkingOffDateSearch_TextChanged(object sender, TextChangedEventArgs e)
        {
            //////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////
        }

        private void WorkingOffSurNameSearch_TextChanged(object sender, TextChangedEventArgs e)
        {
            working1Grid.ItemsSource = Filters.WorkingOffSurnameSearch(WorkingOffSurNameSearch.Text);
        }

        private void FIPSearch_TextChanged(object sender, TextChangedEventArgs e)
        {
            relativeGrid.ItemsSource = Filters.FIORelativeSearch(FIPSearch.Text);
        }

        private void StudentSurNameSearch_TextChanged(object sender, TextChangedEventArgs e)
        {
            relativeGrid.ItemsSource = Filters.RelativeStudentSurNameSearch(StudentSurNameSearch.Text);

        }

        private void StudentRoomSearch_TextChanged(object sender, TextChangedEventArgs e)
        {
            // relativeGrid.ItemsSource = Filters.FIORelativeSearch(FIPSearch.Text);

        }

        private void Button_Click_1(object sender, RoutedEventArgs e)
        {
            WorkCancel();
        }

        private void WorkCancel()
        {
            WorkingOffSurNameSearch.Text = string.Empty;
        }

        private void addEndButton_Click(object sender, RoutedEventArgs e)
        {
            AddWeekendOutWindow form = new AddWeekendOutWindow();
            form.ShowDialog();
            this.ShowAll();
        }
        private void editEndButton_Click(object sender, RoutedEventArgs e)
        {
            if (OutGrid.SelectedItem != null)
            {
                AddWeekendOutWindow form = new AddWeekendOutWindow((WeekendOut)OutGrid.SelectedItem);
                form.ShowDialog();
                this.ShowAll();
            }
            else
                MessageBox.Show("Не выбрано поле для редактирования");
        }
        private void deleteEndButton_Click(object sender, RoutedEventArgs e)
        {
            if (OutGrid.SelectedItem != null)
                DataService.WeekendOutDel((WeekendOut)OutGrid.SelectedItem);
            else
                MessageBox.Show("Не выбрано поле для удаления");
            ShowAll();
        }
        private void reportoOutsButton_Click(object sender, RoutedEventArgs e)
        {
            //Reports.ReportOuts();
        }

        private void addLongButton_Click(object sender, RoutedEventArgs e)
        {
            AddLongOutWindow form = new AddLongOutWindow();
            form.ShowDialog();
            this.ShowAll();
        }

        private void editLongButton_Click(object sender, RoutedEventArgs e)
        {
            if (LongGrid.SelectedItem != null)
            {
                var edit = (LongOut)LongGrid.SelectedItem;
                AddLongOutWindow form = new AddLongOutWindow(edit);
                form.ShowDialog();
            }
            else MessageBox.Show("Не выбрано поле для редактирования", "Ошибка");
            this.ShowAll();
        }

        private void deleteLongButton_Click(object sender, RoutedEventArgs e)
        {
            if (LongGrid.SelectedItem != null)
            {
                DataService.LongOutDel((LongOut)LongGrid.SelectedItem);
                this.ShowAll();
            }
            else MessageBox.Show("Не выбрано поле для удаления", "Ошибка");
        }

        private void addStudentButton_Click(object sender, RoutedEventArgs e)
        {            
            if (studentsgrid.SelectedItem != null)
            {
                AddStudentWindow form = new AddStudentWindow((StudentsView)studentsgrid.SelectedItem);
                form.ShowDialog();
                this.ShowAll();                
            }
            else MessageBox.Show("Не выбран студент для заселения", "Ошибка");
        }

        private void WYoungRadio_Checked(object sender, RoutedEventArgs e)
        {
            hostelstudentsgrid1.ItemsSource = Filters.WYoungFilter();            
        }

        private void SurNameSearch2_TextChanged(object sender, TextChangedEventArgs e)
        {
            hostelstudentsgrid1.ItemsSource = Filters.InSurnameSearch(SurNameSearch2.Text);            
        }

        private void RoomSearch2_TextChanged(object sender, TextChangedEventArgs e)
        {
            if (RoomSearch2.Text.Any(c => Char.IsLetter(c)))
            {
                MessageBox.Show("Ошибка", "В номере комнаты не может быть букв");
            }
            else
            {
                hostelstudentsgrid1.ItemsSource = Filters.RoomSearch(RoomSearch2.Text);
            }
        }

        private void GroupSearch2_TextChanged(object sender, TextChangedEventArgs e)
        {
            hostelstudentsgrid1.ItemsSource = Filters.InGroupSearch(GroupSearch2.Text);            
        }

        private void hostelstudentsgrid1_MouseDoubleClick(object sender, MouseButtonEventArgs e)
        {
            if(hostelstudentsgrid1.SelectedItem != null)
            {
                StudentInfo form = new StudentInfo((StudentsView)hostelstudentsgrid1.SelectedItem);
                form.ShowDialog();                
            }
        }

        private void Button1_Click(object sender, RoutedEventArgs e)
        {
            RelCancel();
        }

        private void Button2_Click(object sender, RoutedEventArgs e)
        {
            UnCancel();
        }

        private void UnCancel()
        {
            GroupSearch.Text = string.Empty;
            RoomSearch.Text = string.Empty;
            SurNameSearch.Text = string.Empty;
            ShowAll();
        }

        private void addGroupButton_Click(object sender, RoutedEventArgs e)
        {

        }

        private void deleteGroupButton_Click(object sender, RoutedEventArgs e)
        {
            DeleteGroup form = new DeleteGroup();
            form.ShowDialog();
            this.ShowAll();
        }

        private void SurNameSearch3_TextChanged(object sender, TextChangedEventArgs e)
        {
            if (String.IsNullOrWhiteSpace(SurNameSearch3.Text))
            {
                ShowAll();
                return;
            }
            roomGrid.ItemsSource = Filters.RoomSurnameSearch(SurNameSearch3.Text);
        }

        private void GroupSearch3_TextChanged(object sender, TextChangedEventArgs e)
        {
            if (String.IsNullOrWhiteSpace(GroupSearch3.Text))
            {
                ShowAll();
                return;
            }
            roomGrid.ItemsSource = Filters.RoomGroupSearch(GridsInfo.GetGroupEng(GroupSearch3.Text));
        }

        private void RoomSearch3_TextChanged(object sender, TextChangedEventArgs e)
        {
            if (String.IsNullOrWhiteSpace(RoomSearch3.Text))
            {
                ShowAll();
                return;
            }
            roomGrid.ItemsSource = Filters.RoomNumberSearch(RoomSearch3.Text);
        }

        private void Button_Click_2(object sender, RoutedEventArgs e)
        {
            SurNameSearch3.Text = string.Empty;
            RoomSearch3.Text = string.Empty;
            GroupSearch3.Text = string.Empty;
            ShowAll();
        }

        private void reportHostelButton_Click(object sender, RoutedEventArgs e)
        {
            Reports.ReportInhabitated();
        }

        //private void SearchBox_TextChanged(object sender, TextChangedEventArgs e)
        //{
        //    var str = SearchBox.Text;
        //    studentGrid.ItemsSource = DBContext.Students.Select(c => c).Where(c => c.SurName.StartsWith(str)).ToList();
        //}

        //private void Man_Checked(object sender, RoutedEventArgs e)
        //{
        //    if (Man.IsChecked == true)
        //    {
        //        studentGrid.ItemsSource = DBContext.Students.Select(c => c).Where(c=>c.Gender == true).ToList();
        //    }
        //    else if (Woman.IsChecked == true)
        //    {
        //        studentGrid.ItemsSource = DBContext.Students.Select(c => c).Where(c => c.Gender == false).ToList();
        //    }
        //    else
        //    {

        //    }
        //}

        //private void Woman_Checked(object sender, RoutedEventArgs e)
        //{
        //    if (Man.IsChecked == true)
        //    {
        //        studentGrid.ItemsSource = DBContext.Students.Select(c => c).Where(c => c.Gender == true).ToList();
        //    }
        //    else if (Woman.IsChecked == true)
        //    {
        //        studentGrid.ItemsSource = DBContext.Students.Select(c => c).Where(c => c.Gender == false).ToList();
        //    }
        //    else
        //    {

        //    }
        //}
    }
}
