using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using GUI_SQL.Model;
using LibraryApp.Models;
using Microsoft.EntityFrameworkCore;

namespace LibraryApp.Repository
{
    class UsersRepository
    {
        private LibraryContext library_context;

        public UsersRepository(LibraryContext library)
        {
            library_context = library;
        }

        public List<Users> GetUsers()
        {
            return library_context.Users.ToList();
        }

        public Users GetUsersByID(int id)
        {
            return library_context.Users.Find(id);
        }

        public Users GetByEmail(string email)
        {
            return library_context.Users.Where(u => u.email == email).FirstOrDefault();
        }

        public void InsertUsers(Users user)
        {
            library_context.Users.Add(user);
        }

        public void DeleteUsers(int id)
        {
            Users user = library_context.Users.Find(id);
            library_context.Users.Remove(user);
        }

        public void UpdateUsers(Users user)
        {
            library_context.Users.Find(user.tagid).nev = user.nev;
            library_context.Users.Find(user.tagid).permission = user.permission;
            library_context.Users.Find(user.tagid).email = user.email;
            library_context.Users.Find(user.tagid).password = user.password;
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
