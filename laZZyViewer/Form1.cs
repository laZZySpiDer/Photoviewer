using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;



namespace laZZyViewer
{
    public partial class Form1 : Form
    {
        String filepath;
        bool imageOpened = false;
        Bitmap bitmap1;
        public Form1()
        {
            InitializeComponent();
            menulist1.Visible = false;
            helpToolStripMenuItem.Visible = false;
            panel1.Visible = true;
            tableLayoutPanel1.Visible = false;
            hintforbutton();
            
            
        }
        public void hintforbutton()
        {
            ToolTip obj1 = new ToolTip();
            obj1.SetToolTip(btnrotateleft,"Rotate Left");
            obj1.SetToolTip(btnrotateright,"Rotate Right");
            obj1.SetToolTip(btnzoomin,"Zoom In");
            obj1.SetToolTip(btnzoomout, "Zoom Out");
        }
        public void opennewImage()
        {
           //a function to open the image.
           //it is called twice. When NEW is clicked from menu strip
           //or when the picture box is clicked once
            OpenFileDialog browseFolder = new OpenFileDialog();
            DialogResult dialogresult = browseFolder.ShowDialog();
            if (dialogresult == DialogResult.OK)
            {
                filepath = browseFolder.ToString();
                PictureBox pic_new = new PictureBox();
                pictureBox1.Image = Image.FromFile(browseFolder.FileName);
                bitmap1 = (Bitmap)pictureBox1.Image;
                imageOpened = true;
                menulist1.Visible = true;
                helpToolStripMenuItem.Visible = true;
                tableLayoutPanel1.Visible = true;

            }
        }
        private void btnclose_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }

        private void exitToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }

        private void newToolStripMenuItem_Click(object sender, EventArgs e)
        {
            opennewImage();
        }

        private void pictureBox1_Click(object sender, EventArgs e)
        {
            if(imageOpened == false)
            {
                opennewImage();
            }            
        }

        private void btnzoomout_Click(object sender, EventArgs e)
        {

            pictureBox1.Top = (int)(pictureBox1.Top + (pictureBox1.Height * 0.025));
            pictureBox1.Left = (int)(pictureBox1.Left + (pictureBox1.Width * 0.025));
            pictureBox1.Height = (int)(pictureBox1.Height - (pictureBox1.Height * 0.05));
            pictureBox1.Width = (int)(pictureBox1.Width - (pictureBox1.Width * 0.05));
        }

        private void btnrotateright_Click(object sender, EventArgs e)
        {
            bitmap1.RotateFlip(RotateFlipType.Rotate90FlipNone);
            pictureBox1.Image = bitmap1;
        }

        private void btnrotateleft_Click(object sender, EventArgs e)
        {
            bitmap1.RotateFlip(RotateFlipType.Rotate270FlipNone);
            pictureBox1.Image = bitmap1;
           
            
        }

        private void btnzoomin_Click(object sender, EventArgs e)
        {
            pictureBox1.Top = (int)(pictureBox1.Top - (pictureBox1.Height * 0.025));
            pictureBox1.Left = (int)(pictureBox1.Left - (pictureBox1.Width * 0.025));
            pictureBox1.Height = (int)(pictureBox1.Height + (pictureBox1.Height * 0.05));
            pictureBox1.Width = (int)(pictureBox1.Width + (pictureBox1.Width * 0.05));
        }
    }
}
