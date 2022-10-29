using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Diagnostics.PerformanceData;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Windows.Forms.VisualStyles;
using ObjectOrientedPractics.Model;

namespace ObjectOrientedPractics.View.Tabs
{
    public partial class OrdersTab : UserControl
    {
        /// <summary>
        /// Коллекция товаров.
        /// </summary>
        private List<Item> _items;

        /// <summary>
        /// Коллекция покупателей.
        /// </summary>
        private List<Customer> _customers;

        private List<Order> _orders;

        private Order _currentOrder;

        public OrdersTab()
        {
            InitializeComponent();

            _orders = new List<Order>();

            AddressControl.ReadOnly = true;

            var orderStatusValues = Enum.GetValues(typeof(OrderStatus));

            foreach (var value in orderStatusValues)
            {
                StatusComboBox.Items.Add(value);
            }

            StatusComboBox.Enabled = false;
        }

        public List<Customer> Customers
        {
            get
            {
                return _customers;
            }
            set
            {
                _customers = value;

                if (_customers != null) UpdateOrders();
            }
        }

        public void RefreshData()
        {
            OrdersDataGridView.Rows.Clear();
            _orders = new List<Order>();
            UpdateOrders();

        }

        private void UpdateOrders()
        {
            foreach (var customer in _customers)
            {
                Address address = customer.Address;
                string fullAddress = $"{address.Index}, {address.Country}, {address.City}," +
                                     $" {address.Street}, {address.Building}, {address.Apartment}";

                foreach (var order in customer.Orders)
                {
                    _orders.Add(order);
                    OrdersDataGridView.Rows.Add(order.Id.ToString(), order.DateOfCreate, 
                        order.Status, customer.Fullname, fullAddress, order.Amount.ToString());
                }
            }
        }

        private void SetValueInTextBoxes()
        {
            StatusComboBox.Enabled = true;
            IDTextBox.Text = _currentOrder.Id.ToString();
            CreatedTextBox.Text = _currentOrder.DateOfCreate;
            StatusComboBox.SelectedIndex = (int) _currentOrder.Status;
            AddressControl.Address = _currentOrder.Address;

            OrderItemsListBox.Items.Clear();
            foreach (var item in _currentOrder.Items)
            {
                OrderItemsListBox.Items.Add(item.Name);
            }

            AmountDigitLabel.Text = _currentOrder.Amount.ToString();
        }

        private void OrdersDataGridView_SelectionChanged(object sender, EventArgs e)
        {
            int index = OrdersDataGridView.CurrentCell.RowIndex;
            if (index == -1) return;

            _currentOrder = _orders[index];
            SetValueInTextBoxes();
        }

        private void StatusComboBox_SelectedIndexChanged(object sender, EventArgs e)
        {
            int index = OrdersDataGridView.CurrentCell.RowIndex;

            _currentOrder.Status = (OrderStatus) StatusComboBox.SelectedIndex;
            OrdersDataGridView.Rows[index].Cells[2].Value = (OrderStatus) StatusComboBox.SelectedIndex;
        }
    }
}
