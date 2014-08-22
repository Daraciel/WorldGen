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
        private static Size MinSize = new Size(1,1);
        private static Emgu.CV.CvEnum.CHAIN_APPROX_METHOD Searchmethod = Emgu.CV.CvEnum.CHAIN_APPROX_METHOD.CV_CHAIN_APPROX_NONE;
        private static Emgu.CV.CvEnum.RETR_TYPE Retrievaltype = Emgu.CV.CvEnum.RETR_TYPE.CV_RETR_TREE;

        private static double CannyThreshold = 149;

        private static List<string> continentes;
        private static List<string> islas;

        static Mass()
        {
            fillIslands();
            fillContinents();
        }

        private static void fillIslands()
        {
            string fic = "Islands.res";
            string texto;
            islas = new List<string>();

            System.IO.StreamReader sr = new System.IO.StreamReader(fic);
            while (!sr.EndOfStream)
            {
                texto = sr.ReadLine();
                islas.Add(texto);
            }

            sr.Close();
        }


        private static void fillContinents()
        {

            string fic = "Continents.res";
            string texto;
            continentes = new List<string>();
            System.IO.StreamReader sr = new System.IO.StreamReader(fic);
            while (!sr.EndOfStream)
            {
                texto = sr.ReadLine();
                continentes.Add(texto);
            }

            sr.Close();
        }

        public static string getRandomIsland()
        {
            string result = "";
            Random rnd = new Random();
            if (islas.Count == 0)
                fillIslands();
            
            int num = rnd.Next(islas.Count());

            result = islas.ElementAt(num);
            islas.RemoveAt(num);

            return result;
        }

        public static string getRandomContinent()
        {
            string result = "";
            Random rnd = new Random();
            if (continentes.Count == 0)
                fillContinents();
            int num = rnd.Next(continentes.Count());

            result = continentes.ElementAt(num);
            continentes.RemoveAt(num);

            return result;
        }

        public static HashSet<Region> GetRegions(Image<Gray, byte> mapa, TIPOREGION tr, double umbral)
        {/*
            if (mapa.Size.Height * mapa.Size.Width < MinSize.Height * MinSize.Width)
                return null;
            */
            double umbralIslote = umbral / 300.0;
            Random randonGen = new Random();
            Color randomColor;
            //Contour<Point> sourceContours = mapa.Canny(CannyThreshold, CannyThreshold).FindContours(Searchmethod, Retrievaltype);
            Contour<Point> sourceContours = mapa.FindContours(Searchmethod, Retrievaltype);
            HashSet<Region> regiones = new HashSet<Region>();
            int contH = 0, contV = 0;
            Region auxH, auxV;
            TIPOREGION nuevotipo = TIPOREGION.AGUA;

            if(tr == TIPOREGION.AGUA)
                nuevotipo = TIPOREGION.TIERRA;

            while (sourceContours != null)
            {
                auxH = new Region();

                auxH.Area = sourceContours.Area;
                auxH.NumVertices = sourceContours.Total;
                if (auxH.NumVertices >2)
                {
                    
                    auxH.Marco = new Rectangulo(sourceContours.BoundingRectangle.Location, sourceContours.BoundingRectangle.Width, sourceContours.BoundingRectangle.Height);

                    Point[] forma = sourceContours.ToArray();
                    for (int i = 0; i < forma.Length; i++)
                    {
                        auxH.Vertices[i] = forma[i];
                    }
                    Point cent = auxH.SetCentroide();
                    byte r = mapa.Data[cent.Y, cent.X, 0];
                    Color c = Color.FromArgb(r, r, r, r);
                        auxH.Perimetro = sourceContours.Perimeter;
                        randomColor = Color.FromArgb(randonGen.Next(255), randonGen.Next(255), randonGen.Next(255));
                        auxH.Col = randomColor;
                        auxH.Tipo = tr;
                        if (auxH.Tipo == TIPOREGION.TIERRA)
                        {
                            if (auxH.Area > umbral)
                            {
                                auxH.Nombre = getRandomContinent();
                                auxH.Tipotam = TIPOTAMANO.CONTINENTE;
                            }
                            else
                            {
                                auxH.Nombre = getRandomIsland();
                                if (auxH.Area > umbralIslote)
                                {
                                    auxH.Tipotam = TIPOTAMANO.ISLA;
                                    if (auxH.Nombre.StartsWith("de"))
                                        auxH.Nombre = "Isla " + auxH.Nombre;
                                }
                                else
                                {
                                    auxH.Tipotam = TIPOTAMANO.ISLOTE;
                                    if (auxH.Nombre.StartsWith("de"))
                                        auxH.Nombre = "Islote " + auxH.Nombre;
                                }
                            }

                        }
                        else
                        {
                            auxH.Nombre = "Lago";
                        }
                        regiones.Add(auxH);
                }
                sourceContours = sourceContours.HNext;
                contH++;
            }

            return regiones;
        }
    }
}
