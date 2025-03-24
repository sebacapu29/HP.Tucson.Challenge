using HP.Tucsone.Application.Mesa.Models.Responses;
using HP.Tucsone.Application.Reserva.Models.Responses;
using MediatR;

namespace HP.Tucsone.Application.Mesa.Models.Commands
{
    public class LiberarMesaCommand : IRequest<LiberarMesaResponse>
    {
        public int Numero { get; set; }
    }
}
