using System;

namespace RusIdentifiers.Exceptions
{
    /// <summary><inheritdoc/></summary>
    public class RusIdentifiersArgumentException : ArgumentException
    {

        /// <summary><inheritdoc/></summary>
        public RusIdentifiersArgumentException()
        {
        }

        /// <summary><inheritdoc/></summary>
        public RusIdentifiersArgumentException(string message) : base(message)
        {
        }

        /// <summary><inheritdoc/></summary>
        public RusIdentifiersArgumentException(string message, Exception innerException) : base(message, innerException)
        {
        }

        /// <summary><inheritdoc/></summary>
        public RusIdentifiersArgumentException(string message, string paramName) : base(message, paramName)
        {
        }

        /// <summary><inheritdoc/></summary>
        public RusIdentifiersArgumentException(string message, string paramName, Exception innerException) : base(message, paramName, innerException)
        {
        }
    }
}
