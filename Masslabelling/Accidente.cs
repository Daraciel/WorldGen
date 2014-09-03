using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using ProtoBuf;
using ProtoBuf.Meta;

namespace Masslabelling
{
    [ProtoContract(SkipConstructor = true)]
    public class Accidente
    {
        private TIPOACCIDENTE _Tipo;

        [ProtoMember(1)]
        public TIPOACCIDENTE Tipo
        {
            get { return _Tipo; }
            set { _Tipo = value; }
        }

        private Rectangulo _Posicion;

        [ProtoMember(2)]
        public Rectangulo Posicion
        {
            get { return _Posicion; }
            set { _Posicion = value; }
        }

        public Accidente()
        {
        }
    }


    public enum TIPOACCIDENTE
    {
        PENINSULA,
        CABO,
        GOLFO,
        BAHIA,
        CANAL
    }
}
