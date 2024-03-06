public class Solution {
    private List<List<char>> _chars = new ();
    private string[] _result;
    private int _writtenCount = 0;

    private void F(int i, StringBuilder sb) {
        if (i == _chars.Count()) {
            _result[_writtenCount++] = sb.ToString();
            return;
        }

        foreach (var c in _chars[i]) {
            var length = sb.Length;
            sb.Append(c);
            F(i+1, sb);
            sb.Remove(length, 1);
        }
    }

    public string[] Expand(string s) {
        _chars = new List<List<char>>();

        var count = 1;

        var i = 0;
        while (i < s.Length) {
            if (char.IsLetter(s[i])) {
                _chars.Add(new List<char>() {s[i]});
                i++;
            }
            else {
                i++;
                var list = new List<char>();
                while (char.IsLetter(s[i])) {
                    list.Add(s[i]);
                    i++;
                    if (s[i] == ',') {
                        i++;
                    }
                }
                i++;
                list.Sort();
                _chars.Add(list);
                count *= list.Count();
            }
        }

        _result = new string[count];

        F(0, new StringBuilder());

        return _result;
    }
}