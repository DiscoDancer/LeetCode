public class Solution {
    public string RearrangeString(string s, int k) {
        var countTable = new int[26];
        foreach (var c in s) {
            countTable[c-'a']++;
        }

        var lastIndexTable = new int[26];

        var list = new List<(char c, int score)>();
        for (var i = 0; i < 26; i++) {
            if (countTable[i] == 0)
            {
                continue;
            }
            
            var ch = (char)('a' + i);
            lastIndexTable[i] = -1;
            list.Add((ch, countTable[i]));
        }
        
        var sb = new StringBuilder();
        for (var i = 0; i < s.Length; i++)
        {
            var sortedList = list.OrderByDescending(x => x.score).ToList();
            var topChar = sortedList.First();
            if (topChar.score < 0)
            {
                return "";
            }

            sb.Append(topChar.c);
            sortedList.RemoveAt(0);
            countTable[topChar.c - 'a']--;
            lastIndexTable[topChar.c - 'a'] = i;
            if (countTable[topChar.c - 'a'] > 0)
            {
                sortedList.Add((topChar.c, topChar.score));
            }
            
            var newList = new List<(char c, int score)>();
            foreach (var element in sortedList)
            {
                var (c, score) = element;
                var lastIndex = lastIndexTable[c - 'a'];

                var d = i - lastIndex + 1;
                var ci = c - 'a';
                var newScore = lastIndex == -1 ? countTable[ci] : (d < k ? -1000 : countTable[ci]);
                newList.Add((c, newScore));
            }

            list = newList;
        }

        return sb.ToString();
    }
}