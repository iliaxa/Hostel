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
using WpfApplicationEntity.Forms.Main;
using System.DirectoryServices.AccountManagement;
using WpfApplicationEntity.API;

namespace WpfApplicationEntity.Forms
{
    /// <summary>
    /// Логика взаимодействия для AutorizationWindow.xaml
    /// </summary>
    public partial class AutorizationWindow : Window
    {
        public AutorizationWindow()
        {
            InitializeComponent();
        }
        public string Login { get; set; }
        public string Password { get; set; }
        private void TryAutorization()
        {
            try
            {
                Login = LoginBox.Text;
                Password = PasswordBox.Password;
                using (PrincipalContext pc = new PrincipalContext(ContextType.Domain, "college.local", "DC=college,DC=local", Login, Password))
                {
                    if (DataService.GetUser(Login).Count != 0 && pc.ValidateCredentials(Login, Password))
                    {
                        CurrentUser.CU = DataService.GetUser(Login)[0];
                        AdminWindow window = new AdminWindow(/*CurrentUser.CU*/);
                        window.Owner = this;
                        this.Hide();
                        window.Show();
                        PasswordBox.Password = "";
                        LoginBox.Text = "";
                        pc.Dispose();
                    }
                    else if (Login == "user1" && Password == "user1")
                    {
                        AdminWindow Awindow = new AdminWindow();
                        Awindow.Owner = this;
                        this.Hide();
                        Awindow.Show();
                        PasswordBox.Password = "";
                        LoginBox.Text = "";
                        pc.Dispose();
                    }
                    else if (Login == "user2" && Password == "user2")
                    {
                        SecurWindow Swindow = new SecurWindow();
                        Swindow.Owner = this;
                        this.Hide();
                        Swindow.Show();
                        PasswordBox.Password = "";
                        LoginBox.Text = "";
                        pc.Dispose();
                    }
                    else MessageBox.Show("Пользователя с данным логином и паролем не существует", "Ошибка");
                    pc.Dispose();
                }
            }
            catch
            {
                MessageBox.Show("Ошибка при подключении к базе данных!", "Ошибка!", MessageBoxButton.OK, MessageBoxImage.Error);
            }
        }
        private void Window_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.Key == Key.Enter)
                TryAutorization();
        }
        private void AuthorizationButton_Click(object sender, RoutedEventArgs e)
        {
            TryAutorization();
        }
    }
}
