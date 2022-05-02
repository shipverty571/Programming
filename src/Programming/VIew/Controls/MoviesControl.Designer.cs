namespace Programming.View.Controls
{
    partial class MoviesControl
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
            this.GenreMovieTextBox = new System.Windows.Forms.TextBox();
            this.GenreMovieLabel = new System.Windows.Forms.Label();
            this.NameMovieTextBox = new System.Windows.Forms.TextBox();
            this.NameMovieLabel = new System.Windows.Forms.Label();
            this.FindMovieButton = new System.Windows.Forms.Button();
            this.RatingMovieTextBox = new System.Windows.Forms.TextBox();
            this.RatingMovieLabel = new System.Windows.Forms.Label();
            this.DurationMinutesMovieTextBox = new System.Windows.Forms.TextBox();
            this.DurationMinutesMovieLabel = new System.Windows.Forms.Label();
            this.YearReleaseMovieTextBox = new System.Windows.Forms.TextBox();
            this.YearReleaseMovieLabel = new System.Windows.Forms.Label();
            this.MovieListBox = new System.Windows.Forms.ListBox();
            this.SuspendLayout();
            // 
            // GenreMovieTextBox
            // 
            this.GenreMovieTextBox.Location = new System.Drawing.Point(139, 56);
            this.GenreMovieTextBox.Name = "GenreMovieTextBox";
            this.GenreMovieTextBox.Size = new System.Drawing.Size(100, 20);
            this.GenreMovieTextBox.TabIndex = 31;
            this.GenreMovieTextBox.TextChanged += new System.EventHandler(this.GenreMovieTextBox_TextChanged);
            // 
            // GenreMovieLabel
            // 
            this.GenreMovieLabel.AutoSize = true;
            this.GenreMovieLabel.Location = new System.Drawing.Point(136, 40);
            this.GenreMovieLabel.Name = "GenreMovieLabel";
            this.GenreMovieLabel.Size = new System.Drawing.Size(39, 13);
            this.GenreMovieLabel.TabIndex = 30;
            this.GenreMovieLabel.Text = "Genre:";
            // 
            // NameMovieTextBox
            // 
            this.NameMovieTextBox.Location = new System.Drawing.Point(139, 17);
            this.NameMovieTextBox.Name = "NameMovieTextBox";
            this.NameMovieTextBox.Size = new System.Drawing.Size(100, 20);
            this.NameMovieTextBox.TabIndex = 29;
            this.NameMovieTextBox.TextChanged += new System.EventHandler(this.NameMovieTextBox_TextChanged);
            // 
            // NameMovieLabel
            // 
            this.NameMovieLabel.AutoSize = true;
            this.NameMovieLabel.Location = new System.Drawing.Point(136, 1);
            this.NameMovieLabel.Name = "NameMovieLabel";
            this.NameMovieLabel.Size = new System.Drawing.Size(38, 13);
            this.NameMovieLabel.TabIndex = 28;
            this.NameMovieLabel.Text = "Name:";
            // 
            // FindMovieButton
            // 
            this.FindMovieButton.Location = new System.Drawing.Point(139, 267);
            this.FindMovieButton.Name = "FindMovieButton";
            this.FindMovieButton.Size = new System.Drawing.Size(103, 23);
            this.FindMovieButton.TabIndex = 27;
            this.FindMovieButton.Text = "Find";
            this.FindMovieButton.UseVisualStyleBackColor = true;
            this.FindMovieButton.Click += new System.EventHandler(this.FindMovieButton_Click);
            // 
            // RatingMovieTextBox
            // 
            this.RatingMovieTextBox.Location = new System.Drawing.Point(139, 173);
            this.RatingMovieTextBox.Name = "RatingMovieTextBox";
            this.RatingMovieTextBox.Size = new System.Drawing.Size(100, 20);
            this.RatingMovieTextBox.TabIndex = 26;
            this.RatingMovieTextBox.TextChanged += new System.EventHandler(this.RatingMovieTextBox_TextChanged);
            // 
            // RatingMovieLabel
            // 
            this.RatingMovieLabel.AutoSize = true;
            this.RatingMovieLabel.Location = new System.Drawing.Point(136, 157);
            this.RatingMovieLabel.Name = "RatingMovieLabel";
            this.RatingMovieLabel.Size = new System.Drawing.Size(41, 13);
            this.RatingMovieLabel.TabIndex = 25;
            this.RatingMovieLabel.Text = "Rating:";
            // 
            // DurationMinutesMovieTextBox
            // 
            this.DurationMinutesMovieTextBox.Location = new System.Drawing.Point(139, 134);
            this.DurationMinutesMovieTextBox.Name = "DurationMinutesMovieTextBox";
            this.DurationMinutesMovieTextBox.Size = new System.Drawing.Size(100, 20);
            this.DurationMinutesMovieTextBox.TabIndex = 24;
            this.DurationMinutesMovieTextBox.TextChanged += new System.EventHandler(this.DurationMinutesMovieTextBox_TextChanged);
            // 
            // DurationMinutesMovieLabel
            // 
            this.DurationMinutesMovieLabel.AutoSize = true;
            this.DurationMinutesMovieLabel.Location = new System.Drawing.Point(136, 118);
            this.DurationMinutesMovieLabel.Name = "DurationMinutesMovieLabel";
            this.DurationMinutesMovieLabel.Size = new System.Drawing.Size(100, 13);
            this.DurationMinutesMovieLabel.TabIndex = 23;
            this.DurationMinutesMovieLabel.Text = "Duration in minutes:";
            // 
            // YearReleaseMovieTextBox
            // 
            this.YearReleaseMovieTextBox.Location = new System.Drawing.Point(139, 95);
            this.YearReleaseMovieTextBox.Name = "YearReleaseMovieTextBox";
            this.YearReleaseMovieTextBox.Size = new System.Drawing.Size(100, 20);
            this.YearReleaseMovieTextBox.TabIndex = 22;
            this.YearReleaseMovieTextBox.TextChanged += new System.EventHandler(this.YearReleaseMovieTextBox_TextChanged);
            // 
            // YearReleaseMovieLabel
            // 
            this.YearReleaseMovieLabel.AutoSize = true;
            this.YearReleaseMovieLabel.Location = new System.Drawing.Point(136, 79);
            this.YearReleaseMovieLabel.Name = "YearReleaseMovieLabel";
            this.YearReleaseMovieLabel.Size = new System.Drawing.Size(81, 13);
            this.YearReleaseMovieLabel.TabIndex = 21;
            this.YearReleaseMovieLabel.Text = "Year of release:";
            // 
            // MovieListBox
            // 
            this.MovieListBox.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left)));
            this.MovieListBox.FormattingEnabled = true;
            this.MovieListBox.Location = new System.Drawing.Point(0, 0);
            this.MovieListBox.Name = "MovieListBox";
            this.MovieListBox.Size = new System.Drawing.Size(133, 290);
            this.MovieListBox.TabIndex = 20;
            this.MovieListBox.SelectedIndexChanged += new System.EventHandler(this.MovieListBox_SelectedIndexChanged);
            // 
            // MoviesControl
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.GenreMovieTextBox);
            this.Controls.Add(this.GenreMovieLabel);
            this.Controls.Add(this.NameMovieTextBox);
            this.Controls.Add(this.NameMovieLabel);
            this.Controls.Add(this.FindMovieButton);
            this.Controls.Add(this.RatingMovieTextBox);
            this.Controls.Add(this.RatingMovieLabel);
            this.Controls.Add(this.DurationMinutesMovieTextBox);
            this.Controls.Add(this.DurationMinutesMovieLabel);
            this.Controls.Add(this.YearReleaseMovieTextBox);
            this.Controls.Add(this.YearReleaseMovieLabel);
            this.Controls.Add(this.MovieListBox);
            this.Name = "MoviesControl";
            this.Size = new System.Drawing.Size(242, 290);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.TextBox GenreMovieTextBox;
        private System.Windows.Forms.Label GenreMovieLabel;
        private System.Windows.Forms.TextBox NameMovieTextBox;
        private System.Windows.Forms.Label NameMovieLabel;
        private System.Windows.Forms.Button FindMovieButton;
        private System.Windows.Forms.TextBox RatingMovieTextBox;
        private System.Windows.Forms.Label RatingMovieLabel;
        private System.Windows.Forms.TextBox DurationMinutesMovieTextBox;
        private System.Windows.Forms.Label DurationMinutesMovieLabel;
        private System.Windows.Forms.TextBox YearReleaseMovieTextBox;
        private System.Windows.Forms.Label YearReleaseMovieLabel;
        private System.Windows.Forms.ListBox MovieListBox;
    }
}
