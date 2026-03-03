using System;
using System.Collections.Generic;
using System.Runtime.InteropServices;
using System.Text;

namespace LABA_1
{
    internal abstract class BoxMessage
    {
        /// <summary>
        /// Импорт функции MessageBox из библиотеки user32.dll
        /// </summary>
        /// <param name="hWnd">Дескриптор родительского окна</param>
        /// <param name="text">Текст сообщения, отображаемый в окне</param>
        /// <param name="caption">Заголовок окна сообщения</param>
        /// <param name="type">Тип сообщения</param>
        /// <returns></returns>
        [DllImport("user32.dll", CharSet = CharSet.Auto)]
        private static extern int MessageBox(IntPtr hWnd, string text, string caption, uint type);

        /// <summary>
        /// Обертка для вызова нативного MessageBox
        /// </summary>
        /// <param name="caption">Заголовок окна</param>
        /// <param name="text">Текст сообщения</param>
        /// <param name="type">Тип сообщения</param>
        /// <returns></returns>
        public static int ShowNativeMessageBox(string caption, string text, uint type)
        {
            return MessageBox(IntPtr.Zero, text, caption, type);
        }
    }
}
