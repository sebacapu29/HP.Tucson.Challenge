using HP.Tucsone.Application.FeatureReserva.Models.Responses;
using HP.Tucsone.Domain;
using HP.Tucsone.Domain.Entities;

namespace HP.Tucsone.Tests.Mocks
{
    public class MockReserva
    {
        public static List<GetReservasResponse> GetValidListReservasResponse()
        {
            return new List<GetReservasResponse>
            {
                new GetReservasResponse
                {
                    FechaHora = DateTime.Now,
                    NumeroCliente = 1
                }
            };
        }
        public static List<GetReservasResponse> GetNotValidListReservasResponse()
        {
            return new List<GetReservasResponse>
            {
                new GetReservasResponse
                {
                    FechaHora = DateTime.Now,
                    NumeroCliente = null
                }
            };
        }
        public static List<GetReservasResponse> GetNotValidListReservasResponseNull()
        {
            return null;            
        }
        public static IReadOnlyList<Reserva> GetValidListReservas()
        {
            return new List<Reserva>
            {
                new Reserva(1,DateTime.Now,new Cliente(1,"",new Domain.Entities.Categoria(1,"")),1)
            };
        }
    }
}
