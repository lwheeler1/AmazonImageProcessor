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
        //this is the list of images that dont exist in the webImages table
        List<string> missingImages = new List<string>();
        List<string> missingAsins = new List<string>();
        List<Images> finalImages = new List<Images>();
        int errors = 0;

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
            //textBoxLocation1.Text = "C:\\Users\\lwheeler\\Downloads\\images\\test.csv";
            textBoxLocation1.Text = "C:\\ImageProcessorAmazon\\imagesToProcess.csv";

            textBoxStatus.Text = "Please enter the file path of your .CSV file and click the Process button."+Environment.NewLine+Environment.NewLine+"Column A of the .CSV file should contain the image name like 'DA5751_8.jpg'";
            buttonProcessWithErrors.Visible = false;
            Application.DoEvents();
        }
        private void buttonCopyImages_Click(object sender, EventArgs e)
        {
            //open a db connection
            DataAccess db = new DataAccess();

            //start with no errors - this will change if there are missing images or asins
            errors = 0;

            //clear the WebImagesCopyProgram table before we do anything
            db.ClearWebImagesCopyProgramTable();

            //clear the lists we use
            missingImages.Clear();
            missingAsins.Clear();

            //clear text boxes
            textBoxMissingImages.Text = "";
            textBoxMissingAsins.Text = "";

            List<string> listA = new List<string>();
            string fileLocation = textBoxLocation1.Text;
            //using (var reader = new StreamReader(@"C:\Users\lwheeler\Downloads\images\test.csv"))
            using (var reader = new StreamReader(fileLocation))
            {
                while (!reader.EndOfStream)
                {
                    var line = reader.ReadLine();
                    listA.Add(line);
                }
            }
            foreach (var imagefile in listA)
            {
                db.InsertIntoWebImagesCopyProgramTable(imagefile);
            }
            missingImages = db.GetMissingImagesList();
            missingAsins = db.GetMissingAsinsList();

            if(missingImages.Count > 0 || missingAsins.Count > 0){//determine if there are any errors in the file that was processed
                errors = 1;
            }
            foreach (var missingImageName in missingImages)//populate the list of errors
            {
                textBoxMissingImages.Text = textBoxMissingImages.Text+missingImageName.ToString()+Environment.NewLine;
            }
            foreach (var missingImageName in missingAsins)
            {
                textBoxMissingAsins.Text = textBoxMissingAsins.Text+missingImageName.ToString()+Environment.NewLine;
            }

            //copying all the images over
            if (errors == 0)
            {
                copyImages();
            }
            else
            {
                textBoxStatus.Text = "There were errors found. No images have been copied."+Environment.NewLine+Environment.NewLine;
                textBoxStatus.Text = textBoxStatus.Text + "If you would like to copy images anyway, please click on the (Ignore Errors - Process Anyway) button. Keep in mind that missing images and images with missing asins will not be copied.";
                buttonProcessWithErrors.Visible = true;
                Application.DoEvents();
            }
        }
        private void copyImages()
        {
            //open a db connection
            DataAccess db = new DataAccess();

            //clear the list and then populate it with the final results
            finalImages.Clear();
            finalImages = db.GetFinalImages();

            //string location1 = "C:\\Users\\lwheeler\\Downloads\\images\\imageBank\\";
            string location1 = "\\\\hood\\CREA_MARK\\ImageRepository\\Originals_2\\";
            //string location2 = "C:\\Users\\lwheeler\\Downloads\\images\\images\\";
            string location2 = "C:\\ImageProcessorAmazon\\images\\";

            int finalImagesSize = finalImages.Count;
            int counter = 1;
            string itemNo = "";
            string image1 = "";
            string image2 = "";
            List<int> singleDigitList = new List<int>() { 1, 2, 3, 4, 5, 6, 7, 8, 9 };
            for (int i = 0; i < finalImagesSize; i++)
            {
                image1 = finalImages[i].ImageFileName;
                if (finalImages[i].ItemNo == itemNo)
                {//#we have seen this item before
                    counter++;
                    image2 = finalImages[i].ASIN + ".PT";
                    if (singleDigitList.Contains(counter)){
                        image2 = image2 + "0" + counter + ".jpg";
                    }
                    else{
                        image2 = image2 + counter + ".jpg";
                    }
                    File.Copy(location1 + image1, location2 + image2);
                }
                else
                {//this is a new item
                    counter = 1;
                    image2 = finalImages[i].ASIN + ".PT01.jpg";
                    File.Copy(location1 + image1, location2 + image2);
                }
                itemNo = finalImages[i].ItemNo;
            }
            textBoxStatus.Text = "File copy complete.";
        }
        private void buttonMissingImages_Click(object sender, EventArgs e)
        {
            Clipboard.SetDataObject(textBoxMissingImages.Text);
        }
        private void buttonMissingAsins_Click(object sender, EventArgs e)
        {
            Clipboard.SetDataObject(textBoxMissingAsins.Text);
        }
        private void buttonProcessWithErrors_Click(object sender, EventArgs e)
        {
            textBoxMissingImages.Text = "";
            textBoxMissingAsins.Text = "";

            copyImages();

            buttonProcessWithErrors.Visible = false;
            Application.DoEvents();
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
