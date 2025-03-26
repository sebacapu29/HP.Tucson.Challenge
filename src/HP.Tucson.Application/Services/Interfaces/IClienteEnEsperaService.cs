using HP.Tucson.Application.FeatureCliente.Models.Responses;
using HP.Tucson.Domain.Entities;

namespace HP.Tucson.Application.Services.Interfaces
{
    public interface IClienteEnEsperaService
    {
        Task EliminarClienteEnEspera(Cliente cliente);
        Task<List<GetClienteEsperaResponse>> ObtenerClientesEnEspera();
        Task PonerClienteEnEspera(Cliente cliente);
    }
}
