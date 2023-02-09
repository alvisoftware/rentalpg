using ApiLayer.Common;
using Domain_Layer.Data;
using Domain_Layer.Models;
using DomainLayer.Models;
using Microsoft.AspNetCore.Mvc;
using RepositoryLayer.IRepository;
using RepositoryLayer.Model;
using Service_Layer.IServices;
using Service_Layer.Services;

namespace ApiLayer.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class PropertyInfoController : ControllerBase
    {
        private readonly IPropertyService<PropertyInfo> _propertyService;
        private readonly ApplicationDbContext _applicationDbContext;
        public PropertyInfoController(IPropertyService<PropertyInfo> propertyService, ApplicationDbContext applicationDbContext)
        {
            _propertyService = propertyService;
            _applicationDbContext = applicationDbContext;
        }
        [HttpGet]
        [ProducesResponseType(StatusCodes.Status200OK, Type = typeof(ResponseResult<List<PropertyInfo>>))]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        public async Task<IActionResult> GetProperty()
        {
            try
            {
                var prop = _propertyService.GetAll().ToList();
                if (prop != null)
                {
                    return Ok(new ResponseResult<List<PropertyInfo>>
                    {
                        IsSuccess = true,
                        message = "",
                        Result = prop
                    });
                }
                else
                {
                    return NotFound(new ResponseResult<List<PropertyInfo>>
                    {
                        IsSuccess = true,
                        message = "property Not Found"
                    });
                }
            }
            catch(Exception ex)
            {
                return StatusCode(500, new ResponseResult<List<PropertyInfo>>
                {
                    IsSuccess = false,
                    message = "somting went Wrong"
                });
            }
        }
        [Route("PropertyListWithOwner")]
        [HttpGet]
        [ProducesResponseType(StatusCodes.Status200OK, Type = typeof(ResponseResult<List<PropertyModel>>))]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        public async Task<IActionResult> PropertyListWithOwner()
        {
            try
            {
                var result = _propertyService.GetPropertyWithOwnerName().ToList();
                if (result != null)
                {
                    return Ok(new ResponseResult<List<PropertyModel>>
                    {
                        IsSuccess = true,
                        message = "",
                        Result = result
                    });
                }
                else
                {
                    return NotFound(new ResponseResult<List<PropertyModel>>
                    {
                        IsSuccess = true,
                        message = "List of property is not found"
                    });
                }
            }
            catch (Exception ex)
            {
                return StatusCode(500, new ResponseResult<List<PropertyModel>>
                {
                    IsSuccess = false,
                    message = "Somthing Went Wrong"
                });
            }
        }
        [HttpPost]
        public async Task<IActionResult> CreateProperty(PropertyInfo property)
        {
            try
            {
                if(property == null)
                {
                    return BadRequest(new ResponseResult<PropertyInfo>
                    {
                        IsSuccess = false,
                        message = "Proeprty not Exist"
                    });
                }
                else
                {
                    CountryTable country = new CountryTable();
                    country.id = Convert.ToInt32(property.cityid);

                    _propertyService.Insert(property);
                    return Ok(new ResponseResult<PropertyInfo>
                    {
                        IsSuccess = true,
                        message = "Record Save",
                        Result = property
                    });
                }
            }
            catch(Exception ex)
            {
                return StatusCode(500, new ResponseResult<PropertyInfo>
                {
                    IsSuccess = false,
                    message = "Record Saved faile"
                });
            }
        }
    }
}




//[HttpGet]
//[ProducesResponseType(StatusCodes.Status200OK, Type = typeof(ResponseResult<List<CustomModel>>))]
//[ProducesResponseType(StatusCodes.Status404NotFound)]
//public async Task<IActionResult> GetPropertyWithOwnerName()
//{
//    try
//    {
//        var result = _propertyService.GetPropertyWithOwnerName().ToList();
//        if (result != null)
//        {
//            return Ok(new ResponseResult<List<PropertyInfo>>
//            {
//                IsSuccess = true,
//                message = "",
//                Result = result
//            });
//        }
//        else
//        {
//            return NotFound(new ResponseResult<List<CustomModel>>
//            {
//                IsSuccess = true,
//                message = "Property with owner not fount"
//            });

//        }
//    }
//    catch (Exception ex)
//    {
//        return StatusCode(500, new ResponseResult<List<CustomModel>>
//        {
//            IsSuccess = false,
//            message = "Somthing Went Wrong"
//        });
//    }
//}