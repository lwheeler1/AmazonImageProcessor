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

namespace AmazonDirectFulfillment
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }
        private void buttonExit_Click(object sender, EventArgs e)
        {
            DialogResult dr = MessageBox.Show("Are you sure you want to close this form?", "Confirm",
                MessageBoxButtons.YesNo, MessageBoxIcon.Question);
            if (dr == DialogResult.Yes)
                this.Close();
        }
        private void Form1_Load(object sender, EventArgs e)
        {
            textBoxLocation1.Text = "C:\\ImageProcessor\\imagesToProcess.csv";

            textBoxStatus.Text = "Please enter the file path of your .CSV file and click the Process button. " + Environment.NewLine + Environment.NewLine + "Column A of the .CSV file should contain the original image name like 'DA5751_8.jpg'" + Environment.NewLine + Environment.NewLine + "Column B should contain the new image name like 'newName.jpg'";
            Application.DoEvents();
        }
        private void buttonCopyImages_Click(object sender, EventArgs e)
        {
            //clear text boxes
            textBoxMissingImages.Text = "";
            textBoxStatus.Text = "Processing...";

            List<string> listA = new List<string>();
            List<string> listB = new List<string>();
            string fileLocation = textBoxLocation1.Text;
            string[] split;
            string originals2Location = "\\\\hood\\CREA_MARK\\ImageRepository\\Originals_2\\";
            string location2 = "C:\\ImageProcessor\\images\\";
            //using (var reader = new StreamReader(@"C:\Users\lwheeler\Downloads\images\test.csv"))
            using (var reader = new StreamReader(fileLocation))
            {
                while (!reader.EndOfStream)
                {
                    var line = reader.ReadLine();

                    split = line.Split(',');
                    listA.Add(split[0]);
                    listA.Add(split[1]);

                    if(File.Exists(originals2Location+split[0]))
                    {
                        File.Copy(originals2Location + split[0], location2 + split[1]);
                    }
                    else
                    {
                        textBoxMissingImages.Text = textBoxMissingImages.Text + split[0].ToString() + Environment.NewLine;
                    }
                }
            }
            textBoxStatus.Text = "File copy complete.";
        }
        private void buttonMissingImages_Click(object sender, EventArgs e)
        {
            Clipboard.SetDataObject(textBoxMissingImages.Text);
        }
        private void textBoxLocation1_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                buttonCopyImages.PerformClick();
            }
        }
    }
}
