namespace OnlineBookShop.Models
{
    public class DiscountCode
    {
        public int DiscountCodeID { get; set; }
        public string Code { get; set; }
        public decimal DiscountPercent { get; set; }
        public bool IsActive { get; set; }
        public DateTime Expiry { get; set; }
    }
}
