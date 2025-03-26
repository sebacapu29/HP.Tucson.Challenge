using HP.Tucson.Application.FeatureReserva.Handlers;
using HP.Tucson.Application.FeatureReserva.Models.Commands;
using HP.Tucson.Application.Services.Interfaces;
using HP.Tucson.Domain.Entities;
using HP.Tucson.Domain.Interfaces;
using HP.Tucson.Tests.Mocks;
using Moq;

namespace HP.Tucsone.Tests.Application.TestReserva
{
    public class CreateReservaHandlerTest
    {
        private readonly Mock<IReservaRepository> _mockReservaRepository;
        private readonly Mock<IMesaRepository> _mockMesaRepository;
        private readonly Mock<IClienteRepository> _mockClienteRepository;
        private readonly Mock<IClienteEnEsperaService> _mockClienteEnEsperaService;
        private readonly CreateReservaCommandHandler _handler;

        public CreateReservaHandlerTest()
        {
            _mockReservaRepository = new Mock<IReservaRepository>();
            _mockMesaRepository = new Mock<IMesaRepository>();
            _mockClienteRepository = new Mock<IClienteRepository>();
            _mockClienteEnEsperaService = new Mock<IClienteEnEsperaService>();
        }

        [Fact]
        public async Task Handle_ReservaExitosa_DeberiaRetornarMensajeExitoso()
        {
            var request = new CreateReservaCommand { NumeroCliente = 1, FechaHora = DateTime.Now.AddDays(1) };
            var reservaId = 1;
            var reserva = new Reserva(reservaId, request.FechaHora, MocksCliente.GetValidCliente(), 2);
            var mesaDisponible = new Mesa(1, 2);
            _mockMesaRepository.Setup(m => m.ObtenerTodas()).Returns(new List<Mesa> { mesaDisponible });
            _mockClienteRepository.Setup(c => c.GetClienteByNumero(request.NumeroCliente)).ReturnsAsync(MocksCliente.GetValidCliente());
            _mockReservaRepository.Setup(r => r.GenerarId()).ReturnsAsync(reservaId);
            _mockReservaRepository.Setup(r => r.CrearReserva(It.IsAny<Reserva>())).ReturnsAsync(reserva);
            var createReservaCommandHandler = new CreateReservaCommandHandler(_mockReservaRepository.Object,
                                                                              _mockMesaRepository.Object,
                                                                              _mockClienteRepository.Object,
                                                                              _mockClienteEnEsperaService.Object);

            var result = await createReservaCommandHandler.Handle(request, CancellationToken.None);

            Assert.NotNull(result);
            Assert.Equal($"Reserva realizada con éxito en mesa {reserva.NumeroMesa}", result.Mensaje);
            _mockMesaRepository.Verify(m => m.OcuparMesa(mesaDisponible), Times.Once);
        }
    }
}
