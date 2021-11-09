class Line : Shape
{
    public int x1 { get; set; }
    public int y1 { get; set; }
    public int x2 { get; set; }
    public int y2 { get; set; }
    public int Id { get; set; }

    private readonly string fill = "none"; // Readonly as this has to saty none

    public Line(int x1, int y1, int x2, int y2)
    {
        this.x1 = x1;
        this.y1 = y1;
        this.x2 = x2;
        this.y2 = y2;
        Id = Shape.nextId++;
        stroke = "red";
        strokeWidth = "5";
    }

    public override string ToCode() // Convert to SVG
    {
        string res = $"<line x1=\"{x1}\" y1=\"{ y1} \" x2=\"{ x1}\" y2=\"{ y2}\" stroke=\"{stroke}\" stroke-width = \"{strokeWidth}\" fill = \"{fill}\"/> ";

        return res;
    }        
    public override int GetId()
    {
        return Id;
    }
}

