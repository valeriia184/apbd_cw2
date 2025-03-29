using System;
using System.Collections.Generic;
using System.Linq;

namespace apbd_cw2
{
    public class Ship
    {
        public string Name { get; set; }
        public double Speed { get; set; }
        public int MaxContainerNum { get; set; }
        public double MaxWeightTons { get; set; }

        private List<BaseContainer> _containers = new List<BaseContainer>();

        public Ship(string name, double speed, int maxContainerNum, double maxWeightTons)
        {
            Name = name;
            Speed = speed;
            MaxContainerNum = maxContainerNum;
            MaxWeightTons = maxWeightTons;
        }

        public void AddContainer(BaseContainer container)
        {
            if (_containers.Count >= MaxContainerNum)
            {
                throw new Exception($"Statek {Name} nie może przyjąć więcej kontenerów (limit: {MaxContainerNum}).");
            }
            double currentWeight = _containers.Sum(c => c.OwnWeight + c.CargoMass);
            double newWeight = currentWeight + (container.OwnWeight + container.CargoMass);
            if (newWeight / 1000.0 > MaxWeightTons)
            {
                throw new Exception($"Statek {Name} przekroczy dopuszczalną masę ładunku (limit: {MaxWeightTons} ton).");
            }
            _containers.Add(container);
        }

        public void RemoveContainer(string serialNumber)
        {
            var container = _containers.FirstOrDefault(c => c.SerialNumber == serialNumber);
            if (container != null)
            {
                _containers.Remove(container);
            }
            else
            {
                throw new Exception($"Nie znaleziono kontenera o numerze {serialNumber} na statku {Name}.");
            }
        }

        public void PrintInfo()
        {
            Console.WriteLine($"--- {Name} ---");
            Console.WriteLine($"Prędkość: {Speed}, Max kontenery: {MaxContainerNum}, Max waga (t): {MaxWeightTons}");
            Console.WriteLine($"Aktualnie kontenerów: {_containers.Count}");
            foreach (var c in _containers)
            {
                Console.WriteLine("   " + c.ToString());
            }
            Console.WriteLine("---------------------------------\n");
        }

        public void SwapContainers(string serialNumA, string serialNumB)
        {
            var indexA = _containers.FindIndex(c => c.SerialNumber == serialNumA);
            var indexB = _containers.FindIndex(c => c.SerialNumber == serialNumB);
            if (indexA == -1 || indexB == -1)
            {
                throw new Exception("Nie odnaleziono kontenera do podmiany.");
            }
            var temp = _containers[indexA];
            _containers[indexA] = _containers[indexB];
            _containers[indexB] = temp;
        }

        public void MoveContainerToAnotherShip(string serialNumber, Ship otherShip)
        {
            var container = _containers.FirstOrDefault(c => c.SerialNumber == serialNumber);
            if (container == null)
            {
                throw new Exception("Nie znaleziono kontenera do przeniesienia.");
            }
            _containers.Remove(container);
            otherShip.AddContainer(container);
        }

        public int GetContainerCount()
        {
            return _containers.Count;
        }

        public BaseContainer GetContainerBySerial(string serialNumber)
        {
            return _containers.FirstOrDefault(c => c.SerialNumber == serialNumber);
        }
    }
}
