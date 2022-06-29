namespace stazServices.ViewModels
{
    public class AuthorWithBooksViewModel
    {
        public Guid Id { get; set; }
        public string FirstName { get; set; }
        public string SurName { get; set; }

        public ICollection<BookViewModel> BookViewModel { get; set; }
    }
}
