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

        var length = sb.Length;

        sb.Insert(0, '1');
        sb.Append('1');
        F(sb);
        sb.Remove(0, 1);
        sb.Remove(length, 1);

        sb.Insert(0, '0');
        sb.Append('0');
        F(sb);
        sb.Remove(0, 1);
        sb.Remove(length, 1);

        sb.Insert(0, '8');
        sb.Append('8');
        F(sb);
        sb.Remove(0, 1);
        sb.Remove(length, 1);

        sb.Insert(0, '6');
        sb.Append('9');
        F(sb);
        sb.Remove(0, 1);
        sb.Remove(length, 1);

        sb.Insert(0, '9');
        sb.Append('6');
        F(sb);
        sb.Remove(0, 1);
        sb.Remove(length, 1);
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