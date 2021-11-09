class Rectangle : Shape
{
    public int x { get; set; }
    public int y { get; set; }
    public int width { get; set; }
    public int height { get; set; }
    public int Id { get; set; } 


    public Rectangle(int x, int y, int width, int height)
    {
        this.x = x;
        this.y = y;
        this.width = width;
        this.height = height;
        Id = Shape.nextId++;
        stroke = "red";
        fill = "blue";
        strokeWidth = "5";

    }

    public override string ToCode() // Converts to SVG
    {
        string res = $"<rect x=\"{x}\" y=\"{ y} \" width=\"{ width}\" height=\"{ height}\" stroke=\"{stroke}\" stroke-width = \"{strokeWidth}\" fill = \"{fill}\"/> ";

        return res;
    }
    public override int GetId()
    {
        return Id;
    }
}

