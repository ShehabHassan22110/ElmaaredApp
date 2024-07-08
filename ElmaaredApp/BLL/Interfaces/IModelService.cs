using ElmaaredApp.DAL.Models;

namespace ElmaaredApp.BLL.Interfaces
{
    public interface IModelService
    {
        Task<Model> Create(Model Model);
        void Update(Model Model);
        void Delete(Model Model);
        Task<Model> GetById(int id);
        Task<IEnumerable<Model>> Get();
    }
}
