namespace HP.Tucsone.Domain.Entities
{
    public class Restaurant
    {
        public string? Nombre { get; private set; }
        private List<Reserva>? Reservas { get; set; }
        private List<Mesa>? Mesas { get; set; }

        public Restaurant(string nombre)
        {
            Nombre = nombre;
            Mesas = new List<Mesa>();
            Reservas = new List<Reserva>();
        }
        private Restaurant() { }

        public IReadOnlyList<Reserva> ListarReservas()
        {
            return Reservas!.AsReadOnly();
        }
        public IReadOnlyList<Mesa> ListarMesas()
        {
            return Mesas!.AsReadOnly();
        }
        public void AgregarReserva(Reserva reserva)
        {
            if(Reservas != null)
            {
                Reservas.ToList().Add(reserva);
            }
        }
    }
}
