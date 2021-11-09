using System.Collections.Generic;

//namespace Assignment-02
//{

    class Polyline : Shape
    {
        List<string> points = new List<string>(); // List of points as strings eg. "120,150"
        static int nextId = 200;
        public string stroke = "";
        public int Id { get; set; }
        private readonly string fill = "none";
        public Polyline(List<string> points) // Handles defaulting 
        {
            this.points = points;
            Id = Shape.nextId++;
            stroke = "green";
            strokeWidth = "5";
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
            string res = "<polyline points = \" ";
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
            for (int i = 0; i < points.Count; i++)
            {
                if (i == index - 1)
                {
                    points[i] = point;
                }
            }
        }
    }
//}

