public class Solution {
    public static int[] GetBin(int x, int size)
    {
        var list = new List<int>();

        while (x > 0)
        {
            list.Add(x % 2);
            x /= 2;
        }
        list.Reverse();

        var list2 = new List<int>();

        for (var i = 0; i < size - list.Count(); i++)
        {
            list2.Add(0);
        }

        list2.AddRange(list);

        return list2.ToArray();
    }
    
    public IList<string> LetterCasePermutation(string s) {
        var lCount = s
            .Where((_, i) => char.IsLetter(s, i))
            .Count();

        if (lCount == 0)
        {
            return new List<string> { s };
        }

        var num = System.Math.Pow(2, lCount);
        var maps = new List<int[]>();
        for (int i = 0; i < num; i++)
        {
            maps.Add(GetBin(i, lCount));
        }

        var appliedMaps = new List<string>();

        foreach (var map in maps)
        {
            int k = 0;
            var sCurr = s.ToCharArray();
            for (int i = 0; i < s.Length; i++)
            {
                if (char.IsLetter(sCurr[i]))
                {
                    if (map[k] == 1)
                    {
                        sCurr[i] = char.ToLower(sCurr[i]);
                    }
                    else
                    {
                        sCurr[i] = char.ToUpper(sCurr[i]);
                    }
                    k++;

                }
            }

            appliedMaps.Add(new string(sCurr));
        }

        return appliedMaps;
    }
}