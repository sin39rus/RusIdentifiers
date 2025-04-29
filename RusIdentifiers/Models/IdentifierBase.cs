using System.Xml;
using System.Xml.Schema;
using System.Xml.Serialization;

namespace RusIdentifiers.Models
{
    /// <summary>Базовый класс идентификаторов России</summary>
    public abstract class IdentifierBase : IXmlSerializable
    {
        #region IXmlSerializable
        /// <inheritdoc/>
        public abstract XmlSchema GetSchema();
        /// <inheritdoc/>
        public abstract void ReadXml(XmlReader reader);
        /// <inheritdoc/>
        public abstract void WriteXml(XmlWriter writer);
        #endregion

        /// <inheritdoc/>
        public abstract override string ToString();
    }
}
