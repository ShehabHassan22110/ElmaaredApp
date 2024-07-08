namespace ElmaaredApp.DAL.Models
{
    public class Brand
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string? PhotoName { get; set; }
        public List<Model>? Models { get; set; } 

    }
}
