using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using NLayer.Core.DTOs;

namespace NLayer.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CustomBaseController : ControllerBase
    {
        [NonAction]
        public IActionResult CreateActionResult<T>(CustomResponseDTo<T> respone)
        {
            if (respone.StatusCode == 204)
                return new ObjectResult(null)
                {
                    StatusCode = respone.StatusCode,
                };

            return new ObjectResult(respone)
            {
                StatusCode = respone.StatusCode
            };
        }
    }
}
