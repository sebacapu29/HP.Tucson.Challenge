using HP.Tucson.Domain.Entities;

namespace HP.Tucson.Domain.Constants
{
    public static class MockMesa
    {
        public static List<Mesa> GetMesas()
        {
            var listaMesas = new List<Mesa>();
            for (int i = 1; i <= 40; i++) { 
                if( i <= 18)
                {
                    listaMesas.Add(new Mesa(i, 2));
                }
                else if( i > 18 && i <= 33)
                {
                    listaMesas.Add(new Mesa(i,4));
                }
                else
                {
                    listaMesas.Add(new Mesa(i, 6));
                }
            }
            return listaMesas;  
        }
    }
}
