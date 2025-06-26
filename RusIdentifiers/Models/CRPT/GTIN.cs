using RusIdentifiers.Exceptions;


namespace RusIdentifiers.CRPT
{
    /// <summary>GTIN - глобальный номер товарной позиции, который используется для однозначной идентификации товаров в международной торговле.</summary>
    public class GTIN : IdentifierBase
    {
        private GTIN() { }

        /// <summary>Код страны</summary>
        public int CoutnryCode =>
            int.Parse(value.Substring(1, 3));

        /// <summary>Код производителя</summary>
        public int ManufacturerCode =>
            int.Parse(value.Substring(4, 4));

        /// <summary>Код товара</summary>
        public int ProductCode =>
            int.Parse(value.Substring(8, 5));

        /// <summary>GTIN</summary>
        /// <param name="value">Значение</param>
        /// <exception cref="RusIdentifiersArgumentNullException"></exception>
        /// <exception cref="RusIdentifiersArgumentException"></exception>
        public GTIN(string value)
        {
            if (value is null)
                throw new RusIdentifiersArgumentNullException(nameof(value));
            value = value.Trim();
            if (value.Length == 13)
                value = "0" + value;
            if (IsGTIN(value))
                base.value = value;
            else
                throw new RusIdentifiersArgumentException($"Значение \"{value}\" не является номером GTIN.");
        }

        /// <summary>Проверка строки на значение GTIN</summary>
        /// <param name="value">Строка</param>
        /// <returns>true - если строка соответствует GTIN<br></br>false - если строка не соответствует GTIN</returns>
        public static bool IsGTIN(string value)
        {
            if (value is null)
                return false;
            if ((value.Length != 13 && value.Length != 14) || !long.TryParse(value, out _))
                return false;
            if (!VerifyChecksum(value))
                return false;
            return true;
        }
        /// <summary>Попытка преобразовать строку в значение GTIN</summary>
        /// <param name="value">Строка для преобразования</param>
        /// <param name="result">Результат</param>
        /// <returns>true - если удалость преобразовать строку в значение GTIN. <br></br>false - если строка не соответствует GTIN</returns>
        public static bool TryParse(string value, out GTIN result)
        {
            try
            {
                result = new GTIN(value);
                return true;
            }
            catch
            {
                result = null;
                return false;
            }
        }
        ///<summary>Преобразование значения в строку</summary>
        public static implicit operator string(GTIN value)
        {
            return value.ToString();
        }

        ///<summary>Преобразование строки в значение</summary>
        public static implicit operator GTIN(string value)
        {
            return new GTIN(value);
        }

        /// <inheritdoc/>
        public override bool Equals(object obj)
        {
            return obj is GTIN gtin &&
                   value == gtin.value;
        }

        /// <inheritdoc/>
        public override int GetHashCode()
        {
            return value.GetHashCode();
        }

        /// <inheritdoc/>
        public static bool operator ==(GTIN lhs, GTIN rhs)
        {
            return lhs.Equals(rhs);
        }

        /// <inheritdoc/>
        public static bool operator !=(GTIN lhs, GTIN rhs)
        {
            return !lhs.Equals(rhs);
        }
        private static bool VerifyChecksum(string value)
        {
            if (value.Length == 14)
                value = value.Substring(1);
            var evenSum = value[1] - '0' + value[3] - '0' + value[5] - '0' + value[7] - '0' + value[9] - '0' + value[11] - '0';
            var oddSum = value[0] - '0' + value[2] - '0' + value[4] - '0' + value[6] - '0' + value[8] - '0' + value[10] - '0';
            var lastDigit = ((evenSum * 3) + oddSum) % 10;
            var checkSum = value[12] - '0';

            if (lastDigit == 0 && checkSum == 0)
                return true;
            else
                return 10 - lastDigit == checkSum;
        }
    }
}
