namespace ReservaSalas.API.Services
{
    public class ReservaService : IReservaService
    {
        private readonly ISalasServices _salasService;
        private static List<Model.Reserva> _reservas = new List<Model.Reserva>();
        private static int _nextId = 1;

        public ReservaService(ISalasServices salasService)
        {
            _salasService = salasService;
        }

        public List<Model.Reserva> GetAll()
        {
            return _reservas;
        }

        public List<Model.Reserva> GetBySalaId(int salaId)
        {
            return _reservas.Where(r => r.SalaId == salaId).ToList();
        }

        public Model.Reserva Create(DTO.CriarReservaDto reservaDto)
        {
            // Verifica se a sala existe
            var salas = _salasService.GetAll();
            if (!salas.Any(s => s.Id == reservaDto.SalaId))
            {
                throw new InvalidOperationException("Sala não encontrada");
            }

            // Verifica se já existe reserva para a sala no horário
            var reservasExistentes = GetBySalaId(reservaDto.SalaId);
            foreach (var reserva in reservasExistentes)
            {
                if (reserva.Data <= reservaDto.Data.AddHours(reservaDto.DuracaoEmHoras) &&
                    reservaDto.Data <= reserva.Data.AddHours(reserva.DuracaoEmHoras))
                {
                    throw new InvalidOperationException("Já existe uma reserva para esta sala neste horário");
                }
            }

            var novaReserva = new Model.Reserva(
                id: _nextId++,
                salaId: reservaDto.SalaId,
                solicitante: reservaDto.Solicitante,
                data: reservaDto.Data,
                duracaoEmHoras: reservaDto.DuracaoEmHoras
            );

            _reservas.Add(novaReserva);
            return novaReserva;
        }
    }
}