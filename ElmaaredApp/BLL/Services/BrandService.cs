using ElmaaredApp.BLL.Interfaces;
using ElmaaredApp.DAL.Context;
using ElmaaredApp.DAL.Models;
using Microsoft.EntityFrameworkCore;

namespace ElmaaredApp.BLL.Services
{
    public class BrandService:IBrandService
    {
        private readonly ApplicationDbContext context;
        public BrandService(ApplicationDbContext context)
        {
            this.context = context;
        }

        public async Task<Brand> Create(Brand Brand)
        {
            await context.Brands.AddAsync(Brand);
            context.SaveChanges();
            return Brand;
        }



        public void Delete(Brand Brand)
        {
            context.Entry(Brand).State = EntityState.Deleted;

            context.SaveChanges();

        }



        public async Task<IEnumerable<Brand>> Get()
        {
            var allCategories = await context.Brands.Include(a => a.Models).ToListAsync();
            return allCategories;
        }

        public async Task<Brand> GetById(int id)
        {
            return await context.Brands.Include(a => a.Models).FirstOrDefaultAsync(a => a.Id == id);
        }



        public void Update(Brand Brand)
        {
            context.Entry(Brand).State = EntityState.Modified;

            context.SaveChanges();

        }
    }
}
