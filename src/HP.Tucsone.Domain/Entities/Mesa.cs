namespace HP.Tucsone.Domain.Entities
{
    public class Mesa
    {
        public int Numero { get;  private set; }
        public int Cubiertos { get;  private set; }
        public bool Disponible { get; private set; }

        private Mesa() { }
        public Mesa(int numero, int cubiertos)
        {
            Numero = numero;
            Cubiertos = cubiertos;
            Disponible = true;
        }

        public void Ocupar()
        {
            Disponible = false;
        }
        public void Liberar()
        {
            Disponible = true;
        }
    }
}
