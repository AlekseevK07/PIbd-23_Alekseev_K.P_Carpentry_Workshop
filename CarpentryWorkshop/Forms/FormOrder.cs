using System;
using System.Windows.Forms;
using WoodworkingWorkshop.Entities;
using WoodworkingWorkshop.Repositories;

namespace WoodworkingWorkshop.Forms
{
    public partial class FormOrder : Form
    {
        private readonly IOrderRepository _repository;

        public FormOrder(IOrderRepository repository, IProductRepository productRepo, IEmployeeRepository employeeRepo)
        {
            InitializeComponent();
            _repository = repository ?? throw new ArgumentNullException(nameof(repository));

            comboBoxProduct.DataSource = productRepo.ReadProducts();
            comboBoxProduct.DisplayMember = "Name";
            comboBoxProduct.ValueMember = "Id";

            comboBoxEmployee.DataSource = employeeRepo.ReadEmployees();
            comboBoxEmployee.DisplayMember = "LastName";
            comboBoxEmployee.ValueMember = "Id";
        }

        private void buttonSave_Click(object sender, EventArgs e)
        {
            try
            {
                if (comboBoxProduct.SelectedIndex < 0 || comboBoxEmployee.SelectedIndex < 0)
                    throw new Exception("Имеются незаполненные поля");

                _repository.CreateOrder(Order.CreateOperation(0, (int)comboBoxProduct.SelectedValue!, (int)comboBoxEmployee.SelectedValue!, (int)numericUpDownQty.Value));
                Close();
            }
            catch (Exception ex) { MessageBox.Show(ex.Message, "Ошибка", MessageBoxButtons.OK, MessageBoxIcon.Error); }
        }

        private void InitializeComponent()
        {
            label1 = new Label();
            label2 = new Label();
            label3 = new Label();
            comboBoxProduct = new ComboBox();
            comboBoxEmployee = new ComboBox();
            numericUpDownQty = new NumericUpDown();
            buttonSave = new Button();
            buttonCancel = new Button();
            ((System.ComponentModel.ISupportInitialize)numericUpDownQty).BeginInit();
            SuspendLayout();
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.Location = new Point(21, 28);
            label1.Name = "label1";
            label1.Size = new Size(56, 15);
            label1.TabIndex = 0;
            label1.Text = "Изделие:";
            // 
            // label2
            // 
            label2.AutoSize = true;
            label2.Location = new Point(21, 85);
            label2.Name = "label2";
            label2.Size = new Size(69, 15);
            label2.TabIndex = 1;
            label2.Text = "Сотрудник:";
            // 
            // label3
            // 
            label3.AutoSize = true;
            label3.Location = new Point(21, 142);
            label3.Name = "label3";
            label3.Size = new Size(75, 15);
            label3.TabIndex = 2;
            label3.Text = "Количество:";
            // 
            // comboBoxProduct
            // 
            comboBoxProduct.FormattingEnabled = true;
            comboBoxProduct.Location = new Point(118, 25);
            comboBoxProduct.Name = "comboBoxProduct";
            comboBoxProduct.Size = new Size(121, 23);
            comboBoxProduct.TabIndex = 3;
            // 
            // comboBoxEmployee
            // 
            comboBoxEmployee.FormattingEnabled = true;
            comboBoxEmployee.Location = new Point(118, 82);
            comboBoxEmployee.Name = "comboBoxEmployee";
            comboBoxEmployee.Size = new Size(121, 23);
            comboBoxEmployee.TabIndex = 4;
            // 
            // numericUpDownQty
            // 
            numericUpDownQty.Location = new Point(119, 140);
            numericUpDownQty.Minimum = new decimal(new int[] { 1, 0, 0, 0 });
            numericUpDownQty.Name = "numericUpDownQty";
            numericUpDownQty.Size = new Size(120, 23);
            numericUpDownQty.TabIndex = 5;
            numericUpDownQty.Value = new decimal(new int[] { 1, 0, 0, 0 });
            // 
            // buttonSave
            // 
            buttonSave.Location = new Point(47, 191);
            buttonSave.Name = "buttonSave";
            buttonSave.Size = new Size(75, 23);
            buttonSave.TabIndex = 6;
            buttonSave.Text = "Сохранить";
            buttonSave.UseVisualStyleBackColor = true;
            buttonSave.Click += buttonSave_Click;
            // 
            // buttonCancel
            // 
            buttonCancel.Location = new Point(143, 191);
            buttonCancel.Name = "buttonCancel";
            buttonCancel.Size = new Size(75, 23);
            buttonCancel.TabIndex = 7;
            buttonCancel.Text = "Отмена";
            buttonCancel.UseVisualStyleBackColor = true;
            buttonCancel.Click += buttonCancel_Click;
            // 
            // FormOrder
            // 
            ClientSize = new Size(402, 359);
            Controls.Add(buttonCancel);
            Controls.Add(buttonSave);
            Controls.Add(numericUpDownQty);
            Controls.Add(comboBoxEmployee);
            Controls.Add(comboBoxProduct);
            Controls.Add(label3);
            Controls.Add(label2);
            Controls.Add(label1);
            Name = "FormOrder";
            Text = "Создание заказа";
            ((System.ComponentModel.ISupportInitialize)numericUpDownQty).EndInit();
            ResumeLayout(false);
            PerformLayout();

        }

        private void buttonCancel_Click(object sender, EventArgs e) => Close();
        private Label label1;
        private Label label2;
        private Label label3;
        private ComboBox comboBoxProduct;
        private ComboBox comboBoxEmployee;
        private NumericUpDown numericUpDownQty;
        private Button buttonSave;
        private Button buttonCancel;
    }
}