namespace HP.Tucson.Application.Exceptions
{
    public class ClienteNotFoundException : Exception
    {
        public ClienteNotFoundException(string mensaje) : base(mensaje)
        {
        }
    }
}
