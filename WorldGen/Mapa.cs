using Emgu.CV;
using Emgu.CV.CvEnum;
using Emgu.CV.Structure;
using System;
using System.Collections.Generic;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Web.UI.DataVisualization.Charting;
using Masslabelling;
using System.Threading.Tasks;
using System.Xml.Serialization;
using ProtoBuf;



namespace WorldGen
{
    
    [ProtoContract]
    public class Mapa
    {
        private string _Semilla;

        [ProtoMember(1)]
        public string Semilla
        {
            get { return _Semilla; }
            set { 
                    _Semilla = value;
                    setSeedFromString();
                }
        }

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
        private double _Scale = 1.0;         //Escala del mapa (futura feature)

        //[XmlIgnoreAttribute()]
        private double PI = Math.PI;        //Constante PI
        private double ssa, ssb, ssc, ssd, ssas, ssbs, sscs, ssds,
  ssax, ssay, ssaz, ssbx, ssby, ssbz, sscx, sscy, sscz, ssdx, ssdy, ssdz;
        private double M = -0.02;            // altitud inicial


        private int Depth = 11; //Número de subdivisiones que hará el tetraedro




        public Random rnd, rnd2;

        //[XmlElementAttribute("ancho")]
        private int _Width;             //Ancho del mapa (px)
        //[XmlElementAttribute("alto")]
        private int _Height;            //Alto del mapa (px)
        //[XmlElementAttribute("latitud")]
        private double _Latitude = 0.0;  //Latitud del centro del mapa (futura feature)
        //[XmlElementAttribute("longitud")]
        private double _Longitude = 0.0; //Longitud del centro del mapa (futura feature)
        [ProtoMember(2)]
        public double Longitude
        {
            get { return _Longitude; }
            set 
            {

                if (value > 180)
                    value -= 360;
                _Longitude = value;


                _Longitude = (_Longitude * PI) / 180.0;
            }
        }
        [ProtoMember(3)]
        public double Latitude
        {
            get { return _Latitude; }
            set 
            { 
                _Latitude = value;

                _Latitude = (_Latitude * PI) / 180.0;
            }
        }
        [ProtoMember(4)]
        public int Width
        {
            get
            {
                return _Width;
            }
            set
            {
                _Width = value;
            }
        }
        [ProtoMember(5)]
        public int Height
        {
            get
            {
                return _Height;
            }
            set
            {
                _Height = value;
            }
        }

        public double Seed
        {
            get
            {
                return _Seed;
            }
            set
            {
                while (value > 1.0)
                    value /= 10.0;
                _Seed = value;
            }
        }
        [ProtoMember(6)]
        public double Scale
        {
            get { return _Scale; }
            set 
            {
                if (value >= 1)
                    _Scale = value;
                else
                    _Scale = 1;
            }
        }

        //[XmlElementAttribute("seed")]
        private double _Seed;           //Semilla del mapa
        private double[,] Heightmap;    //Mapa de alturas

        private int[,] _ColorMap;        //Mapa coloreado


        private string _ColorFile;

        [ProtoMember(7)]
        public string ColorFile
        {
            get
            {
                return _ColorFile;
            }
            set
            {
                _ColorFile = value;
                LoadColorFile(value);
            }
        }

        private Capa[] _Capas;

        [ProtoMember(8, OverwriteList = true)]
        public Capa[] Capas
        {
            get { return _Capas; }
            set { _Capas = value; }
        }


        [ProtoMember(9)]
        public HashSet<Masslabelling.Region> Regiones;

        private double r1, r2, r3, r4;


        private SortedList<int,Color> Schema;

        //private MassLabelling etiquetadora;


        /// <summary>
        /// Constructor de la clase mapa
        /// </summary>
        /// <param name="W">Valor entero que representa la anchura del mapa</param>
        /// <param name="H">Valor entero que representa la altura del mapa</param>
        /// <param name="S">Valor decimal que representa la semilla del mapa</param>
        public Mapa(int W, int H, string S)
        {
            _Width = W;
            _Height = H;
            Semilla = S;
            setSeedFromString();
            Inicializar();
        }

        public void Inicializar()
        {
            Heightmap = new double[Width, Height];
            _ColorMap = new int[Width, Height];
            for (int i = 0; i < Width; i++)
                for (int j = 0; j < Height; j++)
                {
                    Heightmap[i, j] = InitialHeight;
                    _ColorMap[i, j] = 0;
                }

            Schema = new SortedList<int, Color>();
            SetDefaultSchema();
            Depth = 3 * ((int)(Math.Log(_Scale * Height, 2))) + 6;

            r1 = _Seed;
            r1 = Makerand(r1, r1);
            r2 = Makerand(r1, r1);
            r3 = Makerand(r1, r2);
            r4 = Makerand(r2, r3);

            rnd = new Random(Convert.ToInt32(1000000 * _Seed));
            rnd2 = new Random(Convert.ToInt32(1000000 * _Seed));
            //etiquetadora = new MassLabelling();
            Capas = new Capa[2];
            Capas[0] = new Capa(TIPOCAPA.GRAFICA, Width, Height);
            Capas[1] = new Capa(TIPOCAPA.DIFERENCIA, Width, Height);
        }


