using System;

namespace ZooplaApp.CustomException
{
    public class CustomExceptions : Exception
    {
        public ExceptionType type;

        // Constructor of custom exception
        public CustomExceptions(string message,ExceptionType type) : base(message)
        {
            this.type = type;
        }
    }

    // Custom exception types
    public enum ExceptionType
    {
        COULD_NOT_SEND_EMAIL,
        NO_INTERNET_CONNECTIONS,
        SCREENSHOT_NOT_CAPTURED,
        TIME_AND_DATE_NOT_FOUND
    }
}
