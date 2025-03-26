using HP.Tucsone.Domain.Entities;

namespace HP.Tucsone.Domain.Interfaces
{
    public interface IMesaRepository
    {
        IReadOnlyList<Mesa> ObtenerTodas();
        void LiberarMesa(Mesa mesa);
        void OcuparMesa(Mesa mesa);
        Mesa? ObtenerMesaPorNumero(int numero);
    }
}
