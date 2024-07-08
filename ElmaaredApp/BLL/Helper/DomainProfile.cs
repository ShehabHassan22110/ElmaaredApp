using AutoMapper;
using ElmaaredApp.BLL.Dtos;
using ElmaaredApp.DAL.Models;

namespace ElmaaredApp.BLL.Helper
{
    public class DomainProfile:Profile
    {
        public DomainProfile()
        {
            CreateMap<Brand, BrandDto>();
            CreateMap<BrandDto, Brand>();
            //---------------
            CreateMap<Model, ModelDto>();
            CreateMap<ModelDto, Model>();
            //---------------
            CreateMap<Product, ProductDto>();
            CreateMap<ProductDto, Product>();
            //---------------
            CreateMap<CarOutsideLook, CarOutsideLookDto>();
            CreateMap<CarOutsideLookDto, CarOutsideLook>();
            //---------------
        }
    }
}
