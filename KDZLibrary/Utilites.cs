using System;

namespace KDZLibrary
{
    public class Utilites
    {
        [Serializable]
        public class ErrorException : Exception
        {
            public ErrorException() { }
            public ErrorException(string message) : base(message) { }
            public ErrorException(string message, Exception inner) : base(message, inner) { }
            protected ErrorException(
              System.Runtime.Serialization.SerializationInfo info,
              System.Runtime.Serialization.StreamingContext context) : base(info, context) { }
        }

        static internal Random random = new Random();
    }
}
