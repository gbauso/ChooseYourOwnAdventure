using System;

namespace ChooseYourOwnAdventure.CrossCutting.Exceptions
{
    public class InvalidJsonException : Exception
    {
        public InvalidJsonException()
        {

        }
        public InvalidJsonException(string message) : base(message)
        {

        }

        public InvalidJsonException(string[] message) : base(string.Join(";", message))
        {

        }
    }
}
