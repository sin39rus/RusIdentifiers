using System;
using System.Xml;
using System.Xml.Schema;

namespace RusIdentifiers
{
    /// <summary>ИНН — идентификационный номер налогоплательщика.</summary>
    [Serializable]
    public class Inn : IdentifierBase
    {
        private string _value;
        private Inn() { }
        public Inn(string value)
        {
            value = value?.Trim();
            if (string.IsNullOrEmpty(value))
                throw new ArgumentNullException(nameof(value));
            else if (value.Length == 10 && ValidateInnForLegalEntity(value))
                _value = value;
            else if (value.Length == 12 && ValidateInnForIndividual(value))
                _value = value;
            else
                throw new ArgumentException($"Значение \"{value}\" не является номером ИНН.");
        }
        public override string ToString() =>
            _value;
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
        public static Inn Parse(string value)
        {
            return new Inn(value);
        }
        public static bool TryParse(string value, out Inn result)
        {
            try
            {
                result = new Inn(value);
                return true;
            }
            catch
            {
                result = null;
                return false;
            }
        }

        public static implicit operator string(Inn value)
        {
            return value.ToString();
        }
        public static implicit operator Inn(string value)
        {
            return new Inn(value);
        }
        private static bool ValidateInnForLegalEntity(string inn)
        {
            if (inn.Length != 10 || !long.TryParse(inn, out _))
            {
                return false;
            }

            int[] coefficients = { 2, 4, 10, 3, 5, 9, 4, 6, 8 };
            int sum = 0;

            for (int i = 0; i < 9; i++)
            {
                sum += (inn[i] - '0') * coefficients[i];
            }

            int checkDigit = sum % 11;
            if (checkDigit > 9)
            {
                checkDigit %= 10;
            }

            return checkDigit == (inn[9] - '0');
        }
        private static bool ValidateInnForIndividual(string inn)
        {
            if (inn.Length != 12 || !long.TryParse(inn, out _))
                return false;

            int[] coefficients1 = { 7, 2, 4, 10, 3, 5, 9, 4, 6, 8 };
            int sum1 = 0;

            for (int i = 0; i < 10; i++)
            {
                sum1 += (inn[i] - '0') * coefficients1[i];
            }

            int checkDigit1 = sum1 % 11;
            if (checkDigit1 > 9)
            {
                checkDigit1 %= 10;
            }

            if (checkDigit1 != (inn[10] - '0'))
            {
                return false;
            }

            int[] coefficients2 = { 3, 7, 2, 4, 10, 3, 5, 9, 4, 6, 8 };
            int sum2 = 0;

            for (int i = 0; i < 11; i++)
            {
                sum2 += (inn[i] - '0') * coefficients2[i];
            }

            int checkDigit2 = sum2 % 11;
            if (checkDigit2 > 9)
            {
                checkDigit2 %= 10;
            }

            return checkDigit2 == (inn[11] - '0');
        }
    }
}
