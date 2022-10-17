using System;
using System.Collections.Generic;
using System.Drawing;
using System.Windows.Forms;
using Programming.Model;
using Programming.Model.Geometry;
using Programming.Properties;
using Rectangle = Programming.Model.Geometry.Rectangle;

namespace Programming.View.Controls
{
    /// <summary>
    /// Предоставляет реализацию по представлению прямоугольников.
    /// </summary>
    public partial class RectangleCollisionControl : UserControl
    {
        /// <summary>
        /// Коллекция прямоугольников.
        /// </summary>
        private List<Rectangle> _rectangles;

        /// <summary>
        /// Коллекция отображаемых прямоугольников.
        /// </summary>
        private List<Panel> _rectanglePanels;

        /// <summary>
        /// Выбранный прямоугольник.
        /// </summary>
        private Rectangle _currentRectangle;

        /// <summary>
        /// Создаёт экземпляр класса <see cref="RectangleCollisionControl"/>.
        /// </summary>
        public RectangleCollisionControl()
        {
            InitializeComponent();

            _rectangles = new List<Rectangle>();
            _rectanglePanels = new List<Panel>();
        }

        /// <summary>
        /// Из данных прямоугольника преобразует форматированный текст.
        /// </summary>
        /// <param name="rectangle">Прямоугольник.</param>
        /// <returns>Возвращает форматированный текст.</returns>
        private string FormattedText(Rectangle rectangle)
        {
            return $"{rectangle.Id}: " +
                   $"(X: {rectangle.Center.X};" +
                   $" Y: {rectangle.Center.Y};" +
                   $" W: {rectangle.Width};" +
                   $" H: {rectangle.Height})";
        }

        /// <summary>
        /// Находит пересекающиеся прямоугольники и перекрашивает их.
        /// </summary>
        private void FindCollisions()
        {
            for (int i = 0; i < _rectanglePanels.Count; i++)
            {
                CanvasPanel.Controls[i].BackColor = AppColors.IsNotCollision;
            }

            for (int i = 0; i < _rectangles.Count - 1; i++)
            {
                for (int j = i + 1; j < _rectangles.Count; j++)
                {
                    if (!CollisionManager.IsCollision(_rectangles[i], _rectangles[j])) continue;

                    CanvasPanel.Controls[i].BackColor = AppColors.IsCollision;
                    CanvasPanel.Controls[j].BackColor = AppColors.IsCollision;
                }
            }
        }

        /// <summary>
        /// Очищает информацию с текстовых полей и со списка.
        /// </summary>
        private void ClearRectangleInfo()
        {
            RectanglesListBox.Items.Clear();
            IdSelectedRectangleTextBox.Clear();
            XSelectedRectangleTextBox.Clear();
            YSelectedRectangleTextBox.Clear();
            WidthSelectedRectangleTextBox.Clear();
            HeightSelectedRectangleTextBox.Clear();
        }

        private Panel CreatePanel()
        {
            Panel panel = new Panel
            {
                Width = _currentRectangle.Width,
                Height = _currentRectangle.Height,
                Location = new Point(_currentRectangle.Center.X, _currentRectangle.Center.Y),
                BackColor = AppColors.IsNotCollision
            };

            return panel;
        }

        /// <summary>
        /// Обновляет информацию в списке.
        /// </summary>
        /// <param name="rectangle">Прямоугольник.</param>
        private void UpdateRectangleInfo(Rectangle rectangle)
        {
            int ind = RectanglesListBox.FindString(rectangle.Id.ToString());

            if (ind == -1) return;

            RectanglesListBox.Items[ind] = FormattedText(rectangle);
        }


        private void RectanglesListBox_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (RectanglesListBox.SelectedItem == null) return;

            int indexSelectedRectangle = RectanglesListBox.SelectedIndex;
            _currentRectangle = _rectangles[indexSelectedRectangle];
            IdSelectedRectangleTextBox.Text = _currentRectangle.Id.ToString();
            XSelectedRectangleTextBox.Text = _currentRectangle.Center.X.ToString();
            YSelectedRectangleTextBox.Text = _currentRectangle.Center.Y.ToString();
            WidthSelectedRectangleTextBox.Text = _currentRectangle.Width.ToString();
            HeightSelectedRectangleTextBox.Text = _currentRectangle.Height.ToString();
        }

        private void AddRectangleButton_Click(object sender, EventArgs e)
        {
            _currentRectangle = RectangleFactory.Randomize(CanvasPanel.Width, CanvasPanel.Height);
            _rectangles.Add(_currentRectangle);
            RectanglesListBox.Items.Add(FormattedText(_currentRectangle));

            Panel rectanglePanel = CreatePanel();
            _rectanglePanels.Add(rectanglePanel);
            CanvasPanel.Controls.Add(rectanglePanel);
            FindCollisions();
        }

