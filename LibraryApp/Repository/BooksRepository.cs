using GUI_SQL.Model;
using LibraryApp.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LibraryApp.Repository
{
    internal class BooksRepository
    {
        private LibraryContext library_context;

        public BooksRepository(LibraryContext library)
        {
            library_context = library;
        }

        public List<Books> GetBooks()
        {
            return library_context.Books.ToList();
        }

        public Books GetBooksByID(int id)
        {
            return library_context.Books.Find(id);
        }

        public void InsertBooks(Books Book)
        {
            library_context.Books.Add(Book);
        }

        public void DeleteBooks(int id)
        {
            Books Book = library_context.Books.Find(id);
            library_context.Books.Remove(Book);
        }

        public void UpdateBooks(Books book)
        {
            library_context.Books.Find(book.konyvid).cim = book.cim;
            library_context.Books.Find(book.konyvid).szerzo = book.szerzo;
            library_context.Books.Find(book.konyvid).kiadaseve = book.kiadaseve;
            library_context.Books.Find(book.konyvid).isbn = book.isbn;
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
