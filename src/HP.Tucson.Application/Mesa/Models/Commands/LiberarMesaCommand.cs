using HP.Tucson.Application.FeatureMesa.Models.Responses;
using MediatR;

namespace HP.Tucson.Application.FeatureMesa.Models.Commands
{
    public class LiberarMesaCommand : IRequest<LiberarMesaResponse>
    {
        public int NumeroMesa { get; set; }
    }
}
