using System;
using System.Windows.Forms;
using WoodworkingWorkshop.Entities;
using WoodworkingWorkshop.Repositories;

namespace WoodworkingWorkshop.Forms
{
    public partial class FormProduct : Form
    {
        private readonly IProductRepository _repository;
        private Label label1;
        private Label label2;
        private TextBox textBoxName;
        private TextBox textBoxDescription;
        private Button buttonSave;
        private Button buttonCancel;
        private int? _id;

        public FormProduct(IProductRepository repository)
        {
            InitializeComponent();
            _repository = repository ?? throw new ArgumentNullException(nameof(repository));
        }

        public int Id
        {
            set
            {
                var product = _repository.ReadProductById(value);
                if (product != null)
                {
                    textBoxName.Text = product.Name;
                    textBoxDescription.Text = product.Description;
                    _id = value;
                }
            }
        }

        private void buttonSave_Click(object sender, EventArgs e)
        {
            try
            {
                if (string.IsNullOrWhiteSpace(textBoxName.Text))
                    throw new Exception("Имеются незаполненные поля");

                var product = Product.CreateEntity(_id ?? 0, textBoxName.Text, textBoxDescription.Text);

                if (_id.HasValue) _repository.UpdateProduct(product);
                else _repository.CreateProduct(product);
                Close();
            }
            catch (Exception ex) { MessageBox.Show(ex.Message, "Ошибка", MessageBoxButtons.OK, MessageBoxIcon.Error); }
        }

        private void InitializeComponent()
        {
            label1 = new Label();
            label2 = new Label();
            textBoxName = new TextBox();
            textBoxDescription = new TextBox();
            buttonSave = new Button();
            buttonCancel = new Button();
            SuspendLayout();
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.Location = new Point(36, 24);
            label1.Name = "label1";
            label1.Size = new Size(62, 15);
            label1.TabIndex = 0;
            label1.Text = "Название:";
            // 
            // label2
            // 
            label2.AutoSize = true;
            label2.Location = new Point(36, 97);
            label2.Name = "label2";
            label2.Size = new Size(65, 15);
            label2.TabIndex = 1;
            label2.Text = "Описание:";
            // 
            // textBoxName
            // 
            textBoxName.Location = new Point(119, 21);
            textBoxName.Name = "textBoxName";
            textBoxName.Size = new Size(100, 23);
            textBoxName.TabIndex = 2;
            // 
            // textBoxDescription
            // 
            textBoxDescription.Location = new Point(119, 97);
            textBoxDescription.Multiline = true;
            textBoxDescription.Name = "textBoxDescription";
            textBoxDescription.Size = new Size(100, 23);
            textBoxDescription.TabIndex = 3;
            // 
            // buttonSave
            // 
            buttonSave.Location = new Point(50, 147);
            buttonSave.Name = "buttonSave";
            buttonSave.Size = new Size(75, 23);
            buttonSave.TabIndex = 4;
            buttonSave.Text = "Сохранить";
            buttonSave.UseVisualStyleBackColor = true;
            buttonSave.Click += buttonSave_Click;
            // 
            // buttonCancel
            // 
            buttonCancel.Location = new Point(163, 147);
            buttonCancel.Name = "buttonCancel";
            buttonCancel.Size = new Size(75, 23);
            buttonCancel.TabIndex = 5;
            buttonCancel.Text = "Отмена";
            buttonCancel.UseVisualStyleBackColor = true;
            buttonCancel.Click += buttonCancel_Click;
            // 
            // FormProduct
            // 
            ClientSize = new Size(560, 399);
            Controls.Add(buttonCancel);
            Controls.Add(buttonSave);
            Controls.Add(textBoxDescription);
            Controls.Add(textBoxName);
            Controls.Add(label2);
            Controls.Add(label1);
            Name = "FormProduct";
            Text = "Создание\\редактирование изделия";
            ResumeLayout(false);
            PerformLayout();

        }

        private void buttonCancel_Click(object sender, EventArgs e) => Close();
    }
}