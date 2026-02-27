using System;
using System.Collections.Generic;
using System.Text;

namespace LABA_1
{
    internal class MyDivideByZeroException : DivideByZeroException
    {
        /// <summary>
        /// Дополнительная информация об ошибке деления на ноль
        /// </summary>
        public string AdditionalInfo { get; set; }

        /// <summary>
        /// Конструктор по умолчанию
        /// </summary>
        public MyDivideByZeroException() : base("Произошла ошибка деления на ноль!") { }

        /// <summary>
        /// Конструктор с параметром
        /// </summary>
        /// <param name="message">Сообщение, описывающее ошибку</param>
        public MyDivideByZeroException(string message) : base(message) { }

        /// <summary>
        /// Конструктор с двумя параметрами
        /// </summary>
        /// <param name="message">Сообщение, описывающее ошибку</param>
        /// <param name="inner">Внутреннее исключение</param>
        public MyDivideByZeroException(string message, Exception inner) : base(message, inner) { }

        /// <summary>
        /// Конструктор с двумя параметрами
        /// </summary>
        /// <param name="message">Сообщение, описывающее ошибку</param>
        /// <param name="additionalInfo">Дополнительная информация о контексте ошибки</param>
        public MyDivideByZeroException(string message, string additionalInfo) : base(message)
        {
            AdditionalInfo = additionalInfo;
        }

    }   
}
