namespace Library.Model
{
    public class Author
    {
        protected Author()
        {
        }

        public Author(string firstName, string lastName)
        { 
            FirstName = firstName;
            LastName = lastName;
        }

        public long Id { get; set; }

        public string FirstName { get; set; }

        public string LastName { get; set; }
    }
}