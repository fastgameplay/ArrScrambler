using System.Diagnostics;

namespace ArrScrambler.Helper;
public class ReplacementRules
{
    private Dictionary<int, string> _rules;
    private Dictionary<string, string> _secondaryRules;
    private List<string> _secondaryReplacementReference;
    public ReplacementRules()
    {
        _rules = new Dictionary<int, string>();
        _secondaryRules = new Dictionary<string, string>();
        _secondaryReplacementReference = new List<string>();
    }

    public void AddRule(int number, string replacement)
    {
        _rules[number] = replacement;
    }
    public void AddSecondaryRule(string key, string replacement)
    {
        _secondaryRules[key] = replacement;
        _secondaryReplacementReference.Add(replacement);
    }
    public void AddSecondaryRule(int key, string replacement)
    {
        if(!_rules.ContainsKey(key)) return;
        _secondaryRules[_rules[key]] = replacement;
        _secondaryReplacementReference.Add(replacement);
    }
    private string[] CheckSecondary(List<string> array)
    {
        if (!_secondaryRules.Keys.All(key => array.Contains(key))) return array.ToArray();

        List<string> output = new List<string>(_secondaryReplacementReference);
        for (int i = 0; i < array.Count; i++)
        {
            if (_secondaryRules.ContainsKey(array[i])) continue;
            output.Add(array[i]);
        }

        return output.ToArray();
    }
    public string GetReplacement(int number)
    {
        List<string> replacement = new List<string>();

        foreach (var rule in _rules)
        {
            if (number % rule.Key == 0)
            {
                replacement.Add(rule.Value);
            }
        }
        string[] output = CheckSecondary(replacement);
        return output.Length != 0 ? string.Join("-", output) : number.ToString();
    }
}