namespace HP.Tucsone.Domain.Constants
{
    public static class MockCliente
    {
        public static List<Cliente> GetClientesMock()
        {
            var categoriaClassic = MockCategorias.categorias.Where(c => c.GetNombre().ToLower() == "classic").First();
            var categoriaGold = MockCategorias.categorias.Where(c => c.GetNombre().ToLower() == "classic").First();
            var categoriaDiamond = MockCategorias.categorias.Where(c => c.GetNombre().ToLower() == "classic").First();
            var categoriaPlatinum = MockCategorias.categorias.Where(c => c.GetNombre().ToLower() == "classic").First();

            return new List<Cliente>()
            {
                new Cliente(1,"Jose", categoriaClassic),
                new Cliente(1,"Jose", categoriaGold),
                new Cliente(1,"Jose", categoriaDiamond),
                new Cliente(1,"Jose", categoriaPlatinum),
            };
        }
    }
}
