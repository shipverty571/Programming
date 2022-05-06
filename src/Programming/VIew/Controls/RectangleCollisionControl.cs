using System;
using System.Collections.Generic;
using System.Drawing;
using System.Windows.Forms;
using Programming.Model;
using Rectangle = Programming.Model.Rectangle;

namespace Programming.View.Controls
{
    public partial class RectangleCollisionControl : UserControl
    {
        private List<Rectangle> _rectangles;

        private List<Panel> _rectanglePanels;

        private Rectangle _currentRectangle;

        private int _heightCanvas;

        private int _widthCanvas;

        public RectangleCollisionControl()
        {
            InitializeComponent();

            _rectangles = new List<Rectangle>();
            _rectanglePanels = new List<Panel>();

            _widthCanvas = CanvasPanel.Width;
            _heightCanvas = CanvasPanel.Height;
        }

        private string FormattedText(Rectangle rectangle)
        {
            return $"{rectangle.Id}: " +
                   $"(X: {rectangle.Center.X};" +
                   $" Y: {rectangle.Center.Y};" +
                   $" W: {rectangle.Width};" +
                   $" H: {rectangle.Height})";
        }

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
                    if (CollisionManager.IsCollision(_rectangles[i], _rectangles[j]))
                    {
                        CanvasPanel.Controls[i].BackColor = AppColors.IsCollision;
                        CanvasPanel.Controls[j].BackColor = AppColors.IsCollision;
                    }
                }
            }
        }

        private void ClearRectangleInfo()
        {
            RectanglesListBox.Items.Clear();
            IdSelectedRectangleTextBox.Clear();
            XSelectedRectangleTextBox.Clear();
            YSelectedRectangleTextBox.Clear();
            WidthSelectedRectangleTextBox.Clear();
            HeightSelectedRectangleTextBox.Clear();
        }

        private void UpdateRectangleInfo(Rectangle rectangle)
        {
            int ind = RectanglesListBox.FindString(rectangle.Id.ToString());

            if (ind == -1) return;

            RectanglesListBox.Items[ind] = $"{rectangle.Id}: " +
                                                  $"(X: {rectangle.Center.X};" +
                                                  $" Y: {rectangle.Center.Y};" +
                                                  $" W: {rectangle.Width};" +
                                                  $" H: {rectangle.Height})";
        }

        private void AddRectangleButton_MouseEnter(object sender, EventArgs e)
        {
            AddRectangleButton.Image = Properties.Resources.rectangle_add_24x24;
        }

        private void AddRectangleButton_MouseLeave(object sender, EventArgs e)
        {
            AddRectangleButton.Image = Properties.Resources.rectangle_add_24x24_uncolor;
        }

        private void RemoveRectangleButton_MouseEnter(object sender, EventArgs e)
        {
            RemoveRectangleButton.Image = Properties.Resources.rectangle_remove_24x24;
        }

        private void RemoveRectangleButton_MouseLeave(object sender, EventArgs e)
        {
            RemoveRectangleButton.Image = Properties.Resources.rectangle_remove_24x24_uncolor;
        }

        private void AddRectangleButton_Click(object sender, EventArgs e)
        {
            _currentRectangle = RectangleFactory.Randomize(_widthCanvas, _heightCanvas);
            _rectangles.Add(_currentRectangle);
            RectanglesListBox.Items.Add(FormattedText(_currentRectangle));
            Panel rectanglePanel = new Panel();
            rectanglePanel.Width = _currentRectangle.Width;
            rectanglePanel.Height = _currentRectangle.Height;
            rectanglePanel.Location = new Point(_currentRectangle.Center.X, _currentRectangle.Center.Y);
            rectanglePanel.BackColor = AppColors.IsNotCollision;
            _rectanglePanels.Add(rectanglePanel);
            CanvasPanel.Controls.Add(rectanglePanel);
            FindCollisions();

        }

        private void RectanglesListBox_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (!(RectanglesListBox.SelectedItem == null))
            {
                int indexSelectedRectangle = RectanglesListBox.SelectedIndex;
                _currentRectangle = _rectangles[indexSelectedRectangle];
                IdSelectedRectangleTextBox.Text = _currentRectangle.Id.ToString();
                XSelectedRectangleTextBox.Text = _currentRectangle.Center.X.ToString();
                YSelectedRectangleTextBox.Text = _currentRectangle.Center.Y.ToString();
                WidthSelectedRectangleTextBox.Text = _currentRectangle.Width.ToString();
                HeightSelectedRectangleTextBox.Text = _currentRectangle.Height.ToString();
            }
        }

        private void RemoveRectangleButton_Click(object sender, EventArgs e)
        {
            int indexSelectedRectangle = RectanglesListBox.SelectedIndex;

            if (indexSelectedRectangle != -1)
            {
                _rectanglePanels.RemoveAt(indexSelectedRectangle);
                _rectangles.RemoveAt(indexSelectedRectangle);
                ClearRectangleInfo();

                for (int i = 0; i < _rectangles.Count; i++)
                {
                    RectanglesListBox.Items.Add(FormattedText(_rectangles[i]));
                    RectanglesListBox.SelectedIndex = 0;
                }

                CanvasPanel.Controls.RemoveAt(indexSelectedRectangle);
                FindCollisions();
            }
        }

        private void XSelectedRectangleTextBox_TextChanged(object sender, EventArgs e)
        {
            if (RectanglesListBox.SelectedIndex == -1) return;

            try
            {
                string currentXRectangle = XSelectedRectangleTextBox.Text;
                int xRectangleValue = int.Parse(currentXRectangle);
                _currentRectangle.Center.X = xRectangleValue;
                CanvasPanel.Controls[RectanglesListBox.SelectedIndex].Location = new Point(_currentRectangle.Center.X, _currentRectangle.Center.Y);
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
                CanvasPanel.Controls[RectanglesListBox.SelectedIndex].Location = new Point(_currentRectangle.Center.X, _currentRectangle.Center.Y);
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

        private void CanvasPanel_Resize(object sender, EventArgs e)
        {
            _heightCanvas = CanvasPanel.Height;
            _widthCanvas = CanvasPanel.Width;
        }
    }
}
