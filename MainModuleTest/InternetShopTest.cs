using Microsoft.VisualStudio.TestTools.UnitTesting;
using LABA_1;

namespace MainModuleTest
{
    [TestClass]
    public sealed class InternetShopTest
    {
        /// <summary>
        /// Тест на проверку работу метода ToString()
        /// </summary>
        [TestMethod]
        public void ToString_NormalWork_Test()
        {
            InternetShop TestObject = new InternetShop();
            string expected = "Интернет-магазин: NoName\r\n" +
                "Адрес: NoAddress\r\n" +
                "Количество покупок: 0\r\n" +
                "Количество товаров: 0\r\n" +
                "Средний чек: 0,00 ₽\r\n" +
                "Рейтинг: 0,0\r\n" +
                "Статус: Неактивен";

            string actual = TestObject.ToString();
            Assert.AreEqual(expected, actual);
        }

        /// <summary>
        /// Тест на проверку работу метода ToString()
        /// </summary>
        [TestMethod]
        public void ToString_NoWork_Test()
        {
            InternetShop TestObject = new InternetShop("Магнит");
            string expected = "Интернет-магазин: NoName\r\n" +
                "Адрес: NoAddress\r\n" +
                "Количество покупок: 0\r\n" +
                "Количество товаров: 0\r\n" +
                "Средний чек: 0,00 ₽\r\n" +
                "Рейтинг: 0,0\r\n" +
                "Статус: Неактивен";

            string actual = TestObject.ToString();
            Assert.AreEqual(expected, actual);
        }

        /// <summary>
        /// Тест на проверку работу метода GetProductCountHex()
        /// </summary>
        [TestMethod]
        public void GetProductCountHex_NormalWork_Test()
        {
            InternetShop TestObject = new InternetShop();
            string expected = $"Количество товаров (16-ричное): 0x{TestObject.ProductCount:X}";

            string actual = TestObject.GetProductCountHex();
            Assert.AreEqual(expected, actual);
        }
    }
}
