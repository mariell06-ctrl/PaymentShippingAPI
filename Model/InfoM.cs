namespace PaymentShippingAPI.Model
{
    public class InfoM
    {
        public string fName { get; set; }
        public string lName { get; set; }
    }

    public class shipinfo
    {
        public string address { get; set; }
        public string contactnum { get; set; }
    }

    public class payinfo
    {
        public string method { get; set; }
        public string cardNumber { get; set; }
        public string phoneNumber { get; set; }
        public string cardHolder { get; set; }
        public string email { get; set; }
    }
}