using HP.Tucsone.Application.FeatureCliente.Models.Responses;
using HP.Tucsone.Domain.Entities;

namespace HP.Tucsone.Application.Services.Interfaces
{
    public interface IClienteEnEsperaService
    {
        Task EliminarClienteEnEspera(Cliente cliente);
        Task<List<GetClienteEsperaResponse>> ObtenerClientesEnEspera();
        Task PonerClienteEnEspera(Cliente cliente);
    }
}
