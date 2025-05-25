namespace ReservaSalas.API.Services
{
    public interface IReservaService
    {
        List<Model.Reserva> GetAll();
        List<Model.Reserva> GetBySalaId(int salaId);
        Model.Reserva Create(DTO.CriarReservaDto reservaDto);
    }
}