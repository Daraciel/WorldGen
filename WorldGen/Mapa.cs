using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Web.UI.DataVisualization.Charting;


namespace WorldGen
{
    public class Mapa
    {

        private int BLACK = 0;
        private int WHITE = 1;
        private int BACK = 2;
        private int GRID = 3;
        private int OUTLINE1 = 4;
        private int OUTLINE2 = 5;
        private int LOWEST = 6;
        private int SEA = 7;
        private int LAND = 8;
        private int HIGHEST = 9;
        private int latic = 0;

        private double InitialHeight = 0.2; //Altura inicial del mapa
        private double Scale = 1.0;         //Escala del mapa (futura feature)
        private double PI = Math.PI;        //Constante PI
        private double ssa, ssb, ssc, ssd, ssas, ssbs, sscs, ssds,
  ssax, ssay, ssaz, ssbx, ssby, ssbz, sscx, sscy, sscz, ssdx, ssdy, ssdz;
        private double M = -.02;            // altitud inicial


        private int Depth = 11; //Número de subdivisiones que hará el tetraedro

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

        public Random rnd, rnd2;


        private int _Width;             //Ancho del mapa (px)
        private int _Height;            //Alto del mapa (px)
        private double Latitude = 0.0;  //Latitud del centro del mapa (futura feature)
        private double Longitude = 0.0; //Longitud del centro del mapa (futura feature)


        private double _Seed;           //Semilla del mapa
        private double[,] Heightmap;    //Mapa de alturas
        private int[,] ColorMap;        //Mapa coloreado

        private double r1, r2, r3, r4;

        private List<Color> Schema;



        public Mapa(int W, int H, double S)
        {
            _Width = W;
            _Height = H;
            Seed = S;
            Heightmap = new double[Width, Height];
            ColorMap = new int[Width, Height];
            for (int i = 0; i < Width; i++)
                for (int j = 0; j < Height; j++)
                {
                    Heightmap[i, j] = InitialHeight;
                    ColorMap[i, j] = 0;
                }


            if (Longitude > 180)
                Longitude -= 360;
            Longitude = (Longitude * PI)/180.0;
            Latitude = (Latitude * PI)/180.0;

            r1 = _Seed;
            r1 = Makerand(r1, r1);
            r2 = Makerand(r1, r1);
            r3 = Makerand(r1, r2);
            r4 = Makerand(r2, r3);

            rnd = new Random(Convert.ToInt32(1000000 * _Seed));
            rnd2 = new Random(Convert.ToInt32(1000000 * _Seed));
            r1 = rnd.NextDouble();
            r2 = rnd.NextDouble();
            r3 = rnd.NextDouble();
            r4 = rnd.NextDouble();



            /*
            ssa = rnd2.Next(-1, 1) * rnd2.NextDouble();
            ssb = rnd2.Next(-1, 1) * rnd2.NextDouble();
            ssc = rnd2.Next(-1, 1) * rnd2.NextDouble();
            ssd = rnd2.Next(-1, 1) * rnd2.NextDouble();*/
            ssa = GetRND();
            ssb = GetRND();
            ssc = GetRND();
            ssd = GetRND();
            r1 = ssa;
            r2 = ssb;
            r3 = ssc;
            r4 = ssd;

        }

        private double GetRND()
        {
            double res;
            int mod = rnd2.Next(-1, 1);
            while (mod == 0)
                mod = rnd2.Next(-1, 1);

            res = mod * rnd2.NextDouble();

            return res;
        }


