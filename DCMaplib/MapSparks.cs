using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Drawing;
using Emgu.CV;
using Emgu.CV.Structure;

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

        private int _Magnitud = 8;

        public MapSparks()
        {
        }

        public MapSparks(int w, int h, int c, int p)
        {
            _Width = w;
            _Height = h;
            _CantSparks = c;
            _Prob = p;
            rnd = new Random();
            InicializarMatriz();
            InicializarLista();
        }

        private void InicializarLista()
        {
            Cola = new List<int>();
            int ancho = _Width / _Magnitud;
            int alto = _Height / _Magnitud;
            for (int i = 0; i < _CantSparks; i++)
            {
                int num = rnd.Next(ancho * alto);
                _Mapa[num] = TIPOCASILLA.TIERRA;
                Cola.Add(num);
            }
        }

        private void InicializarMatriz()
        {
            int ancho = _Width / _Magnitud;
            int alto = _Height / _Magnitud;
            _Mapa = new TIPOCASILLA[ancho * alto];
            for (int i = 0; i < ancho * alto; i++)
                _Mapa[i] = TIPOCASILLA.UNDEFINED;
        }

        public void Domap()
        {
            int num, r, puestos = 0;
            TIPOCASILLA t;
            List<int> v;
            Random rnd2 = new Random(DateTime.Now.Millisecond - Cola.Count * puestos);
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
                            r = rnd2.Next(100);
                            if (r <=  _Prob)
                                _Mapa[vecino] = TIPOCASILLA.TIERRA;
                            else
                                _Mapa[vecino] = TIPOCASILLA.AGUA;
                            Cola.Add(vecino);
                        }
                    }
                }
                puestos++;
            }
        }

        private List<int> getVecinos(int num)
        {
            List<int> res = new List<int>();
            int ancho = _Width / _Magnitud;
            int alto = _Height / _Magnitud;
            int mod = num % ancho;
            int div = num / ancho;

            if (num > ancho)
            {
                if(mod>0)
                    res.Add(num - ancho - 1);
                res.Add(num - ancho);
                if (mod != ancho - 1)
                    res.Add(num - ancho + 1);
            }

            if (mod > 0)
                res.Add(num - 1);
            if (mod != ancho - 1)
                res.Add(num + 1);

            if (num < ancho * (alto - 1))
            {
                if (mod > 0)
                    res.Add(num + ancho - 1);
                res.Add(num + ancho);
                if (mod != ancho - 1)
                    res.Add(num + ancho + 1);
            }

            return res;
        }

        public void setBMP()
        {

            int ancho = _Width / _Magnitud;
            int alto = _Height / _Magnitud;
            img = new Bitmap(_Width, _Height);
            Image<Bgr, byte> img2 = new Image<Bgr, byte>(_Width, _Height, new Bgr(Color.Blue));
            for (int i = 0; i < ancho; i++)
            {
                for (int j = 0; j < alto; j++)
                {
                    if (_Mapa[ancho * j + i] == TIPOCASILLA.TIERRA)
                        img2.Draw(new Rectangle(i * _Magnitud, j * _Magnitud, _Magnitud - 1, _Magnitud - 1), new Bgr(Color.Green), -1);
                }
            }
            img = img2.ToBitmap();
        }
        /*
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
        }*/

    }
    public enum TIPOCASILLA
    {
        UNDEFINED,
        TIERRA,
        AGUA
    }
}
