using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using Emgu.CV;
using Emgu.CV.Structure;
using System.IO;
using System.Threading.Tasks;
using Emgu.CV.CvEnum;
using Masslabelling;
using ProtoBuf;
using ProtoBuf.Meta;
using DCMapLib;

namespace WorldGen
{
    public partial class Form1 : Form
    {
        Masslabelling.Region poligono;
        private CascadeClassifier clasificadorPeninsulas, clasificadorBahias;

        public Form1()
        {
            RuntimeTypeModel.Default.Add(typeof(System.Drawing.Point), false).Add("X", "Y");
            RuntimeTypeModel.Default.Add(typeof(System.Drawing.Color), false).Add("A", "R", "G","B");
            InitializeComponent();
        }


        public Mapa map;

        private void button1_Click(object sender, EventArgs e)
        {
            map = new Mapa(Convert.ToInt32(nudW.Value), Convert.ToInt32(nudH.Value), tbS.Text);
            map.Latitude = double.Parse(tbLat.Text);
            map.Longitude = double.Parse(tbLong.Text);
            map.Scale = double.Parse(tbScale.Text);
            map.ColorFile = ((KeyValuePair<string, string>)cbSchema.SelectedItem).Value;

            //map.SaveColMap();
            
            //map.Mercador();
            int proj = ((KeyValuePair<string, int>)cbProyecciones.SelectedItem).Value;

            switch (proj)
            {
                case 0:
                    map.Mercador();
                    break;
                case 1:
                    map.Mollweide();
                    break;
                default:
                    map.Mercador();
                    break;
            }

            //map.Mollweide();
            
            //map.MakeHeightMap();
           // map.Save();
            //map.printBMP();
            pbMapa.Image = map.printBMP2();
            //int i = 3;
        }
        private void inicializarCBSchemas()
        {
            cbSchema.DisplayMember = "Key";
            cbSchema.ValueMember = "Value";
            cbSchema.Items.Add(new KeyValuePair<string, string>("Burrows", "./Schemas/burrows.col"));
            cbSchema.Items.Add(new KeyValuePair<string, string>("BurrowsB", "./Schemas/burrowsB.col"));
            cbSchema.Items.Add(new KeyValuePair<string, string>("default", "./Schemas/default.col"));
            cbSchema.Items.Add(new KeyValuePair<string, string>("defaultB", "./Schemas/defaultB.col"));
            cbSchema.Items.Add(new KeyValuePair<string, string>("Lefebvre", "./Schemas/Lefebvre.col"));
            cbSchema.Items.Add(new KeyValuePair<string, string>("Lefebvre2", "./Schemas/Lefebvre2.col"));
            cbSchema.Items.Add(new KeyValuePair<string, string>("Mars", "./Schemas/mars.col"));
            cbSchema.Items.Add(new KeyValuePair<string, string>("Olsson", "./Schemas/Olsson.col"));
            cbSchema.Items.Add(new KeyValuePair<string, string>("White", "./Schemas/white.col"));
            cbSchema.Items.Add(new KeyValuePair<string, string>("Wood", "./Schemas/wood.col"));
            cbSchema.Items.Add(new KeyValuePair<string, string>("Yellow", "./Schemas/yellow.col"));
        }

        private void inicializarCBProyecciones()
        {
            cbProyecciones.DisplayMember = "Key";
            cbProyecciones.ValueMember = "Value";
            cbProyecciones.Items.Add(new KeyValuePair<string, int>("Mercador", 0));
            cbProyecciones.Items.Add(new KeyValuePair<string, int>("Mollweide", 1));
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            inicializarCBSchemas();
            inicializarCBProyecciones();
            cbSchema.SelectedIndex = 7;
            cbProyecciones.SelectedIndex = 0;
        }

        private void tbLat_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (tbLat.Text.Contains('-'))
            {
                if (e.KeyChar == '-')
                {
                    e.Handled = true;
                    return;
                }
            }
            else
            {
                if (e.KeyChar == '-')
                {
                    e.Handled = false;
                    return;
                }
            }


            if (tbLat.Text.Contains(','))
            {
                if (!char.IsDigit(e.KeyChar))
                {
                    e.Handled = true;
                }
            }
            else
            {
                if (e.KeyChar == ',')
                {
                    e.Handled = false;
                }
                else if (!char.IsDigit(e.KeyChar))
                {
                    e.Handled = true;
                }

            }

            if (e.KeyChar == '\b')
                e.Handled = false;
        }

