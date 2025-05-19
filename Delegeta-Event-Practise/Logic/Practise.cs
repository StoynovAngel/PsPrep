namespace Delegeta_Event_Practise.Logic;

class Practise
{
    static void Main(string[] args)
    {
        Console.WriteLine("hello");
        Person p = new Person("Angel", 20);

        p.AgeEvent += ShowAgeMessage;
        p.AgeEvent += LetsGoGambling;

        p.CheckIfUserIsOver12(p.Age);
        
        p.AgeEvent -= ShowAgeMessage;
        p.AgeEvent -= LetsGoGambling;
        
        Person.AgeDelegate del = ShowAgeMessage;
        del(5);
    }
    public static void ShowAgeMessage(int val)
    {
        Console.WriteLine($"Event triggered! Age is greater than 12. Passed value: {val}");
    }

    public static void LetsGoGambling(int val)
    {
        Console.WriteLine($"Lets goooo, someone is old enought to gamble hehe: {val}");
    }
}


public class Person
{
    private string _name;
    private int _age;

    public delegate void AgeDelegate(int param);

    public event AgeDelegate AgeEvent;

    public string Name
    {
        get => _name; 
        set
        {
            _name = value;
        }
    }

    public int Age
    {
        get => _age;
        set
        {
            _age = value;
        }
    }

    public Person(string name, int age)
    {
        _name = name;
        _age = age;
    }

    public void CheckIfUserIsOver12(int age)
    {
        if (age > 12)
        {
            AgeEvent.Invoke(age);
        }
    }
}