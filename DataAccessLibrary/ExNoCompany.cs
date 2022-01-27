using System;
using System.Runtime.Serialization;

namespace DataAccessLibrary
{
    [Serializable]
    public class ExNoCompany : Exception
    {
        public ExNoCompany()
        {
        }

        public ExNoCompany(string message) : base(message)
        {
        }

        public ExNoCompany(string message, Exception innerException) : base(message, innerException)
        {
        }

        protected ExNoCompany(SerializationInfo info, StreamingContext context) : base(info, context)
        {
        }
    }
}