        private void tbLong_KeyPress(object sender, KeyPressEventArgs e)
        {

            if (tbLong.Text.Contains('-'))
            {
                if (e.KeyChar == '-')
                {
                    e.Handled = true;
                    return;
                }
            }
            else
            {
                if (e.KeyChar == '-')
                {
                    e.Handled = false;
                    return;
                }
            }


            if (tbLong.Text.Contains(','))
            {
                if (!char.IsDigit(e.KeyChar))
                {
                    e.Handled = true;
                }
            }
            else
            {
                if (e.KeyChar == ',')
                {
                    e.Handled = false;
                }
                else if (!char.IsDigit(e.KeyChar))
                {
                    e.Handled = true;
                }

            }

            if (e.KeyChar == '\b')
                e.Handled = false;
        }

        private void tbScale_KeyPress(object sender, KeyPressEventArgs e)
        {

            if (tbScale.Text.Contains(','))
            {
                if (!char.IsDigit(e.KeyChar))
                {
                    e.Handled = true;
                }
            }
            else
            {
                if (e.KeyChar == ',')
                {
                    e.Handled = false;
                }
                else if (!char.IsDigit(e.KeyChar))
                {
                    e.Handled = true;
                }

            }

            if (e.KeyChar == '\b')
                e.Handled = false;
        }

        private void button2_Click(object sender, EventArgs e)
        {
            //map = new Mapa(100, 100, "0.123");
            if (cbMasa.Checked)
            {
                pbMapa.Image = map.etiquetarDebug().ToBitmap();

                tvAccidentes.Nodes.Clear();
                foreach (Masslabelling.Region R in map.Regiones)
                {
                    tvAccidentes.Nodes.Add(fillTree(R));
                }
            }
            if (cbForma.Checked)
            {
                clasificadorBahias = new CascadeClassifier("Clasificadores\\Bahias.xml");
                Bitmap bmp = map.printBW();
                Image<Gray,byte> image = new Image<Gray,byte>(bmp);
                Image<Bgr,byte> img = new Image<Bgr,byte>(bmp);
                Rectangle[] rectangles = clasificadorBahias.DetectMultiScale(image, 1.4, 10, new Size(24,24), new Size(50,50));
                foreach (Rectangle r in rectangles)
                {
                    img.Draw(r, new Bgr(Color.Cyan), 1);
                }
                pbMapa.Image = img.ToBitmap();
            }
        }

        private void nSGuardar_Click(object sender, EventArgs e)
        {
            SaveFileDialog saveFileDialog1 = new SaveFileDialog();

            saveFileDialog1.Filter = "bmp files (*.bmp)|*.bmp";
            saveFileDialog1.FilterIndex = 2;
            saveFileDialog1.RestoreDirectory = true;

            if (saveFileDialog1.ShowDialog() == DialogResult.OK)
            {

                if (map.printBMP(saveFileDialog1.FileName))
                {
                    MessageBox.Show("Guardao!");
                }
            }
        }

        private TreeNode fillTree(Masslabelling.Region R)
        {
            TreeNode tn = new TreeNode();

            tn.Name = R.Nombre;
            tn.Text = R.Nombre;
            if((R.Hijos!=null) && (R.Hijos.Count>0))
                foreach (Masslabelling.Region h in R.Hijos)
                {
                    tn.Nodes.Add(fillTree(h));
                }

            return tn;
        }

        private void trbLat_ValueChanged(object sender, EventArgs e)
        {
            tbLat.Text = trbLat.Value.ToString();
        }

        private void trbLong_ValueChanged(object sender, EventArgs e)
        {
            tbLong.Text = trbLong.Value.ToString();
        }

        private void tbLat_TextChanged(object sender, EventArgs e)
        {
            int val;
            bool can = int.TryParse(tbLat.Text,out val);
            if (can)
            {
                if (val > trbLat.Maximum)
                    trbLat.Value = trbLat.Maximum;
                else if (val < trbLat.Minimum)
                    trbLat.Value = trbLat.Minimum;
                else
                    trbLat.Value = val;
            }
            else
                trbLat.Value = 0;
        }

        private void tbLong_TextChanged(object sender, EventArgs e)
        {
            int val;
            bool can = int.TryParse(tbLong.Text,out val);
            if (can)
            {
                if (val > trbLong.Maximum)
                    trbLong.Value = trbLong.Maximum;
                else if (val < trbLong.Minimum)
                    trbLong.Value = trbLong.Minimum;
                else
                    trbLong.Value = val;
            }
            else
                trbLong.Value = 0;
        }

