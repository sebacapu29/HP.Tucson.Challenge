namespace HP.Tucsone.Domain
{
    public class Mesa
    {
        public int Id { get; private set; }
        public int Numero { get; private set; }
        public int Cubiertos { get; private set; }
        private bool Disponible { get; set; }

        private Mesa() { }
        public Mesa(int numero, int cubiertos)
        {
            this.Numero = numero;
            this.Disponible = true;
            this.Cubiertos = cubiertos;
        }
        public bool EstaDisponible()
        {
            return this.Disponible;
        }

        public void Ocupar()
        {
            this.Disponible = true;
        }

        public void Liberar()
        {
            this.Disponible = false;
        }
    }
}
