namespace stazDAL.Entities
{
    public class Author
    {
        public Guid Id { get; set; }
        public string FirstName { get; set; }
        public string SurName { get; set; }

        public ICollection<Book> Books { get; set; }
    }
}
