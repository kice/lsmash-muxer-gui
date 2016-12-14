﻿using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;
using System.Diagnostics;
using System.Windows.Forms;


namespace lsmash_gui
{
    public partial class Main : System.Windows.Forms.Form
    {
        public Main()
        {
            InitializeComponent();
        }

        private void About_Click(object sender, EventArgs e)
        {
            //about
            MessageBox.Show("L-SMASH Muxer GUI\n\nThis is a GUI which use l-smash to mux video and audio");
        }

        private void label1_Click(object sender, EventArgs e)
        {

        }

        private void Form1_Load(object sender, EventArgs e)
        {

        }

        private void label2_Click(object sender, EventArgs e)
        {

        }

        private void openvideo_Click(object sender, EventArgs e)
        {
            //open video file
            OpenFileDialog openFileDialog1 = new OpenFileDialog();
            openFileDialog1.Filter = "RAW MPEG-4 AVC|*.264;*.h264;*.avc|RAW MPEG-4 HEVC|*.265;*.hevc|All Files|*.*";
            openFileDialog1.RestoreDirectory = true;
            openFileDialog1.FilterIndex = 1;
            if (openFileDialog1.ShowDialog() == DialogResult.OK)
            {
                Videopath.Text = openFileDialog1.FileName;

            }
        }

        private void Videopath_DragEnter(object sender, DragEventArgs e)
        {
            //drag video file
            if (e.Data.GetDataPresent(DataFormats.FileDrop, false))
            {

                e.Effect = DragDropEffects.All;
            }
        }

        private void Videopath_DragDrop(object sender, DragEventArgs e)
        {
            //drag video file and confirm format
            string fileName = ((string[])e.Data.GetData(DataFormats.FileDrop))[0];
            //confirm if path is a directort
            string path = ((System.Array)e.Data.GetData(DataFormats.FileDrop)).GetValue(0).ToString();
            if (System.IO.Directory.Exists(path))
            {
                MessageBox.Show("Not a File!");
            }
            else
            {
                if (Path.GetExtension(fileName) == (".avc") || Path.GetExtension(fileName) == (".h264") || Path.GetExtension(fileName) == (".264") || Path.GetExtension(fileName) == (".hevc") || Path.GetExtension(fileName) == (".265"))
                {
                    Videopath.Text = fileName;
                }
                else
                {
                    MessageBox.Show("Unsupport Format!");
                }
            }
        }

        private void FPS_Value_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        private void vtrack_name_TextChanged(object sender, EventArgs e)
        {

        }

        private void Clear_vtrack_name_Click(object sender, EventArgs e)
        {
            vtrack_name.Clear();
        }

        private void Audiopath_DragDrop(object sender, DragEventArgs e)
        {
            //drag video file and confirm format
            string fileName = ((string[])e.Data.GetData(DataFormats.FileDrop))[0];
            //confirm if path is a directort
            string path = ((System.Array)e.Data.GetData(DataFormats.FileDrop)).GetValue(0).ToString();
            if (System.IO.Directory.Exists(path))
            {
                MessageBox.Show("Not a File!");
            }
            else
            {
                if (Path.GetExtension(fileName) == (".aac") || Path.GetExtension(fileName) == (".m4a") || Path.GetExtension(fileName) == (".mp3"))
                {
                    Audiopath.Text = fileName;
                }
                else
                {
                    MessageBox.Show("Unsupport Format!");
                }
            }
        }

        private void Audiopath_DragEnter(object sender, DragEventArgs e)
        {
            //drag audio file
            if (e.Data.GetDataPresent(DataFormats.FileDrop, false))
            {

                e.Effect = DragDropEffects.All;
            }
        }

        private void openaudio_Click(object sender, EventArgs e)
        {
            //open audio file
            OpenFileDialog openFileDialog1 = new OpenFileDialog();
            openFileDialog1.Filter = "AAC|*.aac;*.m4a|mp3|*.mp3|All Files|*.*";
            openFileDialog1.RestoreDirectory = true;
            openFileDialog1.FilterIndex = 1;
            if (openFileDialog1.ShowDialog() == DialogResult.OK)
            {
                Audiopath.Text = openFileDialog1.FileName;

            }
        }

        private void Clear_atrack_name_Click(object sender, EventArgs e)
        {
            atrack_name.Clear();
        }

        private void Chapterpath_DragDrop(object sender, DragEventArgs e)
        {
            //drag video file and confirm format
            string fileName = ((string[])e.Data.GetData(DataFormats.FileDrop))[0];
            //confirm if path is a directort
            string path = ((System.Array)e.Data.GetData(DataFormats.FileDrop)).GetValue(0).ToString();
            if (System.IO.Directory.Exists(path))
            {
                MessageBox.Show("Not a File!");
            }
            else
            {
                if (Path.GetExtension(fileName) == (".txt"))
                {
                    Chapterpath.Text = fileName;
                }
                else
                {
                    MessageBox.Show("Unsupport Format!");
                }
            }
        }

        private void Chapterpath_DragEnter(object sender, DragEventArgs e)
        {
            //drag chapter file
            if (e.Data.GetDataPresent(DataFormats.FileDrop, false))
            {

                e.Effect = DragDropEffects.All;
            }
        }

