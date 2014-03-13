using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Web.UI.DataVisualization.Charting;


namespace WorldGen
{
    public class Mapa
    {

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



        private int _Width;             //Ancho del mapa (px)
        private int _Height;            //Alto del mapa (px)
        private double Latitude = 0.0;  //Latitud del centro del mapa (futura feature)
        private double Longitude = 0.0; //Longitud del centro del mapa (futura feature)


        private double _Seed;           //Semilla del mapa
        private double[,] Heightmap;    //Mapa de alturas

        private double r1, r2, r3, r4;



        public Mapa(int W, int H, double S)
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

            r1 = _Seed;
            r1 = Makerand(r1, r1);
            r2 = Makerand(r1, r1);
            r3 = Makerand(r1, r2);
            r4 = Makerand(r2, r3);
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
                        Heightmap[i,j] = 10000000 * MakeHeight(punto);
                    }
                }
        }

        private int MakeHeight(Point3D P)
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

        private int MakePoint(Tetraedro T, Point3D P, int Depth)
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
                T.Cortar(P);
                return MakePoint(T, P, --Depth);
            }
            else
            {
                return Convert.ToInt32(((T.AHeight + T.BHeight + T.CHeight + T.DHeight) / 4));
            }
        }

        private int MakePoint(double a, double b, double c, double d, double ar, double br, double cr, double dr, double ax, double ay, double az, double bx, double by, double bz, double cx, double cy, double cz, double dx, double dy, double dz, double x, double y, double z, int Depth)
        {
            double abx,aby,abz, acx,acy,acz, adx,ady,adz;
            double bcx,bcy,bcz, bdx,bdy,bdz, cdx,cdy,cdz;
            double lab, lac, lad, lbc, lbd, lcd;
            double ex, ey, ez, e, es, es1, es2, es3;
            double eax,eay,eaz, epx,epy,epz;
            double ecx,ecy,ecz, edx,edy,edz;
            double x1,y1,z1,x2,y2,z2,l1,tmp;

            if (Depth>0) 
            {
                if (Depth==11) 
                {
                  ssa=a; ssb=b; ssc=c; ssd=d; ssas=ar; ssbs=br; sscs=cr; ssds=dr;
                  ssax=ax; ssay=ay; ssaz=az; ssbx=bx; ssby=by; ssbz=bz;
                  sscx=cx; sscy=cy; sscz=cz; ssdx=dx; ssdy=dy; ssdz=dz;
                }
                abx = ax-bx; aby = ay-by; abz = az-bz;
                acx = ax-cx; acy = ay-cy; acz = az-cz;
                lab = abx*abx+aby*aby+abz*abz;
                lac = acx*acx+acy*acy+acz*acz;

            /* reorder vertices so ab is longest edge */
                if (lab<lac)
                  return(MakePoint(a,c,b,d, ar,cr,br,dr,
		                ax,ay,az, cx,cy,cz, bx,by,bz, dx,dy,dz,
		                x,y,z, Depth));
                else 
                {
                    adx = ax-dx; ady = ay-dy; adz = az-dz;
                    lad = adx*adx+ady*ady+adz*adz;
                    if (lab<lad)
	                    return(MakePoint(a,d,b,c, ar,dr,br,cr,
		                    ax,ay,az, dx,dy,dz, bx,by,bz, cx,cy,cz,
		                    x,y,z, Depth));
                    else 
                    {
	                    bcx = bx-cx; bcy = by-cy; bcz = bz-cz;
	                    lbc = bcx*bcx+bcy*bcy+bcz*bcz;
	                    if (lab<lbc)
	                        return(MakePoint(b,c,a,d, br,cr,ar,dr,
			                    bx,by,bz, cx,cy,cz, ax,ay,az, dx,dy,dz,
			                    x,y,z, Depth));
	                    else 
                        {
	                        bdx = bx-dx; bdy = by-dy; bdz = bz-dz;
	                        lbd = bdx*bdx+bdy*bdy+bdz*bdz;
	                        if (lab<lbd)
	                            return(MakePoint(b,d,a,c, br,dr,ar,cr,
			                        bx,by,bz, dx,dy,dz, ax,ay,az, cx,cy,cz,
			                        x,y,z, Depth));
	                        else 
                            {
	                            cdx = cx-dx; cdy = cy-dy; cdz = cz-dz;
	                            lcd = cdx*cdx+cdy*cdy+cdz*cdz;
	                            if (lab<lcd)
	                                return(MakePoint(c,d,a,b, cr,dr,ar,br,
			                            cx,cy,cz, dx,dy,dz, ax,ay,az, bx,by,bz,
			                            x,y,z, Depth));
	                            else 
                                { /* ab is longest, so cut ab */
	                                es = Makerand(ar,br);
	                                es1 = Makerand(es,es);
	                                es2 = 0.5+0.1*Makerand(es1,es1);
	                                es3 = 1.0-es2;
	                                if (ax<bx) 
                                    {
		                                ex = es2*ax+es3*bx; ey = es2*ay+es3*by; ez = es2*az+es3*bz;
	                                } 
                                    else if (ax>bx) 
                                    {
		                                ex = es3*ax+es2*bx; ey = es3*ay+es2*by; ez = es3*az+es2*bz;
	                                } 
                                    else 
                                    { /* ax==bx, very unlikely to ever happen */
		                                ex = 0.5*ax+0.5*bx; ey = 0.5*ay+0.5*by; ez = 0.5*az+0.5*bz;
	                                }
	                                if (lab>1.0) 
                                        lab = Math.Pow(lab,0.5);
	                                /* decrease contribution for very long distances */

                                    /* new altitude is: 
	                                e = 0.5*(a+b) /* average of end points 
		                                + es*dd1*fabs(a-b) /* plus contribution for altitude diff 
                                        + es1*dd2*Math.Pow(lab,POW); /* plus contribution for distance */
                                    e = 0;
	                                eax = ax-ex; eay = ay-ey; eaz = az-ez;
	                                epx =  x-ex; epy =  y-ey; epz =  z-ez;
	                                ecx = cx-ex; ecy = cy-ey; ecz = cz-ez;
	                                edx = dx-ex; edy = dy-ey; edz = dz-ez;
	                                if ((eax*ecy*edz+eay*ecz*edx+eaz*ecx*edy
		                                    -eaz*ecy*edx-eay*ecx*edz-eax*ecz*edy)*
		                                    (epx*ecy*edz+epy*ecz*edx+epz*ecx*edy
		                                    -epz*ecy*edx-epy*ecx*edz-epx*ecz*edy)>0.0)
		                                return(MakePoint(c,d,a,e, cr,dr,ar,es,
			                                    cx,cy,cz, dx,dy,dz, ax,ay,az, ex,ey,ez,
			                                    x,y,z, Depth-1));
	                                else
		                                return(MakePoint(c,d,b,e, cr,dr,br,es,
			                                    cx,cy,cz, dx,dy,dz, bx,by,bz, ex,ey,ez,
			                                    x,y,z, Depth-1));
	                            }
	                        }
	                    }
                    }
                } 
            }
          else 
          { /* level == 0 */
                /*
            if (doshade==1 || doshade==2) 
            {
                x1 = 0.25*(ax+bx+cx+dx);
                x1 = a*(x1-ax)+b*(x1-bx)+c*(x1-cx)+d*(x1-dx);
                y1 = 0.25*(ay+by+cy+dy);
                y1 = a*(y1-ay)+b*(y1-by)+c*(y1-cy)+d*(y1-dy);
                z1 = 0.25*(az+bz+cz+dz);
                z1 = a*(z1-az)+b*(z1-bz)+c*(z1-cz)+d*(z1-dz);
                l1 = sqrt(x1*x1+y1*y1+z1*z1);
                if (l1==0.0) 
                    l1 = 1.0;
                tmp = sqrt(1.0-y*y);
                if (tmp<0.0001) 
                    tmp = 0.0001;
                x2 = x*x1+y*y1+z*z1;
                y2 = -x*y/tmp*x1+tmp*y1-z*y/tmp*z1;
                z2 = -z/tmp*x1+x/tmp*z1;
                shade = (int)((-sin(PI*shade_angle/180.0)*y2-cos(PI*shade_angle/180.0)*z2) /l1*48.0+128.0);
                if (shade<10) 
                    shade = 10;
                if (shade>255) 
                    shade = 255;
                if (doshade==2 && (a+b+c+d)<0.0) 
                    shade = 150;
            }
            else if (doshade==3) 
            {
                if ((a+b+c+d)<0.0) 
                {
	                x1 = x; y1 = y; z1 = z;
                } 
                else 
                {
                    l1 = 50.0/
                     Math.Sqrt((ax-bx)*(ax-bx)+(ay-by)*(ay-by)+(az-bz)*(az-bz)+
		                      (ax-cx)*(ax-cx)+(ay-cy)*(ay-cy)+(az-cz)*(az-cz)+
		                      (ax-dx)*(ax-dx)+(ay-dy)*(ay-dy)+(az-dz)*(az-dz)+
		                      (bx-cx)*(bx-cx)+(by-cy)*(by-cy)+(bz-cz)*(bz-cz)+
		                      (bx-dx)*(bx-dx)+(by-dy)*(by-dy)+(bz-dz)*(bz-dz)+
		                      (cx-dx)*(cx-dx)+(cy-dy)*(cy-dy)+(cz-dz)*(cz-dz));
	                x1 = 0.25*(ax+bx+cx+dx);
	                x1 = l1*(a*(x1-ax)+b*(x1-bx)+c*(x1-cx)+d*(x1-dx)) + x;
	                y1 = 0.25*(ay+by+cy+dy);
	                y1 = l1*(a*(y1-ay)+b*(y1-by)+c*(y1-cy)+d*(y1-dy)) + y;
	                z1 = 0.25*(az+bz+cz+dz);
	                z1 = l1*(a*(z1-az)+b*(z1-bz)+c*(z1-cz)+d*(z1-dz)) + z;
                }
                l1 = sqrt(x1*x1+y1*y1+z1*z1);
                if (l1==0.0) 
                    l1 = 1.0;
                x2 = cos(PI*shade_angle/180.0-0.5*PI)*cos(PI*shade_angle2/180.0);
                y2 = -sin(PI*shade_angle2/180.0);
                z2 = -sin(PI*shade_angle/180.0-0.5*PI)*cos(PI*shade_angle2/180.0);
                shade = (int)((x1*x2+y1*y2+z1*z2)/l1*170.0+10);
                if (shade<10) 
                    shade = 10;
                if (shade>255) 
                    shade = 255;
            }*/
            return int.Parse(((a+b+c+d)/4).ToString());
          }
        }




        private double Makerand(double A, double B)
        {
          double r;
          r = (A+PI)*(B+PI);
          return(2.0*(r-(int)r)-1.0);
        }

    }
}
