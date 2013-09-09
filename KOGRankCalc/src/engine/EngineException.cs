using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace KOGRankCalc
{
    [Serializable()]
    public class EngineException : System.Exception
    {
        public EngineException() : base() { }
        public EngineException(string message) : base(message) { }
        public EngineException(string message, System.Exception inner) : base(message, inner) { }

        // A constructor is needed for serialization when an
        // exception propagates from a remoting server to the client. 
        protected EngineException(System.Runtime.Serialization.SerializationInfo info,
            System.Runtime.Serialization.StreamingContext context) { }
    }
}
