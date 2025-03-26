using HP.Tucson.Application.Exceptions;
using HP.Tucson.Application.FeatureReserva.Models.Commands;
using HP.Tucson.Application.FeatureReserva.Models.Responses;
using HP.Tucson.Domain.Interfaces;
using MediatR;

namespace HP.Tucson.Application.FeatureReserva.Handlers
{
    public class RemoveReservaCommandHandler : IRequestHandler<RemoveReservaCommand, RemoveReservaResponse>
    {
        private readonly IReservaRepository _reservaRepository;

        public RemoveReservaCommandHandler(IReservaRepository reservaRepository)
        {
            _reservaRepository = reservaRepository;
        }
        public async Task<RemoveReservaResponse> Handle(RemoveReservaCommand request, CancellationToken cancellationToken)
        {
            try
            {
                var reservasDelCliente = await this._reservaRepository.BuscarReservasDelCliente(request.NumeroCliente);
                if (!reservasDelCliente.Any())
                {
                    throw new ReservaNoEncontradaException($"No existen reservas para el Cliente {request.NumeroCliente}");
                }
                var reservaEspecifica = reservasDelCliente.Where(r => request.FechaHora.Equals(r.FechaHora)).FirstOrDefault();
                if (reservaEspecifica == null)
                {
                    throw new ReservaNoEncontradaException($"No existen la reserva para el Cliente {request.NumeroCliente} en la fecha solicitada");
                }
                await this._reservaRepository.EliminarReserva(reservaEspecifica);
                return new RemoveReservaResponse { Numero = reservaEspecifica?.Cliente?.Numero, FechaHora = request.FechaHora };
            }
            catch (ReservaNoEncontradaException)
            {
                throw;
            }
            catch (Exception ex)
            {
                throw new UnespectedException("Ocurrio un error inesperado en la clase al liberar mesa", ex);
            }
        }
    }
}
