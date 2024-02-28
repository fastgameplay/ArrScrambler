namespace ArrScrambler.Helper;
public static class ReplacementHelper
{
    public static List<string> ApplyRules(List<int> numbers, ReplacementRules rules)
    {
        var result = new List<string>();

        foreach (var number in numbers)
        {
            result.Add(rules.GetReplacement(number));
        }

        return result;
    }
}