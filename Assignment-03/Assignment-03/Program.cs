using System;
using System.Collections.Generic;
using System.IO;

class Program
{
    static void Main()
    {
        // Making canvas of 285 by 350
        Canvas canvas = new Canvas(285,350);
        string SVGOut = @"Assignment-02/canvas.svg";
        // Create list to hold poly points
        List<string> pLine = new List<string>();
        pLine.Add("50,50");
        pLine.Add("24,55");
        pLine.Add("166,320");
        pLine.Add("230,150");
        pLine.Add("290,250");

        // Creating path is a little different
        Path myPath = new Path("150 0");
        myPath.AddInstruction("L");
        myPath.AddPoint("75 200");
        myPath.AddInstruction("L");
        myPath.AddPoint("225 200");

        //Add Shapes to canvas
        canvas.AddShape(new Line(100, 300, 400, 340));
        canvas.AddShape(new Rectangle(100, 50 , 75, 75)); 
        canvas.AddShape(new Circle(50,50,50));
        canvas.AddShape(new Polygon(pLine));
        canvas.AddShape(new Ellipse(100,100,100,100));
        canvas.AddShape(new Polyline(pLine));
        canvas.AddShape(myPath);

        // Showing canvas before we start editing
        Console.WriteLine("Before:");
        canvas.ReturnList(); 

        //Controlling stack order 
        /*canvas.MoveDown(myLine.GetId(), 0);
        canvas.MoveUp(myPolygon.GetId(), 4); // you get the gist*/

        // Editing shape attributs
        /*myPolygon.EditPoint(1, "300,20"); 
        myCirc.fill = "yellow";
        myRec.x = 230;
        myPath.UpdatePathCommand(3, "H"); // Was 'L', made it 'H'
        myLine.x1 = 300;
        myPolyline.EditPoint(2, "200,200");
        myEllipse.cx = 123;


        // Deleting shapes          
        canvas.DeleteShape(myCirc.GetId()); // Will delete circle
        canvas.DeleteShape(myPolyline.GetId()); // Will delete polyline, you get the gist*/

        canvas.undoShape();
        Console.WriteLine(canvas.CanvasToSVG());


        Console.WriteLine();
        Console.WriteLine("-----------------------------------------------------------------");
        Console.WriteLine();

        // Outputs
        Console.WriteLine("After:");
        canvas.ReturnList();

        Console.WriteLine();
        Console.WriteLine("-----------------------------------------------------------------");
        Console.WriteLine();

        canvas.redoShape();
        canvas.ReturnList();


        /*try
        {
            File.WriteAllText(SVGOut, canvas.CanvasToSVG());
        }catch(System.IO.DirectoryNotFoundException e)
        {
            Console.WriteLine();
            Console.WriteLine("****************************************");
            Console.WriteLine("Please use Developer powershell to run");
            Console.WriteLine("****************************************");
    
        }*/


    }
}





