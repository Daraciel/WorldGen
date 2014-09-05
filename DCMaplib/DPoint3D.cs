using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ProtoBuf;

namespace DCMapLib
{
    [ProtoContract]
    public class DPoint3D
    {
        private double _X;

        [ProtoMember(1)]
        public double X
        {
            get { return _X; }
            set { _X = value; }
        }
        private double _Y;

        [ProtoMember(2)]
        public double Y
        {
            get { return _Y; }
            set { _Y = value; }
        }

        private double _Z;

        [ProtoMember(3)]
        public double Z
        {
            get { return _Z; }
            set { _Z = value; }
        }

        public DPoint3D()
        {
            _X = 0.0;
            _Y = 0.0;
            _Z = 0.0;
        }

        public DPoint3D(double x, double y, double z)
        {
            _X = x;
            _Y = y;
            _Z = z;
        }

        public string ToString()
        {
            return "(" + _X + ", " + _Y + ", " + _Z + ")";
        }

    }
}
