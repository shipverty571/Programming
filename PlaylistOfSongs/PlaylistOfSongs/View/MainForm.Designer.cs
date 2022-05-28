namespace PlaylistOfSongs.View
{
    partial class MainForm
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

        #region Код, автоматически созданный конструктором форм Windows

        /// <summary>
        /// Требуемый метод для поддержки конструктора — не изменяйте 
        /// содержимое этого метода с помощью редактора кода.
        /// </summary>
        private void InitializeComponent()
        {
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(MainForm));
            this.SongListBox = new System.Windows.Forms.ListBox();
            this.SelectedSongGroupBox = new System.Windows.Forms.GroupBox();
            this.ImageLabel = new System.Windows.Forms.Label();
            this.GenreComboBox = new System.Windows.Forms.ComboBox();
            this.GenreLabel = new System.Windows.Forms.Label();
            this.DurationSecondsTextBox = new System.Windows.Forms.TextBox();
            this.DurationSecondsLabel = new System.Windows.Forms.Label();
            this.ArtistNameTextBox = new System.Windows.Forms.TextBox();
            this.ArtistNameLabel = new System.Windows.Forms.Label();
            this.SongNameTextBox = new System.Windows.Forms.TextBox();
            this.SongNameLabel = new System.Windows.Forms.Label();
            this.button1 = new System.Windows.Forms.Button();
            this.EditButton = new System.Windows.Forms.Button();
            this.EditSongButton = new System.Windows.Forms.Button();
            this.DeleteSongButton = new System.Windows.Forms.Button();
            this.AddSongButton = new System.Windows.Forms.Button();
            this.DeleteImageButton = new System.Windows.Forms.Button();
            this.OpenImageButton = new System.Windows.Forms.Button();
            this.ArtistPictureBox = new System.Windows.Forms.PictureBox();
            this.SelectedSongGroupBox.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.ArtistPictureBox)).BeginInit();
            this.SuspendLayout();
            // 
            // SongListBox
            // 
            this.SongListBox.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left)));
            this.SongListBox.FormattingEnabled = true;
            this.SongListBox.Location = new System.Drawing.Point(6, 6);
            this.SongListBox.Name = "SongListBox";
            this.SongListBox.Size = new System.Drawing.Size(200, 368);
            this.SongListBox.TabIndex = 0;
            this.SongListBox.SelectedIndexChanged += new System.EventHandler(this.SongListBox_SelectedIndexChanged);
            // 
            // SelectedSongGroupBox
            // 
            this.SelectedSongGroupBox.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.SelectedSongGroupBox.Controls.Add(this.DeleteImageButton);
            this.SelectedSongGroupBox.Controls.Add(this.OpenImageButton);
            this.SelectedSongGroupBox.Controls.Add(this.ImageLabel);
            this.SelectedSongGroupBox.Controls.Add(this.ArtistPictureBox);
            this.SelectedSongGroupBox.Controls.Add(this.GenreComboBox);
            this.SelectedSongGroupBox.Controls.Add(this.GenreLabel);
            this.SelectedSongGroupBox.Controls.Add(this.DurationSecondsTextBox);
            this.SelectedSongGroupBox.Controls.Add(this.DurationSecondsLabel);
            this.SelectedSongGroupBox.Controls.Add(this.ArtistNameTextBox);
            this.SelectedSongGroupBox.Controls.Add(this.ArtistNameLabel);
            this.SelectedSongGroupBox.Controls.Add(this.SongNameTextBox);
            this.SelectedSongGroupBox.Controls.Add(this.SongNameLabel);
            this.SelectedSongGroupBox.Location = new System.Drawing.Point(215, 6);
            this.SelectedSongGroupBox.Name = "SelectedSongGroupBox";
            this.SelectedSongGroupBox.Size = new System.Drawing.Size(564, 225);
            this.SelectedSongGroupBox.TabIndex = 1;
            this.SelectedSongGroupBox.TabStop = false;
            this.SelectedSongGroupBox.Text = "Selected song";
            // 
            // ImageLabel
            // 
            this.ImageLabel.AutoSize = true;
            this.ImageLabel.Location = new System.Drawing.Point(73, 128);
            this.ImageLabel.Name = "ImageLabel";
            this.ImageLabel.Size = new System.Drawing.Size(39, 13);
            this.ImageLabel.TabIndex = 19;
            this.ImageLabel.Text = "Image:";
            // 
            // GenreComboBox
            // 
            this.GenreComboBox.FormattingEnabled = true;
            this.GenreComboBox.Location = new System.Drawing.Point(118, 94);
            this.GenreComboBox.Name = "GenreComboBox";
            this.GenreComboBox.Size = new System.Drawing.Size(150, 21);
            this.GenreComboBox.TabIndex = 6;
            this.GenreComboBox.SelectedIndexChanged += new System.EventHandler(this.GenreComboBox_SelectedIndexChanged);
            // 
            // GenreLabel
            // 
            this.GenreLabel.AutoSize = true;
            this.GenreLabel.Location = new System.Drawing.Point(73, 98);
            this.GenreLabel.Name = "GenreLabel";
            this.GenreLabel.Size = new System.Drawing.Size(39, 13);
            this.GenreLabel.TabIndex = 4;
            this.GenreLabel.Text = "Genre:";
            // 
            // DurationSecondsTextBox
            // 
            this.DurationSecondsTextBox.HideSelection = false;
            this.DurationSecondsTextBox.Location = new System.Drawing.Point(118, 68);
            this.DurationSecondsTextBox.Name = "DurationSecondsTextBox";
            this.DurationSecondsTextBox.Size = new System.Drawing.Size(150, 20);
            this.DurationSecondsTextBox.TabIndex = 5;
            this.DurationSecondsTextBox.TextChanged += new System.EventHandler(this.DurationSecondsTextBox_TextChanged);
            // 
            // DurationSecondsLabel
            // 
            this.DurationSecondsLabel.AutoSize = true;
            this.DurationSecondsLabel.Location = new System.Drawing.Point(7, 71);
            this.DurationSecondsLabel.Name = "DurationSecondsLabel";
            this.DurationSecondsLabel.Size = new System.Drawing.Size(105, 13);
            this.DurationSecondsLabel.TabIndex = 4;
            this.DurationSecondsLabel.Text = "Duration of seconds:";
            // 
            // ArtistNameTextBox
            // 
            this.ArtistNameTextBox.Location = new System.Drawing.Point(118, 42);
            this.ArtistNameTextBox.Name = "ArtistNameTextBox";
            this.ArtistNameTextBox.Size = new System.Drawing.Size(150, 20);
            this.ArtistNameTextBox.TabIndex = 3;
            this.ArtistNameTextBox.TextChanged += new System.EventHandler(this.ArtistNameTextBox_TextChanged);
            // 
            // ArtistNameLabel
            // 
            this.ArtistNameLabel.AutoSize = true;
            this.ArtistNameLabel.Location = new System.Drawing.Point(50, 45);
            this.ArtistNameLabel.Name = "ArtistNameLabel";
            this.ArtistNameLabel.Size = new System.Drawing.Size(62, 13);
            this.ArtistNameLabel.TabIndex = 2;
            this.ArtistNameLabel.Text = "Artist name:";
            // 
            // SongNameTextBox
            // 
            this.SongNameTextBox.Location = new System.Drawing.Point(118, 16);
            this.SongNameTextBox.Name = "SongNameTextBox";
            this.SongNameTextBox.Size = new System.Drawing.Size(150, 20);
            this.SongNameTextBox.TabIndex = 1;
            this.SongNameTextBox.TextChanged += new System.EventHandler(this.SongNameTextBox_TextChanged);
            // 
            // SongNameLabel
            // 
            this.SongNameLabel.AutoSize = true;
            this.SongNameLabel.Location = new System.Drawing.Point(48, 19);
            this.SongNameLabel.Name = "SongNameLabel";
            this.SongNameLabel.Size = new System.Drawing.Size(64, 13);
            this.SongNameLabel.TabIndex = 0;
            this.SongNameLabel.Text = "Song name:";
            // 
            // button1
            // 
            this.button1.FlatAppearance.BorderSize = 0;
            this.button1.FlatAppearance.MouseDownBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(230)))), ((int)(((byte)(230)))), ((int)(((byte)(230)))));
            this.button1.FlatAppearance.MouseOverBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(235)))), ((int)(((byte)(235)))), ((int)(((byte)(235)))));
            this.button1.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.button1.Location = new System.Drawing.Point(62, 380);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(50, 26);
            this.button1.TabIndex = 4;
            this.button1.UseVisualStyleBackColor = true;
            // 
            // EditButton
            // 
            this.EditButton.FlatAppearance.BorderSize = 0;
            this.EditButton.FlatAppearance.MouseDownBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(230)))), ((int)(((byte)(230)))), ((int)(((byte)(230)))));
            this.EditButton.FlatAppearance.MouseOverBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(235)))), ((int)(((byte)(235)))), ((int)(((byte)(235)))));
            this.EditButton.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.EditButton.Location = new System.Drawing.Point(62, 380);
            this.EditButton.Name = "EditButton";
            this.EditButton.Size = new System.Drawing.Size(50, 26);
            this.EditButton.TabIndex = 4;
            this.EditButton.UseVisualStyleBackColor = true;
            // 
            // EditSongButton
            // 
            this.EditSongButton.FlatAppearance.BorderSize = 0;
            this.EditSongButton.FlatAppearance.MouseDownBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(235)))), ((int)(((byte)(235)))), ((int)(((byte)(235)))));
            this.EditSongButton.FlatAppearance.MouseOverBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(240)))), ((int)(((byte)(240)))), ((int)(((byte)(240)))));
            this.EditSongButton.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.EditSongButton.Image = global::PlaylistOfSongs.Properties.Resources.edit_24x24_uncolor;
            this.EditSongButton.Location = new System.Drawing.Point(62, 380);
            this.EditSongButton.Name = "EditSongButton";
            this.EditSongButton.Size = new System.Drawing.Size(50, 26);
            this.EditSongButton.TabIndex = 4;
            this.EditSongButton.UseVisualStyleBackColor = true;
            this.EditSongButton.MouseEnter += new System.EventHandler(this.EditSongButton_MouseEnter);
            this.EditSongButton.MouseLeave += new System.EventHandler(this.EditSongButton_MouseLeave);
            // 
            // DeleteSongButton
            // 
            this.DeleteSongButton.FlatAppearance.BorderSize = 0;
            this.DeleteSongButton.FlatAppearance.MouseDownBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(235)))), ((int)(((byte)(235)))), ((int)(((byte)(235)))));
            this.DeleteSongButton.FlatAppearance.MouseOverBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(240)))), ((int)(((byte)(240)))), ((int)(((byte)(240)))));
            this.DeleteSongButton.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.DeleteSongButton.Image = global::PlaylistOfSongs.Properties.Resources.remove_24x24_uncolor;
            this.DeleteSongButton.Location = new System.Drawing.Point(118, 380);
            this.DeleteSongButton.Name = "DeleteSongButton";
            this.DeleteSongButton.Size = new System.Drawing.Size(50, 26);
            this.DeleteSongButton.TabIndex = 3;
            this.DeleteSongButton.UseVisualStyleBackColor = true;
            this.DeleteSongButton.Click += new System.EventHandler(this.DeleteSongButton_Click);
            this.DeleteSongButton.MouseEnter += new System.EventHandler(this.DeleteSongButton_MouseEnter);
            this.DeleteSongButton.MouseLeave += new System.EventHandler(this.DeleteSongButton_MouseLeave);
            // 
            // AddSongButton
            // 
            this.AddSongButton.FlatAppearance.BorderSize = 0;
            this.AddSongButton.FlatAppearance.MouseDownBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(235)))), ((int)(((byte)(235)))), ((int)(((byte)(235)))));
            this.AddSongButton.FlatAppearance.MouseOverBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(240)))), ((int)(((byte)(240)))), ((int)(((byte)(240)))));
            this.AddSongButton.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.AddSongButton.Image = global::PlaylistOfSongs.Properties.Resources.add_24x24_uncolor;
            this.AddSongButton.Location = new System.Drawing.Point(6, 380);
            this.AddSongButton.Name = "AddSongButton";
            this.AddSongButton.Size = new System.Drawing.Size(50, 26);
            this.AddSongButton.TabIndex = 2;
            this.AddSongButton.UseVisualStyleBackColor = true;
            this.AddSongButton.Click += new System.EventHandler(this.AddSongButton_Click);
            this.AddSongButton.MouseEnter += new System.EventHandler(this.AddSongButton_MouseEnter);
            this.AddSongButton.MouseLeave += new System.EventHandler(this.AddSongButton_MouseLeave);
            // 
            // DeleteImageButton
            // 
            this.DeleteImageButton.FlatAppearance.BorderSize = 0;
            this.DeleteImageButton.FlatAppearance.MouseDownBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(235)))), ((int)(((byte)(235)))), ((int)(((byte)(235)))));
            this.DeleteImageButton.FlatAppearance.MouseOverBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(240)))), ((int)(((byte)(240)))), ((int)(((byte)(240)))));
            this.DeleteImageButton.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.DeleteImageButton.Image = ((System.Drawing.Image)(resources.GetObject("DeleteImageButton.Image")));
            this.DeleteImageButton.Location = new System.Drawing.Point(174, 121);
            this.DeleteImageButton.Name = "DeleteImageButton";
            this.DeleteImageButton.Size = new System.Drawing.Size(50, 26);
            this.DeleteImageButton.TabIndex = 21;
            this.DeleteImageButton.TabStop = false;
            this.DeleteImageButton.UseVisualStyleBackColor = true;
            this.DeleteImageButton.Click += new System.EventHandler(this.DeleteImageButton_Click);
            this.DeleteImageButton.MouseEnter += new System.EventHandler(this.DeleteImageButton_MouseEnter);
            this.DeleteImageButton.MouseLeave += new System.EventHandler(this.DeleteImageButton_MouseLeave);
            // 
            // OpenImageButton
            // 
            this.OpenImageButton.FlatAppearance.BorderSize = 0;
            this.OpenImageButton.FlatAppearance.MouseDownBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(235)))), ((int)(((byte)(235)))), ((int)(((byte)(235)))));
            this.OpenImageButton.FlatAppearance.MouseOverBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(240)))), ((int)(((byte)(240)))), ((int)(((byte)(240)))));
            this.OpenImageButton.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.OpenImageButton.Image = ((System.Drawing.Image)(resources.GetObject("OpenImageButton.Image")));
            this.OpenImageButton.Location = new System.Drawing.Point(118, 121);
            this.OpenImageButton.Name = "OpenImageButton";
            this.OpenImageButton.Size = new System.Drawing.Size(50, 26);
            this.OpenImageButton.TabIndex = 20;
            this.OpenImageButton.UseVisualStyleBackColor = true;
            this.OpenImageButton.Click += new System.EventHandler(this.OpenImageButton_Click);
            this.OpenImageButton.MouseEnter += new System.EventHandler(this.OpenImageButton_MouseEnter);
            this.OpenImageButton.MouseLeave += new System.EventHandler(this.OpenImageButton_MouseLeave);
            // 
            // ArtistPictureBox
            // 
            this.ArtistPictureBox.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.ArtistPictureBox.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.ArtistPictureBox.Location = new System.Drawing.Point(356, 16);
            this.ArtistPictureBox.Name = "ArtistPictureBox";
            this.ArtistPictureBox.Size = new System.Drawing.Size(200, 200);
            this.ArtistPictureBox.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.ArtistPictureBox.TabIndex = 7;
            this.ArtistPictureBox.TabStop = false;
            // 
            // MainForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(784, 421);
            this.Controls.Add(this.EditSongButton);
            this.Controls.Add(this.DeleteSongButton);
            this.Controls.Add(this.AddSongButton);
            this.Controls.Add(this.SelectedSongGroupBox);
            this.Controls.Add(this.SongListBox);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.MinimumSize = new System.Drawing.Size(800, 460);
            this.Name = "MainForm";
            this.Text = "Playlist of songs";
            this.SelectedSongGroupBox.ResumeLayout(false);
            this.SelectedSongGroupBox.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.ArtistPictureBox)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.ListBox SongListBox;
        private System.Windows.Forms.GroupBox SelectedSongGroupBox;
        private System.Windows.Forms.ComboBox GenreComboBox;
        private System.Windows.Forms.Label GenreLabel;
        private System.Windows.Forms.TextBox DurationSecondsTextBox;
        private System.Windows.Forms.Label DurationSecondsLabel;
        private System.Windows.Forms.TextBox ArtistNameTextBox;
        private System.Windows.Forms.Label ArtistNameLabel;
        private System.Windows.Forms.TextBox SongNameTextBox;
        private System.Windows.Forms.Label SongNameLabel;
        private System.Windows.Forms.PictureBox ArtistPictureBox;
        private System.Windows.Forms.Button OpenImageButton;
        private System.Windows.Forms.Label ImageLabel;
        private System.Windows.Forms.Button DeleteImageButton;
        private System.Windows.Forms.Button AddSongButton;
        private System.Windows.Forms.Button DeleteSongButton;
        private System.Windows.Forms.Button EditSongButton;
        private System.Windows.Forms.Button button1;
        private System.Windows.Forms.Button EditButton;
    }
}

