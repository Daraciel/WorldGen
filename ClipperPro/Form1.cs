using DCMapLib;
using Emgu.CV;
using Emgu.CV.Structure;
using ProtoBuf;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace ClipperPro
{
    public partial class Form1 : Form
    {
        public Mapa map;
        private Rectangle rect;
        private bool go;
        private Image<Gray, Byte> src;
        private Image<Gray, Byte> srcCrop;
        private int X, Y;

        public Form1()
        {
            InitializeComponent();
        }

        private void abrirImágenToolStripMenuItem_Click(object sender, EventArgs e)
        {
            ibImagen.FunctionalMode = Emgu.CV.UI.ImageBox.FunctionalModeOption.Minimum;
            OpenFileDialog openFileDialog1 = new OpenFileDialog();
            openFileDialog1.Filter = "Ficheros DCM (*.dcm)|*.dcm";
            if (openFileDialog1.ShowDialog() == DialogResult.OK)
            {
                using (var file = File.OpenRead(openFileDialog1.FileName))
                {
                    map = Serializer.Deserialize<Mapa>(file);
                    src = new Image<Gray, Byte>(map.printBW());
                    ibImagen.Image = src;
                }
            }
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            go = false;
        }

        private void ibImagen_MouseDown(object sender, MouseEventArgs e)
        {
            if (e.Button == MouseButtons.Left)
            {
                go = true;
                X = e.X;
                Y = e.Y;

                rect = new Rectangle(new Point(e.X, e.Y), new Size());
            }
        }

        private void ibImagen_MouseMove(object sender, MouseEventArgs e)
        {
            if (go)
            {

                if (X > e.X)
                {
                    rect.X = e.X;
                    rect.Width = X - rect.X;
                }
                else
                {
                    rect.X = X;
                    rect.Width = e.X - rect.X;
                }

                if (Y > e.Y)
                {
                    rect.Y = e.Y;
                    rect.Height = Y - rect.Y;
                }
                else
                {
                    rect.Y = Y;
                    rect.Height = e.Y - rect.Y;
                }
                if (rect.Width < rect.Height)
                {
                    if (e.X < X)
                        rect.X = X - rect.Width;
                    if (e.Y < Y)
                        rect.Y = Y - rect.Height;
                    rect.Height = rect.Width;
                }
                else
                {
                    if (e.X < X)
                        rect.X = X - rect.Width;
                    if (e.Y < Y)
                        rect.Y = Y - rect.Height;
                    rect.Width = rect.Height;
                }


                ibImagen.Refresh();
            }
        }

        private void ibImagen_Paint(object sender, PaintEventArgs e)
        {
            if (go)
            {
                Pen boli = Pens.Red;
                e.Graphics.DrawRectangle(boli, rect);
            }
        }

        private void ibImagen_MouseUp(object sender, MouseEventArgs e)
        {
            if (e.Button == MouseButtons.Left && go && rect.Height > 1 && rect.Width > 1 && rect.Size != new Size())
            {
                go = false;
                src.ROI = rect;
                srcCrop = new Image<Gray, Byte>(src.Width, src.Height);
                srcCrop = src.Copy();
                srcCrop= srcCrop.Resize(75, 75, Emgu.CV.CvEnum.INTER.CV_INTER_NN);

                /*Always Reset The region of intrest*/
                CvInvoke.cvResetImageROI(src);
                ibCrop.Image = srcCrop;
            }
            go = false;
        }
    }
}
