using HP.Tucsone.Application.Reserva.Models.Queries;
using HP.Tucsone.Application.Reserva.Models.Responses;
using HP.Tucsone.Domain.Interfaces;
using MediatR;

namespace HP.Tucsone.Application.Reserva.Handlers
{
    public class GetReservasQueryHandler : IRequestHandler<GetReservasQuery, List<GetReservasResponse>>
    {
        private readonly IReservaRepository _reservaRepository;

        public GetReservasQueryHandler(IReservaRepository reservaRepository)
        {
            this._reservaRepository = reservaRepository;
        }
        public async Task<List<GetReservasResponse>> Handle(GetReservasQuery request, CancellationToken cancellationToken)
        {
            var reservas = await this._reservaRepository.ListarReservas();
            var response = reservas!.Select(r => new GetReservasResponse { FechaHora = r.FechaHora, NumeroCliente = r?.Cliente?.Numero });
            return response!.ToList();
        }
    }
}
