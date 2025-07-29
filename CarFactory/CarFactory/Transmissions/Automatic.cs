namespace CarFactory.Transmissions
{
    public class Automatic : ITransmission
    {
        public int Gears => 6;

        public override string ToString()
        {
            return "Automatic";
        }
    }
}