namespace stazServices.RestModels
{
    public class UpdateBookRequest
    {
        public string Title { get; set; }
        public string Description { get; set; }
        public DateTime Release_Date { get; set; }


        public Guid AuthorId { get; set; }
    }
}
