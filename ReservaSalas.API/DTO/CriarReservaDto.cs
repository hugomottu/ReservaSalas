using System.ComponentModel.DataAnnotations;

namespace ReservaSalas.API.DTO
{
    public class CriarReservaDto
    {
        [Required(ErrorMessage = "O ID da sala é obrigatório")]
        public int SalaId { get; set; }

        [Required(ErrorMessage = "O nome do solicitante é obrigatório")]
        public string Solicitante { get; set; }

        [Required(ErrorMessage = "A data da reserva é obrigatória")]
        public DateTime Data { get; set; }

        [Required(ErrorMessage = "A duração é obrigatória")]
        [Range(1, 8, ErrorMessage = "A duração deve estar entre 1 e 8 horas")]
        public int DuracaoEmHoras { get; set; }
    }
}