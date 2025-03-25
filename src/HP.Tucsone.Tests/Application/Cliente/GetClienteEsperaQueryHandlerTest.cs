using HP.Tucsone.Application.FeatureCliente.Handlers;
using HP.Tucsone.Application.FeatureCliente.Models.Queries;
using HP.Tucsone.Application.Services.Interfaces;
using HP.Tucsone.Tests.Mocks;
using Moq;

namespace HP.Tucsone.Tests.Application.Cliente
{
    public class GetClienteEsperaQueryHandlerTest
    {
        private readonly Mock<IClienteEnEsperaService> _mockClienteEnEsperaService;
        public GetClienteEsperaQueryHandlerTest()
        {
            _mockClienteEnEsperaService = new Mock<IClienteEnEsperaService>();
        }
        [Fact]
        public async Task Get_Clientes_En_Espera_Ok()
        {
            _mockClienteEnEsperaService.Setup(ce => ce.ObtenerClientesEnEspera()).Returns(Task.FromResult(MocksCliente.GetClientesEsperaResponseValid()));

            var taskResult = _mockClienteEnEsperaService.Object.ObtenerClientesEnEspera();
            var result = await taskResult;
            Assert.NotNull(taskResult);
            _mockClienteEnEsperaService.Verify(er => er.ObtenerClientesEnEspera(), Times.Once);
        }
        [Fact]
        public async Task Get_Clientes_En_Espera_Fail()
        {
            _mockClienteEnEsperaService.Setup(ce => ce.ObtenerClientesEnEspera()).Throws(new NullReferenceException());
            var mockGetClienteEsperaQueryHandler = new GetClienteEsperaQueryHandler(_mockClienteEnEsperaService.Object);
            var query = new GetClienteEsperaQuery() { NumeroCliente = 1 };
            await Assert.ThrowsAsync<NullReferenceException>(() => mockGetClienteEsperaQueryHandler.Handle(query, CancellationToken.None));

            _mockClienteEnEsperaService.Verify(er => er.ObtenerClientesEnEspera(), Times.Once);
        }
    }
}
    

