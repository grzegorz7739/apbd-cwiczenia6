using ProjectAnimals.Models;
using Microsoft.Data.SqlClient;

namespace ProjectAnimals.Repositories;


public class AnimalRepository : IAnimalRepository
{
    private readonly IConfiguration _configuration;
    
    public AnimalRepository(IConfiguration configuration)
    {
        _configuration = configuration;
    }

    public IEnumerable<Animals> GetAnimals()
    {
        using SqlConnection connection = new SqlConnection(_configuration.GetConnectionString("Default"));
        connection.Open();

        using SqlCommand command = new SqlCommand();
        command.Connection = connection;
        command.CommandText = "SELECT * From tabelka;";

        var reader = command.ExecuteReader();

        var animals = new List<Animals>();

        int idAnimalOrdinal = reader.GetOrdinal("IdAnimal");
        int nameOrdinal = reader.GetOrdinal("Name");

        while (reader.Read())
        {
            animals.Add(new Animals()
            {
                IdAnimal = reader.GetInt32(idAnimalOrdinal),
                Name = reader.GetString(nameOrdinal)
            }); 
        }

        return animals;
    }
}