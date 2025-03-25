namespace HP.Tucsone.Application.Constants
{
    public static class MockMesa
    {
        public static List<Domain.Mesa> GetMesas()
        {
            var listaMesas = new List<Domain.Mesa>();
            for (int i = 1; i <= 40; i++) { 
                if( i <= 18)
                {
                    listaMesas.Add(new Domain.Mesa(i, 2));
                }
                else if( i > 18 && i <= 33)
                {
                    listaMesas.Add(new Domain.Mesa(i,4));
                }
                else
                {
                    listaMesas.Add(new Domain.Mesa(i, 6));
                }
            }
            return listaMesas;  
        }
    }
}
