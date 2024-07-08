using ElmaaredApp.BLL.Helper;

namespace ElmaaredApp.BLL.Interfaces
{
    public interface IMailService
    {

        Task SendEmailAsync(MailRequest mailRequest, CancellationToken cancellationToken = default);
    }
}
