using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace WpfApplication4
{
    public partial class Form2 : Form
    {
        public Form2()
        {
            InitializeComponent();
        }

        public Form2(Form1 form1)
        {
            // TODO: Complete member initialization
            this.form1 = form1;
        }

        IniFile INI;
        private Form1 form1;
        private void Form2_Load(object sender, EventArgs e)
        {
            this.FormBorderStyle = FormBorderStyle.FixedSingle;
            this.MaximizeBox = false;
            this.MinimizeBox = true;
            Load_();

            //File.WriteAllText("start.txt", "Данные");
        }

        private void Load_()
        {
            //File.ReadAllText("start.txt", "Данные");
            INI = new IniFile("config.ini");
            List<string> list_0 = new List<string>(); // лист звонков
            int indexNum = 1; // индекс в ListBox
            while (INI.Read("Bell", indexNum + "").Length > 0) // лист звонков.
            {
                string str = INI.Read("Bell", indexNum + "");
                string[] test11 = str.Split('-');
                list_0.Add("" + indexNum + ": " + test11[0] + "-" + test11[1]);
                indexNum++;
            }
            ListBell.Items.Clear();
            ListBell.Items.AddRange(list_0.ToArray());

            ListBell.SelectedIndexChanged += (sender1, e1) => // клик по распесанию.
            {
                if (ListBell.SelectedItem != null)
                {
                    int selectedCountry = ListBell.SelectedIndex;
                    selectedCountry++;
                    string str = INI.Read("Bell", selectedCountry + "");
                    string[] test11 = str.Split('-');
                    num_text.Text = "" + selectedCountry;
                    num_time0.Text = "" + test11[0];
                    num_time1.Text = "" + test11[1];
                }
            };

            intervalAds.Text = INI.Read("Settings", "interval_ads");
            textReview3.Text = INI.Read("Settings", "ads_dir");
            textReview2.Text = INI.Read("Settings", "music_dir");
            textReview1.Text = INI.Read("Settings", "bell_file");
        }

        public static int StringToInt(String s)
        {
            if (0 == s.Replace("[^\\d]", "").Length)
            {
                return 0;
            }
            if (!s.Contains("-"))
            {
                String strNum = s.Replace("[^\\d]", "");
                return Convert.ToInt32(strNum);
            }
            else
            {
                return 0;
            }
        }

        Form1 formMain;

        private void SaveListBell_Click(object sender, EventArgs e)
        {
            int index = StringToInt(num_text.Text);
            string str0 = num_time0.Text;
            string str1 = num_time1.Text;

            if (str0.Length == 8 && str1.Length == 8)
            {
                int indexNum = 1; // индекс в ListBox
                while (INI.Read("Bell", indexNum + "").Length > 0) // лист звонков.
                {
                    string str = INI.Read("Bell", indexNum + "");
                    string[] test11 = str.Split('-');
                    if (str0 + "-" + str1 == test11[0] + "-" + test11[1])
                    {
                        MessageBox.Show("Ошибка >> Данная время уже существует");
                        return;
                    }
                    indexNum++;
                }
                //Text = ListBell.Items.Count + 1 + "|" + index;
                if (ListBell.Items.Count + 1 >= index)
                {
                    INI.Write("Bell", index + "", str0 + "-" + str1);
                    num_text.Text = "";
                    num_time0.Text = "";
                    num_time1.Text = "";
                }

            }
            else
            {
                INI.Write("Bell", index + "", null);
                num_text.Text = "";
                num_time0.Text = "";
                num_time1.Text = "";
            }
            Load_();
        }

        private void CloseListBell_Click(object sender, EventArgs e)
        {

        }

        private void DeleteListBell_Click(object sender, EventArgs e)
        {
            int index = StringToInt(num_text.Text);
            INI.Write("Bell", index + "", null);
            num_text.Text = "";
            num_time0.Text = "";
            num_time1.Text = "";
            Load_();
        }


        public void SetThis(Form1 form1)
        {
            //throw new NotImplementedException();
            formMain = form1;
        }

        private void Apply_Click(object sender, EventArgs e)
        {
            Application.Restart();
        }

        private void Review1_Click(object sender, EventArgs e)
        {
            OpenFileDialog OPF = new OpenFileDialog();
            OPF.Filter = "Аудио файлы Mp3 (*.mp3)|*.mp3";
            if (OPF.ShowDialog() == DialogResult.OK)
            {
                textReview1.Text = OPF.FileName;
            }
        }

        private void Review2_Click(object sender, EventArgs e)
        {
            FolderBrowserDialog FBD = new FolderBrowserDialog();
            FBD.SelectedPath = Environment.CurrentDirectory;
            FBD.Description = "Укажите папку(каталог) с музыкой:";
            FBD.ShowNewFolderButton = false;
            if (FBD.ShowDialog() == DialogResult.OK)
            {
                textReview2.Text = FBD.SelectedPath;
            }
        }

        private void Review3_Click(object sender, EventArgs e)
        {
            FolderBrowserDialog FBD = new FolderBrowserDialog();
            FBD.SelectedPath = Environment.CurrentDirectory;
            FBD.Description = "Укажите папку(каталог) с объявлениями:";
            FBD.ShowNewFolderButton = false;
            if (FBD.ShowDialog() == DialogResult.OK)
            {
                textReview3.Text = FBD.SelectedPath;
            }
        }

        private void textReview1_TextChanged(object sender, EventArgs e)
        {
            if (textReview1.Text != "")
            {
                INI.Write("Settings", "bell_file", textReview1.Text);
            }
        }

        private void textReview2_TextChanged(object sender, EventArgs e)
        {
            if (textReview2.Text != "")
            {
                INI.Write("Settings", "music_dir", textReview2.Text);
            }

        }

        private void textReview3_TextChanged(object sender, EventArgs e)
        {
            if (textReview3.Text != "")
            {
                INI.Write("Settings", "ads_dir", textReview3.Text);
            }

        }

        private void intervalAds_TextChanged(object sender, EventArgs e)
        {
            if (intervalAds.Text != "")
            {
                INI.Write("Settings", "interval_ads", intervalAds.Text);
            }
        }
    }
}
