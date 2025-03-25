﻿using HP.Tucsone.Application.Exceptions;
using HP.Tucsone.Application.FeatureMesa.Models.Commands;
using HP.Tucsone.Application.FeatureMesa.Models.Responses;
using HP.Tucsone.Application.Services.Interfaces;
using HP.Tucsone.Domain.Entities;
using HP.Tucsone.Domain.Interfaces;
using MediatR;

namespace HP.Tucsone.Application.FeatureMesa.Handlers
{
    public class LiberarMesaCommandHandler : IRequestHandler<LiberarMesaCommand, LiberarMesaResponse>
    {
        private readonly IMesaRepository _mesaRepository;
        private readonly IClienteEnEsperaService _clienteEnEsperaService;
        private readonly IReservaRepository _reservaRepository;
        private readonly IClienteRepository _clienteRepository;
        public LiberarMesaCommandHandler(IMesaRepository mesaRepository,
                                         IClienteEnEsperaService clienteEnEsperaService,
                                         IReservaRepository reservaRepository,
                                         IClienteRepository clienteRepository)
        {
            _mesaRepository = mesaRepository;
            _clienteEnEsperaService = clienteEnEsperaService;
            _reservaRepository = reservaRepository;
            _clienteRepository = clienteRepository;
        }
        public async Task<LiberarMesaResponse> Handle(LiberarMesaCommand request, CancellationToken cancellationToken)
        {
            try
            {
                var mesa = _mesaRepository.ObtenerMesaPorNumero(request.Numero);
                var fechaHora = DateTime.Now;
                if (mesa == null)
                {
                    throw new MesaNotFoundException("No se encontró la mesa especificada");
                }
                _mesaRepository.LiberarMesa(mesa);
                var clientesEnEspera = await _clienteEnEsperaService.ObtenerClientesEnEspera();
                if (clientesEnEspera != null && clientesEnEspera.Any())
                {
                    var ultimoClienteEnEspera = clientesEnEspera.Last();
                    var categoriaCliente = await _clienteRepository.GetCategoriaCliente(ultimoClienteEnEspera.Categoria);
                    var clienteReserva = new Cliente(ultimoClienteEnEspera!.NumeroCliente, ultimoClienteEnEspera.Nombre, categoriaCliente);
                    var idNuevaReserva = await _reservaRepository.GenerarId();
                    var reservaDeClienteEneEspera = new Reserva(idNuevaReserva, fechaHora, clienteReserva, mesa.Numero);
                    await _reservaRepository.CrearReserva(reservaDeClienteEneEspera);
                    await _clienteEnEsperaService.EliminarClienteEnEspera(clienteReserva);
                    return new LiberarMesaResponse { Mensaje = $"Mesa liberada y se asignó al cliente en espera {ultimoClienteEnEspera.Nombre}" };
                }
                return new LiberarMesaResponse { Mensaje = "Mesa liberada" };
            }
            catch (Exception ex)
            {
                throw new UnespectedException("Ocurrio un error en la clase al liberar mesa", ex);
            }
        }
    }
}
