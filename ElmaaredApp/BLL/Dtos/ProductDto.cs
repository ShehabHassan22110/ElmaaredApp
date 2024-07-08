using ElmaaredApp.DAL.Models;

namespace ElmaaredApp.BLL.Dtos
{
    public class ProductDto
    {
        public int Id { get; set; }
        public string Kind { get; set; }
        public int BrandId { get; set; }
        public int ModelId { get; set; }
        public string ManufacturingYear { get; set; }
        public string FuelType { get; set; }
        public string Fender { get; set; }
        public int CarOutsideLookId { get; set; }
        public string Capacity { get; set; }
        public double Kilometer { get; set; }
        public decimal Price { get; set; }
        public string Color { get; set; }
        public string District { get; set; }
        public string DistrictDetails { get; set; }
        public ContactDetails ContactDetails { get; set; }
        public List<IFormFile> Images { get; set; }
    }
}
