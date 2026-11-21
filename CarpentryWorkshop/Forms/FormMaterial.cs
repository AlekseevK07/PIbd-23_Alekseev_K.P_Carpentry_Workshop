using System;
using System.Windows.Forms;
using WoodworkingWorkshop.Entities;
using WoodworkingWorkshop.Entities.Enums;
using WoodworkingWorkshop.Repositories;

namespace WoodworkingWorkshop.Forms
{
    public partial class FormMaterial : Form
    {
        private readonly IMaterialRepository _repository;
        private Label label1;
        private Label label2;
        private Label label3;
        private TextBox textBoxName;
        private NumericUpDown numericUpDownQty;
        private CheckedListBox checkedListBoxMaterialType;
        private Button buttonSave;
        private Button buttonCancel;
        private int? _id;

        public FormMaterial(IMaterialRepository repository)
        {
            InitializeComponent();
            _repository = repository ?? throw new ArgumentNullException(nameof(repository));

            foreach (var elem in Enum.GetValues(typeof(MaterialType)))
                checkedListBoxMaterialType.Items.Add(elem);
        }

        public int Id
        {
            set
            {
                var material = _repository.ReadMaterialById(value);
                if (material != null)
                {
                    textBoxName.Text = material.Name;
                    numericUpDownQty.Value = (decimal)material.QuantityInStock;
                    foreach (MaterialType elem in Enum.GetValues(typeof(MaterialType)))
                    {
                        if ((elem & material.MaterialType) != 0)
                            checkedListBoxMaterialType.SetItemChecked(checkedListBoxMaterialType.Items.IndexOf(elem), true);
                    }
                    _id = value;
                }
            }
        }

        private void buttonSave_Click(object sender, EventArgs e)
        {
            try
            {
                if (string.IsNullOrWhiteSpace(textBoxName.Text) || checkedListBoxMaterialType.CheckedItems.Count == 0)
                    throw new Exception("Имеются незаполненные поля");

                MaterialType type = MaterialType.None;
                foreach (var item in checkedListBoxMaterialType.CheckedItems)
                    type |= (MaterialType)item;

                var material = Material.CreateEntity(_id ?? 0, textBoxName.Text, type, (double)numericUpDownQty.Value);

                if (_id.HasValue) _repository.UpdateMaterial(material);
                else _repository.CreateMaterial(material);

                Close();
            }
            catch (Exception ex) { MessageBox.Show(ex.Message, "Ошибка", MessageBoxButtons.OK, MessageBoxIcon.Error); }
        }



        private void InitializeComponent()
        {
            label1 = new Label();
            label2 = new Label();
            label3 = new Label();
            textBoxName = new TextBox();
            numericUpDownQty = new NumericUpDown();
            checkedListBoxMaterialType = new CheckedListBox();
            buttonSave = new Button();
            buttonCancel = new Button();
            ((System.ComponentModel.ISupportInitialize)numericUpDownQty).BeginInit();
            SuspendLayout();
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.Location = new Point(18, 12);
            label1.Name = "label1";
            label1.Size = new Size(62, 15);
            label1.TabIndex = 0;
            label1.Text = "Название:";
            // 
            // label2
            // 
            label2.AutoSize = true;
            label2.Location = new Point(18, 77);
            label2.Name = "label2";
            label2.Size = new Size(65, 15);
            label2.TabIndex = 1;
            label2.Text = "Материал:";
            // 
            // label3
            // 
            label3.AutoSize = true;
            label3.Location = new Point(18, 195);
            label3.Name = "label3";
            label3.Size = new Size(75, 15);
            label3.TabIndex = 2;
            label3.Text = "Количество:";
            // 
            // textBoxName
            // 
            textBoxName.Location = new Point(110, 9);
            textBoxName.Name = "textBoxName";
            textBoxName.Size = new Size(100, 23);
            textBoxName.TabIndex = 3;
            // 
            // numericUpDownQty
            // 
            numericUpDownQty.DecimalPlaces = 2;
            numericUpDownQty.Location = new Point(110, 193);
            numericUpDownQty.Name = "numericUpDownQty";
            numericUpDownQty.Size = new Size(120, 23);
            numericUpDownQty.TabIndex = 4;
            // 
            // checkedListBoxMaterialType
            // 
            checkedListBoxMaterialType.FormattingEnabled = true;
            checkedListBoxMaterialType.Location = new Point(110, 73);
            checkedListBoxMaterialType.Name = "checkedListBoxMaterialType";
            checkedListBoxMaterialType.Size = new Size(120, 94);
            checkedListBoxMaterialType.TabIndex = 5;
            // 
            // buttonSave
            // 
            buttonSave.Location = new Point(39, 237);
            buttonSave.Name = "buttonSave";
            buttonSave.Size = new Size(75, 23);
            buttonSave.TabIndex = 6;
            buttonSave.Text = "Сохранить";
            buttonSave.UseVisualStyleBackColor = true;
            buttonSave.Click += buttonSave_Click;
            // 
            // buttonCancel
            // 
            buttonCancel.Location = new Point(135, 237);
            buttonCancel.Name = "buttonCancel";
            buttonCancel.Size = new Size(75, 23);
            buttonCancel.TabIndex = 7;
            buttonCancel.Text = "Отмена";
            buttonCancel.UseVisualStyleBackColor = true;
            buttonCancel.Click += buttonCancel_Click;
            // 
            // FormMaterial
            // 
            ClientSize = new Size(475, 388);
            Controls.Add(buttonCancel);
            Controls.Add(buttonSave);
            Controls.Add(checkedListBoxMaterialType);
            Controls.Add(numericUpDownQty);
            Controls.Add(textBoxName);
            Controls.Add(label3);
            Controls.Add(label2);
            Controls.Add(label1);
            Name = "FormMaterial";
            Text = "Создание\\редактирование";
            ((System.ComponentModel.ISupportInitialize)numericUpDownQty).EndInit();
            ResumeLayout(false);
            PerformLayout();

        }

        private void buttonCancel_Click(object sender, EventArgs e) => Close();
    }
}