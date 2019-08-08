namespace Library.Model
{
    public class Book
    {
        protected Book()
        {
        }

        public Book(string name, Genre genre, Author author)
        {
            Name = name;
            Genre = genre;
            Author = author;
        }

        public long Id { get; set; } 
        public string Name { get; set; }
        
        public virtual Author Author { get; set; }

        public long AuthorId { get; set; }

        public virtual Genre Genre { get; set; }

        public long GenreId { get; set; }
        
        public bool IsTake { get; set; } 
    }
}