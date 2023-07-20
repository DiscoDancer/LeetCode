public class Solution {
    private string _digits;
    private List<string> _result = new ();

    private char[] GetChars(char x) {
        switch (x) {
            case '2': 
                return new char[] {'a','b','c'};
            case '3': 
                return new char[] {'d','e','f'};
            case '4': 
                return new char[] {'g','h','i'};
            case '5': 
                return new char[] {'j','k','l'};
            case '6': 
                return new char[] {'m','n','o'};
            case '7': 
                return new char[] {'p','q','r', 's'};
            case '8': 
                return new char[] {'t','u','v'};
            case '9': 
                return new char[] {'w','x','y', 'z'};
        }

        throw new Exception();
    }

    private void F(StringBuilder sb) {
        if (sb.Length == _digits.Length) {
            _result.Add(sb.ToString());
            return;
        }

        var curChar = _digits[sb.Length];
        foreach (var c in GetChars(curChar)) {
            sb.Append(c);
            F(sb);
            sb.Remove(sb.Length-1, 1);
        }
    }

    public IList<string> LetterCombinations(string digits) {
        _digits = digits;

        if (digits.Length > 0) {
            F(new StringBuilder());
        }

        return _result;
    }
}