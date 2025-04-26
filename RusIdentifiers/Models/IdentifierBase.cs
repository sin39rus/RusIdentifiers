using System.Xml;
using System.Xml.Schema;
using System.Xml.Serialization;

namespace RusIdentifiers
{
    public abstract class IdentifierBase : IXmlSerializable
    {
        #region IXmlSerializable
        public abstract XmlSchema GetSchema();
        public abstract void ReadXml(XmlReader reader);
        public abstract void WriteXml(XmlWriter writer); 
        #endregion
        public abstract override string ToString();
    }
}
