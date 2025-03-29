using apbd_cw2;

namespace ContainersApp
{
    public abstract class BaseContainer
    {
        private static int _globalCounter = 1;

        public string SerialNumber { get; private set; }
        public double CargoMass { get; protected set; }
        public double OwnWeight { get; protected set; }
        public double MaxCapacity { get; protected set; }
        public double Height { get; protected set; }
        public double Depth { get; protected set; }

        protected BaseContainer(string typeIndicator, double maxCapacity, double ownWeight, double height, double depth)
        {
            MaxCapacity = maxCapacity;
            OwnWeight = ownWeight;
            Height = height;
            Depth = depth;
            SerialNumber = $"KON-{typeIndicator}-{_globalCounter++}";
        }

        public virtual void Unload()
        {
            CargoMass = 0;
        }

        public abstract void Load(double massToLoad);

        protected void CheckOverfill(double desiredTotalLoad)
        {
            if (desiredTotalLoad > MaxCapacity)
            {
                throw new OverfillException($"Przekroczono maksymalną ładowność kontenera {SerialNumber} (max: {MaxCapacity}, próba: {desiredTotalLoad})");
            }
        }

        public override string ToString()
        {
            return $"{SerialNumber} | CargoMass: {CargoMass} kg | OwnWeight: {OwnWeight} kg | MaxCapacity: {MaxCapacity} kg | Height: {Height} cm | Depth: {Depth} cm";
        }
    }
}