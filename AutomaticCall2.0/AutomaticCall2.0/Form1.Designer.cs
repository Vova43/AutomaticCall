
namespace AutomaticCall2._0
{
    partial class Form1
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
            this.components = new System.ComponentModel.Container();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Form1));
            this.ShowPanel1 = new System.Windows.Forms.Panel();
            this.ShowPanelButton1 = new System.Windows.Forms.Button();
            this.groupBox2 = new System.Windows.Forms.GroupBox();
            this.ListMusic = new System.Windows.Forms.ListBox();
            this.PlayTrackBar = new System.Windows.Forms.TrackBar();
            this.label_music_volume = new System.Windows.Forms.Label();
            this.label_bell_volume = new System.Windows.Forms.Label();
            this.Previous = new System.Windows.Forms.Button();
            this.Play = new System.Windows.Forms.Button();
            this.Next = new System.Windows.Forms.Button();
            this.Bell = new System.Windows.Forms.Button();
            this.track_bell_volume = new System.Windows.Forms.TrackBar();
            this.track_music_volume = new System.Windows.Forms.TrackBar();
            this.label_time = new System.Windows.Forms.Label();
            this.ListBell = new System.Windows.Forms.ListBox();
            this.contextMenuStrip1 = new System.Windows.Forms.ContextMenuStrip(this.components);
            this.AdsPanel = new System.Windows.Forms.Panel();
            this.ShowPanelButton2 = new System.Windows.Forms.Button();
            this.groupBox3 = new System.Windows.Forms.GroupBox();
            this.ListAds = new System.Windows.Forms.ListBox();
            this.Settings = new System.Windows.Forms.Button();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.groupBox4 = new System.Windows.Forms.GroupBox();
            this.ShowPanel1.SuspendLayout();
            this.groupBox2.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.PlayTrackBar)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.track_bell_volume)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.track_music_volume)).BeginInit();
            this.AdsPanel.SuspendLayout();
            this.groupBox3.SuspendLayout();
            this.groupBox1.SuspendLayout();
            this.groupBox4.SuspendLayout();
            this.SuspendLayout();
            // 
            // ShowPanel1
            // 
            this.ShowPanel1.BackColor = System.Drawing.SystemColors.Control;
            this.ShowPanel1.Controls.Add(this.ShowPanelButton1);
            this.ShowPanel1.Controls.Add(this.groupBox2);
            this.ShowPanel1.Location = new System.Drawing.Point(-507, 0);
            this.ShowPanel1.Name = "ShowPanel1";
            this.ShowPanel1.Size = new System.Drawing.Size(527, 270);
            this.ShowPanel1.TabIndex = 0;
            // 
            // ShowPanelButton1
            // 
            this.ShowPanelButton1.BackColor = System.Drawing.SystemColors.Control;
            this.ShowPanelButton1.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
            this.ShowPanelButton1.Font = new System.Drawing.Font("Arial", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.ShowPanelButton1.Location = new System.Drawing.Point(507, 0);
            this.ShowPanelButton1.Name = "ShowPanelButton1";
            this.ShowPanelButton1.Size = new System.Drawing.Size(20, 270);
            this.ShowPanelButton1.TabIndex = 1;
            this.ShowPanelButton1.Text = "►";
            this.ShowPanelButton1.UseVisualStyleBackColor = false;
            // 
            // groupBox2
            // 
            this.groupBox2.BackColor = System.Drawing.SystemColors.Control;
            this.groupBox2.Controls.Add(this.ListMusic);
            this.groupBox2.Font = new System.Drawing.Font("Arial Narrow", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.groupBox2.Location = new System.Drawing.Point(0, 0);
            this.groupBox2.Name = "groupBox2";
            this.groupBox2.Size = new System.Drawing.Size(507, 270);
            this.groupBox2.TabIndex = 0;
            this.groupBox2.TabStop = false;
            this.groupBox2.Text = "Список воспроизведения";
            // 
            // ListMusic
            // 
            this.ListMusic.Font = new System.Drawing.Font("Arial", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.ListMusic.FormattingEnabled = true;
            this.ListMusic.ItemHeight = 16;
            this.ListMusic.Location = new System.Drawing.Point(6, 24);
            this.ListMusic.Name = "ListMusic";
            this.ListMusic.Size = new System.Drawing.Size(495, 228);
            this.ListMusic.TabIndex = 0;
            // 
            // PlayTrackBar
            // 
            this.PlayTrackBar.Location = new System.Drawing.Point(15, 85);
            this.PlayTrackBar.Maximum = 10000;
            this.PlayTrackBar.Name = "PlayTrackBar";
            this.PlayTrackBar.Size = new System.Drawing.Size(252, 45);
            this.PlayTrackBar.TabIndex = 36;
            this.PlayTrackBar.TickStyle = System.Windows.Forms.TickStyle.Both;
            // 
            // label_music_volume
            // 
            this.label_music_volume.AutoSize = true;
            this.label_music_volume.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.label_music_volume.Location = new System.Drawing.Point(128, 199);
            this.label_music_volume.Name = "label_music_volume";
            this.label_music_volume.Size = new System.Drawing.Size(137, 15);
            this.label_music_volume.TabIndex = 34;
            this.label_music_volume.Text = "Громкость звонка: 0%";
            // 
            // label_bell_volume
            // 
            this.label_bell_volume.AutoSize = true;
            this.label_bell_volume.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.label_bell_volume.ImeMode = System.Windows.Forms.ImeMode.NoControl;
            this.label_bell_volume.Location = new System.Drawing.Point(128, 149);
            this.label_bell_volume.Name = "label_bell_volume";
            this.label_bell_volume.Size = new System.Drawing.Size(139, 15);
            this.label_bell_volume.TabIndex = 33;
            this.label_bell_volume.Text = "Громкость музыки: 0%";
            // 
            // Previous
            // 
            this.Previous.BackColor = System.Drawing.SystemColors.Control;
            this.Previous.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
            this.Previous.Font = new System.Drawing.Font("Arial", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.Previous.ImeMode = System.Windows.Forms.ImeMode.NoControl;
            this.Previous.Location = new System.Drawing.Point(79, 53);
            this.Previous.Name = "Previous";
            this.Previous.Size = new System.Drawing.Size(58, 25);
            this.Previous.TabIndex = 32;
            this.Previous.Text = "◄◄";
            this.Previous.UseVisualStyleBackColor = false;
            this.Previous.Click += new System.EventHandler(this.Previous_Click);
            // 
            // Play
            // 
            this.Play.BackColor = System.Drawing.SystemColors.Control;
            this.Play.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
            this.Play.Font = new System.Drawing.Font("Arial", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.Play.ImeMode = System.Windows.Forms.ImeMode.NoControl;
            this.Play.Location = new System.Drawing.Point(143, 53);
            this.Play.Name = "Play";
            this.Play.Size = new System.Drawing.Size(58, 25);
            this.Play.TabIndex = 31;
            this.Play.Text = "►";
            this.Play.UseVisualStyleBackColor = false;
            this.Play.Click += new System.EventHandler(this.Play_Click);
            // 
            // Next
            // 
            this.Next.BackColor = System.Drawing.SystemColors.Control;
            this.Next.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
            this.Next.Font = new System.Drawing.Font("Arial", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.Next.ForeColor = System.Drawing.SystemColors.ControlText;
            this.Next.ImeMode = System.Windows.Forms.ImeMode.NoControl;
            this.Next.Location = new System.Drawing.Point(207, 53);
            this.Next.Name = "Next";
            this.Next.Size = new System.Drawing.Size(58, 25);
            this.Next.TabIndex = 30;
            this.Next.Text = "►►";
            this.Next.UseVisualStyleBackColor = false;
            this.Next.Click += new System.EventHandler(this.Next_Click);
            // 
            // Bell
            // 
            this.Bell.BackColor = System.Drawing.SystemColors.Control;
            this.Bell.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
            this.Bell.Font = new System.Drawing.Font("Arial", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.Bell.Location = new System.Drawing.Point(15, 53);
            this.Bell.Name = "Bell";
            this.Bell.Size = new System.Drawing.Size(58, 25);
            this.Bell.TabIndex = 29;
            this.Bell.Text = "Звонок";
            this.Bell.UseVisualStyleBackColor = false;
            this.Bell.Click += new System.EventHandler(this.Bell_Click);
            // 
            // track_bell_volume
            // 
            this.track_bell_volume.LargeChange = 1;
            this.track_bell_volume.Location = new System.Drawing.Point(15, 135);
            this.track_bell_volume.Maximum = 100;
            this.track_bell_volume.Name = "track_bell_volume";
            this.track_bell_volume.RightToLeft = System.Windows.Forms.RightToLeft.No;
            this.track_bell_volume.Size = new System.Drawing.Size(107, 45);
            this.track_bell_volume.TabIndex = 28;
            this.track_bell_volume.TickStyle = System.Windows.Forms.TickStyle.Both;
            // 
            // track_music_volume
            // 
            this.track_music_volume.LargeChange = 1;
            this.track_music_volume.Location = new System.Drawing.Point(15, 187);
            this.track_music_volume.Maximum = 100;
            this.track_music_volume.Name = "track_music_volume";
            this.track_music_volume.Size = new System.Drawing.Size(107, 45);
            this.track_music_volume.TabIndex = 27;
            this.track_music_volume.TickStyle = System.Windows.Forms.TickStyle.Both;
            // 
            // label_time
            // 
            this.label_time.AutoSize = true;
            this.label_time.FlatStyle = System.Windows.Forms.FlatStyle.System;
            this.label_time.Font = new System.Drawing.Font("Arial", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.label_time.Location = new System.Drawing.Point(15, 24);
            this.label_time.Name = "label_time";
            this.label_time.Size = new System.Drawing.Size(131, 18);
            this.label_time.TabIndex = 26;
            this.label_time.Text = "Время:  00:00:00";
            // 
            // ListBell
            // 
            this.ListBell.BackColor = System.Drawing.SystemColors.Control;
            this.ListBell.Font = new System.Drawing.Font("Arial", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.ListBell.FormattingEnabled = true;
            this.ListBell.ItemHeight = 18;
            this.ListBell.Location = new System.Drawing.Point(6, 24);
            this.ListBell.Name = "ListBell";
            this.ListBell.RightToLeft = System.Windows.Forms.RightToLeft.No;
            this.ListBell.Size = new System.Drawing.Size(175, 220);
            this.ListBell.TabIndex = 37;
            // 
            // contextMenuStrip1
            // 
            this.contextMenuStrip1.Name = "contextMenuStrip1";
            this.contextMenuStrip1.Size = new System.Drawing.Size(61, 4);
            // 
            // AdsPanel
            // 
            this.AdsPanel.BackColor = System.Drawing.SystemColors.Control;
            this.AdsPanel.Controls.Add(this.ShowPanelButton2);
            this.AdsPanel.Controls.Add(this.groupBox3);
            this.AdsPanel.Location = new System.Drawing.Point(507, 0);
            this.AdsPanel.Name = "AdsPanel";
            this.AdsPanel.Size = new System.Drawing.Size(543, 270);
            this.AdsPanel.TabIndex = 41;
            // 
            // ShowPanelButton2
            // 
            this.ShowPanelButton2.BackColor = System.Drawing.SystemColors.Control;
            this.ShowPanelButton2.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
            this.ShowPanelButton2.Font = new System.Drawing.Font("Arial", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.ShowPanelButton2.Location = new System.Drawing.Point(0, 0);
            this.ShowPanelButton2.Name = "ShowPanelButton2";
            this.ShowPanelButton2.Size = new System.Drawing.Size(20, 270);
            this.ShowPanelButton2.TabIndex = 1;
            this.ShowPanelButton2.Text = "◄";
            this.ShowPanelButton2.UseVisualStyleBackColor = false;
            // 
            // groupBox3
            // 
            this.groupBox3.BackColor = System.Drawing.SystemColors.Control;
            this.groupBox3.Controls.Add(this.ListAds);
            this.groupBox3.Font = new System.Drawing.Font("Arial Narrow", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.groupBox3.Location = new System.Drawing.Point(20, 0);
            this.groupBox3.Name = "groupBox3";
            this.groupBox3.Size = new System.Drawing.Size(523, 270);
            this.groupBox3.TabIndex = 0;
            this.groupBox3.TabStop = false;
            this.groupBox3.Text = "Список объявлений";
            // 
            // ListAds
            // 
            this.ListAds.Font = new System.Drawing.Font("Arial", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.ListAds.FormattingEnabled = true;
            this.ListAds.ItemHeight = 16;
            this.ListAds.Location = new System.Drawing.Point(6, 24);
            this.ListAds.Name = "ListAds";
            this.ListAds.Size = new System.Drawing.Size(499, 228);
            this.ListAds.TabIndex = 0;
            // 
            // Settings
            // 
            this.Settings.BackColor = System.Drawing.SystemColors.Control;
            this.Settings.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
            this.Settings.Font = new System.Drawing.Font("Arial", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.Settings.Location = new System.Drawing.Point(143, 21);
            this.Settings.Name = "Settings";
            this.Settings.Size = new System.Drawing.Size(122, 25);
            this.Settings.TabIndex = 43;
            this.Settings.Text = "Настройки";
            this.Settings.UseVisualStyleBackColor = false;
            this.Settings.Click += new System.EventHandler(this.Settings_Click);
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.ListBell);
            this.groupBox1.Font = new System.Drawing.Font("Arial Narrow", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.groupBox1.Location = new System.Drawing.Point(26, 0);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(188, 263);
            this.groupBox1.TabIndex = 44;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "Расписание звонков";
            // 
            // groupBox4
            // 
            this.groupBox4.Controls.Add(this.Settings);
            this.groupBox4.Controls.Add(this.label_time);
            this.groupBox4.Controls.Add(this.track_music_volume);
            this.groupBox4.Controls.Add(this.track_bell_volume);
            this.groupBox4.Controls.Add(this.Bell);
            this.groupBox4.Controls.Add(this.Next);
            this.groupBox4.Controls.Add(this.PlayTrackBar);
            this.groupBox4.Controls.Add(this.Play);
            this.groupBox4.Controls.Add(this.label_music_volume);
            this.groupBox4.Controls.Add(this.Previous);
            this.groupBox4.Controls.Add(this.label_bell_volume);
            this.groupBox4.Font = new System.Drawing.Font("Arial Narrow", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.groupBox4.Location = new System.Drawing.Point(220, 0);
            this.groupBox4.Name = "groupBox4";
            this.groupBox4.Size = new System.Drawing.Size(281, 263);
            this.groupBox4.TabIndex = 45;
            this.groupBox4.TabStop = false;
            this.groupBox4.Text = "Управление";
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(527, 270);
            this.Controls.Add(this.groupBox4);
            this.Controls.Add(this.groupBox1);
            this.Controls.Add(this.AdsPanel);
            this.Controls.Add(this.ShowPanel1);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Name = "Form1";
            this.Text = "Авто Звонки";
            this.Load += new System.EventHandler(this.Form1_Load);
            this.ShowPanel1.ResumeLayout(false);
            this.groupBox2.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.PlayTrackBar)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.track_bell_volume)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.track_music_volume)).EndInit();
            this.AdsPanel.ResumeLayout(false);
            this.groupBox3.ResumeLayout(false);
            this.groupBox1.ResumeLayout(false);
            this.groupBox4.ResumeLayout(false);
            this.groupBox4.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Panel ShowPanel1;
        private System.Windows.Forms.Button ShowPanelButton1;
        private System.Windows.Forms.ListBox ListMusic;
        private System.Windows.Forms.TrackBar PlayTrackBar;
        private System.Windows.Forms.Label label_music_volume;
        private System.Windows.Forms.Label label_bell_volume;
        private System.Windows.Forms.Button Previous;
        private System.Windows.Forms.Button Play;
        private System.Windows.Forms.Button Next;
        private System.Windows.Forms.Button Bell;
        private System.Windows.Forms.TrackBar track_bell_volume;
        private System.Windows.Forms.TrackBar track_music_volume;
        private System.Windows.Forms.Label label_time;
        private System.Windows.Forms.ListBox ListBell;
        private System.Windows.Forms.GroupBox groupBox2;
        private System.Windows.Forms.ContextMenuStrip contextMenuStrip1;
        private System.Windows.Forms.Panel AdsPanel;
        private System.Windows.Forms.GroupBox groupBox3;
        private System.Windows.Forms.ListBox ListAds;
        private System.Windows.Forms.Button ShowPanelButton2;
        private System.Windows.Forms.Button Settings;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.GroupBox groupBox4;
    }
}

