using System;

namespace RusIdentifiers.Exceptions
{
    /// <summary><inheritdoc/></summary>
    public class RusIdentifiersArgumentNullException : ArgumentNullException
    {
        /// <summary><inheritdoc/></summary>
        public RusIdentifiersArgumentNullException()
        {
        }

        /// <summary><inheritdoc/></summary>
        public RusIdentifiersArgumentNullException(string paramName) : base(paramName)
        {
        }

        /// <summary><inheritdoc/></summary>
        public RusIdentifiersArgumentNullException(string message, Exception innerException) : base(message, innerException)
        {
        }

        /// <summary><inheritdoc/></summary>
        public RusIdentifiersArgumentNullException(string paramName, string message) : base(paramName, message)
        {
        }
    }
}
