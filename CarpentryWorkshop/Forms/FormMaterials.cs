using System;
using System.Windows.Forms;
using Unity;
using WoodworkingWorkshop.Repositories;

namespace WoodworkingWorkshop.Forms
{
    public partial class FormMaterials : Form
    {
        private readonly IUnityContainer _container;
        private readonly IMaterialRepository _repository;

        public FormMaterials(IUnityContainer container, IMaterialRepository repository)
        {
            InitializeComponent();
            _container = container ?? throw new ArgumentNullException(nameof(container));
            _repository = repository ?? throw new ArgumentNullException(nameof(repository));
        }

        private void FormMaterials_Load(object sender, EventArgs e) => LoadList();

        // --- НОВЫЕ ОБРАБОТЧИКИ ---
        private void buttonAdd_Click(object sender, EventArgs e)
        {
            _container.Resolve<FormMaterial>().ShowDialog();
            LoadList();
        }

        private void buttonEdit_Click(object sender, EventArgs e)
        {
            if (!TryGetIdentifierFromSelectedRow(out var findId)) return;

            var form = _container.Resolve<FormMaterial>();
            form.Id = findId;
            form.ShowDialog();
            LoadList();
        }

        private void buttonDelete_Click(object sender, EventArgs e)
        {
            if (!TryGetIdentifierFromSelectedRow(out var findId)) return;

            if (MessageBox.Show("Удалить запись?", "Удаление", MessageBoxButtons.YesNo) != DialogResult.Yes)
                return;

            _repository.DeleteMaterial(findId);
            LoadList();
        }

        private void LoadList() => dataGridViewData.DataSource = _repository.ReadMaterials();

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

        // --- КОД ДИЗАЙНЕРА (ДОБАВЛЕНЫ КНОПКИ) ---
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
            dataGridViewData.Size = new Size(650, 441);
            dataGridViewData.TabIndex = 0;
            // 
            // panel1
            // 
            panel1.Controls.Add(buttonAdd);
            panel1.Controls.Add(buttonEdit);
            panel1.Controls.Add(buttonDelete);
            panel1.Dock = DockStyle.Right;
            panel1.Location = new Point(450, 0);
            panel1.Name = "panel1";
            panel1.Size = new Size(200, 441);
            panel1.TabIndex = 1;
            // 
            // buttonAdd
            // 
            buttonAdd.Location = new Point(18, 12);
            buttonAdd.Name = "buttonAdd";
            buttonAdd.Size = new Size(170, 42);
            buttonAdd.TabIndex = 0;
            buttonAdd.Text = "Добавить";
            buttonAdd.UseVisualStyleBackColor = true;
            buttonAdd.Click += buttonAdd_Click;
            // 
            // buttonEdit
            // 
            buttonEdit.Location = new Point(18, 70);
            buttonEdit.Name = "buttonEdit";
            buttonEdit.Size = new Size(170, 42);
            buttonEdit.TabIndex = 1;
            buttonEdit.Text = "Изменить";
            buttonEdit.UseVisualStyleBackColor = true;
            buttonEdit.Click += buttonEdit_Click;
            // 
            // buttonDelete
            // 
            buttonDelete.Location = new Point(18, 128);
            buttonDelete.Name = "buttonDelete";
            buttonDelete.Size = new Size(170, 42);
            buttonDelete.TabIndex = 2;
            buttonDelete.Text = "Удалить";
            buttonDelete.UseVisualStyleBackColor = true;
            buttonDelete.Click += buttonDelete_Click;
            // 
            // FormMaterials
            // 
            ClientSize = new Size(650, 441);
            Controls.Add(panel1);
            Controls.Add(dataGridViewData);
            Name = "FormMaterials";
            Text = "Список материалов";
            Load += FormMaterials_Load;
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