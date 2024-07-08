using static System.Net.Mime.MediaTypeNames;

namespace ElmaaredApp.DAL.Models
{
    public class Product
    {
        public int Id { get; set; }
        public string Kind { get; set; }
        public int BrandId { get; set; }
        public Brand? Brand { get; set; }
        public int ModelId { get; set; }
        public Model? Model { get; set; }
        public string ManufacturingYear { get; set; }
        public string FuelType { get; set; }
        public string Fender { get; set; }
        public int CarOutsideLookId { get; set; } // Foreign key property
        public CarOutsideLook? CarOutsideLook { get; set; } // Navigation property
        public string Capacity { get; set; }
        public double Kilometer { get; set; }
        public decimal Price { get; set; }
        public string Color { get; set; }
        public string District { get; set; }
        public string DistrictDetails { get; set; }
        public ContactDetails ContactDetails { get; set; }
        public List<ProductImage> Images { get; set; } = new List<ProductImage>();




    }
}
