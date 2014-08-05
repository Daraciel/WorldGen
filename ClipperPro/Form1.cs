using DCMapLib;
using Emgu.CV;
using Emgu.CV.Structure;
using ProtoBuf;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Drawing.Imaging;
using System.IO;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace ClipperPro
{
    public partial class Form1 : Form
    {
        public Mapa map;
        private Rectangle rect, rectcrop;
        private bool go, go2;
        private Image<Gray, Byte> src;
        private Image<Gray, Byte> srcCrop;
        private int X, Y, X2, Y2;

        private DirectoryInfo[] dirs;

        public Form1()
        {
            InitializeComponent();
            dirs = new DirectoryInfo[6];
            dirs[0] = new DirectoryInfo("Bahias\\");
            dirs[1] = new DirectoryInfo("Peninsulas\\");
            dirs[2] = new DirectoryInfo("Cabos\\");
            dirs[3] = new DirectoryInfo("Canales\\");
            dirs[4] = new DirectoryInfo("Golfos\\");
            dirs[5] = new DirectoryInfo("Nada\\");
        }

        private void abrirImágenToolStripMenuItem_Click(object sender, EventArgs e)
        {
            ibImagen.FunctionalMode = Emgu.CV.UI.ImageBox.FunctionalModeOption.Minimum;
            ibCrop.FunctionalMode = Emgu.CV.UI.ImageBox.FunctionalModeOption.Minimum;
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

        private void radioButton1_CheckedChanged(object sender, EventArgs e)
        {

        }

        private void rbPen_Click(object sender, EventArgs e)
        {
            lblHelp.Text = (string)rbPen.Tag;
        }

        private void rbCabo_Click(object sender, EventArgs e)
        {
            lblHelp.Text = (string)rbCabo.Tag;
        }

        private void rbCan_Click(object sender, EventArgs e)
        {
            lblHelp.Text = (string)rbCan.Tag;
        }

        private void rbBahia_Click(object sender, EventArgs e)
        {
            lblHelp.Text = (string)rbBahia.Tag;
        }

        private void rbGolfo_Click(object sender, EventArgs e)
        {
            lblHelp.Text = (string)rbGolfo.Tag;
        }

        private void rbNada_Click(object sender, EventArgs e)
        {
            lblHelp.Text = (string)rbNada.Tag;
        }

        private void ibCrop_MouseDown(object sender, MouseEventArgs e)
        {

            if (e.Button == MouseButtons.Left)
            {
                go2 = true;
                X2 = e.X;
                Y2 = e.Y;

                rectcrop = new Rectangle(new Point(e.X, e.Y), new Size());
            }
        }

        private void ibCrop_MouseMove(object sender, MouseEventArgs e)
        {
            if (go2)
            {

                if (X2 > e.X)
                {
                    rectcrop.X = e.X;
                    rectcrop.Width = X2 - rectcrop.X;
                }
                else
                {
                    rectcrop.X = X2;
                    rectcrop.Width = e.X - rectcrop.X;
                }

                if (Y2 > e.Y)
                {
                    rectcrop.Y = e.Y;
                    rectcrop.Height = Y2 - rectcrop.Y;
                }
                else
                {
                    rectcrop.Y = Y2;
                    rectcrop.Height = e.Y - rectcrop.Y;
                }
                /*
                if (rectcrop.Width < rectcrop.Height)
                {
                    if (e.X < X2)
                        rectcrop.X = X2 - rectcrop.Width;
                    if (e.Y < Y2)
                        rectcrop.Y = Y2 - rectcrop.Height;
                    rectcrop.Height = rectcrop.Width;
                }
                else
                {
                    if (e.X < X2)
                        rectcrop.X = X2 - rectcrop.Width;
                    if (e.Y < Y2)
                        rectcrop.Y = Y2 - rectcrop.Height;
                    rectcrop.Width = rectcrop.Height;
                }
                */

                ibCrop.Refresh();
            }
        }

        private void ibCrop_Paint(object sender, PaintEventArgs e)
        {

            if (go2)
            {
                Pen boli = Pens.Green;
                e.Graphics.DrawRectangle(boli, rectcrop);
            }
        }

        private void ibCrop_MouseUp(object sender, MouseEventArgs e)
        {

            if (e.Button == MouseButtons.Left && go2 && rectcrop.Height > 1 && rectcrop.Width > 1 && rectcrop.Size != new Size())
            {
                go2 = false;
            }
            else
            {
                go2 = false;
                rectcrop = new Rectangle();
            }
            //go2 = false;
        }

        private void btnAgregar_Click(object sender, EventArgs e)
        {
            string tipo = "";
            string carpeta = "";
            if (rbPen.Checked)
            {
                tipo = "Peninsula";
                carpeta = "Peninsulas";
            }
            else if (rbGolfo.Checked)
            {
                tipo = "Golfo";
                carpeta = "Golfos";
            }
            else if (rbCan.Checked)
            {
                tipo = "Canal";
                carpeta = "Canales";
            }
            else if (rbBahia.Checked)
            {
                tipo = "Bahia";
                carpeta = "Bahias";
            }
            else if (rbCabo.Checked)
            {
                tipo = "Cabo";
                carpeta = "Cabos";
            }
            else
            {
                tipo = "Falso";
                carpeta = "Nada";
            }
            string archivo = carpeta + "\\" + tipo + "_" + DateTime.Now.ToString("yyyyMMddHHmmss") + ".jpg";
            try
            {
                saveJpeg(archivo, ibCrop.Image.Bitmap, 100);
                string linea = archivo+" 1 ";
                if (rbNada.Checked)
                    linea = archivo;
                else
                {
                    if (rectcrop.Size != new Rectangle().Size)
                        linea += rectcrop.X + " " + rectcrop.Y + " " + (rectcrop.X + rectcrop.Width) + " " + (rectcrop.Y + rectcrop.Height);
                    else
                        linea += "0 0 " + ibCrop.Image.Bitmap.Width + " " + ibCrop.Image.Bitmap.Height;
                }
                File.AppendAllText(tipo+"s.info", linea + Environment.NewLine);
            }
            catch(Exception ex)
            {
                MessageBox.Show("La operación de cropeado ha fallado. El motivo es:" + Environment.NewLine+ex.Message);
            }
        }

        private void saveJpeg(string path, Bitmap img, long quality)
        {
            // Encoder parameter for image quality

            EncoderParameter qualityParam = new EncoderParameter(System.Drawing.Imaging.Encoder.Quality, quality);

            // Jpeg image codec
            ImageCodecInfo jpegCodec = this.getEncoderInfo("image/jpeg");

            if (jpegCodec == null)
                return;

            EncoderParameters encoderParams = new EncoderParameters(1);
            encoderParams.Param[0] = qualityParam;

            img.Save(path, jpegCodec, encoderParams);
        }

        private ImageCodecInfo getEncoderInfo(string mimeType)
        {
            // Get image codecs for all image formats
            ImageCodecInfo[] codecs = ImageCodecInfo.GetImageEncoders();

            // Find the correct image codec
            for (int i = 0; i < codecs.Length; i++)
                if (codecs[i].MimeType == mimeType)
                    return codecs[i];
            return null;
        }

        private void VaciarDirectorio(DirectoryInfo directorio)
        {
            foreach (System.IO.FileInfo file in directorio.GetFiles()) 
                file.Delete();
            foreach (System.IO.DirectoryInfo subDirectory in directorio.GetDirectories()) 
                subDirectory.Delete(true);
        }

        private void vaciarFicheroBahíasToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if(DialogResult.Yes == MessageBox.Show("Esto eliminará todo el contenido de bahías", "Eliminar contenido",MessageBoxButtons.YesNo))
                VaciarDirectorio(dirs[0]);
        }

        private void vaciarFicheroPenínsulasToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (DialogResult.Yes == MessageBox.Show("Esto eliminará todo el contenido de penínsulas", "Eliminar contenido", MessageBoxButtons.YesNo))
                VaciarDirectorio(dirs[1]);
        }

        private void vaciarFicheroCabosToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (DialogResult.Yes == MessageBox.Show("Esto eliminará todo el contenido de cabos", "Eliminar contenido", MessageBoxButtons.YesNo))
                VaciarDirectorio(dirs[2]);
        }

        private void vaciarFicheroCanalesToolStripMenuItem_Click(object sender, EventArgs e)
        {

            if (DialogResult.Yes == MessageBox.Show("Esto eliminará todo el contenido de canales", "Eliminar contenido", MessageBoxButtons.YesNo))
                VaciarDirectorio(dirs[3]);
        }

        private void vaciarFicheroGolfosToolStripMenuItem_Click(object sender, EventArgs e)
        {

            if (DialogResult.Yes == MessageBox.Show("Esto eliminará todo el contenido de golfos", "Eliminar contenido", MessageBoxButtons.YesNo))
                VaciarDirectorio(dirs[4]);
        }

        private void vaciarTodosToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (DialogResult.Yes == MessageBox.Show("Esto eliminará todo el contenido de negativos", "Eliminar contenido", MessageBoxButtons.YesNo))
                VaciarDirectorio(dirs[5]);
        }

        private void vaciarTodosToolStripMenuItem1_Click(object sender, EventArgs e)
        {
            if (DialogResult.Yes == MessageBox.Show("Esto eliminará todo el contenido de todas las carpetas", "Eliminar contenido", MessageBoxButtons.YesNo))
                foreach(DirectoryInfo d in dirs)
                    VaciarDirectorio(d);
        }

        private void crearArchivoDeEjemplosToolStripMenuItem_Click(object sender, EventArgs e)
        {
            CrearVector cv = new CrearVector();
            cv.ShowDialog(this);
        }


    }
}
