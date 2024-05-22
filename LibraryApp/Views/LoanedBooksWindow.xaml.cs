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
    /// <summary>
    /// Interaction logic for LoanedBooksWindow.xaml
    /// </summary>
    public partial class LoanedBooksWindow : Window
    {
        private LoansRepository loansRepository;
        private BooksRepository booksRepository;
        private Users currentUser;
        private List<Loans> loanedBooks;
        private Loans selectedLoan;

        public LoanedBooksWindow(Users user)
        {
            InitializeComponent();
            booksRepository = new BooksRepository(new GUI_SQL.Model.LibraryContext());
            loansRepository = new LoansRepository(new GUI_SQL.Model.LibraryContext());
            currentUser = user;
            LoadLoanedBooks();
            LoanAbondButton.IsEnabled = false;

        }

        private void LoadLoanedBooks()
        {
            Cursor = Cursors.Wait;
            loanedBooks = loansRepository.GetLoans().Where(loan => loan.tagid == currentUser.tagid).ToList();
            LoanedBooksDataGrid.DataContext = loanedBooks;
            Cursor = Cursors.Arrow;
        }

        private void ButtonExit_Click(object sender, RoutedEventArgs e)
        {
            Environment.Exit(0);
        }

        private void ButtonBack_Click(object sender, RoutedEventArgs e)
        {
            BooksWindow booksWindow = new BooksWindow(currentUser);
            booksWindow.Show();
            Close();
        }

        private void LoanedBooksDataGrid_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            if (LoanedBooksDataGrid.SelectedItem != null)
            {
                LoanAbondButton.IsEnabled = true;
                selectedLoan = (Loans)LoanedBooksDataGrid.SelectedItem;
            }
        }

        private void LoanAbondButton_Click(object sender, RoutedEventArgs e)
        {
            if (selectedLoan != null)
            {
                if (MessageBox.Show("Biztosan lemondja a kölcsönzést?", "Kölcsönzés lemondása", MessageBoxButton.YesNo) == MessageBoxResult.Yes)
                {
                    loansRepository.DeleteLoans(selectedLoan);
                    loansRepository.Save();

                    loanedBooks.Remove(selectedLoan);
                    LoadLoanedBooks();
                }
            }
            else
            {
                MessageBox.Show("Válassza ki a lemondani kívánt kölcsönzést!");
            }
        }


    }
}
