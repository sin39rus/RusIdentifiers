using RusIdentifiers.Exceptions;
using System;
using System.Xml;
using System.Xml.Schema;

namespace RusIdentifiers.Models.FNS
{
    /// <summary>КПП (код причины постановки на учёт) — это девятизначный идентификатор, который включает код региона, номер ИФНС, код основания постановки на учёт и порядковый номер постановки на учёт. </summary>
    [Serializable]
    public class Kpp : IdentifierBase
    {
        private string _value;
        private Kpp() { }

        /// <summary>КПП (код причины постановки на учёт)</summary>
        /// <param name="value">Значение</param>
        /// <exception cref="RusIdentifiersArgumentException"></exception>
        public Kpp(string value)
        {
            value = value?.Trim();

            if (IsValid(value))
                _value = value;
            else
                throw new RusIdentifiersArgumentException($"Значение \"{value}\" не является номером КПП.");
        }
        /// <summary>Проверка строки на значение КПП</summary>
        /// <param name="value">Строка</param>
        /// <returns>true - если строка соответствует КПП<br></br>false - если строка не соответствует КПП</returns>
        public static bool IsValid(string value)
        {
            if (string.IsNullOrEmpty(value))
                throw new RusIdentifiersArgumentNullException(nameof(value));
            if (value.Length != 9 || !long.TryParse(value, out _))
                return false;
            return true;
        }

        /// <inheritdoc/>
        public override XmlSchema GetSchema()
        {
            return null;
        }

        /// <inheritdoc/>
        public override void ReadXml(XmlReader reader)
        {
            reader.MoveToContent();
            _value = reader.GetAttribute("value");
            reader.Read();
        }

        /// <inheritdoc/>
        public override void WriteXml(XmlWriter writer)
        {
            writer.WriteAttributeString("value", _value);
        }
        
        /// <inheritdoc/>
        public override string ToString() =>
            _value;

        /// <inheritdoc/>
        public override bool Equals(object obj)
        {
            return obj is Kpp kpp &&
                   _value == kpp._value;
        }

        /// <inheritdoc/>
        public override int GetHashCode()
        {
            return _value.GetHashCode();
        }

        ///<summary>Преобразование значения в строку</summary>
        public static implicit operator string(Kpp value)
        {
            return value.ToString();
        }

        ///<summary>Преобразование строки в значение</summary>
        public static implicit operator Kpp(string value)
        {
            return new Kpp(value);
        }

        /// <inheritdoc/>
        public static bool operator ==(Kpp lhs, Kpp rhs)
        {
            return lhs.Equals(rhs);
        }

        /// <inheritdoc/>
        public static bool operator !=(Kpp lhs, Kpp rhs)
        {
            return !lhs.Equals(rhs);
        }
    }
}
