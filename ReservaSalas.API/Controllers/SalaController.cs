using Microsoft.AspNetCore.Mvc;
using ReservaSalas.API.Services;

namespace ReservaSalas.API.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class SalasController : ControllerBase
    {
        private readonly ISalasServices _salasService;
        public SalasController(ISalasServices service)
        {
            _salasService = service;
        }
        [HttpGet]
        public IActionResult Salas()
        {
            Console.WriteLine("GET Salas");
            string s = _salasService.GetAll();
            return Ok();
        }
        
    }
}