using System;
using System.Collections.Generic;
using System.Text;

namespace SeleniumFramework.Core.Exceptions
{
    class InitializationException : Exception
    {
        public InitializationException(): base("Exception in initialization block!") { }

        public InitializationException(string message) : base("Exception in initialization block! " + message) { }
    }
}
