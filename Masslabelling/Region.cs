﻿using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;

namespace Masslabelling
{
    public class Region
    {
        private string _Nombre;

        public string Nombre
        {
            get { return _Nombre; }
            set { _Nombre = value; }
        }
        private TIPOREGION _Tipo;

        public TIPOREGION Tipo
        {
            get { return _Tipo; }
            set { _Tipo = value; }
        }


        private double _Area;

        public double Area
        {
            get { return _Area; }
            set { _Area = value; }
        }
        private Rectangle _Marco;

        public Rectangle Marco
        {
            get { return _Marco; }
            set { _Marco = value; }
        }
        private double _Perimetro;

        public double Perimetro
        {
            get { return _Perimetro; }
            set { _Perimetro = value; }
        }
        private int _NumVertices;

        public int NumVertices
        {
            get { return _NumVertices; }
            set {
                    _NumVertices = value;
                    _Vertices = new Point[NumVertices];
                }
        }
        private Point[] _Vertices;

        public Point[] Vertices
        {
            get { return _Vertices; }
            set { _Vertices = value; }
        }

        private List<Region> _Hijos;

        public List<Region> Hijos
        {
            get { return _Hijos; }
            set { _Hijos = value; }
        }

    }

    public enum TIPOREGION
    {
        TIERRA,
        AGUA,
        MAPA
    }
}
