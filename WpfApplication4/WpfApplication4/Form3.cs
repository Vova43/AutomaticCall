using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Windows.Media;

namespace WpfApplication4
{
    public partial class Form3 : Form
    {
        public Form3()
        {
            InitializeComponent();
        }

        private void Form3_Load(object sender, EventArgs e)
        {
            Player("", 2);
        }
        MediaPlayer player;
        private void Player(string path, int speedPlay)
        {
            player = new MediaPlayer();
            player.MediaFailed += (s, e) => MessageBox.Show("Ошибка плеера: " + e);
            player.SpeedRatio = speedPlay;
            player.Open(new Uri(path, UriKind.RelativeOrAbsolute));
            //player.Open(new Uri("https://rusradio.hostingradio.ru/rusradio96.aacp"));
            //player.MediaEnded += (s, e) => Next_Play();
            player.Volume = 1;
        }
    }
}
