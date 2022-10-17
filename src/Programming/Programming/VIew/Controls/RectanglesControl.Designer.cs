namespace Programming.View.Controls
{
    partial class RectanglesControl
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
            this.IdRectangleTextBox = new System.Windows.Forms.TextBox();
            this.IdRectangleLabel = new System.Windows.Forms.Label();
            this.YRectangleTextBox = new System.Windows.Forms.TextBox();
            this.YRectangleLabel = new System.Windows.Forms.Label();
            this.XRectangleTextBox = new System.Windows.Forms.TextBox();
            this.XRectangleLabel = new System.Windows.Forms.Label();
            this.FindRectangleButton = new System.Windows.Forms.Button();
            this.ColorRectangleTextBox = new System.Windows.Forms.TextBox();
            this.ColorRectangleLabel = new System.Windows.Forms.Label();
            this.WidthRectangleTextBox = new System.Windows.Forms.TextBox();
            this.WidthRectangleLabel = new System.Windows.Forms.Label();
            this.HeightRectangleTextBox = new System.Windows.Forms.TextBox();
            this.HeightRectangleLabel = new System.Windows.Forms.Label();
            this.RectangleListBox = new System.Windows.Forms.ListBox();
            this.SuspendLayout();
            // 
            // IdRectangleTextBox
            // 
            this.IdRectangleTextBox.Enabled = false;
            this.IdRectangleTextBox.Location = new System.Drawing.Point(139, 212);
            this.IdRectangleTextBox.Name = "IdRectangleTextBox";
            this.IdRectangleTextBox.Size = new System.Drawing.Size(100, 20);
            this.IdRectangleTextBox.TabIndex = 27;
            // 
            // IdRectangleLabel
            // 
            this.IdRectangleLabel.AutoSize = true;
            this.IdRectangleLabel.Location = new System.Drawing.Point(136, 196);
            this.IdRectangleLabel.Name = "IdRectangleLabel";
            this.IdRectangleLabel.Size = new System.Drawing.Size(19, 13);
            this.IdRectangleLabel.TabIndex = 26;
            this.IdRectangleLabel.Text = "Id:";
            // 
            // YRectangleTextBox
            // 
            this.YRectangleTextBox.Enabled = false;
            this.YRectangleTextBox.Location = new System.Drawing.Point(139, 173);
            this.YRectangleTextBox.Name = "YRectangleTextBox";
            this.YRectangleTextBox.Size = new System.Drawing.Size(100, 20);
            this.YRectangleTextBox.TabIndex = 25;
            // 
            // YRectangleLabel
            // 
            this.YRectangleLabel.AutoSize = true;
            this.YRectangleLabel.Location = new System.Drawing.Point(136, 157);
            this.YRectangleLabel.Name = "YRectangleLabel";
            this.YRectangleLabel.Size = new System.Drawing.Size(17, 13);
            this.YRectangleLabel.TabIndex = 24;
            this.YRectangleLabel.Text = "Y:";
            // 
            // XRectangleTextBox
            // 
            this.XRectangleTextBox.Enabled = false;
            this.XRectangleTextBox.Location = new System.Drawing.Point(139, 134);
            this.XRectangleTextBox.Name = "XRectangleTextBox";
            this.XRectangleTextBox.Size = new System.Drawing.Size(100, 20);
            this.XRectangleTextBox.TabIndex = 23;
            // 
            // XRectangleLabel
            // 
            this.XRectangleLabel.AutoSize = true;
            this.XRectangleLabel.Location = new System.Drawing.Point(136, 118);
            this.XRectangleLabel.Name = "XRectangleLabel";
            this.XRectangleLabel.Size = new System.Drawing.Size(17, 13);
            this.XRectangleLabel.TabIndex = 22;
            this.XRectangleLabel.Text = "X:";
            // 
            // FindRectangleButton
            // 
            this.FindRectangleButton.Location = new System.Drawing.Point(139, 267);
            this.FindRectangleButton.Name = "FindRectangleButton";
            this.FindRectangleButton.Size = new System.Drawing.Size(103, 23);
            this.FindRectangleButton.TabIndex = 21;
            this.FindRectangleButton.Text = "Find";
            this.FindRectangleButton.UseVisualStyleBackColor = true;
            this.FindRectangleButton.Click += new System.EventHandler(this.FindRectangleButton_Click);
            // 
            // ColorRectangleTextBox
            // 
            this.ColorRectangleTextBox.Location = new System.Drawing.Point(139, 95);
            this.ColorRectangleTextBox.Name = "ColorRectangleTextBox";
            this.ColorRectangleTextBox.Size = new System.Drawing.Size(100, 20);
            this.ColorRectangleTextBox.TabIndex = 20;
            this.ColorRectangleTextBox.TextChanged += new System.EventHandler(this.ColorRectangleTextBox_TextChanged);
            // 
            // ColorRectangleLabel
            // 
            this.ColorRectangleLabel.AutoSize = true;
            this.ColorRectangleLabel.Location = new System.Drawing.Point(136, 79);
            this.ColorRectangleLabel.Name = "ColorRectangleLabel";
            this.ColorRectangleLabel.Size = new System.Drawing.Size(34, 13);
            this.ColorRectangleLabel.TabIndex = 19;
            this.ColorRectangleLabel.Text = "Color:";
            // 
            // WidthRectangleTextBox
            // 
            this.WidthRectangleTextBox.Location = new System.Drawing.Point(139, 56);
            this.WidthRectangleTextBox.Name = "WidthRectangleTextBox";
            this.WidthRectangleTextBox.Size = new System.Drawing.Size(100, 20);
            this.WidthRectangleTextBox.TabIndex = 18;
            this.WidthRectangleTextBox.TextChanged += new System.EventHandler(this.WidthRectangleTextBox_TextChanged);
            // 
            // WidthRectangleLabel
            // 
            this.WidthRectangleLabel.AutoSize = true;
            this.WidthRectangleLabel.Location = new System.Drawing.Point(136, 40);
            this.WidthRectangleLabel.Name = "WidthRectangleLabel";
            this.WidthRectangleLabel.Size = new System.Drawing.Size(38, 13);
            this.WidthRectangleLabel.TabIndex = 17;
            this.WidthRectangleLabel.Text = "Width:";
            // 
            // HeightRectangleTextBox
            // 
            this.HeightRectangleTextBox.Location = new System.Drawing.Point(139, 17);
            this.HeightRectangleTextBox.Name = "HeightRectangleTextBox";
            this.HeightRectangleTextBox.Size = new System.Drawing.Size(100, 20);
            this.HeightRectangleTextBox.TabIndex = 16;
            this.HeightRectangleTextBox.TextChanged += new System.EventHandler(this.HeightRectangleTextBox_TextChanged);
            // 
            // HeightRectangleLabel
            // 
            this.HeightRectangleLabel.AutoSize = true;
            this.HeightRectangleLabel.Location = new System.Drawing.Point(136, 1);
            this.HeightRectangleLabel.Name = "HeightRectangleLabel";
            this.HeightRectangleLabel.Size = new System.Drawing.Size(41, 13);
            this.HeightRectangleLabel.TabIndex = 15;
            this.HeightRectangleLabel.Text = "Height:";
            // 
            // RectangleListBox
            // 
            this.RectangleListBox.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left)));
            this.RectangleListBox.FormattingEnabled = true;
            this.RectangleListBox.Location = new System.Drawing.Point(0, 0);
            this.RectangleListBox.Name = "RectangleListBox";
            this.RectangleListBox.Size = new System.Drawing.Size(133, 290);
            this.RectangleListBox.TabIndex = 14;
            this.RectangleListBox.SelectedIndexChanged += new System.EventHandler(this.RectangleListBox_SelectedIndexChanged);
            // 
            // RectanglesControl
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.IdRectangleTextBox);
            this.Controls.Add(this.IdRectangleLabel);
            this.Controls.Add(this.YRectangleTextBox);
            this.Controls.Add(this.YRectangleLabel);
            this.Controls.Add(this.XRectangleTextBox);
            this.Controls.Add(this.XRectangleLabel);
            this.Controls.Add(this.FindRectangleButton);
            this.Controls.Add(this.ColorRectangleTextBox);
            this.Controls.Add(this.ColorRectangleLabel);
            this.Controls.Add(this.WidthRectangleTextBox);
            this.Controls.Add(this.WidthRectangleLabel);
            this.Controls.Add(this.HeightRectangleTextBox);
            this.Controls.Add(this.HeightRectangleLabel);
            this.Controls.Add(this.RectangleListBox);
            this.Name = "RectanglesControl";
            this.Size = new System.Drawing.Size(242, 290);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.TextBox IdRectangleTextBox;
        private System.Windows.Forms.Label IdRectangleLabel;
        private System.Windows.Forms.TextBox YRectangleTextBox;
        private System.Windows.Forms.Label YRectangleLabel;
        private System.Windows.Forms.TextBox XRectangleTextBox;
        private System.Windows.Forms.Label XRectangleLabel;
        private System.Windows.Forms.Button FindRectangleButton;
        private System.Windows.Forms.TextBox ColorRectangleTextBox;
        private System.Windows.Forms.Label ColorRectangleLabel;
        private System.Windows.Forms.TextBox WidthRectangleTextBox;
        private System.Windows.Forms.Label WidthRectangleLabel;
        private System.Windows.Forms.TextBox HeightRectangleTextBox;
        private System.Windows.Forms.Label HeightRectangleLabel;
        private System.Windows.Forms.ListBox RectangleListBox;
    }
}
