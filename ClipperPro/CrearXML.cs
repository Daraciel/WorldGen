using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Diagnostics;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace ClipperPro
{
    public partial class CrearXML : Form
    {
        public CrearXML()
        {
            InitializeComponent();
        }

        private void cbPen_CheckedChanged(object sender, EventArgs e)
        {
            if (cbPen.Checked)
            {
                tbPen.Enabled = true;
                btnPen.Enabled = true;
            }
            else
            {
                tbPen.Enabled = false;
                btnPen.Enabled = false;
            }
        }

        private void btnPen_Click(object sender, EventArgs e)
        {
            OpenFileDialog openFileDialog1 = new OpenFileDialog();
            openFileDialog1.Filter = "Vectores (*.vec)|*.vec";
            if (openFileDialog1.ShowDialog() == DialogResult.OK)
            {
                tbPen.Text = openFileDialog1.FileName;
            }
        }

        private void btnCabos_Click(object sender, EventArgs e)
        {
            OpenFileDialog openFileDialog1 = new OpenFileDialog();
            openFileDialog1.Filter = "Vectores (*.vec)|*.vec";
            if (openFileDialog1.ShowDialog() == DialogResult.OK)
            {
                tbCabos.Text = openFileDialog1.FileName;
            }
        }

        private void btnBahias_Click(object sender, EventArgs e)
        {

            OpenFileDialog openFileDialog1 = new OpenFileDialog();
            openFileDialog1.Filter = "Vectores (*.vec)|*.vec";
            if (openFileDialog1.ShowDialog() == DialogResult.OK)
            {
                tbBahias.Text = openFileDialog1.FileName;
            }
        }

        private void btnGolfos_Click(object sender, EventArgs e)
        {

            OpenFileDialog openFileDialog1 = new OpenFileDialog();
            openFileDialog1.Filter = "Vectores (*.vec)|*.vec";
            if (openFileDialog1.ShowDialog() == DialogResult.OK)
            {
                tbGolfos.Text = openFileDialog1.FileName;
            }
        }

        private void btnCanales_Click(object sender, EventArgs e)
        {

            OpenFileDialog openFileDialog1 = new OpenFileDialog();
            openFileDialog1.Filter = "Vectores (*.vec)|*.vec";
            if (openFileDialog1.ShowDialog() == DialogResult.OK)
            {
                tbCanales.Text = openFileDialog1.FileName;
            }
        }

        private void cbCabos_CheckedChanged(object sender, EventArgs e)
        {
            if (cbCabos.Checked)
            {
                tbCabos.Enabled = true;
                btnCabos.Enabled = true;
            }
            else
            {
                tbCabos.Enabled = false;
                btnCabos.Enabled = false;
            }
        }

        private void cbBahias_CheckedChanged(object sender, EventArgs e)
        {
            if (cbBahias.Checked)
            {
                tbBahias.Enabled = true;
                btnBahias.Enabled = true;
            }
            else
            {
                tbBahias.Enabled = false;
                btnBahias.Enabled = false;
            }
        }

        private void cbGolfos_CheckedChanged(object sender, EventArgs e)
        {
            if (cbGolfos.Checked)
            {
                tbGolfos.Enabled = true;
                btnGolfos.Enabled = true;
            }
            else
            {
                tbGolfos.Enabled = false;
                btnGolfos.Enabled = false;
            }
        }

        private void cbCanales_CheckedChanged(object sender, EventArgs e)
        {
            if (cbCanales.Checked)
            {
                tbCanales.Enabled = true;
                btnCanales.Enabled = true;
            }
            else
            {
                tbCanales.Enabled = false;
                btnCanales.Enabled = false;
            }
        }

        private void btnAprender_Click(object sender, EventArgs e)
        {
            int alto = Int32.Parse(nudAlto.Value.ToString());
            int ancho = Int32.Parse(nudAncho.Value.ToString());
            int stages = Int32.Parse(nudStages.Value.ToString());
            int positivos = Int32.Parse(nudPos.Value.ToString());
            int negativos = Int32.Parse(nudNeg.Value.ToString());
            float minhitrate = float.Parse(tbMHR.Text);
            float maxalarmrate = float.Parse(tbMAR.Text);
            string clas;
            if (rbDAB.Checked)
                clas = "DAB";
            else if (rbGAB.Checked)
                clas = "GAB";
            else if (rbLB.Checked)
                clas = "LB";
            else
                clas = "RAB";

            string featureType;
            if (rbHAAR.Checked)
                featureType = "HAAR";
            else
                featureType = "LBP";

            string call = "-data Clasificadores\\ -vec ";

            string call2 = " -bg Nada\\Falsos.info -numPos " + positivos + " -numNeg " + negativos + " -numStages " + stages + " -featureType " + featureType + " -w " + ancho + " -h " + alto;
            if(positivos>2000)
                call2 += " -minHitRate " + minhitrate + " -maxFalseAlarmRate " + maxalarmrate;

            if (cbPen.Checked)
                Learn(call, call2, "", tbPen.Text);
            if (cbBahias.Checked)
                Learn(call, call2, "", tbBahias.Text);
            //-data imgs/cascade/ -vec imgs/vector.vec -bg imgs/negat.dat -numPos 1900 
            //-numNeg 900 -numStages 12  -featureType HAAR -minHitRate 0.999 -maxFalseAlarmRate 0.5 -w 24 -h 30
        }


        private void Learn(string call, string call2, string nombre, string archivo)
        {
            ProcessStartInfo startInfo = new ProcessStartInfo();
            //startInfo.CreateNoWindow = false;
            startInfo.UseShellExecute = false;
            startInfo.FileName = "x64\\opencv_traincascade.exe";
            startInfo.WindowStyle = ProcessWindowStyle.Normal;
            if (File.Exists(archivo))
            {
                startInfo.Arguments = call + archivo + call2;
                try
                {
                    using (Process exeProcess = Process.Start(startInfo))
                    {
                        exeProcess.WaitForExit();
                    }
                }
                catch (Exception ex)
                {
                    MessageBox.Show("Ha ocurrido un error: " + ex.Message);
                }
            }
            else
                MessageBox.Show("No se ha podido crear el fichero de negativos. Créalo primero por favor");
        }
    }
}
