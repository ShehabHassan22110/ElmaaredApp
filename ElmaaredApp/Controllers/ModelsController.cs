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
    public class ModelsController : ControllerBase
    {
        private readonly IModelService ModelService;
        private readonly IMapper mapper;

        public ModelsController(IModelService ModelService,IMapper mapper )
        {
            this.ModelService = ModelService;
            this.mapper = mapper;
        }

        #region get all Models
        [HttpGet("GetAllModels")]
        public async Task<IActionResult>Get()
        {
            var data = await ModelService.Get();

            ModelsResponse response = new ModelsResponse()
            {
                Code = "200",
                Status = "Succeeded",
                Message = "Models data rerurned successfully",
                Data = data
            };
            return Ok(response);
        }

        #endregion

        #region Create
     //   [Authorize(Roles = "Admin")]
        [HttpPost("Create")]
        public async Task<IActionResult> CreateAsync([FromForm] ModelDto dto)
        {

            try
            {
                var data = mapper.Map<Model>(dto);
                await ModelService.Create(data);
                if (data != null)
                {
                    CustomResponse response = new CustomResponse
                    {
                        Code = "200",
                        Status = "Success",
                        Message = "Model created successfully !",
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
