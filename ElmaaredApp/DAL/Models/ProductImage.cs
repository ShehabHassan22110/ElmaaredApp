namespace ElmaaredApp.DAL.Models
{
    public class ProductImage
    {
        public int Id { get; set; }
        public string PhotoName { get; set; }
        public int ProducttId { get; set; }
        public Product? Product { get; set; }
    }
}
