namespace OnlineBookShop.Models
{
    public class ImportBill
    {
        public int ImportBillID { get; set; }
        public int AdminID { get; set; }
        public DateTime BillDate { get; set; }
        public ICollection<ImportItem> ImportedBooks { get; set; }
        public decimal Cost { get; set; }
        public int ReducePercent { get; set; }
        public decimal Total { get; set; }
    }
}
