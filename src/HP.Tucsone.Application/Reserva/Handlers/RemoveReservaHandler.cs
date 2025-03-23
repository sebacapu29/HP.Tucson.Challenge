using HP.Tucsone.Application.Reserva.Models.Commands;
using HP.Tucsone.Application.Reserva.Models.Responses;
using MediatR;

namespace HP.Tucsone.Application.Reserva.Handlers
{
    public class RemoveReservaHandler : IRequestHandler<RemoveReservaCommand, RemoveReservaResponse>
    {
        public Task<RemoveReservaResponse> Handle(RemoveReservaCommand request, CancellationToken cancellationToken)
        {
            throw new NotImplementedException();
        }
    }
}
