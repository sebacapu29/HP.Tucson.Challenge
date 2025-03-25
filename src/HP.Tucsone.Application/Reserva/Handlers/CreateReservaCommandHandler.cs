using HP.Tucsone.Application.Reserva.Models.Commands;
using HP.Tucsone.Application.Reserva.Models.Responses;
using HP.Tucsone.Application.Services.Interfaces;
using HP.Tucsone.Domain.Interfaces;
using MediatR;

namespace HP.Tucsone.Application.Reserva.Handlers
{
    public class CreateReservaCommandHandler : IRequestHandler<CreateReservaCommand, CreateReservaResponse>
    {
        private readonly IReservaRepository _reservaRepository;
        private readonly IMesaRepository _mesaRepository;
        private readonly IClienteRepository _clienteRepository;
        private readonly IClienteEnEsperaService _clienteEnEsperaService;

        public CreateReservaCommandHandler(IReservaRepository reservaRepository,
                                    IMesaRepository mesaRepository,
                                    IClienteRepository clienteRepository,
                                    IClienteEnEsperaService clienteEnEsperaService)
        {
            _reservaRepository = reservaRepository;
            _mesaRepository = mesaRepository;
            _clienteRepository = clienteRepository;
            _clienteEnEsperaService = clienteEnEsperaService;

        }
        public async Task<CreateReservaResponse> Handle(CreateReservaCommand request, CancellationToken cancellationToken)
        {
            try
            {
                var mesas = _mesaRepository.ObtenerTodas();
                var mesaDisponible = mesas.Where(m => m.Disponible).FirstOrDefault();
                var clienteReserva = await _clienteRepository.GetClienteByNumero(request.NumeroCliente);
                var fechaHoraActual = DateTime.Now;

                if (clienteReserva == null)
                {
                    throw new ArgumentNullException($"No se encontró el cliente número: {request.NumeroCliente}");
                }
                bool puedeReservar = PuedeReservar(request.FechaHora, clienteReserva!.Categoria!.Nombre);
                if (!puedeReservar)
                {
                    throw new Exception("No esta habilitado para reservar");
                }
                if (mesaDisponible != null)
                {
                    var idNuevaReserva = await _reservaRepository.GenerarId();
                    var reserva = await _reservaRepository.CrearReserva(new Domain.Reserva(idNuevaReserva, request.FechaHora, clienteReserva, mesaDisponible.Numero));
                    _mesaRepository.OcuparMesa(mesaDisponible);
                    return new CreateReservaResponse { Mensaje = $"Reserva realizada con éxito en mesa {reserva.NumeroMesa}" };
                }
                await _clienteEnEsperaService.PonerClienteEnEspera(clienteReserva);
                return new CreateReservaResponse { Mensaje = "Cliente en espera" };
            }
            catch
            {
                throw;
            }
        }
        private bool PuedeReservar(DateTime fechaReserva, string categoria)
        {
            DateTime fechaHoraActual = DateTime.Now;
            int horasMinimasRequeridas;

            switch (categoria.ToLower())
            {
                case "classic":
                    horasMinimasRequeridas = 48;
                    break;
                case "gold":
                    horasMinimasRequeridas = 72;
                    break;
                case "platinum":
                    horasMinimasRequeridas = 96;
                    break;
                case "diamond":
                    return true;
                default:
                    return false;
            }
            return Math.Round((fechaReserva - fechaHoraActual).TotalHours, 1) <= horasMinimasRequeridas;
        }
    }
}
