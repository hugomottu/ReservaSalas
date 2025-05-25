namespace ReservaSalas.API.Model
{
    public class Sala
    {
        // Propriedades encapsuladas (private set)
        public int Id { get; private set; }
        public string Nome { get; private set; }
        public int Capacidade { get; private set; }
        public string Tipo { get; private set; }

        // Construtor
        public Sala(int id, string nome, int capacidade, string tipo)
        {
            Id = id;
            Nome = nome;
            Capacidade = capacidade;
            Tipo = tipo;
        }
    }
}