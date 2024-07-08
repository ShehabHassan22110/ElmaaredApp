using ElmaaredApp.DAL.Models;

namespace ElmaaredApp.BLL.Dtos
{
    public class CarOutsideLookDto : CarOutsideLook
    {
        public IFormFile Photo { get; set; }
    }
}
