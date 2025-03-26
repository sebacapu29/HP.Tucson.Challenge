using HP.Tucson.Application.FeatureReserva.Models.Responses;
using MediatR;

namespace HP.Tucson.Application.FeatureReserva.Models.Queries
{
    public class GetReservasQuery : IRequest<List<GetReservasResponse>>
    {

    }
}
