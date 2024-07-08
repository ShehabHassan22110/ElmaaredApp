using ElmaaredApp.DAL.Models;

namespace ElmaaredApp.BLL.Helper.Response
{
    public class CarOutsideLookResponse
    {
        public string Code { get; set; }
        public string Message { get; set; }
        public string Status { get; set; }
        public IEnumerable<CarOutsideLook> Data { get; set; }
    }
}
