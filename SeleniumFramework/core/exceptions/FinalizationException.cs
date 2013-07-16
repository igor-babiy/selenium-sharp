using System;
using System.Collections.Generic;
using System.Text;

namespace SeleniumFramework.Core.Exceptions
{
    class FinalizationException : Exception
    {
     
        public FinalizationException(): base("Exception in finalization block!") { }

        public FinalizationException(string message) : base("Exception in finalization block! " + message) { }
    
    }
   
}
