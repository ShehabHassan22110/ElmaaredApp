using ElmaaredApp.DAL.Models;

namespace ElmaaredApp.BLL.Helper.Response
{
    public class ModelsResponse
    {
        public string Code { get; set; }
        public string Message { get; set; }
        public string Status { get; set; }
        public IEnumerable<Model> Data { get; set; }
    }
}
