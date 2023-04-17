using SplashKitSDK;
using System;

public class Program
{   public enum ShapeKind
    {
        Rectangle,
        Circle,
        Line
    }
    public static void Main()
    {
        new Window("My Shape", 800, 600);


        ShapeKind kindToADD = ShapeKind.Circle;
        shapedrawer.Drawing drawing = new shapedrawer.Drawing();
    
        do
        {
            SplashKit.ProcessEvents();

            if (SplashKit.KeyDown(KeyCode.SpaceKey))
            {
                drawing.Background = Color.RandomRGB(255);
            }

            if (SplashKit.KeyDown(KeyCode.RKey))
            {
                kindToADD = ShapeKind.Rectangle;
            }
            if (SplashKit.KeyDown(KeyCode.CKey))
            {
                kindToADD = ShapeKind.Circle;
            }
            if (SplashKit.KeyDown(KeyCode.LKey))
            {
                kindToADD = ShapeKind.Line;
            }

            if (SplashKit.MouseClicked(MouseButton.LeftButton))
            {
                          shapedrawer.Shape newShape;

                          if(kindToADD == ShapeKind.Rectangle)
                          {
                            shapedrawer.MyRectangle newRect = new shapedrawer.MyRectangle();
                            newRect.X = SplashKit.MouseX();
                            newRect.Y = SplashKit.MouseY();
                            newShape = newRect;
                        }
                         else if( kindToADD == ShapeKind.Circle) 
                        {
                            shapedrawer.MyCircle newCircle = new shapedrawer.MyCircle();
                            newCircle.X = SplashKit.MouseX();
                            newCircle.Y = SplashKit.MouseY();
                            newShape = newCircle;
                         }
                         else
                        {
                             shapedrawer.MyLine newLine = new shapedrawer.MyLine();
                             newLine.X = SplashKit.MouseX();
                             newLine.Y = SplashKit.MouseY();
                             newShape = newLine;

                          }
                drawing.AddShpaes(newShape);

            }

            drawing.Draw();



            if (SplashKit.MouseClicked(MouseButton.RightButton))
            {
                drawing.SelectShapesAt(SplashKit.MousePosition());
            }

            if (SplashKit.KeyTyped(KeyCode.BackspaceKey)|| (SplashKit.KeyTyped(KeyCode.DeleteKey)))
            {
                drawing.SelectShapesAt(SplashKit.MousePosition());
                drawing.DeleteShapes(drawing.SelectedShapes);
            }


            SplashKit.RefreshScreen();

            SplashKit.ClearScreen();


        }
        while (!SplashKit.WindowCloseRequested("My Shape"));
        Console.WriteLine();
    }
}
