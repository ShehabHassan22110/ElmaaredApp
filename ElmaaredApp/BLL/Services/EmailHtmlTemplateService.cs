
using ElmaaredApp.BLL.Interfaces;
using ElmaaredApp.DAL.Models;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.WebUtilities;
using MimeKit;

using System.Globalization;
using System.Text;

namespace ElmaaredApp.BLL.Services
{
    public class EmailHtmlTemplateService : IEmailHtmlTemplateService
    {
        #region Ctor
      
        private readonly IConfiguration _configuration;
        private readonly IWebHostEnvironment _environment;
        private readonly UserManager<ApplicationUser> userManager;

        public EmailHtmlTemplateService(IConfiguration configuration, IWebHostEnvironment environment ,UserManager<ApplicationUser> userManager)
        {
            _configuration = configuration;
            _environment = environment;
            this.userManager = userManager;
        }


        #endregion



        #region Contact Us Template
        public string GetContactUsTemplate(string name)
        {

            var pathToFile = $"{_environment.WebRootPath}\\Templates\\ContactUs.html";
            var builder = new BodyBuilder();
            using (StreamReader SourceReader = System.IO.File.OpenText(pathToFile))
            {

                builder.HtmlBody = SourceReader.ReadToEnd();

            }
            string messageBody = string.Format(builder.HtmlBody, name);
            return messageBody;

        }
        #endregion

        #region Get ResetPassword Us Template
        public string GetResetPasswordTemplate(string name, string url)
        {

            var pathToFile = $"{_environment.WebRootPath}\\Templates\\ResetPasswordEmailTemplate.html";
            var builder = new BodyBuilder();
            using (StreamReader SourceReader = System.IO.File.OpenText(pathToFile))
            {

                builder.HtmlBody = SourceReader.ReadToEnd();

            }
            string messageBody = string.Format(builder.HtmlBody, name, url);
            return messageBody;

        }
        #endregion






    }

}
