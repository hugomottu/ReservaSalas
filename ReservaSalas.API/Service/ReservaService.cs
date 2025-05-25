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
            var novaReservaInicio = reservaDto.Data;
            var novaReservaFim = reservaDto.Data.AddHours(reservaDto.DuracaoEmHoras);

            foreach (var reserva in reservasExistentes)
            {
                var reservaExistenteInicio = reserva.Data;
                var reservaExistenteFim = reserva.Data.AddHours(reserva.DuracaoEmHoras);

                // Verifica se há sobreposição de horários
                if (novaReservaInicio < reservaExistenteFim && novaReservaFim > reservaExistenteInicio)
                {
                    throw new InvalidOperationException($"Já existe uma reserva para esta sala no período das {reservaExistenteInicio:HH:mm} às {reservaExistenteFim:HH:mm}");
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