using HP.Tucsone.Application.Mesa.Models.Commands;
using HP.Tucsone.Application.Mesa.Models.Responses;
using MediatR;

namespace HP.Tucsone.Application.Mesa.Handlers
{
    public class LiberarMesaCommandHandler : IRequestHandler<LiberarMesaCommand, LiberarMesaResponse>
    {
        public Task<LiberarMesaResponse> Handle(LiberarMesaCommand request, CancellationToken cancellationToken)
        {
            throw new NotImplementedException();
        }
    }
}
