using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LibraryApp.Models
{
    [Table("books")]
    public class Books
    {
        [Key]
        [Column("konyvid")]
        public int konyvid { get; set; }

        [Column("cim")]
        public string cim { get; set; }

        [Column("szerzo")]
        public string szerzo { get; set; }

        [Column("kiadaseve")]
        public int kiadaseve { get; set; }

        [Column("isbn")]
        public string isbn { get; set; }
    }

    [Table("users")]
    public class Users
    {
        [Key]
        [Column("tagid")]
        public int tagid { get; set; }

        [Column("nev")]
        public string nev { get; set; }

        [Column("permission")]
        public int permission { get; set; }

        [Column("email")]
        public string email { get; set; }

        [Column("password")]
        public string password { get; set; }
    }

    [Table("loans")]
    public class Loans
    {
        [Key]
        [Column("kolcsonzesid")]
        public int kolcsonzesid { get; set; }

        [Column("tagid")]
        public int tagid { get; set; }

        [Column("konyvid")]
        public int konyvid { get; set; }

        [Column("kolcsonzesdatuma")]
        public string kolcsonzesdatuma { get; set; }
    }
}
