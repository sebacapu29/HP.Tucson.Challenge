using HP.Tucsone.Application.FeatureReserva.Models.Responses;
using MediatR;

namespace HP.Tucsone.Application.FeatureReserva.Models.Commands
{
    public class CreateReservaCommand : IRequest<CreateReservaResponse>
    {
        public int NumeroCliente { get; set; }
        public DateTime FechaHora { get; set; }
    }
}
