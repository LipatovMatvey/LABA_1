using System;
using System.Collections.Generic;
using System.Text;
using System.Text.RegularExpressions;

namespace LABA_1
{
    internal abstract class InputChecker
    {
        /// <summary>
        /// Регулярное выражение для проверки на корректность ввода имени магазина
        /// </summary>
        private static readonly string _shopNamePattern = @"^(?!\d+$)(?!.*\s{2})[A-Za-zА-Яа-яЁё0-9&""' -]{2,15}$";

        /// <summary>
        /// Регулярное выражение для проверки на корректность ввода адреса
        /// </summary>
        private static readonly string _addressPattern = @"^(?!\d+$)(?!.*\s{2})[A-Za-zА-Яа-яЁё0-9&""'., -]{2,40}$";

        /// <summary>
        /// Проверяет корректность имени магазина
        /// </summary>
        /// <param name="name">Имя для проверки</param>
        /// <returns>true если имя корректно, иначе false</returns>
        public static bool IsValidShopName(string name)
        {
            if (string.IsNullOrWhiteSpace(name))
                return false;

            return Regex.IsMatch(name.Trim(), _shopNamePattern);
        }

        /// <summary>
        /// Проверяет корректность адреса магазина
        /// </summary>
        /// <param name="address">Адрес для проверки</param>
        /// <returns>true если адрес корректен, иначе false</returns>
        public static bool IsValidAddress(string address)
        {
            if (string.IsNullOrWhiteSpace(address))
                return false;

            return Regex.IsMatch(address.Trim(), _addressPattern);
        }

        /// <summary>
        /// Пытается преобразовать строковое представление числа в целое неотрицательное значение
        /// </summary>
        /// <param name="value">Строковое представление числа для парсинга</param>
        /// <param name="result">При успешном преобразовании содержит целое неотрицательное число</param>
        /// <returns>true, если value успешно преобразовано в неотрицательное целое число; иначе false</returns>
        public static bool TryParseNonNegativeInt(string value, out int result)
        {
            result = 0;
            return int.TryParse(value, out result) && result >= 0;
        }

        /// <summary>
        /// Пытается преобразовать строковое представление числа в неотрицательное число с плавающей запятой двойной точности
        /// </summary>
        /// <param name="value">Строковое представление числа для парсинга</param>
        /// <param name="result">При успешном преобразовании содержит неотрицательное число double</param>
        /// <returns>true, если value успешно преобразовано в неотрицательное число double; иначе false</returns>
        public static bool TryParseNonNegativeDouble(string value, out double result)
        {
            result = 0;
            return double.TryParse(value, out result) && result >= 0;
        }

        /// <summary>
        /// Пытается преобразовать строковое представление числа в значение рейтинга от 1 до 5
        /// </summary>
        /// <param name="value">Строковое представление рейтинга для парсинга</param>
        /// <param name="result">При успешном преобразовании содержит число double в диапазоне от 1 до 5</param>
        /// <returns>true, если value успешно преобразовано в число в диапазоне [1, 5]; иначе false</returns>
        public static bool TryParseRating(string value, out double result)
        {
            result = 0;
            return double.TryParse(value, out result) && result >= 1 && result <= 5;
        }

        /// <summary>
        /// Пытается преобразовать строковое представление логического значения
        /// </summary>
        /// <param name="value">Строковое представление логического значения для парсинга</param>
        /// <param name="result">
        /// При успешном преобразовании содержит true для значений "да" или "true"; false для значений "нет" или "false"
        /// </param>
        /// <returns>true, если value успешно преобразовано в логическое значение; иначе false</returns>
        public static bool TryParseBoolean(string value, out bool result)
        {
            result = false;
            if (string.IsNullOrWhiteSpace(value))
            {
                return false;
            }
            string normalized = value.Trim().ToLower();
            if (normalized == "да" || normalized == "true")
            {
                result = true;
                return true;
            }
            if (normalized == "нет" || normalized == "false")
            {
                result = false;
                return true;
            }
            return false;
        }

    }
}
