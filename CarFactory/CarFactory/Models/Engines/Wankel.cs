using CarFactory.Models.Engines;

public class Wankel : IEngine
{
    public int MaxSpeed => 220;

    public string Name => "Wankel";
}