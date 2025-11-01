namespace Delegeta_Event_Practise.Logic;

class Practise
{
    public delegate void DelegateAge(int age);
    public static event DelegateAge AgeEvent;
    
    public static void IsPersonOver18(int age)
    {
        if (age > 18)
        {
            AgeEvent.Invoke(age);
        }
    }
    
    static void Main(string[] args)
    {
        AgeEvent += Casino;
        AgeEvent += Drinking;
        IsPersonOver18(10);

        foreach (var item in AgeEvent.GetInvocationList())
        {
            Console.WriteLine($"Method: {item.Method.Name}");
        }

        AgeEvent -= Casino;
        AgeEvent -= Drinking;
        
        DelegateAge ageDe = Casino;
        ageDe(200);
    }

    private static void Casino(int age)
    {
        Console.WriteLine("Lets go gambling. You are over 18. Age:" + age);
    }
    
    private static void Drinking(int age)
    {
        Console.WriteLine("Lets go drinking. You are over 18. Age:" + age);
    }
}