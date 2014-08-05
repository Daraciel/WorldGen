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
    public partial class CrearVector : Form
    {
        public CrearVector()
        {
            InitializeComponent();
        }

        private void btnGO_Click(object sender, EventArgs e)
        {
            if (cbPen.Checked)
                CreateSampleFile("Peninsulas", Int32.Parse(nudAlto.Value.ToString()), Int32.Parse(nudAncho.Value.ToString()), Int32.Parse(nudCant.Value.ToString()), cbDist.Checked, cbShow.Checked);
        }

        private void CreateSampleFile(string output, int alto, int ancho, int cant, bool dist, bool show)
        {//opencv_createsamples   -img   source.png   -num   10  -bg negatives.dat -vec samples_out.vec -show
            string mostrar = "";
            ProcessStartInfo startInfo = new ProcessStartInfo();
            //startInfo.CreateNoWindow = false;
            startInfo.UseShellExecute = false;
            startInfo.FileName = "x64\\opencv_createsamples.exe";
            startInfo.WindowStyle = ProcessWindowStyle.Hidden;
            if (show)
                mostrar = " -show";
            if (dist)
            {
                if (File.Exists("Nada\\Falsos.info"))
                {
                    startInfo.Arguments = "-info " + output + "\\" + output + ".info -num " + cant + " -bg Nada\\Falsos.info -vec Ejemplos\\" + output + "_out.vec " + "-w " + ancho + " -h " + alto + mostrar;
                }
                else
                    MessageBox.Show("No se ha podido crear el fichero de negativos. Créalo primero por favor");
            }
            else
                startInfo.Arguments = "-info " + output + "\\" + output + ".info -num " + cant + " -vec Ejemplos\\" + output + "_out.vec " + "-w " + ancho + " -h " + alto + mostrar;
            try
            {
                using (Process exeProcess = Process.Start(startInfo))
                {
                    exeProcess.WaitForExit();
                }
            }
            catch(Exception ex)
            {
                MessageBox.Show("Ha ocurrido un error: "+ex.Message);
            }
        }
    }
}
