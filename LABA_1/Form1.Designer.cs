namespace LABA_1
{
    partial class Form1
    {
        /// <summary>
        ///  Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        ///  Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        ///  Required method for Designer support - do not modify
        ///  the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            components = new System.ComponentModel.Container();
            label1 = new Label();
            panel1 = new Panel();
            label2 = new Label();
            button1 = new Button();
            textBox1 = new TextBox();
            label3 = new Label();
            label4 = new Label();
            textBox2 = new TextBox();
            label5 = new Label();
            numericUpDown1 = new NumericUpDown();
            label6 = new Label();
            numericUpDown2 = new NumericUpDown();
            label7 = new Label();
            numericUpDown3 = new NumericUpDown();
            label8 = new Label();
            numericUpDown4 = new NumericUpDown();
            label9 = new Label();
            comboBox1 = new ComboBox();
            lblObjectCount = new Label();
            groupBoxDisplay = new GroupBox();
            txtDisplayInfo = new TextBox();
            btnShowInfo = new Button();
            btnShowField = new Button();
            btnModifyFields = new Button();
            btnShowHex = new Button();
            btnClear = new Button();
            groupBoxInput = new GroupBox();
            groupBoxStatus = new GroupBox();
            btnBack = new Button();
            contextMenuStrip1 = new ContextMenuStrip(components);
            objectFields = new ComboBox();
            label10 = new Label();
            newFieldValue = new TextBox();
            label11 = new Label();
            label12 = new Label();
            panel1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)numericUpDown1).BeginInit();
            ((System.ComponentModel.ISupportInitialize)numericUpDown2).BeginInit();
            ((System.ComponentModel.ISupportInitialize)numericUpDown3).BeginInit();
            ((System.ComponentModel.ISupportInitialize)numericUpDown4).BeginInit();
            groupBoxDisplay.SuspendLayout();
            groupBoxInput.SuspendLayout();
            groupBoxStatus.SuspendLayout();
            SuspendLayout();
            // 
            // label1
            // 
            label1.Anchor = AnchorStyles.Bottom | AnchorStyles.Right;
            label1.AutoSize = true;
            label1.BackColor = SystemColors.Highlight;
            label1.Font = new Font("Times New Roman", 12F, FontStyle.Bold);
            label1.ForeColor = SystemColors.ButtonFace;
            label1.Location = new Point(21, 20);
            label1.Name = "label1";
            label1.Size = new Size(335, 69);
            label1.TabIndex = 0;
            label1.Text = "Лабораторная работа №1\r\nСтуденты: Липатов М. Кузнецов Н.\r\nГруппа: 24ВП2";
            // 
            // panel1
            // 
            panel1.Anchor = AnchorStyles.Top | AnchorStyles.Bottom | AnchorStyles.Left | AnchorStyles.Right;
            panel1.BackColor = SystemColors.Highlight;
            panel1.Controls.Add(label2);
            panel1.Controls.Add(label1);
            panel1.Location = new Point(0, 0);
            panel1.Name = "panel1";
            panel1.Size = new Size(1013, 100);
            panel1.TabIndex = 1;
            // 
            // label2
            // 
            label2.Anchor = AnchorStyles.Bottom | AnchorStyles.Right;
            label2.AutoSize = true;
            label2.Font = new Font("Times New Roman", 12F, FontStyle.Bold);
            label2.ForeColor = SystemColors.ButtonFace;
            label2.Location = new Point(501, 20);
            label2.Name = "label2";
            label2.Size = new Size(258, 69);
            label2.TabIndex = 1;
            label2.Text = "Тема:\r\nСтатические члены класса\r\nОбработка исключений";
            // 
            // button1
            // 
            button1.Font = new Font("Times New Roman", 10F, FontStyle.Bold);
            button1.Location = new Point(15, 27);
            button1.Name = "button1";
            button1.Size = new Size(315, 35);
            button1.TabIndex = 2;
            button1.Text = "Создать объект";
            button1.UseVisualStyleBackColor = true;
            button1.Click += Button1_Click;
            // 
            // textBox1
            // 
            textBox1.Font = new Font("Times New Roman", 10F);
            textBox1.Location = new Point(170, 27);
            textBox1.Name = "textBox1";
            textBox1.Size = new Size(159, 27);
            textBox1.TabIndex = 3;
            // 
            // label3
            // 
            label3.AutoSize = true;
            label3.Font = new Font("Times New Roman", 10F);
            label3.Location = new Point(15, 27);
            label3.Name = "label3";
            label3.Size = new Size(111, 38);
            label3.TabIndex = 4;
            label3.Text = "Наименование\r\nмагазина:";
            // 
            // label4
            // 
            label4.AutoSize = true;
            label4.Font = new Font("Times New Roman", 10F);
            label4.Location = new Point(15, 83);
            label4.Name = "label4";
            label4.Size = new Size(124, 19);
            label4.TabIndex = 5;
            label4.Text = "Адрес магазина:";
            // 
            // textBox2
            // 
            textBox2.Font = new Font("Times New Roman", 10F);
            textBox2.Location = new Point(170, 83);
            textBox2.Name = "textBox2";
            textBox2.Size = new Size(159, 27);
            textBox2.TabIndex = 6;
            // 
            // label5
            // 
            label5.AutoSize = true;
            label5.Font = new Font("Times New Roman", 10F);
            label5.Location = new Point(15, 123);
            label5.Name = "label5";
            label5.Size = new Size(120, 19);
            label5.TabIndex = 7;
            label5.Text = "Число покупок:";
            // 
            // numericUpDown1
            // 
            numericUpDown1.Font = new Font("Times New Roman", 10F);
            numericUpDown1.Location = new Point(170, 123);
            numericUpDown1.Maximum = new decimal(new int[] { 1000000, 0, 0, 0 });
            numericUpDown1.Name = "numericUpDown1";
            numericUpDown1.Size = new Size(160, 27);
            numericUpDown1.TabIndex = 8;
            // 
            // label6
            // 
            label6.AutoSize = true;
            label6.Font = new Font("Times New Roman", 10F);
            label6.Location = new Point(15, 168);
            label6.Name = "label6";
            label6.Size = new Size(93, 38);
            label6.TabIndex = 9;
            label6.Text = "Количество\r\nтоваров:";
            // 
            // numericUpDown2
            // 
            numericUpDown2.Font = new Font("Times New Roman", 10F);
            numericUpDown2.Location = new Point(170, 168);
            numericUpDown2.Maximum = new decimal(new int[] { 1000000, 0, 0, 0 });
            numericUpDown2.Name = "numericUpDown2";
            numericUpDown2.Size = new Size(160, 27);
            numericUpDown2.TabIndex = 10;
            // 
            // label7
            // 
            label7.AutoSize = true;
            label7.Font = new Font("Times New Roman", 10F);
            label7.Location = new Point(15, 232);
            label7.Name = "label7";
            label7.Size = new Size(103, 19);
            label7.TabIndex = 11;
            label7.Text = "Средний чек:";
            // 
            // numericUpDown3
            // 
            numericUpDown3.DecimalPlaces = 2;
            numericUpDown3.Font = new Font("Times New Roman", 10F);
            numericUpDown3.Increment = new decimal(new int[] { 1, 0, 0, 65536 });
            numericUpDown3.Location = new Point(170, 232);
            numericUpDown3.Maximum = new decimal(new int[] { 1000000, 0, 0, 0 });
            numericUpDown3.Name = "numericUpDown3";
            numericUpDown3.Size = new Size(160, 27);
            numericUpDown3.TabIndex = 12;
            // 
            // label8
            // 
            label8.AutoSize = true;
            label8.Font = new Font("Times New Roman", 10F);
            label8.Location = new Point(15, 269);
            label8.Name = "label8";
            label8.Size = new Size(136, 19);
            label8.TabIndex = 13;
            label8.Text = "Рейтинг магазина:";
            // 
            // numericUpDown4
            // 
            numericUpDown4.DecimalPlaces = 1;
            numericUpDown4.Font = new Font("Times New Roman", 10F);
            numericUpDown4.Increment = new decimal(new int[] { 1, 0, 0, 65536 });
            numericUpDown4.Location = new Point(170, 267);
            numericUpDown4.Maximum = new decimal(new int[] { 5, 0, 0, 0 });
            numericUpDown4.Name = "numericUpDown4";
            numericUpDown4.Size = new Size(160, 27);
            numericUpDown4.TabIndex = 14;
            // 
            // label9
            // 
            label9.AutoSize = true;
            label9.Font = new Font("Times New Roman", 10F);
            label9.Location = new Point(15, 308);
            label9.Name = "label9";
            label9.Size = new Size(128, 19);
            label9.TabIndex = 15;
            label9.Text = "Статус магазина:";
            // 
            // comboBox1
            // 
            comboBox1.DropDownStyle = ComboBoxStyle.DropDownList;
            comboBox1.Font = new Font("Times New Roman", 10F);
            comboBox1.FormattingEnabled = true;
            comboBox1.Items.AddRange(new object[] { "Активен", "Неактивен" });
            comboBox1.Location = new Point(170, 308);
            comboBox1.Name = "comboBox1";
            comboBox1.Size = new Size(159, 27);
            comboBox1.TabIndex = 16;
            // 
            // lblObjectCount
            // 
            lblObjectCount.Anchor = AnchorStyles.Bottom | AnchorStyles.Right;
            lblObjectCount.AutoSize = true;
            lblObjectCount.Font = new Font("Times New Roman", 11F, FontStyle.Bold);
            lblObjectCount.ForeColor = Color.Blue;
            lblObjectCount.Location = new Point(21, 109);
            lblObjectCount.Name = "lblObjectCount";
            lblObjectCount.Size = new Size(188, 22);
            lblObjectCount.TabIndex = 17;
            lblObjectCount.Text = "Создано объектов: 0";
            // 
            // groupBoxDisplay
            // 
            groupBoxDisplay.Anchor = AnchorStyles.Bottom | AnchorStyles.Right;
            groupBoxDisplay.Controls.Add(txtDisplayInfo);
            groupBoxDisplay.Font = new Font("Times New Roman", 10F, FontStyle.Bold);
            groupBoxDisplay.Location = new Point(400, 140);
            groupBoxDisplay.Name = "groupBoxDisplay";
            groupBoxDisplay.Size = new Size(421, 349);
            groupBoxDisplay.TabIndex = 20;
            groupBoxDisplay.TabStop = false;
            groupBoxDisplay.Text = "Информация о магазине";
            // 
            // txtDisplayInfo
            // 
            txtDisplayInfo.Anchor = AnchorStyles.Bottom | AnchorStyles.Right;
            txtDisplayInfo.Font = new Font("Consolas", 10F);
            txtDisplayInfo.Location = new Point(15, 25);
            txtDisplayInfo.Multiline = true;
            txtDisplayInfo.Name = "txtDisplayInfo";
            txtDisplayInfo.ReadOnly = true;
            txtDisplayInfo.ScrollBars = ScrollBars.Vertical;
            txtDisplayInfo.Size = new Size(385, 311);
            txtDisplayInfo.TabIndex = 0;
            // 
            // btnShowInfo
            // 
            btnShowInfo.Anchor = AnchorStyles.Bottom | AnchorStyles.Right;
            btnShowInfo.Font = new Font("Times New Roman", 10F);
            btnShowInfo.Location = new Point(400, 500);
            btnShowInfo.Name = "btnShowInfo";
            btnShowInfo.Size = new Size(146, 35);
            btnShowInfo.TabIndex = 21;
            btnShowInfo.Text = "Показать данные";
            btnShowInfo.Click += btnShowInfo_Click;
            // 
            // btnShowField
            // 
            btnShowField.Anchor = AnchorStyles.Bottom | AnchorStyles.Right;
            btnShowField.Font = new Font("Times New Roman", 10F);
            btnShowField.Location = new Point(553, 500);
            btnShowField.Name = "btnShowField";
            btnShowField.Size = new Size(155, 35);
            btnShowField.TabIndex = 22;
            btnShowField.Text = "Показать поле";
            btnShowField.Click += btnShowField_Click;
            // 
            // btnModifyFields
            // 
            btnModifyFields.Anchor = AnchorStyles.Bottom | AnchorStyles.Right;
            btnModifyFields.Font = new Font("Times New Roman", 10F);
            btnModifyFields.Location = new Point(553, 551);
            btnModifyFields.Name = "btnModifyFields";
            btnModifyFields.Size = new Size(155, 35);
            btnModifyFields.TabIndex = 23;
            btnModifyFields.Text = "Изменить поле";
            btnModifyFields.Click += btnModifyFields_Click;
            // 
            // btnShowHex
            // 
            btnShowHex.Anchor = AnchorStyles.Bottom | AnchorStyles.Right;
            btnShowHex.Font = new Font("Times New Roman", 10F);
            btnShowHex.Location = new Point(400, 551);
            btnShowHex.Name = "btnShowHex";
            btnShowHex.Size = new Size(146, 35);
            btnShowHex.TabIndex = 24;
            btnShowHex.Text = "16-ричный вывод";
            btnShowHex.Click += btnShowHex_Click;
            // 
            // btnClear
            // 
            btnClear.Anchor = AnchorStyles.Bottom | AnchorStyles.Right;
            btnClear.Font = new Font("Times New Roman", 10F);
            btnClear.Location = new Point(400, 597);
            btnClear.Name = "btnClear";
            btnClear.Size = new Size(120, 35);
            btnClear.TabIndex = 26;
            btnClear.Text = "Очистить";
            btnClear.Click += btnClear_Click_1;
            // 
            // groupBoxInput
            // 
            groupBoxInput.Anchor = AnchorStyles.Bottom | AnchorStyles.Right;
            groupBoxInput.Controls.Add(label9);
            groupBoxInput.Controls.Add(label3);
            groupBoxInput.Controls.Add(comboBox1);
            groupBoxInput.Controls.Add(textBox1);
            groupBoxInput.Controls.Add(label4);
            groupBoxInput.Controls.Add(textBox2);
            groupBoxInput.Controls.Add(label5);
            groupBoxInput.Controls.Add(numericUpDown1);
            groupBoxInput.Controls.Add(label6);
            groupBoxInput.Controls.Add(numericUpDown2);
            groupBoxInput.Controls.Add(label7);
            groupBoxInput.Controls.Add(numericUpDown3);
            groupBoxInput.Controls.Add(label8);
            groupBoxInput.Controls.Add(numericUpDown4);
            groupBoxInput.Font = new Font("Times New Roman", 10F, FontStyle.Bold);
            groupBoxInput.Location = new Point(21, 140);
            groupBoxInput.Name = "groupBoxInput";
            groupBoxInput.Size = new Size(350, 349);
            groupBoxInput.TabIndex = 18;
            groupBoxInput.TabStop = false;
            groupBoxInput.Text = "Ввод данных";
            // 
            // groupBoxStatus
            // 
            groupBoxStatus.Anchor = AnchorStyles.Bottom | AnchorStyles.Right;
            groupBoxStatus.Controls.Add(button1);
            groupBoxStatus.Font = new Font("Times New Roman", 10F, FontStyle.Bold);
            groupBoxStatus.Location = new Point(21, 500);
            groupBoxStatus.Name = "groupBoxStatus";
            groupBoxStatus.Size = new Size(350, 85);
            groupBoxStatus.TabIndex = 19;
            groupBoxStatus.TabStop = false;
            groupBoxStatus.Text = "Управление";
            // 
            // btnBack
            // 
            btnBack.Anchor = AnchorStyles.Bottom | AnchorStyles.Right;
            btnBack.BackColor = Color.White;
            btnBack.Font = new Font("Times New Roman", 10.2F, FontStyle.Regular, GraphicsUnit.Point, 204);
            btnBack.ForeColor = Color.Black;
            btnBack.Location = new Point(886, 609);
            btnBack.Name = "btnBack";
            btnBack.Size = new Size(114, 39);
            btnBack.TabIndex = 27;
            btnBack.Text = "ВЫХОД";
            btnBack.UseVisualStyleBackColor = true;
            btnBack.Click += BtnBack;
            // 
            // contextMenuStrip1
            // 
            contextMenuStrip1.ImageScalingSize = new Size(20, 20);
            contextMenuStrip1.Name = "contextMenuStrip1";
            contextMenuStrip1.Size = new Size(61, 4);
            // 
            // objectFields
            // 
            objectFields.Anchor = AnchorStyles.Bottom | AnchorStyles.Right;
            objectFields.DropDownStyle = ComboBoxStyle.DropDownList;
            objectFields.FormattingEnabled = true;
            objectFields.Items.AddRange(new object[] { "name", "address", "purchaseCount", "productCount", "averageCheck", "rating", "isActive" });
            objectFields.Location = new Point(875, 504);
            objectFields.Margin = new Padding(3, 4, 3, 4);
            objectFields.Name = "objectFields";
            objectFields.Size = new Size(125, 28);
            objectFields.TabIndex = 30;
            // 
            // label10
            // 
            label10.AutoSize = true;
            label10.Location = new Point(730, 551);
            label10.Name = "label10";
            label10.Size = new Size(0, 20);
            label10.TabIndex = 31;
            // 
            // newFieldValue
            // 
            newFieldValue.Anchor = AnchorStyles.Bottom | AnchorStyles.Right;
            newFieldValue.Location = new Point(875, 551);
            newFieldValue.Margin = new Padding(3, 4, 3, 4);
            newFieldValue.Name = "newFieldValue";
            newFieldValue.Size = new Size(125, 27);
            newFieldValue.TabIndex = 32;
            // 
            // label11
            // 
            label11.Anchor = AnchorStyles.Bottom | AnchorStyles.Right;
            label11.AutoSize = true;
            label11.Font = new Font("Times New Roman", 10.8F, FontStyle.Bold, GraphicsUnit.Point, 204);
            label11.Location = new Point(722, 554);
            label11.Name = "label11";
            label11.Size = new Size(137, 20);
            label11.TabIndex = 33;
            label11.Text = "Новое значение";
            // 
            // label12
            // 
            label12.Anchor = AnchorStyles.Bottom | AnchorStyles.Right;
            label12.AutoSize = true;
            label12.Font = new Font("Times New Roman", 10.8F, FontStyle.Bold, GraphicsUnit.Point, 204);
            label12.Location = new Point(722, 504);
            label12.Name = "label12";
            label12.Size = new Size(133, 20);
            label12.TabIndex = 34;
            label12.Text = "Выберите поле";
            // 
            // Form1
            // 
            AutoScaleDimensions = new SizeF(8F, 20F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(1013, 663);
            Controls.Add(label12);
            Controls.Add(label11);
            Controls.Add(newFieldValue);
            Controls.Add(label10);
            Controls.Add(objectFields);
            Controls.Add(btnBack);
            Controls.Add(btnClear);
            Controls.Add(btnShowHex);
            Controls.Add(btnModifyFields);
            Controls.Add(btnShowField);
            Controls.Add(btnShowInfo);
            Controls.Add(groupBoxDisplay);
            Controls.Add(groupBoxStatus);
            Controls.Add(groupBoxInput);
            Controls.Add(lblObjectCount);
            Controls.Add(panel1);
            MinimumSize = new Size(836, 687);
            Name = "Form1";
            Text = "Интернет-магазин (Вариант 11)";
            panel1.ResumeLayout(false);
            panel1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)numericUpDown1).EndInit();
            ((System.ComponentModel.ISupportInitialize)numericUpDown2).EndInit();
            ((System.ComponentModel.ISupportInitialize)numericUpDown3).EndInit();
            ((System.ComponentModel.ISupportInitialize)numericUpDown4).EndInit();
            groupBoxDisplay.ResumeLayout(false);
            groupBoxDisplay.PerformLayout();
            groupBoxInput.ResumeLayout(false);
            groupBoxInput.PerformLayout();
            groupBoxStatus.ResumeLayout(false);
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion
        private Label label1;
        private Panel panel1;
        private Label label2;
        private Button button1;
        private TextBox textBox1;
        private Label label3;
        private Label label4;
        private TextBox textBox2;
        private Label label5;
        private NumericUpDown numericUpDown1;
        private Label label6;
        private NumericUpDown numericUpDown2;
        private Label label7;
        private NumericUpDown numericUpDown3;
        private Label label8;
        private NumericUpDown numericUpDown4;
        private Label label9;
        private ComboBox comboBox1;
        private Label lblObjectCount;
        private GroupBox groupBoxInput;
        private GroupBox groupBoxStatus;
        private GroupBox groupBoxDisplay;
        private TextBox txtDisplayInfo;
        private Button btnShowInfo;
        private Button btnShowField;
        private Button btnModifyFields;
        private Button btnShowHex;
        private Button btnClear;
        private Button btnBack;
        private ContextMenuStrip contextMenuStrip1;
        private ComboBox objectFields;
        private Label label10;
        private TextBox newFieldValue;
        private Label label11;
        private Label label12;
    }
}