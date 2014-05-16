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

namespace WorldGen
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }
        public Mapa map;

        private void button1_Click(object sender, EventArgs e)
        {
            map = new Mapa(Convert.ToInt32(nudW.Value), Convert.ToInt32(nudH.Value), tbS.Text);
            map.Latitude = double.Parse(tbLat.Text);
            map.Longitude = double.Parse(tbLong.Text);
            map.Scale = double.Parse(tbScale.Text);

            map.LoadColorFile(((KeyValuePair<string, string>)cbSchema.SelectedItem).Value);

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
            //map.etiquetarDebug();
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
    }
}
