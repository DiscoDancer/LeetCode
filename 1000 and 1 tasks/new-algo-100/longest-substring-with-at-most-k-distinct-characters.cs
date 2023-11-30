public class Solution {
    public int LengthOfLongestSubstringKDistinct(string s, int k) {
        if (k == 0) {
            return 0;
        }

        var table = new Dictionary<char, List<int>>();
        var list = new List<char>();

        var prev = '1';
        var prevCount = 1;
        var max = 0;
        var curScore = 0;
        for (int i = 0; i < s.Length + 1; i++)
        {
            var c = i < s.Length ? s[i] : '1';
            if (c == prev)
            {
                prevCount++;
            }
            if (prev != '1' && c != prev)
            {
                while (!(table.ContainsKey(prev) || table.Keys.Count() < k))
                {
                    var head = list.First();
                    curScore -= table[head].First();
                    if (table[head].Count() > 1)
                    {
                        table[head].RemoveAt(0);
                    }
                    else
                    {
                        table.Remove(head);
                    }
                    list.RemoveAt(0);
                }
                list.Add(prev);
                if (table.ContainsKey(prev))
                {
                    table[prev].Add(prevCount);
                }
                else
                {
                    table[prev] = new List<int>() { prevCount };
                }

                curScore += prevCount;
                max = Math.Max(max, curScore);

                prevCount = 1;
            }
            prev = c;
        }

        return max;
    }
}