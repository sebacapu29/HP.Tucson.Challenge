namespace HP.Tucsone.Domain
{
    public class Reserva
    {
        public int Id { get; private set; }
        private DateTime FechaHora { get; set; }
        public Cliente Cliente { get; private set; }
        public int IdCliente { get; private set; }
        private int NumeroMesa { get; set; }
        private Reserva() {}
        public Reserva(int id, DateTime fechaHora, Cliente cliente, int numeroMesa)
        {
            Id = id;
            FechaHora = fechaHora;
            Cliente = cliente;
            NumeroMesa = numeroMesa;
        }
        public DateTime ObtenerFechaHora()
        {
            return this.FechaHora;
        }
        public enum TiempoReserva
        {
            Free = 0,
            T48Hs = 1,
            T72Hs = 2,
            T96Hs = 3
        }
    }
}
