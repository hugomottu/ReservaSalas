using Microsoft.AspNetCore.Mvc;

namespace ReservaSalas.API.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class SalasController : ControllerBase
    {
        [HttpGet]
        public IActionResult Salas()
        {
            Console.WriteLine("GET Salas");
            return Ok();
        }
        
    }
}