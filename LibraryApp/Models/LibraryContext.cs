using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Logging;
using Org.BouncyCastle.Utilities;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Controls;
using System.Windows.Resources;
using static Microsoft.EntityFrameworkCore.DbLoggerCategory.Database;
using LibraryApp.Models;

namespace GUI_SQL.Model
{
    internal class LibraryContext : DbContext
    {
        public string connection = null;
        public LibraryContext()
        {
            connection = ConfigurationManager.AppSettings.Get("DBurl");
        }

        public DbSet<Books> Books { get; set; }
        public DbSet<Users> Users { get; set; }
        public DbSet<Loans> Loans { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseMySQL(connection);
        }


    }
}

