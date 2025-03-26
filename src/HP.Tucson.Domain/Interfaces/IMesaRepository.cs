using HP.Tucson.Domain.Entities;

namespace HP.Tucson.Domain.Interfaces
{
    public interface IMesaRepository
    {
        IReadOnlyList<Mesa> ObtenerTodas();
        void LiberarMesa(Mesa mesa);
        void OcuparMesa(Mesa mesa);
        Mesa? ObtenerMesaPorNumero(int numero);
    }
}
