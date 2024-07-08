using ElmaaredApp.DAL.Models;

namespace ElmaaredApp.BLL.Interfaces
{
    public interface ICarOutsideLookService
    {
        Task<CarOutsideLook> Create(CarOutsideLook CarOutsideLook);
        void Update(CarOutsideLook CarOutsideLook);
        void Delete(CarOutsideLook CarOutsideLook);
        Task<CarOutsideLook> GetById(int id);
        Task<IEnumerable<CarOutsideLook>> Get();
    }
}
