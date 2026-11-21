
using System;
using System.Windows.Forms;
using Unity;
using WoodworkingWorkshop.Repositories;

namespace WoodworkingWorkshop.Forms
{
    public partial class FormProducts : Form
    {
        private readonly IUnityContainer _container;
        private DataGridView dataGridViewData;
        private readonly IProductRepository _repository;

        public FormProducts(IUnityContainer container, IProductRepository repository)
        {
            InitializeComponent();
            _container = container ?? throw new ArgumentNullException(nameof(container));
            _repository = repository ?? throw new ArgumentNullException(nameof(repository));
        }

        private void FormProducts_Load(object sender, EventArgs e) => LoadList();
        private void buttonAdd_Click(object sender, EventArgs e) { _container.Resolve<FormProduct>().ShowDialog(); LoadList(); }

        private void InitializeComponent()
        {
            dataGridViewData = new DataGridView();
            panel1 = new Panel();
            buttonAdd = new Button();
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
            dataGridViewData.Size = new Size(587, 432);
            dataGridViewData.TabIndex = 0;
            // 
            // panel1
            // 
            panel1.Controls.Add(buttonAdd);
            panel1.Dock = DockStyle.Right;
            panel1.Location = new Point(387, 0);
            panel1.Name = "panel1";
            panel1.Size = new Size(200, 432);
            panel1.TabIndex = 1;
            // 
            // buttonAdd
            // 
            buttonAdd.Location = new Point(16, 12);
            buttonAdd.Name = "buttonAdd";
            buttonAdd.Size = new Size(172, 47);
            buttonAdd.TabIndex = 0;
            buttonAdd.Text = "Добавить";
            buttonAdd.UseVisualStyleBackColor = true;
            buttonAdd.Click += buttonAdd_Click;
            // 
            // FormProducts
            // 
            ClientSize = new Size(587, 432);
            Controls.Add(panel1);
            Controls.Add(dataGridViewData);
            Name = "FormProducts";
            Text = "Список изделий";
            Load += FormProducts_Load;
            ((System.ComponentModel.ISupportInitialize)dataGridViewData).EndInit();
            panel1.ResumeLayout(false);
            ResumeLayout(false);

        }

        private void LoadList() => dataGridViewData.DataSource = _repository.ReadProducts();
        
        private Panel panel1;
        private Button buttonAdd;
    }
}