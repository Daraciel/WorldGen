﻿using System;
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
            map.Mercador();
            
            map.SaveColMap();
            //map.MakeHeightMap();
           // map.Save();
            map.printBMP();
            //int i = 3;
        }
    }
}
