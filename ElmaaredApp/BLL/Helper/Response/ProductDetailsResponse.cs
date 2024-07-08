using ElmaaredApp.DAL.Models;

namespace ElmaaredApp.BLL.Helper.Response
{
    public class ProductDetailsResponse
    {
        public string Code { get; set; }
        public string Message { get; set; }
        public string Status { get; set; }
        public Product Data { get; set; }
    }
}
