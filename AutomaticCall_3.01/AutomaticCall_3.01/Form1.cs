using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Text;
using System.Windows.Forms;
using System.Windows.Media;

namespace AutomaticCall_3._01
{
    public partial class Form1 : Form
    {
        public MediaPlayer player = new MediaPlayer();
        public MediaPlayer player_bell = new MediaPlayer();
        System.Timers.Timer timer = new System.Timers.Timer(500);
        System.Timers.Timer timer_bell = new System.Timers.Timer(250);
        public float music_volume = 0.5F;
        public float bell_volume = 0.5F;
        public float music_speed = 1;
        private IniFile INI;
        static List<int> previous_call = new List<int>(); // для получения прошлых срабатываний звонка.
        static List<string> list_music = new List<string>(); // лист музыки.
        static List<string> list_ads = new List<string>(); // лист музыки.
        static List<string> list_bell = new List<string>(); // лист звонков
        // панели:
        static int DefaultLeftPanel0 = 0;
        static int DefaultTopPanel0 = 0;
        static bool button0_ = false;
        static int DefaultLeftPanel1 = 0;
        static int DefaultTopPanel1 = 0;
        static bool button1_ = false;

        public Form1()
        {
            InitializeComponent();

            this.FormBorderStyle = FormBorderStyle.FixedSingle;
            this.MaximizeBox = false;
            this.MinimizeBox = true;

            this.ListBell.DrawMode = DrawMode.OwnerDrawFixed;
            this.ListBell.SelectedIndexChanged += ((s, e) => { this.ListBell.Invalidate(); });
            this.ListBell.DrawItem += ((s, e) =>
            {
                int index = e.Index;
                Graphics g = e.Graphics;

                foreach (var item in previous_call)
                {
                    if (index == item)
                    {
                        e.DrawBackground();
                        g.FillRectangle(new SolidBrush(System.Drawing.Color.Yellow), e.Bounds);
                    }
                }

                foreach (int selectedIndex in this.ListBell.SelectedIndices)
                {
                    if (index == selectedIndex && index != -1)
                    {
                        e.DrawBackground();
                        g.FillRectangle(new SolidBrush(System.Drawing.Color.Gray), e.Bounds);
                    }
                }

                Font font = ListBell.Font;
                System.Drawing.Color colour = ListBell.ForeColor;
                string text = ListBell.Items[index].ToString();

                g.DrawString(text, font, new SolidBrush(System.Drawing.Color.Black), (float)e.Bounds.X, (float)e.Bounds.Y);
                e.DrawFocusRectangle();
            });


            //MessageBox.Show(Environment.CurrentDirectory + "/schedule/config.ini");
            INI = new IniFile(Environment.CurrentDirectory+"/schedule/config.ini");
            if (!Directory.Exists(Environment.CurrentDirectory + "/schedule"))
                Directory.CreateDirectory(Environment.CurrentDirectory + "/schedule");
            if (!File.Exists(Environment.CurrentDirectory+"/schedule/config.ini")) // исключение "нет файла конфигурации".
            {
                MessageBox.Show("Ошибка >> Файл config.ini не найден или недоступен, файл создан.");
                INI.Write("Settings", "music_dir", @"%cd%\music");
                INI.Write("Settings", "ads_dir", @"%cd%\ads");
                INI.Write("Settings", "bell_file", @"%cd%\bell.mp3");
                INI.Write("Settings", "interval_ads", "2");
                INI.Write("Volume", "bell_volume", (bell_volume) + "");
                INI.Write("Volume", "music_volume", (music_volume) + "");

                INI.Write("Bell", "1", "08:30:00-09:50:00");
                INI.Write("Bell", "2", "10:00:00-11:20:00");
                INI.Write("Bell", "3", "11:40:00-13:00:00");
                INI.Write("Bell", "4", "13:10:00-14:30:00");
                INI.Write("Bell", "5", "14:50:00-16:10:00");
                INI.Write("Bell", "6", "16:20:00-17:40:00");
            }





            track_music_volume.Value = (int)(music_volume * 100);
            track_bell_volume.Value = (int)(bell_volume * 100);
            track_music_speed.Value = (int)(music_speed * 100);
            label_music_volume.Text = "Громкость музыки: " + (track_music_volume.Value) + "%";
            label_bell_volume.Text = "Громкость звонка: " + (track_bell_volume.Value) + "%";
            label_music_speed.Text = "Скорость музыки: " + music_speed + "x";

            track_music_volume.Scroll += (sender1, e1) => // значение трекбара музыки.
            {
                music_volume = track_music_volume.Value / 100F;
                player.Volume = music_volume;
                label_music_volume.Text = "Громкость музыки: " + (track_music_volume.Value) + "%";
                //INI.Write("Volume", "music_volume", track_music_volume.Value + "");
            };
            track_bell_volume.Scroll += (sender1, e1) => // значение трекбара звонка.
            {
                player_bell.Volume = track_bell_volume.Value / 100F;
                bell_volume = track_bell_volume.Value / 100F;
                label_bell_volume.Text = "Громкость звонка: " + (track_bell_volume.Value) + "%";
                INI.Write("Volume", "bell_volume", track_bell_volume.Value + "");
            };
            track_music_speed.Scroll += (sender1, e1) => // значение трекбара музыки.
            {
                music_speed = track_music_speed.Value / 100F;
                player.SpeedRatio = music_speed;
                label_music_speed.Text = "Скорость музыки: " + music_speed + "x";
                //INI.Write("Volume", "music_volume", track_music_volume.Value + "");
            };


            Player("C:/Users/dns/Desktop/без названия.mp3", music_speed);

            PlayTrackBar.Scroll += (sender1, e1) => // значение трекбара музыки.
            {
                int value = (int)PlayTrackBar.Value;
                if (player.Position > TimeSpan.FromSeconds(value + 1) || player.Position < TimeSpan.FromSeconds(value - 1))
                    player.Position = TimeSpan.FromSeconds(value);
            };

            List<string> list_0 = new List<string>(); // лист звонков
            int indexNum = 1; // индекс в ListBox
            while (INI.Read("Bell", indexNum + "").Length > 0) // лист звонков.
            {
                string str = INI.Read("Bell", indexNum + "");
                string[] test11 = str.Split('-');
                list_0.Add("#" + indexNum + ": " + test11[0] + "-" + test11[1]);
                list_bell.Add(test11[0] + "-" + test11[1]);
                previous_call.Add(-1);
                indexNum++;
            }
            ListBell.Items.Clear();
            ListBell.Items.AddRange(list_0.ToArray());
            ListBell.SetSelected(0, true);

            timer.Start();
            timer.Elapsed += (sender1, e1) =>
            {
                try
                {
                    this.Invoke(new Action(() =>
                    {
                        label_time.Text = "Время: " + DateTime.Now.ToString("HH:mm:ss");
                        if (isPlay)
                        {
                            PlayTrackBar.Minimum = 0;
                            try
                            {
                                PlayTrackBar.Maximum = (int)player.NaturalDuration.TimeSpan.TotalSeconds;
                                PlayTrackBar.Value = (int)player.Position.TotalSeconds;
                            }
                            catch (Exception) { }
                        }

                        

                    }));
                }
                catch (Exception) { }
            };

            timer_bell.Elapsed += (sender, e) =>
            {
                try
                {
                    string currentTime = DateTime.Now.ToString("HH:mm:ss");
                    foreach (string item in list_bell)
                    {
                        string[] test11 = item.Split('-');
                        if (currentTime.Contains(test11[0]))
                        {
                            MessageBox.Show("Ошибка >> " + currentTime);
                            isPlay = false;
                            player.Pause();
                            Play.Invoke(new Action(() => { Play.Text = "►"; }));
                            Player_Bell(INI.Read("Settings", "bell_file").Replace("%cd%", Environment.CurrentDirectory), 1);
                            player_bell.Play();
                            System.Threading.Thread.Sleep((int)player_bell.NaturalDuration.TimeSpan.TotalMilliseconds);
                            int i = list_bell.IndexOf(item);
                            if (i + 1 < list_bell.Count)
                                ListBell.SetSelected(i, true);
                            previous_call[i] = i;
                            break;
                        }
                        else if (currentTime.Contains(test11[1]))
                        {
                            MessageBox.Show("Ошибка >> " + currentTime);
                            Player_Bell(INI.Read("Settings", "bell_file").Replace("%cd%", Environment.CurrentDirectory), 1);
                            player_bell.Play();
                            System.Threading.Thread.Sleep((int)player_bell.NaturalDuration.TimeSpan.TotalMilliseconds);
                            isPlay = true;
                            player.Play();
                            player.Volume = music_volume;
                            Play.Invoke(new Action(() => { Play.Text = "■"; }));
                            int i = list_bell.IndexOf(item);
                            if (i + 1 < list_bell.Count)
                                ListBell.SetSelected(i + 1, true);
                            previous_call[i] = i;
                            break;
                        }
                    }
                }
                catch (Exception) { }
            };
        }

