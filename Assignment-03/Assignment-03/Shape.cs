abstract class Shape
{
    public string stroke = "";
    public string fill = "";
    public string strokeWidth = "";
    public static int nextId = 1000;
    /*public Shape()
    {
        Id = Shape.countID;
    }*/
    public virtual string ToCode() // Virtual because I just want to use it as a placeholder rather than a method
    {
        return "";
    }

    public virtual int GetId() //  same thing ^
    {
        return 0;
    }
}
