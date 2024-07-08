namespace ElmaaredApp.BLL.Helper.Response
{
    public class UserManagerResponseError
    {
        public string Message { get; set; }
        public bool IsSuccess { get; set; }
        public IEnumerable<string> Errors { get; set; }


    }
}
