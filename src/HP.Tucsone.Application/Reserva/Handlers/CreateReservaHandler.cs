using HP.Tucsone.Application.Reserva.Models.Commands;
using HP.Tucsone.Application.Reserva.Models.Responses;
using HP.Tucsone.Domain.Entities;
using HP.Tucsone.Domain.Interfaces;
using MediatR;

namespace HP.Tucsone.Application.Reserva.Handlers
{
    public class CreateReservaHandler : IRequestHandler<CreateReservaCommand, CreateReservaResponse>
    {
        private readonly IReservaRepository _reservaRepository;
        private readonly IMesaRepository _mesaRepository;
        private readonly IClienteRepository _clienteRepository;

        public CreateReservaHandler(IReservaRepository reservaRepository, IMesaRepository mesaRepository, IClienteRepository clienteRepository)
        {
            this._reservaRepository = reservaRepository;
            _mesaRepository = mesaRepository;
            _clienteRepository = clienteRepository;
        }
        public async Task<CreateReservaResponse> Handle(CreateReservaCommand request, CancellationToken cancellationToken)
        {
            var mesas = await _mesaRepository.ObtenerTodas();
            var mesaDisponible = mesas.Where(m => m.EstaDisponible());
            var clienteReserva = await _clienteRepository.GetClienteByNumero(request.NumeroCliente);
            var fechaHoraActual = DateTime.Now;

            if (clienteReserva == null)
            {
                throw new ArgumentNullException($"No se encontró el cliente número: {request.NumeroCliente}");
            }
            bool puedeReservar = PuedeReservar(request.FechaHora, clienteReserva.Categoria.GetNombre());
            if (!puedeReservar)
            {
                throw new Exception("No esta habilitado para reservar");
            }
            if (mesaDisponible.Any())
            {
                await this._reservaRepository.CrearReserva(new Domain.Reserva(1, request.FechaHora, clienteReserva));
            }
            throw new NotImplementedException();
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
            return (fechaReserva - fechaHoraActual).TotalHours >= horasMinimasRequeridas;
        }
    }
}
