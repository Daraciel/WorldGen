using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Web;
using System.Web.UI.DataVisualization.Charting;


namespace DCMapLib
{
    public class Tetraedro
    {
        private double dd1 = 0.45;  /* weight for altitude difference */
        private double dd2 = 0.035; /* weight for distance */
        private double POW = 0.47;  /* power for distance function */
        
        private DPoint3D _A;
        public DPoint3D A
        {
            get { return _A; }
            set {
                    _A = value;
                    if (_B != null)
                        _DistAB = getDist(ref _A, ref _B);
                    if (_C != null)
                        _DistAC = getDist(ref _A, ref _C);
                    if (_D != null)
                        _DistAD = getDist(ref _A, ref _D);
                }
        }
        private double _AHeight;
        public double AHeight
        {
            get { return _AHeight; }
            set { _AHeight = value; }
        }
        private double _ASeed;
        public double ASeed
        {
            get { return _ASeed; }
            set { _ASeed = value; }
        }


        private DPoint3D _B;
        public DPoint3D B
        {
            get { return _B; }
            set
            {
                _B = value;
                if (_A != null)
                    _DistAB = getDist(ref _A, ref _B);
                if (_C != null)
                    _DistBC = getDist(ref _B, ref _C);
                if (_D != null)
                    _DistBD = getDist(ref _B, ref _D);
            }
        }
        private double _BHeight;
        public double BHeight
        {
            get { return _BHeight; }
            set { _BHeight = value; }
        }
        private double _BSeed;
        public double BSeed
        {
            get { return _BSeed; }
            set { _BSeed = value; }
        }


        private DPoint3D _C;
        public DPoint3D C
        {
            get { return _C; }
            set
            {
                _C = value;
                if (_A != null)
                    _DistAC = getDist(ref _A, ref _C);
                if (_B != null)
                    _DistBC = getDist(ref _B, ref _C);
                if (_D != null)
                    _DistBC = getDist(ref _B, ref _C);
            }
        }
        private double _CHeight;
        public double CHeight
        {
            get { return _CHeight; }
            set { _CHeight = value; }
        }
        private double _CSeed;
        public double CSeed
        {
            get { return _CSeed; }
            set { _CSeed = value; }
        }


        private DPoint3D _D;
        public DPoint3D D
        {
            get { return _D; }
            set
            {
                _D = value;
                if (_A != null)
                    _DistAD = getDist(ref _A, ref _D);
                if (_B != null)
                    _DistBD = getDist(ref _B, ref _D);
                if (_D != null)
                    _DistCD = getDist(ref _D, ref _C);
            }
        }
        private double _DHeight;
        public double DHeight
        {
            get { return _DHeight; }
            set { _DHeight = value; }
        }
        private double _DSeed;
        public double DSeed
        {
            get { return _DSeed; }
            set { _DSeed = value; }
        }

        /*DISTANCIAS*/
        private double _DistAB, _DistAC, _DistAD, _DistBC, _DistBD, _DistCD;

        public double DistAB
        {
            get { return _DistAB; }
        }
        public double DistAC
        {
            get { return _DistAC; }
        }
        public double DistAD
        {
            get { return _DistAD; }
        }
        public double DistBC
        {
            get { return _DistBC; }
        }
        public double DistBD
        {
            get { return _DistBD; }
        }
        public double DistCD
        {
            get { return _DistCD; }
        }
        /**/

        private double getDist(ref DPoint3D a, ref DPoint3D b)
        {
            double res;
            double deltaXAB = a.X - b.X;
            double deltaYAB = a.Y - b.Y;
            double deltaZAB = a.Z - b.Z;
            res = deltaXAB * deltaXAB + deltaYAB * deltaYAB + deltaZAB * deltaZAB;

            return res;
        }

        public Tetraedro()
        {
            A = new DPoint3D();
            B = new DPoint3D();
            C = new DPoint3D();
            D = new DPoint3D();
        }

