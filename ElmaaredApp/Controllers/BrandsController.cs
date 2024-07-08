using AutoMapper.Internal;
using AutoMapper;
using ElmaaredApp.BLL.Helper.Response;
using ElmaaredApp.BLL.Interfaces;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using ElmaaredApp.BLL.Dtos;
using ElmaaredApp.DAL.Models;
using ElmaaredApp.BLL.Helper;
using Microsoft.AspNetCore.Authorization;

namespace ElmaaredApp.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class BrandsController : ControllerBase
    {
        private readonly IBrandService brandService;
        private readonly IMapper mapper;

        public BrandsController(IBrandService brandService,IMapper mapper )
        {
            this.brandService = brandService;
            this.mapper = mapper;
        }

        #region get all brands
        [HttpGet("GetAllBrands")]
        public async Task<IActionResult>Get()
        {
            var data = await brandService.Get();

            BrandsResponse response = new BrandsResponse()
            {
                Code = "200",
                Status = "Succeeded",
                Message = "Brand rerurned successfully",
                Data = data
            };
            return Ok(response);
        }

        #endregion

        #region Create
        [Authorize(Roles = "Admin")]
        [HttpPost("Create")]
        public async Task<IActionResult> CreateAsync([FromForm] BrandDto dto)
        {

            try
            {
                dto.PhotoName = FileUploader.UploadFile("/wwwroot/Images/", dto.Photo);
                var data = mapper.Map<Brand>(dto);
                await brandService.Create(data);
                if (data != null)
                {
                    CustomResponse response = new CustomResponse
                    {
                        Code = "200",
                        Status = "Success",
                        Message = "Contact us request created successfully !",
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
    }
}
