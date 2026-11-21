using System;
using System.Windows.Forms;
using Unity;
using WoodworkingWorkshop.Repositories;

namespace WoodworkingWorkshop.Forms
{
    public partial class FormMaterialUsages : Form
    {
        private readonly IUnityContainer _container;
        private readonly IMaterialUsageRepository _repository;

        // Объявления элементов перенесены в начало
        private DataGridView dataGridViewData;
        private Panel panel2;
        private Button buttonAdd;
        private Button buttonDelete;

        public FormMaterialUsages(IUnityContainer container, IMaterialUsageRepository repository)
        {
            InitializeComponent();
            _container = container ?? throw new ArgumentNullException(nameof(container));
            _repository = repository ?? throw new ArgumentNullException(nameof(repository));
        }

        private void FormMaterialUsages_Load(object sender, EventArgs e) => LoadList();

        // ДОБАВИТЬ
        private void buttonAdd_Click(object sender, EventArgs e)
        {
            _container.Resolve<FormMaterialUsage>().ShowDialog();
            LoadList();
        }

        // УДАЛИТЬ
        private void buttonDelete_Click(object sender, EventArgs e)
        {
            if (!TryGetIdentifierFromSelectedRow(out var findId)) return;

            if (MessageBox.Show("Удалить запись?", "Удаление", MessageBoxButtons.YesNo) != DialogResult.Yes)
                return;

            _repository.DeleteMaterialUsage(findId);
            LoadList();
        }

        private void LoadList() => dataGridViewData.DataSource = _repository.ReadMaterialUsages();

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
            panel2 = new Panel();
            buttonAdd = new Button();
            buttonDelete = new Button();
            ((System.ComponentModel.ISupportInitialize)dataGridViewData).BeginInit();
            panel2.SuspendLayout();
            SuspendLayout();
            // 
            // dataGridViewData
            // 
            dataGridViewData.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            dataGridViewData.Dock = DockStyle.Fill;
            dataGridViewData.Location = new Point(0, 0);
            dataGridViewData.Name = "dataGridViewData";
            dataGridViewData.Size = new Size(771, 454);
            dataGridViewData.TabIndex = 0;
            // 
            // panel2
            // 
            panel2.Controls.Add(buttonAdd);
            panel2.Controls.Add(buttonDelete);
            panel2.Dock = DockStyle.Right;
            panel2.Location = new Point(571, 0);
            panel2.Name = "panel2";
            panel2.Size = new Size(200, 454);
            panel2.TabIndex = 1;
            // 
            // buttonAdd
            // 
            buttonAdd.Location = new Point(19, 12);
            buttonAdd.Name = "buttonAdd";
            buttonAdd.Size = new Size(169, 45);
            buttonAdd.TabIndex = 0;
            buttonAdd.Text = "Добавить";
            buttonAdd.UseVisualStyleBackColor = true;
            buttonAdd.Click += buttonAdd_Click;
            // 
            // buttonDelete
            // 
            buttonDelete.Location = new Point(19, 70);
            buttonDelete.Name = "buttonDelete";
            buttonDelete.Size = new Size(169, 45);
            buttonDelete.TabIndex = 1;
            buttonDelete.Text = "Удалить";
            buttonDelete.UseVisualStyleBackColor = true;
            buttonDelete.Click += buttonDelete_Click;
            // 
            // FormMaterialUsages
            // 
            ClientSize = new Size(771, 454);
            Controls.Add(panel2);
            Controls.Add(dataGridViewData);
            Name = "FormMaterialUsages";
            Text = "Список расходов";
            Load += FormMaterialUsages_Load;
            ((System.ComponentModel.ISupportInitialize)dataGridViewData).EndInit();
            panel2.ResumeLayout(false);
            ResumeLayout(false);
        }
    }
}