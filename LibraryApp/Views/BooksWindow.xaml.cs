using LibraryApp.Models;
using LibraryApp.Repository;
using Microsoft.VisualBasic;
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
    public partial class BooksWindow : Window
    {
        private BooksRepository booksRepository;
        private LoansRepository loansRepository;
        private Users currentUser;
        private Books selectedBook;

        public BooksWindow(Users user)
        {
            InitializeComponent();
            booksRepository = new BooksRepository(new GUI_SQL.Model.LibraryContext());
            loansRepository = new LoansRepository(new GUI_SQL.Model.LibraryContext());
            LoadBooksGrid();
            currentUser = user;
            RentButton.IsEnabled = false;

            if (currentUser.permission > 0)
            {
                AdminPanelButton.Visibility = Visibility.Visible;
            }
        }

        private void LoadBooksGrid()
        {
            Cursor = Cursors.Wait;
            var allBooks = booksRepository.GetBooks();
            var availableBooks = allBooks.Where(book => !loansRepository.GetLoans().Any(loan => loan.konyvid == book.konyvid)).ToList();
            BooksDataGrid.DataContext = availableBooks;
            Cursor = Cursors.Arrow;
        }

        private void BooksDataGrid_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            if (BooksDataGrid.SelectedItem != null)
            {
                RentButton.IsEnabled = true;
                selectedBook = (Books)BooksDataGrid.SelectedItem;
            }
        }

        private void RentButton_Click(object sender, RoutedEventArgs e)
        {
            if (selectedBook != null)
            {
                loansRepository.InsertLoans(new Loans
                {
                    tagid = currentUser.tagid,
                    konyvid = selectedBook.konyvid,
                    kolcsonzesdatuma = DateTime.Now.ToString("yyyy-MM-dd"),
                });

                loansRepository.Save();
                booksRepository.Save();
                LoadBooksGrid();

                selectedBook = null;
                RentButton.IsEnabled = false;
            }
            else
            {
                MessageBox.Show("Nincsen könyv kiválasztva!");
            }
        }
        private void LoanedBooksButton_Click(object sender, RoutedEventArgs e)
        {
            LoanedBooksWindow loanedBooksWindow = new LoanedBooksWindow(currentUser);
            loanedBooksWindow.Show();
            this.Close();
        }

        private void ExitButton_Click(object sender, RoutedEventArgs e)
        {
            Environment.Exit(0);
        }

        private void AdminPanelButton_Click(object sender, RoutedEventArgs e)
        {
            AdminWindow admninWindow = new AdminWindow(currentUser);
            admninWindow.Show();
            this.Close();
        }
    }
}

