namespace ElmaaredApp.DAL.Models
{
    public class Trade_fairBranch
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Location { get; set; }
        public string ApplicationUserId { get; set; }
        public ApplicationUser? ApplicationUser { get; set; }
    }
}
