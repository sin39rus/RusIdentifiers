using System.Xml;
using System.Xml.Schema;
using System.Xml.Serialization;

namespace RusIdentifiers.Models
{
    /// <summary>Базовый класс идентификаторов России</summary>
    public abstract class IdentifierBase : IXmlSerializable
    {
        /// <summary>Значение идентификатора</summary>
        protected string value;

        #region IXmlSerializable
        /// <inheritdoc/>
        public XmlSchema GetSchema()
        {
            return null;
        }

        /// <inheritdoc/>
        public void ReadXml(XmlReader reader)
        {
            reader.MoveToContent();
            value = reader.GetAttribute("value");
            reader.Read();
        }

        /// <inheritdoc/>
        public void WriteXml(XmlWriter writer)
        {
            writer.WriteAttributeString("value", value.ToString());
        }
        #endregion

        /// <inheritdoc/>
        public override string ToString() => value;
    }
}
