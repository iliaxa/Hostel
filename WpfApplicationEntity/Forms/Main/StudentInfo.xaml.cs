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
    /// Логика взаимодействия для StudentInfo.xaml
    /// </summary>
    public partial class StudentInfo : Window
    {
        private readonly StudentsView student;
        public StudentInfo(StudentsView studentInfo)
        {
            InitializeComponent();
            student = DataService.GetDopInfo(studentInfo).First();
        }
        public void ShowAll()
        {
            tbStudentTelephone.Text = student.Telephone_Mob;
            tbStudentTelephoneHome.Text = student.Telephone_Home;
            dpStudentDateBirth.SelectedDate = student.DateBirth;
            tbStudentPassportSeries.Text = student.PassportSeries;
            chbCitizenRB.IsChecked = student.RB;
            tbStudentPassportNumber.Text = student.PassportNumber.ToString();
            tbStudentPassportIdentificNumber.Text = student.PasportID;
            tbStudentAdress.Text = student.Adress;
            cbStudentMedGroup.ItemsSource = DataService.GetMedGroup();
            cbStudentMedGroup.SelectedItem = DataService.GetStudMG();
            if (DataService.GetStudOrphan(student).Count != 0)
                chbStudentIsInvalid.IsChecked = true;
            dgStudentFamilyInfo.ItemsSource = DataService.GetStudRelatives(student);
            if (DataService.GetFamilyState(student).Count > 0)
            cbFamilyType.Content = DataService.GetFamilyState(student).First().ToString();
        }
        private void TabControlProect_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {

        }

        private void chbStudentSOP_Click(object sender, RoutedEventArgs e)
        {

        }

        private void chbStudentOrphan_Click(object sender, RoutedEventArgs e)
        {

        }

        private void chbStudentNGZ_Click(object sender, RoutedEventArgs e)
        {

        }

        private void chbStudentLivesHostal_Click(object sender, RoutedEventArgs e)
        {

        }

        private void chbStudentInvalid_Click(object sender, RoutedEventArgs e)
        {

        }

        private void chbStudentIndividualProtAccounting_Click(object sender, RoutedEventArgs e)
        {

        }

        private void BtnSaveStudentInfo_Click(object sender, RoutedEventArgs e)
        {

        }

        private void BtnEditStudentInfo_Click(object sender, RoutedEventArgs e)
        {

        }

        private void chbStudentInvalidParents_Click(object sender, RoutedEventArgs e)
        {

        }

        private void BtnSaveStudentFamilyInfo_Click(object sender, RoutedEventArgs e)
        {

        }

        private void BtnForEditRelative_Click(object sender, RoutedEventArgs e)
        {

        }

        private void BtnForDeleteRelative_Click(object sender, RoutedEventArgs e)
        {

        }

        private void BtnForDeleteKindOfFamily_Click(object sender, RoutedEventArgs e)
        {

        }

        private void BtnForCanselAddOrEditRelative_Click(object sender, RoutedEventArgs e)
        {

        }

        private void BtnForCanselAddKindOfFamily_Click(object sender, RoutedEventArgs e)
        {

        }

        private void BtnForAppliEditOrAddRelative_Click(object sender, RoutedEventArgs e)
        {

        }

        private void BtnForAppliAddKindOfFamily_Click(object sender, RoutedEventArgs e)
        {

        }

        private void BtnForAddRelative_Click(object sender, RoutedEventArgs e)
        {

        }

        private void BtnForAddKindOfFamily_Click(object sender, RoutedEventArgs e)
        {

        }

        private void BtnEditStudentFamilyInfo_Click(object sender, RoutedEventArgs e)
        {

        }

        private void Window_Loaded(object sender, RoutedEventArgs e)
        {
            ShowAll();

        }
    }
}
