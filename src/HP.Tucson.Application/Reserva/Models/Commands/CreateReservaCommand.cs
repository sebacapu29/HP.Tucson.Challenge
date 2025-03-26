using HP.Tucson.Application.FeatureReserva.Models.Responses;
using MediatR;

namespace HP.Tucson.Application.FeatureReserva.Models.Commands
{
    public class CreateReservaCommand : IRequest<CreateReservaResponse>
    {
        public int NumeroCliente { get; set; }
        public DateTime FechaHora { get; set; }
    }
}
