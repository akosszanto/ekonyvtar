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
    public partial class AdminWindow : Window
    {
        private UsersRepository usersRepository;
        private BooksRepository booksRepository;
        private Users currentUser;
        private Books selectedBook;
        private Users selectedUser;
        public AdminWindow(Users user)
        {
            currentUser = user;
            InitializeComponent();
            LoadGrids();


        }

        private void LoadGrids()
        {
            Cursor = Cursors.Wait;
            booksRepository = new BooksRepository(new GUI_SQL.Model.LibraryContext());
            usersRepository = new UsersRepository(new GUI_SQL.Model.LibraryContext());
            var allBooks = booksRepository.GetBooks();
            var allUsers = usersRepository.GetUsers();
            BooksDataGrid.DataContext = allBooks;
            UsersDataGrid.DataContext = allUsers;
            Cursor = Cursors.Arrow;
        }

        private void UserDeleteButton_Click(object sender, RoutedEventArgs e)
        {
            if (selectedUser != null)
            {
                if (MessageBox.Show("Biztosan törli a felhasználót?", "Felhasználó törlése", MessageBoxButton.YesNo) == MessageBoxResult.Yes)
                {
                    usersRepository.DeleteUsers(selectedUser.tagid);
                    usersRepository.Save();
                    LoadGrids();
                }
            }
            else
            {
                MessageBox.Show("Válassza ki a törlendő felhasználót!");
            }
        }

        private void BookDeleteButton_Click(object sender, RoutedEventArgs e)
        {
            if (selectedBook != null)
            {
                if (MessageBox.Show("Biztosan törli a könyvet?", "Könyv törlése", MessageBoxButton.YesNo) == MessageBoxResult.Yes)
                {
                    booksRepository.DeleteBooks(selectedBook.konyvid);
                    booksRepository.Save();
                    LoadGrids();
                }
            }
            else
            {
                MessageBox.Show("Válassza ki a törlendő könyvet!");
            }
        }

        private void BookAddButton_Click(object sender, RoutedEventArgs e)
        {
            string cim = CimTextBox.Text;
            string szerzo = SzerzoTextBox.Text;
            int kiadaseve = int.Parse(KiadaseveTextBox.Text);
            string isbn = IsbnTextBox.Text;

            if (!string.IsNullOrEmpty(cim) && !string.IsNullOrEmpty(szerzo) && kiadaseve > 0 && !string.IsNullOrEmpty(isbn))
            {
                Books newBook = new Books
                {
                    cim = cim,
                    szerzo = szerzo,
                    kiadaseve = kiadaseve,
                    isbn = isbn
                };
                booksRepository.InsertBooks(newBook);
                booksRepository.Save();
                LoadGrids();
            }
            else
            {
                MessageBox.Show("Kérjük, töltse ki az összes mezőt!");
            }
        }

        private void BackButton_Click(object sender, RoutedEventArgs e)
        {
            BooksWindow booksWindow = new BooksWindow(currentUser);
            booksWindow.Show();
            Close();
        }

        private void UsersDataGrid_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            if (UsersDataGrid.SelectedItem != null)
            {
                selectedUser = (Users)UsersDataGrid.SelectedItem;
            }        
        }

        private void BooksDataGrid_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            if (BooksDataGrid.SelectedItem != null)
            {
                selectedBook = (Books)BooksDataGrid.SelectedItem;
            }            
        }

    }
}
