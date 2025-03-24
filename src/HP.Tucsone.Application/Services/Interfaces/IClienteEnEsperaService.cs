
using HP.Tucsone.Application.Cliente.Models.Responses;

namespace HP.Tucsone.Application.Services.Interfaces
{
    public interface IClienteEnEsperaService
    {
        void EscucharClientesEnEspera();
        Task<List<GetClienteEsperaResponse>> ObtenerClientesEnEspera();
        Task PonerClienteEnEspera(Domain.Cliente cliente);
    }
}
