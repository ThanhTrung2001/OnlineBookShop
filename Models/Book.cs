namespace OnlineBookShop.Models
{
    public class Book
    {
        public int BookID { get; set; }
        public string Title { get; set; }
        public string ImageLink { get; set; }
        public int AuthorID { get; set; }
        public int BookTypeID { get; set; }
        public decimal Price { get; set; }
        public string Description { get; set; }
        public int Stock { get; set; }
        public bool IsSale { get; set; }
        public decimal SalePercent { get; set; }
    }
}
