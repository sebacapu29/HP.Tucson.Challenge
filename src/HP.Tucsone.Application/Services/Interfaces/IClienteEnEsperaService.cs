
using HP.Tucsone.Application.Cliente.Models.Responses;

namespace HP.Tucsone.Application.Services.Interfaces
{
    public interface IClienteEnEsperaService
    {
        Task EliminarClienteEnEspera(Domain.Cliente cliente);
        Task<List<GetClienteEsperaResponse>> ObtenerClientesEnEspera();
        Task PonerClienteEnEspera(Domain.Cliente cliente);
    }
}
