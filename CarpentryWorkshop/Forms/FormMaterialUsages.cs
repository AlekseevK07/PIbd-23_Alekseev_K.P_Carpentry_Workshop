
using System;
using System.Windows.Forms;
using Unity;
using WoodworkingWorkshop.Repositories;

namespace WoodworkingWorkshop.Forms
{
    public partial class FormMaterialUsages : Form
    {
        private readonly IUnityContainer _container;
        private DataGridView dataGridViewData;
        private Panel panel2;
        private Button buttonAdd;
        private readonly IMaterialUsageRepository _repository;

        public FormMaterialUsages(IUnityContainer container, IMaterialUsageRepository repository)
        {
            InitializeComponent();
            _container = container ?? throw new ArgumentNullException(nameof(container));
            _repository = repository ?? throw new ArgumentNullException(nameof(repository));
        }

        private void FormMaterialUsages_Load(object sender, EventArgs e) => LoadList();
        private void buttonAdd_Click(object sender, EventArgs e) { _container.Resolve<FormMaterialUsage>().ShowDialog(); LoadList(); }

        private void InitializeComponent()
        {
            dataGridViewData = new DataGridView();
            panel2 = new Panel();
            buttonAdd = new Button();
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
            buttonAdd.Click += this.buttonAdd_Click;
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

        private void LoadList() => dataGridViewData.DataSource = _repository.ReadMaterialUsages();
        
        private Panel panel1;
        
    }
}