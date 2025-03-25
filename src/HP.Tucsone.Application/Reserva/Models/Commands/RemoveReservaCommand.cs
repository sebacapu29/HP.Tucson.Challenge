using HP.Tucsone.Application.FeatureReserva.Models.Responses;
using MediatR;

namespace HP.Tucsone.Application.FeatureReserva.Models.Commands
{
    public class RemoveReservaCommand : IRequest<RemoveReservaResponse>
    {
        public int NumeroCliente { get; set; }
        public DateTime FechaHora { get; set; }
    }
}
