using static HP.Tucsone.Domain.Reserva;

namespace HP.Tucsone.Domain
{
    public abstract class Cliente
    {
        public int Id { get; private set; }
        public string Nombre { get; private set; }

        private Cliente() { }
        protected Cliente(string nombre)
        {
            this.Nombre = Nombre;
        }
        public abstract TiempoReserva ObtenerTiempoReserva();
    }
}
