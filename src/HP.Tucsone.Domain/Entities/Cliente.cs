using HP.Tucsone.Domain.Entities;

namespace HP.Tucsone.Domain
{
    public class Cliente
    {
        public string? Nombre { get; private set; }
        public Categoria? Categoria { get; private set; }
        public int Numero { get; private set; }

        private Cliente() { }
        public Cliente(int numero, string nombre, Categoria categoria)
        {
            Numero = numero;
            Nombre = nombre;
            Categoria = categoria;
        }
    }
}
