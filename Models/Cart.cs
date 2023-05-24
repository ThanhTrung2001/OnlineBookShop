namespace OnlineBookShop.Models
{
    public class Cart
    {
        public int CartID { get; set; }
        public int UserID { get; set; }
        public decimal Cost { get; set; }
        public int? DiscountCodeID { get; set; }
        public decimal TotalAmount { get; set; }
        public ICollection<CartItem> CartItems { get; set; }
    }
}
