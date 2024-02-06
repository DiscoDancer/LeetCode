// TL
public class Solution {
    // generate all substrings, filter out good

    // private List<string> _cadidates = new List<string>();
    
    // optimization: drop deadend branches


    private void Generate(StringBuilder sb, List<char> chars, int?[] positions)
    {
        if (_result != "")
        {
            return;
        }
        
        if (!chars.Any())
        {
            var candidate = sb.ToString();
            if (IsValid(candidate))
            {
                _result = candidate;
            }
            return;
        }

        for (int i = 0; i < chars.Count; i++)
        {
            var c = chars[i];
            
            if (positions[c - 'a'] == null || sb.Length - positions[c - 'a'].Value >= _k)
            {
                sb.Append(chars[i]);
                chars.RemoveAt(i);

                var prevPosition = positions[c - 'a'];
                positions[c - 'a'] = (sb.Length-1);

                Generate(sb, chars, positions);

                chars.Insert(i, c);
                sb.Remove(sb.Length - 1, 1);
                positions[c - 'a'] = prevPosition;
            }
        }
    }

    private int _k;
    private string _result = "";

    private bool IsValid(string candidate)
    {
        var indexes = new int?[26];
        for (int i = 0; i < candidate.Length; i++)
        {
            var c = candidate[i];

            if (indexes[c - 'a'].HasValue)
            {
                var d = i - indexes[c - 'a'].Value;
                if (d < _k)
                {
                    return false;
                }
            }

            indexes[c - 'a'] = i;
        }

        _result = candidate;
        return true;
    }

    // s consists of only lowercase English letters.
    public string RearrangeString(string s, int k)
    {
        _k = k;
        var chars = s.ToCharArray().ToList();
        var positions = new int?[s.Length];
        Generate(new StringBuilder(), chars, positions);

        return _result;
    }
}