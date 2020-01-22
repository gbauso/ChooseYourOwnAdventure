using System;

namespace ChooseYourOwnAdventure.CrossCutting.Exceptions
{
    public class ValidationException : Exception
    {
        public ValidationException() : base()
        {

        }
        public ValidationException(string message) : base(message)
        {

        }

        public ValidationException(string[] message) : base(string.Join(";", message))
        {

        }
    }
}
