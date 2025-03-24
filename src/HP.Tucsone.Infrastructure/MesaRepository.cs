using HP.Tucsone.Domain;
using HP.Tucsone.Domain.Constants;
using HP.Tucsone.Domain.Interfaces;

namespace HP.Tucsone.Infrastructure
{
    public class MesaRepository : IMesaRepository
    {
        private readonly IEnumerable<Mesa> _mesas;
        public MesaRepository()
        {
            _mesas = MockMesa.GetMesas();
        }
        public IReadOnlyList<Mesa> ObtenerTodas()
        {
            return this._mesas.ToList().AsReadOnly();
        }
        public void LiberarMesa(Mesa mesa)
        {
            var mesaOcupada = _mesas.Where(m => m.Numero == mesa.Numero).FirstOrDefault();
            if (mesaOcupada != null) 
            {
                mesaOcupada.Liberar();
            }
        }
    }
}
