public class Solution {
    private Dictionary<char, char[]> _table = new () {
        {'2', new char[] {'a', 'b', 'c'}},
        {'3', new char[] {'d', 'e', 'f'}},
        {'4', new char[] {'g', 'h', 'i'}},
        {'5', new char[] {'j', 'k', 'l'}},
        {'6', new char[] {'m', 'n', 'o'}},
        {'7', new char[] {'p', 'q', 'r', 's'}},
        {'8', new char[] {'t', 'u', 'v'}},
        {'9', new char[] {'w', 'x', 'y', 'z'}},
    };

    private List<string> _result = new ();
    private string _digits;

    private void F(int index, StringBuilder sb) {
        if (index == _digits.Length) {
            _result.Add(sb.ToString());
            return;
        }

        var digit = _digits[index];
        var chars = _table[digit];

        foreach (var c in chars) {
            sb.Append(c);
            F(index + 1, sb);
            sb.Remove(sb.Length-1, 1);
        }
    }



    public IList<string> LetterCombinations(string digits) {
        if (string.IsNullOrWhiteSpace(digits)) {
            return new List<string>();
        }

        _digits = digits;
        F(0, new StringBuilder());
        return _result;
    }
}