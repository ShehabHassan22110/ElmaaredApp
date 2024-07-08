using System.ComponentModel.DataAnnotations;

namespace ElmaaredApp.BLL.Dtos
{
    public class ForgetPasswordModel
    {
        [EmailAddress(ErrorMessage = "Invalid Mail")]
        [Required(ErrorMessage = "This Field Required")]
        public string Email { get; set; }
    }
}
