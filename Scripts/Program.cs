namespace ArrScrambler.Main;

using ArrScrambler.Helper;
class Program
{   
    static void Main(string[] args)
    {
        var numbers = new List<int> { 1, 2, 3, 4, 5, 6, 7, 8, 9, 10, 11, 12, 13, 14, 15, 60, 105, 420 };
        ReplacementRules rules = new ReplacementRules();
        rules.AddRule(3, "dog");
        rules.AddRule(5, "cat");
        rules.AddRule(4, "muzz");
        rules.AddRule(7, "guzz");
        
        rules.AddSecondaryRule(3, "good");
        rules.AddSecondaryRule(5, "boy");

        Console.WriteLine("Original numbers:");
        Console.WriteLine(string.Join(", ", numbers));

        Console.WriteLine("\nApplying Custom Rules:");
        Console.WriteLine(string.Join(", ", ReplacementHelper.ApplyRules(numbers, rules)));

    }
}
