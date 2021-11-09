class Ellipse : Shape
{
    public int rx { get; set; }
    public int ry { get; set; }
    public int cx { get; set; }
    public int cy { get; set; }
    private int Id { get; set; }


    public Ellipse(int rx, int ry, int cx, int cy) // Handles defaulting
    {
        this.rx = rx;
        this.ry = ry;
        this.cx = cx;
        this.cy = cy;
        Id = Shape.nextId++;
        stroke = "grey";
        fill = "orange";
        strokeWidth = "10";

    }

    public override string ToCode() // Converts to SVG
    {
        string res = $"<ellipse cx=\"{cx}\" y=\"{ cy} \" rx=\"{ rx}\" ry=\"{ ry}\" stroke=\"{stroke}\" stroke-width = \"{strokeWidth}\" fill = \"{fill}\"/> ";

        return res;
    }

    public override int GetId()
    {
        return Id;
    }
}

