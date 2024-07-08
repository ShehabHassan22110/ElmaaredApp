using ElmaaredApp.BLL.Interfaces;
using ElmaaredApp.DAL.Context;
using ElmaaredApp.DAL.Models;
using Microsoft.EntityFrameworkCore;

namespace ElmaaredApp.BLL.Services
{
    public class ModelService:IModelService
    {
        private readonly ApplicationDbContext context;
        public ModelService(ApplicationDbContext context)
        {
            this.context = context;
        }

        public async Task<Model> Create(Model Model)
        {
            await context.Models.AddAsync(Model);
            context.SaveChanges();
            return Model;
        }



        public void Delete(Model Model)
        {
            context.Entry(Model).State = EntityState.Deleted;

            context.SaveChanges();

        }



        public async Task<IEnumerable<Model>> Get()
        {
            var allCategories = await context.Models.ToListAsync();
            return allCategories;
        }

        public async Task<Model> GetById(int id)
        {
            return await context.Models.FirstOrDefaultAsync(a => a.Id == id);
        }



        public void Update(Model Model)
        {
            context.Entry(Model).State = EntityState.Modified;

            context.SaveChanges();

        }
    }
}
