namespace Ecommerce.API.Exceptions
{
    public class NotFoundException : Exception
    {

        public NotFoundException() { }

        public NotFoundException (string Message) : base(Message) { }
    }
}
