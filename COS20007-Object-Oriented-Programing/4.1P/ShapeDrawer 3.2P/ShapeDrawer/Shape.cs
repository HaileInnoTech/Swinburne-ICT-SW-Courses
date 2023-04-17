using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using SplashKitSDK;

namespace shapedrawer
{
    public abstract class Shape
    {
        private Point2D position;
        private Color _color;
        private float _x, _y;
        private int _width, _height;


        private bool _selected;

        public bool Selected
        {
            get { return _selected; }
            set { _selected = value; }
        }


        public Shape(Color color)
        {
            _x = 0; 
            _y = 0;
            _color = color;
            _width = 100;
            _height = 100;
        }
        public Shape() : this(Color.Yellow) { }

        public Color Color
        {
            get
            {
                return _color;
            }
            set
            {
                _color = value;
            }
        }
        public float X
        {
            get { return _x; }
            set { _x = value; } 
        }
        public float Y
        {
            get { return _y; }
            set { _y = value; }
        }
        public int Width
        {
            get { return _width; }  
            set { _width = value;}
        }
        public int Height
        {
            get { return _height; }
            set { _height = value; }
        }
        public Point2D Position
        {
            get { return position; }
            set { position = value; }
        }

        public abstract void Draw();

        public abstract bool IsAt(Point2D pt);

        public abstract void DrawOutline();
        

        
    }
}
