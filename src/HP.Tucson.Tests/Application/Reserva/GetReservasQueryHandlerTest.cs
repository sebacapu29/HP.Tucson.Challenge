﻿using HP.Tucson.Application.FeatureReserva.Handlers;
using HP.Tucson.Application.FeatureReserva.Models.Queries;
using HP.Tucson.Domain.Interfaces;
using HP.Tucson.Tests.Mocks;
using Moq;

namespace HP.Tucsone.Tests.Application.TestReserva
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
            _mockReservaRepository.Setup(rr => rr.ListarReservas()).Returns(Task.FromResult(MocksReserva.GetValidListReservas()));

            var mockGetReservaQueryHandler = new GetReservasQueryHandler(_mockReservaRepository.Object);
            var query = new GetReservasQuery();
            var result = await mockGetReservaQueryHandler.Handle(query, CancellationToken.None);
            Assert.NotNull(result);

            _mockReservaRepository.Verify(rr => rr.ListarReservas(), Times.Once);
        }
    }
}
