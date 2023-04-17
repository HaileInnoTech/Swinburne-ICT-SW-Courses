using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using SplashKitSDK;

namespace shapedrawer
{
     class Drawing
    {
        private readonly List<Shape> _shapes;

        private Color _background;


        public Drawing(Color background)
        {
            _shapes = new List<Shape>();
            _background = background;

        }
        public Drawing(): this (Color.White)
        {
            
        }
            public void SelectShapesAt(Point2D pt)
            {
                foreach (Shape shape in _shapes)
                {
                    shape.Selected = shape.IsAt(pt);
                }
            }
      
        public List<Shape> SelectedShapes
        {
            get
            {
                List<Shape> result = new List<Shape>();
                foreach (Shape s in _shapes)
                {
                    if (s.Selected)
                    {
                        result.Add(s);
                    }
                }

                return result;
            }
        }
        public int ShapeCount { 
            get { return _shapes.Count; }
        }
        public  void AddShpaes(Shape shape)
        {
            _shapes.Add(shape);

        }
            

        public virtual void Draw()
        {
            SplashKit.ClearScreen(_background);
            foreach(Shape shape in _shapes)
            {
                shape.Draw();
            }
        }
        public void DeleteShapes(List<Shape> shapes)
        {
            foreach (var shape in shapes)
            {
                _shapes.Remove(shape);
            }
        }

        public Color Background
        {
            get
            {
                return _background;
            }
            set
            {
                _background = value;
            }
        }


    }
}
