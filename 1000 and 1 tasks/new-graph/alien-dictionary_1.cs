public class Solution {
    // dependecies -> topologic sort -> answer
    public string AlienOrder(string[] words) {
        // I depend on
        var iLessThan = new List<char>?[26];
        var iBiggerThan = new int?[26];

        foreach (var w in words)
        {
            foreach (var c in w)
            {
                if (iLessThan[c-'a'] == null) {
                    iLessThan[c-'a'] = new ();
                }
                if (iBiggerThan[c-'a'] == null)
                {
                    iBiggerThan[c - 'a'] = 0;
                }
            }
        }

        var prevWord = words[0];
        for (int i = 0; i < words.Length; i++) {
            var curWord = words[i];

            var minLength = Math.Min(curWord.Length, prevWord.Length);
            var firstDifferentIndex = 0;
            while (firstDifferentIndex < minLength && curWord[firstDifferentIndex] == prevWord[firstDifferentIndex])
            {
                firstDifferentIndex++;
            }

            // same words
            if (firstDifferentIndex == minLength) {
                if (curWord.Length < prevWord.Length)
                {
                    return "";
                }
                continue;
            }

            var prevC = prevWord[firstDifferentIndex];
            var curC = curWord[firstDifferentIndex];
            iLessThan[prevC-'a'].Add(curC);
            iBiggerThan[curC-'a']++;

            prevWord = curWord;
        }

        var result = new StringBuilder();
        var queue = new Queue<char>();

        var totalCount = 0;
        for (int i = 0; i < 26; i++)
        {
            if (iBiggerThan[i] != null)
            {
                totalCount++;
            }
            
            if (iBiggerThan[i] != null && iBiggerThan[i] == 0)
            {
                var c = (char)('a' + i);
                queue.Enqueue(c);
            }
        }

        var countProcessed = 0;
        while (queue.Any())
        {
            var curC = queue.Dequeue();
            result.Append(curC);
            countProcessed++;

            var candidates = iLessThan[curC - 'a'];
            foreach (var candidate in candidates)
            {
                iBiggerThan[candidate - 'a']--;
                if (iBiggerThan[candidate - 'a'] == 0)
                {
                    queue.Enqueue(candidate);
                }
            }
        }
        
        return totalCount == countProcessed ? result.ToString() : "";
    }
}