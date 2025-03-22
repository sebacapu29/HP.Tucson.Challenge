namespace HP.Tucsone.Domain
{
    public class Restaurant
    {
        public string Nombre { get; private set; }
        private List<Reserva> Reservas { get; set; }
        private List<Mesa> Mesas { get; set; }

        public Restaurant(string nombre)
        {
            this.Nombre = nombre;
            Mesas = new List<Mesa>();
            Reservas = new List<Reserva>();
        }
        private Restaurant() { }

        public IReadOnlyList<Reserva> ListarReservas()
        {
            return this.Reservas.AsReadOnly();
        }
        public IReadOnlyList<Mesa> ListarMesas()
        {
            return this.Mesas.AsReadOnly();
        }
        public void AgregarReserva(Reserva reserva)
        {
            if(this.Reservas != null)
            {
                this.Reservas.ToList().Add(reserva);
            }
        }
    }
}
