namespace OnlineBookShop.Models
{
    public class User
    {
        public int UserID { get; set; }
        public string UserName { get; set; }
        public string Email { get; set; }
        public string Password { get; set; }
        public string FullName { get; set; }
        public string CitizenID { get; set; }
        public string Phone { get; set; }
        public string Address { get; set; }
        public int AddressDefaultID { get; set; }
        public int UserType { get; set; }
        public ICollection<UserAddress> Addresses { get; set; }
        public ICollection<Cart> Carts { get; set; }
        public ICollection<Order> Orders { get; set; }
    }
}
