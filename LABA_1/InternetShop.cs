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
            set { name = value; }
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
            set { address = value; }
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
            set { purchaseCount = value; }
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
            set { productCount = value; }
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
            set { averageCheck = value; }
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
            set { rating = value; }
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
            set { isActive = value;}
        }

        public static int CountObject = 0;

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
            CountObject++;
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
            purchaseCount = 0;
            productCount = 0;
            averageCheck = 0.0;
            rating = 0.0;
            isActive = false;
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
            purchaseCount = purchases;
            productCount = products;
            averageCheck = avgCheck;
            rating = shopRating;
            isActive = active;
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
