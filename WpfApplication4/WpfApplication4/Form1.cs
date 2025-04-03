using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Windows.Media;
using System.Windows.Shapes;

namespace WpfApplication4
{
    public partial class Form1 : Form
    {
        // панели:
        static int DefaultLeftPanel0 = 0;
        static int DefaultTopPanel0 = 0;
        static bool button0_ = false;
        static int DefaultLeftPanel1 = 0;
        static int DefaultTopPanel1 = 0;
        static bool button1_ = false;

        MediaPlayer player;
        MediaPlayer player_bell;

        static IniFile INI; // файл конфигурации.
        static List<int> previous_call = new List<int>(); // для получения прошлых срабатываний звонка.
        static List<string> list_music = new List<string>(); // лист музыки.
        static List<string> list_ads = new List<string>(); // лист музыки.
        static List<string> list_ = new List<string>(); // лист звонков для проверки.
        static int index_music_list = 0; // индекс листа музыки для кнопок "◄◄" "►►".
        static int index_ads_list = 0; // индекс листа музыки для кнопок "◄◄" "►►".
        static int index_ads_play = 1; // индекс опереди объевлений.
        static float bell_volume = 1F; // базовая громкость звонка.
        static float music_volume = 1F; // базовая громкость музыки.
        static int interval_ads_play = 2; // интервал опереди объевлений.

        public Form1()
        {
            InitializeComponent();
            // графика
            this.FormBorderStyle = FormBorderStyle.FixedSingle;
            this.MaximizeBox = false;
            this.MinimizeBox = true;

            DefaultLeftPanel0 = ShowPanel1.Left;
            DefaultTopPanel0 = ShowPanel1.Top;
            HorizontalVerticalAnimationClass AnimationClassPanel1 = new HorizontalVerticalAnimationClass(ShowPanel1, DefaultLeftPanel0, DefaultTopPanel0);
            ShowPanelButton1.Click += (s_, e_) =>
            {
                ShowPanel1.BringToFront();
                if (button0_)
                {
                    button0_ = false;
                    AnimationClassPanel1.Open(DefaultLeftPanel0, DefaultTopPanel0);
                    ShowPanelButton1.Text = "►";
                }
                else
                {
                    button0_ = true;
                    AnimationClassPanel1.Open(0, DefaultTopPanel0);
                    ShowPanelButton1.Text = "◄";
                }
            };

            DefaultLeftPanel1 = AdsPanel.Left;
            DefaultTopPanel1 = AdsPanel.Top;
            HorizontalVerticalAnimationClass AnimationClassPanel2 = new HorizontalVerticalAnimationClass(AdsPanel, DefaultLeftPanel1, DefaultTopPanel1);
            ShowPanelButton2.Click += (s_, e_) =>
            {
                AdsPanel.BringToFront();
                if (button1_)
                {
                    button1_ = false;
                    AnimationClassPanel2.Open(DefaultLeftPanel1, DefaultTopPanel1);
                    ShowPanelButton2.Text = "◄";
                }
                else
                {
                    button1_ = true;
                    AnimationClassPanel2.Open(0, DefaultTopPanel1);
                    ShowPanelButton2.Text = "►";
                }
            };

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
        }

