using ProtoBuf;
using ProtoBuf.Meta;
using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;

namespace Masslabelling
{
    [ProtoContract(SkipConstructor = true)]
    public class Region
    {

        private string _Nombre;

        [ProtoMember(1)]
        public string Nombre
        {
            get { return _Nombre; }
            set { _Nombre = value; }
        }

        private TIPOREGION _Tipo;

        [ProtoMember(2)]
        public TIPOREGION Tipo
        {
            get { return _Tipo; }
            set { _Tipo = value; }
        }

        private TIPOTAMANO _tipotam;

        [ProtoMember(3)]
        public TIPOTAMANO Tipotam
        {
            get { return _tipotam; }
            set { _tipotam = value; }
        }

        private double _Area;

        [ProtoMember(4)]
        public double Area
        {
            get { return _Area; }
            set { _Area = value; }
        }

        private Rectangulo _Marco;

        [ProtoMember(5)]
        public Rectangulo Marco
        {
            get { return _Marco; }
            set { _Marco = value; }
        }

        private double _Perimetro;

        [ProtoMember(6)]
        public double Perimetro
        {
            get { return _Perimetro; }
            set { _Perimetro = value; }
        }

        private int _NumVertices;

        [ProtoMember(7)]
        public int NumVertices
        {
            get { return _NumVertices; }
            set {
                    _NumVertices = value;
                    _Vertices = new Point[NumVertices];
                }
        }

        //[ProtoMember(8)]
        public Color Col
        {
            get { return _Col; }
            set { 
                    _Col = value;
                    _Alpha = _Col.A;
                    _R = _Col.R;
                    _G = _Col.G;
                    _B = _Col.B;
                }
        }

        private byte _Alpha;

        [ProtoMember(8)]
        public byte Alpha
        {
            get { return _Alpha; }
            set { 
                    _Alpha = value;
                    _Col = Color.FromArgb(_Alpha, _R, _G, _B);
                }
        }

        private byte _R;

        [ProtoMember(9)]
        public byte R
        {
            get { return _R; }
            set
            {
                _R = value;
                _Col = Color.FromArgb(_Alpha, _R, _G, _B);
            }
        }

        private byte _G;

        [ProtoMember(10)]
        public byte G
        {
            get { return _G; }
            set
            {
                _G = value;
                _Col = Color.FromArgb(_Alpha, _R, _G, _B);
            }
        }

        private byte _B;

        [ProtoMember(11)]
        public byte B
        {
            get { return _B; }
            set
            {
                _B = value;
                _Col = Color.FromArgb(_Alpha, _R, _G, _B);
            }
        }

        private Point[] _Vertices;

        [ProtoMember(12, OverwriteList = true)]
        public Point[] Vertices
        {
            get { return _Vertices; }
            set { _Vertices = value; }
        }

        private Point _Centroide;
        public Point Centroide
        {
            get { return _Centroide; }
            set { _Centroide = value; }
        }

        private HashSet<Region> _Hijos;

        [ProtoMember(13)]
        public HashSet<Region> Hijos
        {
            get { return _Hijos; }
            set { _Hijos = value; }
        }

        private Color _Col;

        public Point SetCentroide()
        {
            float accumulatedArea = 0.0f;
            float centerX = 0.0f;
            float centerY = 0.0f;

            for (int i = 0, j = _NumVertices - 1; i < _NumVertices; j = i++)
            {
                float temp = Vertices[i].X * Vertices[j].Y - Vertices[j].X * Vertices[i].Y;
                accumulatedArea += temp;
                centerX += (Vertices[i].X + Vertices[j].X) * temp;
                centerY += (Vertices[i].Y + Vertices[j].Y) * temp;
            }

            if (accumulatedArea < 1E-7f)
                return Point.Empty;  // Avoid division by zero

            accumulatedArea *= 3f;
            _Centroide = new Point((int)(centerX / accumulatedArea), (int)(centerY / accumulatedArea));
            return _Centroide;
        }

    }

    public enum TIPOREGION
    {
        TIERRA,
        AGUA,
        MAPA
    }

    public enum TIPOTAMANO
    {
        CONTINENTE,
        ISLA,
        ISLOTE,
        OCEANO,
        MAR
    }
}
