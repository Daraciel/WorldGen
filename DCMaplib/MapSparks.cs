using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Drawing;

namespace DCMaplib
{
    public class MapSparks
    {
        private TIPOCASILLA[] _Mapa;

        public TIPOCASILLA[] Mapa
        {
            get { return _Mapa; }
            set { _Mapa = value; }
        }

        public Bitmap img;

        private int _Width;

        public int Width
        {
            get { return _Width; }
            set { _Width = value; }
        }

        private int _Height;

        public int Height
        {
            get { return _Height; }
            set { _Height = value; }
        }

        private Random rnd;

        private double _Seed;

        public double Seed
        {
            get { return _Seed; }
            set { _Seed = value; }
        }

        private int _CantSparks;

        public int CantSparks
        {
            get { return _CantSparks; }
            set { _CantSparks = value; }
        }

        private int _Prob;

        public int Prob
        {
            get { return _Prob; }
            set { _Prob = value; }
        }

        private List<int> Cola;

        public MapSparks()
        {
        }

        public MapSparks(int w, int h, int s, int c, int p)
        {
            _Width = w;
            _Height = h;
            _Seed = s;
            _CantSparks = c;
            _Prob = p;
            rnd = new Random();
            InicializarMatriz();
            InicializarLista();
        }

        private void InicializarLista()
        {
            Cola = new List<int>();
            for (int i = 0; i < _CantSparks; i++)
            {
                int num = rnd.Next(_Width * _Height);
                _Mapa[num] = TIPOCASILLA.TIERRA;
                Cola.Add(num);
            }
        }

        private void InicializarMatriz()
        {
            _Mapa = new TIPOCASILLA[_Width * _Height];
            for (int i = 0; i < _Width * _Height; i++)
                _Mapa[i] = TIPOCASILLA.UNDEFINED;
        }

        public void Domap()
        {
            int num, r;
            TIPOCASILLA t;
            List<int> v;
            while (Cola.Count > 0)
            {
                r = rnd.Next(Cola.Count);
                num = Cola.ElementAt(r);
                Cola.RemoveAt(r);
                t = _Mapa[num];
                v = getVecinos(num);
                foreach(int vecino in v)
                {
                    if (_Mapa[vecino] == TIPOCASILLA.UNDEFINED)
                    {
                        if (t == TIPOCASILLA.AGUA)
                        {
                            _Mapa[vecino] = TIPOCASILLA.AGUA;
                            Cola.Add(vecino);
                        }
                        else
                        {
                            r = rnd.Next(100);
                            if (r <=  _Prob)
                                _Mapa[vecino] = TIPOCASILLA.TIERRA;
                            else
                                _Mapa[vecino] = TIPOCASILLA.AGUA;
                            Cola.Add(vecino);
                        }
                    }
                }
            }
        }

        private List<int> getVecinos(int num)
        {
            List<int> res = new List<int>();
            int mod = num % _Width;
            int div = num / _Width;

            if (num > _Width)
            {
                if(mod>0)
                    res.Add(num - _Width - 1);
                res.Add(num - _Width);
                if (mod != _Width-1)
                    res.Add(num - _Width + 1);
            }

            if (mod > 0)
                res.Add(num - 1);
            if (mod != _Width - 1)
                res.Add(num + 1);

            if (num < _Width * (_Height - 1))
            {
                if (mod > 0)
                    res.Add(num + _Width - 1);
                res.Add(num + _Width);
                if (mod != _Width - 1)
                    res.Add(num + _Width + 1);
            }

            return res;
        }

        public void setBMP()
        {

            img = new Bitmap(_Width, _Height);
            for (int i = 0; i < _Width; i++)
            {
                for (int j = 0; j < _Height; j++)
                {
                    if (_Mapa[_Width * j + i] == TIPOCASILLA.AGUA)
                        img.SetPixel(i, j, Color.Blue);
                    else
                        img.SetPixel(i, j, Color.Green);
                }
            }
        }

    }
    public enum TIPOCASILLA
    {
        UNDEFINED,
        TIERRA,
        AGUA
    }
}
