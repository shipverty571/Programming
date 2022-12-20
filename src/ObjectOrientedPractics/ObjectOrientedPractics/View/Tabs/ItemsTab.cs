using System;
using static System.String;
using System.Collections.Generic;
using System.Windows.Forms;
using ObjectOrientedPractics.Model;
using ObjectOrientedPractics.Services;
using ObjectOrientedPractics.Model.Enums;

namespace ObjectOrientedPractics.View.Tabs
{
    /// <summary>
    /// Представляет реализацию по представлению товаров.
    /// </summary>
    public partial class ItemsTab : UserControl
    {
        public event EventHandler<EventArgs> ItemsChanged; 

        /// <summary>
        /// Коллекция товаров.
        /// </summary>
        private List<Item> _items;

        /// <summary>
        /// Выбранный товар.
        /// </summary>
        private Item _currentItem;

        /// <summary>
        /// Коллекция товаров по введенной подстроке.
        /// </summary>
        private List<Item> _displayItems;

        /// <summary>
        /// Создает экземпляр класса <see cref="ItemsTab"/>
        /// </summary>
        public ItemsTab()
        {
            InitializeComponent();

            var category = Enum.GetValues(typeof(Category));

            foreach (var value in category)
                CategoryComboBox.Items.Add(value);

            OrderByComboBox.Items.AddRange(new string[]
            {
                "Name (Ascending)",
                "Cost (Ascending)",
                "Cost (Descending)"
            });
        }

        /// <summary>
        /// Возвращает и задает коллекцию товаров.
        /// </summary>
        public List<Item> Items
        {
            get => _items;
            set
            {
                _items = value;
                _displayItems = value;
                if (_items != null)
                {
                    UpdateListBox(_displayItems, -1);
                    OrderByComboBox.SelectedIndex = 0;
                }
            }
        }

        /// <summary>
        /// Очищает поля вывода информации.
        /// </summary>
        private void ClearItemsInfo()
        {
            IDTextBox.Clear();
            CostTextBox.Clear();
            NameTextBox.Clear();
            DescriptionTextBox.Clear();
        }

        /// <summary>
        /// Обновляет данные в ListBox.
        /// </summary>
        /// <param name="selectedIndex">Выбранный элемент.</param>
        private void UpdateListBox(List<Item> currentListItems, int selectedIndex)
        {
            ItemsListBox.Items.Clear();

            foreach (Item item in currentListItems)
            {
                ItemsListBox.Items.Add(FormattedText(item));
            }

            ItemsListBox.SelectedIndex = selectedIndex;
        }

        /// <summary>
        /// Ищет индекс элемента по уникальному идентификатору.
        /// </summary>
        /// <returns>Возвращает индекс найденного элемента.</returns>
        private int FindIndexItemById()
        {
            //var orderedListItems = from item in _items
            //    orderby item.Name
            //    select item;

            //_items = orderedListItems.ToList();
            int currentItemId = _currentItem.Id;
            int index = -1;

            for (int i = 0; i < _displayItems.Count; i++)
            {
                if (_displayItems[i].Id != currentItemId) continue;

                index = i;
                break;
            }

            return index;
        }

        /// <summary>
        /// Генерирует форматированный текст для отображения.
        /// </summary>
        /// <param name="item">Товар.</param>
        /// <returns>Возвращает форматированный текст.</returns>
        private string FormattedText(Item item)
        {
            return $"{item.Name}";
        }

        private void AddButton_Click(object sender, System.EventArgs e)
        {
            Item item = ItemFactory.Randomize();
            _currentItem = item;
            _items.Add(item);
            _displayItems = _items;
            UpdateListBox(_displayItems, 0);
            ItemsChanged?.Invoke(this, EventArgs.Empty);
        }

        private void RemoveButton_Click(object sender, System.EventArgs e)
        {
            int index = ItemsListBox.SelectedIndex;
            if (index == -1) return;

            _items.RemoveAt(index);
            _displayItems = _items;
            UpdateListBox(_displayItems, -1);
            ClearItemsInfo();
            ItemsChanged?.Invoke(this, EventArgs.Empty);
        }

