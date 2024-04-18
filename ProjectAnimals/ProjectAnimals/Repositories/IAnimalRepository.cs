using ProjectAnimals.Controllers.DTOs;
using ProjectAnimals.Models;

namespace ProjectAnimals.Repositories;

public interface IAnimalRepository
{
    IEnumerable<Animals> GetAnimals(orderByCategories orderBy);

    void AddAnimal(AddAnimals animal);
    void UpdateAnimal(UpdateAnimals animal,int id);
    void RemoveAnimal(int id);
}