using ApiLayer.Common;
using Domain_Layer.Data;
using DomainLayer.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Service_Layer.IServices;

namespace ApiLayer.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class RentTableController : ControllerBase
    {
        private readonly IRentTableService<RentTable> _rentTable;
        private readonly ApplicationDbContext _applicationDbContext;
        public RentTableController(IRentTableService<RentTable> rentTable, ApplicationDbContext applicationDbContext)
        {
            _rentTable = rentTable;
            _applicationDbContext = applicationDbContext;
        }
        [HttpPost]
        public async Task<IActionResult> CreateRent(RentTable rentTable)
        {
            try
            {
                if(rentTable == null)
                {
                    return BadRequest(new ResponseResult<RentTable>
                    {
                        IsSuccess = false,
                        message = "Renttable not found"
                    });
                }
                else
                {
                    _rentTable.Insert(rentTable);
                    return Ok(new ResponseResult<RentTable>
                    {
                        IsSuccess = true,
                        message = "Record Save",
                        Result = rentTable
                    });
                }
            }
            catch(Exception ex)
            {
                return StatusCode(500, new ResponseResult<RentTable>
                {
                    IsSuccess = false,
                    message = "somthing went wrong"
                });
            }
        }
    }
}
