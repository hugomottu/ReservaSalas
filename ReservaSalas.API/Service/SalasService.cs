namespace ReservaSalas.API.Services
{
    public class SalasServices : ISalasServices
    {
        // Lista temporária para armazenar as salas durante a execução
        private static List<Model.Sala> _salas = new List<Model.Sala>();
        private static int _nextId = 1;

        public List<Model.Sala> GetAll()
        {
            return _salas;
        }

        public Model.Sala Create(DTO.CriarSalaDto salaDto)
        {
            var sala = new Model.Sala(
                id: _nextId++,
                nome: salaDto.Nome,
                capacidade: salaDto.Capacidade,
                tipo: salaDto.Tipo
            );

            _salas.Add(sala);
            return sala;
        }
    }
}