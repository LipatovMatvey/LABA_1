using System;
using System.Collections.Generic;
using System.Text;

namespace LABA_1
{
    internal class MyDivideByZeroException : DivideByZeroException
    {
        public string AdditionalInfo { get; set; }

        public MyDivideByZeroException() : base("Произошла ошибка деления на ноль!") { }

        public MyDivideByZeroException(string message) : base(message) { }

        public MyDivideByZeroException(string message, Exception inner) : base(message, inner) { }

        public MyDivideByZeroException(string message, string additionalInfo) : base(message)
        {
            AdditionalInfo = additionalInfo;
        }

    }   
}