        private void ItemsListBox_SelectedIndexChanged(object sender, System.EventArgs e)
        {
            int index = ItemsListBox.SelectedIndex;
            if (index == -1) return;

            _currentItem = _displayItems[index];
            IDTextBox.Text = _currentItem.Id.ToString();
            CostTextBox.Text = _currentItem.Cost.ToString();
            NameTextBox.Text = _currentItem.Name;
            DescriptionTextBox.Text = _currentItem.Info;
            CategoryComboBox.SelectedIndex = (int) _currentItem.Category;
        }

        private void CostTextBox_TextChanged(object sender, EventArgs e)
        {
            int index = ItemsListBox.SelectedIndex;

            if (index == -1) return;

            try
            {
                int cost = Convert.ToInt32(CostTextBox.Text);
                _currentItem.Cost = cost;
                ItemsChanged?.Invoke(this, EventArgs.Empty);
            }
            catch
            {
                CostTextBox.BackColor = AppColor.ErrorColor;
                return;
            }

            CostTextBox.BackColor = AppColor.CorrectColor;
        }

        private void NameTextBox_TextChanged(object sender, EventArgs e)
        {
            int index = ItemsListBox.SelectedIndex;

            if (index == -1) return;

            try
            {
                string name = NameTextBox.Text;
                _currentItem.Name = name;

                int indexItem = FindIndexItemById();
                UpdateListBox(_displayItems, indexItem);
                ItemsChanged?.Invoke(this, EventArgs.Empty);
            }
            catch
            {
                NameTextBox.BackColor = AppColor.ErrorColor;
                return;
            }

            NameTextBox.BackColor = AppColor.CorrectColor;
        }

        private void DescriptionTextBox_TextChanged(object sender, EventArgs e)
        {
            int index = ItemsListBox.SelectedIndex;

            if (index == -1) return;

            try
            {
                string info = DescriptionTextBox.Text;
                _currentItem.Info = info;
                ItemsChanged?.Invoke(this, EventArgs.Empty);
            }
            catch
            {
                DescriptionTextBox.BackColor = AppColor.ErrorColor;
                return;
            }

            DescriptionTextBox.BackColor = AppColor.CorrectColor;
        }

        private void CategoryComboBox_SelectedIndexChanged(object sender, EventArgs e)
        {
            int indexCategory = CategoryComboBox.SelectedIndex;
            int indexListBox = ItemsListBox.SelectedIndex;

            if ((indexCategory == -1) || (indexListBox == -1)) return;

            _currentItem.Category = (Category) CategoryComboBox.SelectedItem;
            ItemsChanged?.Invoke(this, EventArgs.Empty);
        }

        private void ItemsFindTextBox_TextChanged(object sender, EventArgs e)
        {
            string findText = ItemsFindTextBox.Text;
            if (findText != "")
            {
                SelectedItemPanel.Enabled = false;
                ButtonsPanel.Enabled = false;
                _displayItems = DataTools.FindByPredicate(
                    _items, item => item.Name.ToLower().Contains(findText.ToLower()));
                UpdateListBox(_displayItems, -1);
            }
            else
            {
                SelectedItemPanel.Enabled = true;
                ButtonsPanel.Enabled = true;
                _displayItems = _items;
                UpdateListBox(_displayItems, -1);
            }
            
        }

        private void OrderByComboBox_SelectedIndexChanged(object sender, EventArgs e)
        {
            int index = OrderByComboBox.SelectedIndex;

            switch (index)
            {
                case 0:
                    DataTools.Sort(_items, (item, item1) =>
                        Compare(item.Name, item1.Name, StringComparison.Ordinal) <= 0);
                    break;
                case 1:
                    DataTools.Sort(_items, (item, item1) =>
                        item.CompareTo(item1) <= 0);
                    break;
                case 2:
                    DataTools.Sort(_items, (item, item1) =>
                        item.CompareTo(item1) >= 0);
                    break;
            }

            _displayItems = _items;
            UpdateListBox(_displayItems, -1);
        }
    }
}
