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
using ElmaaredApp.BLL.Services;

namespace ElmaaredApp.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CarOutsideLookController : ControllerBase
    {
        private readonly ICarOutsideLookService CarOutsideLookervice;
        private readonly IMapper mapper;

        public CarOutsideLookController(ICarOutsideLookService CarOutsideLookervice,IMapper mapper )
        {
            this.CarOutsideLookervice = CarOutsideLookervice;
            this.mapper = mapper;
        }

        #region get all CarOutsideLook
        [HttpGet("GetAllCarOutsideLook")]
        public async Task<IActionResult>Get()
        {
            var data = await CarOutsideLookervice.Get();

            CarOutsideLookResponse response = new CarOutsideLookResponse()
            {
                Code = "200",
                Status = "Succeeded",
                Message = "CarOutsideLook rerurned successfully",
                Data = data
            };
            return Ok(response);
        }

        #endregion

        #region get  Product by id
        [HttpGet("GetCarOutsideLookById")]
        public async Task<IActionResult> GetById(int id)
        {
            var data = await CarOutsideLookervice.GetById(id);

            if(data == null)
            {
                CustomResponse customResponse = new CustomResponse
                {
                    Code = "400",
                    Status = "Bad Request",
                    Message = $"No data found by id = {id}",
                };

                return BadRequest(customResponse);
            }

            CarOutsideLookDetailsResponse response = new CarOutsideLookDetailsResponse()
            {
                Code = "200",
                Status = "Succeeded",
                Message = "CarOutsideLook rerurned successfully",
                Data = data
            };
            return Ok(response);
        }

        #endregion
        #region Create
        [Authorize(Roles = "Admin")]
        [HttpPost("Create")]
        public async Task<IActionResult> CreateAsync([FromForm] CarOutsideLookDto dto)
        {

            try
            {
                dto.PhotoName = FileUploader.UploadFile("/wwwroot/Images/", dto.Photo);
                var data = mapper.Map<CarOutsideLook>(dto);
                await CarOutsideLookervice.Create(data);
                if (data != null)
                {
                    CustomResponse response = new CustomResponse
                    {
                        Code = "200",
                        Status = "Success",
                        Message = "CarOutsideLook created successfully !",
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
