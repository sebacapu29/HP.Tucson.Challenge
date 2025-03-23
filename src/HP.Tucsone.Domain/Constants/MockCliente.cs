namespace HP.Tucsone.Domain.Constants
{
    public static class MockCliente
    {
        public static List<Cliente> GetClientesMock()
        {
            var categoriaClassic = MockCategorias.categorias.Where(c => c.GetNombre().ToLower() == "classic").First();
            var categoriaGold = MockCategorias.categorias.Where(c => c.GetNombre().ToLower() == "gold").First();
            var categoriaDiamond = MockCategorias.categorias.Where(c => c.GetNombre().ToLower() == "diamond").First();
            var categoriaPlatinum = MockCategorias.categorias.Where(c => c.GetNombre().ToLower() == "platinum").First();

            return new List<Cliente>()
            {
                new Cliente(1,"Jose", categoriaClassic),
                new Cliente(2,"Juan", categoriaGold),
                new Cliente(3,"Pedro", categoriaDiamond),
                new Cliente(4,"Esteban", categoriaPlatinum),
            };
        }
    }
}
