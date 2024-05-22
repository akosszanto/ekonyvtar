using GUI_SQL.Model;
using LibraryApp.Models;
using LibraryApp.Repository;
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

namespace LibraryApp
{
    public partial class LoginWindow : Window
    {

        private UsersRepository usersRepository;

        public LoginWindow()
        {
            InitializeComponent();
            usersRepository = new UsersRepository(new LibraryContext());
        }

        private void LoginButton_Click(object sender, RoutedEventArgs e)
        {
            string email = EmailTextBox.Text;
            string password = PasswordBox.Password;

            Users user = usersRepository.GetByEmail(email);

            if(user != null && user.password == password)
            {
                UserSession.Instance.Login(user);

                MessageBoxResult result = MessageBox.Show("Sikeres bejelentkezés! Szeretnéd folytatni?", "Bejelentkezés", MessageBoxButton.YesNo);

                if (result == MessageBoxResult.Yes)
                {
                    UserSession.Instance.Login(user);
                    BooksWindow BooksWindow = new BooksWindow(user);
                    BooksWindow.Show();
                    this.Close();
                }
                else
                {
                    Environment.Exit(0);
                }

            }
            else
            {
                MessageBox.Show("Hibás felhasználónév vagy jelszó!");
            }
        }

        private void BackButton_Click(object sender, RoutedEventArgs e)
        {
            MainWindow main = new MainWindow();
            main.Show();
            this.Close();
        }
    }
}
