using HP.Tucson.Application.FeatureMesa.Models.Responses;

namespace HP.Tucson.Tests.Mocks
{
    public class MocksMesa
    {
        public static LiberarMesaResponse GetLiberarMesaResponseValid()
        {
            return new LiberarMesaResponse
            {
                Mensaje = "Mesa liberada"
            };
        }
    }
}
