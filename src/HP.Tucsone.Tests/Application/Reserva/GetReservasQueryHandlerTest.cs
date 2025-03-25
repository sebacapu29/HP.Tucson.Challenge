using HP.Tucsone.Application.Cliente.Handlers;
using HP.Tucsone.Application.Cliente.Models.Queries;
using HP.Tucsone.Application.Reserva.Handlers;
using HP.Tucsone.Application.Reserva.Models.Queries;
using HP.Tucsone.Application.Services.Interfaces;
using HP.Tucsone.Domain.Interfaces;
using HP.Tucsone.Tests.Mocks;
using Moq;

namespace HP.Tucsone.Tests.Application.Reserva
{
    public class GetReservasQueryHandlerTest
    {
        private readonly Mock<IReservaRepository> _mockReservaRepository;
        public GetReservasQueryHandlerTest()
        {
            _mockReservaRepository = new Mock<IReservaRepository>();
        }
        [Fact]
        public async Task Get_Clientes_En_Espera_Ok()
        {
            _mockReservaRepository.Setup(rr => rr.ListarReservas()).Returns(Task.FromResult(MockReserva.GetValidListReservas()));

            var mockGetReservaQueryHandler = new GetReservasQueryHandler(_mockReservaRepository.Object);
            var query = new GetReservasQuery();
            var result = await mockGetReservaQueryHandler.Handle(query, CancellationToken.None);
            Assert.NotNull(result);

            _mockReservaRepository.Verify(rr => rr.ListarReservas(), Times.Once);
        }
    }
}
