using HP.Tucsone.Application.Cliente.Models.Responses;

namespace HP.Tucsone.Tests.Mocks
{
    public class MocksCliente
    {
        public static List<GetClienteEsperaResponse> GetClientesEsperaResponseValid() => new List<GetClienteEsperaResponse> {
            new GetClienteEsperaResponse { Categoria = "classic", Nombre = "jose", NumeroCliente = 1
            } 
        };
        public static List<GetClienteEsperaResponse> GetClientesEsperaResponseNoValid() => new List<GetClienteEsperaResponse> {
            new GetClienteEsperaResponse { Categoria = null, Nombre = null, NumeroCliente = 1
            }
        };
    }
}
