using Microsoft.AspNetCore.Mvc;
using WebApplication1.Models;

namespace WebApplication1.Controllers
{
    [Route("api/animal/{animalId}/visits")]
    [ApiController]
    public class VisitsController : ControllerBase
    {
        [HttpGet]
        public ActionResult<List<Visit>> GetAllVisitsForAnimal(int animalId)
        {
            var animalVisits = Database.VisitList
                .Where(v => v.AnimalId == animalId)
                .ToList();

            return Ok(animalVisits);
        }

        [HttpGet("{visitId}")]
        public ActionResult<Visit> GetVisitById(int animalId, int visitId)
        {
            var visit = Database.VisitList
                .FirstOrDefault(v => v.AnimalId == animalId && v.VisitId == visitId);

            if (visit == null)
                return NotFound();

            return Ok(visit);
        }

        [HttpPost]
        public ActionResult<Visit> AddVisit(int animalId, [FromBody] Visit newVisit)
        {
            if (newVisit == null)
                return BadRequest("Visit data is required.");

            newVisit.AnimalId = animalId;
            newVisit.VisitDate = DateTime.Now;

            Database.VisitList.Add(newVisit);

            return CreatedAtAction(
                nameof(GetVisitById),
                new { animalId, visitId = newVisit.VisitId },
                newVisit
            );
        }
    }
}