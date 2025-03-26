using HP.Tucsone.Application.FeatureCliente.Models.Responses;
using MediatR;

namespace HP.Tucsone.Application.FeatureCliente.Models.Queries
{
    public class GetClienteEsperaQuery : IRequest<IEnumerable<GetClienteEsperaResponse>>
    {
        public int NumeroCliente { get; set; }
    }
}
