using System.Runtime.InteropServices;

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
                    purchases == 0 && products == 0 && avgCheck == 0 && rating == 0)
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
    }
}
