namespace apbd_cw2
{
    public class LiquidContainer : BaseContainer, IHazardNotifier
    {
        public bool IsHazardous { get; private set; }

        public LiquidContainer(bool isHazardous, double maxCapacity, double ownWeight, double height, double depth)
            : base("L", maxCapacity, ownWeight, height, depth)
        {
            IsHazardous = isHazardous;
        }

        public override void Load(double massToLoad)
        {
            double maxAllowed = IsHazardous ? 0.5 * MaxCapacity : 0.9 * MaxCapacity;
            double newTotal = CargoMass + massToLoad;
            if (newTotal > maxAllowed)
            {
                NotifyHazard($"Próba załadowania zbyt dużej ilości towaru (limit: {maxAllowed} kg).", SerialNumber);
                throw new OverfillException($"Przekroczono dozwolony limit dla kontenera płynów {SerialNumber}. (Limit: {maxAllowed} kg, Próba: {newTotal} kg)");
            }
            CheckOverfill(newTotal);
            CargoMass = newTotal;
        }

        public void NotifyHazard(string message, string containerNumber)
        {
            System.Console.WriteLine($"[HAZARD - {containerNumber}] {message}");
        }
    }
}