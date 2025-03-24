using HP.Tucsone.Application.Reserva.Models.Responses;
using MediatR;

namespace HP.Tucsone.Application.Reserva.Models.Commands
{
    public class RemoveReservaCommand : IRequest<RemoveReservaResponse>
    {
        public int NumeroCliente { get; set; }
        public DateTime FechaHora { get; set; }
    }
}
