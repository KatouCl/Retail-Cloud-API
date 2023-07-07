using Microsoft.AspNetCore.Mvc;

namespace RetailCloud.Api.Controllers
{
    [Route("error/{code}")]
    [ApiExplorerSettings(IgnoreApi = true)]
    public class ErrorController : Controller
    {
        public IActionResult Error(int code)
        {
            return new ObjectResult(code);
        }
        // return NotFound(new APIResponse(404));
    }
}