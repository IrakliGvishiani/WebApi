namespace Ecommerce.API.Exceptions
{
    public class InternalServerException : Exception
    {
        public InternalServerException() { }


        public InternalServerException(string message) : base(message) { }
    }
}
