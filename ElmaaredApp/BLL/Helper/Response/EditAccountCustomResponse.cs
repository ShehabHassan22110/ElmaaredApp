using ElmaaredApp.BLL.Helper.Response;

namespace ElmaaredApp.BLL.Helper.Response
{
    public class EditAccountCustomResponse:CustomResponse
    {
        public bool IsSuccess { get; set; }
        public string Token { get; set; }
    }
}
