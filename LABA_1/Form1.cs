using System.Runtime.InteropServices;

namespace LABA_1
{
    public partial class Form1 : Form
    {

        [DllImport("user32.dll", CharSet = CharSet.Auto)]
        public static extern int MessageBox(IntPtr hWnd, string text, string caption, uint type);

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
        }

        /// <summary>
        /// Обработчик кнопки закрытия
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void BtnBack(object sender, EventArgs e)
        {
            Close();
        }

        /// <summary>
        /// Обработчик кнопки создания объекта интернет-магазина
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void Button1_Click(object sender, EventArgs e)
        {
            try
            {
                string name = textBox1.Text;
                string address = textBox2.Text;
                int purchases = (int)numericUpDown1.Value;
                int products = (int)numericUpDown2.Value;
                double avgCheck = (double)numericUpDown3.Value;
                double rating = (double)numericUpDown4.Value;
                bool active = comboBox1.SelectedIndex == 0;
                if (purchases == 0 && products == 0 && avgCheck == 0 && rating == 0 && 
                    active == false && string.IsNullOrEmpty(name) && string.IsNullOrEmpty(address))
                {
                    currentShop = new InternetShop();
                    ShowNativeMessageBox("Успех", $"Объект создан с конструктором по умолчанию", 0);
                }
                else if (string.IsNullOrEmpty(address) && purchases == 0 &&
                         products == 0 && avgCheck == 0 && rating == 0 && active == false)
                {
                    currentShop = new InternetShop(name);
                    ShowNativeMessageBox("Успех", $"Объект создан с конструктором с одним параметром: {name}", 0);
                }
                else if (purchases == 0 && products == 0 && avgCheck == 0 && rating == 0 && active == false)
                {
                    currentShop = new InternetShop(name, address);
                    ShowNativeMessageBox("Успех", $"Объект создан с конструктором с двумя параметром", 0);
                }
                else
                {
                    currentShop = new InternetShop(name, address, purchases, products, avgCheck, rating, active);
                    ShowNativeMessageBox("Успех", "Объект создан с конструктором со всеми параметрами", 0);
                }
                shopsList.Add(currentShop);
                UpdateObjectCount();
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
        /// <param name="caption">Заголовок окна сообщения</param>
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
            lblObjectCount.Text = $"Создано объектов: {shopsList.Count}";
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
        /// Обработчик кнопки очистки поля отображения информации
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btnShowHex_Click(object sender, EventArgs e)
        {
            txtDisplayInfo.Clear();
        }

        /// <summary>
        /// Обработчик отображения значения выбранного поля текущего объекта
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btnShowField_Click(object sender, EventArgs e)
        {
            if (currentShop == null)
            {
                ShowNativeMessageBox("Ошибка", "Сначала создайте объект! Поле не определено", 16);
                return;
            }
            string selectedField = objectFields.SelectedItem as string;
            switch (selectedField)
            {
                case "name":
                    txtDisplayInfo.Text = currentShop.name.ToString();
                    break;
                case "address":
                    txtDisplayInfo.Text = currentShop.address.ToString();
                    break;
                case "purchaseCount":
                    txtDisplayInfo.Text = currentShop.purchaseCount.ToString();
                    break;
                case "productCount":
                    txtDisplayInfo.Text = currentShop.productCount.ToString();
                    break;
                case "averageCheck":
                    txtDisplayInfo.Text = currentShop.averageCheck.ToString();
                    break;
                case "rating":
                    txtDisplayInfo.Text = currentShop.rating.ToString();
                    break;
                case "isActive":
                    txtDisplayInfo.Text = currentShop.isActive.ToString();
                    break;
                default:
                    txtDisplayInfo.Text = "Выберите поле для отображения";
                    break;
            }
            if (txtDisplayInfo.Text != "Выберите поле для отображения") 
            {
                ShowNativeMessageBox("Успех", "Значение поля отображено!", 0x40);
            }
        }

        /// <summary>
        /// Обработчик кнопки очистки текстового поля
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btnClear_Click_1(object sender, EventArgs e)
        {
            txtDisplayInfo.Clear();
        }

        /// <summary>
        /// Обработчик кнопки отображения полной информации о текущем объекте
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btnShowInfo_Click(object sender, EventArgs e)
        {
            DisplayCurrentShopInfo();
        }

        

        /// <summary>
        /// Обработчик изменения значения выбранного поля текущего объекта
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btnModifyFields_Click(object sender, EventArgs e)
        {
            if (currentShop == null)
            {
                ShowNativeMessageBox("Ошибка", "Сначала создайте объект! Поле не определено", 16);
                return;
            }
            string selectedField = objectFields.SelectedItem as string;
            string newValue = newFieldValue.Text;
            if (newValue == "")
            {
                ShowNativeMessageBox("Ошибка", "Значение не может быть пустым", 16);
                return;
            }
            switch (selectedField)
            {
                case "name":
                    currentShop.name = newValue;
                    break;
                case "address":
                    currentShop.address = newValue;
                    break;
                case "purchaseCount":
                    currentShop.purchaseCount = int.Parse(newValue);
                    break;
                case "productCount":
                    currentShop.productCount = int.Parse(newValue);
                    break;
                case "averageCheck":
                    currentShop.averageCheck = double.Parse(newValue);
                    break;
                case "rating":
                    currentShop.rating = double.Parse(newValue);
                    break;
                case "isActive":
                    currentShop.isActive = Convert.ToBoolean(newValue);
                    break;
                default:
                    txtDisplayInfo.Text = "Выберите поле для изменения";
                    break;
            }
            if (txtDisplayInfo.Text != "Выберите поле для отображения")
            {
                DisplayCurrentShopInfo();
                ShowNativeMessageBox("Успех", "Значение поля изменено!", 0x40);               
            }
        }
    }
}
