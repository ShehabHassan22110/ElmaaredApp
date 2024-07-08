using Microsoft.AspNetCore.Identity;

namespace ElmaaredApp.DAL.Models
{
    public class ApplicationUser: IdentityUser
    {
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string AccountKind { get; set; }
        public List<Trade_fairBranch>? Trade_fairBranch { get; set; }
    }
}
