using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;
using SplashKitSDK;
namespace shapedrawer
{
    public class MyCircle : Shape
    {
        private int _radius;

        public MyCircle(Color color, int radius) : base(color)
        {
            _radius = radius;
        }
        public MyCircle() : this(Color.Blue, 50) { }

        public int Radius { get => _radius; set => _radius = value; }

        public override void Draw()
        {
            if (Selected)
            {
                this.DrawOutline();
            }
            SplashKit.FillCircle(Color, X, Y, _radius);
        }
        public override void DrawOutline()
        {
            SplashKit.FillCircle(Color.Black, X, Y , _radius + 2);
        }

        public override bool IsAt(Point2D point)
        {
            return SplashKit.PointInCircle(point, SplashKit.CircleAt(X, Y, _radius));
        }

    }
}
