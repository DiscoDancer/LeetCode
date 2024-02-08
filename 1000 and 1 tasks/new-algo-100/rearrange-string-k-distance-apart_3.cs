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
            _result = sb.ToString();
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

    // s consists of only lowercase English letters.
    public string RearrangeString(string s, int k)
    {
        _k = k;
        var chars = s.ToCharArray().ToList();
        var positions = new int?[26];
        Generate(new StringBuilder(), chars, positions);

        return _result;
    }
}