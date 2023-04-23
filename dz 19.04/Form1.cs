using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Windows.Forms;
using static System.Windows.Forms.VisualStyles.VisualStyleElement;

namespace dz19_04
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();

            comboBox1.Items.Add("C:");
            comboBox1.Items.Add("E:");
            comboBox1.Items.Add("F:");
            comboBox1.Items.Add("D:");
        }

        public void FileThread()
        {
            listView1.Items.Clear();
            string[] astrFiles = Directory.GetFiles(comboBox1.SelectedItem.ToString() + path);
            foreach (string file in astrFiles)
            {
                Thread.Sleep(300);
                if (file.Contains("." + textBox1.Text))
                {
                    listView1.Items.Add(file);
                }
            }
        }

        string path = "\\Users\\danya\\OneDrive\\Documents";
        Thread thr;

        private void search_Click(object sender, EventArgs e)
        {
            if (textBox1.Text != null)
            {
                stop.Enabled = true;
                search.Enabled = false;
                thr = new Thread(new ThreadStart(FileThread));
                thr.Start();
            }
        }

        private void stop_Click(object sender, EventArgs e)
        {
            search.Enabled = true;
            stop.Enabled = false;
            thr.Suspend();
        }
    }
}