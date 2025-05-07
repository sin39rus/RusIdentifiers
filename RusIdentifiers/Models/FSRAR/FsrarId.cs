using RusIdentifiers.Exceptions;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml;
using System.Xml.Schema;

namespace RusIdentifiers.Models.FSRAR
{
    /// <summary>ФСРАР ID – уникальный идентификатор организации в ФСРАР.</summary>
    public class FsrarId : IdentifierBase
    {
        private readonly string _value;

        private FsrarId() { }

        /// <summary>ФСРАР ID</summary>
        /// <param name="value">Значение</param>
        /// <exception cref="ArgumentNullException"></exception>
        /// <exception cref="RusIdentifiersArgumentException"></exception>
        public FsrarId(string value)
        {
            value = value?.Trim();
            if (IsValid(value))
                _value = value;
            else
                throw new RusIdentifiersArgumentException($"Значение \"{value}\" не является номером ФСРАР ID.");
        }

        /// <summary>Проверка строки на значение ФСРАР ID</summary>
        /// <param name="value">Строка</param>
        /// <returns>true - если строка соответствует ФСРАР ID<br></br>false - если строка не соответствует ФСРАР ID</returns>
        /// <exception cref="RusIdentifiersArgumentNullException"></exception>
        public static bool IsValid(string value)
        {
            if (string.IsNullOrEmpty(value))
                throw new RusIdentifiersArgumentNullException(nameof(value));
            if (value.Length != 12 || !long.TryParse(value, out _))
                return false;
            return true;
        }

        /// <inheritdoc/>
        public override XmlSchema GetSchema()
        {
            throw new NotImplementedException();
        }

        /// <inheritdoc/>
        public override void ReadXml(XmlReader reader)
        {
            throw new NotImplementedException();
        }

        /// <inheritdoc/>
        public override void WriteXml(XmlWriter writer)
        {
            throw new NotImplementedException();
        }

        ///<summary>Преобразование значения в строку</summary>
        public static implicit operator string(FsrarId value) => 
            value.ToString();

        ///<summary>Преобразование строки в значение</summary>
        public static implicit operator FsrarId(string value) =>
            new FsrarId(value);
        /// <inheritdoc/>
        public override string ToString()
        {
            return _value.ToString();
        }
    }
}
