using RusIdentifiers.Exceptions;
using System;
using System.Xml;
using System.Xml.Schema;

namespace RusIdentifiers.Models.FNS
{
    /// <summary>ИНН — идентификационный номер налогоплательщика. Цифровой код, упорядочивающий учёт налогоплательщиков в Российской Федерации. Присваивается налоговой записи как юридических, так и физических лиц Федеральной налоговой службой России.</summary>
    [Serializable]
    public class Inn : IdentifierBase
    {
        private Inn() { }

        /// <summary>ИНН</summary>
        /// <param name="value">Значение</param>
        /// <exception cref="ArgumentNullException"></exception>
        /// <exception cref="ArgumentException"></exception>
        public Inn(string value)
        {
            value = value?.Trim();
            if (IsValid(value))
                base.value = value;
            else
                throw new RusIdentifiersArgumentException($"Значение \"{value}\" не является номером ИНН.");
        }

        /// <summary>Проверка строки на значение ИНН</summary>
        /// <param name="value">Строка</param>
        /// <returns>true - если строка соответствует ИНН <br></br>false - если строка не соответствует ИНН</returns>
        /// <exception cref="RusIdentifiersArgumentNullException"></exception>
        public static bool IsValid(string value)
        {
            if (string.IsNullOrEmpty(value))
                throw new RusIdentifiersArgumentNullException(nameof(value));
            else if (value.Length == 10 && ValidateInnForLegalEntity(value))
                return true;
            else if (value.Length == 12 && ValidateInnForIndividual(value))
                return true;
            return false;
        }

        /// <summary>Преобразовать строку в значение ИНН</summary>
        /// <param name="value">Строка для преобразования</param>
        /// <returns>ИНН</returns>
        public static Inn Parse(string value)
        {
            return new Inn(value);
        }

        /// <summary>Попытка преобразовать строку в значение ИНН</summary>
        /// <param name="value">Строка для преобразования</param>
        /// <param name="result">Результат</param>
        /// <returns>true - если удалость преобразовать строку в значение ИНН. <br></br>false - если строка не соответствует ИНН</returns>
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

        ///<summary>Преобразование значения в строку</summary>
        public static implicit operator string(Inn value)
        {
            return value.ToString();
        }

        ///<summary>Преобразование строки в значение</summary>
        public static implicit operator Inn(string value)
        {
            return new Inn(value);
        }

        /// <inheritdoc/>
        public override bool Equals(object obj)
        {
            return obj is Inn inn &&
                   value == inn.value;
        }

        /// <inheritdoc/>
        public override int GetHashCode()
        {
            return value.GetHashCode();
        }

        /// <inheritdoc/>
        public static bool operator ==(Inn lhs, Inn rhs)
        {
            return lhs.Equals(rhs);
        }

        /// <inheritdoc/>
        public static bool operator !=(Inn lhs, Inn rhs)
        {
            return !lhs.Equals(rhs);
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

            return checkDigit == inn[9] - '0';
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

            if (checkDigit1 != inn[10] - '0')
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

            return checkDigit2 == inn[11] - '0';
        }

        
    }
}
