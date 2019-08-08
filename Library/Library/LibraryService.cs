using System;
using System.Linq;
using Library.Model;
using Microsoft.EntityFrameworkCore;
using static Library.AuthorService;
using static Library.GenreService;

namespace Library
{
    public class LibraryService
    {
        private static LibraryService _instance;
        private readonly LibrariDbContext _context;
        private readonly GenreService _genreService;
        private readonly AuthorService _authorService;

        public static LibraryService GetInstance(LibrariDbContext dbContext)
        {
            return _instance ?? (_instance = new LibraryService(dbContext));
        }

        private LibraryService(LibrariDbContext context)
        {
            _context = context;
            _genreService = GenreService.GetInstance(context);
            _authorService = AuthorService.GetInstance(context);
        }
        
        public void ShowBooks(bool isTake)
        {
            var books = _context.Set<Book>()
                .Where(x => x.IsTake == isTake)
                .Include(x => x.Author)
                .Include(x => x.Genre)
                .ToList();
            
            books.ForEach(x => Console.WriteLine($"{x.Id}.{x.Name}, {x.Genre.Name}, {x.Author.FirstName} {x.Author.LastName}"));
        }

        public void CreateBook()
        {
            var authors = _authorService.GetAllAuthors();
            Console.WriteLine("Выберите автора из списка, написав его id. В случае, если в списа нет интересующего Вас автора, пожалуйста, ведите: '0' ");
            
            authors.ForEach(x => Console.WriteLine($"{x.Id}.{x.FirstName}, {x.LastName}"));
            
            var authorId = long.Parse(Console.ReadLine());

            var author = authorId == 0 ? _authorService.CreateAuthor() : _authorService.GetAuthor(authorId);

            var genres = _genreService.GetAllGenre();

            Console.WriteLine("Выберите название жанра из списка, написав его id. В случае, если в списке нет нитересующего Вас названия жанра, пожалуйста, введие '0' ");
            
            genres.ForEach(x => Console.WriteLine($"{x.Id}.{x.Name}"));

            var genreId = long.Parse(Console.ReadLine());
            var genre = genreId == 0 ? _genreService.CreateGenre() : _genreService.GetGenre(genreId);
            
            Console.WriteLine("Введите название книги");
            var name = Console.ReadLine();
            var book = new Book(name, genre, author);

            _context.Add(book); 
            _context.SaveChanges();
            
        }

        public void TakeBook()
        {
            Console.WriteLine("Книгу какого жанра предпочитаете взять? Укажите id жанра. Если же Вам похуй, пожалуйста, нажмите 0");
            var genres = _genreService.GetAllGenre();
            genres.ForEach(x => Console.WriteLine($"{x.Id}.{x.Name}"));
            var genreId = long.Parse(Console.ReadLine());
            
            Console.WriteLine("Книгу какого автора предпочитаете взять? Укажите id автора. Если же Вам похуй, пожалуйста, нажмите 0");
            var authors = _authorService.GetAllAuthors();
            authors.ForEach(x => Console.WriteLine($"{x.Id}. {x.FirstName} {x.LastName}"));
            var authorId = long.Parse(Console.ReadLine());

            var queryable = _context.Set<Book>() //тут лежит наш запрос который пока не выполнился так как нет Tolist
                .Where(x => x.IsTake == false);//до этого момента запрос строится пока тут такой запрос select * from Book where IsTake = false

            if (genreId != 0)
                queryable = queryable.Where(x => x.GenreId == genreId); //теперь запрос имеет вид select * from Book where IsTake = false && GenreId = genreI
            if (authorId != 0)
                queryable = queryable.Where(x => x.AuthorId == authorId); //теперь запрос имеет вид select * from Book where IsTake = false && GenreId = genreId && AothorId = authorId

            var books = queryable.ToList();//вот теперь запрос выполнится

            books.ForEach(x => Console.WriteLine($"{x.Id}. {x.Name}"));

            var bookId = long.Parse(Console.ReadLine());

            var book = queryable.First(x => x.Id == bookId);
            book.IsTake = true; 
            _context.SaveChanges();
        }


        public void ReturnBook()
        {
            Console.WriteLine("Введите id книги, которую хотите вернуть");
            
            var books = _context.Set<Book>()
                .Where(x => x.IsTake == true)
                .ToList();
            
            books.ForEach(x => Console.WriteLine($"{x.Id}. {x.Name}"));
            
            var bookId = long.Parse(Console.ReadLine());

            var book = books.First(x => x.Id == bookId);
            book.IsTake = false;
            _context.SaveChanges();

        }

        public void RemoveBook() 
        {
            Console.WriteLine("Выберите книгу, которую хотите удалить, указав id");
            var books = _context.Set<Book>()
                .Where(x => x.IsTake == false)
                .ToList();
            
            books.ForEach(x => Console.WriteLine($"{x.Id}. {x.Name}"));
            
            var bookId = long.Parse(Console.ReadLine());
            var book = books.First(x => x.Id == bookId);
            _context.Remove(book);
            _context.SaveChanges();
        }
    }
}