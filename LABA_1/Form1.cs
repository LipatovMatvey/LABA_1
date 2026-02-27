using System.Runtime.InteropServices;
using System.Text.RegularExpressions;

namespace LABA_1
{
    public partial class Form1 : Form
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
        public static extern int MessageBox(IntPtr hWnd, string text, string caption, uint type);

        /// <summary>
        /// Регулярное выражение для проверки на корректность ввода имени
        /// </summary>
        string pattern1 = @"^(?!\d+$)(?!.*\s{2})[A-Za-zА-Яа-яЁё0-9&""' -]{2,15}$";

        /// <summary>
        /// Регулярное выражение для проверки на корректность ввода адреса
        /// </summary>
        string pattern2 = @"^(?!\d+$)(?!.*\s{2})[A-Za-zА-Яа-яЁё0-9&""'., -]{2,40}$";

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
            ShowNativeMessageBox("Приветствие", "Лабораторная работа № 1. Класс. \n\r \"Статические члены класса. " +
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
                    ShowNativeMessageBox("Успех", $"Объект создан с конструктором по умолчанию", 0);
                }
                else if (string.IsNullOrEmpty(address) && purchases == 0 &&
                         products == 0 && avgCheck == 0 && rating == 0 && active == -1)
                {
                    if (!Regex.IsMatch(name, pattern1))
                    {
                        ShowNativeMessageBox("Ошибка", "Имя магазина некорректно", 16);
                        return;
                    }
                    currentShop = new InternetShop(name);
                    ShowNativeMessageBox("Успех", $"Объект создан с конструктором с одним параметром: {name}", 0);
                }
                else if (purchases == 0 && products == 0 && avgCheck == 0 && rating == 0 && active == -1)
                {
                    if (!Regex.IsMatch(name, pattern1))
                    {
                        ShowNativeMessageBox("Ошибка", "Имя магазина некорректно", 16);
                        return;
                    }
                    if (!Regex.IsMatch(address, pattern2))
                    {
                        ShowNativeMessageBox("Ошибка", "Адрес магазина некорректен", 16);
                        return;
                    }
                    currentShop = new InternetShop(name, address);
                    ShowNativeMessageBox("Успех", $"Объект создан с конструктором с двумя параметрами", 0);
                }
                else
                {
                    if (!Regex.IsMatch(name, pattern1))
                    {
                        ShowNativeMessageBox("Ошибка", "Имя магазина некорректно", 16);
                        return;
                    }
                    if (!Regex.IsMatch(address, pattern2))
                    {
                        ShowNativeMessageBox("Ошибка", "Адрес магазина некорректен", 16);
                        return;
                    }
                    bool isActive = active == 0 ? true : false;
                    currentShop = new InternetShop(name, address, purchases, products, avgCheck, rating, isActive);
                    ShowNativeMessageBox("Успех", "Объект создан с конструктором со всеми параметрами", 0);
                }
                shopsList.Add(currentShop);
                UpdateObjectCount();
                UpdateObjectsList();
                DisplayCurrentShopInfo();
            }
            catch (Exception ex)
            {
                ShowNativeMessageBox("Ошибка", $"Ошибка создания: {ex.Message}", 16);
            }
        }

        /// <summary>
        /// Обертка для вызова нативного MessageBox
        /// </summary>
        /// <param name="caption">Заголовок окна</param>
        /// <param name="text">Текст сообщения</param>
        /// <param name="type">Тип сообщения</param>
        /// <returns></returns>
        private int ShowNativeMessageBox(string caption, string text, uint type)
        {
            return MessageBox(IntPtr.Zero, text, caption, type);
        }

        /// <summary>
        /// Обновляет отображение количества созданных объектов в интерфейсе
        /// </summary>
        private void UpdateObjectCount()
        {
            lblObjectCount.Text = $"Создано объектов: {InternetShop.ObjectsCount}";
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
                ShowNativeMessageBox("Ошибка", "Сначала создайте объект!", 16);
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
                ShowNativeMessageBox("Ошибка", "Сначала создайте объект!", 16);
                return;
            }
            string hexView = currentShop.GetProductCountHex();
            txtDisplayInfo.Text = hexView;
            ShowNativeMessageBox("Успех", "Значение поля отображено!", 0);
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
                ShowNativeMessageBox("Ошибка", "Сначала создайте объект! Поле не определено", 16);
                return;
            }
            string selectedField = objectFields.SelectedItem as string;
            if (string.IsNullOrEmpty(selectedField))
            {
                ShowNativeMessageBox("Ошибка", "Выберите поле для отображения!", 16);
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
            ShowNativeMessageBox("Успех", "Значение поля отображено!", 0x40);
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
                ShowNativeMessageBox("Ошибка", "Сначала создайте объект! Поле не определено", 16);
                return;
            }
            string selectedField = objectFields.SelectedItem as string;
            if (string.IsNullOrEmpty(selectedField))
            {
                ShowNativeMessageBox("Ошибка", "Выберите поле для изменения!", 16);
                return;
            }
            string newValue = newFieldValue.Text.Trim();
            if (newValue == "")
            {
                ShowNativeMessageBox("Ошибка", "Значение не может быть пустым", 16);
                return;
            }
            switch (selectedField)
            {
                case "name":
                    if (!Regex.IsMatch(newValue, pattern1))
                    {
                        ShowNativeMessageBox("Ошибка", "Имя магазина некорректно", 16);
                        return;
                    }
                    currentShop.Name = newValue;
                    break;
                case "address":
                    if (!Regex.IsMatch(newValue, pattern2))
                    {
                        ShowNativeMessageBox("Ошибка", "Адрес некорректен", 16);
                        return;
                    }
                    currentShop.Address = newValue;
                    break;
                case "purchaseCount":
                    if (!int.TryParse(newValue, out int purchaseCount) || purchaseCount < 0)
                    {
                        ShowNativeMessageBox("Ошибка", "Количество покупок должно быть целым неотрицательным числом", 16);
                        return;
                    }
                    currentShop.PurchaseCount = int.Parse(newValue);
                    break;
                case "productCount":
                    if (!int.TryParse(newValue, out int productCount) || productCount < 0)
                    {
                        ShowNativeMessageBox("Ошибка", "Количество товаров должно быть целым неотрицательным числом", 16);
                        return;
                    }
                    currentShop.ProductCount = int.Parse(newValue);
                    break;
                case "averageCheck":
                    if (!double.TryParse(newValue, out double averageCheck) || averageCheck < 0)
                    {
                        ShowNativeMessageBox("Ошибка", "Средний чек должен быть неотрицательным числом", 16);
                        return;
                    }
                    currentShop.AverageCheck = double.Parse(newValue);
                    break;
                case "rating":
                    if (!double.TryParse(newValue, out double rating) || rating < 1 || rating > 5)
                    {
                        ShowNativeMessageBox("Ошибка", "Рейтинг должен быть числом от 1 до 5", 16);
                        return;
                    }
                    currentShop.Rating = double.Parse(newValue);
                    break;
                case "isActive":
                    if (!newValue.Equals("да", StringComparison.OrdinalIgnoreCase) &&
                        !newValue.Equals("нет", StringComparison.OrdinalIgnoreCase) &&
                        !newValue.Equals("true", StringComparison.OrdinalIgnoreCase) &&
                        !newValue.Equals("false", StringComparison.OrdinalIgnoreCase))
                    {
                        ShowNativeMessageBox("Ошибка", "Значение может быть \"да/нет\" или \"true/false\"", 16);
                        return;
                    }
                    if (newValue.Equals("да", StringComparison.OrdinalIgnoreCase) ||
                        newValue.Equals("true", StringComparison.OrdinalIgnoreCase))
                    {
                        currentShop.IsActive = true;
                    }
                    else
                    {
                        currentShop.IsActive = false;
                    }
                    break;

                default:
                    txtDisplayInfo.Text = "Выберите поле для изменения";
                    break;
            }
            DisplayCurrentShopInfo();
            UpdateObjectsList();
            ShowNativeMessageBox("Успех", "Значение поля изменено!", 0x40);
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
                ShowNativeMessageBox("Успех", $"Переключено на объект: {currentShop.Name}", 0x40);
            }
            else
            {
                ShowNativeMessageBox("Ошибка", "Выберите объект из списка!", 16);
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
                int result = ShowNativeMessageBox("Подтверждение", $"Удалить объект '{deletedName}'?", 4);
                if (result == 6)
                {
                    shopsList.RemoveAt(indexToDelete);
                    InternetShop.ObjectsCount--;
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
                    UpdateObjectCount();
                    UpdateObjectsList();
                    ShowNativeMessageBox("Успех", "Объект удален", 0x40);
                }
            }
            else
            {
                ShowNativeMessageBox("Ошибка", "Выберите объект для удаления!", 16);
            }
        }

        private void lblObjectCount_Click(object sender, EventArgs e)
        {

        }

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
                ShowNativeMessageBox($"{ex.Message}", $"{ex.AdditionalInfo}", 0x00000010);
            }
        }

        private void comboBox1_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        private void button2_Click(object sender, EventArgs e)
        {
            comboBox1.SelectedIndex = -1;
        }
    }
}