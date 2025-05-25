using Microsoft.AspNetCore.Mvc;
using ReservaSalas.API.Services;
using ReservaSalas.API.DTO;

namespace ReservaSalas.API.Controllers
{
    [ApiController]
    [Route("reservas")]
    public class ReservasController : ControllerBase
    {
        private readonly IReservaService _reservaService;

        public ReservasController(IReservaService reservaService)
        {
            _reservaService = reservaService;
        }

        [HttpGet]
        public IActionResult GetAll()
        {
            var reservas = _reservaService.GetAll();
            return Ok(reservas);
        }

        [HttpPost]
        public IActionResult Create([FromBody] CriarReservaDto reservaDto)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            try
            {
                var reserva = _reservaService.Create(reservaDto);
                return CreatedAtAction(nameof(GetAll), new { id = reserva.Id }, reserva);
            }
            catch (InvalidOperationException ex)
            {
                return BadRequest(ex.Message);
            }
        }
    }

    [ApiController]
    [Route("salas/{salaId}/reservas")]
    public class SalaReservasController : ControllerBase
    {
        private readonly IReservaService _reservaService;

        public SalaReservasController(IReservaService reservaService)
        {
            _reservaService = reservaService;
        }

        [HttpGet]
        public IActionResult GetReservasBySala(int salaId)
        {
            var reservas = _reservaService.GetBySalaId(salaId);
            return Ok(reservas);
        }
    }
}