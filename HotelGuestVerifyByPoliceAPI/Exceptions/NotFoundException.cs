namespace HotelGuestVerifyByPoliceAPI.Exceptions
{
    public class NotFoundException : Exception
    {
        public NotFoundException(string message): base(message) 
        { 
            
        }

    }

    public class BadRequestException : Exception
    {
        public BadRequestException(string message) : base(message)
        {

        }

    }

    public class NullReferenceException : Exception
    {
        public NullReferenceException(string message) : base(message)
        {

        }

    }
}
