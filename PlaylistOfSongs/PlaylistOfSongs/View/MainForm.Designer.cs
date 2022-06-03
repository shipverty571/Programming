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
            this.GenreTextBox = new System.Windows.Forms.TextBox();
            this.GenreLabel = new System.Windows.Forms.Label();
            this.DurationSecondsTextBox = new System.Windows.Forms.TextBox();
            this.DurationSecondsLabel = new System.Windows.Forms.Label();
            this.ArtistNameTextBox = new System.Windows.Forms.TextBox();
            this.ArtistNameLabel = new System.Windows.Forms.Label();
            this.SongNameTextBox = new System.Windows.Forms.TextBox();
            this.SongNameLabel = new System.Windows.Forms.Label();
            this.button1 = new System.Windows.Forms.Button();
            this.EditSongButton = new System.Windows.Forms.Button();
            this.DeleteSongButton = new System.Windows.Forms.Button();
            this.AddSongButton = new System.Windows.Forms.Button();
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
            this.SelectedSongGroupBox.Controls.Add(this.GenreTextBox);
            this.SelectedSongGroupBox.Controls.Add(this.ArtistPictureBox);
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
            // GenreTextBox
            // 
            this.GenreTextBox.HideSelection = false;
            this.GenreTextBox.Location = new System.Drawing.Point(118, 94);
            this.GenreTextBox.Name = "GenreTextBox";
            this.GenreTextBox.ReadOnly = true;
            this.GenreTextBox.Size = new System.Drawing.Size(150, 20);
            this.GenreTextBox.TabIndex = 22;
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
            this.DurationSecondsTextBox.ReadOnly = true;
            this.DurationSecondsTextBox.Size = new System.Drawing.Size(150, 20);
            this.DurationSecondsTextBox.TabIndex = 5;
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
            this.ArtistNameTextBox.ReadOnly = true;
            this.ArtistNameTextBox.Size = new System.Drawing.Size(150, 20);
            this.ArtistNameTextBox.TabIndex = 3;
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
            this.SongNameTextBox.ReadOnly = true;
            this.SongNameTextBox.Size = new System.Drawing.Size(150, 20);
            this.SongNameTextBox.TabIndex = 1;
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
            // EditSongButton
            // 
            this.EditSongButton.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
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
            this.EditSongButton.Click += new System.EventHandler(this.EditSongButton_Click);
            this.EditSongButton.MouseEnter += new System.EventHandler(this.EditSongButton_MouseEnter);
            this.EditSongButton.MouseLeave += new System.EventHandler(this.EditSongButton_MouseLeave);
            // 
            // DeleteSongButton
            // 
            this.DeleteSongButton.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
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
            this.AddSongButton.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
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
        private System.Windows.Forms.Label GenreLabel;
        private System.Windows.Forms.TextBox DurationSecondsTextBox;
        private System.Windows.Forms.Label DurationSecondsLabel;
        private System.Windows.Forms.TextBox ArtistNameTextBox;
        private System.Windows.Forms.Label ArtistNameLabel;
        private System.Windows.Forms.TextBox SongNameTextBox;
        private System.Windows.Forms.Label SongNameLabel;
        private System.Windows.Forms.PictureBox ArtistPictureBox;
        private System.Windows.Forms.Button AddSongButton;
        private System.Windows.Forms.Button DeleteSongButton;
        private System.Windows.Forms.Button EditSongButton;
        private System.Windows.Forms.Button button1;
        private System.Windows.Forms.TextBox GenreTextBox;
    }
}

