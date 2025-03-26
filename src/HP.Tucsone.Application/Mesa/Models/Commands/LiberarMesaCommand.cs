using HP.Tucsone.Application.FeatureMesa.Models.Responses;
using MediatR;

namespace HP.Tucsone.Application.FeatureMesa.Models.Commands
{
    public class LiberarMesaCommand : IRequest<LiberarMesaResponse>
    {
        public int NumeroMesa { get; set; }
    }
}
