using ProtoBuf;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Serialization;

namespace DCMapLib
{

    [ProtoContract]
    public class Capa
    {
        private TIPOCAPA _Tipo;

        [ProtoMember(1)]
        public TIPOCAPA Tipo
        {
            get { return _Tipo; }
            set { _Tipo = value; }
        }
        
        
        private int _Width;

        [ProtoMember(2)]
        public int Width
        {
            get { return _Width; }
            set
            {
                _Width = value;
                if (_Height != null && _Width != null)
                    Inicializar();
            }
        }

        private int _Height;

        [ProtoMember(3)]
        public int Height
        {
            get { return _Height; }
            set
            {
                _Height = value;
                if (_Height != null && _Width != null)
                    Inicializar();
            }
        }

        private int[] _Valores;

        [ProtoMember(4, OverwriteList = true)]
        public int[] Valores
        {
            get { return _Valores; }
            set { _Valores = value; }
        }

        
        public Capa()
        {
        }

        public void Inicializar()
        {
            _Valores = new int[_Width*_Height];
        }

        public Capa(TIPOCAPA c, int w, int h)
        {
            Tipo = c;
            _Width = w;
            _Height = h;
            Inicializar();
        }
    }

    public enum TIPOCAPA
    {
        GRAFICA,
        DIFERENCIA,
        ETIQUETAS,
        FORMAS
    }
}
