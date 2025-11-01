using System.Xml.Serialization;

namespace FormatDifference;

public class XmlFormat : Format
{
    private const string XmlPath = "person.xml";
    
    public override void Display()
    {
        var path = Path.Combine(AppContext.BaseDirectory, XmlPath);
        if (!File.Exists(path))
        {
            Console.WriteLine("File not found.");
            return;
        }

        var xmlContent = File.ReadAllText(path);
        using var stringReader = new StringReader(xmlContent);
        
        var xmlSerializer = new XmlSerializer(typeof(Person));
        var person = (Person) xmlSerializer.Deserialize(stringReader);

        if (person == null)
        {
            Console.WriteLine("Person is null.");
            return;
        }
        
        Console.WriteLine("\nName: " + person.name + " Type: " + person.name.GetType());
        Console.WriteLine("Age: " + person.age + " Type: " + person.age.GetType());
        Console.WriteLine("Status: " + person.universityStudent + " Type: " + person.universityStudent.GetType());
    }
}