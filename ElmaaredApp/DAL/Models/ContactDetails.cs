namespace ElmaaredApp.DAL.Models
{
    public class ContactDetails
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string PhoneNumber { get; set; }
        public string WhatsappNumber { get; set; }
        public bool ContactByWhatsapp { get; set; }
        public bool ContactBySms { get; set; }
        public bool ContactByCall { get; set; }
        public int ProductId { get; set; }
        public Product Product { get; set; }
    }
}
