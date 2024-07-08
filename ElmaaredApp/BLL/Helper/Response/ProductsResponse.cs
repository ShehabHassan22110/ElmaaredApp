using ElmaaredApp.DAL.Models;

namespace ElmaaredApp.BLL.Helper.Response
{
    public class ProductsResponse
    {
        public string Code { get; set; }
        public string Message { get; set; }
        public string Status { get; set; }
        public IEnumerable<Product> Data { get; set; }
    }
}
