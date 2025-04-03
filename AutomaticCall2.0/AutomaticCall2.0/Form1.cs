using NAudio.Wave;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Diagnostics;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace AutomaticCall2._0
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        // панели:
        static int DefaultLeftPanel0 = 0;
        static int DefaultTopPanel0 = 0;
        static bool button0_ = false;
        static int DefaultLeftPanel1 = 0;
        static int DefaultTopPanel1 = 0;
        static bool button1_ = false;

        //static int previous_call = 0; // для получения прошлых срабатываний звонка.
        static List<int> previous_call = new List<int>(); // для получения прошлых срабатываний звонка.

        static IniFile INI; // файл конфигурации.
        static List<string> list_music = new List<string>(); // лист музыки.
        static List<string> list_ads = new List<string>(); // лист музыки.
        static List<string> list_ = new List<string>(); // лист звонков для проверки.
        static int index_music_list = 0; // индекс листа музыки для кнопок "◄◄" "►►".
        static int index_ads_list = 0; // индекс листа музыки для кнопок "◄◄" "►►".
        static int index_ads_play = 1; // индекс опереди объевлений.
        static float bell_volume = 1F; // базовая громкость звонка.
        static float music_volume = 1F; // базовая громкость музыки.
        static int interval_ads_play = 2; // интервал опереди объевлений.

        private void Form1_Load(object sender_main, EventArgs e_main)
        {
            Load_();
        }

        public async void Load_()
        {

            // графика
            this.FormBorderStyle = FormBorderStyle.FixedSingle;
            this.MaximizeBox = false;
            this.MinimizeBox = true;

            //this.ListBell.Enabled = false;
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
                        g.FillRectangle(new SolidBrush(Color.Yellow), e.Bounds);
                    }
                }

                foreach (int selectedIndex in this.ListBell.SelectedIndices)
                {
                    if (index == selectedIndex && index != -1)
                    {
                        e.DrawBackground();
                        g.FillRectangle(new SolidBrush(Color.Gray), e.Bounds);
                    }
                }

                Font font = ListBell.Font;
                Color colour = ListBell.ForeColor;
                string text = ListBell.Items[index].ToString();

                g.DrawString(text, font, new SolidBrush(Color.Black), (float)e.Bounds.X, (float)e.Bounds.Y);
                e.DrawFocusRectangle();
            });

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

            // механика
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
                if (w_music.PlaybackState == PlaybackState.Playing)
                    w_music.Volume = track_music_volume.Value / 100F;
                music_volume = track_music_volume.Value / 100F;
                label_music_volume.Text = "Громкость музыки: " + (track_music_volume.Value) + "%";
                INI.Write("Volume", "music_volume", track_music_volume.Value + "");
            };

            track_bell_volume.Scroll += (sender1, e1) => // значение трекбара звонка.
            {
                if (w_bell.PlaybackState == PlaybackState.Playing)
                    w_bell.Volume = track_bell_volume.Value / 100F;
                bell_volume = track_bell_volume.Value / 100F;
                label_bell_volume.Text = "Громкость звонка: " + (track_bell_volume.Value) + "%";
                INI.Write("Volume", "bell_volume", track_bell_volume.Value + "");
            };

            //-->> загруска музыки из папки. 
            List<string> base_list = new List<string>();
            foreach (var item in Directory.GetFiles(INI.Read("Settings", "music_dir").Replace("%cd%", Environment.CurrentDirectory)).ToList())
                if (item.EndsWith(".mp3"))
                    base_list.Add(item);
            list_music = Shuffle(base_list); //<<--

            //-->> загруска объектов из папки. 
            List<string> base_list1 = new List<string>();
            foreach (var item in Directory.GetFiles(INI.Read("Settings", "ads_dir").Replace("%cd%", Environment.CurrentDirectory)).ToList())
                if (item.EndsWith(".mp3"))
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
                list_1.Add("" + (i + 1) + " " + Path.GetFileName(list_music[i]));
            }
            ListMusic.Items.Clear();
            ListMusic.Items.AddRange(list_1.ToArray());
            ListMusic.HorizontalScrollbar = true;

            List<string> list_2 = new List<string>();
            for (int i = 0; i < list_ads.Count; i++)
            {
                list_2.Add("" + (i + 1) + " " + Path.GetFileName(list_ads[i]));
            }
            ListAds.Items.Clear();
            ListAds.Items.AddRange(list_2.ToArray());
            ListAds.HorizontalScrollbar = true;


            Create_Bell();
            PosTrack();
            PlayTrackBar.Scroll += (sender1, e1) => // значение трекбара позиции музыки.
            {
                if (w_music.PlaybackState == PlaybackState.Playing || w_music.PlaybackState == PlaybackState.Paused)
                {
                    double ms = PlayTrackBar.Value * 1000.0 / 4.0;
                    r_music.Position = (long)(ms * w_music.OutputWaveFormat.SampleRate * w_music.OutputWaveFormat.BitsPerSample * w_music.OutputWaveFormat.Channels / 8000.0) & ~1;
                }
            };
            Timer();
            TimerTest();
            ListMusic.SetSelected(index_music_list, true);
            Player(list_music[index_music_list]);

            ListMusic.SelectedIndexChanged += (sender1, e1) => // клик по музыке.
            {
                if (ListMusic.SelectedItem != null)
                {
                    w_music.Pause();
                    w_music = null;
                    boolean = true;
                    index_music_list = ListMusic.SelectedIndex;
                    Player(list_music[index_music_list]);
                    w_music.Play();
                    w_music.Volume = music_volume;
                    Play.Invoke(new Action(() => { Play.Text = "■"; }));
                    this.Text = (index_music_list + 1) + "/" + list_music.Count;
                }
            };

            ListAds.SelectedIndexChanged += (sender1, e1) => // клик по распесанию.
            {
                if (ListAds.SelectedItem != null)
                {
                    w_music.Pause();
                    w_music = null;
                    boolean = true;
                    index_ads_list = ListAds.SelectedIndex;
                    Player(list_ads[index_ads_list]);
                    w_music.Play();
                    w_music.Volume = music_volume;
                    Play.Invoke(new Action(() => { Play.Text = "■"; }));
                    this.Text = (index_ads_list + 1) + "/" + list_ads.Count;
                }
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
                    w_music.Pause();
                    Play.Invoke(new Action(() => { Play.Text = "►"; }));
                    Bell_Start();
                    if (i + 1 < list_.Count)
                        ListBell.SetSelected(i + 1, true);
                    //previous_call = i + 1;
                    previous_call[i] = i;
                    break;
                }
                if (DateTime.Now.ToString("HH:mm:ss").Contains(test11[1]))
                {
                    TimeSpan interval = r_bell.TotalTime;
                    Bell_Start();
                    await Task.Delay((int)interval.TotalMilliseconds);
                    w_bell.Stop();
                    boolean = true;
                    w_music.Play();
                    w_music.Volume = music_volume;
                    Play.Invoke(new Action(() => { Play.Text = "■"; }));
                    ListBell.SetSelected(i, true);
                    //previous_call = i + 1;
                    previous_call[i] = i;
                    break;
                }
            }
            await Task.Delay(1000);
            TimerTest();
        }
        async void PosTrack()
        {
            try
            {
                if (w_music.PlaybackState == PlaybackState.Playing)
                {
                    PlayTrackBar.Maximum = (int)(r_music.TotalTime.TotalSeconds) * 4;
                    double ms = r_music.Position * 1000.0 / w_music.OutputWaveFormat.BitsPerSample / w_music.OutputWaveFormat.Channels * 8.0 / w_music.OutputWaveFormat.SampleRate;
                    PlayTrackBar.Value = (int)(4 * ms / 1000);

                    //this.Text = (index_music_list + 1) + "/" + list_music.Count + " >> " + ((int)(4 * ms / 1000)) + "/" + ((int)(r_music.TotalTime.TotalSeconds + 1) * 4); // позиция на треке.
                    //ListMusic.SetSelected(index_music_list, true);

                }
            }
            catch (ArgumentOutOfRangeException) { }
            await Task.Delay(1000);
            PosTrack();
        }


        static WaveOut w_music = new WaveOut();
        static Mp3FileReader r_music;
        private void Player(String file_path) // плеер "►".
        {
            w_music = new WaveOut();
            r_music = new Mp3FileReader(file_path);
            try
            {
                w_music.Volume = music_volume;
                w_music.Init(r_music);
            }
            catch (NAudio.MmException ee)
            {
                MessageBox.Show("Аудио устройства воспроизведения отсутствуют: \n" + ee.ToString());
                Process.GetCurrentProcess().Kill();
            }

            w_music.PlaybackStopped += (s11, e11) => // следущий треек.
            {
                Next_Play();
            };
        }

        WaveOut w_bell = new WaveOut();
        Mp3FileReader r_bell;
        private void Create_Bell() // создать звонок.
        {
            r_bell = new Mp3FileReader(INI.Read("Settings", "bell_file").Replace("%cd%", Environment.CurrentDirectory));
            try
            {
                w_bell.Volume = bell_volume;
                w_bell.Init(r_bell);
            }
            catch (NAudio.MmException ee)
            {
                MessageBox.Show("Аудио устройства воспроизведения отсутствуют: \n" + ee.ToString());
                Process.GetCurrentProcess().Kill();
            }
        }

        static bool boolean = false; // память значений "►" <-> "■".
        private void Music_Start() // старт, пауза "►" <-> "■".
        {
            if (!boolean)
            {
                boolean = true;
                w_music.Play();
                w_music.Volume = music_volume;
                Play.Invoke(new Action(() => { Play.Text = "■"; }));
            }
            else
            {
                boolean = false;
                w_music.Pause();
                Play.Invoke(new Action(() => { Play.Text = "►"; }));
            }
        }
        private void Bell_Start() // старт звонка.
        {
            if (w_music.PlaybackState == PlaybackState.Playing)
            {
                boolean = false;
                w_music.Pause();
                Play.Invoke(new Action(() => { Play.Text = "►"; }));
            }
            w_bell.Stop();
            Create_Bell();
            w_bell.Play();
        }

        private void Next_Play()
        {
            if (index_music_list < list_music.Count)
            {
                //w_music.Pause();
                //w_music = null;
                //boolean = true;

                if (index_music_list < list_music.Count - 1)
                    index_music_list++;
                else
                    index_music_list = 0;
                //Player(list_music[index_music_list]);
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

                w_music.Play();
                w_music.Volume = music_volume;
                Play.Invoke(new Action(() => { Play.Text = "■"; }));
            }
            //throw new NotImplementedException();
        }
        private void Previous_Play()
        {
            if (index_music_list > -1)
            {
                //w_music.Pause();
                //w_music = null;
                //boolean = true;

                if (index_music_list > 0)
                    index_music_list--;
                else
                    index_music_list = list_music.Count - 1;
                //Player(list_music[index_music_list]);
                ListMusic.SetSelected(index_music_list, true);
                /*
                if (index_ads_play > interval_ads_play)
                {
                    index_ads_play--;
                    ListMusic.SetSelected(index_music_list, true);
                }
                else
                {
                    index_ads_play = interval_ads_play;
                    ListAds.SetSelected(index_ads_list, true);

                    if (index_ads_list > list_ads.Count - 1)
                        index_ads_list--;
                    else
                        index_ads_list = interval_ads_play;
                }
                 */

                w_music.Play();
                w_music.Volume = music_volume;
                Play.Invoke(new Action(() => { Play.Text = "■"; }));
            }
            //throw new NotImplementedException();
        }

        private void Bell_Click(object sender, EventArgs e)
        {
            Bell_Start();
        }

        private void Previous_Click(object sender, EventArgs e)
        {
            Previous_Play();
        }

        private void Play_Click(object sender, EventArgs e)
        {
            Music_Start();
        }

        private void Next_Click(object sender, EventArgs e)
        {
            Next_Play();
        }

        private void Settings_Click(object sender, EventArgs e)
        {
            SettingsOpen();
        }

        async Task SettingsOpen()
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
    }
}