        public void MakeHeightMap()
        {
            double cla = Math.Cos(Latitude);
            double sla = Math.Sin(Latitude);
            double clo = Math.Cos(Longitude);
            double slo = Math.Sin(Longitude);

            double x, y, z, x1, y1, z1;
            Point3D punto;
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
                        punto = new Point3D((float)x1, (float)y1, (float)z1);
                        //Heightmap[i, j] = 10000000 * MakeHeight(punto);
                        Heightmap[i, j] = 10000000 * MakeHeight(punto);
                    }
                }
        }

        /*Planet1*/
        private double MakeHeight(Point3D P)
        {
            double abx, aby, abz, acx, acy, acz, adx, ady, adz, apx, apy, apz;
            double bax, bay, baz, bcx, bcy, bcz, bdx, bdy, bdz, bpx, bpy, bpz;

            Tetraedro tetra = new Tetraedro();

            abx = ssbx - ssax; aby = ssby - ssay; abz = ssbz - ssaz;
            acx = sscx - ssax; acy = sscy - ssay; acz = sscz - ssaz;
            adx = ssdx - ssax; ady = ssdy - ssay; adz = ssdz - ssaz;
            apx = P.X - ssax; apy = P.Y - ssay; apz = P.Z - ssaz;
            if ((adx * aby * acz + ady * abz * acx + adz * abx * acy
                 - adz * aby * acx - ady * abx * acz - adx * abz * acy) *
                (apx * aby * acz + apy * abz * acx + apz * abx * acy
                 - apz * aby * acx - apy * abx * acz - apx * abz * acy) > 0.0)
            {
                /* p is on same side of abc as d */
                if ((acx * aby * adz + acy * abz * adx + acz * abx * ady
                 - acz * aby * adx - acy * abx * adz - acx * abz * ady) *
                (apx * aby * adz + apy * abz * adx + apz * abx * ady
                 - apz * aby * adx - apy * abx * adz - apx * abz * ady) > 0.0)
                {
                    /* p is on same side of abd as c */
                    if ((abx * ady * acz + aby * adz * acx + abz * adx * acy
                     - abz * ady * acx - aby * adx * acz - abx * adz * acy) *
                    (apx * ady * acz + apy * adz * acx + apz * adx * acy
                     - apz * ady * acx - apy * adx * acz - apx * adz * acy) > 0.0)
                    {
                        /* p is on same side of acd as b */
                        bax = -abx; bay = -aby; baz = -abz;
                        bcx = sscx - ssbx; bcy = sscy - ssby; bcz = sscz - ssbz;
                        bdx = ssdx - ssbx; bdy = ssdy - ssby; bdz = ssdz - ssbz;
                        bpx = P.X - ssbx; bpy = P.Y - ssby; bpz = P.Z - ssbz;
                        if ((bax * bcy * bdz + bay * bcz * bdx + baz * bcx * bdy
                             - baz * bcy * bdx - bay * bcx * bdz - bax * bcz * bdy) *
                            (bpx * bcy * bdz + bpy * bcz * bdx + bpz * bcx * bdy
                             - bpz * bcy * bdx - bpy * bcx * bdz - bpx * bcz * bdy) > 0.0)
                        {
                            /* p is on same side of bcd as a */
                            /* Hence, p is inside tetrahedron */
                            tetra.A = new Point3D((float)ssax, (float)ssay, (float)ssaz);
                            tetra.B = new Point3D((float)ssbx, (float)ssby, (float)ssbz);
                            tetra.C = new Point3D((float)sscx, (float)sscy, (float)sscz);
                            tetra.D = new Point3D((float)ssdx, (float)ssdy, (float)ssdz);

                            tetra.AHeight = ssa;
                            tetra.BHeight = ssb;
                            tetra.CHeight = ssc;
                            tetra.DHeight = ssd;

                            tetra.ASeed = ssas;
                            tetra.BSeed = ssbs;
                            tetra.CSeed = sscs;
                            tetra.DSeed = ssds;

                            return (MakePoint(tetra, P, 11));
                        }
                    }
                }
            } /* otherwise */

            tetra.A = new Point3D((float)(-Math.Sqrt(3.0) - 0.20), (float)(-Math.Sqrt(3.0) - 0.22), (float)(-Math.Sqrt(3.0) - 0.23));
            tetra.B = new Point3D((float)(-Math.Sqrt(3.0) - 0.19), (float)(Math.Sqrt(3.0) + 0.18), (float)(Math.Sqrt(3.0) + 0.17));
            tetra.C = new Point3D((float)(Math.Sqrt(3.0) + 0.21), (float)(-Math.Sqrt(3.0) - 0.24), (float)(Math.Sqrt(3.0) + 0.15));
            tetra.D = new Point3D((float)(Math.Sqrt(3.0) + 0.24), (float)(Math.Sqrt(3.0) + 0.22), (float)(-Math.Sqrt(3.0) - 0.25));

            tetra.AHeight = M;
            tetra.BHeight = M;
            tetra.CHeight = M;
            tetra.DHeight = M;

            tetra.ASeed = r1;
            tetra.BSeed = r2;
            tetra.CSeed = r3;
            tetra.DSeed = r4;

            return (MakePoint(tetra, P, Depth));
        }

        /*Planet*/
        private double MakePoint(Tetraedro T, Point3D P, int Depth)
        {
            if (Depth > 0)
            {
                if (Depth == 11)
                {
                    ssa = T.AHeight; ssb = T.BHeight; ssc = T.CHeight; ssd = T.DHeight;
                    ssas = T.ASeed; ssbs = T.BSeed; sscs = T.CSeed; ssds = T.DSeed;
                    ssax = T.A.X; ssay = T.A.Y; ssaz = T.A.Z;
                    ssbx = T.B.X; ssby = T.B.Y; ssbz = T.B.Z;
                    sscx = T.C.X; sscy = T.C.Y; sscz = T.C.Z;
                    ssdx = T.D.X; ssdy = T.D.Y; ssdz = T.D.Z;
                }
                T.Reordenar();
                T.Cortar(P,ref rnd);
                return MakePoint(T, P, --Depth);
            }
            else
            {
                double blaa = ((T.AHeight + T.BHeight + T.CHeight + T.DHeight) / 4.0);
                return blaa;
            }
        }

        private int MakeColour(Point3D P, int i, int j)
        {
            
            double alt, y2;
            int colour;

            alt = MakeHeight(P);
            y2 = P.Y * P.Y; y2 = y2 * y2; y2 = y2 * y2;
            if (alt <= 0.0)
            {
                if ((latic == 1) && (y2 + alt >= 0.98))
                {
                    colour = HIGHEST;
                }
                else
                {
                    colour = SEA + (int)((SEA - LOWEST + 1) * (10 * alt));
                    if (colour < LOWEST)
                        colour = LOWEST;
                }
            }
            else
            {
                if (latic == 1)
                    alt += 0.1 + y2;
                if (alt >= 0.1)
                    colour = HIGHEST;
                else
                {
                    colour = LAND + (int)((HIGHEST - LAND + 1) * (10 * alt));
                    if (colour > HIGHEST) 
                        colour = HIGHEST;
                }
            }

            ColorMap[i, j] = colour;

            return colour;
        }

        public void Mercador()
        {
            double y,scale1,cos2,theta1;
            //log_2();
            int i, j, k;
            //planet0();
            y = Math.Sin(Latitude);
            y = (1.0 + y) / (1.0 - y);
            y = 0.5 * Math.Log10(y);
            k = (int)(0.5 * y * Width * Scale / PI);
            
            for (j = 0; j < Height; j++) 
            {/*
                if (debug && ((j % (Height/25)) == 0)) 
	            {
		            fprintf (stderr, "%c", view); fflush(stderr);
	            }*/
                y = PI*(2.0*(j-k)-Height)/Width/Scale;
                y = Math.Pow(2.0,y);
                y = (y-1.0)/(y+1.0);
                scale1 = Scale*Width/Height/Math.Sqrt(1.0-y*y)/PI;
                cos2 = Math.Sqrt(1.0 - y * y);
                Depth = 3*((int)(Math.Log(scale1*Height,2)))+3;
                for (i = 0; i < Width ; i++) 
	            {

                    theta1 = Longitude - 0.5 * PI + PI * (2.0 * i - Width) / Width / Scale;
                    MakeColour(new Point3D((float)(Math.Cos(theta1) * cos2), (float)y, (float)(-Math.Sin(theta1) * cos2)), i, j);
                    //planet0(Math.Cos(theta1) * cos2, y, -Math.Sin(theta1) * cos2, i, j);
                }
            }
  
        }

        private void SetDefaultSchema()
        {
            Schema.Add(new Color(0, 0, 0, 0));
            Schema.Add(new Color(1, 255, 255, 255));
            Schema.Add(new Color(2, 255, 255, 255));
            Schema.Add(new Color(3, 0, 0, 0));
            Schema.Add(new Color(4, 0, 0, 0));
            Schema.Add(new Color(5, 255, 0, 0));
            Schema.Add(new Color(6, 0, 0, 255));
            Schema.Add(new Color(130, 0, 128, 255));
            Schema.Add(new Color(131, 0, 255, 0));
            Schema.Add(new Color(200, 64, 192, 16));
            Schema.Add(new Color(250, 128, 128, 32));
            Schema.Add(new Color(255, 255, 255, 255));
        }

        private double Makerand(double A, double B)
        {
          double r;
          r = (A+PI)*(B+PI);
          return(2.0*(r-(int)r)-1.0);
        }

        public void Save()
        {
            string fileName = _Seed+".txt";
            FileStream stream = new FileStream(fileName, FileMode.OpenOrCreate, FileAccess.Write);
            StreamWriter writer = new StreamWriter(stream);

            writer.WriteLine(_Seed);
            writer.WriteLine(_Width);
            writer.WriteLine(_Height);
            for (int i = 0; i < Width; i++)
            {
                for (int j = 0; j < Height; j++)
                {
                    writer.Write(Heightmap[i, j] + " ");
                }
                writer.Write("\n");
            }
            writer.Close();
        }

        public void SaveColMap()
        {
            string fileName = _Seed + "C.txt";
            FileStream stream = new FileStream(fileName, FileMode.OpenOrCreate, FileAccess.Write);
            StreamWriter writer = new StreamWriter(stream);

            writer.WriteLine(_Seed);
            writer.WriteLine(_Width);
            writer.WriteLine(_Height);
            for (int i = 0; i < Width; i++)
            {
                for (int j = 0; j < Height; j++)
                {
                    writer.Write(ColorMap[i, j] + " ");
                }
                writer.Write("\n");
            }
            writer.Close();
        }

    }
}
