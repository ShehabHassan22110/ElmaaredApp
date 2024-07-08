using ElmaaredApp.BLL.Interfaces;
using ElmaaredApp.DAL.Context;
using ElmaaredApp.DAL.Models;
using Microsoft.EntityFrameworkCore;

namespace ElmaaredApp.BLL.Services
{
    public class ProductService:IProductService
    {
        private readonly ApplicationDbContext context;
        public ProductService(ApplicationDbContext context)
        {
            this.context = context;
        }

        public async Task<Product> Create(Product Product)
        {
            await context.Product.AddAsync(Product);
            context.SaveChanges();
            return Product;
        }



        public void Delete(Product Product)
        {
            context.Entry(Product).State = EntityState.Deleted;

            context.SaveChanges();

        }



        public async Task<IEnumerable<Product>> Get()
        {
            var products = await context.Product.Include(a => a.ContactDetails)
            .Include(a => a.Images)
            .Include(a => a.Brand)
            .Include(a => a.Model).ToListAsync();
            return products;
        }

        public async Task<IEnumerable<Product>> GetByBrand(int brandId)
        {
                    var products = await context.Product.Include(a => a.ContactDetails)
                       .Include(a => a.Images)
                       .Include(a => a.Brand)
                       .Include(a => a.Model).Where(z=>z.BrandId == brandId).ToListAsync();
            return products;
        }

        public async Task<Product> GetById(int id)
        {
            var product = await context.Product.Include(a => a.ContactDetails)
            .Include(a => a.Images)
            .Include(a => a.Brand)
            .Include(a => a.Model).FirstOrDefaultAsync(a => a.Id == id);
            return product;
        }



        public void Update(Product Product)
        {
            context.Entry(Product).State = EntityState.Modified;

            context.SaveChanges();

        }

        public async Task<IEnumerable<Product>> FilterProducts(int? modelId, int? brandId, int? carOutsideLookId, decimal? priceFrom, decimal? priceTo, string? district, string? manufacturingYearFrom, string? manufacturingYearTo)
        {
            var query = context.Product.AsQueryable();

            if (modelId.HasValue)
            {
                query = query.Where(p => p.ModelId == modelId.Value);
            }

            if (brandId.HasValue)
            {
                query = query.Where(p => p.BrandId == brandId.Value);
            }           

            if (carOutsideLookId.HasValue)
            {
                query = query.Where(p => p.CarOutsideLookId == carOutsideLookId.Value);
            }

            if (priceFrom.HasValue)
            {
                query = query.Where(p => p.Price >= priceFrom.Value);
            }

            if (priceTo.HasValue)
            {
                query = query.Where(p => p.Price <= priceTo.Value);
            }

            if (!string.IsNullOrEmpty(district))
            {
                query = query.Where(p => p.District == district);
            }

            if (!string.IsNullOrEmpty(manufacturingYearFrom))
            {
                query = query.Where(p => string.Compare(p.ManufacturingYear, manufacturingYearFrom) >= 0);
            }

            if (!string.IsNullOrEmpty(manufacturingYearTo))
            {
                query = query.Where(p => string.Compare(p.ManufacturingYear, manufacturingYearTo) <= 0);
            }

            return await query.Include(p => p.ContactDetails)
                              .Include(p => p.Images)
                              .Include(p => p.Brand)
                              .Include(p => p.Model)
                              .ToListAsync();
        }

    }
}
