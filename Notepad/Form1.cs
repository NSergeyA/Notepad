using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.IO;
using System.Drawing.Printing;



namespace Notepad
{
    public partial class Form1 : Form
    {
        
        public Form1()
        {
            InitializeComponent();
        }

        private void сохранитьToolStripMenuItem_Click(object sender, EventArgs e)
        {

        }

        private void файлToolStripMenuItem_Click(object sender, EventArgs e)
        {

        }

        private void измененияToolStripMenuItem_Click(object sender, EventArgs e)
        {

        }

        private void шToolStripMenuItem_Click(object sender, EventArgs e)
        {
            FontDialog Font = new FontDialog();
            if (Font.ShowDialog() == DialogResult.OK)
            {
                richTextBox1.Font = Font.Font;
            }
        }

        private void открытьToolStripMenuItem_Click(object sender, EventArgs e)
        {
            OpenFileDialog OpenFile = new OpenFileDialog();
            OpenFile.Filter = "all(*.*) | *.*";
            if (OpenFile.ShowDialog() == DialogResult.OK) 
            {
                richTextBox1.Text = File.ReadAllText(OpenFile.FileName);
                _openfile = OpenFile.FileName;

    }
        }
        private string _openfile;

        private void печатьToolStripMenuItem_Click(object sender, EventArgs e)
        {
            PrintDocument PrintD = new PrintDocument();
            PrintD.PrintPage += PrintPage;
            PrintDialog printDialog = new PrintDialog();
            if (printDialog.ShowDialog() == DialogResult.OK)
            {
                printDialog.Document.Print();
            }


        }
        public void PrintPage(object sender, PrintPageEventArgs P)
        {
            P.Graphics.DrawString(richTextBox1.Text, richTextBox1.Font, Brushes.Black, 0, 0);
        }

        private void сохранитьКакToolStripMenuItem_Click(object sender, EventArgs e)
        {
            SaveFileDialog SaveFile = new SaveFileDialog();
            SaveFile.Filter = "all(*.*) | *.*";
            if (SaveFile.ShowDialog() == DialogResult.OK)
            {
                File.WriteAllText(SaveFile.FileName, richTextBox1.Text);
                _openfile = SaveFile.FileName;
            }
        }
        



        private void выходToolStripMenuItem1_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }

        private void справкаToolStripMenuItem_Click(object sender, EventArgs e)
        {

        }

        private void оПрограммеToolStripMenuItem_Click(object sender, EventArgs e)
        {
        
        }

        private void новоеОкноToolStripMenuItem_Click(object sender, EventArgs e)
        {
            richTextBox1.Text = "";
        }

        private void сохранитьToolStripMenuItem_Click_1(object sender, EventArgs e)
        {
            try
            {
                File.WriteAllText(_openfile, richTextBox1.Text);
            }
            catch (ArgumentException)
            {
                MessageBox.Show("save error");

            }
        }
    }
}
