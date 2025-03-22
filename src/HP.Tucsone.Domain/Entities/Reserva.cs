﻿namespace HP.Tucsone.Domain
{
    public class Reserva
    {
        public int Id { get; private set; }
        private DateTime FechaHora { get; set; }
        public Cliente cliente { get; private set; }
        public int IdCliente { get; private set; }
        public Restaurant Restaurant { get; private set; }
        public int IdRestaurant { get; private set; }

        private Reserva() {}
        public Reserva(int id, DateTime fechaHora, Cliente cliente, Restaurant restaurant)
        {
            Id = id;
            FechaHora = fechaHora;
            this.cliente = cliente;
            Restaurant = restaurant;
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
