namespace HP.Tucson.Domain.Entities
{
    public class Categoria
    {
        private int Id { get; set; }
        public string Nombre { get; private set; }

        public Categoria(int id, string nombre)
        {
            Id = id;
            Nombre = nombre;
        }
        public int GetId()
        {
            return Id;
        }
    }
}
