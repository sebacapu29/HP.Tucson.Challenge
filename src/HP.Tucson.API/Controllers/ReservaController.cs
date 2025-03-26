using HP.Tucson.Application.FeatureReserva.Models.Commands;
using HP.Tucson.Application.FeatureReserva.Models.Queries;
using HP.Tucson.Application.FeatureReserva.Models.Responses;
using MediatR;
using Microsoft.AspNetCore.Mvc;

namespace HP.Tucson.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ReservaController : ControllerBase
    {
        private readonly ISender _sender;
        public ReservaController(ISender sender)
        {
            _sender = sender;
        }

        [HttpGet("listar-reservas")]
        public async Task<IEnumerable<GetReservasResponse>> GetAsync()
        {
            var reservas = await _sender.Send(new GetReservasQuery());
            return reservas;
        }
        [HttpPost("crear-reservar")]
        public async Task<CreateReservaResponse> PostAsync(CreateReservaCommand reserva)
        {
            var reservas = await _sender.Send(reserva);
            return reservas;
        }
        [HttpDelete("eliminar-reservar")]
        public async Task<RemoveReservaResponse> DeleteAsync(RemoveReservaCommand reserva)
        {
            var reservas = await _sender.Send(reserva);
            return reservas;
        }
    }

}
