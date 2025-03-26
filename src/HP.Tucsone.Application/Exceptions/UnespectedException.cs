namespace HP.Tucsone.Application.Exceptions
{
    public class UnespectedException: Exception
    {
        public UnespectedException(string mensaje, Exception ex):base(mensaje, ex)
        {
            
        }
    }
}
