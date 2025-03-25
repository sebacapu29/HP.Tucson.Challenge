﻿using HP.Tucsone.Application.FeatureReserva.Models.Commands;
using HP.Tucsone.Application.FeatureReserva.Models.Queries;
using HP.Tucsone.Application.FeatureReserva.Models.Responses;
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

        [HttpGet(Name = "Listar-Reservas")]
        public async Task<IEnumerable<GetReservasResponse>> GetAsync()
        {
            var reservas = await _sender.Send(new GetReservasQuery());
            return reservas;
        }
        [HttpPost(Name = "Crear-Reservar")]
        public async Task<CreateReservaResponse> PostAsync(CreateReservaCommand reserva)
        {
            var reservas = await _sender.Send(reserva);
            return reservas;
        }
        [HttpDelete(Name = "Eliminar-Reservar")]
        public async Task<RemoveReservaResponse> DeleteAsync(RemoveReservaCommand reserva)
        {
            var reservas = await _sender.Send(reserva);
            return reservas;
        }
    }

}
