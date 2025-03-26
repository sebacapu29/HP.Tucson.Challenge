using HP.Tucsone.Application.Exceptions;
using HP.Tucsone.Application.FeatureReserva.Models.Queries;
using HP.Tucsone.Application.FeatureReserva.Models.Responses;
using HP.Tucsone.Domain.Interfaces;
using MediatR;

namespace HP.Tucsone.Application.FeatureReserva.Handlers
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
            try
            {
                var reservas = await this._reservaRepository.ListarReservas();
                var response = reservas!.Select(r => new GetReservasResponse { FechaHora = r.FechaHora, NumeroCliente = r?.Cliente?.Numero });
                return response!.ToList();
            }
            catch (Exception ex)
            {
                throw new UnespectedException("Ocurrio un error inesperado en la clase al liberar mesa", ex);
            }
        }
    }
}
