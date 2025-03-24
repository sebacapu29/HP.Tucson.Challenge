
namespace HP.Tucsone.Application.Services.Interfaces
{
    public interface IClienteEnEsperaService
    {
        void EscucharClientesEnEspera();
        Task PonerClienteEnEspera(Domain.Cliente cliente);
    }
}
