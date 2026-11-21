using System;
using System.Collections.Generic;
using System.Windows.Forms;
using WoodworkingWorkshop.Entities;
using WoodworkingWorkshop.Repositories;

namespace WoodworkingWorkshop.Forms
{
    public partial class FormMaterialUsage : Form
    {
        private readonly IMaterialUsageRepository _repository;

        public FormMaterialUsage(IMaterialUsageRepository repository, IEmployeeRepository employeeRepo, IMaterialRepository materialRepo)
        {
            InitializeComponent();
            _repository = repository ?? throw new ArgumentNullException(nameof(repository));

            comboBoxEmployee.DataSource = employeeRepo.ReadEmployees();
            comboBoxEmployee.DisplayMember = "LastName";
            comboBoxEmployee.ValueMember = "Id";

            // Настройка выпадающего списка внутри таблицы
            ColumnMaterial.DataSource = materialRepo.ReadMaterials();
            ColumnMaterial.DisplayMember = "Name";
            ColumnMaterial.ValueMember = "Id";
        }

        private void buttonSave_Click(object sender, EventArgs e)
        {
            try
            {
                if (comboBoxEmployee.SelectedIndex < 0 || dataGridViewData.Rows.Count < 1)
                    throw new Exception("Имеются незаполненные поля");

                var items = new List<MaterialUsageItem>();
                foreach (DataGridViewRow row in dataGridViewData.Rows)
                {
                    if (row.Cells["ColumnMaterial"].Value == null || row.Cells["ColumnCount"].Value == null) continue;
                    items.Add(MaterialUsageItem.CreateElement(0, Convert.ToInt32(row.Cells["ColumnMaterial"].Value), Convert.ToDouble(row.Cells["ColumnCount"].Value)));
                }

                _repository.CreateMaterialUsage(MaterialUsage.CreateOperation(0, (int)comboBoxEmployee.SelectedValue!, items));
                Close();
            }
            catch (Exception ex) { MessageBox.Show(ex.Message, "Ошибка", MessageBoxButtons.OK, MessageBoxIcon.Error); }
        }

        private void InitializeComponent()
        {
            label1 = new Label();
            comboBoxEmployee = new ComboBox();
            dataGridViewData = new DataGridView();
            buttonSave = new Button();
            buttonCancel = new Button();
            ColumnMaterial = new DataGridViewComboBoxColumn();
            ColumnCount = new DataGridViewComboBoxColumn();
            ((System.ComponentModel.ISupportInitialize)dataGridViewData).BeginInit();
            SuspendLayout();
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.Location = new Point(24, 23);
            label1.Name = "label1";
            label1.Size = new Size(69, 15);
            label1.TabIndex = 0;
            label1.Text = "Сотрудник:";
            // 
            // comboBoxEmployee
            // 
            comboBoxEmployee.FormattingEnabled = true;
            comboBoxEmployee.Location = new Point(114, 20);
            comboBoxEmployee.Name = "comboBoxEmployee";
            comboBoxEmployee.Size = new Size(121, 23);
            comboBoxEmployee.TabIndex = 1;
            // 
            // dataGridViewData
            // 
            dataGridViewData.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            dataGridViewData.Columns.AddRange(new DataGridViewColumn[] { ColumnMaterial, ColumnCount });
            dataGridViewData.Location = new Point(24, 72);
            dataGridViewData.Name = "dataGridViewData";
            dataGridViewData.Size = new Size(242, 109);
            dataGridViewData.TabIndex = 2;
            dataGridViewData.CellContentClick += dataGridView1_CellContentClick;
            // 
            // buttonSave
            // 
            buttonSave.Location = new Point(50, 208);
            buttonSave.Name = "buttonSave";
            buttonSave.Size = new Size(75, 23);
            buttonSave.TabIndex = 3;
            buttonSave.Text = "Сохранить";
            buttonSave.UseVisualStyleBackColor = true;
            buttonSave.Click += buttonSave_Click;
            // 
            // buttonCancel
            // 
            buttonCancel.Location = new Point(160, 208);
            buttonCancel.Name = "buttonCancel";
            buttonCancel.Size = new Size(75, 23);
            buttonCancel.TabIndex = 4;
            buttonCancel.Text = "Отмена";
            buttonCancel.UseVisualStyleBackColor = true;
            buttonCancel.Click += buttonCancel_Click;
            // 
            // ColumnMaterial
            // 
            ColumnMaterial.HeaderText = "Материал";
            ColumnMaterial.Name = "ColumnMaterial";
            ColumnMaterial.Resizable = DataGridViewTriState.True;
            ColumnMaterial.SortMode = DataGridViewColumnSortMode.Automatic;
            // 
            // ColumnCount
            // 
            ColumnCount.HeaderText = "Количество ";
            ColumnCount.Name = "ColumnCount";
            ColumnCount.Resizable = DataGridViewTriState.True;
            ColumnCount.SortMode = DataGridViewColumnSortMode.Automatic;
            // 
            // FormMaterialUsage
            // 
            ClientSize = new Size(506, 424);
            Controls.Add(buttonCancel);
            Controls.Add(buttonSave);
            Controls.Add(dataGridViewData);
            Controls.Add(comboBoxEmployee);
            Controls.Add(label1);
            Name = "FormMaterialUsage";
            Text = "Создание расхода";
            ((System.ComponentModel.ISupportInitialize)dataGridViewData).EndInit();
            ResumeLayout(false);
            PerformLayout();

        }

        private void buttonCancel_Click(object sender, EventArgs e) => Close();

        private void dataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }

        private Label label1;
        private ComboBox comboBoxEmployee;
        private DataGridView dataGridViewData;
        private Button buttonSave;
        private Button buttonCancel;
        private DataGridViewComboBoxColumn ColumnMaterial;
        private DataGridViewComboBoxColumn ColumnCount;
    }
}