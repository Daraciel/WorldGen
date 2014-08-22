using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using DCMaplib;

namespace GUISparks
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            int w, h, c, p;
            int.TryParse(nudAlto.Value.ToString(), out h);
            int.TryParse(nudAncho.Value.ToString(), out w);
            int.TryParse(nudSparks.Value.ToString(), out c);
            int.TryParse(nudTierra.Value.ToString(), out p);

            MapSparks m = new MapSparks(w, h, c, p);
            m.Domap();
            m.setBMP();
            pbMapa.Image = m.img;
        }
    }
}
