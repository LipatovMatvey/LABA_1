using Microsoft.VisualStudio.TestTools.UnitTesting;
using LABA_1;

namespace MainModuleTest
{
    [TestClass]
    public sealed class InternetShopTest
    {
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
    }
}
