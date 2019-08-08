using System;
using System.Collections.Generic;
using System.Linq;
using Library.Model;
using Microsoft.EntityFrameworkCore;

namespace Library
{
    public class AuthorService
    {
        private static AuthorService _instance;
        private LibrariDbContext _context;

        public static AuthorService GetInstance(LibrariDbContext context) => _instance ?? (_instance = new AuthorService(context));

        private AuthorService(LibrariDbContext context)
        {
            _context = context;
        }

        public Author CreateAuthor()
        {
            Console.WriteLine("Введите имя автора");
            var firstName = Console.ReadLine();
            Console.WriteLine("Введите фамилию автора");
            var lastName = Console.ReadLine();
            return new Author(firstName, lastName);
        }

        public List<Author> GetAllAuthors() => _context.Set<Author>().ToList();

        public Author GetAuthor(long id) => _context.Set<Author>().First(author => author.Id == id);
        
    }
}





