using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;

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
            map = new Mapa(Convert.ToInt32(nudW.Value), Convert.ToInt32(nudH.Value), double.Parse(tbS.Text));
            map.Latitude = double.Parse(tbLat.Text);
            map.Longitude = double.Parse(tbLong.Text);
            map.Scale = double.Parse(tbScale.Text);

            map.LoadColorFile(((KeyValuePair<string, string>)cbSchema.SelectedItem).Value);

            map.SaveColMap();
            
            //map.Mercador();

            map.Mollweide();
            
            //map.MakeHeightMap();
           // map.Save();
            //map.printBMP();
            pbMapa.Image = map.printBMP2();
            //int i = 3;
        }
        private void inicializarCB()
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

        private void Form1_Load(object sender, EventArgs e)
        {
            inicializarCB();
        }

        private void tbLat_KeyPress(object sender, KeyPressEventArgs e)
        {

            if (tbLat.Text.Contains(','))
            {
                if (!char.IsDigit(e.KeyChar))
                {
                    e.Handled = true;
                }
            }
            else
            {
                if (!char.IsDigit(e.KeyChar))
                {
                    e.Handled = true;
                }
                else if (e.KeyChar == ',')
                {
                    e.Handled = false;
                }

            }

            if (e.KeyChar == '\b')
                e.Handled = false;
        }

        private void tbLong_KeyPress(object sender, KeyPressEventArgs e)
        {

            if (tbLong.Text.Contains(','))
            {
                if (!char.IsDigit(e.KeyChar))
                {
                    e.Handled = true;
                }
            }
            else
            {
                if (!char.IsDigit(e.KeyChar))
                {
                    e.Handled = true;
                }
                else if (e.KeyChar == ',')
                {
                    e.Handled = false;
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
                if (!char.IsDigit(e.KeyChar))
                {
                    e.Handled = true;
                }
                else if (e.KeyChar == ',')
                {
                    e.Handled = false;
                }

            }

            if (e.KeyChar == '\b')
                e.Handled = false;
        }
    }
}
