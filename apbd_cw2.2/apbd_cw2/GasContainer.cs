namespace apbd_cw2
{
    public class GasContainer : BaseContainer, IHazardNotifier
    {
        public double Pressure { get; private set; }

        public GasContainer(double pressure, double maxCapacity, double ownWeight, double height, double depth)
            : base("G", maxCapacity, ownWeight, height, depth)
        {
            Pressure = pressure;
        }

        public override void Load(double massToLoad)
        {
            double newTotal = CargoMass + massToLoad;
            CheckOverfill(newTotal);
            CargoMass = newTotal;
        }

        public override void Unload()
        {
            CargoMass *= 0.05;
        }

        public void NotifyHazard(string message, string containerNumber)
        {
            System.Console.WriteLine($"[HAZARD - {containerNumber}] {message}");
        }
    }
}