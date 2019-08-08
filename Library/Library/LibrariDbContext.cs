using System.Collections.Generic;
using Library.Model;
using Microsoft.EntityFrameworkCore;

namespace Library
{
    public class LibrariDbContext : DbContext

    {
        public DbSet<Book> Book { get; set; }
        public DbSet<Author> Author { get; set; }
        public DbSet<Genre> Genre { get; set; }
        
        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlServer("Server=localhost\\SQLEXPRESS;Database=Library;Trusted_Connection=True;");
        }

       
    }
}