using SplashKitSDK;
using System;

public class Program
{
    public static void Main()
    {
        new Window("My Shape", 800, 600);
        shapedrawer.Drawing drawing = new shapedrawer.Drawing();
    
        do
        {
            SplashKit.ProcessEvents();

            if (SplashKit.KeyDown(KeyCode.SpaceKey))
            {
                drawing.Background = Color.RandomRGB(255);
            }

            if (SplashKit.MouseClicked(MouseButton.LeftButton)){

                shapedrawer.Shape newShape = new shapedrawer.Shape();
                newShape.X = SplashKit.MouseX();
                newShape.Y = SplashKit.MouseY();
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
