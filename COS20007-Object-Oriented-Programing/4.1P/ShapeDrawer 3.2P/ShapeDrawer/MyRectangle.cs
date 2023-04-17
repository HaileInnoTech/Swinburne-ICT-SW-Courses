using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;
using SplashKitSDK;

namespace shapedrawer
{
    public class MyRectangle :Shape
    {
        private int _height, _width;
        public  MyRectangle(Color clr, float x, float y, int width, int height ): base (clr)
        {
            X = x;
            Y = y;
            Width = width;
            Height = height;
        }
        public MyRectangle() : this(Color.Green, 0, 0, 100, 100) { }

        public int Width { get => _width; set => _width = value; }
        public int Height { get => _height; set => _height = value; }

        public override void Draw()
        {
            if (Selected)
            {
                this.DrawOutline();
            }
            SplashKit.FillRectangle(Color, X, Y, Width, Height);
        }

        public override void DrawOutline()
        {
            SplashKit.FillRectangle(Color.Black, X - 2, Y - 2, Width + 4, Height + 4);
        }
        public override bool IsAt(Point2D point)
        {
            return SplashKit.PointInRectangle(point, SplashKit.RectangleFrom(X, Y, Width, Height));
        }
    }
}
