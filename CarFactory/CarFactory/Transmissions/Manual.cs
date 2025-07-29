namespace CarFactory.Transmissions
{
    public class Manual : ITransmission
    {
        public int Gears => 5;

        public override string ToString()
        {
            return "Manual";
        }
    }
}