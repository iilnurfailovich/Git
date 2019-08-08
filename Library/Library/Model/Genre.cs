namespace Library.Model
{
    public class Genre
    {
        protected Genre()
        {
        }
        
        public Genre(string name)
        {
            Name = name;
        }

        public long Id { get; set; } 
        public string Name { get; set; }
    }
}