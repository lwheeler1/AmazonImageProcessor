namespace AmazonDirectFulfillment
{
    partial class Form1
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Form1));
            this.buttonExit = new System.Windows.Forms.Button();
            this.textBoxLocation1 = new System.Windows.Forms.TextBox();
            this.buttonCopyImages = new System.Windows.Forms.Button();
            this.textBoxMissingImages = new System.Windows.Forms.TextBox();
            this.buttonMissingImages = new System.Windows.Forms.Button();
            this.labelMissingImages = new System.Windows.Forms.Label();
            this.textBoxStatus = new System.Windows.Forms.TextBox();
            this.SuspendLayout();
            // 
            // buttonExit
            // 
            this.buttonExit.BackColor = System.Drawing.Color.Red;
            this.buttonExit.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.buttonExit.Location = new System.Drawing.Point(966, 13);
            this.buttonExit.Margin = new System.Windows.Forms.Padding(4);
            this.buttonExit.Name = "buttonExit";
            this.buttonExit.Size = new System.Drawing.Size(167, 48);
            this.buttonExit.TabIndex = 7;
            this.buttonExit.Text = "Exit Form";
            this.buttonExit.UseVisualStyleBackColor = false;
            this.buttonExit.Click += new System.EventHandler(this.buttonExit_Click);
            // 
            // textBoxLocation1
            // 
            this.textBoxLocation1.Font = new System.Drawing.Font("Microsoft Sans Serif", 27.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.textBoxLocation1.Location = new System.Drawing.Point(23, 68);
            this.textBoxLocation1.Name = "textBoxLocation1";
            this.textBoxLocation1.Size = new System.Drawing.Size(1083, 49);
            this.textBoxLocation1.TabIndex = 1;
            this.textBoxLocation1.KeyDown += new System.Windows.Forms.KeyEventHandler(this.textBoxLocation1_KeyDown);
            // 
            // buttonCopyImages
            // 
            this.buttonCopyImages.Location = new System.Drawing.Point(23, 136);
            this.buttonCopyImages.Name = "buttonCopyImages";
            this.buttonCopyImages.Size = new System.Drawing.Size(488, 54);
            this.buttonCopyImages.TabIndex = 10;
            this.buttonCopyImages.Text = "Process";
            this.buttonCopyImages.UseVisualStyleBackColor = true;
            this.buttonCopyImages.Click += new System.EventHandler(this.buttonCopyImages_Click);
            // 
            // textBoxMissingImages
            // 
            this.textBoxMissingImages.Location = new System.Drawing.Point(23, 216);
            this.textBoxMissingImages.Multiline = true;
            this.textBoxMissingImages.Name = "textBoxMissingImages";
            this.textBoxMissingImages.ScrollBars = System.Windows.Forms.ScrollBars.Vertical;
            this.textBoxMissingImages.Size = new System.Drawing.Size(287, 457);
            this.textBoxMissingImages.TabIndex = 11;
            // 
            // buttonMissingImages
            // 
            this.buttonMissingImages.Location = new System.Drawing.Point(23, 679);
            this.buttonMissingImages.Name = "buttonMissingImages";
            this.buttonMissingImages.Size = new System.Drawing.Size(287, 59);
            this.buttonMissingImages.TabIndex = 13;
            this.buttonMissingImages.Text = "Copy";
            this.buttonMissingImages.UseVisualStyleBackColor = true;
            this.buttonMissingImages.Click += new System.EventHandler(this.buttonMissingImages_Click);
            // 
            // labelMissingImages
            // 
            this.labelMissingImages.AutoSize = true;
            this.labelMissingImages.Location = new System.Drawing.Point(53, 193);
            this.labelMissingImages.Name = "labelMissingImages";
            this.labelMissingImages.Size = new System.Drawing.Size(219, 20);
            this.labelMissingImages.TabIndex = 14;
            this.labelMissingImages.Text = "Missing Images in originals_2:";
            // 
            // textBoxStatus
            // 
            this.textBoxStatus.BackColor = System.Drawing.Color.Black;
            this.textBoxStatus.Font = new System.Drawing.Font("Microsoft Sans Serif", 20.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.textBoxStatus.ForeColor = System.Drawing.Color.White;
            this.textBoxStatus.Location = new System.Drawing.Point(673, 329);
            this.textBoxStatus.Multiline = true;
            this.textBoxStatus.Name = "textBoxStatus";
            this.textBoxStatus.Size = new System.Drawing.Size(519, 409);
            this.textBoxStatus.TabIndex = 19;
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(9F, 20F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.LightBlue;
            this.ClientSize = new System.Drawing.Size(1204, 750);
            this.Controls.Add(this.textBoxStatus);
            this.Controls.Add(this.labelMissingImages);
            this.Controls.Add(this.buttonMissingImages);
            this.Controls.Add(this.textBoxMissingImages);
            this.Controls.Add(this.buttonCopyImages);
            this.Controls.Add(this.textBoxLocation1);
            this.Controls.Add(this.buttonExit);
            this.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.Name = "Form1";
            this.Text = "ImageProcessorNormal";
            this.Load += new System.EventHandler(this.Form1_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion
        private System.Windows.Forms.Button buttonExit;
        private System.Windows.Forms.TextBox textBoxLocation1;
        private System.Windows.Forms.Button buttonCopyImages;
        private System.Windows.Forms.TextBox textBoxMissingImages;
        private System.Windows.Forms.Button buttonMissingImages;
        private System.Windows.Forms.Label labelMissingImages;
        private System.Windows.Forms.TextBox textBoxStatus;
    }
}

