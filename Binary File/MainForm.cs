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
    public partial class MainForm : Form
    {
        public MainForm()
        {
            InitializeComponent();
        }

        private void CreateBtn_Click(object sender, EventArgs e)
        {
            Info.filename = "D:\\" + FilenametextBox.Text + ".txt"; // Get the file name from user if I insert file1 in FilenameTextBox ,filename= E:\\file1.txt
            if (!File.Exists(Info.filename)) // if the file does not exists 
            {
             var f=   File.Create(Info.filename);// We Should include using System.IO;
                MessageBox.Show("File is Created Successfully", "Note", MessageBoxButtons.OK, MessageBoxIcon.Information);
                f.Close();

            }
            else
                errorLabel.Visible = true; // Error Message “ File Exists “ should set Lable2 : visible = false from properties window first
           
        }

        private void DeleteBtn_Click(object sender, EventArgs e)
        {
            Info.filename = "D:\\" + FilenametextBox.Text + ".txt";
            File.Delete(Info.filename);
            MessageBox.Show("File is Deleted ");
            FilenametextBox.Clear();
            errorLabel.Visible = false;
        }

        private void deleteToolStripMenuItem_Click(object sender, EventArgs e)
        {
            DeleteBtn.Visible = true; // or write the same code of create button
        }

        private void newToolStripMenuItem_Click(object sender, EventArgs e)
        {
            CreateBtn.Visible = true;     // or write the same code of delete button       
        }

        private void addNewStudentToolStripMenuItem_Click(object sender, EventArgs e)
        {
            this.Hide();
            new InsertForm().Show(); 
        }

        private void viewExistingStudentsToolStripMenuItem_Click(object sender, EventArgs e)
        {
            this.Hide();
            new DisplayForm().Show();
        }

       private void exitToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }

        private void FilenametextBox_TextChanged(object sender, EventArgs e)
        {
            errorLabel.Visible = false;
        }

        private void errorLabel_Click(object sender, EventArgs e)
        {

        }

        private void MainForm_Load(object sender, EventArgs e)
        {

        }

        private void studentsToolStripMenuItem_Click(object sender, EventArgs e)
        {

        }

        private void label1_Click(object sender, EventArgs e)
        {

        }
        private void btnClose_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}
