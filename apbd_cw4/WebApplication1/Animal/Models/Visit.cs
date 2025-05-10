namespace WebApplication1.Models
{
    public class Visit
    {
        private static int _nextVisitId = 0;

        public int VisitId { get; private set; }
        public DateTime VisitDate { get; set; }
        public int AnimalId { get; set; }
        public string Description { get; set; }
        public decimal PriceForVisit { get; set; }

        public Visit(DateTime visitDate, int animalId, string description, decimal priceForVisit)
        {
            VisitId = ++_nextVisitId;
            VisitDate = visitDate;
            AnimalId = animalId;
            Description = description;
            PriceForVisit = priceForVisit;
        }

        public Visit()
        {
            VisitId = ++_nextVisitId;
        }
    }
}