using HP.Tucsone.Application.Mesa.Models.Commands;
using HP.Tucsone.Application.Mesa.Models.Responses;
using MediatR;
using Microsoft.AspNetCore.Mvc;

namespace HP.Tucson.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class MesaController : ControllerBase
    {
        private readonly ISender _sender;
        public MesaController(ISender sender)
        {
            _sender = sender;
        }
        [HttpPut(Name = "Liberar-Mesa")]
        public async Task<LiberarMesaResponse> DeleteAsync(LiberarMesaCommand mesa)
        {
            var mesaResponse = await _sender.Send(mesa);
            return mesaResponse;
        }
    }
}
