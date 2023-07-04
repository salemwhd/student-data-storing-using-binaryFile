using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.IO;

namespace Binary_File
{
    public partial class DisplayForm : Form
    {
        public DisplayForm()
        {
            InitializeComponent();
        }

        private void DisplayForm_Load(object sender, EventArgs e)
        {
            displayFNtextBox.Text = Info.filename;
        }
        private void DisplayBtn_Click(object sender, EventArgs e)
        {
            BinaryReader br = new BinaryReader(File.Open(Info.filename, FileMode.Open, FileAccess.Read));
            int num_of_records =(int) br.BaseStream.Length / Info.rec_size;
            if(num_of_records>0)
            {
                NumOfRecLabel.Text = ((Info.count / Info.rec_size) + 1).ToString();
                FileSizeLabel.Text = br.BaseStream.Length.ToString();
                DisplayBtn.Text = "Next";
                br.BaseStream.Seek(Info.count, SeekOrigin.Begin);
                IDtextBox.Text = br.ReadInt32().ToString();
                NametextBox.Text = br.ReadString();
                TeltextBox.Text = br.ReadString();
                AgetextBox.Text = br.ReadInt32().ToString();
                GendertextBox.Text = br.ReadString();
                if ((Info.count / Info.rec_size) >= (num_of_records - 1))
                {
                    Info.count = 0;
                }
                else
                {
                    Info.count += Info.rec_size;
                }
              
            }
            else
            {
                MessageBox.Show("Empty file");
            }

            br.Close();

        }

        private void BackBtn_Click(object sender, EventArgs e)
        {
            this.Hide();
            new MainForm().Show();
        }

        private void NumOfRecLabel_Click(object sender, EventArgs e)
        {

        }

        private void label7_Click(object sender, EventArgs e)
        {

        }
    }
}
