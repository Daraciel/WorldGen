using Emgu.CV;
using Emgu.CV.CvEnum;
using Emgu.CV.Structure;
using System;
using System.Collections.Generic;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Web;
using Masslabelling;
using System.Threading.Tasks;
using System.Xml.Serialization;
using ProtoBuf;
using System.Web.UI.DataVisualization.Charting;



namespace DCMapLib
{
    
    [ProtoContract]
    public class MapaST
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

        private double InitialHeight = 0.2;     //Altura inicial del mapa
        private double _Scale = 1.0;            //Escala del mapa

        private double PI = Math.PI;            //Constante PI

        private Tetraedro T;

        private int Depth = 11; //Número de subdivisiones que hará el tetraedro




        public Random rnd, rnd2;

        private int _Width;             //Ancho del mapa (px)

        private int _Height;            //Alto del mapa (px)

        private double _Latitude = 0.0;  //Latitud del centro del mapa

        private double _Longitude = 0.0; //Longitud del centro del mapa 

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

        private double _WaterLine;      // Nivel del agua

        [ProtoMember(15)]
        public double WaterLine
        {
            get
            {
                return _WaterLine;
            }
            set
            {
                _WaterLine = value;
            }
        }    

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

        private HashSet<Accidente> _Peninsulas;

        [ProtoMember(10, OverwriteList = true)]
        public HashSet<Accidente> Peninsulas
        {
            get { return _Peninsulas; }
            set { _Peninsulas = value; }
        }

        private HashSet<Accidente> _Cabos;

        [ProtoMember(11, OverwriteList = true)]
        public HashSet<Accidente> Cabos
        {
            get { return _Cabos; }
            set { _Cabos = value; }
        }

        private HashSet<Accidente> _Bahias;

        [ProtoMember(12, OverwriteList = true)]
        public HashSet<Accidente> Bahias
        {
            get { return _Bahias; }
            set { _Bahias = value; }
        }

        private HashSet<Accidente> _Golfos;

        [ProtoMember(13, OverwriteList = true)]
        public HashSet<Accidente> Golfos
        {
            get { return _Golfos; }
            set { _Golfos = value; }
        }

        private HashSet<Accidente> _Canales;

        [ProtoMember(14, OverwriteList = true)]
        public HashSet<Accidente> Canales
        {
            get { return _Canales; }
            set { _Canales = value; }
        }


        private double r1, r2, r3, r4;


        private SortedList<int,Color> Schema;

        //private MassLabelling etiquetadora;


