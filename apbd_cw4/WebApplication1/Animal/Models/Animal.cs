namespace WebApplication1.Models
{
    public class Animal
    {
        private static int _nextId = 0;

        public int AnimalId { get; private set; }
        public string Name { get; set; }
        public string Species { get; set; }
        public int Weight { get; set; }
        public string Color { get; set; }

        public Animal(string name, string species, int weight, string color)
        {
            AnimalId = ++_nextId;
            Name = name;
            Species = species;
            Weight = weight;
            Color = color;
        }

        public Animal()
        {
            AnimalId = ++_nextId;
        }
    }
}