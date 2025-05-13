using RusIdentifiers.Exceptions;

namespace RusIdentifiers.FSRAR
{
    /// <summary>Алкогольный код (алкокод)</summary>
    public class AlcoCode : IdentifierBase
    {
        private AlcoCode() { }

        /// <summary>Алкокод</summary>
        /// <param name="value">Значение</param>
        /// <exception cref="RusIdentifiersArgumentException"></exception>
        /// <exception cref="RusIdentifiersArgumentNullException"></exception>
        public AlcoCode(string value)
        {
            value = value?.Trim();
            if (IsAlcoCode(value))
                base.value = value;
            else
                throw new RusIdentifiersArgumentException($"Значение \"{value}\" не является кодом алкогольной продукции.");
        }
        /// <summary>Проверка строки на значение ИНН</summary>
        /// <param name="value">Строка</param>
        /// <returns>true - если строка соответствует ИНН <br></br>false - если строка не соответствует ИНН</returns>
        /// <exception cref="RusIdentifiersArgumentNullException"></exception>
        public static bool IsAlcoCode(string value)
        {
            if (value is null)
                throw new RusIdentifiersArgumentNullException(nameof(value));
            if (value.Length != 19 || !long.TryParse(value, out _))
                return false;
            return true;
        }

        ///<summary>Преобразование значения в строку</summary>
        public static implicit operator string(AlcoCode value)
        {
            return value.ToString();
        }

        ///<summary>Преобразование строки в значение</summary>
        public static implicit operator AlcoCode(string value)
        {
            return new AlcoCode(value);
        }

        /// <summary>Попытка преобразовать строку в алкогольный код</summary>
        /// <param name="value">Строка для преобразования</param>
        /// <param name="result">Результат</param>
        /// <returns>true - если удалость преобразовать строку в алкогольный код.<br></br>false - если строка не соответствует алкогольному коду</returns>
        public static bool TryParse(string value, out AlcoCode result)
        {
            try
            {
                result = new AlcoCode(value);
                return true;
            }
            catch
            {
                result = null;
                return false;
            }
        }
        /// <inheritdoc/>
        public override bool IsValid() =>
            IsAlcoCode(value);
    }
}
