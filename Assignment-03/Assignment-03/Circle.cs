using System;
class Circle : Shape
{
    public int r { get; set; }
    public int cx { get; set; }
    public int cy { get; set; }
    private int Id { get; set; }

    static int nextId = 0;
    public Circle(int r, int cx, int cy) // Handles defaultinh Color etc.
    {
        this.r = r;
        this.cx = cx;
        this.cy = cy;
        Id = Shape.nextId++;
        stroke = "red";
        fill = "blue";
        strokeWidth = "5";

    }
    public override int GetId()
    {
        return Id;
    }
    public override string ToCode() // Converts to SVG
    {
        String res = $"<circle r=\"{r}\" cx=\"{ cx} \" cy=\"{ cy}\" stroke=\"{stroke}\" stroke-width = \"{strokeWidth}\" fill = \"{fill}\" />";
        return res;
    }
}

