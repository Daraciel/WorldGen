using DCMaplib;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace PerlinGUI
{
    public partial class Form1 : Form
    {
        private PerlinMap map;
        public Form1()
        {
            InitializeComponent();
        }

        private void btnGo_Click(object sender, EventArgs e)
        {
            tvOctavas.Nodes.Clear();

            int w, h, o,s;
            Int32.TryParse(nudAncho.Value.ToString(), out w);
            Int32.TryParse(nudAlto.Value.ToString(), out h);
            Int32.TryParse(nudOctavas.Value.ToString(), out o);
            float a;
            float p;
            float.TryParse(nudAmplitud.Value.ToString(), out a);
            float.TryParse(tbPersistencia.Text, out p);
            if(!Int32.TryParse(tbSemilla.Text, out s))
                map = new PerlinMap(w, h, a, p, o);
            else
                map = new PerlinMap(w, h, a, p, o, s);
            for (int i = 0; i < o; i++)
            {
                int num = i + 1;
                tvOctavas.Nodes.Add("Octava " + num);
            }
            tvOctavas.Nodes.Add("Resultado final");
            pbMapa.Image = map.DoPerlin();
        }

        private void tvOctavas_NodeMouseDoubleClick(object sender, TreeNodeMouseClickEventArgs e)
        {
            pbMapa.Image = map.GetOctava(e.Node.Index);
        }
    }
}
