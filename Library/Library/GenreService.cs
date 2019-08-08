using System;
using System.Collections.Generic;
using System.Linq;
using Library.Model;

namespace Library
{
    public class GenreService
    {
        private static GenreService _instance;

        private readonly LibrariDbContext _context;
        
        public static GenreService GetInstance(LibrariDbContext dbContext)
        {
            return _instance = new GenreService(dbContext);
        }

        private GenreService(LibrariDbContext context)
        {
            _context = context;
        }
        
        public Genre CreateGenre()
        {
            Console.WriteLine("Введите название жанра");
            var genreName = Console.ReadLine();
            return new Genre(genreName);
        }

        public List<Genre> GetAllGenre() => _context.Set<Genre>().ToList();
        
        public Genre GetGenre(long id) => _context.Set<Genre>().FirstOrDefault(x => x.Id == id);
    }
}