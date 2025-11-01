using System.Xml.Linq;

namespace FormatDifference;

class Program
{
    static void Main(string[] args)
    {
        JsonFormat jsonFormat = new JsonFormat();
        jsonFormat.Display();

        XmlDifference();
        
        XmlFormat xmlFormat = new XmlFormat();
        xmlFormat.Display();
    }

    static void XmlDifference()
    {
        XDocument xmlDocument = XDocument.Load("person.xml");
        var root = xmlDocument.Root;
        
        var name = root.Element("name").Value; // "Angel"
        var age = root.Element("age").Value; // "10"
        var universityStatus = root.Element("universityStudent").Value; // true

        Console.WriteLine($"\nBefore proper deserialization - XML TYPES:");
        Console.WriteLine($"name: {name.GetType()}"); // String
        Console.WriteLine($"age: {age.GetType()}"); // String
        Console.WriteLine($"status: {universityStatus.GetType()}"); // String
    }
}