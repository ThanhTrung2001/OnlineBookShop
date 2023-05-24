namespace OnlineBookShop.Models
{
    public class ImportItem
    {
        public int ImportItemID { get; set; }
        public int ImportBillID { get; set; }
        public int BookID { get; set; }
        public int Quantity { get; set; }
        public decimal Price { get; set; }
    }
}
