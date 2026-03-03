using System.Net;
using System.Runtime.InteropServices;
using System.Text.RegularExpressions;
using System.Windows.Forms;
using System.Xml.Linq;

namespace LABA_1
{
    public partial class Form1 : Form
    {
        /// <summary>
        /// Текущий активный объект интернет-магазина
        /// </summary>
        private InternetShop currentShop;

        /// <summary>
        /// Коллекция для хранения всех созданных объектов интернет-магазинов
        /// </summary>
        private List<InternetShop> shopsList;

        /// <summary>
        /// Конструктор формы
        /// </summary>
        public Form1()
        {
            InitializeComponent();
            shopsList = new List<InternetShop>();
            BoxMessage.ShowNativeMessageBox("Приветствие", "Лабораторная работа № 1. Класс. \n\r \"Статические члены класса. " +
                "Обработка исключений\" \n\r Группа: 24ВП2 \r\n Бригада 11: Кузнецов Н.Д. Липатов М.В.", 0x40);
        }

        /// <summary>
        /// Обработчик кнопки закрытия
        /// </summary>
        /// <param name="sender">Объект, вызвавший событие</param>
        /// <param name="e">Аргументы события</param>
        private void BtnBack(object sender, EventArgs e)
        {
            Close();
        }

        /// <summary>
        /// Обработчик кнопки создания объекта интернет-магазина
        /// </summary>
        /// <param name="sender">Объект, вызвавший событие</param>
        /// <param name="e">Аргументы события</param>
        private void Button1_Click(object sender, EventArgs e)
        {
            try
            {
                string name = textBox1.Text.Trim();
                string address = textBox2.Text.Trim();
                int purchases = (int)numericUpDown1.Value;
                int products = (int)numericUpDown2.Value;
                double avgCheck = (double)numericUpDown3.Value;
                double rating = (double)numericUpDown4.Value;
                int active = comboBox1.SelectedIndex;
                if (purchases == 0 && products == 0 && avgCheck == 0 && rating == 0 &&
                    active == -1 && string.IsNullOrEmpty(name) && string.IsNullOrEmpty(address))
                {
                    currentShop = new InternetShop();
                    BoxMessage.ShowNativeMessageBox("Успех", $"Объект создан с конструктором по умолчанию", 0);
                }
                else if (string.IsNullOrEmpty(address) && purchases == 0 &&
                         products == 0 && avgCheck == 0 && rating == 0 && active == -1)
                {
                    if (!InputChecker.IsValidShopName(name))
                    {
                        BoxMessage.ShowNativeMessageBox("Ошибка", "Имя магазина некорректно", 16);
                        return;
                    }
                    currentShop = new InternetShop(name);
                    BoxMessage.ShowNativeMessageBox("Успех", $"Объект создан с конструктором с одним параметром: {name}", 0);
                }
                else if (purchases == 0 && products == 0 && avgCheck == 0 && rating == 0 && active == -1)
                {
                    if (!InputChecker.IsValidShopName(name))
                    {
                        BoxMessage.ShowNativeMessageBox("Ошибка", "Имя магазина некорректно", 16);
                        return;
                    }
                    if (!InputChecker.IsValidAddress(address))
                    {
                        BoxMessage.ShowNativeMessageBox("Ошибка", "Адрес магазина некорректен", 16);
                        return;
                    }
                    currentShop = new InternetShop(name, address);
                    BoxMessage.ShowNativeMessageBox("Успех", $"Объект создан с конструктором с двумя параметрами", 0);
                }
                else
                {
                    if (!InputChecker.IsValidShopName(name))
                    {
                        BoxMessage.ShowNativeMessageBox("Ошибка", "Имя магазина некорректно", 16);
                        return;
                    }
                    if (!InputChecker.IsValidAddress(address))
                    {
                        BoxMessage.ShowNativeMessageBox("Ошибка", "Адрес магазина некорректен", 16);
                        return;
                    }
                    bool isActive = active == 0 ? true : false;
                    currentShop = new InternetShop(name, address, purchases, products, avgCheck, rating, isActive);
                    BoxMessage.ShowNativeMessageBox("Успех", "Объект создан с конструктором со всеми параметрами", 0);
                }
                shopsList.Add(currentShop);
                UpdateObjectCount();
                UpdateObjectsList();
                DisplayCurrentShopInfo();
            }
            catch (Exception ex)
            {
                BoxMessage.ShowNativeMessageBox("Ошибка", $"Ошибка создания: {ex.Message}", 16);
            }
        }

