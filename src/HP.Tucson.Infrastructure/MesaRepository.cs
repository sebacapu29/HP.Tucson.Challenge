using HP.Tucson.Domain.Constants;
using HP.Tucson.Domain.Entities;
using HP.Tucson.Domain.Interfaces;

namespace HP.Tucson.Infrastructure
{
    public class MesaRepository : IMesaRepository
    {
        private readonly List<Mesa> _mesas;
        public MesaRepository()
        {
            _mesas = MockMesa.GetMesas();
        }
        public IReadOnlyList<Mesa> ObtenerTodas()
        {
            return this._mesas.ToList().AsReadOnly();
        }
        public Mesa? ObtenerMesaPorNumero(int numero)
        {
            return _mesas.Where(m => m.Numero == numero).FirstOrDefault();
        }
        public void LiberarMesa(Mesa mesa)
        {
            var mesaOcupada = _mesas.Where(m => m.Numero == mesa.Numero).FirstOrDefault();
            if (mesaOcupada != null) 
            {
                mesaOcupada.Liberar();
                ActualizarEstadoMesas(mesa);
            }
        }

        public void OcuparMesa(Mesa mesa)
        {
            var mesaOcupada = _mesas.Where(m => m.Numero == mesa.Numero).FirstOrDefault();
            if (mesaOcupada != null)
            {
                mesaOcupada.Ocupar();
                ActualizarEstadoMesas(mesa);
            }
        }
        private void ActualizarEstadoMesas(Mesa mesa)
        {
            var indexMesa = _mesas.IndexOf(mesa);
            if(indexMesa != -1)
            {
                _mesas[indexMesa] = mesa;
            }
        }
    }
}
