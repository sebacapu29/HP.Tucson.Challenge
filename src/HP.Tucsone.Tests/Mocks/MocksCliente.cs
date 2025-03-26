using HP.Tucsone.Application.FeatureCliente.Models.Responses;
using HP.Tucsone.Domain.Entities;

namespace HP.Tucsone.Tests.Mocks
{
    public class MocksCliente
    {
        public static List<GetClienteEsperaResponse> GetClientesEsperaResponseValid()
        {
            return new List<GetClienteEsperaResponse>
            {
                new GetClienteEsperaResponse
                {
                    Categoria = "classic", Nombre = "jose", NumeroCliente = 1
                }
            };
        }
        public static List<GetClienteEsperaResponse> GetClientesEsperaResponseNoValid()
        {
            return new List<GetClienteEsperaResponse>
            {
                new GetClienteEsperaResponse
                {
                    Categoria = null, Nombre = null, NumeroCliente = 1
                }
            };
        }
        public static Cliente GetValidCliente()
        {
            return new Cliente(1, "jose", new Categoria(1, "classic"));
        }
    }
}
