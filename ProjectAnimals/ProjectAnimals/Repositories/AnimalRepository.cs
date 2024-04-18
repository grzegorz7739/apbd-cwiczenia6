using ProjectAnimals.Models;
using Microsoft.Data.SqlClient;
using ProjectAnimals.Controllers.DTOs;

namespace ProjectAnimals.Repositories;


public class AnimalRepository : IAnimalRepository
{
    private readonly IConfiguration _configuration;
    
    public AnimalRepository(IConfiguration configuration)
    {
        _configuration = configuration;
    }

    public IEnumerable<Animals> GetAnimals(orderByCategories orderByParameter)
    {
        using SqlConnection connection = new SqlConnection(_configuration.GetConnectionString("Default"));
        connection.Open();

        using SqlCommand command = new SqlCommand();
        command.Connection = connection;
        command.CommandText = "SELECT * From tabelka order by " + orderByParameter;
        //command.Parameters.AddWithValue("@orderByParameter",orderByParameter);

        var reader = command.ExecuteReader();

        var animals = new List<Animals>();

        int idAnimalOrdinal = reader.GetOrdinal("IdAnimal");
        int nameOrdinal = reader.GetOrdinal("Name");
        int descriptionOrdinal = reader.GetOrdinal("Description");
        int categoryOrdinal = reader.GetOrdinal("Category");
        int areaOrdinal = reader.GetOrdinal("Area");
        

        while (reader.Read())
        {
            animals.Add(new Animals()
            {
                IdAnimal = reader.GetInt32(idAnimalOrdinal),
                Name = reader.GetString(nameOrdinal),
                Description = reader.GetString(descriptionOrdinal),
                Category = reader.GetString(categoryOrdinal),
                Area = reader.GetString(areaOrdinal)
            }); 
        }

        return animals;
    }

    public void AddAnimal(AddAnimals animals)
    {
        using SqlConnection connection = new SqlConnection(_configuration.GetConnectionString("Default"));
        connection.Open();

        using SqlCommand command = new SqlCommand();
        command.Connection = connection;
        command.CommandText = "INSERT INTO tabelka values(@name,@description,@category,@area)";
        command.Parameters.AddWithValue("@name", animals.Name);
        command.Parameters.AddWithValue("@description", animals.Description);
        command.Parameters.AddWithValue("@category", animals.Category);
        command.Parameters.AddWithValue("@area", animals.Area);

        command.ExecuteNonQuery();
    }

    public void UpdateAnimal(UpdateAnimals animals,int id)
    {
        using SqlConnection connection = new SqlConnection(_configuration.GetConnectionString("Default"));
        connection.Open();

        using SqlCommand command = new SqlCommand();
        command.Connection = connection;
        command.CommandText = "UPDATE tabelka SET name = @name, description = @description, category = @category, area = @area WHERE IdAnimal = @id ";
        command.Parameters.AddWithValue("@id", id);
        command.Parameters.AddWithValue("@name", animals.Name);
        command.Parameters.AddWithValue("@description", animals.Description);
        command.Parameters.AddWithValue("@category", animals.Category);
        command.Parameters.AddWithValue("@area", animals.Area);
        
        command.ExecuteNonQuery();
    }

    public void RemoveAnimal(int id)
    {
        using SqlConnection connection = new SqlConnection(_configuration.GetConnectionString("Default"));
        connection.Open();

        using SqlCommand command = new SqlCommand();
        command.Connection = connection;
        command.CommandText = "DELETE FROM tabelka WHERE IdAnimal = @id";
        command.Parameters.AddWithValue("@id", id);
        command.ExecuteNonQuery();
    }

}