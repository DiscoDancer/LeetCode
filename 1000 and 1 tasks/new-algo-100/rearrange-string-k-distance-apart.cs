public class Solution {

    // out of memory
    // generate all substrings, filter out good

    private List<string> _cadidates = new List<string>();


    private void Generate(StringBuilder sb, List<char> chars)
    {
        if (!chars.Any())
        {
            _cadidates.Add(sb.ToString());
            return;
        }

        for (int i = 0; i < chars.Count; i++)
        {
            var c = chars[i];

            sb.Append(chars[i]);
            chars.RemoveAt(i);

            Generate(sb, chars);

            chars.Insert(i, c);
            sb.Remove(sb.Length - 1, 1);
        }
    }

    private int _k;
    private string _result;

    private bool IsValid(string cadidate)
    {
        var indexes = new int?[26];
        for (int i = 0; i < cadidate.Length; i++)
        {
            var c = cadidate[i];

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

        _result = cadidate;
        return true;
    }

    // s consists of only lowercase English letters.
    public string RearrangeString(string s, int k)
    {
        _k = k;
        var chars = s.ToCharArray().ToList();
        Generate(new StringBuilder(), chars);

        return _cadidates.Any(IsValid) ? _result : "";
    }
}