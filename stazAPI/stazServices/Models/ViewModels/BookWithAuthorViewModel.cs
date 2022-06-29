namespace stazServices.ViewModels
{
    public class BookWithAuthorViewModel
    {
        public Guid Id { get; set; }
        public string Title { get; set; }
        public string Description { get; set; }
        public DateTime Release_Date { get; set; }

        public AuthorViewModel AuthorViewModel { get; set; }
    }
}
