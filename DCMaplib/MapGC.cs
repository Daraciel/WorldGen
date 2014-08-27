using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DCMaplib
{
    public class MapGC
    {
        private const float PI = 3.141593f;
        private int[] Mapa;
        private int Width = 320;
        private int Height = 160;
        private int Seed;
        private int Iterations;
        private int[] Histogram = new int[256];
        private int FilledPixels;
        private int[] Red = {   0,0,0,0,0,0,0,0,34,68,102,119,136,153,170,187,
			                    0,34,34,119,187,255,238,221,204,187,170,153,
			                    136,119,85,68,255,250,245,240,235,230,225,220,
                                215,210,205,200,195,190,185,180,175};

        private int[] Green = { 0,0,17,51,85,119,153,204,221,238,255,255,255,
			                    255,255,255,68,102,136,170,221,187,170,136,
			                    136,102,85,85,68,51,51,34,255,250,245,240,235,
                                230,225,220,215,210,205,200,195,190,185,180,175};
        private int[] Blue = {  0,68,102,136,170,187,221,255,255,255,255,255,
			                    255,255,255,255,0,0,0,0,0,34,34,34,34,34,34,
			                    34,34,34,17,0,255,250,245,240,235,230,225,220,
                                215,210,205,200,195,190,185,180,175};

        private float HeightDiv2, HeightDivPI;
        private float[] SinIterPhi;
        private int PercentageWater, Threshold;
        private Random rnd;
        int MaxZ;
        int MinZ;

        public MapGC(int w, int h, int i, int s, int p)
        {
            MaxZ = Int32.MinValue;
            MinZ = Int32.MaxValue;
            Width = w;
            Height = h;
            Iterations = i;
            if (s == 0)
                rnd = new Random();
            else
                rnd = new Random(s);
            PercentageWater = p;
            Inicializar();
        }

        private void Inicializar()
        {
            Mapa = new int[Width * Height];
            SinIterPhi = new float[2 * Width];
            int row = 0;
            for (int i = 0; i < Width; i++)
            {
                Mapa[row] = 0;
                SinIterPhi[i] = SinIterPhi[i + Width] = (float)Math.Sin(i * 2 * PI / Width);
                for (int j = 1; j < Height; j++)
                {
                    Mapa[j + row] = 0;
                    //Mapa[j + row] = Int32.MinValue;
                }
                row += Height;
            }
            HeightDiv2 = Height / 2;
            HeightDivPI = Height / PI;
        }

        public void Hacermapa()
        {
            for (int i = 0; i < Iterations; i++)
            {
                Iterar();
            }

            Espejo();
            Reconstruir();
            ConstruirHistograma();
            NormalizarMapa();
        }

        private void NormalizarMapa()
        {
            for (int j = 0, row = 0; j < Width; j++)
            {
                for (int i = 0; i < Height; i++)
                {
                    int Color = Mapa[row + i];

                    if (Color < Threshold)
                        Color = (int)(((float)(Color - MinZ) / (float)(Threshold - MinZ)) * 15) + 1;
                    else
                        Color = (int)(((float)(Color - Threshold) / (float)(MaxZ - Threshold)) * 15) + 16;

                    if (Color < 1) 
                        Color = 1;
                    else if (Color > 255) 
                        Color = 31;
                    Mapa[row + i] = Color;
                }
                row += Height;
            }
        }

        private void ConstruirHistograma()
        {
            for (int j = 0; j < Width * Height; j++)
            {
                int Color = Mapa[j];
                if (Color > MaxZ) MaxZ = Color;
                if (Color < MinZ) MinZ = Color;
            }

            for (int j = 0, row = 0; j < Width; j++)
            {
                for (int i = 0; i < Height; i++)
                {
                    int Color = Mapa[row + i];
                    Color = (int)(((float)(Color - MinZ + 1) / (float)(MaxZ - MinZ + 1)) * 30) + 1;
                    Histogram[Color]++;
                }
                row += Height;
            }

            Threshold = PercentageWater * Width * Height / 100;
            int k, Acum;
            for (k = 0, Acum = 0; k < 256; k++)
            {
                Acum += Histogram[k];
                if (Acum > Threshold) 
                    break;
            }

            /* Threshold now holds where sea-level is */
            Threshold = k * (MaxZ - MinZ + 1) / 30 + MinZ;
        }

        private void Reconstruir()
        {
            for (int j = 0, row = 0; j < Width; j++)
            {
                /* We have to start somewhere, and the top row was initialized to 0,
                 * but it might have changed during the iterations... */
                int Color = Mapa[row];
                for (int i = 1; i < Height; i++)
                {
                    /* We "fill" all positions with values != INT_MIN with Color */
                    int actual = Mapa[row + i];
                    if (actual != Int32.MinValue)
                    {
                        Color += actual;
                    }
                    Mapa[row + i] = Color;
                }
                row += Height;
            }
        }

        private void Espejo()
        {
            int z = (Width / 2) * Height;
            for (int j = 0, row = 0; j < Width / 2; j++)
            {
                for (int i = 1; i < Height; i++)                    /* fix */
                {
                    Mapa[row + z + Height - i] = Mapa[row + i];
                }
                row += Height;
            }
        }

        private void Iterar()
        {
            double flag = rnd.NextDouble();
            float A = ((float)rnd.NextDouble() - 0.5f) * PI;
            float B = ((float)rnd.NextDouble() - 0.5f) * PI;

            double T = Math.Tan(Math.Acos(Math.Cos(A) * Math.Cos(B)));

            //float Alpha = (((float)rand()) / MAX_RAND - 0.5) * PI; /* Rotate around x-axis */
            //float Beta = (((float)rand()) / MAX_RAND - 0.5) * PI; /* Rotate around y-axis */
            int row = 0;
            int Xsi = (int)(Width / 2 - (Width / PI) * B);
            for (int i = 0; i < Width / 2; i++)
            {
                int Theta = (int)(HeightDivPI * Math.Atan(SinIterPhi[Xsi - i + Width] * T)) + (int)HeightDiv2;

                if (flag >= 0.5)
                {
                    if (Mapa[row + Theta] != Int32.MinValue)
                        Mapa[row + Theta]--;
                    else
                        Mapa[row + Theta]--;

                }
                else
                {
                    if (Mapa[row + Theta] != Int32.MinValue)
                        Mapa[row + Theta]++;
                    else
                        Mapa[row + Theta]++;
                }
                row += Height;
            }
        }

        public Bitmap printBMP()
        {
            Bitmap img = new Bitmap(Width, Height);
            for (int i = 0, row = 0; i < Width; i++)
            {
                for (int j = 0; j < Height; j++)
                {
                    Color col = Color.FromArgb(Red[Mapa[row+j]], Green[Mapa[row+j]], Blue[Mapa[row+j]]);
                    img.SetPixel(i, j, col);
                }
                row += Height;
            }

            return img;
        }

    }
}
