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
        public static Emgu.CV.CvEnum.CHAIN_APPROX_METHOD Searchmethod = Emgu.CV.CvEnum.CHAIN_APPROX_METHOD.CV_LINK_RUNS;
        public static Emgu.CV.CvEnum.RETR_TYPE Retrievaltype = Emgu.CV.CvEnum.RETR_TYPE.CV_RETR_LIST;

        public static List<Region> GetRegions(Image<Gray, byte> mapa)
        {
            Contour<Point> sourceContours = mapa.FindContours(Searchmethod, Retrievaltype);
            List<Region> regiones = new List<Region>();
            Region aux;

            while (sourceContours != null)
            {
                aux = new Region();

                aux.Area = sourceContours.Area;
                aux.Marco = sourceContours.BoundingRectangle;
                aux.Perimetro = sourceContours.Perimeter;
                aux.NumVertices = sourceContours.Total;
                Point[] forma= sourceContours.ToArray();
                for(int i=0; i<forma.Length; i++)
                {
                    aux.Vertices[i] = forma[i];
                }
                sourceContours = sourceContours.HNext;
                regiones.Add(aux);
            }

            return regiones;
        }
    }
}
