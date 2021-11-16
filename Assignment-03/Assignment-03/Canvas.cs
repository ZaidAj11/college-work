using System;
using System.Collections.Generic;
using System.Linq;

class Canvas
{
    public List<Shape> canvas = new List<Shape>(); // List of shapes -> the canvas
    public List<Shape> canvasState = new List<Shape>(); // List of shapes -> the canvas

    public List<Shape> canvasPriorState = new List<Shape>(); // List of shapes -> the canvas


    public int width = 0;
    public int height = 0;
    public Canvas(int width, int height)
    {
        this.width = width;
        this.height = height;
    }
    public void AddShape(Shape shape) // Add a shape
    {
        canvasPriorState = canvas.ToList();
        canvas.Add(shape);
        
    }

    public void MoveDown(int shape, int layer) // Move down in Z index
    {

        Shape[] arr = canvas.ToArray();
        int index = 0;
        for (int i = 0; i < arr.Length; i++)
        {
            if (arr[i].GetId() == shape) index = i; // Where our shape is right now i.e put it on below other shape(s)
        }

        for (int i = index; i > 0; i--)
        {
            if (i == layer) break;
            else
            {
                Shape temp = arr[i];
                arr[i] = arr[i - 1];
                arr[i - 1] = temp;
            }

        }
        List<Shape> tempStack = new List<Shape>(arr);
        canvas = tempStack;

    }
    public void MoveUp(int shape, int layer) // Move up in Z index i.e put it on top of other shape(s)
    {

        Shape[] arr = canvas.ToArray();
        int index = 0;
        for (int i = 0; i < arr.Length; i++)
        {
            if (arr[i].GetId() == shape) index = i; // Where our shape is right now
        }

        for (int i = index; i < arr.Length - 1; i++) // Then swap it until we get our desired layer
        {
            if (i == layer) break;
            else
            {
                Shape temp = arr[i];
                arr[i] = arr[i + 1];
                arr[i + 1] = temp;
            }

        }
        List<Shape> tempStack = new List<Shape>(arr);
        canvas = tempStack;

    }
    private List<Shape> getCanvas() // Return the list 
    {
        return canvas;
    }
    public string CanvasToSVG() //  Convert to SVG
    {
        Shape[] arr = canvas.ToArray();

        string code = $"<svg width = \"285\" height = \"350\" viewBox=\"0 0 285 350\" >";
        for (int i = 0; i <= arr.Length - 1; i++)
        {
            code += Environment.NewLine;
            code += arr[i].ToCode();
        }
        code += Environment.NewLine;
        code += "</svg>";
        return code;
    }
    public void ReturnList() // Print the List with Z index
    {
        List<Shape> Out = getCanvas();
        List<string> arr = new List<string>();
        int i = 0;
        foreach (var shape in Out)
        {
            arr.Add($"{i} - {$"{shape.GetType()}".Split('.').Last()} {shape.GetId()}" + $" ID:{shape.GetId()}");
            i++;
        }
        arr.Reverse();
        foreach (var shape in arr)
        {
            Console.WriteLine(shape);
        }
    }

    public List<Shape> DeleteShape(int shape) // Delete a shape
    {
        List<Shape> list = new List<Shape>(canvas.ToArray().ToList());
        for (int i = 0; i < list.Count; i++)
        {
            if (list[i].GetId() == shape) list.RemoveAt(i);
        }
        canvas = new List<Shape>(list);
        return canvas;

    }

    public List<Shape> undoShape() 
    {
        canvasState = canvas.ToList();
        canvas = canvasPriorState;
        return canvas;

    }

    public List<Shape> redoShape() 
    {
        canvas = canvasState;
        return canvas;
    }
}



