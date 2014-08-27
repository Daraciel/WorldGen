using DCMaplib;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace GCGUI
{
    public partial class Form1 : Form
    {

        private MapGC map;

        public Form1()
        {
            InitializeComponent();
        }

        private void numericUpDown1_ValueChanged(object sender, EventArgs e)
        {

        }

        private void label4_Click(object sender, EventArgs e)
        {

        }

        private void btnGO_Click(object sender, EventArgs e)
        {

            int w, h, i, p, s;
            Int32.TryParse(nudAncho.Value.ToString(), out w);
            Int32.TryParse(nudAlto.Value.ToString(), out h);
            Int32.TryParse(nudAgua.Value.ToString(), out p);
            Int32.TryParse(nudIteraciones.Value.ToString(), out i);
            Int32.TryParse(tbSemilla.Text, out s);

            map = new MapGC(w, h, i, s, p);
            map.Hacermapa();
            pbMapa.Image = map.printBMP();
        }
    }
}
