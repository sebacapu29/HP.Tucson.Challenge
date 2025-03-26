using HP.Tucsone.Domain.Entities;

namespace HP.Tucsone.Application.Constants
{
    public class MockCategorias
    {
        public static List<Categoria> categorias = new List<Categoria>{
            new Categoria(1,"Classic"),
            new Categoria(2, "Gold"),
            new Categoria(3, "Diamond"),
            new Categoria(4, "Platinum")
        };
    }
}
