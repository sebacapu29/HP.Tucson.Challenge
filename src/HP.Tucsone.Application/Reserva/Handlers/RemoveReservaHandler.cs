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
        public Task<RemoveReservaResponse> Handle(RemoveReservaCommand request, CancellationToken cancellationToken)
        {
            //buscar reserva
            //return _reservaRepository.EliminarReserva(new Domain.Reserva(reque));
            return Task.FromResult(new RemoveReservaResponse());
        }
    }
}
