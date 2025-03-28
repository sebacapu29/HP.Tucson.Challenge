﻿using HP.Tucson.Application.FeatureCliente.Models.Queries;
using HP.Tucson.Application.FeatureCliente.Models.Responses;
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
        [HttpGet("cliente-en-espera")]
        public async Task<IEnumerable<GetClienteEsperaResponse>> GetAsync()
        {
            var clientesEnEspera = await _sender.Send(new GetClienteEsperaQuery());
            return clientesEnEspera;
        }
    }
}