        /// <summary>
        /// Обновляет отображение количества созданных объектов в интерфейсе
        /// </summary>
        private void UpdateObjectCount()
        {
            lblObjectCount.Text = $"Создано объектов: {InternetShop.CountObject}";
        }

        /// <summary>
        /// Обновляет список объектов в комбобоксе
        /// </summary>
        private void UpdateObjectsList()
        {
            cmbObjectsList.Items.Clear();
            for (int i = 0; i < shopsList.Count; i++)
            {
                string displayName = $"Объект {i + 1}: {shopsList[i].Name}";
                if (shopsList[i] == currentShop)
                {
                    displayName += " (текущий)";
                }
                cmbObjectsList.Items.Add(displayName);
            }
            if (currentShop != null)
            {
                int currentIndex = shopsList.IndexOf(currentShop);
                if (currentIndex >= 0)
                {
                    cmbObjectsList.SelectedIndex = currentIndex;
                }
                lblCurrentObject.Text = $"Текущий объект: {currentShop.Name}";
            }
            else
            {
                lblCurrentObject.Text = "Текущий объект: не выбран";
            }
        }

        /// <summary>
        /// Отображает информацию о текущем объекте в текстовом поле
        /// </summary>
        private void DisplayCurrentShopInfo()
        {
            if (currentShop == null)
            {
                BoxMessage.ShowNativeMessageBox("Ошибка", "Сначала создайте объект!", 16);
                return;
            }
            txtDisplayInfo.Clear();
            txtDisplayInfo.AppendText(currentShop.ToString());
        }

        /// <summary>
        /// Обработчик кнопки 16-ричного вывода
        /// </summary>
        /// <param name="sender">Объект, вызвавший событие</param>
        /// <param name="e">Аргументы события</param>
        private void btnShowHex_Click(object sender, EventArgs e)
        {
            if (currentShop == null)
            {
                BoxMessage.ShowNativeMessageBox("Ошибка", "Сначала создайте объект!", 16);
                return;
            }
            string hexView = currentShop.GetProductCountHex();
            txtDisplayInfo.Text = hexView;
            BoxMessage.ShowNativeMessageBox("Успех", "Значение поля отображено!", 0);
        }

        /// <summary>
        /// Обработчик отображения значения выбранного поля текущего объекта
        /// </summary>
        /// <param name="sender">Объект, вызвавший событие</param>
        /// <param name="e">Аргументы события</param>
        private void btnShowField_Click(object sender, EventArgs e)
        {
            if (currentShop == null)
            {
                BoxMessage.ShowNativeMessageBox("Ошибка", "Сначала создайте объект! Поле не определено", 16);
                return;
            }
            string selectedField = objectFields.SelectedItem as string;
            if (string.IsNullOrEmpty(selectedField))
            {
                BoxMessage.ShowNativeMessageBox("Ошибка", "Выберите поле для отображения!", 16);
                return;
            }
            switch (selectedField)
            {
                case "name":
                    txtDisplayInfo.Text = currentShop.Name.ToString();
                    break;
                case "address":
                    txtDisplayInfo.Text = currentShop.Address.ToString();
                    break;
                case "purchaseCount":
                    txtDisplayInfo.Text = currentShop.PurchaseCount.ToString();
                    break;
                case "productCount":
                    txtDisplayInfo.Text = currentShop.ProductCount.ToString();
                    break;
                case "averageCheck":
                    txtDisplayInfo.Text = currentShop.AverageCheck.ToString("F2");
                    break;
                case "rating":
                    txtDisplayInfo.Text = currentShop.Rating.ToString("F1");
                    break;
                case "isActive":
                    txtDisplayInfo.Text = currentShop.IsActive.ToString();
                    break;
                default:
                    txtDisplayInfo.Text = "Выберите поле для отображения";
                    break;
            }
            BoxMessage.ShowNativeMessageBox("Успех", "Значение поля отображено!", 0x40);
        }

