using ElmaaredApp.DAL.Models;

namespace ElmaaredApp.BLL.Interfaces
{
    public interface IBrandService
    {
        Task<Brand> Create(Brand Brand);
        void Update(Brand Brand);
        void Delete(Brand Brand);
        Task<Brand> GetById(int id);
        Task<IEnumerable<Brand>> Get();
    }
}
