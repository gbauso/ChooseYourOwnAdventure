using System;

namespace ChooseYourOwnAdventure.CrossCutting.Exceptions
{
    public class NotFoundException : Exception
    {
        public NotFoundException(string message) : base(message)
        {

        }

        public NotFoundException() : base()
        {

        }
    }
}
