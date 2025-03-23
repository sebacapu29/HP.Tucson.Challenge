using HP.Tucsone.Application.Reserva.Models.Queries;
using HP.Tucsone.Application.Reserva.Models.Responses;
using MediatR;

namespace HP.Tucsone.Application.Reserva.Handlers
{
    public class GetReservasQueryHandler : IRequestHandler<GetReservasQuery, List<GetReservasResponse>>
    {
        //private readonly IReservaRepository reservaRepository;

        public GetReservasQueryHandler()
        {
            
        }
        public Task<List<GetReservasResponse>> Handle(GetReservasQuery request, CancellationToken cancellationToken)
        {
            throw new NotImplementedException();
        }
    }
}
