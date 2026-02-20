using System;
using System.Collections.Generic;
using System.Text;

namespace LABA_1
{
    internal class InternetShop
    {
        /// <summary>
        /// Наименование магазина
        /// </summary>
        public string name {  get; set; }

        /// <summary>
        /// Адрес магазина
        /// </summary>
        public string address { get; set; }

        /// <summary>
        /// Число покупок
        /// </summary>
        public int purchaseCount { get; set; }

        /// <summary>
        /// Количество товаров
        /// </summary>
        public int productCount { get; set; }

        /// <summary>
        /// Средний чек
        /// </summary>
        public double averageCheck { get; set; }

        /// <summary>
        /// Рейтинг магазина
        /// </summary>
        public double rating { get; set; }

        /// <summary>
        /// Активен ли магазин
        /// </summary>
        public bool isActive { get; set; }

        /// <summary>
        /// Конструктор по умолчанию
        /// </summary>
        public InternetShop()
        {
            name = "NoName";
            address = "NoAddress";
            purchaseCount = 0;
            productCount = 0;
            averageCheck = 0.0;
            rating = 0.0;
            isActive = false;
        }

        /// <summary>
        /// Конструктор с одним параметром
        /// </summary>  
        /// <param name="name">Название магазина</param>
        public InternetShop(string name)
        {
            this.name = name;
            address = "NoAddress";
            purchaseCount = 0;
            productCount = 0;
            averageCheck = 0.0;
            rating = 0.0;
            isActive = false;
        }

        /// <summary>
        /// Конструктор с двумя параметрами
        /// </summary>
        /// <param name="name">Название магазина</param>
        /// <param name="address">Адрес магазина</param>
        public InternetShop(string name, string address)
        {
            this.name = name;
            this.address = address;
            purchaseCount = 0;
            productCount = 0;
            averageCheck = 0.0;
            rating = 0.0;
            isActive = false;
        }

        /// <summary>
        /// Конструктор с параметрами
        /// </summary>
        /// <param name="name">Название магазина</param>
        /// <param name="address">Адрес магазина</param>
        /// <param name="purchases">Число покупок</param>
        /// <param name="products">Количество товаров</param>
        /// <param name="avgCheck">Средний чек</param>
        /// <param name="shopRating">Рейтинг магазина</param>
        /// <param name="active">Активен ли магазин</param>
        public InternetShop(string name, string address, int purchases, int products,
                           double avgCheck, double shopRating, bool active)
        {
            this.name = name;
            this.address = address;
            purchaseCount = purchases;
            productCount = products;
            averageCheck = avgCheck;
            rating = shopRating;
            isActive = active;
        }

        /// <summary>
        /// Переопределение метода ToString()
        /// </summary>
        /// <returns></returns>
        public override string ToString()
        {
            return $"Интернет-магазин: {name}\r\n" +
                   $"Адрес: {address}\r\n" +
                   $"Количество покупок: {purchaseCount}\r\n" +
                   $"Количество товаров: {productCount}\r\n" +
                   $"Средний чек: {averageCheck:C}\r\n" +
                   $"Рейтинг: {rating:F1}\r\n" +
                   $"Статус: {(isActive ? "Активен" : "Неактивен")}"; ;
        }

        /// <summary>
        /// Метод для получения шестнадцатеричного представления количества товаров
        /// </summary>
        /// <returns></returns>
        public string GetProductCountHex()
        {
            return $"Количество товаров (16-ричное): 0x{productCount:X}";
        }

    }
}
