using static HP.Tucsone.Domain.Reserva;

namespace HP.Tucsone.Domain.Entities.FUN
{
    public class ClientePlatinum : Cliente
    {
        private readonly TiempoReserva tiempoReserva = TiempoReserva.Free;

        public ClientePlatinum(string nombre) : base(nombre)
        {
        }

        public override TiempoReserva ObtenerTiempoReserva()
        {
            return tiempoReserva;
        }
    }
}
