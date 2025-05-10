using WebApplication1.Models;

namespace WebApplication1
{
    public static class Database
    {
        public static readonly List<WebApplication1.Models.Animal> AnimalList = new List<WebApplication1.Models.Animal>
        {
            new WebApplication1.Models.Animal("X", "Minotaur", 300, "Red"),
            new WebApplication1.Models.Animal("Y", "Pegaz", 210, "White"),
            new WebApplication1.Models.Animal("A", "Unicorn", 200, "Rainbow"),
            new WebApplication1.Models.Animal("B", "Cyklop", 1500, "Black")
        };

        public static readonly List<Visit> VisitList = new List<Visit>
        {
            new Visit(DateTime.Today, 1, "Grooming", 1500),
            new Visit(DateTime.Today, 2, "Bath",400 ),
            new Visit(DateTime.Today, 3, "Nutritionist", 500),
            new Visit(DateTime.Today, 4, "Rehabilitation", 2000)
        };
    }
}