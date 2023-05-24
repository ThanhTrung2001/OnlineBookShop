namespace OnlineBookShop.Models
{
    public class Order
    {
        public int OrderID { get; set; }
        public int UserID { get; set; }
        public int AddressID { get; set; }
        public string Phone { get; set; }
        public DateTime OrderDate { get; set; }
        public decimal TotalAmount { get; set; }
        public string PurchaseType { get; set; }
        public string Status { get; set; }
        public ICollection<OrderItem> OrderItems { get; set; }
    }
}

enum PurchaseType
{
    OnlineBanking,
    PayWhenReceive
}
