namespace HP.Tucsone.Domain.Entities
{
    public class Categoria
    {
        private int Id { get; set; }
        private string Nombre { get; set; }

        public Categoria(int id, string Nombre)
        {
            this.Id = id;
            this.Nombre = Nombre;
        }
        public int GetId()
        {
            return Id;
        }
        public string GetNombre()
        {
            return Nombre;
        }
    }
}
