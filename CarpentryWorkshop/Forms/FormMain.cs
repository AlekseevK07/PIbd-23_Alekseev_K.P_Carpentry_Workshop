
using System;
using System.Windows.Forms;
using Unity;

namespace WoodworkingWorkshop.Forms
{
    public partial class FormMain : Form
    {
        private readonly IUnityContainer _container;

        public FormMain(IUnityContainer container)
        {
            InitializeComponent();
            _container = container ?? throw new ArgumentNullException(nameof(container));
        }

        private void toolStripMenuItemMaterials_Click(object sender, EventArgs e) => _container.Resolve<FormMaterials>().ShowDialog();
        private void toolStripMenuItemProducts_Click(object sender, EventArgs e) => _container.Resolve<FormProducts>().ShowDialog();
        private void toolStripMenuItemEmployees_Click(object sender, EventArgs e) => _container.Resolve<FormEmployees>().ShowDialog();
        private void toolStripMenuItemOrders_Click(object sender, EventArgs e) => _container.Resolve<FormOrders>().ShowDialog();

        private void InitializeComponent()
        {
            menuStrip1 = new MenuStrip();
            справочникиToolStripMenuItem = new ToolStripMenuItem();
            материалыToolStripMenuItem = new ToolStripMenuItem();
            изделияToolStripMenuItem = new ToolStripMenuItem();
            работникиToolStripMenuItem = new ToolStripMenuItem();
            операцииToolStripMenuItem = new ToolStripMenuItem();
            заказыToolStripMenuItem = new ToolStripMenuItem();
            расходМатериаловToolStripMenuItem = new ToolStripMenuItem();
            menuStrip1.SuspendLayout();
            SuspendLayout();
            // 
            // menuStrip1
            // 
            menuStrip1.Items.AddRange(new ToolStripItem[] { справочникиToolStripMenuItem, операцииToolStripMenuItem });
            menuStrip1.Location = new Point(0, 0);
            menuStrip1.Name = "menuStrip1";
            menuStrip1.Size = new Size(538, 24);
            menuStrip1.TabIndex = 0;
            menuStrip1.Text = "menuStrip1";
            // 
            // справочникиToolStripMenuItem
            // 
            справочникиToolStripMenuItem.DropDownItems.AddRange(new ToolStripItem[] { материалыToolStripMenuItem, изделияToolStripMenuItem, работникиToolStripMenuItem });
            справочникиToolStripMenuItem.Name = "справочникиToolStripMenuItem";
            справочникиToolStripMenuItem.Size = new Size(94, 20);
            справочникиToolStripMenuItem.Text = "Справочники";
            // 
            // материалыToolStripMenuItem
            // 
            материалыToolStripMenuItem.Name = "материалыToolStripMenuItem";
            материалыToolStripMenuItem.Size = new Size(138, 22);
            материалыToolStripMenuItem.Text = "Материалы";
            материалыToolStripMenuItem.Click += материалыToolStripMenuItem_Click;
            // 
            // изделияToolStripMenuItem
            // 
            изделияToolStripMenuItem.Name = "изделияToolStripMenuItem";
            изделияToolStripMenuItem.Size = new Size(138, 22);
            изделияToolStripMenuItem.Text = "Изделия";
            изделияToolStripMenuItem.Click += изделияToolStripMenuItem_Click;
            // 
            // работникиToolStripMenuItem
            // 
            работникиToolStripMenuItem.Name = "работникиToolStripMenuItem";
            работникиToolStripMenuItem.Size = new Size(138, 22);
            работникиToolStripMenuItem.Text = "Работники";
            работникиToolStripMenuItem.Click += работникиToolStripMenuItem_Click;
            // 
            // операцииToolStripMenuItem
            // 
            операцииToolStripMenuItem.DropDownItems.AddRange(new ToolStripItem[] { заказыToolStripMenuItem, расходМатериаловToolStripMenuItem });
            операцииToolStripMenuItem.Name = "операцииToolStripMenuItem";
            операцииToolStripMenuItem.Size = new Size(75, 20);
            операцииToolStripMenuItem.Text = "Операции";
            // 
            // заказыToolStripMenuItem
            // 
            заказыToolStripMenuItem.Name = "заказыToolStripMenuItem";
            заказыToolStripMenuItem.Size = new Size(182, 22);
            заказыToolStripMenuItem.Text = "Заказы";
            заказыToolStripMenuItem.Click += заказыToolStripMenuItem_Click;
            // 
            // расходМатериаловToolStripMenuItem
            // 
            расходМатериаловToolStripMenuItem.Name = "расходМатериаловToolStripMenuItem";
            расходМатериаловToolStripMenuItem.Size = new Size(182, 22);
            расходМатериаловToolStripMenuItem.Text = "Расход Материалов";
            расходМатериаловToolStripMenuItem.Click += расходМатериаловToolStripMenuItem_Click;
            // 
            // FormMain
            // 
            ClientSize = new Size(538, 476);
            Controls.Add(menuStrip1);
            MainMenuStrip = menuStrip1;
            Name = "FormMain";
            menuStrip1.ResumeLayout(false);
            menuStrip1.PerformLayout();
            ResumeLayout(false);
            PerformLayout();

        }

        private void toolStripMenuItemMaterialUsages_Click(object sender, EventArgs e) => _container.Resolve<FormMaterialUsages>().ShowDialog();

        private void материалыToolStripMenuItem_Click(object sender, EventArgs e)
        {
            _container.Resolve<FormMaterials>().ShowDialog();
        }

        private MenuStrip menuStrip1;
        private ToolStripMenuItem справочникиToolStripMenuItem;
        private ToolStripMenuItem материалыToolStripMenuItem;
        private ToolStripMenuItem изделияToolStripMenuItem;
        private ToolStripMenuItem работникиToolStripMenuItem;
        private ToolStripMenuItem операцииToolStripMenuItem;
        private ToolStripMenuItem заказыToolStripMenuItem;
        private ToolStripMenuItem расходМатериаловToolStripMenuItem;

        private void изделияToolStripMenuItem_Click(object sender, EventArgs e)
        {
            _container.Resolve<FormProducts>().ShowDialog();
        }

        private void работникиToolStripMenuItem_Click(object sender, EventArgs e)
        {
            _container.Resolve<FormEmployees>().ShowDialog();
        }

        private void заказыToolStripMenuItem_Click(object sender, EventArgs e)
        {
            _container.Resolve<FormOrders>().ShowDialog();
        }

        private void расходМатериаловToolStripMenuItem_Click(object sender, EventArgs e)
        {
            _container.Resolve<FormMaterialUsages>().ShowDialog();
        }
    }
}