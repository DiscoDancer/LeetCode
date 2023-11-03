public class Solution {
    private char[] GetChars(char digit) {
        switch (digit) {
            case '2':
                return new char[] {'a', 'b', 'c'};
            case '3':
                return new char[] {'d', 'e', 'f'};
            case '4':
                return new char[] {'g', 'h', 'i'};
            case '5':
                return new char[] {'j', 'k', 'l'};
            case '6':
                return new char[] {'m', 'n', 'o'};
            case '7':
                return new char[] {'p', 'q', 'r', 's'};
            case '8':
                return new char[] {'t', 'u', 'v'};
            case '9':
                return new char[] {'w', 'x', 'y', 'z'};
        }

        throw new Exception();
    }

    private List<string> _result = new ();
    private string _digits;

    private void F(int index, StringBuilder sb) {
        if (index == _digits.Length) {
            _result.Add(sb.ToString());
            return;
        }

        var digit = _digits[index];
        var chars = GetChars(digit);

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