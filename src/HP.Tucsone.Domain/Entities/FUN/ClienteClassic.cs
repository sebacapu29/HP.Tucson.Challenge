using static HP.Tucsone.Domain.Reserva;

namespace HP.Tucsone.Domain.Entities.FUN
{
    public class ClienteClassic : Cliente
    {
        private readonly TiempoReserva tiempoReserva = TiempoReserva.T48Hs;

        public ClienteClassic(string nombre) : base(nombre)
        {
        }

        public override TiempoReserva ObtenerTiempoReserva()
        {
            return tiempoReserva;
        }
    }
}
