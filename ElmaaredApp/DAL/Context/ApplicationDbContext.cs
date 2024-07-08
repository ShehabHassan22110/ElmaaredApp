using ElmaaredApp.DAL.Models;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using static System.Net.Mime.MediaTypeNames;

namespace ElmaaredApp.DAL.Context
{
        public class ApplicationDbContext : IdentityDbContext<ApplicationUser>
        {
            public ApplicationDbContext(DbContextOptions options) : base(options)
            {

            }
        public DbSet<Product> Product { get; set; }
        public DbSet<CarOutsideLook> CarOutsideLook { get; set; }
        public DbSet<ContactDetails> ContactDetails { get; set; }
        public DbSet<ProductImage> Images { get; set; }
        public DbSet<Brand> Brands { get; set; }
        public DbSet<Model> Models { get; set; }


    }
    
}