        private void openchapter_Click(object sender, EventArgs e)
        {
            //open chapter file
            OpenFileDialog openFileDialog1 = new OpenFileDialog();
            openFileDialog1.Filter = "Chapter File|*.txt|All Files|*.*";
            openFileDialog1.RestoreDirectory = true;
            openFileDialog1.FilterIndex = 1;
            if (openFileDialog1.ShowDialog() == DialogResult.OK)
            {
                Chapterpath.Text = openFileDialog1.FileName;

            }
        }

        private void tableLayoutPanel12_Paint(object sender, PaintEventArgs e)
        {

        }

        private void outputpath_TextChanged(object sender, EventArgs e)
        {

        }

        private void selectpath_Click(object sender, EventArgs e)
        {
            //save file
            SaveFileDialog saveFileDialog1 = new SaveFileDialog();
            saveFileDialog1.Filter = "Muxed File|*.mp4|All Files|*.*";
            saveFileDialog1.RestoreDirectory = true;
            saveFileDialog1.FilterIndex = 1;
            if (saveFileDialog1.ShowDialog() == DialogResult.OK)
            {
                outputpath.Text = saveFileDialog1.FileName;

            }
        }

        private void tableLayoutPanel1_Paint(object sender, PaintEventArgs e)
        {

        }

        private void logs_TextChanged(object sender, EventArgs e)
        {

        }

        private void Start_Click(object sender, EventArgs e)
        {
            bool vtrack_flag = false;
            bool atrack_flag = false;
            bool vfps_flag = false;
            string arg_muxer = "";
            if (outputpath.Text == "")
            {
                MessageBox.Show("Output not set!");
            }
            else
            {
                arg_muxer = ("");
                //main tracks
                if (Chapterpath.Text != "")
                    arg_muxer = (arg_muxer + " --chapter \"" + Chapterpath.Text + "\"");
                if (Videopath.Text != "")
                {
                    arg_muxer = (arg_muxer + " -i \"" + Videopath.Text + "\"");
                    vtrack_flag = true;
                }
                if (Audiopath.Text != "")
                {
                    arg_muxer = (arg_muxer + " -i \"" + Audiopath.Text + "\"");
                    atrack_flag = true;
                }
                //additions
                if (vtrack_flag = true && FPS_Value.SelectedItem != null)
                {
                    arg_muxer = (arg_muxer + "?1:fps=" + FPS_Value.SelectedItem);
                    vfps_flag = true;
                }
                if (vtrack_flag = true && vtrack_name.Text != "")
                {
                    if (vfps_flag == true)
                        arg_muxer = (arg_muxer + ",handler=" + vtrack_name.Text);
                    else
                        arg_muxer = (arg_muxer + "?1:handler=" + vtrack_name.Text);
                }
                if (atrack_flag = true && Lang_Value.SelectedItem != null)
                {
                    arg_muxer = (arg_muxer + "?2:language=" + Lang_Value.SelectedItem);
                }
                else
                {
                    arg_muxer = (arg_muxer + "?2:language=jpn");
                }
                if (atrack_flag = true && atrack_name.Text != "")
                {
                    arg_muxer = (arg_muxer + ",handler=" + atrack_name.Text);
                }
                if (atrack_flag = true && ADelay_Value.Value != 0)
                {
                    arg_muxer = (arg_muxer + ",encoder-delay=" + ADelay_Value.Value.ToString());
                }
                //output
                if (arg_muxer.Contains(" -i \"") == true)
                {
                    arg_muxer = (arg_muxer + " -o \"" + outputpath.Text + "\"");
                    //logs.Text = arg_muxer;
                    logs.Text += ("Processing....");
                    ExcuteDosCommand(arg_muxer);
                    logs.Text = ("Finished....");
                }
                else
                    MessageBox.Show("Nothing to mux!");
            }

        }

        private void Lang_Value_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        private void ADelay_Value_ValueChanged(object sender, EventArgs e)
        {

        }

        private void ExcuteDosCommand(string cmd)
        {
            try
            {
                Process p = new Process();
                p.StartInfo.FileName = "cmd";
                p.StartInfo.UseShellExecute = false;
                p.StartInfo.RedirectStandardInput = true;
                p.StartInfo.RedirectStandardOutput = true;
                p.StartInfo.RedirectStandardError = true;
                p.StartInfo.CreateNoWindow = true;
                p.OutputDataReceived += new DataReceivedEventHandler(sortProcess_OutputDataReceived);
                p.Start();
                StreamWriter cmdWriter = p.StandardInput;
                p.BeginOutputReadLine();
                if (!String.IsNullOrEmpty(cmd))
                {
                    cmdWriter.WriteLine( "\"" + Application.StartupPath + "\\muxer.exe\"" + cmd);
                }
                cmdWriter.Close();
                p.WaitForExit();
                p.Close();
            }

            catch (Exception ex)
            {
                MessageBox.Show("执行命令失败，请检查输入的命令是否正确！");
            }
        }
        private void sortProcess_OutputDataReceived(object sender, DataReceivedEventArgs e)
        {
            if (!String.IsNullOrEmpty(e.Data))
            {
                //this.BeginInvoke(new Action(() => { this.logs.Text= e.Data; }));
                //logs.Text = e.Data;
            }
        }

        private void Clear_All_Click(object sender, EventArgs e)
        {
            Videopath.Clear();
            Audiopath.Clear();
            Chapterpath.Clear();
            outputpath.Clear();
            vtrack_name.Clear();
            atrack_name.Clear();
            FPS_Value.SelectedItem = null;
            Lang_Value.SelectedItem = null;
            ADelay_Value.Value = 0;
        }
    }
}