using GUI_SQL.Model;
using LibraryApp.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LibraryApp.Repository
{
    internal class LoansRepository
    {
        private LibraryContext library_context;

        public LoansRepository(LibraryContext library)
        {
            library_context = library;
        }

        public List<Loans> GetLoans()
        {
            return library_context.Loans.ToList();
        }

        public Loans GetLoansByID(int id)
        {
            return library_context.Loans.Find(id);
        }

        public void InsertLoans(Loans Loan)
        {
            library_context.Loans.Add(Loan);
        }

        public void DeleteLoans(Loans loan)
        {
            library_context.Loans.Remove(loan);
        }

        public void UpdateLoans(Loans Loan)
        {
            library_context.Loans.Find(Loan.kolcsonzesid).tagid = Loan.tagid;
            library_context.Loans.Find(Loan.kolcsonzesid).konyvid = Loan.konyvid;
            library_context.Loans.Find(Loan.kolcsonzesid).kolcsonzesdatuma = Loan.kolcsonzesdatuma;
        }

        public void Save()
        {
            library_context.SaveChanges();
        }

        public void Dispose()
        {
            library_context.Dispose();
            GC.SuppressFinalize(this);
        }
    }
}