        private async void Form1_Load(object sender, EventArgs e)
        {
            //Player("D:\\--00\\Mike_Oldfield_-_Tricks_Of_The_Light_48390951.mp3", 1);
            //player.Play();

            // механика
            ListFiles.Items.Add("config.ini");
            for (int i = 0; i < 10; i++)
            {
                ListFiles.Items.Add("config.ini "+i);
            }
            INI = new IniFile("config.ini");
            if (!File.Exists("config.ini")) // исключение "нет файла конфигурации".
            {
                MessageBox.Show("Ошибка >> Файл config.ini не найден или недоступен, файл создан.");
                INI.Write("Settings", "music_dir", @"%cd%\music");
                INI.Write("Settings", "ads_dir", @"%cd%\ads");
                INI.Write("Settings", "bell_file", @"%cd%\bell.mp3");
                INI.Write("Settings", "interval_ads", "2");
                INI.Write("Volume", "bell_volume", (bell_volume * 50) + "");
                INI.Write("Volume", "music_volume", (music_volume * 50) + "");

                INI.Write("Bell", "1", "08:30:00-09:50:00");
                INI.Write("Bell", "2", "10:00:00-11:20:00");
                INI.Write("Bell", "3", "11:40:00-13:00:00");
                INI.Write("Bell", "4", "13:10:00-14:30:00");
                INI.Write("Bell", "5", "14:50:00-16:10:00");
                INI.Write("Bell", "6", "16:20:00-17:40:00");
            }
            if (!Directory.Exists(INI.Read("Settings", "music_dir").Replace("%cd%", Environment.CurrentDirectory))) // исключение "не найдена папка с музыкой".
            {
                MessageBox.Show("Ошибка: Не найдена папка(каталог) с музыкой. \nПуть:" + INI.Read("Settings", "music_dir").Replace("%cd%", Environment.CurrentDirectory));
                await SettingsOpen();
                await Task.Delay(5000);
                Application.Restart();
                //Process.GetCurrentProcess().Kill();
            }
            if (!Directory.Exists(INI.Read("Settings", "ads_dir").Replace("%cd%", Environment.CurrentDirectory))) // исключение "не найдена папка с объявлениями".
            {
                MessageBox.Show("Ошибка: Не найдена папка(каталог) с объявлениями. \nПуть:" + INI.Read("Settings", "ads_dir").Replace("%cd%", Environment.CurrentDirectory));
                await SettingsOpen();
                await Task.Delay(5000);
                Application.Restart();
                //Process.GetCurrentProcess().Kill();
            }
            if (!File.Exists(INI.Read("Settings", "bell_file").Replace("%cd%", Environment.CurrentDirectory))) // исключение "не найден файл звонка".
            {
                MessageBox.Show("Ошибка: Не найден файл звонка. \nПуть:" + INI.Read("Settings", "bell_file").Replace("%cd%", Environment.CurrentDirectory));
                await SettingsOpen();
                await Task.Delay(5000);
                Application.Restart();
                //Process.GetCurrentProcess().Kill();
            }

            

            List<string> list_0 = new List<string>(); // лист звонков
            int indexNum = 1; // индекс в ListBox
            while (INI.Read("Bell", indexNum + "").Length > 0) // лист звонков.
            {
                string str = INI.Read("Bell", indexNum + "");
                string[] test11 = str.Split('-');
                list_0.Add("" + indexNum + ": " + test11[0] + "-" + test11[1]);
                list_.Add(test11[0] + "-" + test11[1]);
                previous_call.Add(-1);
                indexNum++;
            }
            ListBell.Items.Clear();
            ListBell.Items.AddRange(list_0.ToArray());
            ListBell.SetSelected(0, true);



            if (INI.Read("Settings", "interval_ads").Length > 0) // установка значение трекбара музыки.
            {
                interval_ads_play = int.Parse(INI.Read("Settings", "interval_ads"));
            }
            else INI.Write("Settings", "interval_ads", "2");

            if (INI.Read("Volume", "music_volume").Length > 0) // установка значение трекбара музыки.
            {
                track_music_volume.Value = int.Parse(INI.Read("Volume", "music_volume"));
                label_music_volume.Text = "Громкость музыки: " + INI.Read("Volume", "music_volume") + "%";
                music_volume = track_music_volume.Value / 100F;
            }
            if (INI.Read("Volume", "bell_volume").Length > 0) // установка значение трекбара звонка.
            {
                track_bell_volume.Value = int.Parse(INI.Read("Volume", "bell_volume"));
                label_bell_volume.Text = "Громкость звонка: " + INI.Read("Volume", "bell_volume") + "%";
                bell_volume = track_bell_volume.Value / 100F;
            }

            track_music_volume.Scroll += (sender1, e1) => // значение трекбара музыки.
            {
                music_volume = track_music_volume.Value / 100F;
                player.Volume = music_volume;
                label_music_volume.Text = "Громкость музыки: " + (track_music_volume.Value) + "%";
                INI.Write("Volume", "music_volume", track_music_volume.Value + "");
            };

            track_bell_volume.Scroll += (sender1, e1) => // значение трекбара звонка.
            {
                player_bell.Volume = track_bell_volume.Value / 100F;
                bell_volume = track_bell_volume.Value / 100F;
                label_bell_volume.Text = "Громкость звонка: " + (track_bell_volume.Value) + "%";
                INI.Write("Volume", "bell_volume", track_bell_volume.Value + "");
            };

            //-->> загруска музыки из папки. 
            List<string> base_list = new List<string>();
            foreach (var item in Directory.GetFiles(INI.Read("Settings", "music_dir").Replace("%cd%", Environment.CurrentDirectory)).ToList())
                if (item.EndsWith(".mp3") || item.EndsWith(".wav") || item.EndsWith(".ogg") || item.EndsWith(".mp4") || item.EndsWith(".acc") || item.EndsWith(".flac") || item.EndsWith(".mid1"))
                    base_list.Add(item);
            list_music = Shuffle(base_list); //<<--

            //-->> загруска объектов из папки. 
            List<string> base_list1 = new List<string>();
            foreach (var item in Directory.GetFiles(INI.Read("Settings", "ads_dir").Replace("%cd%", Environment.CurrentDirectory)).ToList())
                if (item.EndsWith(".mp3") || item.EndsWith(".wav") || item.EndsWith(".ogg") || item.EndsWith(".mp4") || item.EndsWith(".acc") || item.EndsWith(".flac") || item.EndsWith(".mid1"))
                    base_list1.Add(item);
            list_ads = Shuffle(base_list1); //<<--

            if (list_music.Count < 1) // исключение "нечего играть (пусто)".
            {
                MessageBox.Show("Ошибка: Папка(каталог) с музыкой пуста. \nПуть:" + INI.Read("Settings", "music_dir").Replace("%cd%", Environment.CurrentDirectory));
                await SettingsOpen();
                await Task.Delay(5000);
                Application.Restart();
                //Process.GetCurrentProcess().Kill();
            }

            if (list_ads.Count < 1) // исключение "нечего играть (пусто)".
            {
                MessageBox.Show("Ошибка: Папка(каталог) с объявлениями пуста. \nПуть:" + INI.Read("Settings", "ads_dir").Replace("%cd%", Environment.CurrentDirectory));
                await SettingsOpen();
                await Task.Delay(5000);
                Application.Restart();
                //Process.GetCurrentProcess().Kill();
            }


            List<string> list_1 = new List<string>();
            for (int i = 0; i < list_music.Count; i++)
            {
                list_1.Add("" + (i + 1) + " " + System.IO.Path.GetFileName(list_music[i]));
            }
            ListMusic.Items.Clear();
            ListMusic.Items.AddRange(list_1.ToArray());
            ListMusic.HorizontalScrollbar = true;

            List<string> list_2 = new List<string>();
            for (int i = 0; i < list_ads.Count; i++)
            {
                list_2.Add("" + (i + 1) + " " + System.IO.Path.GetFileName(list_ads[i]));
            }
            ListAds.Items.Clear();
            ListAds.Items.AddRange(list_2.ToArray());
            ListAds.HorizontalScrollbar = true;


            ListMusic.SetSelected(index_music_list, true);
            Player(list_music[index_music_list], 1);
            Player_Bell(INI.Read("Settings", "bell_file").Replace("%cd%", Environment.CurrentDirectory), 1);
            RowPos();
            Timer();
            TimerTest();

            ListMusic.SelectedIndexChanged += (sender1, e1) => // клик по музыке.
            {
                if (ListMusic.SelectedItem != null)
                {
                    player.Pause();
                    player = null;
                    boolean = true;
                    index_music_list = ListMusic.SelectedIndex;
                    Player(list_music[index_music_list], 1);
                    //Player(list_music[index_music_list]);
                    //w_music.Play();
                    //w_music.Volume = music_volume;
                    Play.Invoke(new Action(() => { Play.Text = "■"; })); // ??????????????????????
                    this.Text = (index_music_list + 1) + "/" + list_music.Count;
                }
            };

            ListAds.SelectedIndexChanged += (sender1, e1) => // клик по распесанию.
            {
                if (ListAds.SelectedItem != null)
                {
                    player.Pause();
                    player = null;
                    boolean = true;
                    index_ads_list = ListAds.SelectedIndex;
                    Player(list_ads[index_ads_list], 1);
                    //w_music.Play();
                    //w_music.Volume = music_volume;
                    Play.Invoke(new Action(() => { Play.Text = "■"; }));
                    this.Text = (index_ads_list + 1) + "/" + list_ads.Count;
                }
            };

            boolean = false;
            Play.Text = "►";
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

        private async Task SettingsOpen()
        {
            Form2 form2 = new Form2();
            form2.SetThis(this);
            form2.Show();

            await GetTaskFromEvent(form2, "FormClosed");
        }
        public static Task<object> GetTaskFromEvent(object o, string evt)
        {
            if (o == null || evt == null) throw new ArgumentNullException("Arguments cannot be null");

            EventInfo einfo = o.GetType().GetEvent(evt);
            if (einfo == null)
            {
                throw new ArgumentException(String.Format("*{0}* has no *{1}* event", o, evt));
            }

            TaskCompletionSource<object> tcs = new TaskCompletionSource<object>();
            MethodInfo mi = null;
            Delegate deleg = null;
            EventHandler handler = null;

            //код обработчика события
            handler = (s, e) =>
            {
                mi = handler.Method;
                deleg = Delegate.CreateDelegate(einfo.EventHandlerType, handler.Target, mi);
                einfo.RemoveEventHandler(s, deleg); //отцепляем обработчик события
                tcs.TrySetResult(null); //сигнализируем о наступлении события
            };

            mi = handler.Method;
            deleg = Delegate.CreateDelegate(einfo.EventHandlerType, handler.Target, mi); //получаем делегат нужного типа
            einfo.AddEventHandler(o, deleg); //присоединяем обработчик события
            return tcs.Task;
        }

        private void Player(string path, int speedPlay)
        {
            player = new MediaPlayer();
            player.MediaFailed += (s, e) => MessageBox.Show("Ошибка плеера: " + e);
            player.SpeedRatio = speedPlay;
            player.Open(new Uri(path, UriKind.RelativeOrAbsolute));
            player.MediaEnded += (s, e) => Next_Play();
            player.Volume = music_volume;
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

        private void Play_Bell()
        {
            boolean = false;
            player.Pause();
            Play.Invoke(new Action(() => { Play.Text = "►"; }));
            player_bell.Stop();
            player_bell.Play();
        }

        async void RowPos()
        {
            if (player != null)
            {
                PlayTrackBar.Minimum = 0;
                try
                {
                    PlayTrackBar.Maximum = (int)player.NaturalDuration.TimeSpan.TotalSeconds;
                }
                catch (InvalidOperationException) { }

                try
                {
                    PlayTrackBar.Value = (int)player.Position.TotalSeconds;

                }
                catch (ArgumentOutOfRangeException) { }

                TimeSpan t = TimeSpan.FromSeconds((int)PlayTrackBar.Value);
                string displayTime = string.Format("{0:D2}:{1:D2}:{2:D2}",
                    (int)t.TotalHours,
                    t.Minutes,
                    t.Seconds,
                    t.Milliseconds);
                //trackBar1.Content = displayTime;

                TimeSpan t1 = TimeSpan.FromSeconds((int)PlayTrackBar.Maximum);
                string displayTime1 = string.Format("{0:D2}:{1:D2}:{2:D2}",
                    (int)t1.TotalHours,
                    t1.Minutes,
                    t1.Seconds,
                    t1.Milliseconds);
                //Total_Track_Length.Content = displayTime1;
            }
            await Task.Delay(1000);
            RowPos();
        }

        async void Timer()
        {
            label_time.Text = "Время: " + DateTime.Now.ToString("HH:mm:ss");
            /*
            try
            {
                double s = w_music.GetPosition() * 1000 / w_music.OutputWaveFormat.BitsPerSample / w_music.OutputWaveFormat.Channels * 8 / w_music.OutputWaveFormat.SampleRate;
                TimeSpan interval = r_bell.TotalTime;
                TimeSpan intervalPos = TimeSpan.Parse(s / 60 + "");
                Text = intervalPos.ToString() + "|" + interval.ToString();
            } catch (NAudio.MmException) { }
            */
            await Task.Delay(1000);
            Timer();
        }

        async void TimerTest()
        {
            for (int i = 0; i < list_.Count; i++)
            {
                string item = list_[i];
                string[] test11 = item.Split('-');
                if (DateTime.Now.ToString("HH:mm:ss").Contains(test11[0]))
                {
                    boolean = false;
                    player.Pause();
                    Play.Invoke(new Action(() => { Play.Text = "►"; }));
                    //Bell_Start();
                    Play_Bell();
                    await Task.Delay((int)player_bell.NaturalDuration.TimeSpan.TotalMilliseconds);
                    if (i + 1 < list_.Count)
                        ListBell.SetSelected(i, true);
                    //previous_call = i + 1;
                    previous_call[i] = i;
                    break;
                }
                if (DateTime.Now.ToString("HH:mm:ss").Contains(test11[1]))
                {
                    Play_Bell();
                    await Task.Delay((int)player_bell.NaturalDuration.TimeSpan.TotalMilliseconds);
                    //w_bell.Stop();
                    boolean = true;
                    player.Play();
                    player.Volume = music_volume;
                    Play.Invoke(new Action(() => { Play.Text = "■"; }));
                    ListBell.SetSelected(i + 1, true);
                    //previous_call = i + 1;
                    previous_call[i] = i;
                    break;
                }
            }
            await Task.Delay(250);
            TimerTest();
        }

        static bool boolean = false; // память значений "►" <-> "■".
        private void Music_Start() // старт, пауза "►" <-> "■".
        {
            if (!boolean)
            {
                boolean = true;
                player.Volume = music_volume;
                player.Play();
                Play.Invoke(new Action(() => { Play.Text = "■"; }));
            }
            else
            {
                boolean = false;
                player.Pause();
                player.Volume = music_volume;
                Play.Invoke(new Action(() => { Play.Text = "►"; }));
            }
        }

        private void PlayTrackBar_Scroll(object sender, EventArgs e)
        {
            int value = (int)PlayTrackBar.Value;
            if (player.Position > TimeSpan.FromSeconds(value + 1) || player.Position < TimeSpan.FromSeconds(value - 1))
                player.Position = TimeSpan.FromSeconds(value);
        }
        private void Next_Play()
        {
            if (index_music_list < list_music.Count)
            {
                if (index_music_list < list_music.Count - 1)
                    index_music_list++;
                else
                    index_music_list = 0;
                if (index_ads_play < interval_ads_play)
                {
                    index_ads_play++;
                    ListMusic.SetSelected(index_music_list, true);
                }
                else
                {
                    index_ads_play = 0;
                    ListAds.SetSelected(index_ads_list, true);

                    if (index_ads_list < list_ads.Count - 1)
                        index_ads_list++;
                    else
                        index_ads_list = 0;
                }
                player.Play();
                player.Volume = music_volume;
                Play.Invoke(new Action(() => { Play.Text = "■"; }));
            }
        }
        private void Previous_Play()
        {
            if (index_music_list > -1)
            {
                if (index_music_list > 0)
                    index_music_list--;
                else
                    index_music_list = list_music.Count - 1;
                ListMusic.SetSelected(index_music_list, true);

                player.Play();
                player.Volume = music_volume;
                Play.Invoke(new Action(() => { Play.Text = "■"; }));
            }
        }

        private void Settings_Click(object sender, System.EventArgs e)
        {
            SettingsOpen();
            //throw new System.NotImplementedException();
        }

        private void Bell_Click(object sender, System.EventArgs e)
        {
            Play_Bell();
            //throw new System.NotImplementedException();
        }

        private void Next_Click(object sender, System.EventArgs e)
        {
            Next_Play();
            //throw new System.NotImplementedException();
        }

        private void Play_Click(object sender, System.EventArgs e)
        {
            Music_Start();
            //throw new System.NotImplementedException();
        }

        private void Previous_Click(object sender, System.EventArgs e)
        {
            Previous_Play();
            //throw new System.NotImplementedException();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            Form1_Load(null, null);
        }
    }
}
