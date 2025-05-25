namespace ReservaSalas.API.Services
{
    public interface ISalasServices
    {
        List<Model.Sala> GetAll();
        Model.Sala Create(DTO.CriarSalaDto salaDto);
    }
}