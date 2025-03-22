using static HP.Tucsone.Domain.Reserva;

namespace HP.Tucsone.Domain.Entities.FUN
{
    public class ClienteDiamond : Cliente
    {
        private readonly TiempoReserva tiempoReserva = TiempoReserva.T96Hs;

        public ClienteDiamond(string nombre) : base(nombre)
        {
        }

        public override TiempoReserva ObtenerTiempoReserva()
        {
            return tiempoReserva;
        }
    }
}
