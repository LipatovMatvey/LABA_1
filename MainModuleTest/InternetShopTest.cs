using Microsoft.VisualStudio.TestTools.UnitTesting;
using LABA_1;

namespace MainModuleTest
{
    [TestClass]
    [DoNotParallelize]
    public sealed class InternetShopTest
    {
        /// <summary>
        /// Тест работы метода ToString() после вызова конструктора по умолчанию
        /// </summary>
        [TestMethod]
        public void ToString_DefaultConstructor_ReturnsCorrectString()
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
        /// Тест работы метода ToString() после вызова конструктора с 1 параметром - именем
        /// </summary>
        [TestMethod]
        public void ToString_ConstructorWithName_ReturnsStringWithGivenName()
        {
            InternetShop TestObject = new InternetShop("Магнит");
            string expected = $"Интернет-магазин: {TestObject.Name}\r\n" +
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
        /// Тест работы метода GetProductCountHex()
        /// </summary>
        /// <param name="DecView">Десятичное представление</param>
        /// <param name="HexView">Шестнадцатеричное представление</param>
        [TestMethod]
        [DataRow(0, "0x0")]
        [DataRow(15, "0xF")]
        [DataRow(255, "0xFF")]
        [DataRow(4096, "0x1000")]
        public void GetProductCountHex_VariousInputs_ReturnsExpectedHex(int DecView, string HexView) 
        {
            InternetShop shop = new InternetShop();
            shop.ProductCount = DecView;
            string expected = $"Количество товаров (16-ричное): {HexView}";
            Assert.AreEqual(expected, shop.GetProductCountHex());
        }

        /// <summary>
        /// Тестирование корректной работы статического счетчика создания объектов
        /// </summary>
        [TestMethod]
        public void ObjectsCount_IncrementsOnEachNewInstance() 
        {
            int beforeCreate = InternetShop.ObjectsCount;
            var shop1 = new InternetShop();
            Assert.AreEqual(beforeCreate + 1, InternetShop.ObjectsCount);

            var shop2 = new InternetShop("Name");
            Assert.AreEqual(beforeCreate + 2, InternetShop.ObjectsCount);

            var shop3 = new InternetShop("Name", "Addr");
            Assert.AreEqual(beforeCreate + 3, InternetShop.ObjectsCount);
        }

        /// <summary>
        /// Проверка работы конструктора по умолчанию
        /// </summary>
        [TestMethod]
        public void Constructor_Default_SetsDefaultValues()
        {
            InternetShop shop = new InternetShop();

            Assert.AreEqual("NoName", shop.Name);
            Assert.AreEqual("NoAddress", shop.Address);
            Assert.AreEqual(0, shop.PurchaseCount);
            Assert.AreEqual(0, shop.ProductCount);
            Assert.AreEqual(0.0, shop.AverageCheck);
            Assert.AreEqual(0.0, shop.Rating);
            Assert.IsFalse(shop.IsActive);
            
        }

        /// <summary>
        /// Проверка работы конструктора с 1 параметром - именем
        /// </summary>
        [TestMethod]
        public void Constructor_WithName_SetsNameAndDefaultValues()
        {
            string testName = "Пятерочка";
            InternetShop shop = new InternetShop(testName);

            Assert.AreEqual(testName, shop.Name);
            Assert.AreEqual("NoAddress", shop.Address);
            Assert.AreEqual(0, shop.PurchaseCount);
            Assert.AreEqual(0, shop.ProductCount);
            Assert.AreEqual(0.0, shop.AverageCheck);
            Assert.AreEqual(0.0, shop.Rating);
            Assert.IsFalse(shop.IsActive);
        }

        /// <summary>
        /// Проверка работы конструктора с 2 параметрами - именем и адресом
        /// </summary>
        [TestMethod]
        public void Constructor_WithNameAndAddress_SetsBothAndDefaultValues()
        {
            string testName = "Пятерочка";
            string testAddress = "Г. Пенза, ул. Тамбовская 9";

            InternetShop shop = new InternetShop(testName, testAddress);

            Assert.AreEqual(testName, shop.Name);
            Assert.AreEqual(testAddress, shop.Address);
            Assert.AreEqual(0, shop.PurchaseCount);
            Assert.AreEqual(0, shop.ProductCount);
            Assert.AreEqual(0.0, shop.AverageCheck);
            Assert.AreEqual(0.0, shop.Rating);
            Assert.IsFalse(shop.IsActive);
        }

        /// <summary>
        /// Проверка работы конструктора со всеми параметрами
        /// </summary>
        [TestMethod]
        public void Constructor_WithAllValues_SetsAllValues()
        {
            string testName = "Пятерочка";
            string testAddress = "Г. Пенза, ул. Тамбовская 9";
            int testPurchases = 500;
            int testProducts = 200;
            double testAvgCheck = 1057.8;
            double testRating = 5.0;
            bool testIsActive = true;

            InternetShop shop = new InternetShop(testName, testAddress, testPurchases, testProducts, testAvgCheck,
                testRating, testIsActive);

            Assert.AreEqual(testName, shop.Name);
            Assert.AreEqual(testAddress, shop.Address);
            Assert.AreEqual(testPurchases, shop.PurchaseCount);
            Assert.AreEqual(testProducts, shop.ProductCount);
            Assert.AreEqual(testAvgCheck, shop.AverageCheck);
            Assert.AreEqual(testRating, shop.Rating);
            Assert.IsTrue(shop.IsActive);
        }

        /// <summary>
        /// Тестирование корректной работы геттеров и сеттеров
        /// </summary>
        [TestMethod]
        public void Properties_SetAndGet_ReturnCorrectValues()
        {
            InternetShop shop = new InternetShop();

            shop.Name = "NewName";
            shop.Address = "NewAddress";
            shop.PurchaseCount = 42;
            shop.ProductCount = 100;
            shop.AverageCheck = 999.99;
            shop.Rating = 3.5;
            shop.IsActive = true;

            Assert.AreEqual("NewName", shop.Name);
            Assert.AreEqual("NewAddress", shop.Address);
            Assert.AreEqual(42, shop.PurchaseCount);
            Assert.AreEqual(100, shop.ProductCount);
            Assert.AreEqual(999.99, shop.AverageCheck);
            Assert.AreEqual(3.5, shop.Rating);
            Assert.IsTrue(shop.IsActive);
        }

    }
}
