using System;
using System.Windows.Forms;
using Unity;
using WoodworkingWorkshop.Repositories;

namespace WoodworkingWorkshop.Forms
{
    public partial class FormEmployees : Form
    {
        private readonly IUnityContainer _container;
        private readonly IEmployeeRepository _repository;

        public FormEmployees(IUnityContainer container, IEmployeeRepository repository)
        {
            InitializeComponent();
            _container = container ?? throw new ArgumentNullException(nameof(container));
            _repository = repository ?? throw new ArgumentNullException(nameof(repository));
        }

        private void FormEmployees_Load(object sender, EventArgs e) => LoadList();

        // ДОБАВИТЬ
        private void buttonAdd_Click(object sender, EventArgs e)
        {
            _container.Resolve<FormEmployee>().ShowDialog();
            LoadList();
        }

        // ИЗМЕНИТЬ
        private void buttonEdit_Click(object sender, EventArgs e)
        {
            if (!TryGetIdentifierFromSelectedRow(out var findId)) return;

            var form = _container.Resolve<FormEmployee>();
            form.Id = findId;
            form.ShowDialog();
            LoadList();
        }

        // УДАЛИТЬ
        private void buttonDelete_Click(object sender, EventArgs e)
        {
            if (!TryGetIdentifierFromSelectedRow(out var findId)) return;

            if (MessageBox.Show("Удалить запись?", "Удаление", MessageBoxButtons.YesNo) != DialogResult.Yes)
                return;

            _repository.DeleteEmployee(findId);
            LoadList();
        }

        private void LoadList() => dataGridViewData.DataSource = _repository.ReadEmployees();

        private bool TryGetIdentifierFromSelectedRow(out int id)
        {
            id = 0;
            if (dataGridViewData.SelectedRows.Count < 1)
            {
                MessageBox.Show("Нет выбранной записи", "Ошибка", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return false;
            }
            id = Convert.ToInt32(dataGridViewData.SelectedRows[0].Cells["Id"].Value);
            return true;
        }

        private void InitializeComponent()
        {
            dataGridViewData = new DataGridView();
            panel1 = new Panel();
            buttonAdd = new Button();
            buttonEdit = new Button();
            buttonDelete = new Button();
            ((System.ComponentModel.ISupportInitialize)dataGridViewData).BeginInit();
            panel1.SuspendLayout();
            SuspendLayout();
            // 
            // dataGridViewData
            // 
            dataGridViewData.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            dataGridViewData.Dock = DockStyle.Fill;
            dataGridViewData.Location = new Point(0, 0);
            dataGridViewData.Name = "dataGridViewData";
            dataGridViewData.Size = new Size(618, 455);
            dataGridViewData.TabIndex = 0;
            // 
            // panel1
            // 
            panel1.Controls.Add(buttonAdd);
            panel1.Controls.Add(buttonEdit);
            panel1.Controls.Add(buttonDelete);
            panel1.Dock = DockStyle.Right;
            panel1.Location = new Point(418, 0);
            panel1.Name = "panel1";
            panel1.Size = new Size(200, 455);
            panel1.TabIndex = 1;
            // 
            // buttonAdd
            // 
            buttonAdd.Location = new Point(19, 12);
            buttonAdd.Name = "buttonAdd";
            buttonAdd.Size = new Size(169, 43);
            buttonAdd.TabIndex = 0;
            buttonAdd.Text = "Добавить";
            buttonAdd.UseVisualStyleBackColor = true;
            buttonAdd.Click += buttonAdd_Click;
            // 
            // buttonEdit
            // 
            buttonEdit.Location = new Point(19, 70);
            buttonEdit.Name = "buttonEdit";
            buttonEdit.Size = new Size(169, 43);
            buttonEdit.TabIndex = 1;
            buttonEdit.Text = "Изменить";
            buttonEdit.UseVisualStyleBackColor = true;
            buttonEdit.Click += buttonEdit_Click;
            // 
            // buttonDelete
            // 
            buttonDelete.Location = new Point(19, 128);
            buttonDelete.Name = "buttonDelete";
            buttonDelete.Size = new Size(169, 43);
            buttonDelete.TabIndex = 2;
            buttonDelete.Text = "Удалить";
            buttonDelete.UseVisualStyleBackColor = true;
            buttonDelete.Click += buttonDelete_Click;
            // 
            // FormEmployees
            // 
            ClientSize = new Size(618, 455);
            Controls.Add(panel1);
            Controls.Add(dataGridViewData);
            Name = "FormEmployees";
            Text = "Список работников";
            Load += FormEmployees_Load;
            ((System.ComponentModel.ISupportInitialize)dataGridViewData).EndInit();
            panel1.ResumeLayout(false);
            ResumeLayout(false);
        }

        private DataGridView dataGridViewData;
        private Panel panel1;
        private Button buttonAdd;
        private Button buttonEdit;
        private Button buttonDelete;
    }
}