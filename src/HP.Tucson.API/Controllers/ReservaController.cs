using HP.Tucsone.Application.Reserva.Models.Commands;
using HP.Tucsone.Application.Reserva.Models.Queries;
using HP.Tucsone.Application.Reserva.Models.Responses;
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

        [HttpGet(Name = "GetReservasAll")]
        public async Task<IEnumerable<GetReservasResponse>> GetAsync()
        {
            var reservas = await _sender.Send(new GetReservasQuery());
            return reservas;
        }
        [HttpPost(Name = "Reservar")]
        public async Task<CreateReservaResponse> PostAsync(CreateReservaCommand reserva)
        {
            var reservas = await _sender.Send(reserva);
            return reservas;
        }
    }

}
