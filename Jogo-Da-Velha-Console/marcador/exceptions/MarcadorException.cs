using System;

namespace exceptions
{
    class MarcadorException : ApplicationException
    {
        public MarcadorException(string message) 
            : base(message)
        {

        }
    }
}
