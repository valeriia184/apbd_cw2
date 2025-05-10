using Microsoft.AspNetCore.Mvc;

namespace WebApplication1.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AnimalController : ControllerBase
    {
        [HttpGet]
        public IActionResult GetAllAnimals()
        {
            var allAnimals = Database.AnimalList;
            if (allAnimals == null || allAnimals.Count == 0)
                return NotFound();

            return Ok(allAnimals);
        }

        [HttpGet("{id}")]
        public IActionResult GetAnimalById(int id)
        {
            var selectedAnimal = Database.AnimalList.FirstOrDefault(a => a.AnimalId == id);
            if (selectedAnimal == null)
                return NotFound();

            return Ok(selectedAnimal);
        }

        [HttpGet("search")]
        public IActionResult SearchAnimalsByName(string name)
        {
            var matchingAnimals = Database.AnimalList
                .Where(a => a.Name.Contains(name, StringComparison.OrdinalIgnoreCase))
                .ToList();

            if (matchingAnimals.Count == 0)
                return NotFound();

            return Ok(matchingAnimals);
        }

        [HttpPost]
        public IActionResult AddAnimal([FromBody] Models.Animal newAnimal)
        {
            Database.AnimalList.Add(newAnimal);
            return CreatedAtAction(nameof(GetAnimalById), new { id = newAnimal.AnimalId }, newAnimal);
        }

        [HttpPut("{id}")]
        public IActionResult UpdateAnimal(int id, [FromBody] Models.Animal updatedAnimal)
        {
            var existingAnimal = Database.AnimalList.FirstOrDefault(a => a.AnimalId == id);
            if (existingAnimal == null)
                return NotFound();

            existingAnimal.Name = updatedAnimal.Name;
            existingAnimal.Species = updatedAnimal.Species;
            existingAnimal.Weight = updatedAnimal.Weight;
            existingAnimal.Color = updatedAnimal.Color;

            return Ok(existingAnimal);
        }

        [HttpDelete("{id}")]
        public IActionResult DeleteAnimal(int id)
        {
            var animalToRemove = Database.AnimalList.FirstOrDefault(a => a.AnimalId == id);
            if (animalToRemove == null)
                return NotFound();

            Database.AnimalList.Remove(animalToRemove);
            return Ok();
        }
    }
}
