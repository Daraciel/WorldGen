using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Serialization;

namespace WorldGen
{
    public class Capa
    {
        private TIPOCAPA _Tipo;

        public TIPOCAPA Tipo
        {
            get { return _Tipo; }
            set { _Tipo = value; }
        }

        private int[] _Valores;

        public int[] Valores
        {
            get { return _Valores; }
            set { _Valores = value; }
        }

        private int _Width;

        public int Width
        {
            get { return _Width; }
            set { 
                    _Width = value;
                    if (_Height != null && _Width != null)
                        Inicializar();
                }
        }

        private int _Height;

        public int Height
        {
            get { return _Height; }
            set { 
                    _Height = value;
                    if (_Height != null && _Width != null)
                        Inicializar();
                }
        }
        /*
        public int[][] Vals
        {
            get
            {
                int[][] Vals = new int[Width][];
                for (int i = 0; i < Width; i++)
                {
                    Vals[i] = new int[Height];
                    for (int j = 0; j < Height; j++)
                    {
                        Vals[i][j] = _Valores[i, j];
                    }
                }
                return Vals;
            }
            set
            {
                for (int i = 0; i < Width; i++)
                {
                    for (int j = 0; j < Height; j++)
                    {
                        _Valores[i, j] = Vals[i][j];
                    }
                }
            }
        }
        */
        
        
        public Capa()
        {
        }

        public void Inicializar()
        {
            _Valores = new int[_Width*_Height];
        }

        public Capa(TIPOCAPA c, int w, int h)
        {
            Tipo = c;
            _Width = w;
            _Height = h;
            Inicializar();
        }
    }

    public enum TIPOCAPA
    {
        GRAFICA,
        DIFERENCIA,
        ETIQUETAS,
        FORMAS
    }
}