        public Mapa()
        {

        }

        //////////////////////////////////////////////////////
        //              FUNCIONES NECESARIAS                //
        //////////////////////////////////////////////////////

        /*Planet1*/
        /// <summary>
        /// Función para calcular la altura de un punto P
        /// </summary>
        /// <param name="P">Punto cartesiano</param>
        /// <returns>double que representa la aaltura del punto en el mapa</returns>
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
        private double MakePoint(Tetraedro T, Point3D P, int D)
        {
            if (D > 0)
            {
                if (D == 11)
                {
                    ssa = T.AHeight; ssb = T.BHeight; ssc = T.CHeight; ssd = T.DHeight;
                    ssas = T.ASeed; ssbs = T.BSeed; sscs = T.CSeed; ssds = T.DSeed;
                    ssax = T.A.X; ssay = T.A.Y; ssaz = T.A.Z;
                    ssbx = T.B.X; ssby = T.B.Y; ssbz = T.B.Z;
                    sscx = T.C.X; sscy = T.C.Y; sscz = T.C.Z;
                    ssdx = T.D.X; ssdy = T.D.Y; ssdz = T.D.Z;
                }
                T.Reordenar();
                T.Cortar(P, ref rnd);
                return MakePoint(T, P, --D);
            }
            else
            {
            }
            double blaa = ((T.AHeight + T.BHeight + T.CHeight + T.DHeight) / 4.0);
            return blaa;
        }


        /*Planet0*/
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
            /*
            if (colour < LAND)
                _ColorMap[i, j] = 0;
            else
                _ColorMap[i, j] = 1;*/

            //_ColorMap[i, j] = colour;
            Capas[0].Valores[_Width*j+i] = colour;

            if (colour > SEA)
                Capas[1].Valores[_Width * j + i] = 1;
            else
                Capas[1].Valores[_Width * j + i] = 0;

            return colour;
        }


        //////////////////////////////////////////////////////
        //              FUNCIONES AUXILIARES                //
        //////////////////////////////////////////////////////


        private void AddColor(int indice, Color c)
        {
            int r, g, b, pos, oldIndex;
            oldIndex = 0;
            if (Schema.Count > 0)
                oldIndex = Schema.Last().Key;
            if (indice < oldIndex)
                indice = oldIndex;
            if (indice > 65535)
                indice = 65535;
            Schema.Add(indice, c);
            for (int i = oldIndex + 1; i < indice; i++)
            {
                pos = Schema.IndexOfKey(oldIndex);
                r = (Schema[oldIndex].R * (indice - i) + Schema[indice].R * (i - oldIndex)) / (indice - oldIndex + 1);
                g = (Schema[oldIndex].G * (indice - i) + Schema[indice].G * (i - oldIndex)) / (indice - oldIndex + 1);
                b = (Schema[oldIndex].B * (indice - i) + Schema[indice].B * (i - oldIndex)) / (indice - oldIndex + 1);
                Schema.Add(i, Color.FromArgb(r, g, b));
            }

        }

        private void SetDefaultSchema()
        {

            AddColor(0, Color.FromArgb(0, 0, 0));
            AddColor(1, Color.FromArgb(255, 255, 255));
            AddColor(2, Color.FromArgb(255, 255, 255));
            AddColor(3, Color.FromArgb(0, 0, 0));
            AddColor(4, Color.FromArgb(0, 0, 0));
            AddColor(5, Color.FromArgb(255, 0, 0));
            AddColor(6, Color.FromArgb(0, 0, 255));
            AddColor(130, Color.FromArgb(0, 128, 255));
            AddColor(131, Color.FromArgb(0, 255, 0));
            AddColor(200, Color.FromArgb(64, 192, 16));
            AddColor(250, Color.FromArgb(128, 128, 32));
            AddColor(255, Color.FromArgb(255, 255, 255));

            int cNum = 255;

            int nocols = cNum + 1;
            if (nocols < 10) nocols = 10;
            LOWEST = 6;
            HIGHEST = nocols - 1;
            SEA = (HIGHEST + LOWEST) / 2;
            LAND = SEA + 1;

        }

        public void printBMP()
        {
            Bitmap img = new Bitmap(Width, Height);
            for (int i = 0; i < Width; i++)
            {
                for (int j = 0; j < Height; j++)
                {
                    img.SetPixel(i, j, Schema[Capas[0].Valores[_Width * j + i]]);
                }
            }
            img.Save(Seed + ".bmp", System.Drawing.Imaging.ImageFormat.Bmp);
        }

