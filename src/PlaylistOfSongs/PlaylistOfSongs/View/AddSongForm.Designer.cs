namespace PlaylistOfSongs.View
{
    partial class AddSongForm
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(AddSongForm));
            this.GenreComboBox = new System.Windows.Forms.ComboBox();
            this.GenreLabel = new System.Windows.Forms.Label();
            this.DurationSecondsTextBox = new System.Windows.Forms.TextBox();
            this.DurationSecondsLabel = new System.Windows.Forms.Label();
            this.ArtistNameTextBox = new System.Windows.Forms.TextBox();
            this.ArtistNameLabel = new System.Windows.Forms.Label();
            this.SongNameTextBox = new System.Windows.Forms.TextBox();
            this.SongNameLabel = new System.Windows.Forms.Label();
            this.CancelButton = new System.Windows.Forms.Button();
            this.OKButton = new System.Windows.Forms.Button();
            this.ImageLabel = new System.Windows.Forms.Label();
            this.DeleteImageButton = new System.Windows.Forms.Button();
            this.OpenImageButton = new System.Windows.Forms.Button();
            this.ArtistPictureBox = new System.Windows.Forms.PictureBox();
            ((System.ComponentModel.ISupportInitialize)(this.ArtistPictureBox)).BeginInit();
            this.SuspendLayout();
            // 
            // GenreComboBox
            // 
            this.GenreComboBox.FormattingEnabled = true;
            this.GenreComboBox.Location = new System.Drawing.Point(326, 84);
            this.GenreComboBox.Name = "GenreComboBox";
            this.GenreComboBox.Size = new System.Drawing.Size(150, 21);
            this.GenreComboBox.TabIndex = 14;
            this.GenreComboBox.SelectedIndexChanged += new System.EventHandler(this.GenreComboBox_SelectedIndexChanged);
            // 
            // GenreLabel
            // 
            this.GenreLabel.AutoSize = true;
            this.GenreLabel.Location = new System.Drawing.Point(281, 87);
            this.GenreLabel.Name = "GenreLabel";
            this.GenreLabel.Size = new System.Drawing.Size(39, 13);
            this.GenreLabel.TabIndex = 11;
            this.GenreLabel.Text = "Genre:";
            // 
            // DurationSecondsTextBox
            // 
            this.DurationSecondsTextBox.HideSelection = false;
            this.DurationSecondsTextBox.Location = new System.Drawing.Point(326, 58);
            this.DurationSecondsTextBox.Name = "DurationSecondsTextBox";
            this.DurationSecondsTextBox.Size = new System.Drawing.Size(150, 20);
            this.DurationSecondsTextBox.TabIndex = 13;
            this.DurationSecondsTextBox.TextChanged += new System.EventHandler(this.DurationSecondsTextBox_TextChanged);
            // 
            // DurationSecondsLabel
            // 
            this.DurationSecondsLabel.AutoSize = true;
            this.DurationSecondsLabel.Location = new System.Drawing.Point(215, 61);
            this.DurationSecondsLabel.Name = "DurationSecondsLabel";
            this.DurationSecondsLabel.Size = new System.Drawing.Size(105, 13);
            this.DurationSecondsLabel.TabIndex = 12;
            this.DurationSecondsLabel.Text = "Duration of seconds:";
            // 
            // ArtistNameTextBox
            // 
            this.ArtistNameTextBox.Location = new System.Drawing.Point(326, 32);
            this.ArtistNameTextBox.Name = "ArtistNameTextBox";
            this.ArtistNameTextBox.Size = new System.Drawing.Size(150, 20);
            this.ArtistNameTextBox.TabIndex = 10;
            this.ArtistNameTextBox.TextChanged += new System.EventHandler(this.ArtistNameTextBox_TextChanged);
            // 
            // ArtistNameLabel
            // 
            this.ArtistNameLabel.AutoSize = true;
            this.ArtistNameLabel.Location = new System.Drawing.Point(258, 35);
            this.ArtistNameLabel.Name = "ArtistNameLabel";
            this.ArtistNameLabel.Size = new System.Drawing.Size(62, 13);
            this.ArtistNameLabel.TabIndex = 9;
            this.ArtistNameLabel.Text = "Artist name:";
            // 
            // SongNameTextBox
            // 
            this.SongNameTextBox.Location = new System.Drawing.Point(326, 6);
            this.SongNameTextBox.Name = "SongNameTextBox";
            this.SongNameTextBox.Size = new System.Drawing.Size(150, 20);
            this.SongNameTextBox.TabIndex = 8;
            this.SongNameTextBox.TextChanged += new System.EventHandler(this.SongNameTextBox_TextChanged);
            // 
            // SongNameLabel
            // 
            this.SongNameLabel.AutoSize = true;
            this.SongNameLabel.Location = new System.Drawing.Point(256, 9);
            this.SongNameLabel.Name = "SongNameLabel";
            this.SongNameLabel.Size = new System.Drawing.Size(64, 13);
            this.SongNameLabel.TabIndex = 7;
            this.SongNameLabel.Text = "Song name:";
            // 
            // CancelButton
            // 
            this.CancelButton.Location = new System.Drawing.Point(401, 183);
            this.CancelButton.Name = "CancelButton";
            this.CancelButton.Size = new System.Drawing.Size(75, 23);
            this.CancelButton.TabIndex = 15;
            this.CancelButton.Text = "Cancel";
            this.CancelButton.UseVisualStyleBackColor = true;
            this.CancelButton.Click += new System.EventHandler(this.CancelButton_Click);
            // 
            // OKButton
            // 
            this.OKButton.Location = new System.Drawing.Point(320, 183);
            this.OKButton.Name = "OKButton";
            this.OKButton.Size = new System.Drawing.Size(75, 23);
            this.OKButton.TabIndex = 16;
            this.OKButton.Text = "OK";
            this.OKButton.UseVisualStyleBackColor = true;
            this.OKButton.Click += new System.EventHandler(this.OKButton_Click);
            // 
            // ImageLabel
            // 
            this.ImageLabel.AutoSize = true;
            this.ImageLabel.Location = new System.Drawing.Point(281, 118);
            this.ImageLabel.Name = "ImageLabel";
            this.ImageLabel.Size = new System.Drawing.Size(39, 13);
            this.ImageLabel.TabIndex = 17;
            this.ImageLabel.Text = "Image:";
            // 
            // DeleteImageButton
            // 
            this.DeleteImageButton.FlatAppearance.BorderSize = 0;
            this.DeleteImageButton.FlatAppearance.MouseDownBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(235)))), ((int)(((byte)(235)))), ((int)(((byte)(235)))));
            this.DeleteImageButton.FlatAppearance.MouseOverBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(240)))), ((int)(((byte)(240)))), ((int)(((byte)(240)))));
            this.DeleteImageButton.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.DeleteImageButton.Image = ((System.Drawing.Image)(resources.GetObject("DeleteImageButton.Image")));
            this.DeleteImageButton.Location = new System.Drawing.Point(382, 111);
            this.DeleteImageButton.Name = "DeleteImageButton";
            this.DeleteImageButton.Size = new System.Drawing.Size(50, 26);
            this.DeleteImageButton.TabIndex = 23;
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
            this.OpenImageButton.Location = new System.Drawing.Point(326, 111);
            this.OpenImageButton.Name = "OpenImageButton";
            this.OpenImageButton.Size = new System.Drawing.Size(50, 26);
            this.OpenImageButton.TabIndex = 22;
            this.OpenImageButton.UseVisualStyleBackColor = true;
            this.OpenImageButton.Click += new System.EventHandler(this.OpenImageButton_Click);
            this.OpenImageButton.MouseEnter += new System.EventHandler(this.OpenImageButton_MouseEnter);
            this.OpenImageButton.MouseLeave += new System.EventHandler(this.OpenImageButton_MouseLeave);
            // 
            // ArtistPictureBox
            // 
            this.ArtistPictureBox.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.ArtistPictureBox.Location = new System.Drawing.Point(6, 6);
            this.ArtistPictureBox.Name = "ArtistPictureBox";
            this.ArtistPictureBox.Size = new System.Drawing.Size(200, 200);
            this.ArtistPictureBox.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.ArtistPictureBox.TabIndex = 19;
            this.ArtistPictureBox.TabStop = false;
            // 
            // AddSongForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(482, 212);
            this.Controls.Add(this.DeleteImageButton);
            this.Controls.Add(this.OpenImageButton);
            this.Controls.Add(this.ArtistPictureBox);
            this.Controls.Add(this.ImageLabel);
            this.Controls.Add(this.OKButton);
            this.Controls.Add(this.CancelButton);
            this.Controls.Add(this.GenreComboBox);
            this.Controls.Add(this.GenreLabel);
            this.Controls.Add(this.DurationSecondsTextBox);
            this.Controls.Add(this.DurationSecondsLabel);
            this.Controls.Add(this.ArtistNameTextBox);
            this.Controls.Add(this.ArtistNameLabel);
            this.Controls.Add(this.SongNameTextBox);
            this.Controls.Add(this.SongNameLabel);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.MaximumSize = new System.Drawing.Size(498, 251);
            this.MinimumSize = new System.Drawing.Size(498, 251);
            this.Name = "AddSongForm";
            this.Text = "Add song";
            ((System.ComponentModel.ISupportInitialize)(this.ArtistPictureBox)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.ComboBox GenreComboBox;
        private System.Windows.Forms.Label GenreLabel;
        private System.Windows.Forms.TextBox DurationSecondsTextBox;
        private System.Windows.Forms.Label DurationSecondsLabel;
        private System.Windows.Forms.TextBox ArtistNameTextBox;
        private System.Windows.Forms.Label ArtistNameLabel;
        private System.Windows.Forms.TextBox SongNameTextBox;
        private System.Windows.Forms.Label SongNameLabel;
        private System.Windows.Forms.Button CancelButton;
        private System.Windows.Forms.Button OKButton;
        private System.Windows.Forms.Label ImageLabel;
        private System.Windows.Forms.PictureBox ArtistPictureBox;
        private System.Windows.Forms.Button DeleteImageButton;
        private System.Windows.Forms.Button OpenImageButton;
    }
}