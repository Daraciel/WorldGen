using Emgu.CV;
using Emgu.CV.Structure;
using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DCMaplib
{
    public class PerlinMap
    {
        private int _Width;
        private int _Height;
        private float[,] Ruido;
        private float[,] Resultado;
        private float[, ,] Mapas;
        private float _Amplitud;
        private float _Persistencia;
        private int _Octavas;
        private bool Generado = false;
        private Random rnd;

        public PerlinMap(int w, int h, float a, float p, int o, int? s=null)
        {
            _Width = w;
            _Height = h;
            _Amplitud = a;
            _Persistencia = p;
            _Octavas = o;
            Mapas = new float[_Octavas, _Width, _Height];
            if (s == null)
                rnd = new Random();
            else
                rnd = new Random(s.Value);
        }

        private void GenerateNoise()
        {
            if (!Generado)
            {
                Ruido = new float[_Width, _Height];
                for (int i = 0; i < _Width; i++)
                {
                    for (int j = 0; j < _Height; j++)
                    {
                        Ruido[i,j] = (float)rnd.NextDouble() % 1;
                    }
                }
                Generado = true;
            }
        }

        private void Perlin()
        {
            GenerateNoise();
            Resultado = new float[_Width, _Height];
            for (int i = 0; i < _Octavas; i++)
            {
                GenerarOctava(i);
            }

            float amp = _Amplitud;
            float acumamp = 0.0f;
            for (int k = _Octavas - 1; k >= 0; k--)
            {
                amp *= _Persistencia;
                acumamp += amp;

                for (int i = 0; i < _Width; i++)
                {
                    for (int j = 0; j < _Height; j++)
                    {
                        Resultado[i, j] += Mapas[k,i,j] * amp;
                    }
                }

            }

            for (int i = 0; i < _Width; i++)
                for (int j = 0; j < _Height; j++)
                    Resultado[i, j] /= acumamp;


        }

        private void GenerarOctava(int octava)
        {
            int periodo = 1 << octava;
            float frecuencia = _Amplitud / periodo;
            for (int i = 0; i < _Width; i++)
            {
                //calculate the horizontal sampling indices
                int sample_i0 = (i / periodo) * periodo;
                int sample_i1 = (sample_i0 + periodo) % _Width; //wrap around
                float horizontal_blend = (i - sample_i0) * frecuencia;

                for (int j = 0; j < _Height; j++)
                {
                    //calculate the vertical sampling indices
                    int sample_j0 = (j / periodo) * periodo;
                    int sample_j1 = (sample_j0 + periodo) % _Height; //wrap around
                    float vertical_blend = (j - sample_j0) * frecuencia;

                    //blend the top two corners
                    float top = Interpolar(Ruido[sample_i0,sample_j0],
                        Ruido[sample_i1,sample_j0], horizontal_blend);

                    //blend the bottom two corners
                    float bottom = Interpolar(Ruido[sample_i0,sample_j1],
                        Ruido[sample_i1,sample_j1], horizontal_blend);

                    //final blend
                    Mapas[octava,i,j] = Interpolar(top, bottom, vertical_blend);
                }
            }
        }

        private float Interpolar(float x, float y, float hb)
        {
            return x * (1 - hb) + hb * y;
        }

        public Bitmap DoPerlin()
        {
            Bitmap img = new Bitmap(_Width,_Height);
            Perlin();
            for (int i = 0; i < _Width; i++)
            {
                for (int j = 0; j < _Height; j++)
                {
                    float a = Resultado[i, j];
                    int num = (int)(255 * a);
                    img.SetPixel(i,j, Color.FromArgb(255, num, num, num));
                }
            }
            return img;
        }



        public Bitmap GetOctava(int p)
        {
            Bitmap img = new Bitmap(_Width, _Height);
            if (p >= _Octavas)//Mostrar resultado final
            {
                for (int i = 0; i < _Width; i++)
                {
                    for (int j = 0; j < _Height; j++)
                    {
                        int num = (int)(255 * Resultado[i, j]);
                        img.SetPixel(i, j, Color.FromArgb(255, num, num, num));
                    }
                }
            }
            else
            {
                for (int i = 0; i < _Width; i++)
                {
                    for (int j = 0; j < _Height; j++)
                    {
                        int num = (int)(255 * Mapas[p,i, j]);
                        img.SetPixel(i, j, Color.FromArgb(255, num, num, num));
                    }
                }
            }
            return img;
        }
    }
}
