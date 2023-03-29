using Microsoft.AspNetCore.Mvc;

namespace FirstApi.Controllers
{

    [Route("api/[controller]")]
    [ApiController]
    public class HomeController : ControllerBase
    {
        [HttpGet]
        public IActionResult GetHello() => Ok("Hello World"); 
    }
}
