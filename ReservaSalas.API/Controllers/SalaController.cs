using Microsoft.AspNetCore.Mvc;
using ReservaSalas.API.Services;
using ReservaSalas.API.DTO;

namespace ReservaSalas.API.Controllers
{
    [ApiController]
    [Route("salas")]
    public class SalasController : ControllerBase
    {
        private readonly ISalasServices _salasService;

        public SalasController(ISalasServices service)
        {
            _salasService = service;
        }

        [HttpGet]
        public IActionResult GetAll()
        {
            var salas = _salasService.GetAll();
            return Ok(salas);
        }

        [HttpPost]
        public IActionResult Create([FromBody] CriarSalaDto salaDto)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            var sala = _salasService.Create(salaDto);
            return CreatedAtAction(nameof(GetAll), new { id = sala.Id }, sala);
        }
    }
}