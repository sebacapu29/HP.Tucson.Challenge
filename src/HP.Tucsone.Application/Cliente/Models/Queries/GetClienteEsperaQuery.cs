using HP.Tucsone.Application.Cliente.Models.Responses;
using MediatR;

namespace HP.Tucsone.Application.Cliente.Models.Queries
{
    public class GetClienteEsperaQuery : IRequest<IEnumerable<GetClienteEsperaResponse>>
    {
        public int NumeroCliente { get; set; }
    }
}
