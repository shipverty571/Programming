namespace ObjectOrientedPractics.View
{
    partial class MainForm
    {
        /// <summary>
        /// Обязательная переменная конструктора.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Освободить все используемые ресурсы.
        /// </summary>
        /// <param name="disposing">истинно, если управляемый ресурс должен быть удален; иначе ложно.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Код, автоматически созданный конструктором форм Windows

        /// <summary>
        /// Требуемый метод для поддержки конструктора — не изменяйте 
        /// содержимое этого метода с помощью редактора кода.
        /// </summary>
        private void InitializeComponent()
        {
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(MainForm));
            this.TabControl = new System.Windows.Forms.TabControl();
            this.ItemsPage = new System.Windows.Forms.TabPage();
            this.ItemsTab = new ObjectOrientedPractics.View.Tabs.ItemsTab();
            this.CustomersPage = new System.Windows.Forms.TabPage();
            this.CustomersTab = new ObjectOrientedPractics.View.Tabs.CustomersTab();
            this.CartsTabPage = new System.Windows.Forms.TabPage();
            this.CartsTab = new ObjectOrientedPractics.View.Tabs.CartsTab();
            this.OrdersTabPage = new System.Windows.Forms.TabPage();
            this.OrdersTab = new ObjectOrientedPractics.View.Tabs.OrdersTab();
            this.TabControl.SuspendLayout();
            this.ItemsPage.SuspendLayout();
            this.CustomersPage.SuspendLayout();
            this.CartsTabPage.SuspendLayout();
            this.OrdersTabPage.SuspendLayout();
            this.SuspendLayout();
            // 
            // TabControl
            // 
            this.TabControl.Controls.Add(this.ItemsPage);
            this.TabControl.Controls.Add(this.CustomersPage);
            this.TabControl.Controls.Add(this.CartsTabPage);
            this.TabControl.Controls.Add(this.OrdersTabPage);
            this.TabControl.Dock = System.Windows.Forms.DockStyle.Fill;
            this.TabControl.Location = new System.Drawing.Point(0, 0);
            this.TabControl.Name = "TabControl";
            this.TabControl.SelectedIndex = 0;
            this.TabControl.Size = new System.Drawing.Size(784, 461);
            this.TabControl.TabIndex = 0;
            this.TabControl.SelectedIndexChanged += new System.EventHandler(this.TabControl_SelectedIndexChanged);
            // 
            // ItemsPage
            // 
            this.ItemsPage.Controls.Add(this.ItemsTab);
            this.ItemsPage.Location = new System.Drawing.Point(4, 22);
            this.ItemsPage.Name = "ItemsPage";
            this.ItemsPage.Padding = new System.Windows.Forms.Padding(3);
            this.ItemsPage.Size = new System.Drawing.Size(776, 435);
            this.ItemsPage.TabIndex = 0;
            this.ItemsPage.Text = "Items";
            this.ItemsPage.UseVisualStyleBackColor = true;
            // 
            // ItemsTab
            // 
            this.ItemsTab.Dock = System.Windows.Forms.DockStyle.Fill;
            this.ItemsTab.Items = null;
            this.ItemsTab.Location = new System.Drawing.Point(3, 3);
            this.ItemsTab.Name = "ItemsTab";
            this.ItemsTab.Size = new System.Drawing.Size(770, 429);
            this.ItemsTab.TabIndex = 0;
            // 
            // CustomersPage
            // 
            this.CustomersPage.Controls.Add(this.CustomersTab);
            this.CustomersPage.Location = new System.Drawing.Point(4, 22);
            this.CustomersPage.Name = "CustomersPage";
            this.CustomersPage.Padding = new System.Windows.Forms.Padding(3);
            this.CustomersPage.Size = new System.Drawing.Size(776, 435);
            this.CustomersPage.TabIndex = 1;
            this.CustomersPage.Text = "Customers";
            this.CustomersPage.UseVisualStyleBackColor = true;
            // 
            // CustomersTab
            // 
            this.CustomersTab.Customers = null;
            this.CustomersTab.Dock = System.Windows.Forms.DockStyle.Fill;
            this.CustomersTab.Location = new System.Drawing.Point(3, 3);
            this.CustomersTab.Name = "CustomersTab";
            this.CustomersTab.Size = new System.Drawing.Size(770, 429);
            this.CustomersTab.TabIndex = 0;
            // 
            // CartsTabPage
            // 
            this.CartsTabPage.Controls.Add(this.CartsTab);
            this.CartsTabPage.Location = new System.Drawing.Point(4, 22);
            this.CartsTabPage.Name = "CartsTabPage";
            this.CartsTabPage.Padding = new System.Windows.Forms.Padding(3);
            this.CartsTabPage.Size = new System.Drawing.Size(776, 435);
            this.CartsTabPage.TabIndex = 2;
            this.CartsTabPage.Text = "Carts";
            this.CartsTabPage.UseVisualStyleBackColor = true;
            // 
            // CartsTab
            // 
            this.CartsTab.Customers = null;
            this.CartsTab.Dock = System.Windows.Forms.DockStyle.Fill;
            this.CartsTab.Items = null;
            this.CartsTab.Location = new System.Drawing.Point(3, 3);
            this.CartsTab.Name = "CartsTab";
            this.CartsTab.Size = new System.Drawing.Size(770, 429);
            this.CartsTab.TabIndex = 0;
            // 
            // OrdersTabPage
            // 
            this.OrdersTabPage.Controls.Add(this.OrdersTab);
            this.OrdersTabPage.Location = new System.Drawing.Point(4, 22);
            this.OrdersTabPage.Name = "OrdersTabPage";
            this.OrdersTabPage.Padding = new System.Windows.Forms.Padding(3);
            this.OrdersTabPage.Size = new System.Drawing.Size(776, 435);
            this.OrdersTabPage.TabIndex = 3;
            this.OrdersTabPage.Text = "Orders";
            this.OrdersTabPage.UseVisualStyleBackColor = true;
            // 
            // OrdersTab
            // 
            this.OrdersTab.Dock = System.Windows.Forms.DockStyle.Fill;
            this.OrdersTab.Location = new System.Drawing.Point(3, 3);
            this.OrdersTab.Name = "OrdersTab";
            this.OrdersTab.Size = new System.Drawing.Size(770, 429);
            this.OrdersTab.TabIndex = 0;
            // 
            // MainForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(784, 461);
            this.Controls.Add(this.TabControl);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.MinimumSize = new System.Drawing.Size(800, 500);
            this.Name = "MainForm";
            this.Text = "Object Oriented Practics";
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.MainForm_FormClosing);
            this.TabControl.ResumeLayout(false);
            this.ItemsPage.ResumeLayout(false);
            this.CustomersPage.ResumeLayout(false);
            this.CartsTabPage.ResumeLayout(false);
            this.OrdersTabPage.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.TabControl TabControl;
        private View.Tabs.ItemsTab itemsTab1;
        private System.Windows.Forms.TabPage CustomersPage;
        private System.Windows.Forms.TabPage ItemsPage;
        private ObjectOrientedPractics.View.Tabs.ItemsTab ItemsTab;
        private Tabs.CustomersTab CustomersTab;
        private System.Windows.Forms.TabPage CartsTabPage;
        private Tabs.CartsTab CartsTab;
        private System.Windows.Forms.TabPage OrdersTabPage;
        private Tabs.OrdersTab OrdersTab;
    }
}

