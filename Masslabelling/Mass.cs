using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data;
using System.Drawing;
using Emgu.CV;
using Emgu.Util;
using Emgu.CV.UI;
using Emgu.CV.Structure;
using System.Threading.Tasks;

namespace Masslabelling
{
    public static class Mass
    {
        private static Size MinSize = new Size(2,1);
        private static Emgu.CV.CvEnum.CHAIN_APPROX_METHOD Searchmethod = Emgu.CV.CvEnum.CHAIN_APPROX_METHOD.CV_CHAIN_APPROX_NONE;
        private static Emgu.CV.CvEnum.RETR_TYPE Retrievaltype = Emgu.CV.CvEnum.RETR_TYPE.CV_RETR_EXTERNAL;

        private static double CannyThreshold = 149;

        public static List<Region> GetRegions(Image<Gray, byte> mapa)
        {
            if (mapa.Size.Height * mapa.Size.Width < MinSize.Height * MinSize.Width)
                return null;

            
            Contour<Point> sourceContours = mapa.FindContours(Searchmethod, Retrievaltype);
            List<Region> regiones = new List<Region>();
            int contH = 0, contV = 0;
            Region auxH, auxV;
            while (sourceContours != null)
            {
                auxH = new Region();

                auxH.Area = sourceContours.Area;
                auxH.Marco = sourceContours.BoundingRectangle;
                auxH.Perimetro = sourceContours.Perimeter;
                auxH.NumVertices = sourceContours.Total;
                Point[] forma = sourceContours.ToArray();
                for (int i = 0; i < forma.Length; i++)
                {
                    auxH.Vertices[i] = forma[i];
                }
                auxH.Hijos = GetRegions(mapa.GetSubRect(auxH.Marco));
                regiones.Add(auxH);
                sourceContours = sourceContours.HNext;
                contH++;
            }

            return regiones;
        }
    }
}
