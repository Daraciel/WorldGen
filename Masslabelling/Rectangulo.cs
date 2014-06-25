using ProtoBuf;
using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;

namespace Masslabelling
{
    [ProtoContract]
    public class Rectangulo
    {
        private Point _Location;

        [ProtoMember(1)]
        public Point Location
        {
          get { return _Location; }
          set { _Location = value; }
        }

        private int _Width;

        [ProtoMember(2)]
        public int Width
        {
            get { return _Width; }
            set { _Width = value; }
        }


        private int _Height;

        [ProtoMember(3)]
        public int Height
        {
            get { return _Height; }
            set { _Height = value; }
        }

        public int X
        {
            get
            {
                return _Location.X;
            }
            set
            {
                _Location.X = value;
            }
        }

        public int Y
        {
            get
            {
                return _Location.Y;
            }
            set
            {
                _Location.Y = value;
            }
        }

        public Rectangulo()
        {
        }

        public Rectangulo(Point p, int w, int h)
        {
            _Location = p;
            _Width = w;
            _Height = h;
        }

        public Rectangle ToRect()
        {
            return new Rectangle(X, Y, _Width, _Height);
        }
    }
}