        /// <summary>
        /// Обработчик кнопки очистки текстового поля
        /// </summary>
        /// <param name="sender">Объект, вызвавший событие</param>
        /// <param name="e">Аргументы события</param>
        private void btnClear_Click_1(object sender, EventArgs e)
        {
            txtDisplayInfo.Clear();
        }

        /// <summary>
        /// Обработчик кнопки отображения полной информации о текущем объекте
        /// </summary>
        /// <param name="sender">Объект, вызвавший событие</param>
        /// <param name="e">Аргументы события</param>
        private void btnShowInfo_Click(object sender, EventArgs e)
        {
            DisplayCurrentShopInfo();
        }

        /// <summary>
        /// Обработчик изменения значения выбранного поля текущего объекта
        /// </summary>
        /// <param name="sender">Объект, вызвавший событие</param>
        /// <param name="e">Аргументы события</param>
        private void btnModifyFields_Click(object sender, EventArgs e)
        {
            if (currentShop == null)
            {
                BoxMessage.ShowNativeMessageBox("Ошибка", "Сначала создайте объект!", 16);
                return;
            }
            string selectedField = objectFields.SelectedItem as string;
            if (string.IsNullOrEmpty(selectedField))
            {
                BoxMessage.ShowNativeMessageBox("Ошибка", "Выберите поле для изменения!", 16);
                return;
            }
            string newValue = newFieldValue.Text.Trim();
            if (string.IsNullOrEmpty(newValue))
            {
                BoxMessage.ShowNativeMessageBox("Ошибка", "Значение не может быть пустым", 16);
                return;
            }
            bool success = true;
            switch (selectedField)
            {
                case "name":
                    if (InputChecker.IsValidShopName(newValue))
                    {
                        currentShop.Name = newValue;
                    }
                    else
                    {
                        success = false;
                    }
                    break;
                case "address":
                    if (InputChecker.IsValidAddress(newValue))
                    {
                        currentShop.Address = newValue;
                    }
                    else
                    {
                        success = false;
                    }
                    break;
                case "purchaseCount":
                    if (InputChecker.TryParseNonNegativeInt(newValue, out int purchaseCount))
                    {
                        currentShop.PurchaseCount = purchaseCount;
                    }
                    else
                    {
                        success = false;
                    }
                    break;
                case "productCount":
                    if (InputChecker.TryParseNonNegativeInt(newValue, out int productCount))
                    {
                        currentShop.ProductCount = productCount;
                    }
                    else
                    {
                        success = false;
                    }
                    break;
                case "averageCheck":
                    if (InputChecker.TryParseNonNegativeDouble(newValue, out double avgCheck))
                    {
                        currentShop.AverageCheck = avgCheck;
                    }
                    else
                    {
                        success = false;
                    }
                    break;
                case "rating":
                    if (InputChecker.TryParseRating(newValue, out double rating))
                    {
                        currentShop.Rating = rating;
                    }
                    else
                    {
                        success = false;
                    }     
                    break;
                case "isActive":
                    if (InputChecker.TryParseBoolean(newValue, out bool isActive))
                    {
                        currentShop.IsActive = isActive;
                    }
                    else
                    {
                        success = false;
                    }
                    break;
                default:
                    BoxMessage.ShowNativeMessageBox("Ошибка", "Выберите поле для изменения", 16);
                    return;
            }
            if (!success)
            {
                BoxMessage.ShowNativeMessageBox("Ошибка", $"Некорректное значение для поля {selectedField}", 16);
                return;
            }
            DisplayCurrentShopInfo();
            UpdateObjectsList();
            BoxMessage.ShowNativeMessageBox("Успех", "Значение поля изменено!", 0x40);
            newFieldValue.Clear();
        }