        private void guardarMapaToolStripMenuItem_Click(object sender, EventArgs e)
        {
            SaveFileDialog saveFileDialog1 = new SaveFileDialog();

            saveFileDialog1.Filter = "Ficheros DCM (*.dcm)|*.dcm";
            saveFileDialog1.FilterIndex = 2;
            saveFileDialog1.RestoreDirectory = true;

            if (saveFileDialog1.ShowDialog() == DialogResult.OK)
            {

                if (map.Salvar(saveFileDialog1.FileName))
                    MessageBox.Show("Guardao!");
                else
                    MessageBox.Show("Error!");

            }
        }

        private void cargarMapaToolStripMenuItem_Click(object sender, EventArgs e)
        {
            OpenFileDialog openFileDialog1 = new OpenFileDialog();
            openFileDialog1.Filter = "Ficheros DCM (*.dcm)|*.dcm";
            if (openFileDialog1.ShowDialog() == DialogResult.OK)
            {
                using (var file = File.OpenRead(openFileDialog1.FileName))
                {
                    map = Serializer.Deserialize<Mapa>(file);
                    pbMapa.Image = map.printBW();
                    if (map.Regiones == null)
                        map.Regiones = new HashSet<Masslabelling.Region>();
                    else
                        foreach (Masslabelling.Region R in map.Regiones)
                        {
                            tvAccidentes.Nodes.Add(fillTree(R));
                        }
                    tbS.Text = map.Semilla;
                }
            }

        }

        private void btnMostrar_Click(object sender, EventArgs e)
        {
            MCvFont fuente = new MCvFont(FONT.CV_FONT_HERSHEY_COMPLEX_SMALL, 0.5, 0.5);
            Emgu.CV.Image<Bgr, Byte> b;
            if (rbMapaColor.Checked)
                b = new Emgu.CV.Image<Bgr, Byte>(map.printBMP2());
            else
                b = new Emgu.CV.Image<Bgr, Byte>(map.printBW());

            Parallel.ForEach(map.Regiones, region =>
                {
                    if( (region.Tipo==TIPOREGION.TIERRA) &&
                        ((region.Tipotam==TIPOTAMANO.CONTINENTE && cbContinentes.Checked) || 
                         (region.Tipotam==TIPOTAMANO.ISLA && cbIslas.Checked) || 
                         (region.Tipotam==TIPOTAMANO.ISLOTE && cbIslotes.Checked)))
                    {
                        if(rbShowRect.Checked)
                            b.Draw(region.Marco.ToRect(), new Bgr(region.Col), 2);
                        else
                            b.DrawPolyline(region.Vertices, true, new Bgr(region.Col), 1);
                    
                        if(cbShowNames.Checked)
                            b.Draw(region.Nombre, ref fuente, region.Marco.Location, new Bgr(region.Col));
                    }
                    
                });
            pbMapa.Image = b.ToBitmap();
        }

        private void tvAccidentes_NodeMouseDoubleClick(object sender, TreeNodeMouseClickEventArgs e)
        {
            Stack<string> nodos = new Stack<string>();
            TreeNode nodo = e.Node;
            nodos.Push(nodo.Name);
            if (nodo.Parent != null)
            {
                nodo = nodo.Parent;
                nodos.Push(nodo.Name);
            }
            string peek;
            bool find = false, find2 = false;
            HashSet<Masslabelling.Region> reg = map.Regiones;
            Masslabelling.Region sal = new Masslabelling.Region() ;
            while (nodos.Count > 0)
            {
                peek = nodos.Pop();
                for (int i = 0; i < reg.Count && !find; i++)
                {
                    sal = reg.ElementAt(i);
                    if (sal.Nombre == peek)
                    {
                        find = true;
                        if (sal.Hijos != null && sal.Hijos.Count > 0)
                        {
                            reg = sal.Hijos;
                        }
                    }
                }
            }
            poligono = sal;
            pbMapa.Refresh();

           
        }

        private void pbMapa_Paint(object sender, PaintEventArgs e)
        {
            if (poligono != null)
            {
                Pen boli = new Pen(poligono.Col, 1.0f);
                e.Graphics.DrawPolygon(boli, poligono.Vertices);
            }
        }

        private void tvAccidentes_AfterSelect(object sender, TreeViewEventArgs e)
        {
            //poligono = null;
        }


    }
}
