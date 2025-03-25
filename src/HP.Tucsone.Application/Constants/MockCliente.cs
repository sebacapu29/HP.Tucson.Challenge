namespace HP.Tucsone.Application.Constants
{
    public static class MockCliente
    {
        public static List<Domain.Cliente> GetClientesMock()
        {
            var categoriaClassic = MockCategorias.categorias.Where(c => c.Nombre.ToLower() == "classic").First();
            var categoriaGold = MockCategorias.categorias.Where(c => c.Nombre.ToLower() == "gold").First();
            var categoriaDiamond = MockCategorias.categorias.Where(c => c.Nombre.ToLower() == "diamond").First();
            var categoriaPlatinum = MockCategorias.categorias.Where(c => c.Nombre.ToLower() == "platinum").First();

            return new List<Domain.Cliente>()
            {
                new Domain.Cliente(1,"Jose", categoriaClassic),
                new Domain.Cliente(2,"Juan", categoriaGold),
                new Domain.Cliente(3,"Pedro", categoriaDiamond),
                new Domain.Cliente(4,"Esteban", categoriaPlatinum),
            };
        }
    }
}
