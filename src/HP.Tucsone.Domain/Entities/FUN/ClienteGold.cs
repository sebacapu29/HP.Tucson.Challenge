using static HP.Tucsone.Domain.Reserva;

namespace HP.Tucsone.Domain.Entities.FUN
{
    public class ClienteGold : Cliente
    {
        private readonly TiempoReserva tiempoReserva = TiempoReserva.T72Hs;

        public ClienteGold(string nombre) : base(nombre)
        {
        }

        public override TiempoReserva ObtenerTiempoReserva()
        {
            return tiempoReserva;
        }
    }
}
