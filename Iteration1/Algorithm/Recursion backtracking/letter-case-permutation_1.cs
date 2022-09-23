public class Solution {
    public IList<string> LetterCasePermutation(string s)
    {
        var lCount = s
            .Where((_, i) => char.IsLetter(s, i))
            .Count();

        if (lCount == 0)
        {
            return new List<string> { s };
        }

        var num = 1 << lCount;
        var appliedMaps = new List<string>();
        for (int i = 0; i < num; i++)
        {
            var sCurr = s.ToCharArray();
            var b = 0;

            for (int j = 0; j < sCurr.Length; j++)
            {
                if (char.IsLetter(sCurr[j]))
                {
                    if (((i >> b) & 1) == 0)
                    {
                        sCurr[j] = char.ToLower(sCurr[j]); 
                    }
                    else
                    {
                        sCurr[j] = char.ToUpper(sCurr[j]);
                    }

                    b++;
                }
            }

            appliedMaps.Add(new string(sCurr));
        }

        return appliedMaps;
    }
}