        public bool printBMP(string file)
        {
            Bitmap img = new Bitmap(Width, Height);
            for (int i = 0; i < Width; i++)
            {
                for (int j = 0; j < Height; j++)
                {
                    img.SetPixel(i, j, Schema[Capas[0].Valores[_Width * j + i]]);
                }
            }
            img.Save(file, System.Drawing.Imaging.ImageFormat.Bmp);
            return true;
        }

        public double Makerand(double A, double B)
        {
            double r;
            r = (A + 3.14159265) * (B + 3.14159265);
            return (2.0 * (r - (int)r) - 1.0);
        }

        public void Save()
        {
            string fileName = _Seed + ".txt";
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
                    writer.Write(_ColorMap[i, j] + " ");
                }
                writer.Write("\n");
            }
            writer.Close();
        }

        public Bitmap printBW()
        {
            Bitmap img = new Bitmap(Width, Height);
            for (int i = 0; i < Width; i++)
            {
                for (int j = 0; j < Height; j++)
                {
                    if (Capas[1].Valores[_Width * j + i] == 1)
                        img.SetPixel(i, j, Color.White);
                    else
                        img.SetPixel(i, j, Color.Black);
                }
            }
            return img;
        }

        public Bitmap printBMP2()
        {
            Bitmap img = new Bitmap(Width, Height);
            for (int i = 0; i < Width; i++)
            {
                for (int j = 0; j < Height; j++)
                {
                    img.SetPixel(i, j, Schema[Capas[0].Valores[_Width * j + i]]);
                }
            }
            return img;
        }


        public void LoadColorFile(string p)
        {
            string archivo = p;
            string linea = "";
            string[] tokens;
            char[] delimiters = new char[2];
            int indice = 0, r, g, b;
            Color C;
            if (Schema == null)
                Schema = new SortedList<int, Color>();
            Schema.Clear();
            delimiters[0] = ' ';
            delimiters[1] = (char)ConsoleKey.Tab;
            FileStream stream = new FileStream(archivo, FileMode.Open, FileAccess.Read);

            StreamReader SR = new StreamReader(stream);
            while (!SR.EndOfStream)
            {
                linea = SR.ReadLine();
                tokens = linea.Split(delimiters);
                if (tokens.Length == 4)
                {
                    indice = int.Parse(tokens[0]);
                    r = int.Parse(tokens[1]);
                    g = int.Parse(tokens[2]);
                    b = int.Parse(tokens[3]);
                    C = Color.FromArgb(r, g, b);
                    AddColor(indice, C);
                }
            }

            int cNum = indice;

            int nocols = cNum + 1;
            if (nocols < 10) nocols = 10;
            LOWEST = 6;
            HIGHEST = nocols - 1;
            SEA = (HIGHEST + LOWEST) / 2;
            LAND = SEA + 1;

        }

        private void setSeedFromString()
        {


            double aux = 0;
            bool res = double.TryParse(Semilla,out aux);
            if(!res)
                foreach (char c in _Semilla)
                {
                        aux += c;
                }
            Seed = aux;
        }


        /// <summary>
        /// Función para generar números aleatorios
        /// </summary>
        /// <returns>devuelve un número aleatorio entre -1 y 1 (ambos inclusive)</returns>
        private double GetRND()
        {
            double res;
            int mod = rnd2.Next(-1, 2);
            while (mod == 0)
                mod = rnd2.Next(-1, 2);

            res = mod * rnd2.NextDouble();

            return res;
        }

        //////////////////////////////////////////////////////
        //                  PROYECCIONES                    //
        //////////////////////////////////////////////////////

        public void MakeHeightMap()
        {
            double cla = Math.Cos(Latitude);
            double sla = Math.Sin(Latitude);
            double clo = Math.Cos(Longitude);
            double slo = Math.Sin(Longitude);

            double x, y, z, x1, y1, z1;
            Point3D punto;
            for (int j = 0; j < Height; j++)
                for (int i = 0; i < Width; i++)
                {
                    x = (2.0 * i - Width) / Height / Scale;
                    y = (2.0 * j - Height) / Height / Scale;
                    if (x * x + y * y > 1.0)//ponemos los bordes a 0
                        Heightmap[i, j] = 0;
                    else
                    {
                        //Recalculamos los puntos del mapa para la posicion i,j
                        z = Math.Sqrt(1.0 - x * x - y * y);
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

        public void Mercador()
        {
            double y, theta1, scale1, cos2;
            //log_2();
            int k;
            //planet0();
            y = Math.Sin(Latitude);
            y = (1.0 + y) / (1.0 - y);
            y = 0.5 * Math.Log10(y);
            k = (int)(0.5 * y * Width * Scale / PI);


            int i,j;
            for (j = 0; j < Height; j++) 
            {
                y = PI*(2.0*(j-k)-Height)/Width/Scale;
                y = Math.Exp(2.0*y);
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

        public void Mollweide()
        {

            double cla = Math.Cos(Latitude);
            double sla = Math.Sin(Latitude);
            double clo = Math.Cos(Longitude);
            double slo = Math.Sin(Longitude);
            double y,y1,zz,scale1,cos2,theta1,theta2;
            
            int i,j,i1=1,k;

            for (j = 0; j < Height; j++) 
            {
                y1 = 2*(2.0*j-_Height)/_Width/_Scale;
                if (Math.Abs(y1)>=1.0) 
                    for (i = 0; i < Width ; i++) 
                    {
                        _ColorMap[i,j] = BLACK;/*
                        if (doshade>0) 
                            shades[i][j] = 255;*/
                    } 
                else 
                {
                    zz = Math.Sqrt(1.0-y1*y1);
                    y = 2.0/PI*(y1*zz+Math.Asin(y1));
                    cos2 = Math.Sqrt(1.0 - y * y);
                    if (cos2>0.0) 
                    {
	                    scale1 = _Scale*Width/Height/cos2/PI;
	                    Depth = 3*((int)(Math.Log((scale1*Height),2)))+3;
	                    for (i = 0; i < Width ; i++) 
                        {
	                        theta1 = PI/zz*(2.0*i-Width)/Width/_Scale;
                            if (Math.Abs(theta1) > PI) 
                            {
                                _ColorMap[i,j] = BLACK;/*
	                            if (doshade>0) 
                                    shades[i][j] = 255;*/
	                        } 
                            else 
                            {
	                            double x2,y2,z2, x3,y3,z3;
	                            theta1 += -0.5*PI;
	                            x2 = Math.Cos(theta1)*cos2;
	                            y2 = y;
	                            z2 = -Math.Sin(theta1)*cos2;
	                            x3 = clo*x2+slo*sla*y2+slo*cla*z2;
	                            y3 = cla*y2-sla*z2;
	                            z3 = -slo*x2+clo*sla*y2+clo*cla*z2;

                                MakeColour(new Point3D((float)x3, (float)y3, (float)z3), i, j);
	                        }
	                    }
                    }
                }
            }
        }



        //////////////////////////////////////////////////////
        //               E T I Q U E T A D O                //
        //////////////////////////////////////////////////////

        public Image<Bgr, byte> etiquetarDebug()
        {
            Bitmap mapa = printBW();
            Emgu.CV.Image<Gray, Byte> img = new Image<Gray, Byte>(mapa);
            Emgu.CV.Image<Bgr, Byte> imgColor = new Image<Bgr, Byte>(mapa);
            double tamanoplaneta = mapa.Size.Height*mapa.Size.Width;
            double umbralcontinente = tamanoplaneta * 0.03;
            double umbralislita = tamanoplaneta * 0.000008;

            Regiones = new HashSet<Masslabelling.Region>();

            Regiones = Mass.GetRegions(img, TIPOREGION.TIERRA, umbralcontinente);

            //Emgu.CV.Structure.MIplImage image = img.MIplImage;
            MCvFont fuente = new MCvFont(FONT.CV_FONT_HERSHEY_COMPLEX_SMALL, 0.5, 0.5);

            Parallel.ForEach<Masslabelling.Region>(Regiones, (region) =>
                {
                    if (region.Area > umbralislita)
                    {
                        imgColor.Draw(region.Marco.ToRect(), new Bgr(region.Col), 2);
                        imgColor.Draw(region.Nombre, ref fuente, region.Marco.Location, new Bgr(region.Col));
                    }
                });

            //etiquetadora.regionprops(image);
            int i = 6;
            return imgColor;
            
            /*
            String win1 = "Test Window"; //The name of the window
            CvInvoke.cvNamedWindow(win1); //Create the window using the specific name

            Image<Bgr, Byte> img = new Image<Bgr, byte>(400, 200, new Bgr(255, 0, 0)); //Create an image of 400x200 of Blue color
            MCvFont f = new MCvFont(FONT.CV_FONT_HERSHEY_COMPLEX, 1.0, 1.0); //Create the font

            img.Draw("Hello, world", ref f, new System.Drawing.Point(10, 80), new Bgr(0, 255, 0)); //Draw "Hello, world." on the image using the specific font

            CvInvoke.cvShowImage(win1, img); //Show the image
            CvInvoke.cvWaitKey(0);  //Wait for the key pressing event
            CvInvoke.cvDestroyWindow(win1); //Destory the window
            
            */
        }

        public bool Salvar(string FileName)
        {
            try
            {
                using (var file = File.Create(FileName))
                {
                    Serializer.Serialize(file, this);
                }
            }
            catch (Exception ex)
            {
                return false;
            }

            return true;
        }

    }
}
