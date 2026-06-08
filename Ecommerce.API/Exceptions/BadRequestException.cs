namespace Ecommerce.API.Exceptions
{
    public class BadRequestException : Exception
    {
        public BadRequestException() { }


        public BadRequestException(string Message) : base(Message)
        { }
    }
}
