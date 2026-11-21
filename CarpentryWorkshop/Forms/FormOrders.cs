using WoodworkingWorkshop.Forms;
using System;
using System.Windows.Forms;
using Unity;
using WoodworkingWorkshop.Repositories;

namespace WoodworkingWorkshop.Forms
{
    public partial class FormOrders : Form
    {
        private readonly IUnityContainer _container;
        private readonly IOrderRepository _repository;

        public FormOrders(IUnityContainer container, IOrderRepository repository)
        {
            InitializeComponent();
            _container = container ?? throw new ArgumentNullException(nameof(container));
            _repository = repository ?? throw new ArgumentNullException(nameof(repository));
        }

        private void FormOrders_Load(object sender, EventArgs e) => LoadList();
        private void buttonAdd_Click(object sender, EventArgs e) { _container.Resolve<FormOrder>().ShowDialog(); LoadList(); }

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
            dataGridViewData.Size = new Size(620, 408);
            dataGridViewData.TabIndex = 0;
            // 
            // panel1
            // 
            panel1.Controls.Add(buttonAdd);
            panel1.Dock = DockStyle.Right;
            panel1.Location = new Point(420, 0);
            panel1.Name = "panel1";
            panel1.Size = new Size(200, 408);
            panel1.TabIndex = 1;
            // 
            // buttonAdd
            // 
            buttonAdd.Location = new Point(29, 12);
            buttonAdd.Name = "buttonAdd";
            buttonAdd.Size = new Size(148, 53);
            buttonAdd.TabIndex = 0;
            buttonAdd.Text = "Добавить";
            buttonAdd.UseVisualStyleBackColor = true;
            buttonAdd.Click += buttonAdd_Click;
            // 
            // FormOrders
            // 
            ClientSize = new Size(620, 408);
            Controls.Add(panel1);
            Controls.Add(dataGridViewData);
            Name = "FormOrders";
            Text = "Список заказов";
            Load += FormOrders_Load;
            ((System.ComponentModel.ISupportInitialize)dataGridViewData).EndInit();
            panel1.ResumeLayout(false);
            ResumeLayout(false);

        }

        private void LoadList() => dataGridViewData.DataSource = _repository.ReadOrders();
        private DataGridView dataGridViewData;
        private Panel panel1;
        private Button buttonAdd;
    }
}