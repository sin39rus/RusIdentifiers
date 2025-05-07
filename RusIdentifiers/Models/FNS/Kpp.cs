using RusIdentifiers.Exceptions;
using System;

namespace RusIdentifiers.Models.FNS
{
    /// <summary>КПП (код причины постановки на учёт) — это девятизначный идентификатор, который включает код региона, номер ИФНС, код основания постановки на учёт и порядковый номер постановки на учёт. </summary>
    [Serializable]
    public class Kpp : IdentifierBase
    {
        private Kpp() { }

        /// <summary>КПП (код причины постановки на учёт)</summary>
        /// <param name="value">Значение</param>
        /// <exception cref="RusIdentifiersArgumentException"></exception>
        public Kpp(string value)
        {
            value = value?.Trim();

            if (IsValid(value))
                base.value = value;
            else
                throw new RusIdentifiersArgumentException($"Значение \"{value}\" не является номером КПП.");
        }
        /// <summary>Проверка строки на значение КПП</summary>
        /// <param name="value">Строка</param>
        /// <returns>true - если строка соответствует КПП<br></br>false - если строка не соответствует КПП</returns>
        public static bool IsValid(string value)
        {
            if (value is null)
                throw new RusIdentifiersArgumentNullException(nameof(value));
            if (value.Length != 9 || !long.TryParse(value, out _))
                return false;
            return true;
        }

        /// <inheritdoc/>
        public override bool Equals(object obj)
        {
            return obj is Kpp kpp &&
                   value == kpp.value;
        }

        /// <inheritdoc/>
        public override int GetHashCode()
        {
            return value.GetHashCode();
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
        public static bool operator ==(Kpp lValue, Kpp rValue)
        {
            return lValue.Equals(rValue);
        }

        /// <inheritdoc/>
        public static bool operator !=(Kpp lValue, Kpp rValue)
        {
            return !lValue.Equals(rValue);
        }
    }
}