        public void Reordenar()
        {

            double HeightAux;
            DPoint3D PointAux;
            double SeedAux;

            if (_DistAB < _DistAC)
            {
                /*Intercambiamos B con C*/
                PointAux = B; SeedAux = BSeed; HeightAux = BHeight;
                B = C; BSeed = CSeed; BHeight = CHeight;
                C = PointAux; CSeed = SeedAux; CHeight = HeightAux;
                Reordenar();
                return;
            }
            else
            {
                if (_DistAB < _DistAD)
                {
                    /*Intercambiamos B con C*/
                    PointAux = B; SeedAux = BSeed; HeightAux = BHeight;
                    B = C; BSeed = CSeed; BHeight = CHeight;
                    C = PointAux; CSeed = SeedAux; CHeight = HeightAux;

                    /*Intercambiamos B con D*/
                    PointAux = B; SeedAux = BSeed; HeightAux = BHeight;
                    B = D; BSeed = DSeed; BHeight = DHeight;
                    D = PointAux; DSeed = SeedAux; DHeight = HeightAux;
                    Reordenar();
                    return;
                }
                else
                {

                    if (_DistAB < _DistBC)
                    {
                        /*Intercambiamos A con B*/
                        PointAux = B; SeedAux = BSeed; HeightAux = BHeight;
                        B = A; BSeed = ASeed; BHeight = AHeight;
                        A = PointAux; ASeed = SeedAux; AHeight = HeightAux;

                        /*Intercambiamos C con D*//*
                        PointAux = D; SeedAux = DSeed; HeightAux = DHeight;
                        D = C; DSeed = CSeed; DHeight = CHeight;
                        C = PointAux; CSeed = SeedAux; CHeight = HeightAux;*/

                        /*Intercambiamos B con C*/
                        PointAux = B; SeedAux = BSeed; HeightAux = BHeight;
                        B = C; BSeed = CSeed; BHeight = CHeight;
                        C = PointAux; CSeed = SeedAux; CHeight = HeightAux;
                        Reordenar();
                        return;

                    }
                    else
                    {
                        if (_DistAB < _DistBD)
                        {
                            /*Intercambiamos A con B*/
                            PointAux = B; SeedAux = BSeed; HeightAux = BHeight;
                            B = A; BSeed = ASeed; BHeight = AHeight;
                            A = PointAux; ASeed = SeedAux; AHeight = HeightAux;

                            /*Intercambiamos C con D*/
                            PointAux = D; SeedAux = DSeed; HeightAux = DHeight;
                            D = C; DSeed = CSeed; DHeight = CHeight;
                            C = PointAux; CSeed = SeedAux; CHeight = HeightAux;

                            /*Intercambiamos B con C*/
                            PointAux = B; SeedAux = BSeed; HeightAux = BHeight;
                            B = C; BSeed = CSeed; BHeight = CHeight;
                            C = PointAux; CSeed = SeedAux; CHeight = HeightAux;
                            Reordenar();
                            return;
                        }
                        else
                        {
                            if (_DistAB < _DistCD)
                            {
                                /*Intercambiamos A con C*/
                                PointAux = A; SeedAux = ASeed; HeightAux = AHeight;
                                A = C; ASeed = CSeed; AHeight = CHeight;
                                C = PointAux; CSeed = SeedAux; CHeight = HeightAux;

                                /*Intercambiamos B con D*/
                                PointAux = B; SeedAux = BSeed; HeightAux = BHeight;
                                B = D; BSeed = DSeed; BHeight = DHeight;
                                D = PointAux; DSeed = SeedAux; DHeight = HeightAux;
                                Reordenar();
                                return;
                            }
                        }

                    }
                    
                }

            }

        }


        private double GetRND(ref Random R)
        {
            double res;
            int mod = R.Next(-1, 2);
            while (mod == 0)
                mod = R.Next(-1, 2);

            res = mod * R.NextDouble();

            return res;
        }

