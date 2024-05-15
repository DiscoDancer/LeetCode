public class Solution {
    public string AlienOrder(string[] words)
    {
        // could use array
        var iLessThanTable = new Dictionary<char, HashSet<char>>();
        var iBiggerThanTable = new Dictionary<char, HashSet<char>>();
        var uniqueLetters = new HashSet<char>();

        foreach (var word in words)
        {
            foreach (var c in word)
            {
                uniqueLetters.Add(c);
            }
        }

        for (int wi = 1; wi < words.Length; wi++)
        {
            var curWord = words[wi];
            var prevWord = words[wi - 1];

            var minLength = Math.Min(curWord.Length, prevWord.Length);
            var ci = 0;
            while (ci < minLength && curWord[ci] == prevWord[ci])
            {
                ci++;
            }

            // ["abc","ab"]
            if (ci == minLength && prevWord.Length > curWord.Length)
            {
                return "";
            }

            if (ci < minLength)
            {
                // a < b

                var a = prevWord[ci];
                var b = curWord[ci];

                if (!iLessThanTable.ContainsKey(a))
                {
                    iLessThanTable[a] = new();
                }

                if (!iBiggerThanTable.ContainsKey(b))
                {
                    iBiggerThanTable[b] = new();
                }

                iLessThanTable[a].Add(b);
                iBiggerThanTable[b].Add(a);

                // проверка на противоречия
                if (iLessThanTable.ContainsKey(b) && iLessThanTable[b].Contains(a) ||
                    iBiggerThanTable.ContainsKey(a) && iBiggerThanTable[a].Contains(b))
                {
                    return "";
                }
            }
        }

        var sb = new StringBuilder();

        var queue = new Queue<char>();
        foreach (var c in uniqueLetters)
        {
            if (!iBiggerThanTable.ContainsKey(c))
            {
                queue.Enqueue(c);
            }
        }

        while (queue.Any())
        {
            var cur = queue.Dequeue();
            sb.Append(cur);
            if (iLessThanTable.ContainsKey(cur))
            {
                foreach (var other in iLessThanTable[cur])
                {
                    if (iBiggerThanTable.ContainsKey(other))
                    {
                        iBiggerThanTable[other].Remove(cur);
                        if (iBiggerThanTable[other].Count == 0)
                        {
                            queue.Enqueue(other);
                        }
                    }
                }
            }
        }

        if (sb.Length != uniqueLetters.Count) {
            return "";
        }
        
        return sb.ToString();
    }
}