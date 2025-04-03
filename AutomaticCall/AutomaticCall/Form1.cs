using NAudio.Wave;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Diagnostics;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace AutomaticCall
{
    public partial class Form1 : Form
    {
        IniFile INI; // файл конфигурации.
        List<string> list_ = new List<string>(); // лист звонков для проверки.
        List<string> list_music = new List<string>(); // лист музыки.
        //List<int> list_music_num = new List<int>(); // лист значений для кнопок "◄◄" "►►".
        static float bell_volume = 1F; // базовая громкость звонка.
        static float music_volume = 1F; // базовая громкость музыки.
        //Random random = new Random(); // класс рандом для музыки.
        int index_music_list = 0; // индекс листа музыки для кнопок "◄◄" "►►".
        //int index_music_revious = 0; // индекс листа для кнопки "◄◄".

        public Form1() // точка в хода.
        {
            // --> Окно со стотичным размером.
            this.FormBorderStyle = FormBorderStyle.FixedSingle;
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            //this.AutoSize = true; // не нужен
            this.AutoSizeMode = AutoSizeMode.GrowAndShrink;
            //this.MinimumSize = new System.Drawing.Size(this.Width, this.Height);
            //this.MaximumSize = new System.Drawing.Size(Screen.PrimaryScreen.Bounds.Width, Screen.PrimaryScreen.Bounds.Height);
            // <--
            InitializeComponent();
        }


        private void Form1_Load(object sender, EventArgs e)
        {
            INI = new IniFile("config.ini");
            if (!File.Exists("config.ini")) // исключение "нет файла конфигурации".
            {
                MessageBox.Show("Ошибка >> Файл config.ini не найден или недоступен, файл создан.");
                INI.Write("Settings", "music_dir", @"%cd%\music");
                INI.Write("Settings", "bell_file", @"%cd%\bell.mp3");
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
                MessageBox.Show("" + INI.Read("Settings", "music_dir").Replace("%cd%", Environment.CurrentDirectory) + "\nОшибка в config.ini >> Объект не найден или недоступен.");
                Process.GetCurrentProcess().Kill();
            }
            if (!File.Exists("" + INI.Read("Settings", "bell_file").Replace("%cd%", Environment.CurrentDirectory))) // исключение "не найден файл звонка".
            {
                MessageBox.Show("" + INI.Read("Settings", "bell_file").Replace("%cd%", Environment.CurrentDirectory) + "\nОшибка в config.ini >> Объект не найден или недоступен.");
                Process.GetCurrentProcess().Kill();
            }

            Create_Bell();
            SetListStart();
            EventStart();

            Player(list_music[index_music_list]);
            this.Text = (index_music_list + 1) + "/" + list_music.Count; // позиция на треке.
            test();
        }

        void test()
        {
            Timer timer0 = new Timer() { Interval = 1000 /* interval - zaderzhka v miliseconds peredd vipolneniem*/ };
            timer0.Tick += (sender1, e1) =>
            {
                if (w_music.PlaybackState == PlaybackState.Playing)
                {
                    PlayTrackBar.Maximum = (int)(r_music.TotalTime.TotalSeconds + 10) * 4;
                    double ms = r_music.Position * 1000.0 / w_music.OutputWaveFormat.BitsPerSample / w_music.OutputWaveFormat.Channels * 8.0 / w_music.OutputWaveFormat.SampleRate;
                    PlayTrackBar.Value = (int)(4 * ms / 1000);

                    this.Text = (index_music_list + 1) + "/" + list_music.Count + " >> " + ((int)(4 * ms / 1000)) + "/" + ((int)(r_music.TotalTime.TotalSeconds + 1) * 4); // позиция на треке.
                    //ListMusic.SetSelected(index_music_list, true);
                }
            };
            timer0.Start();

            PlayTrackBar.Scroll += (sender1, e1) => // значение трекбара позиции музыки.
            {
                if (w_music.PlaybackState == PlaybackState.Playing || w_music.PlaybackState == PlaybackState.Paused)
                {
                    double ms = PlayTrackBar.Value * 1000.0 / 4.0;
                    r_music.Position = (long)(ms * w_music.OutputWaveFormat.SampleRate * w_music.OutputWaveFormat.BitsPerSample * w_music.OutputWaveFormat.Channels / 8000.0) & ~1;
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

        private void SetListStart() // працедура старта.
        {
            INI = new IniFile("config.ini");
            list_ = new List<string>();
            list_music = new List<string>();
            bell_volume = 1F;
            music_volume = 1F;

            //-->> загруска музыки из папки. 
            List<string> base_list = new List<string>();
            foreach (var item in Directory.GetFiles(INI.Read("Settings", "music_dir").Replace("%cd%", Environment.CurrentDirectory)).ToList())
                if (item.EndsWith(".mp3"))
                    base_list.Add(item);
            list_music = Shuffle(base_list); //<<--
            //Player(@"D:\--00\Amante_-_Be_My_Delight_70420843.mp3"); // для теста.
            
            if (list_music.Count < 1) // исключение "нечего играть (пусто)".
            {
                MessageBox.Show(INI.Read("Settings", "music_dir").Replace("%cd%", Environment.CurrentDirectory) + "\nОшибка в config.ini >> Объект пуст или недоступен.");
                Process.GetCurrentProcess().Kill();
            }

            List<string> list_0 = new List<string>(); // лист звонков
            int indexNum = 1; // индекс в ListBox
            while (INI.Read("Bell", indexNum + "").Length > 0) // лист звонков.
            {
                string str = INI.Read("Bell", indexNum + "");
                string[] test11 = str.Split('-');
                list_0.Add("№" + indexNum + ": " + test11[0] + "-" + test11[1]);
                list_.Add(test11[0] + "-" + test11[1]);
                indexNum++;
            }
            ListBell.Items.Clear();
            ListBell.Items.AddRange(list_0.ToArray());
            ListMusic.HorizontalScrollbar = true;

            List<string> list_1 = new List<string>();
            for (int i = 0; i < list_music.Count; i++)
            {
                list_1.Add("№"+ (i + 1) + " " + Path.GetFileName(list_music[i]));
            }
            ListMusic.Items.Clear();
            ListMusic.Items.AddRange(list_1.ToArray());
            ListMusic.HorizontalScrollbar = true;

            if (INI.Read("Volume", "music_volume").Length > 0) // установка значение трекбара музыки.
            {
                track_music_volume.Value = int.Parse(INI.Read("Volume", "music_volume"));
                label_music_volume.Text = "Громкость музыки: " + INI.Read("Volume", "music_volume") + "%";
                music_volume = track_music_volume.Value / 100F;
            }
            if (INI.Read("Volume", "bell_volume").Length > 0) // установка значение трекбара музыки.
            {
                track_bell_volume.Value = int.Parse(INI.Read("Volume", "bell_volume"));
                label_bell_volume.Text = "Громкость звонка: " + INI.Read("Volume", "bell_volume") + "%";
                bell_volume = track_bell_volume.Value / 100F;
            }
        }

        private void EventStart() // ивент працедура.
        {
            ListBell.SelectedIndexChanged += (sender1, e1) => // клик по распесанию.
            {
                if (ListBell.SelectedItem != null)
                {
                    string selectedCountry = ListBell.SelectedItem.ToString();
                    MessageBox.Show(selectedCountry);
                }
            };

            ListMusic.SelectedIndexChanged += (sender1, e1) => // клик по распесанию.
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

            Timer timer = new Timer() // часы.
            { Interval = 1 /* interval - zaderzhka v miliseconds peredd vipolneniem*/ };
            timer.Tick += (sender1, e1) =>
            {
                label_time.Text = "Время: " + DateTime.Now.ToString("HH:mm:ss");
            };
            timer.Start();

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

            // реализация подачи звонков, музыки.
            Timer timer1 = new Timer() { Interval = 1000 /* interval - zaderzhka v miliseconds peredd vipolneniem*/ };
            timer1.Tick += (sender1, e1) =>
            {
                foreach (var item in list_)
                {
                    string[] test11 = item.Split('-');
                    if (DateTime.Now.ToString("HH:mm:ss").Contains(test11[0]))
                    {
                        int Bell_Length = (int)r_bell.Length / 40;
                        System.Threading.Thread myThread0 = new System.Threading.Thread(() =>
                        {
                            Bell_Start(); System.Threading.Thread.Sleep(Bell_Length);
                            boolean = true;
                            w_music.Play();
                            w_music.Volume = music_volume;
                            Play.Invoke(new Action(() => { Play.Text = "■"; }));
                        });
                        myThread0.Start();
                        break;
                    }
                    if (DateTime.Now.ToString("HH:mm:ss").Contains(test11[1]))
                    {
                        boolean = false;
                        w_music.Pause();
                        Play.Invoke(new Action(() => { Play.Text = "►"; }));
                        Bell_Start();
                        break;
                    }
                }
            };
            timer1.Start();
        }

        static WaveOut w_music = new WaveOut();
        static Mp3FileReader r_music;
        private void Player(String file_path) // плеер "►".
        {
            w_music = new WaveOut();
            r_music = new Mp3FileReader(file_path);
            w_music.Volume = music_volume;
            w_music.Init(r_music);

            w_music.PlaybackStopped += (s11, e11) => // следущий треек.
            {
                //MessageBox.Show("PlaybackStopped");
                Next_Play();
            };
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
            w_bell.Stop();
            Create_Bell();
            w_bell.Play();
        }

        WaveOut w_bell = new WaveOut();
        Mp3FileReader r_bell;
        private void Create_Bell() // создать звонок.
        {
            r_bell = new Mp3FileReader(INI.Read("Settings", "bell_file").Replace("%cd%", Environment.CurrentDirectory));
            w_bell.Volume = bell_volume;
            w_bell.Init(r_bell);
        }

        private void Next_Play() // функция реализующая следущий треек "►►".
        {
            if (index_music_list < list_music.Count)
            {
                w_music.Pause();
                w_music = null;
                boolean = true;

                if (index_music_list < list_music.Count - 1)
                    index_music_list++;
                else
                    index_music_list = 0;
                Player(list_music[index_music_list]);

                w_music.Play();
                w_music.Volume = music_volume;
                Play.Invoke(new Action(() => { Play.Text = "■"; }));
            }
        }

        private void Previous_Play() // функция реализующая преведущий треек "◄◄".
        {
            if (index_music_list > -1)
            {
                w_music.Pause();
                w_music = null;
                boolean = true;

                if (index_music_list > 0)
                    index_music_list--;
                else
                    index_music_list = list_music.Count - 1;
                Player(list_music[index_music_list]);

                w_music.Play();
                w_music.Volume = music_volume;
                Play.Invoke(new Action(() => { Play.Text = "■"; }));
            }
        }

        private void Next_Click(object sender, EventArgs e) // кнопка "►►".
        {
            Next_Play();
        }

        private void Previous_Click(object sender, EventArgs e) // кнопка "◄◄".
        {
            Previous_Play();
        }

        private void Play_Click(object sender, EventArgs e) // кнопка "►".
        {
            Music_Start();
        }

        private void Bell_Click(object sender, EventArgs e) // кнопка "Звонок".
        {
            if (boolean)
                Music_Start();
            Bell_Start();
        }

        private void Restart_Click(object sender, EventArgs e) // кнопка "Обновить файл".
        {
            w_music.Stop();
            w_bell.Stop();
            boolean = false;
            Play.Invoke(new Action(() => { Play.Text = "►"; }));
            SetListStart();
            EventStart();
        }
    }
}
