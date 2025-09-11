namespace WebApi.Controllers;

public class ControllerHelper
{
    private const int MinId = 1;
    private const int MaxId = 1000000000;

    public static int GenerateId()
    {
        Random rnd = new Random();

        return rnd.Next( MinId, MaxId );
    }
}