using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace MusicPlayer
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }
        String[] paths, files;
        int StartIndex = 0;
        String[] FileName, FilePath;
        Boolean Playnext= false;
        bool playing = false;

       private void bunifuFlatButton3_Click(object sender, EventArgs e)
        {
            StartIndex = 0;
            Playnext = false;
            OpenFileDialog openfile = new OpenFileDialog();
            openfile.Multiselect = true;
            openfile.Filter = "(mp3,wav,mp4,mov,wmv,mpg,avi,3gp,flv)|*.mp3;*.wav;*.mp4;*.mov;*.wmv;*.mpg;*.avi;*.3gp;*.flv|all files|*.*";
            if (openfile.ShowDialog() == DialogResult.OK)
            {
                FileName = openfile.SafeFileNames;
                FilePath = openfile.FileNames;
                for(int i = 0; i <= FileName.Length - 1; i++)
                {
                    listBox1.Items.Add(FileName[i]);
                }
                StartIndex = 0;
                PlayFile(0);
            }
        }

        private void bunifuProgressBar1_progressChanged(object sender, EventArgs e)
        {

        }

        private void bunifuCustomLabel1_Click(object sender, EventArgs e)
        {

        }

        private void listBox1_SelectedIndexChanged(object sender, EventArgs e)
        {
            StartIndex = listBox1.SelectedIndex;
            PlayFile(StartIndex);
            SongName.Text = listBox1.Text;
        }
        
        private void Form1_Load(object sender, EventArgs e)
        {
            StartIndex = 0;
            Playnext = false;
            StopPlayer();
        }

        private void Playlistbtn_Click(object sender, EventArgs e)
        {
            listBox1.BringToFront();
        }

        private void Playingbtn_Click(object sender, EventArgs e)
        {
            axWindowsMediaPlayer1.BringToFront();
        }


        //hàm StopPlayer
        public void StopPlayer()
        {
            axWindowsMediaPlayer1.Ctlcontrols.stop();
        }
        //hàm playfile
        public void PlayFile(int PlayListIndex)
        {
            if(listBox1.Items.Count <= 0)
            {
                return;
            }
            if(PlayListIndex < 0)
            {
                return;
            }
            axWindowsMediaPlayer1.settings.autoStart = true;
            axWindowsMediaPlayer1.URL = FilePath[PlayListIndex];
            axWindowsMediaPlayer1.Ctlcontrols.next();
            axWindowsMediaPlayer1.Ctlcontrols.play();
        }
    }
}
