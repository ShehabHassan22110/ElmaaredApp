
namespace ElmaaredApp.BLL.Interfaces
{
    public interface IEmailHtmlTemplateService
    {
        public string GetContactUsTemplate(string name);
        public string GetResetPasswordTemplate(string name, string url);





    }
}
