
using ElmaaredApp.BLL.Helper.Response;
using ElmaaredApp.BLL.Dtos;
using ElmaaredApp.DAL.Models;


namespace ElmaaredApp.BLL.Interfaces
{
	public interface IUserService

	{

		 Task<UserManagerResponse> RegisterUserAsync(RegisterModel model);
		Task<UserManagerResponse> LoginUserAsync(LoginModel model);
		Task<UserManagerResponse> ForgetPasswordAsync(string Email);
        Task<UserManagerResponse> ConfirmEmailAsync(string userId, string token);

        Task<UserManagerResponse> ResetPasswordAsync(ResetPasswordModel model);

		Task<UserModel> GetAccount(string id);
		Task<EditAccountCustomResponse> EditProfile(EditProfileModel model);
		Task<UserManagerResponse> EditPassword(EditPassword model);
		Task<ApplicationUser> GetUserToEdit(string name);
	}
}
