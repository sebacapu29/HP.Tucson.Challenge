using HP.Tucsone.Application.Reserva.Models.Responses;
using MediatR;

namespace HP.Tucsone.Application.Reserva.Models.Commands
{
    public class CreateReservaCommand : IRequest<CreateReservaResponse>
    {
        public int NumeroCliente { get; set; }
        public DateTime FechaHora { get; set; }
    }
}
