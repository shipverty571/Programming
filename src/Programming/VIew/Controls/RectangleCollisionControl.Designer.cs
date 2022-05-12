namespace Programming.View.Controls
{
    partial class RectangleCollisionControl
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(RectangleCollisionControl));
            this.CanvasPanel = new System.Windows.Forms.Panel();
            this.HeightSelectedRectangleTextBox = new System.Windows.Forms.TextBox();
            this.HeightSelectedRectangleLabel = new System.Windows.Forms.Label();
            this.WidthSelectedRectangleTextBox = new System.Windows.Forms.TextBox();
            this.WidthSelectedRectangleLabel = new System.Windows.Forms.Label();
            this.YSelectedRectangleTextBox = new System.Windows.Forms.TextBox();
            this.YSelectedRectangleLabel = new System.Windows.Forms.Label();
            this.XSelectedRectangleTextBox = new System.Windows.Forms.TextBox();
            this.XSelectedRectangleLabel = new System.Windows.Forms.Label();
            this.IdSelectedRectangleTextBox = new System.Windows.Forms.TextBox();
            this.IdSelectedRectangleLabel = new System.Windows.Forms.Label();
            this.SelectedRectangleLabel = new System.Windows.Forms.Label();
            this.RectanglesLabel = new System.Windows.Forms.Label();
            this.RectanglesListBox = new System.Windows.Forms.ListBox();
            this.RemoveRectangleButton = new System.Windows.Forms.Button();
            this.AddRectangleButton = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // CanvasPanel
            // 
            this.CanvasPanel.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.CanvasPanel.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.CanvasPanel.Location = new System.Drawing.Point(224, 0);
            this.CanvasPanel.Name = "CanvasPanel";
            this.CanvasPanel.Size = new System.Drawing.Size(470, 345);
            this.CanvasPanel.TabIndex = 47;
            // 
            // HeightSelectedRectangleTextBox
            // 
            this.HeightSelectedRectangleTextBox.Location = new System.Drawing.Point(50, 325);
            this.HeightSelectedRectangleTextBox.Name = "HeightSelectedRectangleTextBox";
            this.HeightSelectedRectangleTextBox.Size = new System.Drawing.Size(100, 20);
            this.HeightSelectedRectangleTextBox.TabIndex = 46;
            this.HeightSelectedRectangleTextBox.TextChanged += new System.EventHandler(this.HeightSelectedRectangleTextBox_TextChanged);
            // 
            // HeightSelectedRectangleLabel
            // 
            this.HeightSelectedRectangleLabel.AutoSize = true;
            this.HeightSelectedRectangleLabel.Location = new System.Drawing.Point(5, 328);
            this.HeightSelectedRectangleLabel.Name = "HeightSelectedRectangleLabel";
            this.HeightSelectedRectangleLabel.Size = new System.Drawing.Size(41, 13);
            this.HeightSelectedRectangleLabel.TabIndex = 45;
            this.HeightSelectedRectangleLabel.Text = "Height:";
            // 
            // WidthSelectedRectangleTextBox
            // 
            this.WidthSelectedRectangleTextBox.Location = new System.Drawing.Point(50, 299);
            this.WidthSelectedRectangleTextBox.Name = "WidthSelectedRectangleTextBox";
            this.WidthSelectedRectangleTextBox.Size = new System.Drawing.Size(100, 20);
            this.WidthSelectedRectangleTextBox.TabIndex = 44;
            this.WidthSelectedRectangleTextBox.TextChanged += new System.EventHandler(this.WidthSelectedRectangleTextBox_TextChanged);
            // 
            // WidthSelectedRectangleLabel
            // 
            this.WidthSelectedRectangleLabel.AutoSize = true;
            this.WidthSelectedRectangleLabel.Location = new System.Drawing.Point(8, 302);
            this.WidthSelectedRectangleLabel.Name = "WidthSelectedRectangleLabel";
            this.WidthSelectedRectangleLabel.Size = new System.Drawing.Size(38, 13);
            this.WidthSelectedRectangleLabel.TabIndex = 43;
            this.WidthSelectedRectangleLabel.Text = "Width:";
            // 
            // YSelectedRectangleTextBox
            // 
            this.YSelectedRectangleTextBox.Location = new System.Drawing.Point(50, 273);
            this.YSelectedRectangleTextBox.Name = "YSelectedRectangleTextBox";
            this.YSelectedRectangleTextBox.Size = new System.Drawing.Size(100, 20);
            this.YSelectedRectangleTextBox.TabIndex = 42;
            this.YSelectedRectangleTextBox.TextChanged += new System.EventHandler(this.YSelectedRectangleTextBox_TextChanged);
            // 
            // YSelectedRectangleLabel
            // 
            this.YSelectedRectangleLabel.AutoSize = true;
            this.YSelectedRectangleLabel.Location = new System.Drawing.Point(29, 276);
            this.YSelectedRectangleLabel.Name = "YSelectedRectangleLabel";
            this.YSelectedRectangleLabel.Size = new System.Drawing.Size(17, 13);
            this.YSelectedRectangleLabel.TabIndex = 41;
            this.YSelectedRectangleLabel.Text = "Y:";
            // 
            // XSelectedRectangleTextBox
            // 
            this.XSelectedRectangleTextBox.Location = new System.Drawing.Point(50, 247);
            this.XSelectedRectangleTextBox.Name = "XSelectedRectangleTextBox";
            this.XSelectedRectangleTextBox.Size = new System.Drawing.Size(100, 20);
            this.XSelectedRectangleTextBox.TabIndex = 40;
            this.XSelectedRectangleTextBox.TextChanged += new System.EventHandler(this.XSelectedRectangleTextBox_TextChanged);
            // 
            // XSelectedRectangleLabel
            // 
            this.XSelectedRectangleLabel.AutoSize = true;
            this.XSelectedRectangleLabel.Location = new System.Drawing.Point(29, 250);
            this.XSelectedRectangleLabel.Name = "XSelectedRectangleLabel";
            this.XSelectedRectangleLabel.Size = new System.Drawing.Size(17, 13);
            this.XSelectedRectangleLabel.TabIndex = 39;
            this.XSelectedRectangleLabel.Text = "X:";
            // 
            // IdSelectedRectangleTextBox
            // 
            this.IdSelectedRectangleTextBox.Enabled = false;
            this.IdSelectedRectangleTextBox.Location = new System.Drawing.Point(50, 221);
            this.IdSelectedRectangleTextBox.Name = "IdSelectedRectangleTextBox";
            this.IdSelectedRectangleTextBox.Size = new System.Drawing.Size(100, 20);
            this.IdSelectedRectangleTextBox.TabIndex = 38;
            // 
            // IdSelectedRectangleLabel
            // 
            this.IdSelectedRectangleLabel.AutoSize = true;
            this.IdSelectedRectangleLabel.Location = new System.Drawing.Point(27, 224);
            this.IdSelectedRectangleLabel.Name = "IdSelectedRectangleLabel";
            this.IdSelectedRectangleLabel.Size = new System.Drawing.Size(19, 13);
            this.IdSelectedRectangleLabel.TabIndex = 37;
            this.IdSelectedRectangleLabel.Text = "Id:";
            // 
            // SelectedRectangleLabel
            // 
            this.SelectedRectangleLabel.AutoSize = true;
            this.SelectedRectangleLabel.Location = new System.Drawing.Point(0, 204);
            this.SelectedRectangleLabel.Name = "SelectedRectangleLabel";
            this.SelectedRectangleLabel.Size = new System.Drawing.Size(99, 13);
            this.SelectedRectangleLabel.TabIndex = 36;
            this.SelectedRectangleLabel.Text = "Selected rectangle:";
            // 
            // RectanglesLabel
            // 
            this.RectanglesLabel.AutoSize = true;
            this.RectanglesLabel.Location = new System.Drawing.Point(0, 0);
            this.RectanglesLabel.Name = "RectanglesLabel";
            this.RectanglesLabel.Size = new System.Drawing.Size(64, 13);
            this.RectanglesLabel.TabIndex = 33;
            this.RectanglesLabel.Text = "Rectangles:";
            // 
            // RectanglesListBox
            // 
            this.RectanglesListBox.FormattingEnabled = true;
            this.RectanglesListBox.Location = new System.Drawing.Point(3, 16);
            this.RectanglesListBox.Name = "RectanglesListBox";
            this.RectanglesListBox.Size = new System.Drawing.Size(212, 147);
            this.RectanglesListBox.TabIndex = 32;
            this.RectanglesListBox.SelectedIndexChanged += new System.EventHandler(this.RectanglesListBox_SelectedIndexChanged);
            // 
            // RemoveRectangleButton
            // 
            this.RemoveRectangleButton.FlatAppearance.BorderSize = 0;
            this.RemoveRectangleButton.FlatAppearance.MouseDownBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(250)))), ((int)(((byte)(250)))), ((int)(((byte)(250)))));
            this.RemoveRectangleButton.FlatAppearance.MouseOverBackColor = System.Drawing.Color.White;
            this.RemoveRectangleButton.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.RemoveRectangleButton.Image = ((System.Drawing.Image)(resources.GetObject("RemoveRectangleButton.Image")));
            this.RemoveRectangleButton.Location = new System.Drawing.Point(140, 169);
            this.RemoveRectangleButton.Name = "RemoveRectangleButton";
            this.RemoveRectangleButton.Size = new System.Drawing.Size(75, 26);
            this.RemoveRectangleButton.TabIndex = 35;
            this.RemoveRectangleButton.UseVisualStyleBackColor = true;
            this.RemoveRectangleButton.Click += new System.EventHandler(this.RemoveRectangleButton_Click);
            this.RemoveRectangleButton.MouseEnter += new System.EventHandler(this.RemoveRectangleButton_MouseEnter);
            this.RemoveRectangleButton.MouseLeave += new System.EventHandler(this.RemoveRectangleButton_MouseLeave);
            // 
            // AddRectangleButton
            // 
            this.AddRectangleButton.FlatAppearance.BorderSize = 0;
            this.AddRectangleButton.FlatAppearance.MouseDownBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(250)))), ((int)(((byte)(250)))), ((int)(((byte)(250)))));
            this.AddRectangleButton.FlatAppearance.MouseOverBackColor = System.Drawing.Color.White;
            this.AddRectangleButton.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.AddRectangleButton.Image = ((System.Drawing.Image)(resources.GetObject("AddRectangleButton.Image")));
            this.AddRectangleButton.Location = new System.Drawing.Point(3, 169);
            this.AddRectangleButton.Name = "AddRectangleButton";
            this.AddRectangleButton.Size = new System.Drawing.Size(75, 26);
            this.AddRectangleButton.TabIndex = 34;
            this.AddRectangleButton.UseVisualStyleBackColor = true;
            this.AddRectangleButton.Click += new System.EventHandler(this.AddRectangleButton_Click);
            this.AddRectangleButton.MouseEnter += new System.EventHandler(this.AddRectangleButton_MouseEnter);
            this.AddRectangleButton.MouseLeave += new System.EventHandler(this.AddRectangleButton_MouseLeave);
            // 
            // RectangleCollisionControl
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.CanvasPanel);
            this.Controls.Add(this.HeightSelectedRectangleTextBox);
            this.Controls.Add(this.HeightSelectedRectangleLabel);
            this.Controls.Add(this.WidthSelectedRectangleTextBox);
            this.Controls.Add(this.WidthSelectedRectangleLabel);
            this.Controls.Add(this.YSelectedRectangleTextBox);
            this.Controls.Add(this.YSelectedRectangleLabel);
            this.Controls.Add(this.XSelectedRectangleTextBox);
            this.Controls.Add(this.XSelectedRectangleLabel);
            this.Controls.Add(this.IdSelectedRectangleTextBox);
            this.Controls.Add(this.IdSelectedRectangleLabel);
            this.Controls.Add(this.SelectedRectangleLabel);
            this.Controls.Add(this.RemoveRectangleButton);
            this.Controls.Add(this.AddRectangleButton);
            this.Controls.Add(this.RectanglesLabel);
            this.Controls.Add(this.RectanglesListBox);
            this.Name = "RectangleCollisionControl";
            this.Size = new System.Drawing.Size(694, 345);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Panel CanvasPanel;
        private System.Windows.Forms.TextBox HeightSelectedRectangleTextBox;
        private System.Windows.Forms.Label HeightSelectedRectangleLabel;
        private System.Windows.Forms.TextBox WidthSelectedRectangleTextBox;
        private System.Windows.Forms.Label WidthSelectedRectangleLabel;
        private System.Windows.Forms.TextBox YSelectedRectangleTextBox;
        private System.Windows.Forms.Label YSelectedRectangleLabel;
        private System.Windows.Forms.TextBox XSelectedRectangleTextBox;
        private System.Windows.Forms.Label XSelectedRectangleLabel;
        private System.Windows.Forms.TextBox IdSelectedRectangleTextBox;
        private System.Windows.Forms.Label IdSelectedRectangleLabel;
        private System.Windows.Forms.Label SelectedRectangleLabel;
        private System.Windows.Forms.Button RemoveRectangleButton;
        private System.Windows.Forms.Button AddRectangleButton;
        private System.Windows.Forms.Label RectanglesLabel;
        private System.Windows.Forms.ListBox RectanglesListBox;
    }
}
