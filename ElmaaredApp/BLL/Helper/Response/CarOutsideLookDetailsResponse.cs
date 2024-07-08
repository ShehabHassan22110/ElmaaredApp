using ElmaaredApp.DAL.Models;

namespace ElmaaredApp.BLL.Helper.Response
{
    public class CarOutsideLookDetailsResponse
    {
        public string Code { get; set; }
        public string Message { get; set; }
        public string Status { get; set; }
        public CarOutsideLook Data { get; set; }
    }
}
