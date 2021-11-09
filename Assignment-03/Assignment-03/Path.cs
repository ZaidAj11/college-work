using System;
using System.Collections.Generic;
using System.Linq;
using System.Text.RegularExpressions;
class Path : Shape
{
    public int Id { get; set; }
    public string Start = "";
    private List<string> myPath = new List<string>();
    Regex commands = new Regex("[MLHVCSQTA]"); // leave out z because that will closepath
    public Path(string start) // Handles defaulting
    {
        this.Start = start;
        Id = Shape.nextId++;
        stroke = "red";
        strokeWidth = "5";
        fill = "purple";
        myPath.Add("M");
        myPath.Add(start);
    }

    public void AddInstruction(string command) // adds an instruction from [MLHVCSQTAZ]
    {
        if (!commands.IsMatch(myPath[myPath.Count() - 1])) myPath.Add(command);
        else { Console.WriteLine("Incorrect command"); }

    }
    public void AddPoint(string point) // Adds a point for that command
    {
        if (commands.IsMatch(myPath[myPath.Count() - 1])) myPath.Add(point);
        else { Console.WriteLine("Must add a point first"); }
    }
        
    public override string ToCode() // Convert to SVG
    {
        string res = "<path d = \" ";
        for(int i = 0;i < myPath.Count(); i++)
        {
            res += myPath[i];
        }
        if (myPath[myPath.Count() - 1] != "Z") res += $" Z \" stroke=\"{stroke}\" stroke-width = \"{strokeWidth}\" fill = \"{fill}\" />";
        else { res += $"\" stroke=\"{stroke}\" stroke-width = \"{strokeWidth}\" fill = \"{fill}\" />"; }
        return res;
    }

    public void UpdatePathCommand(int index, string NewCommand) // Changes command in list by index, intuitively, so starting at 1...
    {
        if (commands.IsMatch(NewCommand))
        {
            for (int i = 0; i < myPath.Count(); i++)
            {
                if (i == index - 1)
                {
                    myPath[i] = NewCommand;
                }
            }
        }
        else { Console.WriteLine("Not a command"); }
    }
    public void UpdatePathPoint(int index, string NewPoint) // Changes point in list by index, intuitively, so starting at 1...
    {
        if (!commands.IsMatch(NewPoint))
        {
            for (int i = 0; i < myPath.Count(); i++)
            {
                if (i == index - 1)
                {
                    myPath[i] = NewPoint;
                }
            }
        }
        else { Console.WriteLine("Not a point"); }
    }

    public override int GetId()
    {
        return Id;
    }
}

