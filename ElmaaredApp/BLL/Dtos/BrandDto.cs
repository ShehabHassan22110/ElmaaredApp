using ElmaaredApp.DAL.Models;

namespace ElmaaredApp.BLL.Dtos
{
    public class BrandDto:Brand
    {
        public IFormFile Photo { get; set; }
    }
}
