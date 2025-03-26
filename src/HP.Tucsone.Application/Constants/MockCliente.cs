using HP.Tucsone.Domain.Entities;

namespace HP.Tucsone.Application.Constants
{
    public static class MockCliente
    {
        public static List<Cliente> GetClientesMock()
        {
            var categoriaClassic = MockCategorias.categorias.Where(c => c.Nombre.ToLower() == "classic").First();
            var categoriaGold = MockCategorias.categorias.Where(c => c.Nombre.ToLower() == "gold").First();
            var categoriaDiamond = MockCategorias.categorias.Where(c => c.Nombre.ToLower() == "diamond").First();
            var categoriaPlatinum = MockCategorias.categorias.Where(c => c.Nombre.ToLower() == "platinum").First();

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
