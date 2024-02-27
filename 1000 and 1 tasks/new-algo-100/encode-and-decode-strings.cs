public class Codec {

    /*
        Add meta info XXX count of strings, e.g. 001 or 200
        Add meta info length of strings, e.g. 001 or 200
        all strings must be appended to have max length
    */

    // Encodes a list of strings to a single string.
    public string encode(IList<string> strs) {
        var sb = new StringBuilder();

        foreach (var str in strs)
        {
            var length = str.Length;
            if (length < 100) {
                sb.Append('0');
            }
            if (length < 10) {
                sb.Append('0');
            }
            sb.Append(length);
            foreach (var c in str)
            {
                sb.Append(c);
            }
        }

        return sb.ToString();
    }

    // Decodes a single string to a list of strings.
    public IList<string> decode(string s)
    {
        var result = new List<string>();
        var i = 0;
        while (i < s.Length)
        {
            var sb = new StringBuilder();
            var length = int.Parse($"{s[i]}{s[i + 1]}{s[i + 2]}");
            i += 3;
            var j = 0;
            while (i < s.Length && j < length)
            {
                sb.Append(s[i]);
                i++;
                j++;
            }
            result.Add(sb.ToString());
        }

        return result;
    }
}

// Your Codec object will be instantiated and called as such:
// Codec codec = new Codec();
// codec.decode(codec.encode(strs));