        /// <summary>
        /// Переключение на выбранный объект
        /// </summary>
        /// <param name="sender">Объект, вызвавший событие</param>
        /// <param name="e">Аргументы события</param>
        private void btnSwitchToSelected_Click(object sender, EventArgs e)
        {
            if (cmbObjectsList.SelectedIndex >= 0 && cmbObjectsList.SelectedIndex < shopsList.Count)
            {
                currentShop = shopsList[cmbObjectsList.SelectedIndex];
                UpdateObjectsList();
                DisplayCurrentShopInfo();
                BoxMessage.ShowNativeMessageBox("Успех", $"Переключено на объект: {currentShop.Name}", 0x40);
            }
            else
            {
                BoxMessage.ShowNativeMessageBox("Ошибка", "Выберите объект из списка!", 16);
            }
        }

        /// <summary>
        /// Удаление выбранного объекта
        /// </summary>
        /// <param name="sender">Объект, вызвавший событие</param>
        /// <param name="e">Аргументы события</param>
        private void btnDeleteObject_Click(object sender, EventArgs e)
        {
            if (cmbObjectsList.SelectedIndex >= 0 && cmbObjectsList.SelectedIndex < shopsList.Count)
            {
                int indexToDelete = cmbObjectsList.SelectedIndex;
                string deletedName = shopsList[indexToDelete].Name;
                int result = BoxMessage.ShowNativeMessageBox("Подтверждение", $"Удалить объект '{deletedName}'?", 4);
                if (result == 6)
                {
                    shopsList.RemoveAt(indexToDelete);
                    if (shopsList.Count == 0)
                    {
                        currentShop = null;
                        txtDisplayInfo.Clear();
                    }
                    else if (currentShop != null && indexToDelete <= shopsList.IndexOf(currentShop))
                    {
                        currentShop = shopsList[0];
                        DisplayCurrentShopInfo();
                    }
                    InternetShop.CountObject--;
                    UpdateObjectCount();
                    UpdateObjectsList();
                    BoxMessage.ShowNativeMessageBox("Успех", "Объект удален", 0x40);
                }
            }
            else
            {
                BoxMessage.ShowNativeMessageBox("Ошибка", "Выберите объект для удаления!", 16);
            }
        }

        /// <summary>
        /// Демонстрация работы исключения
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>

        private void exceptionButton_Click(object sender, EventArgs e)
        {
            int a = 10;
            int b = 0;
            try
            {
                if (b == 0)
                {
                    throw new MyDivideByZeroException("Ошибка деления на 0. DivisionByZeroException",
                        $"Исключение было сгенерировано при попытке деления {a} на {b}");
                }
                int result = a / b;
            }
            catch (MyDivideByZeroException ex)
            {
                BoxMessage.ShowNativeMessageBox($"{ex.Message}", $"{ex.AdditionalInfo}", 0x00000010);
            }
        }

        /// <summary>
        /// Сброс значений полей
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void button2_Click(object sender, EventArgs e)
        {
            textBox1.Text = "";
            textBox2.Text = "";
            numericUpDown1.Value = 0;
            numericUpDown2.Value = 0;
            numericUpDown3.Value = 0.00m;
            numericUpDown4.Value = 0.0m;
            comboBox1.SelectedIndex = -1;
            newFieldValue.Text = "";
            objectFields.SelectedIndex = -1;
        }
    }
}