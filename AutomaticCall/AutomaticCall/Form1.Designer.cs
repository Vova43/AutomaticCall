namespace AutomaticCall
{
    partial class Form1
    {
        /// <summary>
        /// Требуется переменная конструктора.
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
        /// Обязательный метод для поддержки конструктора - не изменяйте
        /// содержимое данного метода при помощи редактора кода.
        /// </summary>
        private void InitializeComponent()
        {
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Form1));
            this.label_music_volume = new System.Windows.Forms.Label();
            this.label_bell_volume = new System.Windows.Forms.Label();
            this.Previous = new System.Windows.Forms.Button();
            this.Play = new System.Windows.Forms.Button();
            this.Next = new System.Windows.Forms.Button();
            this.Bell = new System.Windows.Forms.Button();
            this.track_bell_volume = new System.Windows.Forms.TrackBar();
            this.track_music_volume = new System.Windows.Forms.TrackBar();
            this.label_time = new System.Windows.Forms.Label();
            this.Restart = new System.Windows.Forms.Button();
            this.PlayTrackBar = new System.Windows.Forms.TrackBar();
            this.ListMusic = new System.Windows.Forms.ListBox();
            this.ListBell = new System.Windows.Forms.ListBox();
            ((System.ComponentModel.ISupportInitialize)(this.track_bell_volume)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.track_music_volume)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.PlayTrackBar)).BeginInit();
            this.SuspendLayout();
            // 
            // label_music_volume
            // 
            this.label_music_volume.AutoSize = true;
            this.label_music_volume.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.label_music_volume.Location = new System.Drawing.Point(613, 169);
            this.label_music_volume.Name = "label_music_volume";
            this.label_music_volume.Size = new System.Drawing.Size(137, 15);
            this.label_music_volume.TabIndex = 22;
            this.label_music_volume.Text = "Громкость звонка: 0%";
            // 
            // label_bell_volume
            // 
            this.label_bell_volume.AutoSize = true;
            this.label_bell_volume.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.label_bell_volume.ImeMode = System.Windows.Forms.ImeMode.NoControl;
            this.label_bell_volume.Location = new System.Drawing.Point(613, 121);
            this.label_bell_volume.Name = "label_bell_volume";
            this.label_bell_volume.Size = new System.Drawing.Size(139, 15);
            this.label_bell_volume.TabIndex = 21;
            this.label_bell_volume.Text = "Громкость музыки: 0%";
            // 
            // Previous
            // 
            this.Previous.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
            this.Previous.Font = new System.Drawing.Font("Arial Narrow", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.Previous.ImeMode = System.Windows.Forms.ImeMode.NoControl;
            this.Previous.Location = new System.Drawing.Point(564, 32);
            this.Previous.Name = "Previous";
            this.Previous.Size = new System.Drawing.Size(58, 23);
            this.Previous.TabIndex = 20;
            this.Previous.Text = "◄◄";
            this.Previous.UseVisualStyleBackColor = true;
            this.Previous.Click += new System.EventHandler(this.Previous_Click);
            // 
            // Play
            // 
            this.Play.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
            this.Play.Font = new System.Drawing.Font("Arial Narrow", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.Play.ImeMode = System.Windows.Forms.ImeMode.NoControl;
            this.Play.Location = new System.Drawing.Point(628, 32);
            this.Play.Name = "Play";
            this.Play.Size = new System.Drawing.Size(58, 23);
            this.Play.TabIndex = 19;
            this.Play.Text = "►";
            this.Play.UseVisualStyleBackColor = true;
            this.Play.Click += new System.EventHandler(this.Play_Click);
            // 
            // Next
            // 
            this.Next.BackColor = System.Drawing.Color.Transparent;
            this.Next.BackgroundImageLayout = System.Windows.Forms.ImageLayout.None;
            this.Next.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
            this.Next.Font = new System.Drawing.Font("Arial Narrow", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.Next.ImeMode = System.Windows.Forms.ImeMode.NoControl;
            this.Next.Location = new System.Drawing.Point(692, 32);
            this.Next.Name = "Next";
            this.Next.Size = new System.Drawing.Size(58, 23);
            this.Next.TabIndex = 18;
            this.Next.Text = "►►";
            this.Next.UseVisualStyleBackColor = false;
            this.Next.Click += new System.EventHandler(this.Next_Click);
            // 
            // Bell
            // 
            this.Bell.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
            this.Bell.Font = new System.Drawing.Font("Arial Narrow", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.Bell.Location = new System.Drawing.Point(500, 32);
            this.Bell.Name = "Bell";
            this.Bell.Size = new System.Drawing.Size(58, 23);
            this.Bell.TabIndex = 17;
            this.Bell.Text = "Звонок";
            this.Bell.UseVisualStyleBackColor = true;
            this.Bell.Click += new System.EventHandler(this.Bell_Click);
            // 
            // track_bell_volume
            // 
            this.track_bell_volume.LargeChange = 1;
            this.track_bell_volume.Location = new System.Drawing.Point(500, 108);
            this.track_bell_volume.Maximum = 100;
            this.track_bell_volume.Name = "track_bell_volume";
            this.track_bell_volume.RightToLeft = System.Windows.Forms.RightToLeft.No;
            this.track_bell_volume.Size = new System.Drawing.Size(119, 45);
            this.track_bell_volume.TabIndex = 16;
            this.track_bell_volume.TickStyle = System.Windows.Forms.TickStyle.Both;
            // 
            // track_music_volume
            // 
            this.track_music_volume.LargeChange = 1;
            this.track_music_volume.Location = new System.Drawing.Point(500, 157);
            this.track_music_volume.Maximum = 100;
            this.track_music_volume.Name = "track_music_volume";
            this.track_music_volume.Size = new System.Drawing.Size(119, 45);
            this.track_music_volume.TabIndex = 15;
            this.track_music_volume.TickStyle = System.Windows.Forms.TickStyle.Both;
            // 
            // label_time
            // 
            this.label_time.AutoSize = true;
            this.label_time.FlatStyle = System.Windows.Forms.FlatStyle.System;
            this.label_time.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F);
            this.label_time.Location = new System.Drawing.Point(500, 9);
            this.label_time.Name = "label_time";
            this.label_time.Size = new System.Drawing.Size(132, 20);
            this.label_time.TabIndex = 14;
            this.label_time.Text = "Время:  00:00:00";
            // 
            // Restart
            // 
            this.Restart.BackColor = System.Drawing.Color.Transparent;
            this.Restart.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
            this.Restart.Font = new System.Drawing.Font("Arial Narrow", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.Restart.Location = new System.Drawing.Point(628, 6);
            this.Restart.Name = "Restart";
            this.Restart.Size = new System.Drawing.Size(122, 23);
            this.Restart.TabIndex = 23;
            this.Restart.Text = "Обновить файл";
            this.Restart.UseVisualStyleBackColor = false;
            this.Restart.Click += new System.EventHandler(this.Restart_Click);
            // 
            // PlayTrackBar
            // 
            this.PlayTrackBar.Location = new System.Drawing.Point(500, 61);
            this.PlayTrackBar.Maximum = 10000;
            this.PlayTrackBar.Name = "PlayTrackBar";
            this.PlayTrackBar.Size = new System.Drawing.Size(252, 45);
            this.PlayTrackBar.TabIndex = 25;
            this.PlayTrackBar.TickStyle = System.Windows.Forms.TickStyle.Both;
            // 
            // ListMusic
            // 
            this.ListMusic.Font = new System.Drawing.Font("Microsoft Sans Serif", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.ListMusic.FormattingEnabled = true;
            this.ListMusic.ItemHeight = 18;
            this.ListMusic.Location = new System.Drawing.Point(12, 12);
            this.ListMusic.Name = "ListMusic";
            this.ListMusic.Size = new System.Drawing.Size(482, 382);
            this.ListMusic.TabIndex = 26;
            // 
            // ListBell
            // 
            this.ListBell.Font = new System.Drawing.Font("Microsoft Sans Serif", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.ListBell.FormattingEnabled = true;
            this.ListBell.ItemHeight = 18;
            this.ListBell.Location = new System.Drawing.Point(500, 208);
            this.ListBell.Name = "ListBell";
            this.ListBell.Size = new System.Drawing.Size(252, 184);
            this.ListBell.TabIndex = 27;
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(764, 403);
            this.Controls.Add(this.ListBell);
            this.Controls.Add(this.ListMusic);
            this.Controls.Add(this.PlayTrackBar);
            this.Controls.Add(this.Restart);
            this.Controls.Add(this.label_music_volume);
            this.Controls.Add(this.label_bell_volume);
            this.Controls.Add(this.Previous);
            this.Controls.Add(this.Play);
            this.Controls.Add(this.Next);
            this.Controls.Add(this.Bell);
            this.Controls.Add(this.track_bell_volume);
            this.Controls.Add(this.track_music_volume);
            this.Controls.Add(this.label_time);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.SizableToolWindow;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Name = "Form1";
            this.Text = "Form1";
            this.Load += new System.EventHandler(this.Form1_Load);
            ((System.ComponentModel.ISupportInitialize)(this.track_bell_volume)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.track_music_volume)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.PlayTrackBar)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label label_music_volume;
        private System.Windows.Forms.Label label_bell_volume;
        private System.Windows.Forms.Button Previous;
        private System.Windows.Forms.Button Play;
        private System.Windows.Forms.Button Next;
        private System.Windows.Forms.Button Bell;
        private System.Windows.Forms.TrackBar track_bell_volume;
        private System.Windows.Forms.TrackBar track_music_volume;
        private System.Windows.Forms.Label label_time;
        private System.Windows.Forms.Button Restart;
        private System.Windows.Forms.TrackBar PlayTrackBar;
        private System.Windows.Forms.ListBox ListMusic;
        private System.Windows.Forms.ListBox ListBell;

    }
}

