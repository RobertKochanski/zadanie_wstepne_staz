namespace stazServices.ViewModels
{
    public class BookViewModel
    {
        public Guid Id { get; set; }
        public string Title { get; set; }
        public string Description { get; set; }
        public DateTime Release_Date { get; set; }

        public Guid AuthorId { get; set; }
    }
}
