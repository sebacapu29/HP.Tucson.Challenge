using HP.Tucsone.Application.FeatureCliente.Models.Queries;
using HP.Tucsone.Application.FeatureCliente.Models.Responses;
using HP.Tucsone.Application.Services.Interfaces;
using MediatR;

namespace HP.Tucsone.Application.FeatureCliente.Handlers
{
    public class GetClienteEsperaQueryHandler : IRequestHandler<GetClienteEsperaQuery, IEnumerable<GetClienteEsperaResponse>>
    {
        private readonly IClienteEnEsperaService _clienteEnEsperaService;

        public GetClienteEsperaQueryHandler(IClienteEnEsperaService clienteEnEsperaService)
        {
            _clienteEnEsperaService = clienteEnEsperaService;
        }
        public async Task<IEnumerable<GetClienteEsperaResponse>> Handle(GetClienteEsperaQuery request, CancellationToken cancellationToken)
        {
            try
            {
                return await _clienteEnEsperaService.ObtenerClientesEnEspera();
            }
            catch
            {
                throw;
            }
        }
    }
}
