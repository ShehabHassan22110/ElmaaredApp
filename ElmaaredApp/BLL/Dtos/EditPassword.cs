using System.ComponentModel.DataAnnotations;

namespace ElmaaredApp.BLL.Dtos
{
	public class EditPassword
	{
        public string Email { get; set; }
        [Required]
        public string OldPaassword { get; set; }
        [Required]

        public string NewPassword { get; set; }
        [Required]

        public string ConfirmNewPassword { get; set; }
    }
}
