using ProjectAnimals.Models;

namespace ProjectAnimals.Repositories;

public class IAnimalRepository
{
    IEnumerable<Animals> GetAnimals();

    //void AddAnimal(AddAnimal animal);
}