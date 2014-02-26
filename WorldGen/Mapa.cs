using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;


namespace WorldGen
{
    class Mapa
    {

        private double InitialHeight = 0.2; //Altura inicial del mapa
        private double Scale = 1.0;         //Escala del mapa (futura feature)
        private double PI = Math.PI;        //Constante PI



        public int Width
        {
            get
            {
                return _Width;
            }
        }

        public int Height
        {
            get
            {
                return _Height;
            }
        }


        public double Seed
        {
            get
            {
                return _Seed;
            }
            private set
            {
                while (value > 1.0)
                    value /= 10.0;
                _Seed = value;
            }
        }



        private int _Width;             //Ancho del mapa (px)
        private int _Height;            //Alto del mapa (px)
        private double Latitude = 0.0;  //Latitud del centro del mapa (futura feature)
        private double Longitude = 0.0; //Longitud del centro del mapa (futura feature)


        private double _Seed;           //Semilla del mapa
        private double[,] Heightmap;    //Mapa de alturas



        public Mapa(int W, int H, int S)
        {
            _Width = W;
            _Height = H;
            Seed = S;
            Heightmap = new double[Width,Height];
            for (int i = 0; i < Width; i++)
                for (int j = 0; j < Height; j++)
                    Heightmap[i,j] = InitialHeight;


            if (Longitude > 180)
                Longitude -= 360;
            Longitude = (Longitude * PI)/180.0;
            Latitude = (Latitude * PI)/180.0;
        }


        public void MakeHeightMap()
        {
            double cla = Math.Cos(Latitude);
            double sla = Math.Sin(Latitude);
            double clo = Math.Cos(Longitude);
            double slo = Math.Sin(Longitude);

            double x, y, z, x1, y1, z1;
            for(int j=0; j<Height; j++)
                for (int i = 0; i < Width; i++)
                {
                    x = (2.0 * i - Width) / Height / Scale;
                    y = (2.0 * j - Height) / Height / Scale;
                    if (Math.Pow(x, 2) + Math.Pow(y, 2) > 1.0)//ponemos los bordes a 0
                        Heightmap[i, j] = 0;
                    else
                    {
                        //Recalculamos los puntos del mapa para la posicion i,j
                        z = Math.Sqrt(1.0 - Math.Pow(x, 2) - Math.Pow(y, 2));
                        x1 = (clo * x) + (slo * sla * y) + (slo * cla * z);
                        y1 = (cla * y) - (sla * z);
                        z1 = (-slo * x) + (clo * sla * y) + (clo * cla * z);
                        //Calculamos la altura del punto i,j
                        Heightmap[i,j] = 10000000 * MakeHeight(x1, y1, z1);
                    }
                }
        }

        private int MakeHeight(double x1, double y1, double z1)
        {
            throw new NotImplementedException();
        }

    }
}
