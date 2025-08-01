namespace CarFactory.Models.Transmissions
{
    public class Robotic : ITransmission
    {
        public int Gears => 7;

        public override string ToString()
        {
            return "Robotic";
        }
    }
}