namespace HP.Tucsone.Domain
{
    public class Mesa
    {
        public int Id { get; private set; }
        public int Numero { get; private set; }
        public int Cubiertos { get; private set; }
        private bool Disponible { get; set; }

        private Mesa() { }
        public Mesa(int numero)
        {
            this.Numero = numero;
            Disponible = true;
        }
        public bool EstaDisponible()
        {
            return Disponible;
        }

        public void Ocupar()
        {
            Disponible = true;
        }

        public void Liberar()
        {
            Disponible = false;
        }
    }
}
