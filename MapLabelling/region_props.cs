using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace MapLabelling
{
    public struct region_props
    {
        private int _area;
        private int _value;
        private float _x;
        private float _y;
    
        public int value
        {
            get
            {
                return _value;
            }
            set
            {
                _value = value;
            }
        }

        public int area
        {
            get
            {
                return _area;
            }
            set
            {
                _area = value;
            }
        }

        public float x
        {
            get
            {
                return _x;
            }
            set
            {
                _x = value;
            }
        }

        public float y
        {
            get
            {
                return _y;
            }
            set
            {
                _y = value;
            }
        }
    }
}
