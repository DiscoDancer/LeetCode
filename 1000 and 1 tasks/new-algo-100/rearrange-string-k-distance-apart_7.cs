public class Solution {
    // editorial
    public string RearrangeString(string s, int k)
    {
        var countTable = new int[26];
        foreach (var c in s)
        {
            countTable[c - 'a']++;
        }

        var free = new PriorityQueue<char, int>();
        for (int i = 0; i < 26; i++)
        {
            if (countTable[i] > 0)
            {
                var ch = (char)('a' + i);
                free.Enqueue(ch, -countTable[i]);
            }
        }

        var sb = new StringBuilder();
        var busy = new Queue<(int index, char ch)>();
        for (var i = 0; i < s.Length; i++)
        {
            if (busy.Count > 0 && (i - busy.Peek().index) >= k)
            {
                var top = busy.Dequeue();
                free.Enqueue(top.ch, -countTable[top.ch-'a']);
            }

            if (free.Count == 0)
            {
                return "";
            }

            var topFree = free.Dequeue();
            sb.Append(topFree);
            countTable[topFree - 'a']--;
            if (countTable[topFree - 'a'] > 0)
            {
                busy.Enqueue((i, topFree));
            }
        }

        return sb.ToString();
    }
}