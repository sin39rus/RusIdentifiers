using System;
using System.Xml;
using System.Xml.Schema;

namespace RusIdentifiers
{
    /// <summary>КПП (код причины постановки на учёт) — это девятизначный идентификатор, который включает код региона, номер ИФНС, код основания постановки на учёт и порядковый номер постановки на учёт. </summary>
    [Serializable]
    public class Kpp : IdentifierBase
    {
        private string _value;
        private Kpp() { }
        public Kpp(string value)
        {
            value = value?.Trim();

            if (IsValid(value))
                _value = value;
            else
                throw new ArgumentException($"Значение \"{value}\" не является номером КПП.");
        }
        private static bool IsValid(string value)
        {
            if (string.IsNullOrEmpty(value))
                throw new ArgumentNullException(nameof(value));
            if (value.Length != 9 || !long.TryParse(value, out _))
                return false;
            return true;
        }
        public override XmlSchema GetSchema()
        {
            return null;
        }
        public override void ReadXml(XmlReader reader)
        {
            reader.MoveToContent();
            _value = reader.GetAttribute("value");
            reader.Read();
        }
        public override void WriteXml(XmlWriter writer)
        {
            writer.WriteAttributeString("value", _value);
        }
        public override string ToString() =>
            _value;

        public static implicit operator string(Kpp value)
        {
            return value.ToString();
        }
        public static implicit operator Kpp(string value)
        {
            return new Kpp(value);
        }
    }
}
