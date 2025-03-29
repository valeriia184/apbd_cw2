using System;
using System.Collections.Generic;

namespace apbd_cw2
{
    public class RefrigeratedContainer : BaseContainer
    {
        private static readonly Dictionary<string, double> RequiredTemperatures = new Dictionary<string, double>
        {
            { "Bananas",  13.3 },
            { "Chocolate", 18.0 },
            { "Fish",      2.0 },
            { "Meat",     -15.0 },
            { "Ice cream",-18.0 },
            { "Frozen pizza",-17.0 },
            { "Cheese",   2.0 },
            { "Sausage",  7.2 },
            { "Butter",   20.5 },
            { "Eggs",     19.0 }
        };

        public string ProductType { get; private set; }
        public double Temperature { get; private set; }

        public RefrigeratedContainer(string productType, double setTemperature, double maxCapacity, double ownWeight, double height, double depth)
            : base("C", maxCapacity, ownWeight, height, depth)
        {
            ProductType = productType;
            SetTemperature(setTemperature);
        }

        public void SetTemperature(double temp)
        {
            if (RequiredTemperatures.ContainsKey(ProductType))
            {
                double required = RequiredTemperatures[ProductType];
                if (temp < required)
                {
                    throw new Exception($"Temperatura {temp}°C jest zbyt niska dla produktu {ProductType} (wymaga minimum {required}°C)!");
                }
            }
            Temperature = temp;
        }

        public override void Load(double massToLoad)
        {
            double newTotal = CargoMass + massToLoad;
            CheckOverfill(newTotal);
            CargoMass = newTotal;
        }
    }
}