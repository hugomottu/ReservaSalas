using System.ComponentModel.DataAnnotations;

namespace ReservaSalas.API.DTO
{
    public class CriarSalaDto
    {
        [Required(ErrorMessage = "O nome é obrigatório")]
        public string Nome { get; set; }

        [Required(ErrorMessage = "A capacidade é obrigatória")]
        [Range(1, 100, ErrorMessage = "A capacidade deve estar entre 1 e 100")]
        public int Capacidade { get; set; }

        [Required(ErrorMessage = "O tipo é obrigatório")]
        public string Tipo { get; set; }
    }
}