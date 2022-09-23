public class Solution {
    
    public string FreqAlphabets(string s)
    {
        var sb = new StringBuilder();

        for (int i = 0; i < s.Length; i++)
        {
            if (char.IsDigit(s[i]))
            {
                // is #12
                if (i < s.Length - 2)
                {
                    if (s[i + 2] == '#')
                    {
                        var num = ((int)s[i] - (int)'0') * 10 + ((int)s[i + 1] - (int)'0');
                        sb.Append((char)(num - 1 + (int)'a'));
                        i += 2;
                        continue;
                    }
                    else
                    {
                        var num = (int) s[i] - (int) '0';
                        sb.Append((char)(num - 1 + (int)'a'));
                        continue;
                    }
                }
                else
                {
                    var num = (int)s[i] - (int)'0';
                    sb.Append((char)(num - 1 + (int)'a'));
                    continue;
                }
            }
        }

        return sb.ToString();
    }
}