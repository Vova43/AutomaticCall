using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace AutomaticCall3._0_1
{
    /// <summary>
    /// Логика взаимодействия для MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {

        MainWindow MainWindow_;
        MediaPlayer player = null;
        IniFile INI; // файл конфигурации.
        double bell_volume = 1D; // базовая громкость звонка.
        double music_volume = 1D; // базовая громкость музыки.

        public MainWindow()
        {
            InitializeComponent();
            MainWindow_ = this;

            new Form1().Show();

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

            if (INI.Read("Volume", "music_volume").Length > 0) // установка значение трекбара музыки.
            {
                Music_Volume.Value = double.Parse(INI.Read("Volume", "music_volume"));
                music_volume = Music_Volume.Value;
                Music_Volume_Label.Content = "♫: " + (int)(Music_Volume.Value * 100) + "%";
            }
            if (INI.Read("Volume", "bell_volume").Length > 0) // установка значение трекбара звонка.
            {
                Bell_Volume.Value = double.Parse(INI.Read("Volume", "bell_volume"));
                bell_volume = Bell_Volume.Value;
                Ads_Volume_Label.Content = "⍾: " + (int)(Bell_Volume.Value * 100) + "%";
            }

            Music_Volume.Minimum = 0;
            Bell_Volume.Minimum = 0;

            Music_Volume.Maximum = 1D;
            Bell_Volume.Maximum = 1D;

            Music_Volume.Value = music_volume;
            Bell_Volume.Value = bell_volume;
            
            //Window1 T = new Window1();
            //T.Show();

            //Player(Environment.CurrentDirectory + "\\MikeOldfield-ForeignAffair.mp3", 1);
            Player("D:\\--00\\Mike_Oldfield_-_Tricks_Of_The_Light_48390951.mp3", 1);
            RowPos();
        }

        private void MouseDown_(object sender, MouseButtonEventArgs e)
        {
            if (MouseButtonState.Pressed == Mouse.LeftButton)
                MainWindow_.DragMove();
        }

        private void Close_Click(object sender, RoutedEventArgs e)
        {
            Application.Current.Shutdown();
        }

        private void Hide_Click(object sender, RoutedEventArgs e)
        {
            this.WindowState = WindowState.Minimized;
        }

        bool Play_stage = false;
        private void Play_Button_Click(object sender, RoutedEventArgs e)
        {
            if (Play_stage)
            {
                Play_stage = false;
                Play_Button.Content = "►";

                player.Pause();
            }
            else
            {
                Play_stage = true;
                Play_Button.Content = "■";

                player.Play();
            }
        }

        private void Next_Button_Click(object sender, RoutedEventArgs e)
        {

        }

        private void Previous_Button_Click(object sender, RoutedEventArgs e)
        {

        }

        private void Player(string path, int speedPlay)
        {
            player = new MediaPlayer();
            player.MediaFailed += (s, e) => MessageBox.Show("Error " + e);
            player.SpeedRatio = speedPlay;
            player.Open(new Uri(path, UriKind.RelativeOrAbsolute));
            player.MediaEnded += (s, e) => MessageBox.Show(">> ");
            player.Volume = music_volume;
        }

        async void RowPos()
        {
            if (Play_stage)
            {
                POS.Minimum = 0;
                POS.Maximum = (int)player.NaturalDuration.TimeSpan.TotalSeconds;
                POS.Value = (int)player.Position.TotalSeconds;

                TimeSpan t = TimeSpan.FromSeconds((int)POS.Value);
                string displayTime =  string.Format("{0:D2}:{1:D2}:{2:D2}",
                    (int)t.TotalHours,
                    t.Minutes,
                    t.Seconds,
                    t.Milliseconds);
                Total_Track_Position.Content = displayTime;

                TimeSpan t1 = TimeSpan.FromSeconds((int)POS.Maximum);
                string displayTime1 = string.Format("{0:D2}:{1:D2}:{2:D2}",
                    (int)t1.TotalHours,
                    t1.Minutes,
                    t1.Seconds,
                    t1.Milliseconds);
                Total_Track_Length.Content = displayTime1;
            }
            await Task.Delay(1000);
            RowPos();
        }

        private void POS_ValueChanged(object sender, RoutedPropertyChangedEventArgs<double> e)
        {
            int value = (int) e.NewValue;
            if (player.Position > TimeSpan.FromSeconds(value + 1) || player.Position < TimeSpan.FromSeconds(value - 1))
                player.Position = TimeSpan.FromSeconds(value);
            //Tile.Text = e.NewValue + "/" + (int)player.NaturalDuration.TimeSpan.TotalSeconds;
        }

        private void Music_Volume_ValueChanged(object sender, RoutedPropertyChangedEventArgs<double> e)
        {
            if (player != null)
            {
                player.Volume = Music_Volume.Value;
                Music_Volume_Label.Content = "♫: " + (int)(Music_Volume.Value * 100) + "%";
                INI.Write("Volume", "music_volume", Music_Volume.Value + "");
            }
            
        }

        private void Bell_Volume_ValueChanged(object sender, RoutedPropertyChangedEventArgs<double> e)
        {
            if (player != null)
            {
                Ads_Volume_Label.Content = "⍾: " + (int)(Bell_Volume.Value * 100) + "%";
                INI.Write("Volume", "bell_volume", Bell_Volume.Value + "");
            }
        }

        private void Slider_ValueChanged(object sender, RoutedPropertyChangedEventArgs<double> e)
        {
            player.SpeedRatio = e.NewValue;
        }
    }
}
