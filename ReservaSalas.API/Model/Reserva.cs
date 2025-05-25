namespace ReservaSalas.API.Model
{
    public class Reserva
    {
        // Propriedades encapsuladas (private set)
        public int Id { get; private set; }
        public int SalaId { get; private set; }
        public string Solicitante { get; private set; }
        public DateTime Data { get; private set; }
        public int DuracaoEmHoras { get; private set; }
        
        // Construtor
        public Reserva(int id, int salaId, string solicitante, DateTime data, int duracaoEmHoras)
        {
            Id = id;
            SalaId = salaId;
            Solicitante = solicitante;
            Data = data;
            DuracaoEmHoras = duracaoEmHoras;
        }
    }
}