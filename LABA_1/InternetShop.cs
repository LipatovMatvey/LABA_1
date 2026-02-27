using System;
using System.Collections.Generic;
using System.Net;
using System.Text;
using System.Xml.Linq;

namespace LABA_1
{
    public class InternetShop
    {
        /// <summary>
        /// Наименование магазина
        /// </summary>
        private string name;

        /// <summary>
        /// Наименование магазина
        /// </summary>
        public string Name
        {
            get { return name; }
            set { this.name = value; }
        }

        /// <summary>
        /// Адрес магазина
        /// </summary>
        private string address;

        /// <summary>
        /// Адрес магазина
        /// </summary>
        public string Address
        {
            get { return  address; }
            set { this.address = value; }
        }

        /// <summary>
        /// Число покупок
        /// </summary>
        private int purchaseCount;

        /// <summary>
        /// Число покупок
        /// </summary>
        public int PurchaseCount
        {
            get { return purchaseCount;}
            set { this.purchaseCount = value; }
        }

        /// <summary>
        /// Количество товаров
        /// </summary>
        private int productCount;

        /// <summary>
        /// Количество товаров
        /// </summary>
        public int ProductCount
        {
            get { return productCount;}
            set { this.productCount = value; }
        }

        /// <summary>
        /// Средний чек
        /// </summary>
        private double averageCheck;

        /// <summary>
        /// Средний чек
        /// </summary>
        public double AverageCheck
        {
            get { return averageCheck; }
            set { this.averageCheck = value; }
        }

        /// <summary>
        /// Рейтинг магазина
        /// </summary>
        private double rating;

        /// <summary>
        /// Рейтинг магазина
        /// </summary>
        public double Rating
        {
            get { return rating; }
            set { this.rating = value; }
        }

        /// <summary>
        /// Активен ли магазин
        /// </summary>
        private bool isActive;

        /// <summary>
        /// Активен ли магазин
        /// </summary>
        public bool IsActive
        {
            get { return isActive;}
            set { this.isActive = value;}
        }

        /// <summary>
        /// Счётчик объектов
        /// </summary>
        public static int CountObject = 0;

        /// <summary>
        /// Счетчик созданных объектов
        /// </summary>
        public static int ObjectsCount { get; set; }

        /// <summary>
        /// Конструктор по умолчанию
        /// </summary>
        public InternetShop()
        {
            this.name = "NoName";
            this.address = "NoAddress";
            this.purchaseCount = 0;
            this.productCount = 0;
            this.averageCheck = 0.0;
            this.rating = 0.0;
            this.isActive = false;
            CountObject++;
        }

        /// <summary>
        /// Конструктор с одним параметром
        /// </summary>  
        /// <param name="name">Название магазина</param>
        public InternetShop(string name)
        {
            this.name = name;
            this.address = "NoAddress";
            this.purchaseCount = 0;
            this.productCount = 0;
            this.averageCheck = 0.0;
            this.rating = 0.0;
            this.isActive = false;
            CountObject++;
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
            this.purchaseCount = 0;
            this.productCount = 0;
            this.averageCheck = 0.0;
            this.rating = 0.0;
            this.isActive = false;
            CountObject++;
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
            this.purchaseCount = purchases;
            this.productCount = products;
            this.averageCheck = avgCheck;
            this.rating = shopRating;
            this.isActive = active;
            CountObject++;
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
