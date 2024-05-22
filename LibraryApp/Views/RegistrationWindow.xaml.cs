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
using LibraryApp.Repository;
using LibraryApp.Models;
using GUI_SQL.Model;

namespace LibraryApp
{
    public partial class RegistrationWindow : Window
    {
        private UsersRepository _usersRepository;

        public RegistrationWindow()
        {
            InitializeComponent();
            _usersRepository = new UsersRepository(new LibraryContext());
        }

        private void RegisterButton_Click(object sender, RoutedEventArgs e)
        {
            if (NameTextBox.Text != "" && EmailTextBox.Text != "" && PasswordBox.Password != "")
            {
                Users newUser = new Users
                {
                    nev = NameTextBox.Text,
                    permission = 0,
                    email = EmailTextBox.Text,
                    password = PasswordBox.Password,
                };

                _usersRepository.InsertUsers(newUser);
                _usersRepository.Save();

                MessageBoxResult result = MessageBox.Show("Sikeres regisztráció! Szeretnéd folytatni?", "Regisztráció", MessageBoxButton.YesNo);

                if (result == MessageBoxResult.Yes)
                {
                    UserSession.Instance.Login(newUser);
                    BooksWindow BooksWindow = new BooksWindow(newUser);
                    BooksWindow.Show();
                    Close();
                }
                else
                {
                    Environment.Exit(0);
                }

            }
            else
            {
                MessageBox.Show("Valami hiba történt a regisztráció során!");
            }
        }

        private void BackButton_Click(object sender, RoutedEventArgs e)
        {
            MainWindow mainWindow = new MainWindow();
            mainWindow.Show();
            Close();
        }
    }
}
