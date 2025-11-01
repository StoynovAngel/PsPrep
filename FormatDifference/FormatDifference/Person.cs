using System.Xml.Serialization;

namespace FormatDifference;

[XmlRoot("person")]
public class Person
{
    public string name { get; set; }
    public int age { get; set; }
    public bool universityStudent { get; set; }
}