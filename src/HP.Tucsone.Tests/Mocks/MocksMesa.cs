using HP.Tucsone.Application.FeatureMesa.Models.Responses;

namespace HP.Tucsone.Tests.Mocks
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
