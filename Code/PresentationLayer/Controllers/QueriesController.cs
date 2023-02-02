using ApiLayer.Common;
using Domain_Layer.Data;
using DomainLayer.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Service_Layer.IServices;
using Service_Layer.Services;

namespace ApiLayer.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class QueriesController : ControllerBase
    {
        private readonly IQueriesServices<Queries> _queriesService;
        private readonly ApplicationDbContext _applicationDbContext;
        public QueriesController(IQueriesServices<Queries> queriesService, ApplicationDbContext applicationDbContext)
        {
            _queriesService = queriesService;
            _applicationDbContext = applicationDbContext;
        }
        [HttpGet]
        public async Task<IActionResult> GetQueries()
        {
            try
            {
                var result = _queriesService.GetAll().ToList();
                if (result != null)
                {
                    return Ok(new ResponseResult<List<Queries>>
                    {
                        IsSuccess = true,
                        message="",
                        Result= result
                    });
                }
                else
                {
                    return NotFound(new ResponseResult<List<Queries>>
                    {
                        IsSuccess = true,
                        message = "query not found"
                    });
                }
            }
            catch(Exception ex)
            {
                return StatusCode(500, new ResponseResult<List<Queries>>
                {
                    IsSuccess = false,
                    message = "somthing went wrong"
                });
            }
        }
        [HttpPost]
        public async Task<IActionResult> CreateQueries(Queries queries)
        {
            try
            {
                if (queries == null)
                {
                    return BadRequest(new ResponseResult<Queries>
                    {
                        IsSuccess = false,
                        message = "Proeprty not Exist"
                    });
                }
                else
                {
                    _queriesService.Insert(queries);
                    return Ok(new ResponseResult<Queries>
                    {
                        IsSuccess = true,
                        message = "Record Save",
                        Result=queries
                    });
                }
            }
            catch (Exception ex)
            {
                return StatusCode(500, new ResponseResult<Queries>
                {
                    IsSuccess = false,
                    message = "Record Saved faile"
                });
            }
        }
    }
}
