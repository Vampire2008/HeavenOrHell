using Microsoft.AspNetCore.Cors;
using Microsoft.AspNetCore.Mvc;

namespace StoringAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    [EnableCors(Cors.FrontendAppPolicy)]
    public class ClientController : ControllerBase
    {
        public IActionResult SavePersonal()
        {
            return Ok();
        }
    }
}
