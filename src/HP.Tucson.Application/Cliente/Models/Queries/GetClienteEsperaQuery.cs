using HP.Tucson.Application.FeatureCliente.Models.Responses;
using MediatR;

namespace HP.Tucson.Application.FeatureCliente.Models.Queries
{
    public class GetClienteEsperaQuery : IRequest<IEnumerable<GetClienteEsperaResponse>>
    {
        public int NumeroCliente { get; set; }
    }
}
