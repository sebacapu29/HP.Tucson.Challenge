using HP.Tucsone.Application.Reserva.Models.Commands;
using HP.Tucsone.Application.Reserva.Models.Responses;
using MediatR;

namespace HP.Tucsone.Application.Reserva.Handlers
{
    public class CreateReservaHandler : IRequestHandler<CreateReservaCommand, CreateReservaResponse>
    {
        public Task<CreateReservaResponse> Handle(CreateReservaCommand request, CancellationToken cancellationToken)
        {
            throw new NotImplementedException();
        }
    }
}
