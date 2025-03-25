using HP.Tucsone.Application.FeatureReserva.Models.Responses;
using MediatR;

namespace HP.Tucsone.Application.FeatureReserva.Models.Queries
{
    public class GetReservasQuery : IRequest<List<GetReservasResponse>>
    {

    }
}
