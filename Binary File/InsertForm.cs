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
    public partial class InsertForm : Form
    {
        public InsertForm()
        {
            InitializeComponent();
        }

       
        private void Form2_Load(object sender, EventArgs e)
        {
            displayFNtextBox.Text = Info.filename;

        }

        private void SaveBtn_Click(object sender, EventArgs e)
        {
            BinaryWriter bw = new BinaryWriter(File.Open(Info.filename, FileMode.Open, FileAccess.Write)); // We Should include using System.IO;
            int length = (int)bw.BaseStream.Length;

            if (length != 0) //If the file is not empty hymshy 32 byte (record size) w b3d keda yktb
            {
                bw.BaseStream.Seek(length, SeekOrigin.Begin); 
                            
            }
            
            bw.Write(int.Parse(IDtextBox.Text)); // ID
            
            NametextBox.Text = NametextBox.Text.PadRight(9); // Name 
            bw.Write(NametextBox.Text.Substring(0, 9));

            TeltextBox.Text = TeltextBox.Text.PadRight(11); //Tel 
            bw.Write(TeltextBox.Text.Substring(0, 11));

            bw.Write(int.Parse(AgetextBox.Text)); //Year 
            
            bw.Write(GendertextBox.Text.Substring(0, 1)); // Gender
            
            length += Info.rec_size;
            IDtextBox.Clear(); NametextBox.Clear(); TeltextBox.Clear(); AgetextBox.Clear(); GendertextBox.Clear();
            NumOfRecLabel.Text = (length / Info.rec_size).ToString(); // update number of records label
            FileSizeLabel.Text = length.ToString();//update file length label
            MessageBox.Show(" Data is Saved Successfully ");

            bw.Close();
            

        }

        private void BackBtn_Click(object sender, EventArgs e)
        {
            this.Hide();
            new MainForm().Show();
        }

        private void displayFNtextBox_TextChanged(object sender, EventArgs e)
        {

        }

        private void IDtextBox_TextChanged(object sender, EventArgs e)
        {
            NametextBox.Clear();
            TeltextBox.Clear();
            AgetextBox.Clear();
            GendertextBox.Clear();
        }

        private void NumOfRecLabel_Click(object sender, EventArgs e)
        {

        }

        private void searchbtn_Click(object sender, EventArgs e)
        {
            BinaryReader br = new BinaryReader(File.Open(Info.filename, FileMode.Open, FileAccess.Read));
            br.BaseStream.Seek(Info.count, SeekOrigin.Begin);
            int num_of_records = (int)br.BaseStream.Length / Info.rec_size;
            int length = (int)br.BaseStream.Length;
            if (length != 0)
            {
                while (true)
                {
                    br.BaseStream.Seek(Info.count, SeekOrigin.Begin);
                    if (IDtextBox.Text == br.ReadInt32().ToString())
                    {
                        NametextBox.Text = br.ReadString();
                        TeltextBox.Text = br.ReadString();
                        AgetextBox.Text = br.ReadInt32().ToString();
                        GendertextBox.Text = br.ReadString();
                        Info.count = 0;
                        break;

                    }
                    else if ((Info.count / Info.rec_size) >= (num_of_records - 1))
                    {
                        MessageBox.Show("Not found");
                        Info.count = 0;
                        break;
                    }

                    else
                    {

                        Info.count += Info.rec_size;
                    }
                }
            }
            else
            {
                MessageBox.Show("erorr");
            }


            br.Close();

        }

        private void Updatebtn_Click(object sender, EventArgs e)
        {
            if (IDtextBox.Text == "")
            {
                MessageBox.Show("Erorr, NO ID Found");

            }
            else
            {

                BinaryReader br = new BinaryReader(File.Open(Info.filename, FileMode.Open, FileAccess.Read));
                br.BaseStream.Seek(Info.count, SeekOrigin.Begin);
                int num_of_records = (int)br.BaseStream.Length / Info.rec_size;
                while (true)
                {
                    br.BaseStream.Seek(Info.count, SeekOrigin.Begin);
                    if (IDtextBox.Text == br.ReadInt32().ToString())
                    {
                        br.Close();
                        BinaryWriter bw = new BinaryWriter(File.Open(Info.filename, FileMode.Open, FileAccess.Write));

                        if (IDtextBox.Text != "")
                        {
                            bw.Write(int.Parse(IDtextBox.Text)); // ID
                        }
                        if (NametextBox.Text != "")
                        {

                            NametextBox.Text = NametextBox.Text.PadRight(9); // Name 
                            bw.Write(NametextBox.Text.Substring(0, 9));
                        }

                        if (TeltextBox.Text != "")
                        {

                            TeltextBox.Text = TeltextBox.Text.PadRight(11); //Tel 
                            bw.Write(TeltextBox.Text.Substring(0, 11));
                        }

                        if (AgetextBox.Text != "")
                        {
                            bw.Write(int.Parse(AgetextBox.Text)); //Age
                        }
                        if (GendertextBox.Text != "")
                        {
                            bw.Write(GendertextBox.Text.Substring(0, 1));
                        }
                        Info.count = 0;
                        MessageBox.Show("Data Updated sucessfully");
                        bw.Close();
                        break;

                    }
                    else if ((Info.count / Info.rec_size) >= (num_of_records - 1))
                    {
                        MessageBox.Show("Memeber Not found");
                        Info.count = 0;
                        break;
                    }

                    else
                    {

                        Info.count += Info.rec_size;
                    }
                }
            }
                }
            }
}
