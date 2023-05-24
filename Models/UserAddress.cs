namespace OnlineBookShop.Models
{
    public class UserAddress
    {

        public int UserAddressID { get; set; }
        public int UserID { get; set; }
        public string Address { get; set; }
        public string City { get; set; }
        public string PostalCode { get; set; }
        public string Country { get; set; }
    }
}
