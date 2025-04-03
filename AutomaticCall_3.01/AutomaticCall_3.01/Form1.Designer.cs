namespace AutomaticCall_3._01
{
    partial class Form1
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
            this.groupBox4 = new System.Windows.Forms.GroupBox();
            this.track_music_speed = new System.Windows.Forms.TrackBar();
            this.label_music_speed = new System.Windows.Forms.Label();
            this.Settings = new System.Windows.Forms.Button();
            this.label_time = new System.Windows.Forms.Label();
            this.track_bell_volume = new System.Windows.Forms.TrackBar();
            this.track_music_volume = new System.Windows.Forms.TrackBar();
            this.Bell = new System.Windows.Forms.Button();
            this.Next = new System.Windows.Forms.Button();
            this.PlayTrackBar = new System.Windows.Forms.TrackBar();
            this.Play = new System.Windows.Forms.Button();
            this.label_bell_volume = new System.Windows.Forms.Label();
            this.Previous = new System.Windows.Forms.Button();
            this.label_music_volume = new System.Windows.Forms.Label();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.comboBox1 = new System.Windows.Forms.ComboBox();
            this.ListBell = new System.Windows.Forms.ListBox();
            this.groupBox4.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.track_music_speed)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.track_bell_volume)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.track_music_volume)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.PlayTrackBar)).BeginInit();
            this.groupBox1.SuspendLayout();
            this.SuspendLayout();
            // 
            // groupBox4
            // 
            this.groupBox4.Controls.Add(this.track_music_speed);
            this.groupBox4.Controls.Add(this.label_music_speed);
            this.groupBox4.Controls.Add(this.Settings);
            this.groupBox4.Controls.Add(this.label_time);
            this.groupBox4.Controls.Add(this.track_bell_volume);
            this.groupBox4.Controls.Add(this.track_music_volume);
            this.groupBox4.Controls.Add(this.Bell);
            this.groupBox4.Controls.Add(this.Next);
            this.groupBox4.Controls.Add(this.PlayTrackBar);
            this.groupBox4.Controls.Add(this.Play);
            this.groupBox4.Controls.Add(this.label_bell_volume);
            this.groupBox4.Controls.Add(this.Previous);
            this.groupBox4.Controls.Add(this.label_music_volume);
            this.groupBox4.Font = new System.Drawing.Font("Arial Narrow", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.groupBox4.Location = new System.Drawing.Point(775, 12);
            this.groupBox4.Name = "groupBox4";
            this.groupBox4.Size = new System.Drawing.Size(281, 284);
            this.groupBox4.TabIndex = 46;
            this.groupBox4.TabStop = false;
            this.groupBox4.Text = "Управление";
            // 
            // track_music_speed
            // 
            this.track_music_speed.LargeChange = 1;
            this.track_music_speed.Location = new System.Drawing.Point(14, 134);
            this.track_music_speed.Maximum = 400;
            this.track_music_speed.Name = "track_music_speed";
            this.track_music_speed.RightToLeft = System.Windows.Forms.RightToLeft.No;
            this.track_music_speed.Size = new System.Drawing.Size(107, 45);
            this.track_music_speed.TabIndex = 44;
            this.track_music_speed.TickStyle = System.Windows.Forms.TickStyle.Both;
            // 
            // label_music_speed
            // 
            this.label_music_speed.AutoSize = true;
            this.label_music_speed.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.label_music_speed.ImeMode = System.Windows.Forms.ImeMode.NoControl;
            this.label_music_speed.Location = new System.Drawing.Point(127, 148);
            this.label_music_speed.Name = "label_music_speed";
            this.label_music_speed.Size = new System.Drawing.Size(136, 15);
            this.label_music_speed.TabIndex = 45;
            this.label_music_speed.Text = "Скорость музыки: 0.0x";
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
            // track_bell_volume
            // 
            this.track_bell_volume.LargeChange = 1;
            this.track_bell_volume.Location = new System.Drawing.Point(14, 237);
            this.track_bell_volume.Maximum = 100;
            this.track_bell_volume.Name = "track_bell_volume";
            this.track_bell_volume.Size = new System.Drawing.Size(107, 45);
            this.track_bell_volume.TabIndex = 27;
            this.track_bell_volume.TickStyle = System.Windows.Forms.TickStyle.Both;
            // 
            // track_music_volume
            // 
            this.track_music_volume.LargeChange = 1;
            this.track_music_volume.Location = new System.Drawing.Point(14, 185);
            this.track_music_volume.Maximum = 100;
            this.track_music_volume.Name = "track_music_volume";
            this.track_music_volume.RightToLeft = System.Windows.Forms.RightToLeft.No;
            this.track_music_volume.Size = new System.Drawing.Size(107, 45);
            this.track_music_volume.TabIndex = 28;
            this.track_music_volume.TickStyle = System.Windows.Forms.TickStyle.Both;
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
            // PlayTrackBar
            // 
            this.PlayTrackBar.Location = new System.Drawing.Point(15, 85);
            this.PlayTrackBar.Maximum = 10000;
            this.PlayTrackBar.Name = "PlayTrackBar";
            this.PlayTrackBar.Size = new System.Drawing.Size(252, 45);
            this.PlayTrackBar.TabIndex = 36;
            this.PlayTrackBar.TickStyle = System.Windows.Forms.TickStyle.Both;
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
            // label_bell_volume
            // 
            this.label_bell_volume.AutoSize = true;
            this.label_bell_volume.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.label_bell_volume.Location = new System.Drawing.Point(127, 249);
            this.label_bell_volume.Name = "label_bell_volume";
            this.label_bell_volume.Size = new System.Drawing.Size(137, 15);
            this.label_bell_volume.TabIndex = 34;
            this.label_bell_volume.Text = "Громкость звонка: 0%";
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
            // label_music_volume
            // 
            this.label_music_volume.AutoSize = true;
            this.label_music_volume.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.label_music_volume.ImeMode = System.Windows.Forms.ImeMode.NoControl;
            this.label_music_volume.Location = new System.Drawing.Point(127, 199);
            this.label_music_volume.Name = "label_music_volume";
            this.label_music_volume.Size = new System.Drawing.Size(139, 15);
            this.label_music_volume.TabIndex = 33;
            this.label_music_volume.Text = "Громкость музыки: 0%";
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.comboBox1);
            this.groupBox1.Controls.Add(this.ListBell);
            this.groupBox1.Font = new System.Drawing.Font("Arial Narrow", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.groupBox1.Location = new System.Drawing.Point(565, 13);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(188, 263);
            this.groupBox1.TabIndex = 47;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "Расписание звонков";
            // 
            // comboBox1
            // 
            this.comboBox1.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.comboBox1.FormattingEnabled = true;
            this.comboBox1.Items.AddRange(new object[] {
            "12",
            "12121"});
            this.comboBox1.Location = new System.Drawing.Point(6, 21);
            this.comboBox1.Name = "comboBox1";
            this.comboBox1.Size = new System.Drawing.Size(175, 28);
            this.comboBox1.TabIndex = 38;
            // 
            // ListBell
            // 
            this.ListBell.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.ListBell.BackColor = System.Drawing.SystemColors.Control;
            this.ListBell.Font = new System.Drawing.Font("Arial", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.ListBell.FormattingEnabled = true;
            this.ListBell.ItemHeight = 18;
            this.ListBell.Location = new System.Drawing.Point(6, 66);
            this.ListBell.Name = "ListBell";
            this.ListBell.RightToLeft = System.Windows.Forms.RightToLeft.No;
            this.ListBell.Size = new System.Drawing.Size(175, 184);
            this.ListBell.TabIndex = 37;
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1224, 375);
            this.Controls.Add(this.groupBox1);
            this.Controls.Add(this.groupBox4);
            this.Name = "Form1";
            this.Text = "Form1";
            this.groupBox4.ResumeLayout(false);
            this.groupBox4.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.track_music_speed)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.track_bell_volume)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.track_music_volume)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.PlayTrackBar)).EndInit();
            this.groupBox1.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.GroupBox groupBox4;
        private System.Windows.Forms.Button Settings;
        private System.Windows.Forms.Label label_time;
        private System.Windows.Forms.TrackBar track_bell_volume;
        private System.Windows.Forms.TrackBar track_music_volume;
        private System.Windows.Forms.Button Bell;
        private System.Windows.Forms.Button Next;
        private System.Windows.Forms.TrackBar PlayTrackBar;
        private System.Windows.Forms.Button Play;
        private System.Windows.Forms.Label label_bell_volume;
        private System.Windows.Forms.Button Previous;
        private System.Windows.Forms.Label label_music_volume;
        private System.Windows.Forms.TrackBar track_music_speed;
        private System.Windows.Forms.Label label_music_speed;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.ListBox ListBell;
        private System.Windows.Forms.ComboBox comboBox1;
    }
}