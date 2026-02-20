using System.Runtime.InteropServices;
using System.Text.RegularExpressions;

namespace LABA_1
{
    public partial class Form1 : Form
    {

        [DllImport("user32.dll", CharSet = CharSet.Auto)]
        public static extern int MessageBox(IntPtr hWnd, string text, string caption, uint type);

        /// <summary>
        /// Объект
        /// </summary>
        private InternetShop currentShop;

        /// <summary>
        /// Список объектов
        /// </summary>
        private List<InternetShop> shopsList;

        /// <summary>
        /// 
        /// </summary>
        public Form1()
        {
            InitializeComponent();
            shopsList = new List<InternetShop>();
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void BtnBack(object sender, EventArgs e)
        {
            Close();
        }

        /// <summary>
        /// 
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
                if (string.IsNullOrEmpty(name) && string.IsNullOrEmpty(address) &&
                    purchases == 0 && products == 0 && avgCheck == 0 && rating == 0 && active == false)
                {
                    currentShop = new InternetShop();
                    ShowNativeMessageBox("Успех", "Объект создан с конструктором по умолчанию", 0);
                }
                else if (string.IsNullOrEmpty(address) && purchases == 0 &&
                         products == 0 && avgCheck == 0 && rating == 0)
                {
                    currentShop = new InternetShop(name);
                    ShowNativeMessageBox("Успех", $"Объект создан с конструктором с одним параметром: {name}", 0);
                }
                else if (purchases == 0 && products == 0 && avgCheck == 0 && rating == 0)
                {
                    currentShop = new InternetShop(name, address);
                    ShowNativeMessageBox("Успех", $"Объект создан с конструктором с двумя параметрами", 0);
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
        /// 
        /// </summary>
        /// <param name="caption"></param>
        /// <param name="text"></param>
        /// <param name="type"></param>
        /// <returns></returns>
        private int ShowNativeMessageBox(string caption, string text, uint type)
        {
            return MessageBox(IntPtr.Zero, text, caption, type);
        }

        /// <summary>
        /// 
        /// </summary>
        private void UpdateObjectCount()
        {
            lblObjectCount.Text = $"Создано объектов: {shopsList.Count}";
        }

        /// <summary>
        /// 
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

        private void label1_Click(object sender, EventArgs e)
        {

        }

        private void btnShowHex_Click(object sender, EventArgs e)
        {
            if (currentShop == null)
            {
                ShowNativeMessageBox("Ошибка", "Сначала создайте объект!", 16);
                return;
            }
            string hexView = currentShop.GetProductCountHex();
            txtDisplayInfo.Text = hexView;
            ShowNativeMessageBox("Успех", "Значение поля отображено!", 0x40);
        }

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

        private void btnClear_Click_1(object sender, EventArgs e)
        {
            txtDisplayInfo.Clear();
        }

        private void btnShowInfo_Click(object sender, EventArgs e)
        {
            DisplayCurrentShopInfo();
        }

        private void comboBox2_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

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
                    string pattern1 = @"^(?!\d+$)(?!.*\s{2})[A-Za-zА-Яа-яЁё0-9&""' -]{2,15}$";
                    if (!Regex.IsMatch(newValue, pattern1))
                    {
                        ShowNativeMessageBox("Ошибка", "Имя магазина некорректно", 16);
                        return;
                    }
                    currentShop.name = newValue;
                    break;
                case "address":
                    string pattern2 = @"^(?!\d+$)(?!.*\s{2})[A-Za-zА-Яа-яЁё0-9&""'., -]{2,40}$";
                    if (!Regex.IsMatch(newValue, pattern2))
                    {
                        ShowNativeMessageBox("Ошибка", "Адрес некорректен", 16);
                        return;
                    }
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
                    if (!newValue.Equals("да", StringComparison.OrdinalIgnoreCase) &&
                        !newValue.Equals("нет", StringComparison.OrdinalIgnoreCase))
                    {
                        ShowNativeMessageBox("Ошибка", "Значение может быть \"да/нет\"", 16);
                        return;
                    }
                    currentShop.isActive = newValue.ToLower() == "да" ? true : false;
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

        private void label12_Click(object sender, EventArgs e)
        {

        }
    }
}
