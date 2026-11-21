
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
        private void buttonAdd_Click(object sender, EventArgs e) { _container.Resolve<FormEmployee>().ShowDialog(); LoadList(); }

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
            dataGridViewData.Size = new Size(618, 455);
            dataGridViewData.TabIndex = 0;
            // 
            // panel1
            // 
            panel1.Controls.Add(buttonAdd);
            panel1.Dock = DockStyle.Right;
            panel1.Location = new Point(418, 0);
            panel1.Name = "panel1";
            panel1.Size = new Size(200, 455);
            panel1.TabIndex = 1;
            panel1.Paint += panel1_Paint;
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

        private void LoadList() => dataGridViewData.DataSource = _repository.ReadEmployees();

        private void panel1_Paint(object sender, PaintEventArgs e)
        {

        }

        private DataGridView dataGridViewData;
        private Panel panel1;
        private Button buttonAdd;
    }
}