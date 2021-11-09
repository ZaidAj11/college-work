using System.Collections.Generic;
class Polygon : Shape
{
    List<string> points = new List<string>(); // List of points as strings eg. "120,150"

    public int Id { get; set; }
    public Polygon(List<string> points) // Handles defaulting 
    {
        this.points = points;
        Id = Shape.nextId++;
        stroke = "purple";
        fill = "lime";
        strokeWidth = "2";
    }
    public void addPoint(string point) // Adds a point to the list of points
    {
        points.Add(point);
    }
    public override int GetId()
    {
        return Id;
    }
    public override string ToCode() // Converts to SVG
    {
        string res = "<polygon points = \" ";
        for (int i = 0; i < points.Count; i++)
        {
            string checker = i % 2 == 0 ? "," : " ";
            res += $"{points[i]} ";
        }
        res = res.Substring(0, res.Length - 1);
        res += $"\" style = \"fill:{fill};stroke:{stroke};stroke-width:{strokeWidth}\"/>";
        return res;
    }

    public void EditPoint(int index, string point) // Edit the points: "index" is where the current point is intuitively(starting at 1) 
                                                    // and "point" is the new point
    {
        for(int i = 0;  i < points.Count; i++)
        {
            if(i == index - 1)
            {
                points[i] = point;
            }
        }
    }
}
