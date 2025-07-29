using CarFactory.Models.Engines;

public class Wankel : IEngine
{
    public int MaxSpeed => 220;

    public override string ToString()
    {
        return "Wankel";
    }
}