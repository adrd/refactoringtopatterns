using System;
using System.Runtime.Serialization;

namespace UnifyInterfacesWithAdapter.InitialCode
{
    [Serializable]
    public class RuntimeException : Exception
    {
        public RuntimeException()
        {
        }

        public RuntimeException(String message) : base(message)
        {
        }

        public RuntimeException(String message, Exception innerException) : base(message, innerException)
        {
        }

        protected RuntimeException(SerializationInfo info, StreamingContext context) : base(info, context)
        {
        }
    }
}