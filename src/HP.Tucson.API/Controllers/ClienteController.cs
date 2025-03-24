using HP.Tucsone.Application.Cliente.Models.Queries;
using HP.Tucsone.Application.Cliente.Models.Responses;
using HP.Tucsone.Application.Reserva.Models.Queries;
using HP.Tucsone.Application.Reserva.Models.Responses;
using MediatR;
using Microsoft.AspNetCore.Mvc;

namespace HP.Tucson.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ClienteController : ControllerBase
    {
        private readonly ISender _sender;
        public ClienteController(ISender sender)
        {
            _sender = sender;
        }

        [HttpGet(Name = "Obtener-Cliente-En-Espera")]
        public async Task<IEnumerable<GetClienteEsperaResponse>> GetAsync()
        {
            var clientesEnEspera = await _sender.Send(new GetClienteEsperaQuery());
            return clientesEnEspera;
        }
    }
}
