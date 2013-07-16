using System;
using System.Collections.Generic;
using System.Text;

namespace SeleniumFramework.Core.Exceptions
{
    class TestException : Exception
    {
        public TestException() : base("Exception in test block!") { }

        public TestException(string message) : base("Exception in test block! " + message) { }
    }
}
