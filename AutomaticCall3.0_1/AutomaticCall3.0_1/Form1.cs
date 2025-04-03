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

namespace AutomaticCall3._0_1
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void Form1_Load(object sender1, EventArgs e1)
        {
            /*
            MediaPlayer player = new MediaPlayer();
            player.MediaFailed += (s, e) => MessageBox.Show("Error " + e);
            player.SpeedRatio = 1;
            player.Open(new Uri("", UriKind.RelativeOrAbsolute));
            player.MediaEnded += (s, e) => MessageBox.Show(">> ");
            player.Volume = 1;
             */
            //tabControl1.DrawItem += new DrawItemEventHandler(tabControl1_DrawItem);
        }

        private void tabControl1_DrawItem(object sender, DrawItemEventArgs e)
        {
            string tabName = tabControl1.TabPages[e.Index].Text;
            StringFormat stringFormat = new StringFormat();
            stringFormat.Alignment = StringAlignment.Center;
            stringFormat.LineAlignment = StringAlignment.Center;
            //Find if it is selected, this one will be hightlighted...
            if (e.Index == tabControl1.SelectedIndex)
                e.Graphics.FillRectangle(System.Drawing.Brushes.LightBlue, e.Bounds);
            e.Graphics.DrawString(tabName, this.Font, System.Drawing.Brushes.Black, tabControl1.GetTabRect(e.Index), stringFormat);
        }

        private void class11_Click(object sender, EventArgs e)
        {
            Text = "ddsdsdsd";
        }
    }
}