        /// <summary>
        /// Constructor de la clase mapa
        /// </summary>
        /// <param name="W">Valor entero que representa la anchura del mapa</param>
        /// <param name="H">Valor entero que representa la altura del mapa</param>
        /// <param name="S">Valor decimal que representa la semilla del mapa</param>
        public MapaST(int W, int H, string S)
        {
            T = new Tetraedro();
            _Width = W;
            _Height = H;
            Semilla = S;
            _WaterLine = -0.02;
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


        public MapaST()
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
            
            abx = T.B.X - T.A.X; aby = T.B.Y - T.A.Y; abz = T.B.Z - T.A.Z;
            acx = T.C.X - T.A.X; acy = T.C.Y - T.A.Y; acz = T.C.Z - T.A.Z;
            adx = T.D.X - T.A.X; ady = T.D.Y - T.A.Y; adz = T.D.Z - T.A.Z;
            apx = P.X - T.A.X; apy = P.Y - T.A.Y; apz = P.Z - T.A.Z;
            if ((adx * aby * acz + ady * abz * acx + adz * abx * acy
                 - adz * aby * acx - ady * abx * acz - adx * abz * acy) *
                (apx * aby * acz + apy * abz * acx + apz * abx * acy
                 - apz * aby * acx - apy * abx * acz - apx * abz * acy) > 0.0)
            {
                /* p está en el mismo lado de abc que d */
                if ((acx * aby * adz + acy * abz * adx + acz * abx * ady
                 - acz * aby * adx - acy * abx * adz - acx * abz * ady) *
                (apx * aby * adz + apy * abz * adx + apz * abx * ady
                 - apz * aby * adx - apy * abx * adz - apx * abz * ady) > 0.0)
                {
                    /* p está en el mismo lado de abd que c */
                    if ((abx * ady * acz + aby * adz * acx + abz * adx * acy
                     - abz * ady * acx - aby * adx * acz - abx * adz * acy) *
                    (apx * ady * acz + apy * adz * acx + apz * adx * acy
                     - apz * ady * acx - apy * adx * acz - apx * adz * acy) > 0.0)
                    {
                        /* p está en el mismo lado de acd que b */
                        bax = -abx; bay = -aby; baz = -abz;
                        
                        bcx = T.C.X - T.B.X; bcy = T.C.Y - T.B.Y; bcz = T.C.Z - T.B.Z;
                        bdx = T.D.X - T.B.X; bdy = T.D.Y - T.B.Y; bdz = T.D.Z - T.B.Z;
                        bpx = P.X - T.B.X; bpy = P.Y - T.B.Y; bpz = P.Z - T.B.Z;


                        if ((bax * bcy * bdz + bay * bcz * bdx + baz * bcx * bdy
                             - baz * bcy * bdx - bay * bcx * bdz - bax * bcz * bdy) *
                            (bpx * bcy * bdz + bpy * bcz * bdx + bpz * bcx * bdy
                             - bpz * bcy * bdx - bpy * bcx * bdz - bpx * bcz * bdy) > 0.0)
                        {
                            /* p está en el mismo lado de bcd que a */
                            /* Por lo que p está dentro del tetraedro */
                            
                            tetra.A = new DPoint3D(T.A.X, T.A.Y, T.A.Z);
                            tetra.B = new DPoint3D(T.B.X, T.B.Y, T.B.Z);
                            tetra.C = new DPoint3D(T.C.X, T.C.Y, T.C.Z);
                            tetra.D = new DPoint3D(T.D.X, T.D.Y, T.D.Z);

                            tetra.AHeight = T.AHeight;
                            tetra.BHeight = T.BHeight;
                            tetra.CHeight = T.CHeight;
                            tetra.DHeight = T.DHeight;

                            tetra.ASeed = T.ASeed;
                            tetra.BSeed = T.BSeed;
                            tetra.CSeed = T.CSeed;
                            tetra.DSeed = T.DSeed;

                            return (MakePoint(tetra, P, 11));
                        }
                    }
                }
            } /* otherwise */

            tetra.A = new DPoint3D((-Math.Sqrt(3.0) - 0.20), (-Math.Sqrt(3.0) - 0.22), (-Math.Sqrt(3.0) - 0.23));
            tetra.B = new DPoint3D((-Math.Sqrt(3.0) - 0.19), (Math.Sqrt(3.0) + 0.18), (Math.Sqrt(3.0) + 0.17));
            tetra.C = new DPoint3D((Math.Sqrt(3.0) + 0.21), (-Math.Sqrt(3.0) - 0.24), (Math.Sqrt(3.0) + 0.15));
            tetra.D = new DPoint3D((Math.Sqrt(3.0) + 0.24), (Math.Sqrt(3.0) + 0.22), (-Math.Sqrt(3.0) - 0.25));

            tetra.AHeight = _WaterLine;
            tetra.BHeight = _WaterLine;
            tetra.CHeight = _WaterLine;
            tetra.DHeight = _WaterLine;

            tetra.ASeed = r1;
            tetra.BSeed = r2;
            tetra.CSeed = r3;
            tetra.DSeed = r4;

            return (MakePoint(tetra, P, Depth));
        }

        /*Planet*/
        private double MakePoint(Tetraedro T1, Point3D P, int D)
        {
            if (D > 0)
            {
                if (D == 11)
                {
                    
                    T.AHeight = T1.AHeight; 
                    T.BHeight = T1.BHeight; 
                    T.CHeight = T1.CHeight; 
                    T.DHeight = T1.DHeight;

                    T.ASeed = T1.ASeed; 
                    T.BSeed = T1.BSeed; 
                    T.CSeed = T1.CSeed; 
                    T.DSeed = T1.DSeed;

                    T.A.X = T1.A.X; T.A.Y = T1.A.Y; T.A.Z = T1.A.Z;
                    T.B.X = T1.B.X; T.B.Y = T1.B.Y; T.B.Z = T1.B.Z;
                    T.C.X = T1.C.X; T.C.Y = T1.C.Y; T.C.Z = T1.C.Z;
                    T.D.X = T1.D.X; T.D.Y = T1.D.Y; T.D.Z = T1.D.Z;
                }
                T1.Reordenar();
                T1.Cortar(P, ref rnd);
                return MakePoint(T1, P, --D);
            }
            else
            {
            }
            double blaa = ((T1.AHeight + T1.BHeight + T1.CHeight + T1.DHeight) / 4.0);
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
            double umbralcontinente = tamanoplaneta * 0.015;
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
                        imgColor.Draw(new CircleF(region.Centroide, 1), new Bgr(region.Col), 2);
                    }
                });

            return imgColor;
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
