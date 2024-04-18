using Microsoft.AspNetCore.Mvc;
using ProjectAnimals.Controllers.DTOs;
using ProjectAnimals.Models;
using ProjectAnimals.Repositories;

namespace ProjectAnimals.Controllers;

[ApiController]
[Route("api/[controller]")]
public class AnimalsController : ControllerBase
{
    private readonly IAnimalRepository _animalRepository;
    
    public AnimalsController(IAnimalRepository animalRepository)
    {
        _animalRepository = animalRepository;
    }

    [HttpGet]

    public IActionResult GetAnimals(orderByCategories orderBy)
    {
        var animals = _animalRepository.GetAnimals(orderBy);
        
        return Ok(animals);
    }
    
    [HttpPost]

    public IActionResult AddAnimals(AddAnimals animal)
    {
        _animalRepository.AddAnimal(animal);
        
        return Created("", null);
    }
    
    [HttpPut("{id:int}")]

    public IActionResult UpdateAnimals(UpdateAnimals animal,int id)
    {
        _animalRepository.UpdateAnimal(animal,id);
        
        return Created("", null);
    }

    [HttpDelete("{id:int}")]

    public IActionResult RemoveAnimals(int id)
    {
        _animalRepository.RemoveAnimal(id);

        return Ok("REMOVED" + id);
    }
}