        private List<string> Shuffle(List<string> musicList) // Тасовка плейлиста случайным образом.
        {
            Random RND = new Random();
            for (int i = 0; i < musicList.Count; i++)
            {
                string tmp = musicList[i];
                musicList.RemoveAt(i);
                musicList.Insert(RND.Next(musicList.Count), tmp);
            }
            return musicList;
        }

        private void Player(string path, float speedPlay)
        {
            player.MediaFailed += (s, e) => MessageBox.Show("Ошибка плеера: " + e);
            player.SpeedRatio = speedPlay;
            player.Open(new Uri(path, UriKind.RelativeOrAbsolute));
            //player.MediaEnded += (s, e) => Next_Play();
            player.Volume = 1.0f;
        }

        private void Player_Bell(string path, int speedPlay)
        {
            player_bell = new MediaPlayer();
            player_bell.MediaFailed += (s, e) => MessageBox.Show("Ошибка плеера: " + e);
            player_bell.SpeedRatio = speedPlay;
            player_bell.Open(new Uri(path, UriKind.RelativeOrAbsolute));
            player.MediaEnded += (s, e) => Player_Bell(INI.Read("Settings", "bell_file").Replace("%cd%", Environment.CurrentDirectory), 1);
            player_bell.Volume = bell_volume;
        }

        bool isPlay = false;
        private void Play_Click(object sender, EventArgs e)
        {
            if (!isPlay)
            {
                isPlay = true;
                player.Volume = music_volume;
                player.Play();
                Play.Invoke(new Action(() => { Play.Text = "■"; }));
            }
            else
            {
                isPlay = false;
                player.Pause();
                player.Volume = music_volume;
                Play.Invoke(new Action(() => { Play.Text = "►"; }));
            }
        }

        private void Next_Click(object sender, EventArgs e)
        {

        }

        private void Previous_Click(object sender, EventArgs e)
        {

        }

        private void Bell_Click(object sender, EventArgs e)
        {
            ///MessageBox.Show(INI.Read("Settings", "bell_file").Replace("%cd%", Environment.CurrentDirectory));
            Player_Bell(INI.Read("Settings", "bell_file").Replace("%cd%", Environment.CurrentDirectory), 1);
            player_bell.Play();
        }

        private void Settings_Click(object sender, EventArgs e)
        {

        }

        private void ShowPanelButton1_Click(object sender, EventArgs e)
        {

        }
    }
}
