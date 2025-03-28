﻿using HP.Tucson.Domain.Entities;
using HP.Tucson.Domain.Interfaces;

namespace HP.Tucson.Infrastructure
{
    public class ReservaRepository : IReservaRepository
    {
        private readonly List<Reserva>? _reservas = new List<Reserva>();
        private readonly IMesaRepository? _mesaRepository;

        public ReservaRepository()
        {
        }
        public ReservaRepository(IMesaRepository mesaRepository)
        {
            _mesaRepository = mesaRepository;
        }
        public Task<IReadOnlyList<Reserva>> BuscarReservasDelCliente(int numeroCliente)
        {
            IReadOnlyList<Reserva> reservasDelCliente = _reservas!.Where(x=> x?.Cliente?.Numero == numeroCliente).ToList();
            return Task.FromResult(reservasDelCliente);
        }

        public Task<Reserva> CrearReserva(Reserva reserva)
        {
            _reservas?.Add(reserva);
            return Task.FromResult(reserva);
        }

        public Task EliminarReserva(Reserva reserva)
        {
            var reservaEnLista = _reservas!.FirstOrDefault(r=> r.Id == reserva.Id);
            if(reservaEnLista != null)
            {
                _reservas!.Remove(reservaEnLista);
            }
            return Task.CompletedTask;
        }

        public Task<int> GenerarId()
        {
            var ultimoId = _reservas!.Count + 1;
            return Task.FromResult(ultimoId);
        }

        public Task<Reserva?> GetReservaByClienteYFecha(int numeroCliente, DateTime fechaHora)
        {
            return Task.FromResult(_reservas!.Where(r => r!.Cliente!.Numero == numeroCliente && r.FechaHora.Equals(fechaHora)).FirstOrDefault());
        }

        public Task<IReadOnlyList<Reserva>?> ListarReservas()
        {
            IReadOnlyList<Reserva> listaReservas = _reservas!.ToList();
            return Task.FromResult(listaReservas ?? null);
        }
    }
}
