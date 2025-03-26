using HP.Tucson.Application.FeatureReserva.Models.Responses;
using HP.Tucson.Domain.Entities;

namespace HP.Tucson.Tests.Mocks
{
    public class MocksReserva
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
                new Reserva(1,DateTime.Now,new Cliente(1,"",new Categoria(1,"")),1)
            };
        }
    }
}
