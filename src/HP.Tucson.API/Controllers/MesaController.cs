﻿using HP.Tucson.Application.FeatureMesa.Models.Commands;
using HP.Tucson.Application.FeatureMesa.Models.Responses;
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
        [HttpPut("liberar-mesa")]
        public async Task<LiberarMesaResponse> DeleteAsync(LiberarMesaCommand mesa)
        {
            var mesaResponse = await _sender.Send(mesa);
            return mesaResponse;
        }
    }
}
