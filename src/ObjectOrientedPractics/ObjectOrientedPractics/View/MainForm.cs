using System.Collections.Generic;
using System.Windows.Forms;
using ObjectOrientedPractics.Model;

namespace ObjectOrientedPractics.View
{
    /// <summary>
    /// Предоставляет реализацию по представлению главного окна.
    /// </summary>
    public partial class MainForm : Form
    {
        /// <summary>
        /// Покупатели и товары.
        /// </summary>
        private Store _store;

        /// <summary>
        /// Создаёт экземпляр класса <see cref="MainForm"/>.
        /// </summary>
        public MainForm()
        {
            InitializeComponent();
            _store = ProjectSerializer.Deserialize();
            ItemsTab.Items = _store.Items;
            CustomersTab.Customers = _store.Customers;
            CartsTab.Items = _store.Items;
            CartsTab.Customers = _store.Customers;
            OrdersTab.Customers = _store.Customers;
            ItemsTab.ItemsChanged += ItemsTab_ItemsChanged;
        }

        private void MainForm_FormClosing(object sender, FormClosingEventArgs e)
        {
            _store.Items = ItemsTab.Items;
            _store.Customers = CustomersTab.Customers;
            ProjectSerializer.Serialize(_store);
        }

        private void ItemsTab_ItemsChanged(object sender, System.EventArgs args)
        {
            CartsTab.Items = ItemsTab.Items;
            CartsTab.Customers = CustomersTab.Customers;
            OrdersTab.Customers = CartsTab.Customers;
            OrdersTab.RefreshData();
            CartsTab.RefreshData();
        }

        //private void TabControl_SelectedIndexChanged(object sender, System.EventArgs e)
        //{
        //    if (TabControl.SelectedIndex == 2)
        //    {
        //        CartsTab.Items = ItemsTab.Items;
        //        CartsTab.Customers = CustomersTab.Customers;
        //        CartsTab.RefreshData();
        //    }
        //    else if (TabControl.SelectedIndex == 3)
        //    {
        //        OrdersTab.Customers = CartsTab.Customers;
        //        OrdersTab.RefreshData();
        //    }
        //    //else if (TabControl.SelectedIndex == 5)
        //    //{
        //    //    DiscountsTab.Items = ItemsTab.Items;
        //    //}
        //}
    }
}
