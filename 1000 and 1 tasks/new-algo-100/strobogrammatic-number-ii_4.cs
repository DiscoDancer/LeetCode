public class Solution {
    private readonly List<string> _result = new ();
    private int _n;

    private void F(StringBuilder sb) {
        if (sb.Length == _n) {
            if (_n == 1 || sb[0] != '0') {
                _result.Add(sb.ToString());
            }
            return;
        }
        
        var pairs = new List<(char begin, char end)>()
        {
            ('0', '0'),
            ('1', '1'),
            ('8', '8'),
            ('6', '9'),
            ('9', '6'),
        };

        var length = sb.Length;
        foreach (var (begin, end) in pairs)
        {
            sb.Insert(0, begin);
            sb.Append(end);
            F(sb);
            sb.Remove(0, 1);
            sb.Remove(length, 1);
        }
    }

    public IList<string> FindStrobogrammatic(int n) {
        _n = n;

        if (n % 2 == 0) {
            F(new StringBuilder());
        }
        else {
            F(new StringBuilder("1"));
            F(new StringBuilder("0"));
            F(new StringBuilder("8"));
        }


        return _result;
    }
}