namespace HP.Tucsone.Domain.Interfaces
{
    public interface IMesaRepository
    {
        IReadOnlyList<Mesa> ObtenerTodas();
        void LiberarMesa(Mesa mesa);
    }
}
