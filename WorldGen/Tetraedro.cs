using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Web.UI.DataVisualization.Charting;


namespace WorldGen
{
    public class Tetraedro
    {
        private double dd1 = 0.45;  /* weight for altitude difference */
        private double dd2 = 0.035; /* weight for distance */
        private double POW = 0.47;  /* power for distance function */
        
        private Point3D _A;
        public Point3D A
        {
            get { return _A; }
            set { _A = value; }
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


        private Point3D _B;
        public Point3D B
        {
            get { return _B; }
            set { _B = value; }
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


        private Point3D _C;
        public Point3D C
        {
            get { return _C; }
            set { _C = value; }
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


        private Point3D _D;
        public Point3D D
        {
            get { return _D; }
            set { _D = value; }
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


        public Tetraedro()
        {
            
        }

        public void Reordenar()
        {

            double HeightAux;
            Point3D PointAux;
            double SeedAux;

            double deltaXAB = A.X - B.X;
            double deltaYAB = A.Y - B.Y;
            double deltaZAB = A.Z - B.Z;

            double distanceAB = deltaXAB * deltaXAB + deltaYAB * deltaYAB + deltaZAB * deltaZAB;


            double deltaXAC = A.X - C.X;
            double deltaYAC = A.Y - C.Y;
            double deltaZAC = A.Z - C.Z;

            double distanceAC = deltaXAC * deltaXAC + deltaYAC * deltaYAC + deltaZAC * deltaZAC;

            if (distanceAB < distanceAC)
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
                double deltaXAD = A.X - D.X;
                double deltaYAD = A.Y - D.Y;
                double deltaZAD = A.Z - D.Z;

                double distanceAD = deltaXAD * deltaXAD + deltaYAD * deltaYAD + deltaZAD * deltaZAD;
                if (distanceAB < distanceAD)
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

                    double deltaXBC = B.X - C.X;
                    double deltaYBC = B.Y - C.Y;
                    double deltaZBC = B.Z - C.Z;

                    double distanceBC = deltaXBC * deltaXBC + deltaYBC * deltaYBC + deltaZBC * deltaZBC;
                    if (distanceAB < distanceBC)
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
                        double deltaXBD = B.X - D.X;
                        double deltaYBD = B.Y - D.Y;
                        double deltaZBD = B.Z - D.Z;

                        double distanceBD = deltaXBD * deltaXBD + deltaYBD * deltaYBD + deltaZBD * deltaZBD;
                        if (distanceAB < distanceBD)
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
                            double deltaXCD = C.X - D.X;
                            double deltaYCD = C.Y - D.Y;
                            double deltaZCD = C.Z - D.Z;

                            double distanceCD = deltaXCD * deltaXCD + deltaYCD * deltaYCD + deltaZCD * deltaZCD;
                            if (distanceAB < distanceCD)
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

            Point3D E = new Point3D();
            
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

            Point3D EA = new Point3D(A.X - E.X, A.Y - E.Y, A.Z - E.Z);
            Point3D EP = new Point3D(P.X - E.X, P.Y - E.Y, P.Z - E.Z);
            Point3D EC = new Point3D(C.X - E.X, C.Y - E.Y, C.Z - E.Z);
            Point3D ED = new Point3D(D.X - E.X, D.Y - E.Y, D.Z - E.Z);
            Point3D PointAux;
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
