namespace ObjectOrientedPractics.View.Tabs
{
    partial class CartsTab
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

        #region Код, автоматически созданный конструктором компонентов

        /// <summary> 
        /// Требуемый метод для поддержки конструктора — не изменяйте 
        /// содержимое этого метода с помощью редактора кода.
        /// </summary>
        private void InitializeComponent()
        {
            this.ItemsListBox = new System.Windows.Forms.ListBox();
            this.ItemsLabel = new System.Windows.Forms.Label();
            this.ItemsPanel = new System.Windows.Forms.Panel();
            this.AddToCartButton = new System.Windows.Forms.Button();
            this.CustomerPanel = new System.Windows.Forms.Panel();
            this.TotalDigitLabel = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.DiscountAmountDigitLabel = new System.Windows.Forms.Label();
            this.DiscountAmountLabel = new System.Windows.Forms.Label();
            this.DiscountCheckedListBox = new System.Windows.Forms.CheckedListBox();
            this.AmountDigitLabel = new System.Windows.Forms.Label();
            this.RemoveItemButton = new System.Windows.Forms.Button();
            this.ClearCartButton = new System.Windows.Forms.Button();
            this.AmountLabel = new System.Windows.Forms.Label();
            this.CreateOrderButton = new System.Windows.Forms.Button();
            this.CartListBox = new System.Windows.Forms.ListBox();
            this.CartLabel = new System.Windows.Forms.Label();
            this.CustomerComboBox = new System.Windows.Forms.ComboBox();
            this.CustomerLabel = new System.Windows.Forms.Label();
            this.ItemsPanel.SuspendLayout();
            this.CustomerPanel.SuspendLayout();
            this.SuspendLayout();
            // 
            // ItemsListBox
            // 
            this.ItemsListBox.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left)));
            this.ItemsListBox.FormattingEnabled = true;
            this.ItemsListBox.Location = new System.Drawing.Point(3, 22);
            this.ItemsListBox.Name = "ItemsListBox";
            this.ItemsListBox.Size = new System.Drawing.Size(291, 459);
            this.ItemsListBox.TabIndex = 0;
            // 
            // ItemsLabel
            // 
            this.ItemsLabel.AutoSize = true;
            this.ItemsLabel.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.ItemsLabel.Location = new System.Drawing.Point(3, 3);
            this.ItemsLabel.Name = "ItemsLabel";
            this.ItemsLabel.Size = new System.Drawing.Size(37, 13);
            this.ItemsLabel.TabIndex = 1;
            this.ItemsLabel.Text = "Items";
            // 
            // ItemsPanel
            // 
            this.ItemsPanel.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.ItemsPanel.Controls.Add(this.AddToCartButton);
            this.ItemsPanel.Controls.Add(this.ItemsLabel);
            this.ItemsPanel.Controls.Add(this.ItemsListBox);
            this.ItemsPanel.Location = new System.Drawing.Point(3, 3);
            this.ItemsPanel.Name = "ItemsPanel";
            this.ItemsPanel.Size = new System.Drawing.Size(300, 550);
            this.ItemsPanel.TabIndex = 3;
            // 
            // AddToCartButton
            // 
            this.AddToCartButton.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.AddToCartButton.Location = new System.Drawing.Point(6, 502);
            this.AddToCartButton.Name = "AddToCartButton";
            this.AddToCartButton.Size = new System.Drawing.Size(93, 45);
            this.AddToCartButton.TabIndex = 4;
            this.AddToCartButton.Text = "Add To Cart";
            this.AddToCartButton.UseVisualStyleBackColor = true;
            this.AddToCartButton.Click += new System.EventHandler(this.AddToCartButton_Click);
            // 
            // CustomerPanel
            // 
            this.CustomerPanel.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.CustomerPanel.Controls.Add(this.TotalDigitLabel);
            this.CustomerPanel.Controls.Add(this.label4);
            this.CustomerPanel.Controls.Add(this.DiscountAmountDigitLabel);
            this.CustomerPanel.Controls.Add(this.DiscountAmountLabel);
            this.CustomerPanel.Controls.Add(this.DiscountCheckedListBox);
            this.CustomerPanel.Controls.Add(this.AmountDigitLabel);
            this.CustomerPanel.Controls.Add(this.RemoveItemButton);
            this.CustomerPanel.Controls.Add(this.ClearCartButton);
            this.CustomerPanel.Controls.Add(this.AmountLabel);
            this.CustomerPanel.Controls.Add(this.CreateOrderButton);
            this.CustomerPanel.Controls.Add(this.CartListBox);
            this.CustomerPanel.Controls.Add(this.CartLabel);
            this.CustomerPanel.Controls.Add(this.CustomerComboBox);
            this.CustomerPanel.Controls.Add(this.CustomerLabel);
            this.CustomerPanel.Location = new System.Drawing.Point(306, 3);
            this.CustomerPanel.Name = "CustomerPanel";
            this.CustomerPanel.Size = new System.Drawing.Size(452, 550);
            this.CustomerPanel.TabIndex = 4;
            // 
            // TotalDigitLabel
            // 
            this.TotalDigitLabel.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.TotalDigitLabel.Font = new System.Drawing.Font("Roboto Medium", 14.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.TotalDigitLabel.Location = new System.Drawing.Point(12, 502);
            this.TotalDigitLabel.Name = "TotalDigitLabel";
            this.TotalDigitLabel.Size = new System.Drawing.Size(435, 24);
            this.TotalDigitLabel.TabIndex = 20;
            this.TotalDigitLabel.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // label4
            // 
            this.label4.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.label4.AutoSize = true;
            this.label4.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.label4.Location = new System.Drawing.Point(396, 486);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(51, 13);
            this.label4.TabIndex = 19;
            this.label4.Text = "TOTAL:";
            // 
            // DiscountAmountDigitLabel
            // 
            this.DiscountAmountDigitLabel.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.DiscountAmountDigitLabel.Font = new System.Drawing.Font("Roboto Medium", 14.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.DiscountAmountDigitLabel.Location = new System.Drawing.Point(209, 336);
            this.DiscountAmountDigitLabel.Name = "DiscountAmountDigitLabel";
            this.DiscountAmountDigitLabel.Size = new System.Drawing.Size(232, 24);
            this.DiscountAmountDigitLabel.TabIndex = 18;
            this.DiscountAmountDigitLabel.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // DiscountAmountLabel
            // 
            this.DiscountAmountLabel.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.DiscountAmountLabel.AutoSize = true;
            this.DiscountAmountLabel.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.DiscountAmountLabel.Location = new System.Drawing.Point(342, 316);
            this.DiscountAmountLabel.Name = "DiscountAmountLabel";
            this.DiscountAmountLabel.Size = new System.Drawing.Size(107, 13);
            this.DiscountAmountLabel.TabIndex = 17;
            this.DiscountAmountLabel.Text = "Discount Amount:";
            // 
            // DiscountCheckedListBox
            // 
            this.DiscountCheckedListBox.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left)));
            this.DiscountCheckedListBox.BackColor = System.Drawing.SystemColors.Window;
            this.DiscountCheckedListBox.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.DiscountCheckedListBox.CheckOnClick = true;
            this.DiscountCheckedListBox.FormattingEnabled = true;
            this.DiscountCheckedListBox.Location = new System.Drawing.Point(10, 319);
            this.DiscountCheckedListBox.Name = "DiscountCheckedListBox";
            this.DiscountCheckedListBox.Size = new System.Drawing.Size(193, 180);
            this.DiscountCheckedListBox.TabIndex = 16;
            this.DiscountCheckedListBox.SelectedIndexChanged += new System.EventHandler(this.DiscountCheckedListBox_SelectedIndexChanged);
            // 
            // AmountDigitLabel
            // 
            this.AmountDigitLabel.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.AmountDigitLabel.Font = new System.Drawing.Font("Roboto Medium", 14.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.AmountDigitLabel.Location = new System.Drawing.Point(6, 241);
            this.AmountDigitLabel.Name = "AmountDigitLabel";
            this.AmountDigitLabel.Size = new System.Drawing.Size(435, 24);
            this.AmountDigitLabel.TabIndex = 14;
            this.AmountDigitLabel.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // RemoveItemButton
            // 
            this.RemoveItemButton.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.RemoveItemButton.Location = new System.Drawing.Point(249, 268);
            this.RemoveItemButton.Name = "RemoveItemButton";
            this.RemoveItemButton.Size = new System.Drawing.Size(93, 45);
            this.RemoveItemButton.TabIndex = 9;
            this.RemoveItemButton.Text = "Remove Item";
            this.RemoveItemButton.UseVisualStyleBackColor = true;
            this.RemoveItemButton.Click += new System.EventHandler(this.RemoveItemButton_Click);
            // 
            // ClearCartButton
            // 
            this.ClearCartButton.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.ClearCartButton.Location = new System.Drawing.Point(348, 268);
            this.ClearCartButton.Name = "ClearCartButton";
            this.ClearCartButton.Size = new System.Drawing.Size(93, 45);
            this.ClearCartButton.TabIndex = 8;
            this.ClearCartButton.Text = "Clear Cart";
            this.ClearCartButton.UseVisualStyleBackColor = true;
            this.ClearCartButton.Click += new System.EventHandler(this.ClearCartButton_Click);
            // 
            // AmountLabel
            // 
            this.AmountLabel.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.AmountLabel.AutoSize = true;
            this.AmountLabel.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.AmountLabel.Location = new System.Drawing.Point(396, 224);
            this.AmountLabel.Name = "AmountLabel";
            this.AmountLabel.Size = new System.Drawing.Size(53, 13);
            this.AmountLabel.TabIndex = 6;
            this.AmountLabel.Text = "Amount:";
            // 
            // CreateOrderButton
            // 
            this.CreateOrderButton.Location = new System.Drawing.Point(6, 268);
            this.CreateOrderButton.Name = "CreateOrderButton";
            this.CreateOrderButton.Size = new System.Drawing.Size(93, 45);
            this.CreateOrderButton.TabIndex = 5;
            this.CreateOrderButton.Text = "Create Order";
            this.CreateOrderButton.UseVisualStyleBackColor = true;
            this.CreateOrderButton.Click += new System.EventHandler(this.CreateOrderButton_Click);
            // 
            // CartListBox
            // 
            this.CartListBox.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.CartListBox.FormattingEnabled = true;
            this.CartListBox.Location = new System.Drawing.Point(6, 71);
            this.CartListBox.Name = "CartListBox";
            this.CartListBox.Size = new System.Drawing.Size(443, 147);
            this.CartListBox.TabIndex = 3;
            // 
            // CartLabel
            // 
            this.CartLabel.AutoSize = true;
            this.CartLabel.Location = new System.Drawing.Point(3, 52);
            this.CartLabel.Name = "CartLabel";
            this.CartLabel.Size = new System.Drawing.Size(29, 13);
            this.CartLabel.TabIndex = 2;
            this.CartLabel.Text = "Cart:";
            // 
            // CustomerComboBox
            // 
            this.CustomerComboBox.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.CustomerComboBox.FormattingEnabled = true;
            this.CustomerComboBox.Location = new System.Drawing.Point(72, 16);
            this.CustomerComboBox.Name = "CustomerComboBox";
            this.CustomerComboBox.Size = new System.Drawing.Size(377, 21);
            this.CustomerComboBox.TabIndex = 1;
            this.CustomerComboBox.SelectedIndexChanged += new System.EventHandler(this.CustomerComboBox_SelectedIndexChanged);
            // 
            // CustomerLabel
            // 
            this.CustomerLabel.AutoSize = true;
            this.CustomerLabel.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.CustomerLabel.Location = new System.Drawing.Point(3, 19);
            this.CustomerLabel.Name = "CustomerLabel";
            this.CustomerLabel.Size = new System.Drawing.Size(63, 13);
            this.CustomerLabel.TabIndex = 0;
            this.CustomerLabel.Text = "Customer:";
            // 
            // CartsTab
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.CustomerPanel);
            this.Controls.Add(this.ItemsPanel);
            this.Name = "CartsTab";
            this.Size = new System.Drawing.Size(764, 556);
            this.ItemsPanel.ResumeLayout(false);
            this.ItemsPanel.PerformLayout();
            this.CustomerPanel.ResumeLayout(false);
            this.CustomerPanel.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.ListBox ItemsListBox;
        private System.Windows.Forms.Label ItemsLabel;
        private System.Windows.Forms.Panel ItemsPanel;
        private System.Windows.Forms.Button AddToCartButton;
        private System.Windows.Forms.Panel CustomerPanel;
        private System.Windows.Forms.Button RemoveItemButton;
        private System.Windows.Forms.Button ClearCartButton;
        private System.Windows.Forms.Label AmountLabel;
        private System.Windows.Forms.Button CreateOrderButton;
        private System.Windows.Forms.ListBox CartListBox;
        private System.Windows.Forms.Label CartLabel;
        private System.Windows.Forms.ComboBox CustomerComboBox;
        private System.Windows.Forms.Label CustomerLabel;
        private System.Windows.Forms.Label AmountDigitLabel;
        private System.Windows.Forms.Label TotalDigitLabel;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label DiscountAmountDigitLabel;
        private System.Windows.Forms.Label DiscountAmountLabel;
        private System.Windows.Forms.CheckedListBox DiscountCheckedListBox;
    }
}
