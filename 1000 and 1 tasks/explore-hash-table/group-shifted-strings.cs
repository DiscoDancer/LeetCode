public class Solution {
    // выравниваем строки, чтобы первая буква была 'a'
    private string Encode (string s) {
        if (s.Length <= 1) {
            return s.Length.ToString();
        }

        var diff = s[0] - 'a';
        var sb = new StringBuilder();
        foreach (var c in s)
        {
            var cur = c - 'a';
            cur -= diff;
            if (cur < 0)
            {
                cur += 26;
            }
            sb.Append(cur);
            // важно, иначе 1 1 и 11 сольются
            sb.Append(';'); 
        }
        
        return sb.ToString();
    }

    public IList<IList<string>> GroupStrings(string[] strings) {
        var table = new Dictionary<string, IList<string>>();
        foreach (var s in strings) {
            var encoded = Encode(s);
            if (!table.ContainsKey(encoded)) {
                table[encoded] = new List<string>();
            }
            table[encoded].Add(s);
        }

        return table.Values.ToList();
    }
}