        public void Cortar(Point3D P, ref Random R)
        {/*
            double ESeed = Makerand(ASeed,BSeed);
            System.Threading.Thread.Sleep(1);
            double ESeed1 = Makerand(ESeed, ESeed);
            System.Threading.Thread.Sleep(1);
            double ESeed2 = 0.5 + 0.1 * Makerand(ESeed1, ESeed1);
            System.Threading.Thread.Sleep(1);
*/

            /*
            double ESeed = GetRND(ref R);
            double ESeed1 = GetRND(ref R);
            double ESeed2 = 0.5 + 0.1 * GetRND(ref R);
            double ESeed3 = 1.0 - ESeed2;*/


            double ESeed = Makerand(ASeed, BSeed);
            double ESeed1 = Makerand(ESeed, ESeed);
            double ESeed2 = 0.5 + 0.1 * Makerand(ESeed1, ESeed1);
            double ESeed3 = 1.0 - ESeed2;

            DPoint3D E = new DPoint3D();
            
            if (A.X < B.X)
            {
                E.X = (float)(ESeed2 * A.X + ESeed3 * B.X);
                E.Y = (float)(ESeed2 * A.Y + ESeed3 * B.Y);
                E.Z = (float)(ESeed2 * A.Z + ESeed3 * B.Z);
            }
            else if (A.X > B.X)
            {
                E.X = (float)(ESeed3 * A.X + ESeed2 * B.X);
                E.Y = (float)(ESeed3 * A.Y + ESeed2 * B.Y);
                E.Z = (float)(ESeed3 * A.Z + ESeed2 * B.Z);
            }
            else
            {
                E.X = (float)(0.5 * A.X + 0.5 * B.X);
                E.Y = (float)(0.5 * A.Y + 0.5 * B.Y);
                E.Z = (float)(0.5 * A.Z + 0.5 * B.Z);
            }


            double deltaXAB = A.X - B.X;
            double deltaYAB = A.Y - B.Y;
            double deltaZAB = A.Z - B.Z;

            double distanceAB = deltaXAB * deltaXAB + deltaYAB * deltaYAB + deltaZAB * deltaZAB;

            if (distanceAB > 1.0)
                distanceAB = Math.Pow(distanceAB, 0.5);

            double EHeight = 0.5 * (AHeight + BHeight)                    // media de las dos alturas
                            + ESeed * dd1 * Math.Abs(AHeight-BHeight)   // + contribucion por la diferencia de altitudes
                            + ESeed1 * dd2 * Math.Pow(distanceAB, POW);  // + contribucion por la distancia

            DPoint3D EA = new DPoint3D(A.X - E.X, A.Y - E.Y, A.Z - E.Z);
            DPoint3D EP = new DPoint3D(P.X - E.X, P.Y - E.Y, P.Z - E.Z);
            DPoint3D EC = new DPoint3D(C.X - E.X, C.Y - E.Y, C.Z - E.Z);
            DPoint3D ED = new DPoint3D(D.X - E.X, D.Y - E.Y, D.Z - E.Z);
            DPoint3D PointAux;
            double SeedAux;
            double HeightAux;
            if ((EA.X * EC.Y * ED.Z + EA.Y * EC.Z * ED.X + EA.Z * EC.X * ED.Y - EA.Z * EC.Y * ED.X - EA.Y * EC.X * ED.Z - EA.X * EC.Z * ED.Y) *
                (EP.X * EC.Y * ED.Z + EP.Y * EC.Z * ED.X + EP.Z * EC.X * ED.Y - EP.Z * EC.Y * ED.X - EP.Y * EC.X * ED.Z - EP.X * EC.Z * ED.Y) > 0.0)
            {
                /*Intercambiamos A con C*/
                PointAux = A; SeedAux = ASeed; HeightAux = AHeight;
                A = C; ASeed = CSeed; AHeight = CHeight;
                C = PointAux; CSeed = SeedAux; CHeight = HeightAux;

                /*Intercambiamos B con D y ustituimos B por E*/
                PointAux = E; SeedAux = ESeed; HeightAux = EHeight;
                B = D; BSeed = DSeed; BHeight = DHeight;
                D = PointAux; DSeed = SeedAux; DHeight = HeightAux;

            }
            else
            {

                /*Intercambiamos B con C*/
                PointAux = B; SeedAux = BSeed; HeightAux = BHeight;
                B = C; BSeed = CSeed; BHeight = CHeight;
                C = PointAux; CSeed = SeedAux; CHeight = HeightAux;

                /*Intercambiamos A con B*/
                PointAux = B; SeedAux = BSeed; HeightAux = BHeight;
                B = A; BSeed = ASeed; BHeight = AHeight;
                A = PointAux; ASeed = SeedAux; AHeight = HeightAux;

                /*Intercambiamos B con D y ustituimos B por E*/
                PointAux = E; SeedAux = ESeed; HeightAux = EHeight;
                B = D; BSeed = DSeed; BHeight = DHeight;
                D = PointAux; DSeed = SeedAux; DHeight = HeightAux;

            }


        }

        private double Makerand(double A, double B)
        {
            double r;
            r = (A + 3.14159265) * (B + 3.14159265);
            return (2.0 * (r - (int)r) - 1.0);
        }

    }
}
