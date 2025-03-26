using HP.Tucson.Application.Exceptions;
using HP.Tucson.Application.FeatureMesa.Handlers;
using HP.Tucson.Application.FeatureMesa.Models.Commands;
using HP.Tucson.Application.Services.Interfaces;
using HP.Tucson.Domain.Entities;
using HP.Tucson.Domain.Interfaces;
using HP.Tucson.Tests.Mocks;
using Moq;

namespace HP.Tucsone.Tests.Application.TestLibrerarMesa
{
    public class LiberarMesaCommandHandlerTest
    {
        private readonly Mock<IMesaRepository> _mockMesaRepository;
        private readonly Mock<IClienteEnEsperaService> _mockClienteEnEsperaService;
        private readonly Mock<IReservaRepository> _mockReservaRepository;
        private readonly Mock<IClienteRepository> _mockClienteRepository;
        public LiberarMesaCommandHandlerTest()
        {
            _mockMesaRepository = new Mock<IMesaRepository>();
            _mockClienteEnEsperaService = new Mock<IClienteEnEsperaService>();
            _mockReservaRepository = new Mock<IReservaRepository>();
            _mockClienteRepository = new Mock<IClienteRepository>();
        }
        [Fact]
        public async Task LiberarMesa_Error()
        {
            _mockClienteEnEsperaService.Setup(ce => ce.ObtenerClientesEnEspera()).Throws(new MesaNotFoundException("No se encontró la mesa especificada"));
            var mockLiberarMesaCommandHandler = new LiberarMesaCommandHandler(_mockMesaRepository.Object, 
                                                                                _mockClienteEnEsperaService.Object, 
                                                                                _mockReservaRepository.Object,
                                                                                _mockClienteRepository.Object);
            var command = new LiberarMesaCommand() { NumeroMesa = 1 };
            await Assert.ThrowsAsync<MesaNotFoundException>(() => mockLiberarMesaCommandHandler.Handle(command, CancellationToken.None));

            _mockClienteEnEsperaService.Verify(er => er.ObtenerClientesEnEspera(), Times.Never);
        }
        [Fact]
        public async Task LiberarMesa_Y_Asignar_A_Cliente_En_Espera_Ok()
        {
            string mensajeEsperado = $"Mesa liberada y se asignó al cliente en espera jose";
            _mockClienteEnEsperaService.Setup(ce => ce.ObtenerClientesEnEspera()).Returns(Task.FromResult(MocksCliente.GetClientesEsperaResponseValid()));
            _mockMesaRepository.Setup(mr => mr.ObtenerMesaPorNumero(It.IsAny<int>())).Returns(new Mesa(1, 2));
            _mockReservaRepository.Setup(rr => rr.GenerarId()).Returns(Task.FromResult(1));
            _mockReservaRepository.Setup(rr => rr.CrearReserva(It.IsAny<Reserva>())).Returns(Task.FromResult(MocksReserva.GetValidListReservas().First()));
            _mockClienteEnEsperaService.Setup(cr => cr.EliminarClienteEnEspera(It.IsAny<Cliente>())).Returns(Task.FromResult(MocksCliente.GetValidCliente()));
            _mockClienteRepository.Setup(cr => cr.GetCategoriaCliente(It.IsAny<string>())).Returns(Task.FromResult(new Categoria(1, "classic")));

            var mockLiberarMesaCommandHandler = new LiberarMesaCommandHandler(_mockMesaRepository.Object,
                                                                             _mockClienteEnEsperaService.Object,
                                                                             _mockReservaRepository.Object,
                                                                             _mockClienteRepository.Object);
            var command = new LiberarMesaCommand() { NumeroMesa = 1 };
            var mesaLiberadaResponse = await mockLiberarMesaCommandHandler.Handle(command, CancellationToken.None);
            Assert.Equal(mensajeEsperado.ToLower(), mesaLiberadaResponse.Mensaje.ToLower());

            _mockClienteEnEsperaService.Verify(ce => ce.ObtenerClientesEnEspera(), Times.Once);
            _mockMesaRepository.Verify(mr => mr.ObtenerMesaPorNumero(1), Times.Once);
            _mockReservaRepository.Verify(rr => rr.GenerarId(), Times.Once);
            _mockClienteRepository.Verify(cr => cr.GetCategoriaCliente(It.IsAny<string>()), Times.Once);
            _mockReservaRepository.Verify(rr => rr.CrearReserva(It.IsAny<Reserva>()), Times.Once);
        }
    }
}
