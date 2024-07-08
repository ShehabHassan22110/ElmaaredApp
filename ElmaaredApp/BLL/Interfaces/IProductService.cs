using ElmaaredApp.DAL.Models;

namespace ElmaaredApp.BLL.Interfaces
{
    public interface IProductService
    {
        Task<Product> Create(Product Product);
        void Update(Product Product);
        void Delete(Product Product);
        Task<Product> GetById(int id);
        Task<IEnumerable<Product>> Get();
        Task<IEnumerable<Product>> GetByBrand(int brandId);
        Task<IEnumerable<Product>> FilterProducts(int? modelId, int? brandId, int? carOutsideLookId, decimal? priceFrom, decimal? priceTo, string? district, string? manufacturingYearFrom, string? manufacturingYearTo);

    }
}