        private void RemoveRectangleButton_Click(object sender, EventArgs e)
        {
            int indexSelectedRectangle = RectanglesListBox.SelectedIndex;

            if (indexSelectedRectangle == -1) return;

            _rectanglePanels.RemoveAt(indexSelectedRectangle);
            _rectangles.RemoveAt(indexSelectedRectangle);
            ClearRectangleInfo();

            foreach (var rectangle in _rectangles)
            {
                RectanglesListBox.Items.Add(FormattedText(rectangle));
                RectanglesListBox.SelectedIndex = 0;
            }

            CanvasPanel.Controls.RemoveAt(indexSelectedRectangle);
            FindCollisions();
        }

        private void XSelectedRectangleTextBox_TextChanged(object sender, EventArgs e)
        {
            if (RectanglesListBox.SelectedIndex == -1) return;

            try
            {
                string currentXRectangle = XSelectedRectangleTextBox.Text;
                int xRectangleValue = int.Parse(currentXRectangle);
                _currentRectangle.Center.X = xRectangleValue;
                CanvasPanel.Controls[RectanglesListBox.SelectedIndex].Location =
                    new Point(_currentRectangle.Center.X, _currentRectangle.Center.Y);
                FindCollisions();
                UpdateRectangleInfo(_currentRectangle);
            }
            catch
            {
                XSelectedRectangleTextBox.BackColor = AppColors.ErrorColor;
                return;
            }

            XSelectedRectangleTextBox.BackColor = AppColors.CorrectColor;
        }

        private void YSelectedRectangleTextBox_TextChanged(object sender, EventArgs e)
        {
            if (RectanglesListBox.SelectedIndex == -1) return;

            try
            {
                string currentYRectangle = YSelectedRectangleTextBox.Text;
                int yRectangleValue = int.Parse(currentYRectangle);
                _currentRectangle.Center.Y = yRectangleValue;
                CanvasPanel.Controls[RectanglesListBox.SelectedIndex].Location =
                    new Point(_currentRectangle.Center.X, _currentRectangle.Center.Y);
                FindCollisions();
                UpdateRectangleInfo(_currentRectangle);
            }
            catch
            {
                YSelectedRectangleTextBox.BackColor = AppColors.ErrorColor;
                return;
            }

            YSelectedRectangleTextBox.BackColor = AppColors.CorrectColor;
        }

        private void WidthSelectedRectangleTextBox_TextChanged(object sender, EventArgs e)
        {
            if (RectanglesListBox.SelectedIndex == -1) return;

            try
            {
                string currentWidthRectangle = WidthSelectedRectangleTextBox.Text;
                int widthRectangleValue = int.Parse(currentWidthRectangle);
                _currentRectangle.Width = widthRectangleValue;
                CanvasPanel.Controls[RectanglesListBox.SelectedIndex].Width = _currentRectangle.Width;
                FindCollisions();
                UpdateRectangleInfo(_currentRectangle);
            }
            catch
            {
                WidthSelectedRectangleTextBox.BackColor = AppColors.ErrorColor;
                return;
            }
            WidthSelectedRectangleTextBox.BackColor = AppColors.CorrectColor;
        }

        private void HeightSelectedRectangleTextBox_TextChanged(object sender, EventArgs e)
        {
            if (RectanglesListBox.SelectedIndex == -1) return;

            try
            {
                string currentHeightRectangle = HeightSelectedRectangleTextBox.Text;
                int heightRectangleValue = int.Parse(currentHeightRectangle);
                _currentRectangle.Height = heightRectangleValue;
                CanvasPanel.Controls[RectanglesListBox.SelectedIndex].Height = _currentRectangle.Height;
                FindCollisions();
                UpdateRectangleInfo(_currentRectangle);
            }
            catch
            {
                HeightSelectedRectangleTextBox.BackColor = AppColors.ErrorColor;
                return;
            }
            HeightSelectedRectangleTextBox.BackColor = AppColors.CorrectColor;
        }

        private void AddRectangleButton_MouseEnter(object sender, EventArgs e)
        {
            AddRectangleButton.Image = Resources.rectangle_add_24x24;
        }

        private void AddRectangleButton_MouseLeave(object sender, EventArgs e)
        {
            AddRectangleButton.Image = Resources.rectangle_add_24x24_uncolor;
        }

        private void RemoveRectangleButton_MouseEnter(object sender, EventArgs e)
        {
            RemoveRectangleButton.Image = Resources.rectangle_remove_24x24;
        }

        private void RemoveRectangleButton_MouseLeave(object sender, EventArgs e)
        {
            RemoveRectangleButton.Image = Resources.rectangle_remove_24x24_uncolor;
        }
    }
}
