using System.Text.Json;

namespace FormatDifference;

public class JsonFormat : Format
{
    private const string JsonPath = "person.json";
    
    public override void Display()
    {
        var path = Path.Combine(AppContext.BaseDirectory, JsonPath);
        if (!File.Exists(path))
        {
            Console.WriteLine("File not found.");
            return;
        }

        var json = File.ReadAllText(path);
        var person = JsonSerializer.Deserialize<Person>(json)!;

        Console.WriteLine("Name: " + person.name + " Type: " + person.name.GetType());
        Console.WriteLine("Age: " + person.age + " Type: " + person.age.GetType());
        Console.WriteLine("Status: " + person.universityStudent + " Type: " + person.universityStudent.GetType());
    }
}