namespace HP.Tucson.Domain.Entities
{
    public class Reserva
    {
        public int Id { get; private set; }
        public DateTime FechaHora { get; private set; }
        public Cliente? Cliente { get; private set; }
        public int NumeroMesa { get; private set; }
        private Reserva() {}
        public Reserva(int id, DateTime fechaHora, Cliente cliente, int numeroMesa)
        {
            Id = id;
            FechaHora = fechaHora;
            Cliente = cliente;
            NumeroMesa = numeroMesa;
        }
    }
}
