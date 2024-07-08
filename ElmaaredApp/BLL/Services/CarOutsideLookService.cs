using ElmaaredApp.BLL.Interfaces;
using ElmaaredApp.DAL.Context;
using ElmaaredApp.DAL.Models;
using Microsoft.EntityFrameworkCore;

namespace ElmaaredApp.BLL.Services
{
    public class CarOutsideLookService:ICarOutsideLookService
    {
        private readonly ApplicationDbContext context;
        public CarOutsideLookService(ApplicationDbContext context)
        {
            this.context = context;
        }

        public async Task<CarOutsideLook> Create(CarOutsideLook CarOutsideLook)
        {
            await context.CarOutsideLook.AddAsync(CarOutsideLook);
            context.SaveChanges();
            return CarOutsideLook;
        }



        public void Delete(CarOutsideLook CarOutsideLook)
        {
            context.Entry(CarOutsideLook).State = EntityState.Deleted;

            context.SaveChanges();

        }



        public async Task<IEnumerable<CarOutsideLook>> Get()
        {
            var allCategories = await context.CarOutsideLook.ToListAsync();
            return allCategories;
        }

        public async Task<CarOutsideLook> GetById(int id)
        {
            return await context.CarOutsideLook.FirstOrDefaultAsync(a => a.Id == id);
        }



        public void Update(CarOutsideLook CarOutsideLook)
        {
            context.Entry(CarOutsideLook).State = EntityState.Modified;

            context.SaveChanges();

        }
    }
}
