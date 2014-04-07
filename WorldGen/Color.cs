using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WorldGen
{
    class Color
    {
        private int _Indice;

        public int Indice
        {
            get { return _Indice; }
            set { _Indice = value; }
        }
        private int _R;

        public int R
        {
            get { return _R; }
            set { _R = value; }
        }
        private int _G;

        public int G
        {
            get { return _G; }
            set { _G = value; }
        }
        private int _B;

        public int B
        {
            get { return _B; }
            set { _B = value; }
        }

        public Color()
        {
            Indice = 0;
            R = 0;
            G = 0;
            B = 0;
        }

        public Color(int i, int r, int g, int b)
        {
            Indice = i;
            R = r;
            G = g;
            B = b;
        }

    }
}
