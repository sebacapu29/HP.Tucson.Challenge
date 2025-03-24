using HP.Tucsone.Application.Reserva.Models.Commands;
using HP.Tucsone.Application.Reserva.Models.Responses;
using HP.Tucsone.Domain.Interfaces;
using MediatR;

namespace HP.Tucsone.Application.Reserva.Handlers
{
    public class RemoveReservaHandler : IRequestHandler<RemoveReservaCommand, RemoveReservaResponse>
    {
        private readonly IReservaRepository _reservaRepository;

        public RemoveReservaHandler(IReservaRepository reservaRepository)
        {
           _reservaRepository = reservaRepository;
        }
        public async Task<RemoveReservaResponse> Handle(RemoveReservaCommand request, CancellationToken cancellationToken)
        {
            var reservasDelCliente = await this._reservaRepository.BuscarReservasDelCliente(request.NumeroCliente);
            if (!reservasDelCliente.Any())
            {
                throw new ArgumentNullException($"No existen reservas para el Cliente {request.NumeroCliente}");
            }
            var reservaEspecifica = reservasDelCliente.Where(r => request.FechaHora.Equals(r.ObtenerFechaHora())).FirstOrDefault();
            if (reservaEspecifica == null)
            {
                throw new ArgumentNullException($"No existen la reservas para el Cliente {request.NumeroCliente} en la fecha solicitada");
            }
            await this._reservaRepository.EliminarReserva(reservaEspecifica);
            return new RemoveReservaResponse { Numero = reservaEspecifica.IdCliente, FechaHora = request.FechaHora};
        }
    }
}
