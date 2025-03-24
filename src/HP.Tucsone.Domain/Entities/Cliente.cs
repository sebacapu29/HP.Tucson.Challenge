using HP.Tucsone.Domain.Entities;

namespace HP.Tucsone.Domain
{
    public class Cliente
    {
        public int Id { get; private set; }
        public string Nombre { get; private set; }
        public Categoria Categoria { get; private set; }
        public int Numero { get; private set; }

        private Cliente() { }
        public Cliente(int numero, string nombre, Categoria categoria)
        {
            this.Nombre = Nombre;
            this.Categoria = categoria;
            this.Numero = numero;
        }
    }
}
