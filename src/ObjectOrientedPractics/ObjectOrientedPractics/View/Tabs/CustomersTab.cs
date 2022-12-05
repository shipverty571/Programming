using System;
using System.Collections.Generic;
using System.Linq;
using System.Windows.Forms;
using ObjectOrientedPractics.Model;
using ObjectOrientedPractics.Model.Discounts;
using ObjectOrientedPractics.Services;
using ObjectOrientedPractics.View.Forms;

namespace ObjectOrientedPractics.View.Tabs
{
    /// <summary>
    /// Представляет реализацию по представлению покупателей.
    /// </summary>
    public partial class CustomersTab : UserControl
    {
        /// <summary>
        /// Коллекция покупателей.
        /// </summary>
        private List<Customer> _customers;

        /// <summary>
        /// Выбранный покупатель.
        /// </summary>
        private Customer _currentCustomer;

        /// <summary>
        /// Создает экземпляр класса <see cref="CustomersTab"/>
        /// </summary>
        public CustomersTab()
        {
            InitializeComponent();

            IsPriorityCheckBox.Enabled = false;
            
        }

        /// <summary>
        /// Возвращает и задает коллекцию покупателей.
        /// </summary>
        public List<Customer> Customers
        {
            get => _customers;
            set
            {
                _customers = value;

                if (_customers != null)
                {
                    UpdateListBox(-1);
                }
            }
        }

        private void UpdateDiscountsListBox()
        {
            DiscountsListBox.Items.Clear();
            
            foreach (var discount in _currentCustomer.Discounts)
            {
                DiscountsListBox.Items.Add(discount.Info);
            }
        }

        /// <summary>
        /// Обновляет данные в ListBox.
        /// </summary>
        /// <param name="selectedIndex">Выбранный элемент.</param>
        private void UpdateListBox(int selectedIndex)
        {
            CustomersListBox.Items.Clear();
            var orderedListItems = from customer in _customers
                orderby customer.Fullname  
                select customer;

            _customers = orderedListItems.ToList();

            foreach (Customer customer in _customers)
            {
                CustomersListBox.Items.Add(FormattedText(customer));
            }

            if (selectedIndex == -1) AddressControl.Enabled = false;

            CustomersListBox.SelectedIndex = selectedIndex;
        }

        /// <summary>
        /// Ищет индекс элемента по уникальному идентификатору.
        /// </summary>
        /// <returns>Возвращает индекс найденного элемента.</returns>
        private int FindIndexItemById()
        {
            var orderedListItems = from customer in _customers
                orderby customer.Fullname
                select customer;

            _customers = orderedListItems.ToList();
            int currentCustomerId = _currentCustomer.Id;
            int index = -1;

            for (int i = 0; i < _customers.Count; i++)
            {
                if (_customers[i].Id != currentCustomerId) continue;

                index = i;
                break;
            }

            return index;
        }

        /// <summary>
        /// Очищает поля вывода информации.
        /// </summary>
        private void ClearCustomersInfo()
        {
            IDTextBox.Clear();
            FullNameTextBox.Clear();
            AddressControl.Clear();
            IsPriorityCheckBox.Checked = false;
        }

        /// <summary>
        /// Генерирует форматированный текст для отображения.
        /// </summary>
        /// <param name="customer">Покупатель.</param>
        /// <returns>Возвращает форматированный текст.</returns>
        private string FormattedText(Customer customer)
        {
            return $"{customer.Fullname}";
        }

        private void AddButton_Click(object sender, System.EventArgs e)
        {
            Customer customer = CustomerFactory.Randomize();
            _currentCustomer = customer;
            _customers.Add(customer);
            UpdateListBox(0);
        }

        private void RemoveButton_Click(object sender, System.EventArgs e)
        {
            int index = CustomersListBox.SelectedIndex;

            if (index == -1) return;

            _customers.RemoveAt(index);
            UpdateListBox(-1);
            ClearCustomersInfo();
        }

        private void CustomersListBox_SelectedIndexChanged(object sender, System.EventArgs e)
        {
            int index = CustomersListBox.SelectedIndex;

            if (index == -1)
            {
                AddressControl.Enabled = false;
                IsPriorityCheckBox.Enabled = false;
                return;
            }

            AddressControl.Enabled = true;
            IsPriorityCheckBox.Enabled = true;
            
            _currentCustomer = _customers[index];
            IsPriorityCheckBox.Checked = _currentCustomer.IsPriority;

            IDTextBox.Text = _currentCustomer.Id.ToString();
            FullNameTextBox.Text = _currentCustomer.Fullname;
            AddressControl.Address = _currentCustomer.Address;
            UpdateDiscountsListBox();
        }

        private void FullNameTextBox_TextChanged(object sender, EventArgs e)
        {
            int index = CustomersListBox.SelectedIndex;

            if (index == -1) return;

            try
            {
                string name = FullNameTextBox.Text;
                _currentCustomer.Fullname = name;
                int indexCustomer = FindIndexItemById();
                UpdateListBox(indexCustomer);
            }
            catch
            {
                FullNameTextBox.BackColor = AppColor.ErrorColor;
                return;
            }

            FullNameTextBox.BackColor = AppColor.CorrectColor;
        }

        private void IsPriorityCheckBox_CheckedChanged(object sender, EventArgs e)
        {
            _currentCustomer.IsPriority = IsPriorityCheckBox.Checked;
        }

        private void AddDiscountButton_Click(object sender, EventArgs e)
        {
            AddDiscountForm addDiscountForm = new AddDiscountForm();
            if (addDiscountForm.ShowDialog() == DialogResult.OK)
            {
                _currentCustomer.Discounts.Add(addDiscountForm.PercentDiscount);
                UpdateDiscountsListBox();
            }
        }

        private void RemoveDiscountButton_Click(object sender, EventArgs e)
        {
            int index = DiscountsListBox.SelectedIndex;
            if (index == -1) return;
            if (index == 0) return;
            _currentCustomer.Discounts.RemoveAt(index);
            UpdateDiscountsListBox();
        }
    }
}
