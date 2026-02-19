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
        private string shopName {  get; set; }

        /// <summary>
        /// Адрес магазина
        /// </summary>
        private string shopAddress { get; set; }

        /// <summary>
        /// Число покупок
        /// </summary>
        private int purchaseCount { get; set; }

        /// <summary>
        /// Количество товаров
        /// </summary>
        private int productCount { get; set; }

        /// <summary>
        /// Средний чек
        /// </summary>
        private double averageCheck { get; set; }

        /// <summary>
        /// Рейтинг магазина
        /// </summary>
        private double rating { get; set; }

        /// <summary>
        /// Активен ли магазин
        /// </summary>
        private bool isActive { get; set; }

        /// <summary>
        /// Конструктор по умолчанию
        /// </summary>
        public InternetShop()
        {
            shopName = "Неизвестный магазин";
            shopAddress = "Адрес не указан";
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
            shopName = name;
            shopAddress = "Адрес не указан";
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
            shopName = name;
            shopAddress = address;
            purchaseCount = 0;
            productCount = 0;
            averageCheck = 0.0;
            rating = 0.0;
            isActive = false;
        }

        /// <summary>
        /// 
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
            shopName = name;
            shopAddress = address;
            purchaseCount = purchases;
            productCount = products;
            averageCheck = avgCheck;
            rating = shopRating;
            isActive = active;
        }
    }
}
