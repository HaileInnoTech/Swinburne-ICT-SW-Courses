using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using SplashKitSDK;

namespace shapedrawer
{
    public class Shape
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


        public Shape(){
            _x = 0; 
            _y = 0;
            _color = Color.Green;
            _width = 100;
            _height = 100;
        }
        public Color color
        {
           get { return _color; }
            set { _color = value; } 
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
        /* ---- 2.2P Task
          public  void Draw()
        {
            
            SplashKit.FillRectangle(Color, X, Y, Width, Height);
        }*/


        public void Draw()
        {if (Selected)
            {
                DrawOutline();
            }
            SplashKit.FillRectangle(color, _x,_y,_width,_height);
  
        }

        public  bool IsAt(Point2D pt)
        {
            bool pointWithinRange = false;
            double xMax = X + _width;
            double yMax = Y + _height;
            if ((pt.X > X) && (pt.X < xMax))
            {
                if ((pt.Y > Y) && (pt.Y < yMax))
                {
                    pointWithinRange = true;
                }
            }

            return pointWithinRange;
        }
       /* public  bool IsAt(Point2D pt ) --- 2.2P task
        {
            if (pt.X >= Position.X &&
                 pt.X <= Position.X + Width &&
                 pt.Y >= Position.Y &&
                 pt.Y <= Position.Y + Height)
            {
                return true;
            }
            else
                return false;
        }*/
         public void DrawOutline()
        {
            SplashKit.FillRectangle(
                clr: Color.Black,
                x: (X - 2),
                y: (Y - 2),
                width: (Width + 4),
                height: (Height + 4)
                );

        }

        
    }
}
