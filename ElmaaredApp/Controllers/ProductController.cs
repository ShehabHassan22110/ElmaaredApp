using AutoMapper;
using ElmaaredApp.BLL.Dtos;
using ElmaaredApp.BLL.Helper.Response;
using ElmaaredApp.BLL.Helper;
using ElmaaredApp.BLL.Interfaces;
using ElmaaredApp.DAL.Models;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using ElmaaredApp.BLL.Services;

namespace ElmaaredApp.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ProductController : ControllerBase
    {
        private readonly IProductService Productservice;
        private readonly IMapper mapper;

        public ProductController(IProductService Productervice, IMapper mapper)
        {
            this.Productservice = Productervice;
            this.mapper = mapper;
        }

        #region get all Product
        [HttpGet("GetAllProduct")]
        public async Task<IActionResult> Get()
        {
            var data = await Productservice.Get();

            ProductsResponse response = new ProductsResponse()
            {
                Code = "200",
                Status = "Succeeded",
                Message = "Products rerurned successfully",
                Data = data
            };
            return Ok(response);
        }

        #endregion


        #region get  Product by id
        [HttpGet("GetProductById")]
        public async Task<IActionResult> GetById(int id)
        {
            var data = await Productservice.GetById(id);
            if (data == null)
            {
                CustomResponse customResponse = new CustomResponse
                {
                    Code = "400",
                    Status = "Bad Request",
                    Message = $"No data found by id = {id}",
                };

                return BadRequest(customResponse);
            }
            ProductDetailsResponse response = new ProductDetailsResponse()
            {
                Code = "200",
                Status = "Succeeded",
                Message = "Product rerurned successfully" ,
                Data = data
            };
            return Ok(response);
        }

        #endregion
        #region get  Product by id
        [HttpGet("GetProductByBrandId")]
        public async Task<IActionResult> GetProductByBrandId(int id)
        {
            var data = await Productservice.GetByBrand(id);

            ProductsResponse response = new ProductsResponse()
            {
                Code = "200",
                Status = "Succeeded",
                Message = " Products rerurned successfully",
                Data = data
            };
            return Ok(response);
        }

        #endregion


        #region Create
        [Authorize(Roles = "Admin")]
        [HttpPost("Create")]
        public async Task<IActionResult> CreateAsync([FromForm] ProductDto dto)
        {

            try
            {

              //  dto.PhotoName = FileUploader.UploadFile("/wwwroot/Images/", dto.Photo);
                var product = mapper.Map<Product>(dto);

                if (dto.Images != null && dto.Images.Count > 0)
                {
                    foreach (var formFile in dto.Images)
                    {
                        if (formFile.Length > 0)
                        {
                            string imageName = FileUploader.UploadFile("/wwwroot/Images/", formFile);
                            var productImage = new ProductImage
                            {
                                PhotoName = imageName,
                                Product = product
                            };
                            product.Images.Add(productImage);
                        }
                    }
                }

                await Productservice.Create(product);
                if (product != null)
                {
                    CustomResponse response = new CustomResponse
                    {
                        Code = "200",
                        Status = "Success",
                        Message = "Product created successfully !",
                    };

                    return Ok(response);
                }
                return StatusCode(400, new CustomResponse { Code = "400", Message = "Error" });

            }
            catch (Exception ex)
            {
                return BadRequest(ex);
            }



        }

        #endregion


        #region Filer 
        [HttpGet("FilterProducts")]
        public async Task<IActionResult> FilterProducts(int? modelId, int? brandId, int? carOutsideLookId, decimal? priceFrom, decimal? priceTo, string? district, string? manufacturingYearFrom, string? manufacturingYearTo)
        {
            try
            {
                var products = await Productservice.FilterProducts(
                    modelId,
                    brandId,                   
                    carOutsideLookId,
                    priceFrom,
                    priceTo,
                    district,
                    manufacturingYearFrom,
                    manufacturingYearTo
                );

                ProductsResponse response = new ProductsResponse()
                {
                    Code = "200",
                    Status = "Succeeded",
                    Message = "Products filtered successfully!",
                    Data = products
                };
                return Ok(response);

              
            }
            catch (Exception ex)
            {
                return BadRequest(new
                {
                    Code = "400",
                    Status = "Error",
                    Message = ex.Message
                });
            }
        }

        #endregion
    }
}
