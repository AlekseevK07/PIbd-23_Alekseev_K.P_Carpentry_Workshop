
using System;
using System.Windows.Forms;
using WoodworkingWorkshop.Entities;
using WoodworkingWorkshop.Entities.Enums;
using WoodworkingWorkshop.Repositories;

namespace WoodworkingWorkshop.Forms
{
    public partial class FormEmployee : Form
    {
        private readonly IEmployeeRepository _repository;
        private Label label1;
        private Label label2;
        private Label label3;
        private TextBox textBoxFirstName;
        private TextBox textBoxLastName;
        private ComboBox comboBoxPost;
        private Button buttonSave;
        private Button buttonCancel;
        private int? _id;

        public FormEmployee(IEmployeeRepository repository)
        {
            InitializeComponent();
            _repository = repository ?? throw new ArgumentNullException(nameof(repository));
            comboBoxPost.DataSource = Enum.GetValues(typeof(EmployeePost));
        }

        public int Id
        {
            set
            {
                var emp = _repository.ReadEmployeeById(value);
                if (emp != null)
                {
                    textBoxFirstName.Text = emp.FirstName;
                    textBoxLastName.Text = emp.LastName;
                    comboBoxPost.SelectedItem = emp.EmployeePost;
                    _id = value;
                }
            }
        }

        private void buttonSave_Click(object sender, EventArgs e)
        {
            try
            {
                if (string.IsNullOrWhiteSpace(textBoxFirstName.Text) || string.IsNullOrWhiteSpace(textBoxLastName.Text))
                    throw new Exception("Имеются незаполненные поля");

                var emp = Employee.CreateEntity(_id ?? 0, textBoxFirstName.Text, textBoxLastName.Text, (EmployeePost)comboBoxPost.SelectedItem!);

                if (_id.HasValue) _repository.UpdateEmployee(emp);
                else _repository.CreateEmployee(emp);
                Close();
            }
            catch (Exception ex) { MessageBox.Show(ex.Message, "Ошибка", MessageBoxButtons.OK, MessageBoxIcon.Error); }
        }

        private void InitializeComponent()
        {
            label1 = new Label();
            label2 = new Label();
            label3 = new Label();
            textBoxFirstName = new TextBox();
            textBoxLastName = new TextBox();
            comboBoxPost = new ComboBox();
            buttonSave = new Button();
            buttonCancel = new Button();
            SuspendLayout();
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.Location = new Point(31, 34);
            label1.Name = "label1";
            label1.Size = new Size(34, 15);
            label1.TabIndex = 0;
            label1.Text = "Имя:";
            label1.Click += label1_Click;
            // 
            // label2
            // 
            label2.AutoSize = true;
            label2.Location = new Point(31, 85);
            label2.Name = "label2";
            label2.Size = new Size(61, 15);
            label2.TabIndex = 1;
            label2.Text = "Фамилия:";
            // 
            // label3
            // 
            label3.AutoSize = true;
            label3.Location = new Point(31, 140);
            label3.Name = "label3";
            label3.Size = new Size(72, 15);
            label3.TabIndex = 2;
            label3.Text = "Должность:";
            // 
            // textBoxFirstName
            // 
            textBoxFirstName.Location = new Point(122, 31);
            textBoxFirstName.Name = "textBoxFirstName";
            textBoxFirstName.Size = new Size(100, 23);
            textBoxFirstName.TabIndex = 3;
            // 
            // textBoxLastName
            // 
            textBoxLastName.Location = new Point(122, 82);
            textBoxLastName.Name = "textBoxLastName";
            textBoxLastName.Size = new Size(100, 23);
            textBoxLastName.TabIndex = 4;
            // 
            // comboBoxPost
            // 
            comboBoxPost.FormattingEnabled = true;
            comboBoxPost.Location = new Point(122, 137);
            comboBoxPost.Name = "comboBoxPost";
            comboBoxPost.Size = new Size(121, 23);
            comboBoxPost.TabIndex = 5;
            comboBoxPost.SelectedIndexChanged += comboBox1_SelectedIndexChanged;
            // 
            // buttonSave
            // 
            buttonSave.Location = new Point(52, 199);
            buttonSave.Name = "buttonSave";
            buttonSave.Size = new Size(75, 23);
            buttonSave.TabIndex = 6;
            buttonSave.Text = "Сохранить";
            buttonSave.UseVisualStyleBackColor = true;
            buttonSave.Click += buttonSave_Click;
            // 
            // buttonCancel
            // 
            buttonCancel.Location = new Point(147, 199);
            buttonCancel.Name = "buttonCancel";
            buttonCancel.Size = new Size(75, 23);
            buttonCancel.TabIndex = 7;
            buttonCancel.Text = "Отмена";
            buttonCancel.UseVisualStyleBackColor = true;
            buttonCancel.Click += buttonCancel_Click;
            // 
            // FormEmployee
            // 
            ClientSize = new Size(472, 419);
            Controls.Add(buttonCancel);
            Controls.Add(buttonSave);
            Controls.Add(comboBoxPost);
            Controls.Add(textBoxLastName);
            Controls.Add(textBoxFirstName);
            Controls.Add(label3);
            Controls.Add(label2);
            Controls.Add(label1);
            Name = "FormEmployee";
            Text = "Создание\\редактирование работника";
            ResumeLayout(false);
            PerformLayout();

        }

        private void buttonCancel_Click(object sender, EventArgs e) => Close();

        private void label1_Click(object sender, EventArgs e)
        {

        }

        private void comboBox1_SelectedIndexChanged(object sender, EventArgs e)
        {

        }
    }
}